using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using mise.model;
using mise.exception;
using System.Collections.Generic;

namespace miseTest
{
    [TestClass]
    public class ProdutoRepoTest
    {
        private ProdutoRepo repo;
        private VendaRepo vendaRepo;

        private static long CODIGO_TESTE = 140788;
        private static long CODIGO_VINCULADO = 9988776655443322;

        private Produto produtoTeste;
        private Produto produtoComVenda;
        private Produto produtoComGrupoEFornecedor;
        private Produto diverso;

        private Grupo grupo;
        private Fornecedor fornecedor;

        [TestInitialize]
        public void Init()
        {
            repo = ProdutoRepo.Instance;
            repo.Carregar();
            try
            {
                produtoTeste = repo.Obter(CODIGO_TESTE);
                repo.Excluir(produtoTeste.Id);
                repo.Carregar();
            }
            catch (MiseException)
            {
            }

            vendaRepo = VendaRepo.Instance;
            if (!repo.PossuiCodigo(CODIGO_VINCULADO))
            {
                //inclui produto vinculado para teste
                produtoComVenda = new Produto(CODIGO_VINCULADO, "PRODUTO VINCULADO", 3.50m, "UN");
                produtoComVenda.Descricao = "PRODUTO VINCULADO A VENDA";
                repo.Incluir(produtoComVenda);
                repo.Carregar();

                Venda v = Venda.Iniciar(repo);
                v.AdicionarItem(CODIGO_VINCULADO);
                v.Pagar(produtoComVenda.PrecoVenda, FormaPagamentoRepo.Instance.Obter(1));
                v.Concluir();
                vendaRepo.Incluir(v);
            }
            else
            {
                produtoComVenda = repo.Obter(CODIGO_VINCULADO);
            }

            if (fornecedor == null)
            {
                fornecedor = FornecedorRepo.Instance.Obter(1);
            }
            if (grupo == null)
            {
                grupo = GrupoRepo.Instance.Obter(1);
            }
            if (diverso == null)
                diverso = repo.Obter(Produto.DIVERSOS);
            if (produtoComGrupoEFornecedor == null)
            {
                if (!repo.PossuiCodigo(90000000001))
                {
                    produtoComGrupoEFornecedor = new Produto();
                    produtoComGrupoEFornecedor.Codigo = 90000000001;
                    produtoComGrupoEFornecedor.Nome = "TEM GRUPO E FORNE";
                    produtoComGrupoEFornecedor.Descricao = "TEM GRUPO E FORNECEDOR MESMO";
                    produtoComGrupoEFornecedor.PrecoVenda = 0.5m;
                    produtoComGrupoEFornecedor.UnidadeMedida = "UN";
                    produtoComGrupoEFornecedor.Grupo = grupo;
                    produtoComGrupoEFornecedor.Fornecedor = fornecedor;
                    repo.Incluir(produtoComGrupoEFornecedor);
                }
            }

            // tem que ser o ultimo comando do metodo
            repo.Carregar();
        }

        [TestMethod]
        public void Instance()
        {
            repo = ProdutoRepo.Instance;

            Assert.IsNotNull(repo);
        }

        [TestMethod]
        public void ListarPorNome_Erro_NaoAchou()
        {
            repo = ProdutoRepo.Instance;
            List<Produto> lista = repo.Listar("SDOIUAPDUP");
            Assert.AreEqual(0, lista.Count);
        }

        [TestMethod]
        public void ListarPorNome_Ok()
        {
            repo = ProdutoRepo.Instance;
            List<Produto> lista = repo.Listar("KIT");
            foreach (var p in lista)
            {
                Assert.IsTrue(p.Nome.Contains("KIT"));
            }
        }

        [TestMethod]
        public void Incluir_Erro_CodigoNaoPreenchido()
        {
            repo = ProdutoRepo.Instance;
            Produto p = new Produto();

            try
            {
                repo.Incluir(p);
                Assert.Fail();
            }
            catch (MiseException)
            {
                
            }
            
        }

        [TestMethod]
        public void Incluir_Erro_NomeNaoPreenchido()
        {
            repo = ProdutoRepo.Instance;
            Produto p = new Produto();
            p.Codigo = CODIGO_TESTE;

            try
            {
                repo.Incluir(p);
                Assert.Fail();
            }
            catch (MiseException)
            {
            }

        }

