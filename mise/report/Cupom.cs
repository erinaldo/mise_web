using mise.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mise.report
{
    public class Cupom
    {
        private static string NOME = Properties.Settings.Default.nome;
        private static string ENDERECO = Properties.Settings.Default.endereco;
        private static string FONE = Properties.Settings.Default.fone;

        private static string LINE_SEPARATOR = new String('-', 48);
        private static string DOUBLE_LINE_SEPARATOR = new String('=', 48);
        private static string LINE_BREAK = "\r\n";

        private StringBuilder _sb = new StringBuilder();
        private Venda _venda;

        public Cupom(Venda v)
        {
            _venda = v;
        }

        public string Gerar()
        {
            doubleLineSeparator();
            header();

            itemHeader();

            foreach (var i in _venda.Itens)
            {
                if (!i.Cancelado)
                    item(i);
            }

            total();

            foreach (var p in _venda.Pagamentos)
            {
                pagamento(p);
            }

            troco();

            footer();

            return _sb.ToString();
        }

        private Cupom header()
        {
            _sb.Append(NOME.PadLeft(24 + (NOME.Length / 2)));
            lineBreak();
            _sb.Append(ENDERECO);
            lineBreak();
            _sb.Append("FONE: " + FONE);
            lineBreak();
            lineSeparator();
            _sb.Append("CUPOM - NAO FISCAL".PadLeft(24 + 9));
            lineBreak();
            _sb.Append(_venda.Data.ToString("dd/MM/yyyy HH:mm:ss"));
            _sb.Append(("# " +_venda.Id).PadLeft(48 - 19));
            lineBreak();
            lineSeparator();

            return this;
        }

        private void itemHeader()
        {
            _sb.Append("codigo         produto       qtd   vl un vl item");
            lineBreak();
            lineSeparator();
        }

        private void item(Item i)
        {
            _sb.Append(i.Produto.Codigo.ToString().PadRight(14).Substring(0, 14));
            _sb.Append(" ");
            _sb.Append(i.Produto.Nome.PadRight(10).Substring(0, 10));
            _sb.Append(" ");
            _sb.Append(i.Qtd.ToString("0.###").PadLeft(6));
            _sb.Append(" ");
            _sb.Append(i.PrecoUni.ToString("0.00").PadLeft(7));
            _sb.Append(" ");
            _sb.Append(i.Total.ToString("0.00").PadLeft(7));
            lineBreak();
        }

        private void total()
        {
            lineSeparator();
            _sb.Append("TOTAL");
            _sb.Append(_venda.Total.ToString("0.00").PadLeft(43));
            lineBreak();
        }

        private void pagamento(Venda.Pagamento p)
        {
            _sb.Append(p.FormaPagamento.Nome);
            _sb.Append(p.Valor.ToString("0.00").PadLeft(48 - p.FormaPagamento.Nome.Length));
            lineBreak();
        }

        private void troco()
        {
            _sb.Append("TROCO");
            _sb.Append(_venda.Troco.ToString("0.00").PadLeft(43));
        }

        private Cupom footer()
        {
            lineBreak();
            lineSeparator();
            _sb.Append("Agradecemos sua preferencia ^_^".PadLeft(24 + 16));
            lineBreak();
            doubleLineSeparator();
            return this;
        }

        private Cupom doubleLineSeparator()
        {
            _sb.Append(DOUBLE_LINE_SEPARATOR);
            lineBreak();
            return this;
        }

        private Cupom lineSeparator()
        {
            _sb.Append(LINE_SEPARATOR);
            lineBreak();
            return this;
        }

        private Cupom lineBreak()
        {
            _sb.Append(LINE_BREAK);
            return this;
        }

        public static void Main()
        {
            Venda v = VendaRepo.Instance.Obter(1);
            Cupom c = new Cupom(v);
            Console.WriteLine(c.Gerar());

            Console.ReadLine();
        }
    }
}
