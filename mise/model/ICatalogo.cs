using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mise.model
{
    public interface ICatalogo
    {
        Produto Incluir(Produto p);
        void Alterar(Produto p);
        bool PossuiCodigo(long codigo);
        Produto Obter(long codigo);
        void Excluir(long p);
        List<Produto> Listar(string nome);
    }
}
