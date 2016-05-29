using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using mise;
using mise.model;
using mise.exception;

namespace miseTest
{
    [TestClass]
    public class VendaTest
    {
        private Venda venda;
        private Venda vendaConcluida;
        private static CatalogoMap catalogo;

        [ClassInitialize]
        public static void classInit(TestContext ctx)
        {
            catalogo = Mock.catalogo();
        }

        [TestInitialize]
        public void Init()
        {
            venda = Venda.Iniciar(catalogo);

            vendaConcluida = Venda.Iniciar(catalogo);
            vendaConcluida.AdicionarItem(Mock.KITKAT.Codigo);
            vendaConcluida.Pagar(Mock.KITKAT.PrecoVenda, Mock.DINHEIRO);
            vendaConcluida.Concluir();
        }
        

        [TestMethod]
        public void IniciarVenda_Ok()
        {
            Venda venda = Venda.Iniciar(catalogo);

            Assert.AreEqual(true, venda.Iniciada());
        }

        [TestMethod]
        public void IniciarVenda_Possui0Itens()
        {
            Venda venda = Venda.Iniciar(catalogo);

            Assert.AreEqual(true, venda.Iniciada());
            Assert.AreEqual(0, venda.Itens.Count, "Venda iniciada não pode possuir itens");
        }

        [TestMethod]
        public void IniciarVenda_DataVendaIgualHoje()
        {
            Venda venda = Venda.Iniciar(catalogo);

            Assert.AreEqual(true, venda.Iniciada());
            Assert.AreEqual(DateTime.Today, venda.Data.Date, "Venda iniciada - data da venda = hoje");
        }

        [TestMethod]
        public void AdicionarItem_UmMamao()
        {
            Assert.IsFalse(venda.PossuiItem(3), "Antes de adicionar não pode ter item");

            venda.AdicionarItem(3);

            Assert.IsTrue(venda.PossuiItem(3), "Tem que ter item depois de adicionar");
        }

        [TestMethod]
        public void AdicionarItem_UmKgE275DeMaca()
        {
            Assert.IsFalse(venda.PossuiItem(Mock.MACA_FUJI.Codigo), "Antes de adicionar não pode ter item");
            Assert.AreEqual(0m, venda.Total, "Total começa igual a 0");

            venda.AdicionarItem(Mock.MACA_FUJI.Codigo, 1.275m);

            Assert.IsTrue(venda.PossuiItem(Mock.MACA_FUJI.Codigo), "Tem que ter item depois de adicionar");
            Assert.AreEqual(Mock.MACA_FUJI.PrecoVenda * 1.275m, venda.Total, "total = 1.275 de maçã");
        }

        [TestMethod]
        public void AdicionarItem_UmKgE300DeMacaMaisUmKgE199DeMorango()
        {
            Assert.IsFalse(venda.PossuiItem(Mock.MACA_FUJI.Codigo), "Antes de adicionar não pode ter item");
            Assert.IsFalse(venda.PossuiItem(Mock.MORANGO.Codigo), "Antes de adicionar não pode ter item");
            Assert.AreEqual(0m, venda.Total, "Total começa igual a 0");

            venda.AdicionarItem(Mock.MACA_FUJI.Codigo, 1.300m);
            venda.AdicionarItem(Mock.MORANGO.Codigo, 1.199m);

            decimal totalEsperado = Math.Round((Mock.MACA_FUJI.PrecoVenda * 1.300m) + (Mock.MORANGO.PrecoVenda * 1.199m), 2);

            Assert.IsTrue(venda.PossuiItem(Mock.MACA_FUJI.Codigo), "Tem que ter item depois de adicionar");
            Assert.IsTrue(venda.PossuiItem(Mock.MORANGO.Codigo), "Tem que ter item depois de adicionar");
            Assert.AreEqual(totalEsperado, venda.Total, "total = 1.3 de maçã + 1.199 de morango");
        }

        [TestMethod]
        public void AdicionarItem_CodigoNaoEncontradoNoCatalogo()
        {
            try
            {
                venda.AdicionarItem(666);
                Assert.Fail("Devia ter lançado Exception!");
            }
            catch (MiseException)
            {
            }
        }

        [TestMethod]
        public void AdicionarItem_NOk_NaoPodePassarCodigoDeDiversos()
        {
            try
            {
                venda.AdicionarItem(Mock.DIVERSOS.Codigo);

                Assert.Fail("AdicionarItem não pode aceitar Diversos!");
            }
            catch (MiseException)
            {
            }
        }

