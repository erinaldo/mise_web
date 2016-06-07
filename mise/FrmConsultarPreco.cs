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
using mise.log;

namespace mise
{
    public partial class FrmConsultarPreco : Form
    {
        private ProdutoRepo _repo = ProdutoRepo.Instance;
        private Logger _logger = Logger.Instance;

        public FrmConsultarPreco()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                long codigo;

                if (long.TryParse(txtPesquisa.Text, out codigo))
                {
                    gridProdutos.Rows.Clear();
                    Produto p = _repo.Obter(codigo);

                    gridProdutos.Rows.Add(p.Codigo, p.Nome, p.PrecoVenda.ToString("0.00"), p.UnidadeMedida);
                }
                else
                {
                    List<Produto> produtos = _repo.Listar(txtPesquisa.Text);

                    gridProdutos.Rows.Clear();

                    foreach (var p in produtos)
                    {
                        gridProdutos.Rows.Add(p.Codigo, p.Nome, p.PrecoVenda.ToString("0.00"), p.UnidadeMedida);
                    }
                }

                txtPesquisa.SelectAll();
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

        private void FrmConsultarPreco_Shown(object sender, EventArgs e)
        {
            gridProdutos.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            gridProdutos.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            txtPesquisa.Focus();
        }

        private void FrmConsultarPreco_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