        [TestMethod]
        public void Incluir_Erro_PrecoVendaNaoPreenchido()
        {
            repo = ProdutoRepo.Instance;
            Produto p = new Produto();
            p.Codigo = CODIGO_TESTE;
            p.Nome = "MANTEIGA GHEE";

            try
            {
                repo.Incluir(p);
                Assert.Fail();
            }
            catch (MiseException)
            {
            }
        }

        [TestMethod]
        public void Incluir_Erro_UnMedidaNaoPreenchido()
        {
            repo = ProdutoRepo.Instance;
            Produto p = new Produto();
            p.Codigo = CODIGO_TESTE;
            p.Nome = "MANTEIGA GHEE";
            p.PrecoVenda = 5.60m;

            try
            {
                repo.Incluir(p);
                Assert.Fail();
            }
            catch (MiseException)
            {
            }
        }

        [TestMethod]
        public void Incluir_Erro_UnDescricaoNaoPreenchida()
        {
            repo = ProdutoRepo.Instance;
            Produto p = new Produto();
            p.Codigo = CODIGO_TESTE;
            p.Nome = "MANTEIGA GHEE";
            p.PrecoVenda = 5.60m;
            p.UnidadeMedida = "UN";
            
            try
            {
                repo.Incluir(p);
                Assert.Fail();
            }
            catch (MiseException)
            {
            }
        }

        [TestMethod]
        public void Incluir_Ok()
        {
            repo = ProdutoRepo.Instance;
            Produto p = new Produto();
            p.Codigo = CODIGO_TESTE;
            p.Nome = "MANTEIGA GHEE";
            p.PrecoVenda = 5.60m;
            p.UnidadeMedida = "UN";
            p.Descricao = "MANTEIGA GHEE GRASS FED";

            Produto incluido = repo.Incluir(p);

            Assert.IsNotNull(incluido.Id);
        }

        [TestMethod]
        public void Incluir_Ok_CompletoComVinculos()
        {
            repo = ProdutoRepo.Instance;
            Produto p = new Produto();
            p.Codigo = CODIGO_TESTE;
            p.Nome = "MANTEIGA GHEE";
            p.PrecoVenda = 5.60m;
            p.UnidadeMedida = "UN";
            p.Descricao = "MANTEIGA GHEE GRASS FED";
            p.PrecoCusto = 4.50m;
            p.Grupo = grupo;
            p.Fornecedor = fornecedor;

            Assert.IsNotNull(repo.Incluir(p).Id);
            repo.Carregar();

            Produto incluido = repo.Obter(CODIGO_TESTE);
            Assert.AreEqual("MANTEIGA GHEE", incluido.Nome);
            Assert.AreEqual(5.60m, incluido.PrecoVenda);
            Assert.AreEqual("UN", incluido.UnidadeMedida);
            Assert.AreEqual("MANTEIGA GHEE GRASS FED", incluido.Descricao);
            Assert.AreEqual(4.5m, incluido.PrecoCusto);
            Assert.AreEqual(grupo, incluido.Grupo);
            Assert.AreEqual(fornecedor, incluido.Fornecedor);
        }

        [TestMethod]
        public void Incluir_Erro_JaExistente()
        {
            repo = ProdutoRepo.Instance;
            Produto p = new Produto();
            p.Codigo = CODIGO_TESTE;
            p.Nome = "MANTEIGA GHEE";
            p.PrecoVenda = 5.60m;
            p.UnidadeMedida = "UN";
            p.Descricao = "MANTEIGA GHEE GRASS FED";

            Produto incluido = repo.Incluir(p);
            Assert.IsNotNull(incluido.Id);
            repo.Carregar();
            try
            {
                repo.Incluir(p);
                Assert.Fail("Não pode deixar incluir com mesmo codigo!");
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
                Assert.Fail("Id não informado!");
            }
            catch (MiseException)
            {
            }
        }

        [TestMethod]
        public void Excluir_Erro_NaoPodeExcluirDiverso()
        {
            try
            {
                repo.Excluir(diverso.Id);
                Assert.Fail("Não pode excluir DIVERSO!");
            }
            catch (MiseException)
            {
            }
        }

