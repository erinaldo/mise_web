using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using mise.model;
using System.Data.SqlClient;
using System.Configuration;
using mise.external;
using mise.report;
using mise.exception;
using mise.log;
using mise.dbutil;
using System.Threading;
using System.IO;
using System.Reflection;

namespace mise
{
    public partial class FrmMain : Form
    {
        private ICatalogo _catalogo;
        private VendaRepo _vendaRepo;
        private FormaPagamentoRepo _formaPagamentoRepo;
        private Balanca _balanca;

        private Venda _ultimaVenda;
        
        private Logger _logger;

        private Font FONT_BOLD;
        private Font FONT_REGULAR;

        private Venda venda;

        private Impressora Impressora { get { return Impressora.Instance; } }

        public FrmMain()
        {
            InitializeComponent();

            _logger = Logger.Instance;

            _catalogo = ProdutoRepo.Instance;
            _vendaRepo = VendaRepo.Instance;
            _formaPagamentoRepo = FormaPagamentoRepo.Instance;

            this.FONT_BOLD = new Font(this.Font, FontStyle.Bold);
            this.FONT_REGULAR = new Font(this.Font, FontStyle.Regular);
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            _logger.Log("iniciou");

            inicializar();
            try
            {
                _balanca = Balanca.Instance;
            }
            catch (Exception ex)
            {
                _logger.Log(ex);
                MessageBox.Show("Não foi possível conectar com a balança. Reinicie o sistema.");
            }

            try
            {
                var i = Impressora.Instance;
            }
            catch (Exception ex)
            {
                _logger.Log(ex);
                MessageBox.Show("Não foi possível conectar com a impressora. Reinicie o sistema.");
            }

            timerDataHora.Interval = 1000;
            timerDataHora.Start();
        }

        private void inicializar()
        {
            venda = Venda.Iniciar(_catalogo);
            gridItem.Rows.Clear();
            gridItem.Rows.Add("#", "Código", "Produto", "Preço Un", "Qtd", "Un", "Subtotal");
            gridItem.Rows[0].Frozen = true;
            gridItem.Rows[0].DefaultCellStyle.ForeColor = Color.DarkGray;
            gridItem.Rows[0].DefaultCellStyle.Font = FONT_BOLD;

            lblTotal.Text = "R$ 0,00";
            lblProduto.Text = "";

            resetInputs();
        }

        private void resetInputs()
        {
            txtQtd.ReadOnly = true;
            txtPreco.ReadOnly = true;

            txtCodigo.ReadOnly = false;
            txtCodigo.Focus();
            gridItem.ClearSelection();

            lblCodigo.ForeColor = Color.Black;
            lblCodigo.Font = FONT_BOLD;
        }

        private void frmMain_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F2:
                    if (new FrmTotal(venda).ShowDialog() == DialogResult.OK)
                    {
                        Venda v = _vendaRepo.Incluir(venda);
                        _ultimaVenda = v;
                        inicializar();
                    }
                    else
                    {
                        venda.CancelarPagamento();
                    }

                    break;
                case Keys.F3: // quantidade
                    resetInputs();
                    txtCodigo.Text = "";
                    txtCodigo.ReadOnly = true;
                    txtPreco.Text = "";
                    txtQtd.ReadOnly = false;
                    txtQtd.SelectAll();
                    txtQtd.Focus();
                    break;
                case Keys.F4: // balanca
                    try
                    {
                        txtQtd.Text = _balanca.LerPeso();
                    }
                    catch (Exception ex)
                    {
                        txtQtd.Text = "";
                        _logger.Log(ex);
                        MessageBox.Show(ex.Message);
                    }
                    break;  
                case Keys.F6:
                    // cancelar item
                    FrmCancelarItem frmCancelarItem = new FrmCancelarItem(venda);