        [TestMethod]
        public void AdicionarItem_PassandoQtd_NOk_NaoPodePassarCodigoDeDiversos()
        {
            try
            {
                venda.AdicionarItem(Mock.DIVERSOS.Codigo, 2);

                Assert.Fail("AdicionarItem não pode aceitar Diversos!");
            }
            catch (MiseException)
            {
            }
        }

        [TestMethod]
        public void AdicionarItem_Ok_SetouSequencial()
        {
            Item item1 = venda.AdicionarItem(Mock.KITKAT.Codigo);
            Assert.AreEqual(1, item1.Sequencial);

            Item item2 = venda.AdicionarItem(Mock.MACA_FUJI.Codigo, 0.9m);
            Assert.AreEqual(2, item2.Sequencial);

            Item item3 = venda.AdicionarItem(Mock.MELAO.Codigo, 1.0m);
            Assert.AreEqual(3, item3.Sequencial);
        }

        [TestMethod]
        public void AdicionarItem_NOk_NaoPodeAdicionarSeVendaConcluida()
        {
            try
            {
                vendaConcluida.AdicionarItem(Mock.EBICEN.Codigo);
                Assert.Fail("Nâo pode adicionar! Venda concluída!");
            }
            catch (MiseException)
            {
            }
        }

        [TestMethod]
        public void AdicionarItem_Diversos_NOk_VendaConcluida()
        {
            try
            {
                vendaConcluida.AdicionarItemDiversos(1, 3.99m);
                Assert.Fail("Venda Concluída! Não pode adicionar item diversos!");
            }
            catch (MiseException)
            {
            }
        }

        [TestMethod]
        public void AdicionarItem_Diversos_Ok()
        {
            venda.AdicionarItemDiversos(1, 3.99m);

            Assert.IsTrue(venda.PossuiItem(Mock.DIVERSOS.Codigo));
            Assert.AreEqual(3.99m, venda.Total);
        }

        [TestMethod]
        public void AdicionarItem_Diversos_Ok_SetouSequencial()
        {
            Item i = venda.AdicionarItemDiversos(1, 3.99m);
            Assert.AreEqual(1, i.Sequencial);

            Item i2 = venda.AdicionarItemDiversos(1, 3.99m);
            Assert.AreEqual(2, i2.Sequencial);

            Item i3 = venda.AdicionarItemDiversos(1, 3.99m);
            Assert.AreEqual(3, i3.Sequencial);
        }

        [TestMethod]
        public void CancelarItem_NOk_ItemNaoEncontrado()
        {
            try
            {
                venda.CancelarItem(1);
                Assert.Fail("Não pode cancelar item se sequencial do item não existir!");
            }
            catch (MiseException)
            {
            } 
        }

        [TestMethod]
        public void CancelarItem_NOk_NumeroNegativo()
        {
            try
            {
                venda.CancelarItem(-1);
                Assert.Fail("Não pode cancelar item se sequencial do item não existir!");
            }
            catch (MiseException)
            {
            }
        }

        [TestMethod]
        public void CancelarItem_NOk_VendaConcluida()
        {
            try
            {
                vendaConcluida.CancelarItem(1);
                Assert.Fail("Venda Concluída! Não pode cancelar item!");
            }
            catch (MiseException)
            {
            }
        }

        [TestMethod]
        public void CancelarItem_Ok()
        {
            Item item = venda.AdicionarItem(Mock.EBICEN.Codigo);

            venda.CancelarItem(item.Sequencial);

            Assert.IsTrue(item.Cancelado, "Item cancelado");
            Assert.AreEqual(0.0m, venda.Total, "total não pode contabilizar itens cancelados!");
        }

        [TestMethod]
        public void TotalAPagar_Ok_VendaSemItens()
        {
            Assert.AreEqual(0.0m, venda.TotalAPagar);
        }

        [TestMethod]
        public void TotalAPagar_Ok_VendaComUmItem_AindaNaoPago()
        {
            venda.AdicionarItem(Mock.MORANGO.Codigo, 1.5m);
            decimal aPagarEsperado = Math.Round(Mock.MORANGO.PrecoVenda * 1.5m, 2);
            Assert.AreEqual(aPagarEsperado, venda.TotalAPagar);
        }

        [TestMethod]
        public void Troco_Ok_AindaNaoPago()
        {
            venda.AdicionarItem(Mock.KITKAT.Codigo);
            Assert.AreEqual(0, venda.Troco);
        }

        [TestMethod]
        public void Troco_Ok_ParcialmentePago()
        {
            venda.AdicionarItem(Mock.KITKAT.Codigo);
            venda.Pagar(Mock.KITKAT.PrecoVenda - 1, Mock.DINHEIRO);

            Assert.AreEqual(0, venda.Troco);
        }