        [TestMethod]
        public void Excluir_Erro_ProdutoVinculadoAItem()
        {
            try
            {
                repo.Excluir(produtoComVenda.Id);
                Assert.Fail("Não pode excluir produto vinculado a venda!");
            }
            catch (MiseException)
            {
            }
            
            Assert.IsTrue(repo.PossuiCodigo(CODIGO_VINCULADO));
        }

        [TestMethod]
        public void Excluir_Ok()
        {
            Produto p = new Produto();
            p.Codigo = CODIGO_TESTE;
            p.Nome = "MANTEIGA GHEE";
            p.PrecoVenda = 5.60m;
            p.UnidadeMedida = "UN";
            p.Descricao = "MANTEIGA GHEE GRASS FED";

            Produto incluido = repo.Incluir(p);
            Assert.IsNotNull(incluido.Id);
            repo.Carregar();
            repo.Excluir(incluido.Id);
            repo.Carregar();

            Assert.IsFalse(repo.PossuiCodigo(CODIGO_TESTE));
        }

        [TestMethod]
        public void Alterar_Erro_IdObrigatorio()
        {
            Produto p = new Produto();
            p.Codigo = CODIGO_TESTE;
            p.Nome = "MANTEIGA GHEE";
            p.PrecoVenda = 5.60m;
            p.UnidadeMedida = "UN";
            p.Descricao = "MANTEIGA GHEE GRASS FED";

            Produto incluido = repo.Incluir(p);
            repo.Carregar();
            incluido.Id = 0;

            try
            {
                repo.Alterar(incluido);
                Assert.Fail("Id não informado!");
            }
            catch (MiseException)
            {
            }
        }

        [TestMethod]
        public void Alterar_Erro_CodigoObrigatorio()
        {
            Produto p = new Produto();
            p.Codigo = CODIGO_TESTE;
            p.Nome = "MANTEIGA GHEE";
            p.PrecoVenda = 5.60m;
            p.UnidadeMedida = "UN";
            p.Descricao = "MANTEIGA GHEE GRASS FED";

            Produto incluido = repo.Incluir(p);
            Assert.IsNotNull(incluido.Id);
            repo.Carregar();
            incluido.Codigo = 0;

            try
            {
                repo.Alterar(incluido);
                Assert.Fail("Código não informado!");
            }
            catch (MiseException)
            {   
            }
        }

        [TestMethod]
        public void Alterar_Erro_NomeObrigatorio()
        {
            Produto p = new Produto();
            p.Codigo = CODIGO_TESTE;
            p.Nome = "MANTEIGA GHEE";
            p.PrecoVenda = 5.60m;
            p.UnidadeMedida = "UN";
            p.Descricao = "MANTEIGA GHEE GRASS FED";

            Produto incluido = repo.Incluir(p);
            Assert.IsNotNull(incluido.Id);
            repo.Carregar();
            incluido.Nome = null;

            try
            {
                repo.Alterar(incluido);
                Assert.Fail("Nome não informado!");
            }
            catch (MiseException)
            {
            }
        }

        [TestMethod]
        public void Alterar_Erro_PrecoVendaObrigatorio()
        {
            Produto p = new Produto();
            p.Codigo = CODIGO_TESTE;
            p.Nome = "MANTEIGA GHEE";
            p.PrecoVenda = 5.60m;
            p.UnidadeMedida = "UN";
            p.Descricao = "MANTEIGA GHEE GRASS FED";

            Produto incluido = repo.Incluir(p);
            Assert.IsNotNull(incluido.Id);
            repo.Carregar();
            incluido.PrecoVenda = 0;

            try
            {
                repo.Alterar(incluido);
                Assert.Fail("Preço de venda não informado!");
            }
            catch (MiseException)
            {
            }
        }

        [TestMethod]
        public void Alterar_Erro_UnidadeMedidaObrigatorio()
        {
            Produto p = new Produto();
            p.Codigo = CODIGO_TESTE;
            p.Nome = "MANTEIGA GHEE";
            p.PrecoVenda = 5.60m;
            p.UnidadeMedida = "UN";
            p.Descricao = "MANTEIGA GHEE GRASS FED";

            Produto incluido = repo.Incluir(p);
            Assert.IsNotNull(incluido.Id);
            repo.Carregar();
            incluido.UnidadeMedida = null;

            try
            {
                repo.Alterar(incluido);
                Assert.Fail("Unidade de medida não informada!");
            }
            catch (MiseException)
            {
            }
        }

