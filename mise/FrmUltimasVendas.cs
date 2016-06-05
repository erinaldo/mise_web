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
    public partial class FrmUltimasVendas : Form
    {
        private VendaRepo _vendaRepo = VendaRepo.Instance;
        private List<Venda> _vendas;
        private long _idSelecionado;

        public FrmUltimasVendas()
        {
            InitializeComponent();
        }

        private void FrmUltimasVendas_Load(object sender, EventArgs e)
        {
            txtData.Text = DateTime.Today.ToShortDateString();

            carregarVendas();
        }

        private void carregarVendas()
        {
            DateTime d;
            if (!DateTime.TryParse(txtData.Text, out d))
            {
                MessageBox.Show("Data inválida!");
                d = DateTime.Today;
                txtData.Text = d.ToShortDateString();
            }
            _vendas = _vendaRepo.Listar(d, d);
            gridVendas.Rows.Clear();

            foreach (var v in _vendas)
            {
                gridVendas.Rows.Add(v.Id, v.Data.ToShortDateString() + " " + v.Data.ToShortTimeString(), v.Total.ToString("0.00"));
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            carregarVendas();
        }

        private void toolBtnVisualizar_Click(object sender, EventArgs e)
        {
            if (_idSelecionado != 0)
            {
                new FrmDetalheVenda(_vendas.Find( z => z.Id == _idSelecionado)).ShowDialog();
            }
        }

        private void gridCategorias_SelectionChanged(object sender, EventArgs e)
        {
            if (gridVendas.SelectedRows.Count > 0)
            {
                _idSelecionado = Convert.ToInt64(gridVendas.SelectedRows[0].Cells[0].Value);
                toolBtnVisualizar.Enabled = true;
            }
            else
            {
                _idSelecionado = 0;
                toolBtnVisualizar.Enabled = false;
            }
        }
    }
}
