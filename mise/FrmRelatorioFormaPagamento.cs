using mise.external;
using mise.model;
using mise.report;
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
    public partial class FrmRelatorioFormaPagamento : Form
    {
        private VendaRepo _vendaRepo;
        private FormaPagamentoRepo _formaPagamentoRepo;

        private DateTime _dataIni;
        private DateTime _dataFim;

        public FrmRelatorioFormaPagamento()
        {
            InitializeComponent();
        }

        private void FrmRelatorioFormaPagamento_Load(object sender, EventArgs e)
        {
            _vendaRepo = VendaRepo.Instance;
            _formaPagamentoRepo = FormaPagamentoRepo.Instance;
        }

        private void btnVisualizar_Click(object sender, EventArgs e)
        {
            
            //if (!DateTime.TryParse(txtDataIni.Text, out _dataIni))
            //{
            //    throw new Exception("Data inválida!");
            //}

            //if (!DateTime.TryParse(txtDataFim.Text, out _dataFim))
            //{
            //    throw new Exception("Data inválida!");
            //}

            _dataIni = dtIni.Value;
            _dataFim = dtFim.Value;

            Dictionary<long, ResumoVenda> resumo = _vendaRepo.GerarResumoAnalitico(_dataIni, _dataFim);

            gridPagamentos.Rows.Clear();
            Dictionary<int, decimal> resumoFormaPagamento = _vendaRepo.GerarResumo(_dataIni, _dataFim);
            decimal totalP = 0;
            foreach (var item in resumoFormaPagamento.OrderBy(x => -x.Value))
            {
                gridPagamentos.Rows.Add(_formaPagamentoRepo.Obter(item.Key).Nome, item.Value.ToString("0.00"));
                totalP += item.Value;
            }

            int indexP = gridPagamentos.Rows.Add("TOTAL", totalP.ToString("0.00"));
            gridPagamentos.Rows[indexP].DefaultCellStyle.Font = new Font(gridPagamentos.DefaultCellStyle.Font, FontStyle.Bold);
        }


        private void gridPagamentos_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {
            int iTotal = gridPagamentos.Rows.Count - 1;
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
            else if (e.Column.Index == 1)
            {
                e.SortResult = decimal.Parse(e.CellValue1.ToString()).CompareTo(decimal.Parse(e.CellValue2.ToString()));
                e.Handled = true;
            }
        }

        private void btImprimir_Click(object sender, EventArgs e)
        {
            if (_dataIni != null && _dataFim != null)
            {
                Impressora.Instance.Imprimir(new Resumo(_dataIni, _dataFim, _vendaRepo, _formaPagamentoRepo, LancamentoRepo.Instance).Gerar());
                Impressora.Instance.CortarPapel();
            }
        }
    }
}
