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
    public partial class FrmFormasPagamento : Form
    {
        private FormaPagamentoRepo _repo = FormaPagamentoRepo.Instance;
        private List<FormaPagamento> _formasPagamento;
        private int _idSelecionado;
        private int _ultimoIndice;

        public FrmFormasPagamento()
        {
            InitializeComponent();
        }

        private void FrmFormasPagamento_Load(object sender, EventArgs e)
        {
            carregar(this, EventArgs.Empty);
            _repo.Changed += new EventHandler(carregar);
        }

        private void carregar(object sender, EventArgs e)
        {
            _formasPagamento = _repo.Listar();

            gridFormasPagamento.Rows.Clear();

            foreach (var f in _formasPagamento)
            {
                gridFormasPagamento.Rows.Add(f.Id, f.Indice, f.Nome);
            }

            if (gridFormasPagamento.SortedColumn != null)
            {
                gridFormasPagamento.Sort(gridFormasPagamento.SortedColumn, gridFormasPagamento.SortOrder == SortOrder.Ascending ? ListSortDirection.Ascending : ListSortDirection.Descending);
            }
            gridFormasPagamento.ClearSelection();
            if (_ultimoIndice != 0) gridFormasPagamento.Rows[_ultimoIndice].Selected = true;
        }

        private void toolBtnNovo_Click(object sender, EventArgs e)
        {
            new FrmFormaPagamento().ShowDialog();
        }

        private void gridFormasPagamento_SelectionChanged(object sender, EventArgs e)
        {
            if (gridFormasPagamento.SelectedRows.Count > 0)
            {
                _idSelecionado = Convert.ToInt32(gridFormasPagamento.SelectedRows[0].Cells[0].Value);
                toolBtnAlterar.Enabled = true;
                toolBtnExcluir.Enabled = true;
                toolBtnUp.Enabled = true;
                toolBtnDown.Enabled = true;
            }
            else
            {
                _idSelecionado = 0;
                toolBtnAlterar.Enabled = false;
                toolBtnExcluir.Enabled = false;
                toolBtnUp.Enabled = false;
                toolBtnDown.Enabled = false;
            }
        }

        private void toolBtnAlterar_Click(object sender, EventArgs e)
        {
            if (_idSelecionado == 0)
            {
                MessageBox.Show("Nenhuma forma de pagamento selecionada!");
            }
            else
            {
                _ultimoIndice = 0;
                new FrmFormaPagamento(_repo.Obter(_idSelecionado)).ShowDialog();
            }
        }

        private void toolBtnExcluir_Click(object sender, EventArgs e)
        {
            if (_idSelecionado == 0)
            {
                MessageBox.Show("Nenhuma forma de pagamento selecionada!");
            }
            else
            {
                try
                {
                    FormaPagamento p = _repo.Obter(_idSelecionado);
                    
                    DialogResult r = MessageBox.Show("Deseja REALMENTE excluir a forma de pagamento " + p.Nome + "?", "Excluir Forma de Pagamento",
                        MessageBoxButtons.YesNo, MessageBoxIcon.None, MessageBoxDefaultButton.Button2);

                    if (r == DialogResult.Yes)
                    {
                        _ultimoIndice = 0;
                        _repo.Excluir(_idSelecionado);
                    }
                }
                catch (Exception ee)
                {
                    MessageBox.Show(ee.Message);
                }
            }
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            ordenar(true);
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            ordenar(false);
        }

        private void ordenar(bool up)
        {
            if (_idSelecionado != 0)
            {
                int index = gridFormasPagamento.SelectedRows[0].Index;

                bool podeOrdernar = 
                    index > 0 &&
                    (up || (!up && index < (_formasPagamento.Count - 1)));

                if (podeOrdernar)
                {
                    try
                    {
                        List<int> ids = (from ff in _formasPagamento
                                         select ff.Id).ToList();

                        int id = ids[index];
                        ids.RemoveAt(index);

                        _ultimoIndice = up ? index - 1 : index + 1;
                        ids.Insert(_ultimoIndice, id);

                        _repo.Reordenar(ids);

                    }
                    catch (Exception ee)
                    {
                        MessageBox.Show(ee.Message);
                    }
                }

            }
        }
    }
}
