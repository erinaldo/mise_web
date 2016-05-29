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
    public partial class FrmCategorias : Form
    {
        private CategoriaRepo _repo;
        private int _idSelecionado;

        public FrmCategorias()
        {
            InitializeComponent();
        }

        private void FrmCategorias_Load(object sender, EventArgs e)
        {
            _repo = CategoriaRepo.Instance;

            carregarGrid();
        }

        private void carregarGrid()
        {
            gridCategorias.Rows.Clear();
            
            List<Categoria> categorias = _repo.Listar();
            foreach (var item in categorias)
            {
                gridCategorias.Rows.Add(item.Id, item.Nome);
            }

            gridCategorias.ClearSelection();
        }

        private void toolBtnNovo_Click(object sender, EventArgs e)
        {
            new FrmCategoria().ShowDialog();
            carregarGrid();
        }

        private void gridCategorias_SelectionChanged(object sender, EventArgs e)
        {
            if (gridCategorias.SelectedRows.Count > 0)
            {
                _idSelecionado = Convert.ToInt32(gridCategorias.SelectedRows[0].Cells[0].Value);
                toolBtnAlterar.Enabled = true;
                toolBtnExcluir.Enabled = true;
            }
            else
            {
                _idSelecionado = 0;
                toolBtnAlterar.Enabled = false;
                toolBtnExcluir.Enabled = false;
            }
        }

        private void toolBtnAlterar_Click(object sender, EventArgs e)
        {
            new FrmCategoria(_repo.Obter(_idSelecionado)).ShowDialog();

            carregarGrid();
        }

        private void toolBtnExcluir_Click(object sender, EventArgs e)
        {
            if (_idSelecionado == 0)
            {
                MessageBox.Show("Nenhuma categoria selecionada!");
            }
            else
            {
                try
                {
                    Categoria c = _repo.Obter(_idSelecionado);

                    DialogResult r = MessageBox.Show("Deseja REALMENTE excluir a categoria " + c.Nome + "?", "Excluir Categoria",
                        MessageBoxButtons.YesNo, MessageBoxIcon.None, MessageBoxDefaultButton.Button2);

                    if (r == DialogResult.Yes)
                    {
                        _repo.Excluir(_idSelecionado);
                    }
                }
                catch (Exception ee)
                {
                    MessageBox.Show(ee.Message);
                }

                carregarGrid();
            }
        }
    }
}
