using mise.exception;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mise.model
{
    public class FornecedorRepo : SuperDAO
    {
        private ConcurrentDictionary<long, Fornecedor> _fornecedores = new ConcurrentDictionary<long, Fornecedor>();
        private static FornecedorRepo _INSTANCE;
        public EventHandler Changed;

        private FornecedorRepo() : base() {
            Carregar();
        }
        
        public static FornecedorRepo Instance {
            get
            {
                if (_INSTANCE == null)
                    _INSTANCE = new FornecedorRepo();

                return _INSTANCE;
            }
        }

        public List<Fornecedor> ListarTodos()
        {
            if (_fornecedores.Count == 0)
            {
                Carregar();
            }

            return (from f in _fornecedores
                    orderby f.Value.NomeFantasia
                    select f.Value).ToList();
        }

        public void Carregar()
        {
            ListarDB(null);
            OnChanged(EventArgs.Empty);
        }

        private void ListarDB(string nomeFantasia)
        {
            _fornecedores.Clear();
            using (SqlConnection conn = new SqlConnection(CONN))
            {
                SqlCommand cmd = new SqlCommand();
                SqlDataReader reader;

                string sql = "select * from Fornecedor where 1 = 1 ";

                if (nomeFantasia != null && nomeFantasia.Length > 0)
                {
                    sql += "and nome_fantasia like @nomeFantasia ";
                }

                cmd.CommandText = sql;
                cmd.CommandType = CommandType.Text;

                if (nomeFantasia != null && nomeFantasia.Length > 0)
                {
                    cmd.Parameters.Add("@nomeFantasia", SqlDbType.VarChar).Value = "%" + nomeFantasia + "%";
                }

                cmd.Connection = conn;
                conn.Open();

                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Fornecedor f = new Fornecedor(
                            readLong(reader, 0),
                            readStr(reader, 2),
                            readStr(reader, 1),
                            readStr(reader, 4),
                            readStr(reader, 3),
                            readStr(reader, 5));

                        _fornecedores.TryAdd(f.Id, f);
                    }
                }
            }
        }

        public Fornecedor Obter(long id)
        {
            if (_fornecedores.Count == 0)
            {
                Carregar();
            }

            Fornecedor f = null;
            _fornecedores.TryGetValue(id, out f);

            return f;
        }

        private Fornecedor ObterDB(long codigo)
        {
            using (SqlConnection conn = new SqlConnection(CONN))
            {
                SqlCommand cmd = new SqlCommand();
                SqlDataReader reader;

                cmd.CommandText = "select * from fornecedor where id = @id";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@id", SqlDbType.BigInt).Value = codigo;

                cmd.Connection = conn;
                conn.Open();

                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Fornecedor f = new Fornecedor(
                            readLong(reader, 0),
                            readStr(reader, 2),
                            readStr(reader, 1),
                            readStr(reader, 4),
                            readStr(reader, 3),
                            readStr(reader, 5));
                        return f;
                    }
                }
            }

            return null;
        }

        public Fornecedor Incluir(Fornecedor f)
        {
            validarObrigatorios(f);
            using (SqlConnection conn = new SqlConnection(CONN))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("insert into Fornecedor(nome_fantasia, razao_social, contato, telefone, outros) " +
                    "output inserted.id " +
                    "values(@nome_fantasia, @razao_social, @contato, @telefone, @outros)", conn);

                cmd.Parameters.Add("@nome_fantasia", SqlDbType.VarChar).Value = f.NomeFantasia;
                cmd.Parameters.Add("@razao_social", SqlDbType.VarChar).Value = f.RazaoSocial;
                cmd.Parameters.Add("@contato", SqlDbType.VarChar).Value = f.Contato;
                cmd.Parameters.Add("@telefone", SqlDbType.VarChar).Value = f.Telefone;
                cmd.Parameters.Add("@outros", SqlDbType.VarChar).Value = f.Outros;

                long id = (long)cmd.ExecuteScalar();
                f.Id = id;
            }

            Carregar();

            return f;
        }

        public void Alterar(Fornecedor f)
        {
            validarObrigatorios(f);

            if (f.Id == 0)
            {
                throw new MiseException("Id não fornecido!");
            }
            using (SqlConnection conn = new SqlConnection(CONN))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("update Fornecedor " +
                    "set nome_fantasia = @nomeFantasia, " +
                    "razao_social = @razaoSocial, " +
                    "contato = @contato, " +
                    "telefone = @telefone, " +
                    "outros = @outros " +
                    "where id = @id "
                    , conn);

                cmd.Parameters.Add("@id", SqlDbType.BigInt).Value = f.Id;
                cmd.Parameters.Add("@nomeFantasia", SqlDbType.VarChar).Value = f.NomeFantasia;
                cmd.Parameters.Add("@razaoSocial", SqlDbType.VarChar).Value = f.RazaoSocial;
                cmd.Parameters.Add("@contato", SqlDbType.VarChar).Value = f.Contato;
                cmd.Parameters.Add("@telefone", SqlDbType.VarChar).Value = f.Telefone;
                cmd.Parameters.Add("@outros", SqlDbType.VarChar).Value = f.Outros;

                cmd.ExecuteNonQuery();
            }

            Carregar();
        }

        private void validarObrigatorios(Fornecedor f)
        {
            if (f.NomeFantasia == null || f.NomeFantasia.Length == 0)
            {
                throw new MiseException("Nome Fantasia não informado!");
            }
        }

        public List<Fornecedor> Listar(string nomeFantasia)
        {
            if (_fornecedores.Count == 0)
            {
                Carregar();
            }

            return (from f in _fornecedores
                    where nomeFantasia == null || f.Value.NomeFantasia.ToLower().Contains(nomeFantasia.ToLower())
                    orderby f.Value.NomeFantasia
                    select f.Value).ToList();
        }

        public void Excluir(long id)
        {
            if (id == 0)
                throw new MiseException("Id não fornecido!");

            if (ProdutoRepo.Instance.TemProdutoVinculadoAFornecedor(id))
                throw new MiseException("Fornecedor não pode ser excluído, pois possui vínculo com Produto(s).");

            using (SqlConnection conn = new SqlConnection(CONN))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(
                    "delete from fornecedor " +
                    "where id = @id "
                    , conn);

                cmd.Parameters.Add("@id", SqlDbType.BigInt).Value = id;
                cmd.ExecuteNonQuery();
            }

            Carregar();
        }

        protected virtual void OnChanged(EventArgs e)
        {
            if (Changed != null)
                Changed(this, e);
        }

    }
}
