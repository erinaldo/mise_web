using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using mise;
using mise.model;

namespace miseTest
{
    [TestClass]
    public class ItemTest
    {
        private static CatalogoMap catalogo;

        [ClassInitialize]
        public static void initClass(TestContext ctx)
        {
            catalogo = Mock.catalogo();
        }

        [TestMethod]
        public void NovoItem_1KgDeMaca()
        {
            Item item = new Item(1, Mock.MACA_FUJI, 1);

            Assert.AreEqual(Mock.MACA_FUJI.Nome, item.NomeProduto);
            Assert.AreEqual(Mock.MACA_FUJI.PrecoVenda, item.Total);
            Assert.AreEqual(Mock.MACA_FUJI.PrecoVenda, item.PrecoUni);
        }

        [TestMethod]
        public void NovoItem_UmKgEMeioDeMelao()
        {
            Item item = new Item(1, Mock.MELAO, 1.5m);

            Assert.AreEqual(Mock.MELAO.Nome, item.NomeProduto);
            Assert.AreEqual(Decimal.Round(Mock.MELAO.PrecoVenda * 1.5m, 2), item.Total);
            Assert.AreEqual(Mock.MELAO.PrecoVenda, item.PrecoUni);
        }

        [TestMethod]
        public void NovoItem_Diversos_3_99()
        {
            Item item = new Item(1, Mock.DIVERSOS, 1, 3.99m);

            Assert.AreEqual(3.99m, item.Total);
        }
    }
}
