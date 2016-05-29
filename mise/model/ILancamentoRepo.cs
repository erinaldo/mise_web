using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mise.model
{
    public interface ILancamentoRepo
    {
        decimal ObterTotal(DateTime data);
    }
}
