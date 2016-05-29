using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using mise.model;
using mise.exception;
using System.Collections.Generic;

namespace miseTest
{
    [TestClass]
    public class FornecedorRepoTest
    {
        private FornecedorRepo repo;
        private Fornecedor fornecedorAlt;

        [TestInitialize]
        public void Init()
        {
            repo = FornecedorRepo.Instance;

            if (fornecedorAlt == null)
            {
                Fornecedor f = new Fornecedor();
                f.NomeFantasia = "JUNJI SA";
                f.RazaoSocial = "JUNJI ITO SA";
                f.Contato = "junji";
                f.Telefone = "33334444";
                f.Outros = "x";
                fornecedorAlt = repo.Incluir(f);
            }

            repo.Carregar();
        }

        [TestMethod]
        public void ListarTodos_Ok()
        {
            Fornecedor f = new Fornecedor();
            f.NomeFantasia = "JUNJI SA";
            f.RazaoSocial = "JUNJI ITO SA";
            f.Contato = "junji";
            f.Telefone = "33334444";
            f.Outros = "x";
            repo.Incluir(f);
            repo.Carregar();
            
            List<Fornecedor> todos = repo.ListarTodos();

            Assert.IsTrue(todos.Contains(f));
        }

        [TestMethod]
        public void Obter_Ok()
        {
            Fornecedor f = new Fornecedor();
            f.NomeFantasia = "JUNJI SA";
            f.RazaoSocial = "JUNJI ITO SA";
            f.Contato = "junji";
            f.Telefone = "33334444";
            f.Outros = "x";
            f = repo.Incluir(f);
            repo.Carregar();

            Fornecedor banco = repo.Obter(f.Id);

            Assert.AreEqual(f.NomeFantasia, banco.NomeFantasia);
            Assert.AreEqual(f.RazaoSocial, banco.RazaoSocial);
            Assert.AreEqual(f.Contato, banco.Contato);
            Assert.AreEqual(f.Telefone, banco.Telefone);
            Assert.AreEqual(f.Outros, banco.Outros);
        }

        [TestMethod]
        public void Incluir_Erro_nomeFantasiaNaoInformado()
        {
            Fornecedor f = new Fornecedor();
            f.NomeFantasia = null;
            f.RazaoSocial = "JUNJI ITO SA";
            f.Contato = "junji";
            f.Telefone = "33334444";
            f.Outros = "x";
            try
            {
                f = repo.Incluir(f);
                Assert.Fail("Não pode deixar incluir se nomeFantasia = null");
            }
            catch (MiseException)
            {
            }
        }

        [TestMethod]
        public void Incluir_Erro_nomeFantasiaNaoInformado2()
        {
            Fornecedor f = new Fornecedor();
            f.NomeFantasia = "";
            f.RazaoSocial = "JUNJI ITO SA";
            f.Contato = "junji";
            f.Telefone = "33334444";
            f.Outros = "x";
            try
            {
                f = repo.Incluir(f);
                Assert.Fail("Não pode deixar incluir se nomeFantasia = ''");
            }
            catch (MiseException)
            {
            }
        }

        [TestMethod]
        public void Incluir_Ok()
        {
            Fornecedor f = new Fornecedor();
            f.NomeFantasia = "JUNJI SA";
            f.RazaoSocial = "JUNJI ITO SA";
            f.Contato = "junji";
            f.Telefone = "33334444";
            f.Outros = "x";
            f = repo.Incluir(f);
            
            Assert.IsNotNull(f.Id);
        }

        [TestMethod]
        public void Alterar_Erro_NomeFantasiaNaoInformado()
        {
            fornecedorAlt.NomeFantasia = null;

            try
            {
                repo.Alterar(fornecedorAlt);
                Assert.Fail("Não pode deixar alterar nomeFantasia para null!");
            }
            catch (MiseException)
            {
            }

        }

