using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Threading;
using System.Collections.Concurrent;
using mise.exception;

namespace mise.model
{
    public class ProdutoRepo : SuperDAO, ICatalogo
    {
        private ConcurrentDictionary<long, Produto> _produtos = new ConcurrentDictionary<long, Produto>();

        private VendaRepo _vendaRepo = VendaRepo.Instance;

        public EventHandler Changed;

        private ProdutoRepo() : base() {
            Carregar();
        }

        private static ProdutoRepo _INSTANCE;

        public static ProdutoRepo Instance {
            get {
                if (_INSTANCE == null)
                    _INSTANCE = new ProdutoRepo();
                return _INSTANCE;
            }
        }

        public Produto Obter(long codigo)
        {
            Produto p = null;
            if (!_produtos.TryGetValue(codigo, out p))
                throw new MiseException("Código inexistente: " + codigo);
            return p;
        }

        // chamar isso sempre dentro de outro metodo!
        public bool PossuiCodigo(long codigo)
        {
            return _produtos.ContainsKey(codigo);
        }

        private bool Existe(long codigo)
        {
            return _produtos.ContainsKey(codigo);
        }

        public Produto Incluir(Produto p)
        {
            validarObrigatorios(p);

            if (Existe(p.Codigo))
            {
                throw new MiseException("Código já cadastrado:" + p.Codigo);
            }
            using (SqlConnection conn = new SqlConnection(CONN))
            {
                conn.Open();


                SqlCommand cmd = new SqlCommand("insert into Produto(codigo, nome, preco_venda, preco_custo, un_medida, descricao, id_grupo, id_fornecedor) "+
                    "output inserted.id " +
                    "values(@codigo, @nome, @precoVenda, @precoCusto, @unMedida, @descricao, @idGrupo, @idFornecedor)", conn);

                cmd.Parameters.Add("@codigo", SqlDbType.BigInt).Value = p.Codigo;
                cmd.Parameters.Add("@nome", SqlDbType.VarChar).Value = p.Nome;
                cmd.Parameters.Add("@precoVenda", SqlDbType.Decimal).Value = p.PrecoVenda;
                cmd.Parameters.Add("@precoCusto", SqlDbType.Decimal).Value = p.PrecoCusto;
                cmd.Parameters.Add("@unMedida", SqlDbType.VarChar).Value = p.UnidadeMedida;
                cmd.Parameters.Add("@descricao", SqlDbType.VarChar).Value = p.Descricao;

                cmd.Parameters.Add("@idFornecedor", SqlDbType.BigInt).Value = p.Fornecedor != null ? (object) p.Fornecedor.Id : DBNull.Value;
                cmd.Parameters.Add("@idGrupo", SqlDbType.Int).Value = p.Grupo != null ? (object) p.Grupo.Id : DBNull.Value;

                long id = (long)cmd.ExecuteScalar();
                p.Id = id;
            
            }

            Thread t = new Thread(Carregar);
            t.Start();

            return p;
        }

        public void Alterar(Produto p)
        {
            if (p.Id == 0)
                throw new MiseException("Id não informado!");
            validarObrigatorios(p);

            using (SqlConnection conn = new SqlConnection(CONN))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(
                    "update produto set " +
                    "codigo = @codigo, " +
                    "nome = @nome, " +
                    "preco_venda = @precoVenda, " +
                    "preco_custo = @precoCusto, " +
                    "un_medida = @unMedida, " +
                    "descricao = @descricao, " +
                    "id_grupo = @idGrupo, " +
                    "id_fornecedor = @idFornecedor " + 
                    "where id = @id", conn);

                cmd.Parameters.Add("@id", SqlDbType.BigInt).Value = p.Id;
                cmd.Parameters.Add("@codigo", SqlDbType.BigInt).Value = p.Codigo;
                cmd.Parameters.Add("@nome", SqlDbType.VarChar).Value = p.Nome;
                cmd.Parameters.Add("@precoVenda", SqlDbType.Decimal).Value = p.PrecoVenda;
                cmd.Parameters.Add("@precoCusto", SqlDbType.Decimal).Value = p.PrecoCusto;
                cmd.Parameters.Add("@unMedida", SqlDbType.VarChar).Value = p.UnidadeMedida;
                cmd.Parameters.Add("@descricao", SqlDbType.VarChar).Value = p.Descricao;

                cmd.Parameters.Add("@idFornecedor", SqlDbType.BigInt).Value = p.Fornecedor != null ? (object)p.Fornecedor.Id : DBNull.Value;
                cmd.Parameters.Add("@idGrupo", SqlDbType.Int).Value = p.Grupo != null ? (object)p.Grupo.Id : DBNull.Value;

                cmd.ExecuteNonQuery();
            }

            Thread t = new Thread(Carregar);
            t.Start();
        }

