using mise.exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mise.model
{
    public class Venda
    {
        private long _id;
        private ICatalogo _catalogo;
        private DateTime _data;
        private Situacao _situacao;
        private List<Item> _itens =  new List<Item>();
        private List<Pagamento> _pagamentos = new List<Pagamento>();

        public enum Situacao { Iniciada, Concluida, Cancelada };

        public DateTime Data { 
            get { return _data; }
            set { _data = value; }
        }

        Venda(ICatalogo catalogo, long codigo)
        {
            _id = codigo;
            _data = DateTime.Now;
            _catalogo = catalogo;
            _situacao = Situacao.Iniciada;
        }

        Venda(ICatalogo catalogo) : this(catalogo, 0)
        {

        }

        public Venda(long id, DateTime data)
        {
            _id = id;
            _data = data;
        }

        public static Venda Iniciar(ICatalogo catalogo)
        {
            return new Venda(catalogo);
        }

        public bool Iniciada()
        {
            return true;
        }

        public bool PossuiItem(long codigo)
        {
            foreach (var item in _itens)
            {
                if (codigo.Equals(item.Codigo))
                    return true;
            }
            return false;
        }


        public Item AdicionarItem(long codigo)
        {
            return AdicionarItem(codigo, 1);
        }

        public Item AdicionarItem(long codigo, decimal qtd)
        {
            if (Concluida())
                throw new MiseException("Venda já concluída. Não é possível adicionar itens.");
            Produto p = _catalogo.Obter(codigo);
            if (codigo == Produto.DIVERSOS)
                throw new MiseException("Código do produto corresponde a Diversos. Utilize o método AdicionarItemDiversos.");

            Item i = new Item(_itens.Count + 1, p, qtd);
            _itens.Add(i);
            return i;
        }

        public Item AdicionarItemDiversos(decimal qtd, decimal preco)
        {
            if (Concluida())
                throw new MiseException("Venda já concluída. Não é possível adicionar itens.");
            Produto p = _catalogo.Obter(Produto.DIVERSOS);
            
            Item i = new Item(_itens.Count + 1, p, qtd, preco);
            _itens.Add(i);

            return i;
        }

        public decimal Total {
            get
            {
                decimal total = 0;
                foreach (var item in _itens)
                {
                    if (!item.Cancelado)
                        total += item.Total;
                }

                return Math.Round(total, 2);
            }
        }

        public void CancelarItem(int sequencial)
        {
            if (Concluida())
                throw new MiseException("Venda Concluída! Não é possível cancelar itens!");
            if (sequencial < 1 || sequencial > _itens.Count)
                throw new MiseException("Item não existente: " + sequencial);

            _itens[sequencial - 1].Cancelar();
        }

        public List<Item> Itens
        {
            get { return _itens; }
            set { _itens = value; }
        }

        public decimal TotalAPagar {
            get {
                decimal aPagar = Math.Round(Total - TotalPago, 2);
                return aPagar > 0 ? aPagar : 0;
            }
        }

        public long Id { 
            get { return _id; }
            set { _id = value; }
        }

        public decimal TotalPago
        {
            get
            {
                decimal pago = 0.0m;

                foreach (var p in _pagamentos)
                {
                    pago += p.Valor;
                }

                return Math.Round(pago, 2);
            }
        }

        public Pagamento Pagar(decimal valor, FormaPagamento formaPagamento)
        {
            if (Itens.Count == 0)
                throw new MiseException("Venda não possui itens!");
            if (valor <= 0)
                throw new MiseException("Valor do pagamento precisa ser maior que 0!");

            decimal aPagar = TotalAPagar;
            if (aPagar <= 0)
                throw new MiseException("Pagamento já efetuado!");

            decimal troco = valor > aPagar ? valor - TotalAPagar : 0;
            Pagamento p = new Pagamento(valor, formaPagamento, troco);
            _pagamentos.Add(p);

            return p;
        }

        public class Pagamento
        {
            private decimal _valor;
            private FormaPagamento _formaPagamento;
            private decimal _troco;

            public Pagamento(decimal valor, FormaPagamento formaPagamento, decimal troco)
            {
                _valor = valor;
                _formaPagamento = formaPagamento;
                _troco = troco;
            }

            public decimal Valor
            {
                get { return _valor;  }
            }

            public FormaPagamento FormaPagamento
            {
                get
                {
                    return _formaPagamento;
                }
            }

            public decimal Troco
            {
                get
                {
                    return _troco;
                }
            }

            public decimal ValorSemTroco
            {
                get
                {
                    return _valor - _troco;
                }
            }

            public override int GetHashCode()
            {
                return Convert.ToInt32("" + _valor + _formaPagamento.Id);
            }

            public override bool Equals(object obj)
            {
                if (obj == null || !(obj is Pagamento))
                    return false;
                Pagamento other = obj as Pagamento;

                return ValorSemTroco == other.ValorSemTroco && _formaPagamento.Equals(other._formaPagamento);
            }
        }

        public void Concluir()
        {
            if (_itens.Count == 0)
                throw new MiseException("Venda não pode ser concluída, pois não possui nenhum item!");

            if (TotalAPagar > 0)
                throw new MiseException("Venda não pode ser concluída, pois ainda há saldo a pagar!");

            _situacao = Situacao.Concluida;
        }

        public bool Concluida()
        {
            return _situacao.Equals(Situacao.Concluida);
        }

        public void Cancelar()
        {
            if (Concluida())
                throw new MiseException("Venda já concluída! Não pode ser cancelada!");
            _situacao = Situacao.Cancelada;
        }

        public bool Cancelada()
        {
            return _situacao.Equals(Situacao.Cancelada);
        }

        public decimal Troco {
            get
            {
                return _pagamentos.Count > 0 ? _pagamentos[_pagamentos.Count - 1].Troco : 0.0m;
            } 
        }

        public List<Pagamento> Pagamentos
        {
            get { return _pagamentos; }
            set { _pagamentos = value; }
        }

        public void CancelarPagamento()
        {
            _pagamentos.Clear();
        }

        public override int GetHashCode()
        {
            return _id.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return obj != null && obj is Venda && ((Venda)obj)._id == this._id;
        }
    }
}
