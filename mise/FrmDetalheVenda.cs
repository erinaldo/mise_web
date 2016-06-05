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
using mise.report;
using mise.external;
using mise.exception;
using mise.log;

namespace mise
{
    public partial class FrmDetalheVenda : Form
    {
        private Venda _venda;
        private Logger _logger = Logger.Instance;
        
        public FrmDetalheVenda(Venda venda)
        {
            InitializeComponent();
            _venda = venda;
        }

        private void FrmDetalheVenda_Load(object sender, EventArgs e)
        {
            this.Text = "Venda # " + _venda.Id;
            txtTotal.Text = _venda.Total.ToString("C2");
            txtDataHora.Text = _venda.Data.ToShortDateString() + " " + _venda.Data.ToShortTimeString();

            foreach (var item in _venda.Itens)
            {
                gridItem.Rows.Add(item.Sequencial, item.Codigo, item.NomeProduto,  item.PrecoUni.ToString("0.00"), 
                    item.Qtd.ToString("0.000"), item.Produto.UnidadeMedida, item.Total.ToString("0.00"));
            }
            gridItem.ClearSelection();

            foreach (var pagamento in _venda.Pagamentos)
            {
                gridPagamento.Rows.Add(pagamento.FormaPagamento.Nome, pagamento.Valor);
            }
            gridPagamento.ClearSelection();
        }

        private void btFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                Cupom cupom = new Cupom(_venda);
                Impressora.Instance.Imprimir(cupom.Gerar());
                Impressora.Instance.CortarPapel();
            }
            catch (MiseException me)
            {
                MessageBox.Show(me.Message);
            }
            catch (Exception ex)
            {
                _logger.Log(ex);
                MessageBox.Show(ex.Message);
            }
        }


    }
}
