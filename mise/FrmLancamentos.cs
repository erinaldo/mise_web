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
    public partial class FrmLancamentos : Form
    {
        private LancamentoRepo _repo;
        private long _idSelecionado;

        public FrmLancamentos()
        {
            InitializeComponent();
        }

        private void FrmLancamento_Load(object sender, EventArgs e)
        {
            _repo = LancamentoRepo.Instance;

            txtData.Text = DateTime.Today.ToShortDateString();
            carregarGrid();
        }

        private void carregarGrid()
        {
            gridLancamentos.Rows.Clear();
            DateTime d;
            if (!DateTime.TryParse(txtData.Text, out d))
            {
                MessageBox.Show("Data inválida!");
                d = DateTime.Today;
                txtData.Text = d.ToShortDateString();
            }
            List<Lancamento> lancamentos = _repo.Listar(d);
            decimal total = 0;
            foreach (var item in lancamentos)
            {
                gridLancamentos.Rows.Add(item.Id, item.Categoria.Nome, item.Descricao, item.Valor.ToString("0.00"));
                total += item.Valor;
            }
            lblTotal.Text = total.ToString("0.00");
            gridLancamentos.ClearSelection();
        }

        private void toolBtnNovo_Click(object sender, EventArgs e)
        {
            new FrmLancamento().ShowDialog();
            carregarGrid();
        }

        private void gridLancamentos_SelectionChanged(object sender, EventArgs e)
        {
            if (gridLancamentos.SelectedRows.Count > 0)
            {
                _idSelecionado = Convert.ToInt64(gridLancamentos.SelectedRows[0].Cells[0].Value);
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
            new FrmLancamento(_repo.Obter(_idSelecionado)).ShowDialog();
            carregarGrid();
        }

        private void toolBtnExcluir_Click(object sender, EventArgs e)
        {
            if (_idSelecionado == 0)
            {
                MessageBox.Show("Nenhum lançamento selecionado!");
            }
            else
            {
                try
                {
                    Lancamento l = _repo.Obter(_idSelecionado);

                    DialogResult r = MessageBox.Show("Deseja REALMENTE excluir o lançamento " + l.Descricao + "?", "Excluir Lançamento",
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

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                carregarGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