        [TestMethod]
        public void Alterar_Erro_NomeFantasiaNaoInformado2()
        {
            fornecedorAlt.NomeFantasia = "";

            try
            {
                repo.Alterar(fornecedorAlt);
                Assert.Fail("Não pode deixar alterar nomeFantasia para ''!");
            }
            catch (MiseException)
            {
            }

        }

        [TestMethod]
        public void Alterar_Erro_IdNaoInformado()
        {
            fornecedorAlt.Id = 0;

            try
            {
                repo.Alterar(fornecedorAlt);
                Assert.Fail("Id obrigatório!");
            }
            catch (MiseException)
            {
            }

        }

        [TestMethod]
        public void Alterar_Ok()
        {
            fornecedorAlt.NomeFantasia = "JUNJI SA alt";
            fornecedorAlt.RazaoSocial = "JUNJI ITO SA alt";
            fornecedorAlt.Contato = "junji alt";
            fornecedorAlt.Telefone = "33334444 5";
            fornecedorAlt.Outros = "xy";

            repo.Alterar(fornecedorAlt);

            Fornecedor banco = repo.Obter(fornecedorAlt.Id);

            Assert.AreEqual(fornecedorAlt.NomeFantasia, banco.NomeFantasia);
            Assert.AreEqual(fornecedorAlt.RazaoSocial, banco.RazaoSocial);
            Assert.AreEqual(fornecedorAlt.Contato, banco.Contato);
            Assert.AreEqual(fornecedorAlt.Telefone, banco.Telefone);
            Assert.AreEqual(fornecedorAlt.Outros, banco.Outros);
        }

        [TestMethod]
        public void Listar_Ok_SemFiltrar()
        {
            Assert.AreEqual(repo.ListarTodos().Count, repo.Listar("").Count);
        }

        [TestMethod]
        public void Listar_Ok_ComFiltro()
        {
            Fornecedor f = new Fornecedor();
            f.NomeFantasia = "NEO JUNJI SA 2";
            f.RazaoSocial = "JUNJI ITO SA";
            f.Contato = "junji";
            f.Telefone = "33334444";
            f.Outros = "x";
            f = repo.Incluir(f);

            repo.Carregar();

            Assert.IsTrue(repo.Listar("NEO JUNJI SA").Contains(f));
        }

        [TestMethod]
        public void Excluir_Erro_FornecedorVinculadoAProduto()
        {
            Fornecedor f = new Fornecedor();
            f.NomeFantasia = "JUNJI SA";
            f.RazaoSocial = "JUNJI ITO SA";
            f.Contato = "junji";
            f.Telefone = "33334444";
            f.Outros = "x";
            f = repo.Incluir(f);
            repo.Carregar();

            Produto p = new Produto();
            p.Codigo = 99990809809;
            p.Nome = "teste";
            p.Descricao = "descricao";
            p.PrecoVenda = 5.90m;
            p.UnidadeMedida = "UN";
            p.Fornecedor = f;

            ProdutoRepo produtoRepo = ProdutoRepo.Instance;
            produtoRepo.Carregar();
            if (!produtoRepo.PossuiCodigo(p.Codigo))
            {
                produtoRepo.Incluir(p);
            }
            else
            {
                Produto pp = produtoRepo.Obter(p.Codigo);
                p.Id = pp.Id;
                produtoRepo.Alterar(p);
            }
            produtoRepo.Carregar();
            
            try
            {
                repo.Excluir(f.Id);
                Assert.Fail("Não pode excluir fornecedor vinculado a produto.");
            }
            catch (MiseException)
            {
                
            }
        }

        [TestMethod]
        public void Excluir_Ok()
        {
            Fornecedor f = new Fornecedor();
            f.NomeFantasia = "NEO JUNJI SA 3";
            f.RazaoSocial = "JUNJI ITO SA";
            f.Contato = "junji";
            f.Telefone = "33334444";
            f.Outros = "x";
            f = repo.Incluir(f);

            repo.Carregar();

            repo.Excluir(f.Id);
            repo.Carregar();
            Assert.IsFalse(repo.ListarTodos().Contains(f));
        }
    }
}
