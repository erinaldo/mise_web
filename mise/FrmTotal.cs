using mise.exception;
using mise.external;
using mise.log;
using mise.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mise
{
    public partial class FrmTotal : Form
    {
        private List<FormaPagamento> _formasPagamento;
        private FormaPagamentoRepo _formaPagamentoRepo;
        private Venda _venda;

        private Logger _logger;

        public FrmTotal(Venda v)
        {
            InitializeComponent();
            _venda = v;

            _logger = Logger.Instance;

            txtValor.Text = _venda.Total.ToString();

            _formaPagamentoRepo = FormaPagamentoRepo.Instance;
            _formasPagamento = _formaPagamentoRepo.Listar();

            cbxTipoPagamento.DataSource = _formasPagamento;
            cbxTipoPagamento.DisplayMember = "DescricaoFmt";
            cbxTipoPagamento.ValueMember = "Id";

            foreach (var p in _venda.Pagamentos)
            {
                gridPagamento.Rows.Add(p.FormaPagamento.Nome, p.Valor);
            }

            gridPagamento.ClearSelection();

            lblRestante.Text = _venda.TotalAPagar.ToString("C2");
        }

        private void txtValor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = e.SuppressKeyPress = true;

                if (txtValor.Text == "")
                {
                    MessageBox.Show("Informe o valor pago!");
                    return;
                }
                decimal valor = Convert.ToDecimal(txtValor.Text);

                try
                {
                    Venda.Pagamento p = _venda.Pagar(valor, (FormaPagamento) cbxTipoPagamento.SelectedItem);
                    gridPagamento.Rows.Add(p.FormaPagamento.Nome, p.Valor.ToString("0.00"));
                    gridPagamento.ClearSelection();

                    lblTroco.Text = _venda.Troco.ToString("C2");
                    lblRestante.Text = _venda.TotalAPagar.ToString("C2");

                    txtValor.Text = _venda.TotalAPagar.ToString();
                    txtValor.SelectAll();

                    lblTotalPago.Text = _venda.TotalPago.ToString("C2");
                    
                    if (_venda.TotalAPagar == 0)
                    {
                        Impressora.Instance.AbrirGaveta();
                    }
                }
                catch (MiseException ve)
                {
                    MessageBox.Show(ve.Message);
                }
                catch (Exception ee)
                {
                    _logger.Log(ee);
                    MessageBox.Show(ee.Message);
                }
            }
        }

        private void cbxTipoPagamento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = e.SuppressKeyPress = true;
                txtValor.Focus();
                txtValor.SelectAll();
            }
        }

        private void FrmPagamento_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F9:
                    cbxTipoPagamento.Focus();
                    cbxTipoPagamento.DroppedDown = true;
                    break;
                case Keys.F10:
                    e.Handled = e.SuppressKeyPress = true;
                    try
                    {
                        _venda.Concluir();
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    catch (MiseException ve)
                    {
                        MessageBox.Show(ve.Message);
                    }
                    catch (Exception ee)
                    {
                        _logger.Log(ee);
                        MessageBox.Show(ee.Message);
                    }
                    break;
                case Keys.Escape:
                    this.Close();
                    break;
                case Keys.A:
                    cbxTipoPagamento.SelectedIndex = 0;
                    break;
                case Keys.S:
                    cbxTipoPagamento.SelectedIndex = 1;
                    break;
                case Keys.D:
                    cbxTipoPagamento.SelectedIndex = 2;
                    break;
                case Keys.F:
                    cbxTipoPagamento.SelectedIndex = 3;
                    break;
                case Keys.G:
                    cbxTipoPagamento.SelectedIndex = 4;
                    break;
                case Keys.H:
                    cbxTipoPagamento.SelectedIndex = 5;
                    break;
                case Keys.J:
                    cbxTipoPagamento.SelectedIndex = 6;
                    break;
                case Keys.K:
                    cbxTipoPagamento.SelectedIndex = 7;
                    break;
            }
        }

        private void cbxTipoPagamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtValor.Focus();
            txtValor.SelectAll();
        }

        private void FrmTotal_Shown(object sender, EventArgs e)
        {
            lblTotal.Text = _venda.Total.ToString("C2");
            txtValor.Focus();
            txtValor.SelectAll();
        }

    }
}
