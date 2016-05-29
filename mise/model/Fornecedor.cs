using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mise.model
{
    public class Fornecedor
    {
        private long _id;
        private string _razaoSocial;
        private string _nomeFantasia;
        private string _telefone;
        private string _contato;
        private string _outros;

        public Fornecedor(long id, string razaoSocial, string nomeFantasia, string telefone, string contato, string outros)
        {
            _id = id;
            _razaoSocial = razaoSocial;
            _nomeFantasia = nomeFantasia;
            _telefone = telefone;
            _contato = contato;
            _outros = outros;
        }

        public Fornecedor(long codigo, string nomeFantasia) : this(codigo, null, nomeFantasia, null, null, null)
        {
            
        }

        public Fornecedor() { }

        public long Id { get { return _id; } set { _id = value; } }
        public string RazaoSocial { get { return _razaoSocial; } set { _razaoSocial = value; } }
        public string NomeFantasia { get { return _nomeFantasia; } set { _nomeFantasia = value; } }
        public string Telefone { get { return _telefone; } set { _telefone = value; } }
        public string Contato { get { return _contato; } set { _contato = value; } }
        public string Outros { get { return _outros; } set { _outros = value; } }

        public override int GetHashCode()
        {
            return _id.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return obj != null && obj is Fornecedor && ((Fornecedor)obj)._id == this._id;
        }
    }
}