        private void validarObrigatorios(Produto p)
        {
            if (p.Codigo == 0)
                throw new MiseException("Código não informado!");

            if (p.Nome == null || p.Nome.Equals(""))
                throw new MiseException("Nome não informado!");

            if (p.Descricao == null || p.Descricao.Equals(""))
                throw new MiseException("Descrição não informada!");

            if (p.Codigo == Produto.DIVERSOS)
            {
                if (p.PrecoVenda > 0)
                    throw new MiseException("DIVERSO não pode ter preço de venda!");
                if (p.PrecoCusto > 0)
                    throw new MiseException("DIVERSO não pode ter preço de custo!");
            }
            else
            {
                if (p.PrecoVenda == 0)
                    throw new MiseException("Preço de Venda não informado!");
            }

            if (p.UnidadeMedida == null || p.UnidadeMedida.Equals(""))
                throw new MiseException("Unidade de Medida não informada!");

        }

        public List<Produto> Listar()
        {
            if (_produtos.Count == 0)
            {
                Carregar();
            }

            return (from p in _produtos
                    orderby p.Value.Codigo
                    select p.Value).ToList();
        }

        public List<Produto> Listar(string nome)
        {
            if (_produtos.Count == 0)
            {
                Carregar();
            }

            return (from p in _produtos
                    where (nome == null || nome.Length == 0 || p.Value.Nome.ToLower().Contains(nome.ToLower()))
                    orderby p.Value.Codigo
                    select p.Value).ToList();
        }

        public void Carregar()
        {
            _produtos.Clear();
            using (SqlConnection conn = new SqlConnection(CONN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    SqlDataReader reader;

                    string sql =
                        "select p.id, p.codigo, p.nome, p.preco_venda, p.preco_custo, p.un_medida, p.descricao, " +
                        "f.id, f.nome_fantasia, " +
                        "g.id, g.nome " +
                        "from Produto p " +
                        "left join Fornecedor f on f.id = p.id_fornecedor " +
                        "left join Grupo g on g.id = p.id_grupo " +
                        "where 1 = 1 "
                        ;

                    cmd.CommandText = sql;
                    cmd.CommandTimeout = 90;
                    cmd.CommandType = CommandType.Text;
                
                    cmd.Connection = conn;
                    conn.Open();

                    reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {

                            Fornecedor f = null;
                            long codFornededor = readLong(reader, 7);
                            if (codFornededor != 0)
                            {
                                f = new Fornecedor(codFornededor, readStr(reader, 8));
                            }
                            Grupo g = null;
                            int codGrupo = readInt(reader, 9);
                            if (codGrupo != 0)
                            {
                                g = new Grupo(codGrupo, readStr(reader, 10));
                            }
                            Produto p = new Produto(
                                readLong(reader, 0),
                                readLong(reader, 1),
                                readStr(reader, 2),
                                readDecimal(reader, 3),
                                readStr(reader, 5),
                                readDecimal(reader, 4),
                                readStr(reader, 6),
                                f,
                                g,
                                false
                            );
                            _produtos.TryAdd(p.Codigo, p);
                        }
                    }
                }
                catch (Exception e)
                {
                    throw new MiseException(e.Message, e);
                }
            }


            OnChanged(EventArgs.Empty);
            
        }

        public void Excluir(long id)
        {
            if (id == 0)
            {
                throw new MiseException("Id não fornecido!");
            }

            if (_vendaRepo.TemItemVinculadoAProduto(id))
                throw new MiseException("Produto não pode ser excluído, pois possui vínculo com Venda(s).");

            
            using (SqlConnection conn = new SqlConnection(CONN))
            {
                conn.Open();

                if (ehDiversos(id, conn))
                    throw new MiseException("DIVERSO não pode ser excluído!");

                SqlCommand cmd = new SqlCommand(
                    "delete from produto " +
                    "where id = @id", conn);

                cmd.Parameters.Add("@id", SqlDbType.BigInt).Value = id;
                cmd.ExecuteNonQuery();
            }

            Thread t = new Thread(Carregar);
            t.Start();
        }

        private bool ehDiversos(long id, SqlConnection conn)
        {
            int count = (from p in _produtos
                    where (p.Value.Id == id && p.Value.IsDiverso)
                    select p.Value).Count();
            return count > 0;
        }

        public bool TemProdutoVinculadoAGrupo(int idGrupo)
        {
            return (from p in _produtos 
                    where (p.Value.Grupo != null && idGrupo.Equals(p.Value.Grupo.Id)) select p.Value).Count() > 0;
        }

        public bool TemProdutoVinculadoAFornecedor(long idFornecedor)
        {
            return (from p in _produtos
                    where (p.Value.Fornecedor != null && idFornecedor.Equals(p.Value.Fornecedor.Id))
                    select p.Value).Count() > 0;
        }

        protected virtual void OnChanged(EventArgs e)
        {
            if (Changed != null)
                Changed(this, e);
        }

    }

}
