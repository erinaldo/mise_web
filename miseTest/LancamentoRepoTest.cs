using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using mise;
using mise.exception;
using mise.model;
using System.Collections.Generic;

namespace miseTest
{
    [TestClass]
    public class LancamentoRepoTest
    {
        private LancamentoRepo repo;
        private Categoria DESPESAS;
        private Categoria OUTROS;

        [TestInitialize]
        public void init()
        {
            repo = LancamentoRepo.Instance;

            if (DESPESAS == null)
            {
                DESPESAS = new Categoria();
                DESPESAS.Nome = "Despesas";

                CategoriaRepo.Instance.Incluir(DESPESAS);
            }

            if (OUTROS == null)
            {
                OUTROS = new Categoria();
                OUTROS.Nome = "OUTROS";

                CategoriaRepo.Instance.Incluir(OUTROS);
            }
        }

        [TestMethod]
        public void Incluir_Erro_DescricaoObrigatoria1()
        {
            Lancamento luz = new Lancamento();
            luz.Descricao = "";
            luz.Data = DateTime.Today;
            luz.Categoria = DESPESAS;
            luz.Valor = 80.14m;

            try
            {
                repo.Incluir(luz);
                Assert.Fail("Descrição não pode ser ''!");
            }
            catch (MiseException)
            {
            }
        }

        [TestMethod]
        public void Incluir_Erro_DescricaoObrigatoria2()
        {
            Lancamento luz = new Lancamento();
            luz.Descricao = null;
            luz.Data = DateTime.Today;
            luz.Categoria = DESPESAS;
            luz.Valor = 80.14m;

            try
            {
                repo.Incluir(luz);
                Assert.Fail("Descrição não pode ser null!");
            }
            catch (MiseException)
            {
            }
        }

        [TestMethod]
        public void Incluir_Erro_DataObrigatoria()
        {
            Lancamento luz = new Lancamento();
            luz.Descricao = "LUX";
            luz.Data = DateTime.MinValue;
            luz.Categoria = DESPESAS;
            luz.Valor = 80.14m;

            try
            {
                repo.Incluir(luz);
                Assert.Fail("Data não pode ser DateTime.MinValue!");
            }
            catch (MiseException)
            {
            }
        }

        [TestMethod]
        public void Incluir_Erro_CategoriaObrigatoria()
        {
            Lancamento luz = new Lancamento();
            luz.Descricao = "LUX";
            luz.Data = DateTime.Today;
            luz.Categoria = null;
            luz.Valor = 80.14m;

            try
            {
                repo.Incluir(luz);
                Assert.Fail("Categoria não pode ser NULL!");
            }
            catch (MiseException)
            {
            }
        }

        [TestMethod]
        public void Incluir_Erro_ValorObrigatorio()
        {
            Lancamento luz = new Lancamento();
            luz.Descricao = "LUX";
            luz.Data = DateTime.Today;
            luz.Categoria = null;
            luz.Valor = 0;

            try
            {
                repo.Incluir(luz);
                Assert.Fail("Valor não pode ser 0!");
            }
            catch (MiseException)
            {
            }
        }

        [TestMethod]
        public void Incluir_Ok()
        {
            Lancamento luz = new Lancamento();
            luz.Descricao = "Luz";
            luz.Data = DateTime.Today;
            luz.Categoria = DESPESAS;
            luz.Valor = 80.14m;

            luz = repo.Incluir(luz);

            Assert.AreNotEqual(luz.Id, 0);
        }

        [TestMethod]
        public void Obter_Ok()
        {
            Lancamento luz = new Lancamento();
            luz.Descricao = "Luz";
            luz.Data = DateTime.Today;
            luz.Categoria = DESPESAS;
            luz.Valor = 80.14m;

            luz = repo.Incluir(luz);

            Lancamento banco = repo.Obter(luz.Id);
            Assert.AreEqual(luz.Descricao, banco.Descricao);
            Assert.AreEqual(luz.Data, banco.Data);
            Assert.AreEqual(luz.Categoria, banco.Categoria);
            Assert.AreEqual(luz.Valor, banco.Valor);
        }

