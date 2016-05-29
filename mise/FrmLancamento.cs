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

namespace mise
{
    public partial class FrmLancamento : Form
    {
        private CategoriaRepo _categoriaRepo;
        private LancamentoRepo _lancamentoRepo;
        private Lancamento _lancamento;
        public FrmLancamento(Lancamento l)
        {
            InitializeComponent();
            _lancamento = l ?? new Lancamento();
        }

        public FrmLancamento():this(null)
        {
        }

        private void FrmLancamento_Load(object sender, EventArgs e)
        {
            _categoriaRepo = CategoriaRepo.Instance;
            _lancamentoRepo = LancamentoRepo.Instance;

            carregar();
            txtData.Text = DateTime.Today.ToShortDateString();

            if (_lancamento.Id != 0)
            {
                txtData.Text = _lancamento.Data.ToShortDateString();
                cbCategoria.SelectedItem = _lancamento.Categoria;
                txtDescricao.Text = _lancamento.Descricao;
                txtValor.Text = _lancamento.Valor.ToString("0.00");
            }
        }

        private void carregar()
        {
            cbCategoria.DataSource = _categoriaRepo.Listar();
            cbCategoria.DisplayMember = "Nome";
            cbCategoria.ValueMember = "Id";
            cbCategoria.SelectedIndex = -1;
        }

        private void btnNovaCategoria_Click(object sender, EventArgs e)
        {
            FrmCategoria frmCategoria = new FrmCategoria();
            frmCategoria.ShowDialog();
            carregar();
            if (frmCategoria.Categoria != null && frmCategoria.Categoria.Id != 0)
            {
                cbCategoria.SelectedItem = frmCategoria.Categoria;
            }
            cbCategoria.Focus();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                _lancamento.Categoria = cbCategoria.SelectedItem as Categoria;
                DateTime d;
                if (!DateTime.TryParse(txtData.Text, out d))
                {
                    throw new Exception("Data inválida!");
                }
                _lancamento.Data = Convert.ToDateTime(d);
                _lancamento.Descricao = txtDescricao.Text;

                decimal valor;
                Decimal.TryParse(txtValor.Text, out valor);
                _lancamento.Valor = valor;

                if (_lancamento.Id == 0)
                {
                    _lancamento = _lancamentoRepo.Incluir(_lancamento);
                }
                else
                {
                    _lancamento = _lancamentoRepo.Alterar(_lancamento);
                }

                fadingLabel.ShowAndFade();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
