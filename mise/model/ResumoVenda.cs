using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mise.model
{
    public class ResumoVenda
    {
        public ResumoVenda(Produto p, decimal qtd, decimal total)
        {
            Produto = p;
            Qtd = qtd;
            Total = total;
        }

        public Produto Produto { get; set; }
        public decimal Qtd { get; set; }
        public decimal Total { get; set; }
    }
}
