using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace miseTest
{
    [TestClass]
    public class FormaPagamentoTest
    {
        [TestMethod]
        public void EqualsFalse()
        {
            Assert.AreNotEqual(Mock.DINHEIRO, Mock.VISA_DEBITO);
        }

        [TestMethod]
        public void EqualsTrue()
        {
            Assert.AreEqual(Mock.DINHEIRO, Mock.DINHEIRO);
        }
    }
}
