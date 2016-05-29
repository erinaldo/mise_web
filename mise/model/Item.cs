using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mise.model
{
    public class Item
    {
        private int _sequencial;
        private Produto _produto;
        private decimal _qtd;
        private decimal _preco;
        private bool _cancelado = false;

        public Item(int sequencial, Produto produto, decimal qtd, decimal preco)
        {
            _sequencial = sequencial;
            _produto = produto;
            _qtd = qtd;
            _preco = preco;
        }

        public Item(int sequencial, Produto produto, decimal qtd)
            : this(sequencial, produto, qtd, produto.PrecoVenda)
        {
        }

        public Item(int sequencial, Produto produto)
            : this(sequencial, produto, 1)
        {
        }

        public int Sequencial
        {
            get { return _sequencial; }
        }

        public string NomeProduto
        {
            get { return _produto.Nome; }
        }

        public decimal Total { 
            get { return Decimal.Round(_preco * _qtd, 2); } 
        }

        public decimal PrecoUni { 
            get { return _preco; }
            set { _preco = value; }
        }

        public decimal Qtd
        {
            get { return _qtd; }
            set { _qtd = value; }
        }

        public long Codigo {
            get { return _produto.Codigo; }
        }

        public bool Cancelado
        { 
            get { return _cancelado; }
        }

        public void Cancelar()
        {
            _cancelado = true;
        }

        public Produto Produto { get { return _produto; } }

        public override int GetHashCode()
        {
            string hash = "" + _sequencial + _qtd + _preco + _produto.Codigo;
            return Convert.ToInt32(hash);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Item))
                return false;
            Item other = obj as Item;
            return _sequencial == other._sequencial && 
                _qtd == other._qtd && 
                _preco == other._preco &&
                _produto.Equals(other._produto);
        }
    }
}
