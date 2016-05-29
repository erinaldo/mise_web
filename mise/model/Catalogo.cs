using mise.exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mise.model
{
    public class CatalogoMap : ICatalogo
    {
        private static CatalogoMap instance;

        private Dictionary<long, Produto> produtosPorCodInterno = new Dictionary<long, Produto>();

        public static CatalogoMap Instance()
        {
            if (instance == null)
            {
                instance = new CatalogoMap();
            }
            return new CatalogoMap();
        }

        public Produto Incluir(Produto p)
        {
            if (produtosPorCodInterno.ContainsKey(p.Codigo))
                throw new MiseException("Código " + p.Codigo + " já cadastrado.");
            
            produtosPorCodInterno.Add(p.Codigo, p);
            return p;
        }

        public bool PossuiCodigo(long codigo)
        {
            return produtosPorCodInterno.ContainsKey(codigo);
        }

        public Produto Obter(long codigo)
        {
            Produto p = null;
            if (!produtosPorCodInterno.TryGetValue(codigo, out p))
            {
                throw new MiseException("Código não encontrado: " + codigo);
            }

            return p;
        }


        public void Excluir(long p)
        {
            Produto produto = null;
            if (produtosPorCodInterno.TryGetValue(p, out produto))
            {
                produtosPorCodInterno.Remove(produto.Codigo);
            }
            
        }

        public void Limpar()
        {
            produtosPorCodInterno.Clear();
        }


        public List<Produto> Listar(string nome)
        {
            throw new NotImplementedException();
        }


        public void Alterar(Produto p)
        {
            throw new NotImplementedException();
        }
    }
}
