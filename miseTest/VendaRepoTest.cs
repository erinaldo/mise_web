using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using mise.model;
using mise.exception;
using System.Collections.Generic;

namespace miseTest
{
    [TestClass]
    public class VendaRepoTest
    {
        private VendaRepo repo;
        private ProdutoRepo produtoRepo;

        private Produto BANANA;
        private Produto ALFACE;
        private Produto MACA;
        private Produto CASTANHA;
        private Produto OVO;
        private Produto TWIX;
        private Produto PAO;

        private FormaPagamento DINHEIRO;
        private FormaPagamento MASTER_CREDITO;
        private FormaPagamento ELO_DEBITO;
        private FormaPagamento CADERNO;


        [TestInitialize]
        public void Init()
        {
            produtoRepo = ProdutoRepo.Instance;
            produtoRepo.Carregar();
            if (BANANA == null)
                BANANA = produtoRepo.Obter(25);
            if (ALFACE == null)
                ALFACE = produtoRepo.Obter(14);
            if (MACA == null)
                MACA = produtoRepo.Obter(70);
            if (CASTANHA == null)
                CASTANHA = produtoRepo.Obter(193);
            if (OVO == null)
                OVO = produtoRepo.Obter(93);
            if (TWIX == null)
                TWIX = produtoRepo.Obter(7896423424539);
            if (PAO == null)
                PAO = produtoRepo.Obter(142);
            // formas de pagamento
            if (DINHEIRO == null)
                DINHEIRO = FormaPagamentoRepo.Instance.Obter(1);
            if (MASTER_CREDITO == null)
                MASTER_CREDITO = FormaPagamentoRepo.Instance.Obter(2);
            if (ELO_DEBITO == null)
                ELO_DEBITO = FormaPagamentoRepo.Instance.Obter(7);
            if (CADERNO == null)
                CADERNO = FormaPagamentoRepo.Instance.Obter(11);

            repo = VendaRepo.Instance;
        }

        [TestMethod]
        public void Incluir_Erro_SemItens()
        {
            repo = VendaRepo.Instance;
            Venda venda = Venda.Iniciar(produtoRepo);
            try
            {
                repo.Incluir(venda);
                Assert.Fail("Não pode incluir venda sem itens!");
            }
            catch (MiseException)
            {
                
            }

        }

        [TestMethod]
        public void Incluir_Erro_PossuiSaldoAPagar()
        {
            repo = VendaRepo.Instance;
            Venda venda = Venda.Iniciar(produtoRepo);
            venda.AdicionarItem(BANANA.Codigo, 0.9m);
            venda.AdicionarItem(MACA.Codigo, 0.588m);
            venda.AdicionarItem(OVO.Codigo);
            venda.Pagar(2m, DINHEIRO);
            try
            {
                repo.Incluir(venda);
                Assert.Fail("Não pode incluir venda, pois possui saldo a pagar!");
            }
            catch (MiseException)
            {
            }

        }

        [TestMethod]
        public void Incluir()
        {
            repo = VendaRepo.Instance;
            Venda venda = Venda.Iniciar(produtoRepo);
            venda.AdicionarItem(BANANA.Codigo, 0.9m);
            venda.AdicionarItem(MACA.Codigo, 0.588m);
            venda.AdicionarItem(OVO.Codigo);
            venda.AdicionarItem(CASTANHA.Codigo, 0.356m);
            venda.AdicionarItem(ALFACE.Codigo);
            venda.AdicionarItem(TWIX.Codigo);
            venda.AdicionarItem(TWIX.Codigo);
            venda.CancelarItem(7);

            venda.Pagar(2, MASTER_CREDITO);
            venda.Pagar(2, ELO_DEBITO);
            venda.Pagar(50, DINHEIRO);

            Venda retorno = repo.Incluir(venda);

            Assert.IsNotNull(retorno.Id);
            Venda consulta = repo.Obter(retorno.Id);

            Assert.IsNotNull(consulta);
        }

        [TestMethod]
        public void TemItemVinculadoAProduto_true()
        {
            Assert.IsTrue(repo.TemItemVinculadoAProduto(TWIX.Id));
        }

        [TestMethod]
        public void TemItemVinculadoAProduto_false()
        {
            Assert.IsFalse(repo.TemItemVinculadoAProduto(PAO.Id));
        }

