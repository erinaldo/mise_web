using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using mise;
using mise.model;
using mise.exception;

namespace miseTest
{
    [TestClass]
    public class CatalogoTest
    {
        private static CatalogoMap catalogo;

        [TestInitialize]
        public void init()
        {
            catalogo = CatalogoMap.Instance();
        }

        [TestMethod]
        public void IncluirProduto_Ok()
        {
            catalogo.Incluir(Mock.KITKAT);

            Assert.IsTrue(catalogo.PossuiCodigo(Mock.KITKAT.Codigo), "depois de incluir tem que constar no catálogo");
        }

        [TestMethod]
        public void IncluirProduto_SemCodBarra_Ok()
        {
            catalogo.Incluir(Mock.BANANA_CATURRA);
            
            Assert.IsTrue(catalogo.PossuiCodigo(Mock.BANANA_CATURRA.Codigo), "depois de incluir tem que constar no catálogo");
        }

        [TestMethod]
        public void IncluirProduto_CodigoInternoJaExistente()
        {
            Assert.IsFalse(catalogo.PossuiCodigo(2), "antes de incluir ainda não possui no catálogo");

            catalogo.Incluir(Mock.BANANA_CATURRA);

            Assert.IsTrue(catalogo.PossuiCodigo(2), "depois de incluir tem que constar no catálogo");
            try
            {
                catalogo.Incluir(Mock.BANANA_CATURRA);
                Assert.Fail("deveria ter lançado exception");
            }
            catch (MiseException)
            {
            }
        }

        [TestMethod]
        public void IncluirProduto_CodigoBarrasJaExistente()
        {
            catalogo.Incluir(Mock.KITKAT);
            try
            {
                catalogo.Incluir(Mock.KITKAT);
                Assert.Fail("deveria ter lançado exception");
            }
            catch (MiseException)
            {
            }
        }

        [TestMethod]
        public void IncluirProduto_NomeNull()
        {
            try
            {
                catalogo.Incluir(new Produto(3, null, 3.00m, "KG"));
                Assert.Fail("não pode incluir produto com nome null");
            }
            catch (MiseException)
            {
            }
        }

        [TestMethod]
        public void IncluirProduto_NomeVazio()
        {
            try
            {
                catalogo.Incluir(new Produto(4, "", 3.00m, "KG"));
                Assert.Fail("não pode incluir produto com nome vazio");
            }
            catch (MiseException)
            {
            }
        }

        [TestMethod]
        public void IncluirProduto_PrecoVendaZerado()
        {
            try
            {
                catalogo.Incluir(new Produto(4, "Kit Kat", 0, "KG"));
                Assert.Fail("não pode incluir produto preco venda zerado");
            }
            catch (MiseException)
            {
            }
        }

        [TestMethod]
        public void Obter_Ok()
        {
            catalogo.Incluir(Mock.EBICEN);

            Produto ebicen = catalogo.Obter(Mock.EBICEN.Codigo);

            Assert.AreEqual(Mock.EBICEN.Codigo, ebicen.Codigo);
            Assert.AreEqual(Mock.EBICEN.Nome, ebicen.Nome);
            Assert.AreEqual(Mock.EBICEN.PrecoVenda, ebicen.PrecoVenda);

        }

        [TestMethod]
        public void Obter_NaoExistente()
        {
            try
            {
                catalogo.Obter(666);
                Assert.Fail("Codigo não encontrado");
            }
            catch (MiseException)
            {
            }
        }

        [TestMethod]
        public void Obter_PorCodBarras_Ok()
        {
            catalogo.Incluir(Mock.EBICEN);

            Produto ebicen = catalogo.Obter(Mock.EBICEN.Codigo);

            Assert.AreEqual(Mock.EBICEN.Codigo, ebicen.Codigo);
            Assert.AreEqual(Mock.EBICEN.Nome, ebicen.Nome);
            Assert.AreEqual(Mock.EBICEN.PrecoVenda, ebicen.PrecoVenda);
            Assert.AreEqual(Mock.EBICEN.UnidadeMedida, ebicen.UnidadeMedida);
        }

        [TestMethod]
        public void Excluir_PorCodInterno_Ok()
        {
            catalogo.Incluir(Mock.MACA_FUJI);

            Assert.IsTrue(catalogo.PossuiCodigo(Mock.MACA_FUJI.Codigo), "Incluiu a laranja pera");

            catalogo.Excluir(Mock.MACA_FUJI.Codigo);

            Assert.IsFalse(catalogo.PossuiCodigo(Mock.MACA_FUJI.Codigo), "Excluiu, então não possui mais código");
        }

        [TestMethod]
        public void Excluir_PorCodBarras_Ok()
        {
            catalogo.Incluir(Mock.KITKAT);

            Assert.IsTrue(catalogo.PossuiCodigo(Mock.KITKAT.Codigo), "Incluiu o brócolis");

            catalogo.Excluir(Mock.KITKAT.Codigo);

            Assert.IsFalse(catalogo.PossuiCodigo(Mock.KITKAT.Codigo), "Excluiu, então não possui mais código");
        }

        [TestMethod]
        public void IncluirDiversos_Ok()
        {
            catalogo.Incluir(Mock.DIVERSOS);

            Assert.IsTrue(catalogo.PossuiCodigo(Mock.DIVERSOS.Codigo), "Incluiu diversos");
        }

        [TestMethod]
        public void IncluirDiversos_NOk_ComPrecoVenda()
        {
            try
            {
                catalogo.Incluir(new Produto(1, "Diversos", 1.99m, null));
                Assert.Fail("Diversos não pode ter preço de venda!");
            }
            catch (MiseException)
            {
            }
        }
    }
}