        [TestMethod]
        public void Listar_Ok()
        {
            Lancamento luz = new Lancamento();
            luz.Descricao = "Luz";
            luz.Data = DateTime.Today;
            luz.Categoria = DESPESAS;
            luz.Valor = 80.14m;

            luz = repo.Incluir(luz);

            List<Lancamento> lancamentos = repo.Listar();

            Lancamento l = lancamentos.Find(x => x.Id == luz.Id);

            Assert.AreEqual(luz, l);
        }

        [TestMethod]
        public void Listar_Ok_PorData()
        {
            Lancamento internet = new Lancamento();
            internet.Descricao = "internet";
            internet.Data = DateTime.Today;
            internet.Categoria = DESPESAS;
            internet.Valor = 99.88m;
            internet = repo.Incluir(internet);

            Lancamento luz = new Lancamento();
            luz.Descricao = "Luz";
            luz.Data = DateTime.Today.AddDays(7);
            luz.Categoria = DESPESAS;
            luz.Valor = 80.14m;
            luz = repo.Incluir(luz);

            List<Lancamento> lancamentos = repo.Listar(DateTime.Today);

            Lancamento luzBanco = lancamentos.Find(x => x.Id == luz.Id);
            Lancamento internetBanco = lancamentos.Find(x => x.Id == internet.Id);

            Assert.IsNull(luzBanco);
            Assert.AreEqual(internet, internetBanco);
        }

        [TestMethod]
        public void Excluir_Erro_IdObrigatorio()
        {
            try
            {
                repo.Excluir(0);
                Assert.Fail("Id não informado!");
            }
            catch (MiseException)
            {
            }
        }

        [TestMethod]
        public void Excluir_Ok()
        {
            Lancamento luz = new Lancamento();
            luz.Descricao = "Luz";
            luz.Data = DateTime.Today;
            luz.Categoria = DESPESAS;
            luz.Valor = 80.14m;

            luz = repo.Incluir(luz);

            repo.Excluir(luz.Id);

            List<Lancamento> lancamentos = repo.Listar();

            Lancamento l = lancamentos.Find(x => x.Id == luz.Id);

            Assert.IsNull(l);
        }

        [TestMethod]
        public void Alterar_Erro_IdObrigatorio()
        {
            Lancamento luz = new Lancamento();
            luz.Descricao = "Luz";
            luz.Data = DateTime.Today;
            luz.Categoria = DESPESAS;
            luz.Valor = 80.14m;

            luz = repo.Incluir(luz);

            luz.Id = 0;

            try
            {
                repo.Alterar(luz);
                Assert.Fail("Id não informado!");
            }
            catch (MiseException)
            {
            }
        }

        [TestMethod]
        public void Alterar_Erro_DescricaoObrigatoria1()
        {
            Lancamento luz = new Lancamento();
            luz.Descricao = "Luz";
            luz.Data = DateTime.Today;
            luz.Categoria = DESPESAS;
            luz.Valor = 80.14m;

            luz = repo.Incluir(luz);

            luz.Descricao = null;

            try
            {
                repo.Alterar(luz);
                Assert.Fail("Descrição não informada!");
            }
            catch (MiseException)
            {
            }
        }

        [TestMethod]
        public void Alterar_Erro_DescricaoObrigatoria2()
        {
            Lancamento luz = new Lancamento();
            luz.Descricao = "Luz";
            luz.Data = DateTime.Today;
            luz.Categoria = DESPESAS;
            luz.Valor = 80.14m;

            luz = repo.Incluir(luz);

            luz.Descricao = "";

            try
            {
                repo.Alterar(luz);
                Assert.Fail("Descrição não informada!");
            }
            catch (MiseException)
            {
            }
        }

