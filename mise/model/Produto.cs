using mise.exception;
using mise.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mise.model
{
    public class Produto
    {
        private long _id;
        private long _codigo;
        private string _nome;
        private decimal _precoVenda;
        private string _unidadeMedida;
        private decimal _precoCusto;
        private string _descricao;
        private Fornecedor _fornecedor;
        private Grupo _grupo;
        
        public const long DIVERSOS = 1;

        public Produto(long id, long codigo, string nome, decimal precoVenda, string unidadeMedida, decimal precoCusto, string descricao, Fornecedor fornecedor, Grupo grupo, bool validar)
        {
            if (validar)
            {
                if (codigo == 0)
                    throw new MiseException("Código do produto não preenchido");
            
                if (nome == null || nome.Equals(""))
                    throw new MiseException("Nome do produto não preenchido");

                if (codigo == DIVERSOS)
                {
                    if (precoVenda != 0)
                        throw new MiseException("Diversos não pode ter preço cadastrado!");
                }
                else
                {
                    if (precoVenda == 0)
                        throw new MiseException("Preço de venda não pode ser 0!");
                }
            }
            this._id = id;
            this._codigo = codigo;
            this._nome = nome;
            this._precoVenda = precoVenda;
            this._precoCusto = precoCusto;
            this._unidadeMedida = unidadeMedida;
            this._descricao = descricao;
            this._fornecedor = fornecedor;
            this._grupo = grupo;
        }

        public Produto(long codigo, string nome, decimal precoVenda, string unidadeMedida, decimal precoCusto, string descricao, Fornecedor fornecedor, Grupo grupo, bool validar) : 
            this(0, codigo, nome, precoVenda, unidadeMedida, precoCusto, descricao,  fornecedor, grupo, true) { }

        public Produto(long codigo, string nome, decimal precoVenda, string unidadeMedida) 
            : this(0, codigo, nome, precoVenda, unidadeMedida, 0, null, null, null, true)
        {
        }

        public Produto(long codigo, string nome, decimal precoVenda, string unidadeMedida, Fornecedor f)
            : this(0, codigo, nome, precoVenda, unidadeMedida, 0, null, f, null, false)
        {

        }

        public Produto() { }

        public long Id { get { return _id; } set { _id = value; } }
        public long Codigo { 
            get { return _codigo; }
            set { _codigo = value; }
        }
        public string Nome { 
            get { return _nome; }
            set { _nome = value; }
        }
        public decimal PrecoVenda { 
            get { return _precoVenda; }
            set { _precoVenda = value; }
        }
        public string UnidadeMedida { 
            get { return _unidadeMedida; }
            set { _unidadeMedida = value; }
        }
        public decimal PrecoCusto { 
            get { return _precoCusto; }
            set { _precoCusto = value; }
        }
        public string Descricao { 
            get { return _descricao; }
            set { _descricao = value; }
        }
        public Fornecedor Fornecedor { 
            get { return _fornecedor; }
            set { _fornecedor = value; }
        }
        public Grupo Grupo { 
            get { return _grupo; }
            set { _grupo = value; }
        }

        public bool IsDiverso
        {
            get { return _codigo == DIVERSOS; }
        }

        public override int GetHashCode()
        {
            return _id.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return obj != null && obj is Produto && ((Produto)obj)._id == this._id;
        }
    }
}
