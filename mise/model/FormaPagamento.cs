using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mise.model
{
    public class FormaPagamento
    {
        private int _id;
        private int _indice;
        private string _nome;
        private char _atalho;

        public const int DINHEIRO = 1;
        
        public FormaPagamento(int id, string nome, int indice)
        {
            _id = id;
            _nome = nome;
            _indice = indice;
        }

        public FormaPagamento() { }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Nome
        {
            get { return _nome; }
            set { _nome = value; }
        }

        public int Indice
        {
            get { return _indice; }
            set { _indice = value; }
        }

        public string DescricaoFmt
        {
            get
            {
                return _indice + " - " + _nome;
            }
        }

        public bool IsDinheiro
        {
            get { return _indice == DINHEIRO; }
        }

        public char Atalho
        {
            get { return _atalho; }
            set { _atalho = value; }
        }

        public override int GetHashCode()
        {
            return _id.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return obj != null && obj is FormaPagamento && ((FormaPagamento)obj)._id == this._id;
        }
    }
}