        [TestMethod]
        public void Troco_Ok_PagamentoExato()
        {
            venda.AdicionarItem(Mock.KITKAT.Codigo);
            venda.Pagar(Mock.KITKAT.PrecoVenda, Mock.DINHEIRO);

            Assert.AreEqual(0, venda.Troco);
        }

        [TestMethod]
        public void Troco_Ok_PagamentoAMais_Troco()
        {
            venda.AdicionarItem(Mock.KITKAT.Codigo);
            venda.Pagar(Mock.KITKAT.PrecoVenda + 2, Mock.DINHEIRO);

            Assert.AreEqual(2, venda.Troco);
        }

        [TestMethod]
        public void Pagar_NOk_ValorNegativo()
        {
            
            venda.AdicionarItem(Mock.MORANGO.Codigo, 1.5m);

            try
            {
                venda.Pagar(-1m, Mock.DINHEIRO);
                Assert.Fail("Não pode aceitar pagamentos negativos!");
            }
            catch (MiseException)
            {    
            }

        }

        [TestMethod]
        public void Pagar_NOk_VendaNaoPossuiItens()
        {
            try
            {
                venda.Pagar(5m, Mock.DINHEIRO);
                Assert.Fail("Não pode pagar se não tiver itens!");
            }
            catch (MiseException)
            {
            }
        }

        [TestMethod]
        public void Pagar_NOk_VendaConcluida()
        {
            try
            {
                vendaConcluida.Pagar(1m, Mock.DINHEIRO);
                Assert.Fail("Venda Concluída! Não pode pagar!");
            }
            catch (MiseException)
            {
            }

        }

        [TestMethod]
        public void Pagar_Ok_ValorExato()
        {
            venda.AdicionarItem(Mock.MORANGO.Codigo, 1.5m);
            venda.Pagar(Mock.MORANGO.PrecoVenda * 1.5m, Mock.DINHEIRO);

            Assert.AreEqual(0m, venda.TotalAPagar);
        }

        [TestMethod]
        public void Pagar_Ok_ValorMenorQueOTotal()
        {
            decimal aPagar = Math.Round(1.5m * Mock.MORANGO.PrecoVenda, 2);
            decimal pago = Math.Round(aPagar / 2m, 2);

            venda.AdicionarItem(Mock.MORANGO.Codigo, 1.5m);
            venda.Pagar(pago, Mock.DINHEIRO);

            Assert.AreEqual(aPagar - pago, venda.TotalAPagar);
        }

        [TestMethod]
        public void Pagar_NOk_2Pagamentos_NaoPossuiMaisSaldoDevedor()
        {
            decimal aPagar = Math.Round(1.5m * Mock.MORANGO.PrecoVenda, 2);
            
            venda.AdicionarItem(Mock.MORANGO.Codigo, 1.5m);
            venda.Pagar(aPagar + 1m, Mock.DINHEIRO);
            try
            {
                venda.Pagar(1m, Mock.DINHEIRO);
                Assert.Fail("Não tem mais o que pagar!");
            }
            catch (MiseException)
            {
            }
        }

        [TestMethod]
        public void Concluir_NOk_PagamentoNaoEfetuado()
        {
            venda.AdicionarItem(Mock.EBICEN.Codigo);
            try
            {
                venda.Concluir();
                Assert.Fail("Não pode concluir sem pagar");
            }
            catch (MiseException)
            {
            }
        }

        [TestMethod]
        public void Concluir_NOk_VendaSemItens()
        {
            try
            {
                venda.Concluir();
                Assert.Fail("Não pode concluir sem pagar");
            }
            catch (MiseException)
            {
            }
        }

        [TestMethod]
        public void Concluir_Ok()
        {
            venda.AdicionarItem(Mock.KITKAT.Codigo);
            venda.Pagar(Mock.KITKAT.PrecoVenda, Mock.DINHEIRO);

            venda.Concluir();

            Assert.IsTrue(venda.Concluida());
        }

        [TestMethod]
        public void Cancelar_NOk_JaConcluida()
        {
            try
            {
                vendaConcluida.Cancelar();
                Assert.Fail("Já Concluída! Não pode cancelar!");
            }
            catch (MiseException)
            {
            }
        }

        [TestMethod]
        public void Cancelar_Ok()
        {
            venda.Cancelar();

            Assert.IsTrue(venda.Cancelada());
        }

        [TestMethod]
        public void CancelarPagamento_OK()
        {
            venda.AdicionarItem(Mock.BANANA_CATURRA.Codigo);
            venda.Pagar(20, Mock.DINHEIRO);
            venda.CancelarPagamento();

            Assert.AreEqual(0, venda.Pagamentos.Count);
        }
    }
}
