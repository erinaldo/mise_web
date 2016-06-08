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
    public partial class FrmFornecedores : Form
    {
        private FornecedorRepo _repo = FornecedorRepo.Instance;
        private List<Fornecedor> _fornecedores = new List<Fornecedor>();
        private long _idSelecionado;

        public FrmFornecedores()
        {
            InitializeComponent();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            _fornecedores = _repo.Listar(txtNomeFantasia.Text);
            gridFornecedores.Rows.Clear();
            if (_fornecedores.Count > 0)
            {
                foreach (var f in _fornecedores)
                {
                    gridFornecedores.Rows.Add(f.Id, f.NomeFantasia, f.Contato, f.Telefone);
                }

                if (gridFornecedores.SortedColumn != null)
                {
                    gridFornecedores.Sort(gridFornecedores.SortedColumn, gridFornecedores.SortOrder == SortOrder.Ascending ? ListSortDirection.Ascending : ListSortDirection.Descending);
                }

                gridFornecedores.ClearSelection();
            }

            txtNomeFantasia.SelectAll();
        }

        private void FrmFornecedores_Load(object sender, EventArgs e)
        {
            _repo.Changed += new EventHandler(carregar);
        }

        private void carregar(object sender, EventArgs e)
        {
            if (_fornecedores != null && _fornecedores.Count > 0)
            {
                btnPesquisar_Click(sender, e);
            }
        }

        private void toolBtnNovo_Click(object sender, EventArgs e)
        {
            new FrmFornecedor().ShowDialog();
        }

        private void toolBtnAlterar_Click(object sender, EventArgs e)
        {
            if (_idSelecionado == 0)
            {
                MessageBox.Show("Nenhum fornecedor selecionado!");
            }
            else
            {
                new FrmFornecedor(_repo.Obter(_idSelecionado)).ShowDialog();
            }
        }

        private void gridFornecedores_SelectionChanged(object sender, EventArgs e)
        {
            if (gridFornecedores.SelectedRows.Count > 0)
            {
                _idSelecionado = Convert.ToInt64(gridFornecedores.SelectedRows[0].Cells[0].Value);
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

        private void toolBtnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                Fornecedor f = _repo.Obter(_idSelecionado);

                DialogResult r = MessageBox.Show("Deseja REALMENTE excluir o fornecedor " + f.NomeFantasia + "?", "Excluir Fornecedor",
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