                    if (frmCancelarItem.ShowDialog() == DialogResult.OK)
                    {
                        e.Handled = e.SuppressKeyPress = true;

                        int sequencial = frmCancelarItem.Sequencial;

                        try
                        {
                            DataGridViewRow row = gridItem.Rows[sequencial];
                            row.DefaultCellStyle.ForeColor = Color.LightGray;
                            txtCodigo.Focus();
                            lblTotal.Text = venda.Total.ToString("C2");

                            resetInputs();
                        }
                        catch (MiseException me)
                        {
                            MessageBox.Show(me.Message);
                        }
                        catch (Exception ee)
                        {
                            _logger.Log(ee);
                            MessageBox.Show(ee.Message);
                        }
                    }
                    else
                    {
                        e.Handled = e.SuppressKeyPress = true;
                        resetInputs();
                        txtCodigo.Focus();
                    }

                    break;
                case Keys.F7: // cancelar venda
                     DialogResult r = MessageBox.Show("Deseja REALMENTE cancelar a venda?", "Cancelar Venda", 
                         MessageBoxButtons.YesNo, MessageBoxIcon.None, MessageBoxDefaultButton.Button2);

                    if (r == DialogResult.Yes)
                    {
                        inicializar();
                    }
                    
                    break;
                case Keys.F9:
                    try
                    {
                        if (_ultimaVenda == null)
                        {
                            long idUltimaVenda = _vendaRepo.ObterUltimoId();
                            _ultimaVenda = _vendaRepo.Obter(idUltimaVenda);
                        }

                        if (_ultimaVenda == null) {
                            MessageBox.Show("Nenhuma venda concluída até o momento!");
                        } else {
                            Cupom cupom = new Cupom(_ultimaVenda);
                            Impressora.Imprimir(cupom.Gerar());
                            Impressora.CortarPapel();
                        }
                    }
                    catch (MiseException me)
                    {
                        MessageBox.Show(me.Message);
                    }
                    catch (Exception ee)
                    {
                        _logger.Log(ee);
                        MessageBox.Show(ee.Message);
                    }

                    break;
                case Keys.F10:
                    e.Handled = e.SuppressKeyPress = true;
                    break;
                case Keys.F11:
                    new FrmConsultarPreco().ShowDialog();

                    break;
                case Keys.F12:
                    e.Handled = e.SuppressKeyPress = true;
                    gerarResumoDiario();