        [TestMethod]
        public void TemPagamentoVinculadoAFormaPagamento_true()
        {
            Assert.IsTrue(repo.TemPagamentoVinculadoAFormaPagamento(DINHEIRO.Id));
        }

        [TestMethod]
        public void TemPagamentoVinculadoAFormaPagamento_false()
        {
            Assert.IsFalse(repo.TemPagamentoVinculadoAFormaPagamento(CADERNO.Id));
        }

        [TestMethod]
        public void GerarResumoDiario_ok()
        {
            DateTime dataTeste = DateTime.Today.AddYears(1);

            Venda v6 = Venda.Iniciar(produtoRepo);
            v6.Data = dataTeste;
            v6.AdicionarItem(TWIX.Codigo, 1);
            v6.AdicionarItem(CASTANHA.Codigo, 0.2m);
            v6.AdicionarItem(ALFACE.Codigo, 3);
            v6.AdicionarItem(MACA.Codigo, 0.711m);
            v6.Pagar(v6.Total, ELO_DEBITO);
            repo.Incluir(v6);

            Venda v5 = Venda.Iniciar(produtoRepo);
            v5.Data = dataTeste;
            v5.AdicionarItem(TWIX.Codigo, 2);
            v5.AdicionarItem(CASTANHA.Codigo, 1.3m);
            v5.AdicionarItem(BANANA.Codigo, 0.5m);
            v5.AdicionarItem(MACA.Codigo, 0.711m);
            v5.Pagar(v5.Total, ELO_DEBITO);
            repo.Incluir(v5);

            Venda v4 = Venda.Iniciar(produtoRepo);
            v4.Data = dataTeste;
            v4.AdicionarItem(TWIX.Codigo, 2);
            v4.AdicionarItem(CASTANHA.Codigo, 0.399m);
            v4.AdicionarItem(BANANA.Codigo, 1.5m);
            v4.AdicionarItem(MACA.Codigo, 0.511m);
            v4.Pagar(v4.Total, MASTER_CREDITO);
            repo.Incluir(v4);

            Venda v3 = Venda.Iniciar(produtoRepo);
            v3.Data = dataTeste;
            v3.AdicionarItem(OVO.Codigo, 2);
            v3.AdicionarItem(ALFACE.Codigo);
            v3.AdicionarItem(MACA.Codigo, 0.511m);
            v3.Pagar(v3.Total, MASTER_CREDITO);
            repo.Incluir(v3);

            Venda v2 = Venda.Iniciar(produtoRepo);
            v2.Data = dataTeste;
            v2.AdicionarItem(OVO.Codigo, 2);
            v2.AdicionarItem(ALFACE.Codigo, 2);
            v2.Pagar(v2.Total, DINHEIRO);
            repo.Incluir(v2);

            Venda v1 = Venda.Iniciar(produtoRepo);
            v1.Data = dataTeste;
            v1.AdicionarItem(TWIX.Codigo, 2);
            v1.AdicionarItem(BANANA.Codigo, 0.999m);
            v1.AdicionarItem(MACA.Codigo, 0.511m);
            v1.Pagar(v1.Total, DINHEIRO);
            repo.Incluir(v1);

            Dictionary<int, decimal> resumo = repo.GerarResumoDiario(dataTeste);

            Assert.AreEqual((v1.Total + v2.Total), resumo[DINHEIRO.Id]);
            Assert.AreEqual((v3.Total + v4.Total), resumo[MASTER_CREDITO.Id]);
            Assert.AreEqual((v5.Total + v6.Total), resumo[ELO_DEBITO.Id]);
        }

        [TestMethod]
        public void Obter_ok()
        {
            Venda v = Venda.Iniciar(produtoRepo);
            v.AdicionarItem(PAO.Codigo, 0.5m);
            v.AdicionarItem(TWIX.Codigo, 2);
            v.AdicionarItem(BANANA.Codigo, 0.999m);
            v.AdicionarItem(MACA.Codigo, 0.511m);
            v.AdicionarItemDiversos(2.5m, 2.99m);
            v.CancelarItem(1);
            v.Pagar(v.Total, DINHEIRO);
            v = repo.Incluir(v);

            Venda consulta = repo.Obter(v.Id);

            Assert.IsNotNull(consulta);
            Assert.AreEqual(consulta.Data.ToString("yyyyMMddHHmm"), v.Data.ToString("yyyyMMddHHmm"));
            Assert.AreEqual(v.Total, consulta.Total);

            foreach (var item in v.Itens)
            {
                if (!item.Cancelado) // itens cancelados não são persistidos
                    Assert.IsTrue(consulta.Itens.Contains(item));
            }

            foreach (var p in v.Pagamentos)
            {
                Assert.IsTrue(consulta.Pagamentos.Contains(p));
            }
        }

