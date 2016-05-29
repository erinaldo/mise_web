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
                if (txtCodigo.Text != "")
                {
                    gridProdutos.Rows.Clear();
                    Produto p = _repo.Obter(Convert.ToInt64(txtCodigo.Text));

                    gridProdutos.Rows.Add(p.Codigo, p.Nome, p.PrecoVenda.ToString("0.00"), p.UnidadeMedida);
                }
                else
                {
                    List<Produto> produtos = _repo.Listar(txtNome.Text);

                    gridProdutos.Rows.Clear();

                    foreach (var p in produtos)
                    {
                        gridProdutos.Rows.Add(p.Codigo, p.Nome, p.PrecoVenda.ToString("0.00"), p.UnidadeMedida);
                    }
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
        }

        private void rdNome_CheckedChanged(object sender, EventArgs e)
        {
            radioChange();
        }

        private void rdCodigo_CheckedChanged(object sender, EventArgs e)
        {
            radioChange();
        }

        private void radioChange()
        {
            txtCodigo.Visible = rdCodigo.Checked;
            txtNome.Visible = rdNome.Checked;
            if (rdCodigo.Checked)
            {
                txtNome.Text = "";
                txtCodigo.Focus();
            }
            else
            {
                txtCodigo.Text = "";
                txtNome.Focus();
            }
        }

        private void FrmConsultarPreco_Shown(object sender, EventArgs e)
        {
            txtCodigo.Focus();
        }
    }
}
