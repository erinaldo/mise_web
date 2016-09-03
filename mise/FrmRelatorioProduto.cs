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
    public partial class FrmRelatorioProduto : Form
    {
        private VendaRepo _vendaRepo;
        private FormaPagamentoRepo _formaPagamentoRepo;

        public FrmRelatorioProduto()
        {
            InitializeComponent();
        }

        private void FrmRelatorios_Load(object sender, EventArgs e)
        {
            _vendaRepo = VendaRepo.Instance;
            _formaPagamentoRepo = FormaPagamentoRepo.Instance;

        }

        private void btnVisualizar_Click(object sender, EventArgs e)
        {
            
            Dictionary<long, ResumoVenda> resumo = _vendaRepo.GerarResumoAnalitico(dtIni.Value, dtFim.Value);
            
            gridResumo.Rows.Clear();
            decimal total = 0;
            foreach (var item in resumo.OrderBy(x=> -x.Value.Total ).Select(x => x.Value).ToList())
            {
                gridResumo.Rows.Add(item.Produto.Nome, item.Produto.Codigo, item.Qtd.ToString("0.000"), item.Total.ToString("0.00"));
                total += item.Total;
            }

            int index = gridResumo.Rows.Add("TOTAL", "-", "-", total.ToString("0.00"));
            gridResumo.Rows[index].DefaultCellStyle.Font = new Font(gridResumo.DefaultCellStyle.Font, FontStyle.Bold);
        }

        private void gridResumo_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {
            int iTotal = gridResumo.Rows.Count - 1;
            if (e.RowIndex1 == iTotal)
            {
                e.SortResult = int.MaxValue;
                e.Handled = true;
            }
            else if (e.RowIndex2 == iTotal)
            {
                e.SortResult = int.MinValue;
                e.Handled = true;
            }
            else if (e.Column.Index == 2 || e.Column.Index == 3)
            {
                e.SortResult = decimal.Parse(e.CellValue1.ToString()).CompareTo(decimal.Parse(e.CellValue2.ToString()));
                e.Handled = true;
            }
        }
    }
}
