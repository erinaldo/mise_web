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
using mise.exception;

namespace mise
{
    public partial class FrmProdutos : Form
    {
        private ProdutoRepo _produtoRepo = ProdutoRepo.Instance;
        private List<Produto> _produtos;
        private long _codSelecionado;

        public FrmProdutos()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            long codigo;

            if (long.TryParse(txtPesquisa.Text, out codigo))
            {
                Produto p = null;
                try
                {
                    p = _produtoRepo.Obter(codigo);
                }
                catch (MiseException)
                {
                    
                }
                _produtos.Clear();
                if (p != null)
                {
                    _produtos.Add(p);
                }

                gridProdutos.Rows.Clear();
                gridProdutos.Rows.Add(p.Codigo, p.Nome, p.PrecoVenda.ToString("0.00"), p.UnidadeMedida);
            }
            else
            {
                _produtos = _produtoRepo.Listar(txtPesquisa.Text);
                if (IsHandleCreated)
                {
                    this.Invoke((MethodInvoker)delegate {
                        gridProdutos.Rows.Clear();

                        foreach (var p in _produtos)
	                    {
                            gridProdutos.Rows.Add(p.Codigo, p.Nome, p.PrecoVenda);
	                    }

                        if (gridProdutos.SortedColumn != null)
                        {
                            gridProdutos.Sort(gridProdutos.SortedColumn, gridProdutos.SortOrder == SortOrder.Ascending ? ListSortDirection.Ascending : ListSortDirection.Descending);
                        }
                        gridProdutos.ClearSelection();
                    });
                }
            }
            txtPesquisa.SelectAll();
        }

        private void FrmProdutos2_Load(object sender, EventArgs e)
        {
            _produtoRepo.Changed += new EventHandler(carregar);
        }

        private void carregar(object sender, EventArgs e)
        {
            if (_produtos != null && _produtos.Count > 0)
            {
                btnBuscar_Click(sender, e);
            }
        }

        private void toolBtnNovo_Click(object sender, EventArgs e)
        {
            new FrmProduto().ShowDialog();
        }

        private void gridProdutos_SelectionChanged(object sender, EventArgs e)
        {
            if (gridProdutos.SelectedRows.Count > 0)
            {
                _codSelecionado = Convert.ToInt64(gridProdutos.SelectedRows[0].Cells[0].Value);
                toolBtnAlterar.Enabled = true;
                toolBtnExcluir.Enabled = true;
            }
            else
            {
                _codSelecionado = 0;
                toolBtnAlterar.Enabled = false;
                toolBtnExcluir.Enabled = false;
            }

        }

        private void toolBtnAlterar_Click(object sender, EventArgs e)
        {
            if (_codSelecionado == 0)
            {
                MessageBox.Show("Nenhum produto selecionado!");
            }
            else
            {
                new FrmProduto(_produtoRepo.Obter(_codSelecionado)).ShowDialog();
            }
        }

        private void toolBtnExcluir_Click(object sender, EventArgs e)
        {
            if (_codSelecionado == 0)
            {
                MessageBox.Show("Nenhum produto selecionado!");
            }
            else
            {
                try
                {
                    Produto p = _produtoRepo.Obter(_codSelecionado);
                    DialogResult r = MessageBox.Show("Deseja REALMENTE excluir o produto " + p.Nome + "?", "Excluir Produto",
                        MessageBoxButtons.YesNo, MessageBoxIcon.None, MessageBoxDefaultButton.Button2);

                    if (r == DialogResult.Yes)
                    {
                        _produtoRepo.Excluir(p.Id);
                    }
                }
                catch (Exception ee)
                {
                    MessageBox.Show(ee.Message);
                }
            }
        }
    }
}
