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
    public partial class FrmCategoria : Form
    {
        private CategoriaRepo _repo;
        private Categoria _categoria;

        public FrmCategoria(Categoria c)
        {
            InitializeComponent();
            _categoria = c ?? new Categoria();
        }

        public FrmCategoria() : this(null)
        {
        }

        public Categoria Categoria
        {
            get { return _categoria; }
        }

        private void FrmCategoria_Load(object sender, EventArgs e)
        {
            _repo = CategoriaRepo.Instance;

            if (_categoria.Id != 0)
            {
                txtNome.Text = _categoria.Nome;
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                _categoria.Nome = txtNome.Text;
                if (_categoria.Id == 0) {
                    _categoria = _repo.Incluir(_categoria);
                } else {
                    _categoria = _repo.Alterar(_categoria);
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