        [TestMethod]
        public void Alterar_Erro_DataObrigatoria()
        {
            Lancamento luz = new Lancamento();
            luz.Descricao = "Luz";
            luz.Data = DateTime.Today;
            luz.Categoria = DESPESAS;
            luz.Valor = 80.14m;

            luz = repo.Incluir(luz);

            luz.Data = DateTime.MinValue;

            try
            {
                repo.Alterar(luz);
                Assert.Fail("Data não informada!");
            }
            catch (MiseException)
            {
            }
        }

        [TestMethod]
        public void Alterar_Erro_ValorObrigatorio()
        {
            Lancamento luz = new Lancamento();
            luz.Descricao = "Luz";
            luz.Data = DateTime.Today;
            luz.Categoria = DESPESAS;
            luz.Valor = 80.14m;

            luz = repo.Incluir(luz);

            luz.Valor = 0;

            try
            {
                repo.Alterar(luz);
                Assert.Fail("Valor não informado!");
            }
            catch (MiseException)
            {
            }
        }

        [TestMethod]
        public void Alterar_Erro_CategoriaObrigatoria()
        {
            Lancamento luz = new Lancamento();
            luz.Descricao = "Luz";
            luz.Data = DateTime.Today;
            luz.Categoria = DESPESAS;
            luz.Valor = 80.14m;

            luz = repo.Incluir(luz);
            luz.Categoria = null;

            try
            {
                repo.Alterar(luz);
                Assert.Fail("Categoria não informada!");
            }
            catch (MiseException)
            {
            }
        }

        [TestMethod]
        public void Alterar_Ok()
        {
            Lancamento luz = new Lancamento();
            luz.Descricao = "Luz";
            luz.Data = DateTime.Today;
            luz.Categoria = DESPESAS;
            luz.Valor = 80.14m;

            luz = repo.Incluir(luz);

            DateTime tomorrow = DateTime.Today.AddDays(1);
            luz.Descricao = "Luz Alt";
            luz.Data = tomorrow;
            luz.Categoria = OUTROS;
            luz.Valor = 77.66m;

            repo.Alterar(luz);

            Lancamento banco = repo.Obter(luz.Id);
            Assert.AreEqual(luz.Descricao, banco.Descricao);
            Assert.AreEqual(luz.Data, banco.Data);
            Assert.AreEqual(luz.Categoria, banco.Categoria);
            Assert.AreEqual(luz.Valor, banco.Valor);
        }


        [TestMethod]
        public void TemLancamentoVinculadoACategoria_false()
        {
            Assert.IsFalse(repo.TemLancamentoVinculadoACategoria(int.MaxValue));
        }

        [TestMethod]
        public void TemLancamentoVinculadoACategoria_true()
        {
            Lancamento luz = new Lancamento();
            luz.Descricao = "Luz";
            luz.Data = DateTime.Today;
            luz.Categoria = DESPESAS;
            luz.Valor = 80.14m;

            luz = repo.Incluir(luz);

            Assert.IsTrue(repo.TemLancamentoVinculadoACategoria(DESPESAS.Id));
        }

        [TestMethod]
        public void ObterTotal_Ok()
        {
            List<Lancamento> lista = repo.Listar(DateTime.Today);
            foreach (var item in lista)
            {
                repo.Excluir(item.Id);
            }

            decimal total = 0;
            Lancamento lineaVerde = new Lancamento();
            lineaVerde.Categoria = DESPESAS;
            lineaVerde.Descricao = "Linea Verde";
            lineaVerde.Data = DateTime.Today;
            lineaVerde.Valor = 25.10m;
            repo.Incluir(lineaVerde);
            total += lineaVerde.Valor;

            Lancamento internet = new Lancamento();
            internet.Categoria = DESPESAS;
            internet.Descricao = "Internet";
            internet.Data = DateTime.Today;
            internet.Valor = 125.80m;
            repo.Incluir(internet);
            total += internet.Valor;

            Lancamento luz = new Lancamento();
            luz.Categoria = DESPESAS;
            luz.Descricao = "Luz";
            luz.Data = DateTime.Today;
            luz.Valor = 80.99m;
            repo.Incluir(luz);
            total += luz.Valor;

            Assert.AreEqual(total, repo.ObterTotal(DateTime.Today));
        }
    }
}
