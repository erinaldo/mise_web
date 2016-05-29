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
    public partial class FrmFormaPagamento : Form
    {
        private FormaPagamento _formaPagamento;
        private FormaPagamentoRepo _repo = FormaPagamentoRepo.Instance;

        public FrmFormaPagamento(FormaPagamento f)
        {
            _formaPagamento = f != null ? f : new FormaPagamento();
            InitializeComponent();
        }

        public FrmFormaPagamento(): this(null)
        {
        }

        private void FrmFormaPagamento_Load(object sender, EventArgs e)
        {
            if (_formaPagamento != null)
            {
                txtDescricao.Text = _formaPagamento.Nome;
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            _formaPagamento.Nome = txtDescricao.Text;
            try
            {
                if (_formaPagamento.Id != 0)
                {
                    _repo.Alterar(_formaPagamento);
                }
                else
                {
                    _repo.Incluir(_formaPagamento);
                }
                fadingLabel.ShowAndFade();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

    }
}
