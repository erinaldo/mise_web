using mise.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mise.report
{
    public class Resumo
    {
        private IVendaRepo _vendaRepo;
        private IFormaPagamentoRepo _formaPagamentoRepo;
        private ILancamentoRepo _lancamentoRepo;
        private DateTime _dataIni;
        private DateTime _dataFim;

        private StringBuilder _sb = new StringBuilder();
        private Dictionary<int, decimal> _dadosResumo;

        private static string LINE_SEPARATOR = new String('-', 48);
        private static string LINE_BREAK = "\r\n";

        private decimal _subtotal;
        private decimal _pagamentos;
        private decimal _total;
        private decimal _totalOutros;

        public Resumo(DateTime dataIni, DateTime dataFim, IVendaRepo vendaRepo, IFormaPagamentoRepo formaPagamentoRepo, ILancamentoRepo lancamentoRepo)
        {
            _dataIni = dataIni;
            _dataFim = dataFim;
            _vendaRepo = vendaRepo;
            _formaPagamentoRepo = formaPagamentoRepo;
            _lancamentoRepo = lancamentoRepo;
            _dadosResumo = vendaRepo.GerarResumo(dataIni, dataFim);

            _subtotal = (from d in _dadosResumo select d.Value).Sum(x => x);
            _pagamentos = _lancamentoRepo.ObterTotal(dataIni);
            _total = _subtotal - _pagamentos;
            _totalOutros = (from d in _dadosResumo
                            where !_formaPagamentoRepo.Obter(d.Key).IsDinheiro
                            select d.Value).Sum(x => x);
        }

        public decimal SubTotal
        {
            get { return _subtotal; }
        }

        public decimal TotalOutros
        {
            get { return _totalOutros; }
        }

        public string Gerar()
        {
            header();
            lineSeparator();

            decimal totalDinheiro = 0;
            foreach (var item in _dadosResumo.OrderBy(x=> x.Key))
            {
                FormaPagamento f = _formaPagamentoRepo.Obter(item.Key);
                if (f.IsDinheiro)
                    totalDinheiro = item.Value;

                total(f.Nome, item.Value);
            }

            lineSeparator();
            total("SUBTOTAL", SubTotal);
            total("PAGAMENTOS", _pagamentos);
            
            lineSeparator();
            total("TOTAL", _total);
            total("DINHEIRO", totalDinheiro - _pagamentos);
            total("OUTRAS FORMAS DE PAGAMENTO", TotalOutros);

            return _sb.ToString();
        }

        private Resumo header()
        {
            _sb.Append("RESUMO");
            lineBreak();
            if (_dataIni.Equals(_dataFim))
            {
                _sb.Append(_dataIni.ToShortDateString());
            }
            else
            {
                _sb.Append("DE ")
                    .Append(_dataIni.ToShortDateString())
                    .Append(" A ")
                    .Append(_dataFim.ToShortDateString());
            }
            lineBreak();
            return this;
        }

        private Resumo lineSeparator()
        {
            _sb.Append(LINE_SEPARATOR);
            lineBreak();
            return this;
        }

        private Resumo lineBreak()
        {
            _sb.Append(LINE_BREAK);
            return this;
        }

        private Resumo total(String tipo, decimal total)
        {
            String totalFmt = total.ToString("0.00");
            _sb.Append(tipo).Append(totalFmt.PadLeft(48 - tipo.Length));
            lineBreak();
            return this;
        }
    }
}
