using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mise;
using mise.model;

namespace miseTest
{
    public class Mock
    {
        public static Produto DIVERSOS = new Produto(1, "Diversos", 0, null);
        public static Produto BANANA_CATURRA = new Produto(2, "Banana Caturra", 2.50m, "KG");
        public static Produto MAMAO_FORMOSA = new Produto(3, "Mamão Formosa", 3.89m, "KG");
        public static Produto MELAO = new Produto(4, "Melão Pingo de Ouro", 5.29m, "KG");
        public static Produto MORANGO = new Produto(5, "Morango", 4.99m, "KG");
        public static Produto KITKAT = new Produto(6, "Kit Kat", 3.99m, "UN");
        public static Produto EBICEN = new Produto(7, "Ebicen", 4.0m, "UN");
        public static Produto MACA_FUJI = new Produto(8, "Maçã Fuji", 4.0m, "KG");

        public static FormaPagamento DINHEIRO = new FormaPagamento(1, "Dinheiro", 1);
        public static FormaPagamento VISA_DEBITO = new FormaPagamento(2, "VISA Débito", 2);
        public static FormaPagamento VISA_CREDITO = new FormaPagamento(3, "VISA Crédito", 3);

        public static CatalogoMap catalogo()
        {
            CatalogoMap catalogo = CatalogoMap.Instance();
            catalogo.Limpar();
            catalogo.Incluir(MACA_FUJI);
            catalogo.Incluir(BANANA_CATURRA);
            catalogo.Incluir(MAMAO_FORMOSA);
            catalogo.Incluir(MELAO);
            catalogo.Incluir(MORANGO);

            catalogo.Incluir(KITKAT);
            catalogo.Incluir(EBICEN);
            catalogo.Incluir(DIVERSOS);

            return catalogo;
        }

        public static List<Venda> vendas()
        {
            List<Venda> vendas = new List<Venda>();

            vendas.Add(venda(new Dictionary<Produto, decimal> () {
                { MACA_FUJI, 1.521m },
                { KITKAT, 3 },
                { BANANA_CATURRA, 1.201m },
                { EBICEN, 1m },
            }, DINHEIRO));

            vendas.Add(venda(new Dictionary<Produto, decimal>() {
                { MACA_FUJI, 1.521m },
                { KITKAT, 3 },
                { BANANA_CATURRA, 1.201m },
                { EBICEN, 1m },
            }, DINHEIRO));

            vendas.Add(venda(new Dictionary<Produto, decimal>() {
                { MAMAO_FORMOSA, 1.233m },
                { KITKAT, 1 },
                { BANANA_CATURRA, 2m }
            }, VISA_CREDITO));

            return vendas;
        }

        public static Venda venda(Dictionary<Produto, decimal> produtos, FormaPagamento formaPagamento)
        {
            Venda v = Venda.Iniciar(catalogo());

            foreach (var item in produtos)
            {
                v.AdicionarItem(item.Key.Codigo, item.Value);
            }

            v.Pagar(v.Total, formaPagamento);
            v.Concluir();

            return v;
        }

    }
}
