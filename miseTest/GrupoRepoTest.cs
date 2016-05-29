using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using mise.model;
using mise.exception;

namespace miseTest
{
    [TestClass]
    public class GrupoRepoTest
    {
        private GrupoRepo repo;

        [TestInitialize]
        public void Init()
        {
            repo = GrupoRepo.Instance;
        }

        [TestMethod]
        public void Incluir_Erro_DescricaoNaoInformada()
        {
            Grupo g = new Grupo();
            g.Nome = null;
            try
            {
                g = repo.Incluir(g);
                Assert.Fail("Descrição obrigatória!");
            }
            catch (MiseException)
            {
            }
        }

        [TestMethod]
        public void Incluir_Erro_DescricaoNaoInformada2()
        {
            Grupo g = new Grupo();
            g.Nome = "";
            try
            {
                g = repo.Incluir(g);
                Assert.Fail("Descrição obrigatória!");
            }
            catch (MiseException)
            {
            }
        }

        [TestMethod]
        public void Incluir_Ok()
        {
            Grupo g = new Grupo();
            g.Nome = "GULOSEIMAS";

            g = repo.Incluir(g);

            Assert.IsNotNull(g.Id);
        }

        [TestMethod]
        public void Obter_Ok()
        {
            Grupo g = new Grupo();
            g.Nome = "GULOSEIMAS 2";

            g = repo.Incluir(g);
            repo.Carregar();

            Grupo banco = repo.Obter(g.Id);

            Assert.AreEqual(g.Nome, banco.Nome);
        }

        [TestMethod]
        public void Listar_Ok()
        {
            Grupo g = new Grupo();
            g.Nome = "GULOSEIMAS 3";

            g = repo.Incluir(g);
            repo.Carregar();

            Assert.IsTrue(repo.Listar().Contains(g));
        }

        [TestMethod]
        public void Alterar_Erro_IdObrigatorio()
        {
            Grupo g = new Grupo();
            g.Nome = "GULOSEIMAS 4";

            g = repo.Incluir(g);
            repo.Carregar();

            Grupo alterado = repo.Obter(g.Id);
            alterado.Id = 0;
            alterado.Nome = "GULOSEIMAS Z";

            try
            {
                repo.Alterar(alterado);
                Assert.Fail("Id obrigatório!");
            }
            catch (MiseException)
            {
            }
        }

        [TestMethod]
        public void Alterar_Erro_DescricaoObrigatoria()
        {
            Grupo g = new Grupo();
            g.Nome = "GULOSEIMAS 4";

            g = repo.Incluir(g);
            repo.Carregar();

            Grupo alterado = repo.Obter(g.Id);
            alterado.Nome = null;

            try
            {
                repo.Alterar(alterado);
                Assert.Fail("Descrição obrigatória!");
            }
            catch (MiseException)
            {
            }
        }

        [TestMethod]
        public void Alterar_Erro_DescricaoObrigatoria2()
        {
            Grupo g = new Grupo();
            g.Nome = "GULOSEIMAS 4";

            g = repo.Incluir(g);
            repo.Carregar();

            Grupo alterado = repo.Obter(g.Id);
            alterado.Nome = "";

            try
            {
                repo.Alterar(alterado);
                Assert.Fail("Descrição obrigatória!");
            }
            catch (MiseException)
            {
            }
        }

        [TestMethod]
        public void Alterar_Ok()
        {
            Grupo g = new Grupo();
            g.Nome = "GULOSEIMAS 4";

            g = repo.Incluir(g);
            repo.Carregar();

            Grupo alterado = repo.Obter(g.Id);
            alterado.Nome = "GULOSEIMAS Z";

            repo.Alterar(alterado);

            Grupo banco = repo.Obter(alterado.Id);

            Assert.AreEqual(alterado.Nome, banco.Nome);
        }

        [TestMethod]
        public void Excluir_Erro_GrupoVinculadoAProduto()
        {
            Grupo g = new Grupo();
            g.Nome = "GULOSEIMAS DO NIHON";

            g = repo.Incluir(g);
            repo.Carregar();

            Produto p = new Produto();
            ProdutoRepo.Instance.Carregar();
            if (ProdutoRepo.Instance.PossuiCodigo(556677))
            {
                ProdutoRepo.Instance.Excluir(ProdutoRepo.Instance.Obter(556677).Id);
            }
            ProdutoRepo.Instance.Carregar();

            p.Codigo = 556677;
            p.Nome = "KARINTO";
            p.Descricao = "KARINTO";
            p.PrecoVenda = 4.5m;
            p.UnidadeMedida = "UN";
            p.Grupo = g;
            ProdutoRepo.Instance.Incluir(p);
            ProdutoRepo.Instance.Carregar();

            try
            {
                repo.Excluir(g.Id);
                Assert.Fail("Não pode excluir grupo vinculado a produto!");
            }
            catch (MiseException)
            {
            }
        }

        [TestMethod]
        public void Excluir_Erro_IdNaoInformado()
        {
            try
            {
                repo.Excluir(0);
                Assert.Fail("Id é obrigatório!");
            }
            catch (MiseException)
            {
            }
        }

        [TestMethod]
        public void Excluir_Ok()
        {
            Grupo g = new Grupo();
            g.Nome = "GULOSEIMAS 4";

            g = repo.Incluir(g);
            repo.Carregar();

            repo.Excluir(g.Id);
            repo.Carregar();

            Assert.IsFalse(repo.Listar().Contains(g));
        }
    }
}
