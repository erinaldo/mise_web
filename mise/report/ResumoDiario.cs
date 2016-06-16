using mise.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mise.report
{
    public class ResumoDiario
    {
        private IVendaRepo _vendaRepo;
        private IFormaPagamentoRepo _formaPagamentoRepo;
        private ILancamentoRepo _lancamentoRepo;
        private DateTime _data;

        private StringBuilder _sb = new StringBuilder();
        private Dictionary<int, decimal> _dadosResumo;

        private static string LINE_SEPARATOR = new String('-', 48);
        private static string LINE_BREAK = "\r\n";

        private decimal _subtotal;
        private decimal _pagamentos;
        private decimal _total;
        private decimal _totalOutros;

        public ResumoDiario(DateTime data, IVendaRepo vendaRepo, IFormaPagamentoRepo formaPagamentoRepo, ILancamentoRepo lancamentoRepo)
        {
            _data = data;
            _vendaRepo = vendaRepo;
            _formaPagamentoRepo = formaPagamentoRepo;
            _lancamentoRepo = lancamentoRepo;
            _dadosResumo = vendaRepo.GerarResumo(data, data);

            _subtotal = (from d in _dadosResumo select d.Value).Sum(x => x);
            _pagamentos = _lancamentoRepo.ObterTotal(data);
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

        private ResumoDiario header()
        {
            _sb.Append("RESUMO DIARIO");
            lineBreak();
            _sb.Append(_data.ToShortDateString());
            lineBreak();
            return this;
        }

        private ResumoDiario lineSeparator()
        {
            _sb.Append(LINE_SEPARATOR);
            lineBreak();
            return this;
        }

        private ResumoDiario lineBreak()
        {
            _sb.Append(LINE_BREAK);
            return this;
        }

        private ResumoDiario total(String tipo, decimal total)
        {
            String totalFmt = total.ToString("0.00");
            _sb.Append(tipo).Append(totalFmt.PadLeft(48 - tipo.Length));
            lineBreak();
            return this;
        }

        public static void Main()
        {
            ResumoDiario r = new ResumoDiario(DateTime.Today, VendaRepo.Instance, FormaPagamentoRepo.Instance, LancamentoRepo.Instance);
            Console.WriteLine(r.Gerar());
            Console.ReadLine();
        }
    }
}
