using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using mise.model;
using mise.exception;
using System.Collections.Generic;
using System.Linq;

namespace miseTest
{
    [TestClass]
    public class CategoriaRepoTest
    {
        private CategoriaRepo _repo;

        [TestInitialize]
        public void Init()
        {
            _repo = CategoriaRepo.Instance;

        }

        [TestMethod]
        public void Incluir_Erro_NomeNaoInformado1()
        {
            Categoria categoria = new Categoria();
            categoria.Nome = null;

            try
            {
                categoria = _repo.Incluir(categoria);
                Assert.Fail("Nome não pode ser null!");
            }
            catch (MiseException)
            {
            }
        }

        [TestMethod]
        public void Incluir_Erro_NomeNaoInformado2()
        {
            Categoria categoria = new Categoria();
            categoria.Nome = "";

            try
            {
                categoria = _repo.Incluir(categoria);
                Assert.Fail("Nome não pode ser ''!");
            }
            catch (MiseException)
            {
            }
        }

        [TestMethod]
        public void Incluir_Ok()
        {
            Categoria categoria = new Categoria();
            categoria.Nome = "COMBUSTIVEL";

            categoria = _repo.Incluir(categoria);
            Assert.AreNotEqual(0, categoria.Id);
        }

        [TestMethod]
        public void Obter_Erro_NaoEncontrado()
        {
            Assert.IsNull(_repo.Obter(int.MaxValue));
        }

        [TestMethod]
        public void Obter_Ok()
        {
            Categoria categoria = new Categoria();
            categoria.Nome = "FORNECEDORES";

            categoria = _repo.Incluir(categoria);

            Categoria banco = _repo.Obter(categoria.Id);

            Assert.AreEqual(categoria.Nome, banco.Nome);
        }

        [TestMethod]
        public void Alterar_Erro_NomeObrigatorio1()
        {
            Categoria categoria = new Categoria();
            categoria.Nome = "CONTAS";
            categoria = _repo.Incluir(categoria);

            // alterando
            categoria.Nome = null;

            try
            {
                categoria = _repo.Alterar(categoria);
                Assert.Fail("Nome não pode ser null!");
            }
            catch (MiseException)
            {
            }
        }

        [TestMethod]
        public void Alterar_Erro_NomeObrigatorio2()
        {
            Categoria categoria = new Categoria();
            categoria.Nome = "CONTAS";
            categoria = _repo.Incluir(categoria);

            // alterando
            categoria.Nome = "";

            try
            {
                categoria = _repo.Alterar(categoria);
                Assert.Fail("Nome não pode ser ''!");
            }
            catch (MiseException)
            {
            }
        }

        [TestMethod]
        public void Alterar_Erro_IdObrigatorio()
        {
            Categoria categoria = new Categoria();
            categoria.Nome = "CONTAS";
            categoria = _repo.Incluir(categoria);

            // alterando
            categoria.Id = 0;
            categoria.Nome = "CONTAS ALT";

            try
            {
                categoria = _repo.Alterar(categoria);
                Assert.Fail("Id não pode ser 0!");
            }
            catch (MiseException)
            {
            }
        }

        [TestMethod]
        public void Alterar_Ok()
        {
            Categoria categoria = new Categoria();
            categoria.Nome = "CONTAS";
            categoria = _repo.Incluir(categoria);

            // alterando
            categoria.Nome = "CONTAS ALT";
            categoria = _repo.Alterar(categoria);

            Categoria banco = _repo.Obter(categoria.Id);

            Assert.AreEqual(categoria.Nome, banco.Nome);
        }

        [TestMethod]
        public void Listar_Ok()
        {
            Categoria categoria = new Categoria();
            categoria.Nome = "INVESTIMENTOS";
            categoria = _repo.Incluir(categoria);

            List<Categoria> lista = _repo.Listar();
            Assert.IsTrue(lista.Contains(categoria));

            Categoria banco = lista.Find(x => x.Id == categoria.Id);

            Assert.AreEqual(categoria.Nome, banco.Nome);
        }

        [TestMethod]
        public void Excluir_Erro_IdObrigatorio()
        {
            try
            {
                _repo.Excluir(0);
                Assert.Fail("Id não informado!");
            }
            catch (MiseException)
            {
            }
        }

        [TestMethod]
        public void Excluir_Erro_CategoriaVinculadaALancamento()
        {
            Categoria categoria = new Categoria();
            categoria.Nome = "cat vinculada";
            categoria = _repo.Incluir(categoria);

            Lancamento l = new Lancamento();
            l.Descricao = "lancamento";
            l.Data = DateTime.Today;
            l.Categoria = categoria;
            l.Valor = 10.00m;

            LancamentoRepo.Instance.Incluir(l);

            try
            {
                _repo.Excluir(categoria.Id);
                Assert.Fail("Não pode excluir categoria vinculada a lancamento!");
            }
            catch (MiseException)
            {
            }
        }

        [TestMethod]
        public void Excluir_Ok()
        {
            Categoria categoria = new Categoria();
            categoria.Nome = "teste teste";
            categoria = _repo.Incluir(categoria);

            _repo.Excluir(categoria.Id);

            List<Categoria> lista = _repo.Listar();
            Assert.IsFalse(lista.Contains(categoria));

            Categoria banco = lista.Find(x => x.Id == categoria.Id);
            Assert.IsNull(banco);
        }
    }
}
