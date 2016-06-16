using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using mise;
using mise.model;
using System.Collections.Generic;
using miseTest.mock;
using mise.report;
using System.Linq;

namespace miseTest
{
    [TestClass]
    public class ResumoDiarioTest
    {

        private IVendaRepo repo;
        private ResumoDiario resumo;

        [TestInitialize]
        public void Init()
        {
            repo = new VendaRepoMock();
            resumo = new ResumoDiario(DateTime.Now, repo, FormaPagamentoRepo.Instance, LancamentoRepo.Instance);
        }

        [TestMethod]
        public void SubTotal()
        {
            Dictionary<int, decimal> dadosResumo = repo.GerarResumo(DateTime.Now, DateTime.Now);
            decimal subTotal = (from d in dadosResumo
                                select d.Value).Sum(x => x);
            Assert.AreEqual(subTotal, resumo.SubTotal);
        }

        [TestMethod]
        public void Relatorio()
        {
            Dictionary<int, decimal> dadosResumo = repo.GerarResumo(DateTime.Now, DateTime.Now);
            decimal subTotal = (from d in dadosResumo
                                select d.Value).Sum(x => x);
            Assert.AreEqual(subTotal, resumo.SubTotal);
        }
    }
}
