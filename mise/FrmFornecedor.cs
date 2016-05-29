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
    public partial class FrmFornecedor : Form
    {

        private Fornecedor _fornecedor;
        private FornecedorRepo _repo = FornecedorRepo.Instance;

        public FrmFornecedor(Fornecedor f)
        {
            InitializeComponent();

            _fornecedor = f;
        }

        public FrmFornecedor() : this(null) { }

        private void FrmFornecedor_Load(object sender, EventArgs e)
        {
            if (_fornecedor != null)
            {
                txtNomeFantasia.Text = _fornecedor.NomeFantasia;
                txtRazaoSocial.Text = _fornecedor.RazaoSocial;
                txtContato.Text = _fornecedor.Contato;
                txtTelefone.Text = _fornecedor.Telefone;
                txtObs.Text = _fornecedor.Outros;
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (_fornecedor == null)
                _fornecedor = new Fornecedor();

            _fornecedor.NomeFantasia = txtNomeFantasia.Text;
            _fornecedor.RazaoSocial = txtRazaoSocial.Text;
            _fornecedor.Contato = txtContato.Text;
            _fornecedor.Telefone = txtTelefone.Text;
            _fornecedor.Outros = txtObs.Text;

            try
            {
                if (_fornecedor.Id == 0)
                {
                    _fornecedor = _repo.Incluir(_fornecedor);
                }
                else
                {
                    _repo.Alterar(_fornecedor);
                }
                fadingLabel.ShowAndFade();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public Fornecedor Fornecedor
        {
            get { return _fornecedor; }
        }
    }
}
