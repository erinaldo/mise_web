using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mise.model;

namespace miseTest.mock
{
    public class VendaRepoMock : IVendaRepo
    {
        public VendaRepoMock() { }

        public Venda Incluir(Venda v) { return v; }

        public Dictionary<int, decimal> GerarResumo(DateTime ini, DateTime fim)
        {
            return new Dictionary<int, decimal> { 
                { Mock.DINHEIRO.Id, 599.55m },
                { Mock.VISA_DEBITO.Id, 123.78m },
                { Mock.VISA_CREDITO.Id, 145.99m }
            };;
        }

        public Venda Obter(long id)
        {
            return null;
        }
    }
}