        [TestMethod]
        public void Alterar_Erro_DescricaoObrigatorio()
        {
            Produto p = new Produto();
            p.Codigo = CODIGO_TESTE;
            p.Nome = "MANTEIGA GHEE";
            p.PrecoVenda = 5.60m;
            p.UnidadeMedida = "UN";
            p.Descricao = "MANTEIGA GHEE GRASS FED";

            Produto incluido = repo.Incluir(p);
            Assert.IsNotNull(incluido.Id);
            repo.Carregar();
            incluido.Descricao = null;

            try
            {
                repo.Alterar(incluido);
                Assert.Fail("Descrição não informada!");
            }
            catch (MiseException)
            {
            }
        }

        [TestMethod]
        public void Alterar_Erro_DiversoComPrecoVenda()
        {
            diverso.PrecoVenda = 5.00m;
            try
            {
                repo.Alterar(diverso);
                Assert.Fail("Diverso não pode ter precoVenda!");
            }
            catch (MiseException)
            {
            }
        }

        [TestMethod]
        public void Alterar_Erro_DiversoComPrecoCusto()
        {
            diverso.PrecoCusto = 5.00m;
            try
            {
                repo.Alterar(diverso);
                Assert.Fail("Diverso não pode ter precoVenda!");
            }
            catch (MiseException)
            {
            }
        }

        [TestMethod]
        public void Alterar_Ok()
        {
            Produto p = new Produto();
            p.Codigo = CODIGO_TESTE;
            p.Nome = "MANTEIGA GHEE";
            p.PrecoVenda = 5.60m;
            p.UnidadeMedida = "UN";
            p.Descricao = "MANTEIGA GHEE GRASS FED";

            Produto incluido = repo.Incluir(p);
            Assert.IsNotNull(incluido.Id);
            repo.Carregar();

            try
            {
                Produto trash = repo.Obter(12345678);
                repo.Excluir(trash.Id);
                repo.Carregar();
            }
            catch (MiseException)
            {
            }

            incluido.Codigo = 12345678;
            incluido.Nome = "MANTEIGA GHEE ALT";
            incluido.PrecoVenda = 6.5m ;
            incluido.UnidadeMedida = "KG";
            incluido.Descricao = "MANTEIGA GHEE GRASS FED ALT";
            incluido.PrecoCusto = 5.99m;
            incluido.Fornecedor = fornecedor;
            incluido.Grupo = grupo;

            repo.Alterar(incluido);

            repo.Carregar();

            Produto alterado = repo.Obter(12345678);
            Assert.AreEqual(12345678, alterado.Codigo);
            Assert.AreEqual("MANTEIGA GHEE ALT", alterado.Nome);
            Assert.AreEqual(6.5m, alterado.PrecoVenda);
            Assert.AreEqual("KG", alterado.UnidadeMedida);
            Assert.AreEqual("MANTEIGA GHEE GRASS FED ALT", alterado.Descricao);
            Assert.AreEqual(5.99m, alterado.PrecoCusto);
            Assert.AreEqual(fornecedor, alterado.Fornecedor);
            Assert.AreEqual(grupo, alterado.Grupo);
        }

        [TestMethod]
        public void TemProdutoVinculadoAGrupo_true()
        {
            Assert.IsTrue(repo.TemProdutoVinculadoAGrupo(grupo.Id));
        }

        [TestMethod]
        public void TemProdutoVinculadoAGrupo_false()
        {
            Assert.IsFalse(repo.TemProdutoVinculadoAGrupo(int.MaxValue));
        }

        [TestMethod]
        public void TemProdutoVinculadoAFornecedor_true()
        {
            Assert.IsTrue(repo.TemProdutoVinculadoAFornecedor(fornecedor.Id));
        }

        [TestMethod]
        public void TemProdutoVinculadoAFornecedor_false()
        {
            Assert.IsFalse(repo.TemProdutoVinculadoAFornecedor(long.MaxValue));
        }
    }
}