                    break;
                case Keys.PageDown:
                    if (gridItem.FirstDisplayedScrollingRowIndex < (gridItem.RowCount - 1))
                        gridItem.FirstDisplayedScrollingRowIndex = gridItem.FirstDisplayedScrollingRowIndex + 1;
                    break;
                case Keys.PageUp:
                    if (gridItem.FirstDisplayedScrollingRowIndex > 1)
                        gridItem.FirstDisplayedScrollingRowIndex = gridItem.FirstDisplayedScrollingRowIndex - 1;
                    break;
                case Keys.Alt:
                    e.Handled = e.SuppressKeyPress = true;
                    break;
                case Keys.Q:
                    e.Handled = e.SuppressKeyPress = true;
                    Impressora.AbrirGaveta();
                    break;
                case Keys.W:
                    sair();
                    break;
                case Keys.B:
                    if (e.Control && e.Alt && e.Shift)
                    {
                        e.Handled = e.SuppressKeyPress = true;
                        new FrmRestore().ShowDialog();
                    }
                    break;
                default:
                    if (e.Modifiers.Equals(Keys.Alt))
                    {
                        e.Handled = true;
                    }
                    break;
            }
        }

        private void txtCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = e.SuppressKeyPress = true;

                if (txtCodigo.Text == "")
                {
                    MessageBox.Show("Informe um código!");
                    return;
                }

                long codProduto = Convert.ToInt64(txtCodigo.Text);

                if (codProduto == Produto.DIVERSOS)
                {
                    txtCodigo.ReadOnly = true;
                    txtPreco.ReadOnly = false;
                    txtPreco.Focus();
                    lblProduto.Text = _catalogo.Obter(Produto.DIVERSOS).Descricao;
                }
                else
                {
                    try
                    {
                        decimal qtd = txtQtd.Text != "" ? Convert.ToDecimal(txtQtd.Text) : 1;
                        Item item = venda.AdicionarItem(codProduto, qtd);
                        lblProduto.Text = item.Produto.Descricao;
                        adicionarItemGrid(item);
                    }
                    catch (MiseException pe)
                    {
                        MessageBox.Show(pe.Message);
                        txtCodigo.Text = "";
                    }
                    catch (Exception ee)
                    {
                        txtCodigo.Text = "";
                        _logger.Log(ee);
                        MessageBox.Show(ee.Message);
                    }
                    resetInputs();
                }
            }
            else if (e.KeyCode == Keys.Escape)
            {
                e.Handled = e.SuppressKeyPress = true;

                resetInputs();
                txtQtd.Text = "";
                txtCodigo.Text = "";
                txtCodigo.Focus();
            }
        }

        private void adicionarItemGrid(Item item)
        {
            int index = gridItem.Rows.Add(item.Sequencial, item.Codigo, item.NomeProduto, 
                item.PrecoUni.ToString("0.00"), item.Qtd.ToString("0.000"), item.Produto.UnidadeMedida, item.Total.ToString("0.00"));
            gridItem.Rows[index].Cells[0].Style.Font = FONT_BOLD;
            gridItem.FirstDisplayedScrollingRowIndex = gridItem.RowCount - 1;

            txtCodigo.Text = "";
            txtQtd.Text = "";
            txtPreco.Text = "";
            txtCodigo.Focus();
            lblTotal.Text = "" + venda.Total.ToString("C2");
        }

        private void txtQtd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = e.SuppressKeyPress = true;

                if (txtQtd.Text == "")
                {
                    MessageBox.Show("Informe a quantidade!");
                    return;
                }

                txtQtd.ReadOnly = true;
                txtCodigo.ReadOnly = false;
                txtCodigo.Focus();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                e.Handled = e.SuppressKeyPress = true;
                txtQtd.Text = "";
                resetInputs();
            }
        }

        private void txtPreco_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = e.SuppressKeyPress = true;

                if (txtPreco.Text == "")
                {
                    MessageBox.Show("Informe o preço!");
                    return;
                }

                decimal preco = Convert.ToDecimal(txtPreco.Text);
                if (preco <= 0)
                {
                    MessageBox.Show("Informe o preço!");
                    return;
                }

                decimal qtd = txtQtd.Text != "" ? Convert.ToDecimal(txtQtd.Text) : 1;

                adicionarItemGrid(venda.AdicionarItemDiversos(qtd, preco));

                resetInputs();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                e.Handled = e.SuppressKeyPress = true;
                txtPreco.Text = "";
                resetInputs();
            }
        }

        private void txtQtd_ReadOnlyChanged(object sender, EventArgs e)
        {

            if (!txtQtd.ReadOnly)
            {
                lblQtd.ForeColor = Color.Black;
                lblQtd.Font = FONT_BOLD;
            }
            else
            {
                // lblQtd.ForeColor = Color.DarkGray;
                lblQtd.Font = FONT_REGULAR;
            }
        }

        private void txtPreco_ReadOnlyChanged(object sender, EventArgs e)
        {
            if (!txtPreco.ReadOnly)
            {
                lblPreco.ForeColor = Color.Black;
                lblPreco.Font = FONT_BOLD;
            }
            else
            {
                // lblPreco.ForeColor = Color.DarkGray;
                lblPreco.Font = FONT_REGULAR;
            }
        }

        private void txtCodigo_ReadOnlyChanged(object sender, EventArgs e)
        {
            if (!txtCodigo.ReadOnly)
            {
                lblCodigo.ForeColor = Color.Black;
                lblCodigo.Font = FONT_BOLD;
            }
            else
            {
                // lblCodigo.ForeColor = Color.DarkGray;
                lblCodigo.Font = FONT_REGULAR;
            }
        }

        private void FrmMain_Click(object sender, EventArgs e)
        {
            voltarFocoParaInput();
        }

        private void voltarFocoParaInput()
        {
            if (!txtCodigo.ReadOnly)
            {
                txtCodigo.Focus();
            }
            else if (!txtQtd.ReadOnly)
            {
                txtQtd.Focus();
            }
            else if (!txtPreco.ReadOnly)
            {
                txtPreco.Focus();
            }
        }

        private void menuItemProdutos_Click(object sender, EventArgs e)
        {
            new FrmProdutos().ShowDialog();
        }

        private void fornecedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FrmFornecedores().ShowDialog();
        }

        private void gruposToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FrmGrupos().ShowDialog();
        }

        private void formasDePagamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FrmFormasPagamento().ShowDialog();
        }

        private void gridItem_Click(object sender, EventArgs e)
        {
            gridItem.ClearSelection();
            voltarFocoParaInput();
        }

        private void gridItem_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            menuItemCadastros.Enabled = gridItem.Rows.Count == 1;
        }

        private void menuItemSair_Click(object sender, EventArgs e)
        {
            sair();
        }

        private void sair()
        {
            if (venda != null && venda.Itens.Count > 0)
            {
                MessageBox.Show("Venda em andamento! Não pode sair do mise ainda!");
            }
            else
            {
                DialogResult r = MessageBox.Show("Deseja REALMENTE fechar o mise?", "Fechar",
                             MessageBoxButtons.YesNo, MessageBoxIcon.None, MessageBoxDefaultButton.Button2);

                if (r == DialogResult.Yes)
                {
                    FrmWait frmWait = new FrmWait("Fechando mise");

                    bgWorker.RunWorkerAsync();
                    frmWait.ShowDialog();
                }
            }
        }

        private void txtQtd_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox txtBox = ((TextBox) sender);
            int index = txtBox.Text.IndexOf(',');
            bool validChar = char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar) || e.KeyChar == ',';

            if ((e.KeyChar == ',' && index > 0)
                || !validChar
                || (char.IsDigit(e.KeyChar) && index >= 0 && index < txtBox.Text.Length - 3)
                )
            {
                e.Handled = true;
                return;
            }
        }

        private void txtQtd_TextChanged(object sender, EventArgs e)
        {
            TextBox txtBox = ((TextBox)sender);
            if (txtBox.Text.Equals(","))
            {
                txtBox.Text = txtBox.Text.Insert(0, "0");
                txtBox.SelectionStart = txtBox.Text.Length;
            }
        }

        private void doDiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FrmLancamentos().ShowDialog();
        }

        private void categoriasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FrmCategorias().ShowDialog();
        }



        private void resumoDiarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gerarResumoDiario();
        }

        private void gerarResumoDiario()
        {
            try
            {
                Resumo resumo = new Resumo(DateTime.Now, DateTime.Now, _vendaRepo, _formaPagamentoRepo, LancamentoRepo.Instance);
                Impressora.Imprimir(resumo.Gerar());
                Impressora.CortarPapel();
            }
            catch (MiseException me)
            {
                MessageBox.Show(me.Message);
            }
            catch (Exception ee)
            {
                _logger.Log(ee);

                MessageBox.Show(ee.Message);
            }
        }

        private void bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            _balanca.FecharConexao();
            Impressora.FecharConexao();

            try
            {
                _logger.Log("backup - iniciando");
                DBUtil.Backup();
                _logger.Log("backup - concluido");

            }
            catch (Exception ee)
            {
                _logger.Log("backup - erro");
                _logger.Log(ee);
            }

            this.Invoke((MethodInvoker)delegate
            {
                _logger.Log("saiu");
                Application.Exit();
            });
        }

        private void txtQtd_Enter(object sender, EventArgs e)
        {
            if (txtQtd.ReadOnly)
            {
                voltarFocoParaInput();
            }
        }

        private void txtCodigo_Enter(object sender, EventArgs e)
        {
            if (txtCodigo.ReadOnly)
            {
                voltarFocoParaInput();
            }
        }

        private void txtPreco_Enter(object sender, EventArgs e)
        {
            if (txtPreco.ReadOnly)
            {
                voltarFocoParaInput();
            }
        }

        private void gridItem_Enter(object sender, EventArgs e)
        {
            voltarFocoParaInput();
        }

        private void timerDataHora_Tick(object sender, EventArgs e)
        {
            lblDataHora.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
        }

        private void doDiaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new FrmUltimasVendas().ShowDialog();
        }

        private void porProdutoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FrmRelatorioProduto().ShowDialog();
        }

        private void porFormaDePagamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FrmRelatorioFormaPagamento().ShowDialog();
        }

    }
}