        [TestMethod]
        public void GerarResumoAnalitico_Ok()
        {
            DateTime dataTeste = DateTime.Today.AddYears(20);

            decimal qtdAlface = 0;
            decimal qtdBanana = 0;
            decimal qtdCastanha = 0;
            decimal qtdMaca = 0;
            decimal qtdOvo = 0;
            decimal qtdTwix = 0;

            Venda v6 = Venda.Iniciar(produtoRepo);
            v6.Data = dataTeste;
            qtdTwix += v6.AdicionarItem(TWIX.Codigo, 1).Qtd;
            qtdCastanha += v6.AdicionarItem(CASTANHA.Codigo, 0.2m).Qtd;
            qtdAlface += v6.AdicionarItem(ALFACE.Codigo, 3).Qtd;
            qtdMaca += v6.AdicionarItem(MACA.Codigo, 0.711m).Qtd;

            v6.Pagar(v6.Total, ELO_DEBITO);
            repo.Incluir(v6);

            Venda v5 = Venda.Iniciar(produtoRepo);
            v5.Data = dataTeste;
            qtdTwix += v5.AdicionarItem(TWIX.Codigo, 2).Qtd;
            qtdCastanha += v5.AdicionarItem(CASTANHA.Codigo, 1.3m).Qtd;
            qtdBanana += v5.AdicionarItem(BANANA.Codigo, 0.5m).Qtd;
            qtdMaca += v5.AdicionarItem(MACA.Codigo, 0.711m).Qtd;
            v5.Pagar(v5.Total, ELO_DEBITO);
            repo.Incluir(v5);

            Venda v4 = Venda.Iniciar(produtoRepo);
            v4.Data = dataTeste;
            qtdTwix += v4.AdicionarItem(TWIX.Codigo, 2).Qtd;
            qtdCastanha += v4.AdicionarItem(CASTANHA.Codigo, 0.399m).Qtd;
            qtdBanana += v4.AdicionarItem(BANANA.Codigo, 1.5m).Qtd;
            qtdMaca += v4.AdicionarItem(MACA.Codigo, 0.511m).Qtd;
            v4.Pagar(v4.Total, MASTER_CREDITO);
            repo.Incluir(v4);

            Venda v3 = Venda.Iniciar(produtoRepo);
            v3.Data = dataTeste;
            qtdOvo += v3.AdicionarItem(OVO.Codigo, 2).Qtd;
            qtdAlface += v3.AdicionarItem(ALFACE.Codigo).Qtd;
            qtdMaca += v3.AdicionarItem(MACA.Codigo, 0.511m).Qtd;
            v3.Pagar(v3.Total, MASTER_CREDITO);
            repo.Incluir(v3);

            Venda v2 = Venda.Iniciar(produtoRepo);
            v2.Data = dataTeste;
            qtdOvo += v2.AdicionarItem(OVO.Codigo, 2).Qtd;
            qtdAlface += v2.AdicionarItem(ALFACE.Codigo, 2).Qtd;
            v2.Pagar(v2.Total, DINHEIRO);
            repo.Incluir(v2);

            Venda v1 = Venda.Iniciar(produtoRepo);
            v1.Data = dataTeste;
            qtdTwix += v1.AdicionarItem(TWIX.Codigo, 2).Qtd;
            qtdBanana += v1.AdicionarItem(BANANA.Codigo, 0.999m).Qtd;
            qtdMaca += v1.AdicionarItem(MACA.Codigo, 0.511m).Qtd;
            v1.Pagar(v1.Total, DINHEIRO);
            repo.Incluir(v1);

            Dictionary<long, ResumoVenda> resumo = repo.GerarResumoAnalitico(dataTeste, dataTeste);
            // qtds
            Assert.AreEqual(qtdAlface, resumo[ALFACE.Codigo].Qtd);
            Assert.AreEqual(qtdBanana, resumo[BANANA.Codigo].Qtd);
            Assert.AreEqual(qtdCastanha, resumo[CASTANHA.Codigo].Qtd);
            Assert.AreEqual(qtdMaca, resumo[MACA.Codigo].Qtd);
            Assert.AreEqual(qtdOvo, resumo[OVO.Codigo].Qtd);
            Assert.AreEqual(qtdTwix, resumo[TWIX.Codigo].Qtd);

            // precos
            Assert.AreEqual(Decimal.Round(qtdAlface * ALFACE.PrecoVenda,2), resumo[ALFACE.Codigo].Total);
            Assert.AreEqual(Decimal.Round(qtdBanana * BANANA.PrecoVenda, 2), resumo[BANANA.Codigo].Total);
            Assert.AreEqual(Decimal.Round(qtdCastanha * CASTANHA.PrecoVenda,2), resumo[CASTANHA.Codigo].Total);
            Assert.AreEqual(Decimal.Round(qtdMaca * MACA.PrecoVenda,2), resumo[MACA.Codigo].Total);
            Assert.AreEqual(Decimal.Round(qtdOvo * OVO.PrecoVenda,2), resumo[OVO.Codigo].Total);
            Assert.AreEqual(Decimal.Round(qtdTwix * TWIX.PrecoVenda, 2), resumo[TWIX.Codigo].Total);
            
        }

