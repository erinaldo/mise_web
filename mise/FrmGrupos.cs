using mise.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mise
{
    public partial class FrmGrupos : Form
    {

        private GrupoRepo _repo = GrupoRepo.Instance;
        private List<Grupo> _grupos;
        private int _idSelecionado;

        public FrmGrupos()
        {
            _repo.Changed += new EventHandler(carregar);

            InitializeComponent();
        }

        private void FrmGrupos_Load(object sender, EventArgs e)
        {
            carregar(this, EventArgs.Empty);
        }

        private void carregar(object sender, EventArgs e)
        {
            _grupos = _repo.Listar();
            gridGrupos.Rows.Clear();
            foreach (var g in _grupos)
            {
                gridGrupos.Rows.Add(g.Id, g.Nome);
            }

            if (gridGrupos.SortedColumn != null)
            {
                gridGrupos.Sort(gridGrupos.SortedColumn, gridGrupos.SortOrder == SortOrder.Ascending ? ListSortDirection.Ascending : ListSortDirection.Descending);
            }
            gridGrupos.ClearSelection();
        }

        private void toolBtnNovo_Click(object sender, EventArgs e)
        {
            new FrmGrupo().ShowDialog();
        }

        private void gridGrupos_SelectionChanged(object sender, EventArgs e)
        {
            if (gridGrupos.SelectedRows.Count > 0)
            {
                _idSelecionado = Convert.ToInt32(gridGrupos.SelectedRows[0].Cells[0].Value);
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
            if (_idSelecionado == 0)
            {
                MessageBox.Show("Nenhum grupo selecionado!");
            }
            else
            {
                new FrmGrupo(_repo.Obter(_idSelecionado)).ShowDialog();
            }
        }

        private void toolBtnExcluir_Click(object sender, EventArgs e)
        {
            if (_idSelecionado == 0)
            {
                MessageBox.Show("Nenhum grupo selecionado!");
            }
            else
            {
                try
                {
                    Grupo p = _repo.Obter(_idSelecionado);
                    DialogResult r = MessageBox.Show("Deseja REALMENTE excluir o grupo " + p.Nome + "?", "Excluir Grupo",
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
            }
        }
    }
}
