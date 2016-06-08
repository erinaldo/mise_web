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
    public partial class FrmProduto : Form
    {
        private Produto _produto;
        private GrupoRepo _grupos = GrupoRepo.Instance;
        private ICatalogo _catalogo = ProdutoRepo.Instance;
        private FornecedorRepo _fornecedores = FornecedorRepo.Instance;

        public FrmProduto(Produto produto)
        {
            InitializeComponent();

            _produto = produto;
        }

        public FrmProduto() : this(null)
        {
        }

        private void FrmProduto_Load(object sender, EventArgs e)
        {
            carregarCbGrupo();
            carregarCbFornecedor();

            if (_produto != null)
            {
                txtCodigo.Text = _produto.Codigo.ToString();
                txtNome.Text = _produto.Nome;
                txtDescricao.Text = _produto.Descricao;
                txtPrecoVenda.Text = _produto.PrecoVenda.ToString();
                txtPrecoCusto.Text = _produto.PrecoCusto.ToString();
                txtUnMedida.Text = _produto.UnidadeMedida;
                if (_produto.Fornecedor != null)
                {
                    cbFornecedor.SelectedItem = _produto.Fornecedor;
                }
                if (_produto.Grupo != null)
                {
                    cbGrupo.SelectedItem = _produto.Grupo;
                }

                if (_produto.Codigo == Produto.DIVERSOS)
                {
                    txtPrecoVenda.Enabled = false;
                    txtPrecoCusto.Enabled = false;
                    txtCodigo.Enabled = false;
                }
            }

        }

        private void carregarCbGrupo()
        {
            cbGrupo.DataSource = _grupos.Listar();
            cbGrupo.DisplayMember = "Nome";
            cbGrupo.ValueMember = "Id";
            cbGrupo.SelectedIndex = -1;
        }

        private void carregarCbFornecedor()
        {
            cbFornecedor.DataSource = _fornecedores.ListarTodos();
            cbFornecedor.DisplayMember = "NomeFantasia";
            cbFornecedor.ValueMember = "Id";
            cbFornecedor.SelectedIndex = -1;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            btnSalvar.Enabled = false;
            if (_produto == null)
            {
                _produto = new Produto();
            }
            

            try
            {
                _produto.Codigo = txtCodigo.Text != "" ? Convert.ToInt64(txtCodigo.Text) : 0;
                if (_produto.Codigo == 0) {
                    txtCodigo.Focus();
                    throw new MiseException("Código não informado!");
                }
                if (txtNome.Text == "")
                {
                    txtNome.Focus();
                    throw new MiseException("Nome não informado!");
                }
                _produto.Nome = txtNome.Text;

                if (txtDescricao.Text == "")
                {
                    txtDescricao.Focus();
                    throw new MiseException("Descrição não informada!");
                }
                _produto.Descricao = txtDescricao.Text;


                _produto.PrecoVenda = txtPrecoVenda.Text != "" ? Convert.ToDecimal(txtPrecoVenda.Text) : 0;
                if (_produto.PrecoVenda == 0 && !_produto.IsDiverso)
                {
                    txtPrecoVenda.Focus();
                    throw new MiseException("Preço de Venda não informado!");
                }

                if (txtUnMedida.Text == "")
                {
                    txtUnMedida.Focus();
                    throw new MiseException("Unidade de Medida não informada!");
                }

                _produto.UnidadeMedida = txtUnMedida.Text;
                _produto.PrecoCusto = !txtPrecoCusto.Text.Equals("") ? Convert.ToDecimal(txtPrecoCusto.Text) : 0;
                _produto.Fornecedor = (Fornecedor)cbFornecedor.SelectedItem;
                _produto.Grupo = (Grupo)cbGrupo.SelectedItem;

                if (_produto.Id != 0)
                {
                    _catalogo.Alterar(_produto);
                }
                else
                {
                    _catalogo.Incluir(_produto);
                }
                lblSalvo.ShowAndFade();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            btnSalvar.Enabled = true;
        }

        private void cbGrupo_Leave(object sender, EventArgs e)
        {
            if (cbGrupo.SelectedItem == null && !cbGrupo.Text.Equals(""))
            {
                cbGrupo.Text = "";
            }
        }

        private void cbFornecedor_Leave(object sender, EventArgs e)
        {
            if (cbFornecedor.SelectedItem == null && !cbFornecedor.Text.Equals(""))
            {
                cbFornecedor.Text = "";
            }
        }

        private void btnNovoGrupo_Click(object sender, EventArgs e)
        {
            FrmGrupo frmGrupo = new FrmGrupo();
            frmGrupo.ShowDialog();
            carregarCbGrupo();

            if (frmGrupo.Grupo != null && frmGrupo.Grupo.Id != 0)
            {
                cbGrupo.SelectedItem = frmGrupo.Grupo;
            }
            cbGrupo.Focus();
        }

        private void btnNovoFornecedor_Click(object sender, EventArgs e)
        {
            FrmFornecedor frmFornecedor = new FrmFornecedor();
            frmFornecedor.ShowDialog();
            carregarCbFornecedor();

            if (frmFornecedor.Fornecedor != null && frmFornecedor.Fornecedor.Id != 0)
            {
                cbFornecedor.SelectedItem = frmFornecedor.Fornecedor;
            }
            cbFornecedor.Focus();
        }

        private void txtDescricao_Enter(object sender, EventArgs e)
        {
            if (txtDescricao.Text == "" && txtNome.Text != "")
            {
                txtDescricao.Text = txtNome.Text;
            }
        }

    }
}