        [TestMethod]
        public void ObterUltimoId_ok()
        {
            Venda v = Venda.Iniciar(produtoRepo);
            v.AdicionarItem(PAO.Codigo, 0.5m);
            v.AdicionarItem(TWIX.Codigo, 2);
            v.AdicionarItem(BANANA.Codigo, 0.999m);
            v.AdicionarItem(MACA.Codigo, 0.511m);
            v.AdicionarItemDiversos(2.5m, 2.99m);
            v.CancelarItem(1);
            v.Pagar(v.Total, DINHEIRO);
            v = repo.Incluir(v);

            Assert.AreEqual(v.Id, repo.ObterUltimoId());
        }

        [TestMethod]
        public void Listar_ok()
        {
            Venda v = Venda.Iniciar(produtoRepo);
            v.AdicionarItem(PAO.Codigo, 0.5m);
            v.AdicionarItem(TWIX.Codigo, 2);
            v.AdicionarItem(BANANA.Codigo, 0.999m);
            v.AdicionarItem(MACA.Codigo, 0.511m);
            v.AdicionarItemDiversos(2.5m, 2.99m);
            v.CancelarItem(1);
            v.Pagar(v.Total, DINHEIRO);
            v = repo.Incluir(v);

            List<Venda> lista = repo.Listar(DateTime.Today, DateTime.Today);

            Assert.IsTrue(lista.Contains(v));

            Venda vendaBanco = lista.Find(x => x.Id == v.Id);
            Assert.AreEqual(v.Total, vendaBanco.Total);

            foreach (var item in v.Itens)
            {
                if (!item.Cancelado) // itens cancelados não são persistidos
                    Assert.IsTrue(vendaBanco.Itens.Contains(item));
            }

            foreach (var p in v.Pagamentos)
            {
                Assert.IsTrue(vendaBanco.Pagamentos.Contains(p));
            }
        }

        [TestMethod]
        public void Listar_ok_NaoTemVendasNoDia()
        {
            Venda v = Venda.Iniciar(produtoRepo);
            v.AdicionarItem(PAO.Codigo, 0.5m);
            v.AdicionarItem(TWIX.Codigo, 2);
            v.AdicionarItem(BANANA.Codigo, 0.999m);
            v.AdicionarItem(MACA.Codigo, 0.511m);
            v.AdicionarItemDiversos(2.5m, 2.99m);
            v.CancelarItem(1);
            v.Pagar(v.Total, DINHEIRO);
            v = repo.Incluir(v);

            DateTime daqui5Dias = DateTime.Today.AddDays(5);

            List<Venda> lista = repo.Listar(daqui5Dias, daqui5Dias);

            Assert.AreEqual(0, lista.Count);
        }
    }
}
