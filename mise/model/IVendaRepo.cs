using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mise.model
{
    public interface IVendaRepo
    {
        Venda Incluir(Venda v);
        Dictionary<int, decimal> GerarResumo(DateTime ini, DateTime fim);
        Venda Obter(long id);
    }
}
