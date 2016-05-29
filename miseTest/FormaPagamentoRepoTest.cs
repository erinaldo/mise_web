using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using mise.model;
using mise.exception;
using System.Collections.Generic;
using System.Linq;

namespace miseTest
{
    [TestClass]
    public class FormaPagamentoRepoTest
    {
        private FormaPagamentoRepo repo;
        private FormaPagamento dinheiro;
        
        [TestInitialize]
        public void Init()
        {
            repo = FormaPagamentoRepo.Instance;
            if (dinheiro == null)
            {
                dinheiro = repo.Listar().Find(z => z.IsDinheiro);
            }
        }

        [TestMethod]
        public void Incluir_Ok()
        {
            FormaPagamento f = new FormaPagamento();
            f.Nome = "CASH";

            f = repo.Incluir(f);
            Assert.IsNotNull(f.Id);
            Assert.IsNotNull(f.Indice);
        }

        [TestMethod]
        public void Incluir_Erro_DescricaoNaoPreenchida()
        {
            FormaPagamento f = new FormaPagamento();
            f.Nome = null;

            try
            {
                f = repo.Incluir(f);
                Assert.Fail("Não pode incluir com descricao null!");
            }
            catch (MiseException)
            {

            }
        }

        [TestMethod]
        public void Incluir_Erro_DescricaoNaoPreenchida2()
        {
            FormaPagamento f = new FormaPagamento();
            f.Nome = "";

            try
            {
                f = repo.Incluir(f);
                Assert.Fail("Não pode incluir com descricao ''!");
            }
            catch (MiseException)
            {
                
            }
        }

        [TestMethod]
        public void Obter_Ok()
        {
            FormaPagamento f = new FormaPagamento();
            f.Nome = "CASH";

            f = repo.Incluir(f);
            repo.Carregar();

            FormaPagamento banco = repo.Obter(f.Id);
            Assert.AreEqual(f.Nome, banco.Nome);
        }

        [TestMethod]
        public void Listar_Ok()
        {
            FormaPagamento f = new FormaPagamento();
            f.Nome = "CASH";

            f = repo.Incluir(f);
            repo.Carregar();

            Assert.IsTrue(repo.Listar().Contains(f));
        }

        [TestMethod]
        public void Alterar_Erro_IdNaoInformado()
        {
            FormaPagamento f = new FormaPagamento();
            f.Nome = "CASH";

            f = repo.Incluir(f);
            repo.Carregar();

            FormaPagamento alterado = repo.Obter(f.Id);
            alterado.Id = 0;
            alterado.Nome = "CASH alt";
            try
            {
                repo.Alterar(alterado);
                Assert.Fail("Id é obrigatório!");
            }
            catch (MiseException)
            {   
            }

        }

        [TestMethod]
        public void Alterar_Erro_DescricaoNaoInformada()
        {
            FormaPagamento f = new FormaPagamento();
            f.Nome = "CASH";

            f = repo.Incluir(f);
            repo.Carregar();

            FormaPagamento alterado = repo.Obter(f.Id);
            alterado.Nome = null;
            try
            {
                repo.Alterar(alterado);
                Assert.Fail("Descrição é obrigatória!");
            }
            catch (MiseException)
            {
            }

        }

        [TestMethod]
        public void Alterar_Erro_DescricaoNaoInformada2()
        {
            FormaPagamento f = new FormaPagamento();
            f.Nome = "CASH";

            f = repo.Incluir(f);
            repo.Carregar();

            FormaPagamento alterado = repo.Obter(f.Id);
            alterado.Nome = "";
            try
            {
                repo.Alterar(alterado);
                Assert.Fail("Descrição é obrigatória!");
            }
            catch (MiseException)
            {
            }

        }

        [TestMethod]
        public void Alterar_Ok()
        {
            FormaPagamento f = new FormaPagamento();
            f.Nome = "CASH";

            f = repo.Incluir(f);
            repo.Carregar();

            FormaPagamento alterado = repo.Obter(f.Id);
            alterado.Nome = "CASH alt";
            repo.Alterar(alterado);

            FormaPagamento banco = repo.Obter(f.Id);
            Assert.AreEqual(alterado.Nome, banco.Nome);
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
        public void Excluir_Erro_Dinheiro()
        {
            try
            {
                repo.Excluir(dinheiro.Id);
                Assert.Fail("Não pode excluir DINHEIRO!");
            }
            catch (MiseException)
            {
            }
        }

        [TestMethod]
        public void Excluir_Erro_PagamentoVinculado()
        {
            FormaPagamento f = new FormaPagamento();
            f.Nome = "OKANE";
            repo.Incluir(f);
            repo.Carregar();

            Venda v = Venda.Iniciar(ProdutoRepo.Instance);
            v.AdicionarItemDiversos(3, 4.50m);
            v.Pagar(v.Total, f);
            VendaRepo.Instance.Incluir(v);

            try
            {
                repo.Excluir(f.Id);
                Assert.Fail("Não pode excluir pois já está vinculada a pagamento!");
            }
            catch (MiseException)
            {
            }
        }

        [TestMethod]
        public void Excluir_Ok()
        {
            FormaPagamento f = new FormaPagamento();
            f.Nome = "CASH";

            f = repo.Incluir(f);
            repo.Carregar();

            repo.Excluir(f.Id);
            repo.Carregar();
            Assert.IsFalse(repo.Listar().Contains(f));
        }

        [TestMethod]
        public void Reordenar_Erro_DinheiroNaoPodeSerReordenado()
        {
            List<FormaPagamento> lista = repo.Listar();
            List<int> ids = lista.Select(e => e.Id).ToList();

            ids.Remove(dinheiro.Id);
            ids.Insert(2, dinheiro.Id);

            try
            {
                repo.Reordenar(ids);
                Assert.Fail("DINHEIRO não pode ser reordenado!");
            }
            catch (MiseException)
            {
            }
        }

        [TestMethod]
        public void Reordenar_Ok()
        {
            List<FormaPagamento> lista = repo.Listar();
            List<int> ids = lista.Select(e => e.Id).ToList();

            // ultimo vai para segundo
            int ultimo = ids[ids.Count - 1];
            ids.Remove(ultimo);
            ids.Insert(1, ultimo);

            // terceiro vai para ultimo
            int terceiro = ids[2];
            ids.Remove(terceiro);
            ids.Insert(ids.Count - 1, terceiro);

            // quarto vai para quinto
            int quarto = ids[3];
            ids.Remove(quarto);
            ids.Insert(4, quarto);

            repo.Reordenar(ids);

            repo.Carregar();
            lista = repo.Listar();

            for (int i = 0; i < lista.Count; i++)
            {
                Assert.AreEqual(ids[i], lista[i].Id);
            }
        }
    }
}
