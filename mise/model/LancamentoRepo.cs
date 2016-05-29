using mise.exception;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mise.model
{
    public class LancamentoRepo : SuperDAO, ILancamentoRepo
    {
        private static LancamentoRepo INSTANCE;
        private LancamentoRepo() : base() { }

        public static LancamentoRepo Instance
        {
            get
            {
                if (INSTANCE == null)
                    INSTANCE = new LancamentoRepo();

                return INSTANCE;
            }
        }

        public Lancamento Incluir(Lancamento l)
        {
            validarObrigatorios(l);

            using (SqlConnection conn = new SqlConnection(CONN))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(
                    "insert into lancamento(descricao, data, valor, id_categoria) " +
                    "output inserted.id " +
                    "values(@descricao, @data, @valor, @id_categoria)", conn);

                cmd.Parameters.Add("@descricao", SqlDbType.VarChar).Value = l.Descricao;
                cmd.Parameters.Add("@data", SqlDbType.Date).Value = l.Data;
                cmd.Parameters.Add("@valor", SqlDbType.Decimal).Value = l.Valor;
                cmd.Parameters.Add("@id_categoria", SqlDbType.Int).Value = l.Categoria.Id;

                long id = (long)cmd.ExecuteScalar();
                l.Id = id;
            }

            return l;
        }

        public Lancamento Alterar(Lancamento l)
        {
            if (l.Id == 0)
                throw new MiseException("Id não informado!");
            validarObrigatorios(l);

            using (SqlConnection conn = new SqlConnection(CONN))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(
                    "update lancamento " +
                    "set descricao = @descricao, " +
                    "data = @data, " +
                    "valor = @valor, " +
                    "id_categoria = @id_categoria " +
                    "where id = @id;", conn);

                cmd.Parameters.Add("@id", SqlDbType.BigInt).Value = l.Id;
                cmd.Parameters.Add("@descricao", SqlDbType.VarChar).Value = l.Descricao;
                cmd.Parameters.Add("@data", SqlDbType.Date).Value = l.Data;
                cmd.Parameters.Add("@valor", SqlDbType.Decimal).Value = l.Valor;
                cmd.Parameters.Add("@id_categoria", SqlDbType.Int).Value = l.Categoria.Id;
                cmd.ExecuteNonQuery();
            }

            return l;
        }

        private void validarObrigatorios(Lancamento l)
        {
            if (l.Data == DateTime.MinValue)
                throw new MiseException("Data não informada!");
            if (l.Categoria == null)
                throw new MiseException("Categoria não informada!");
            if (l.Valor == 0)
                throw new MiseException("Valor não informado!");
            if (l.Descricao == null || l.Descricao == "")
                throw new MiseException("Descrição não informada!");
        }

        public Lancamento Obter(long id)
        {
            Lancamento l = null;

            using (SqlConnection conn = new SqlConnection(CONN))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select * from lancamento where id = @id";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@id", SqlDbType.BigInt).Value = id;

                cmd.Connection = conn;
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            l = new Lancamento();
                            l.Id = readLong(reader, 0);
                            l.Descricao = readStr(reader, 1);
                            l.Data = readDateTime(reader, 2);
                            l.Valor = readDecimal(reader, 3);
                            l.Categoria = CategoriaRepo.Instance.Obter(readInt(reader, 4));
                        }
                    }
                }
            }

            return l;
        }

        public List<Lancamento> Listar()
        {
            return Listar(DateTime.MinValue);
        }

        public List<Lancamento> Listar(DateTime data)
        {
            List<Lancamento> lancamentos = new List<Lancamento>();

            using (SqlConnection conn = new SqlConnection(CONN))
            {
                string sql = "select * from lancamento ";
                if (data != DateTime.MinValue)
                {
                    sql += "where data = @data";
                }

                SqlCommand cmd = new SqlCommand(sql, conn);
                if (data != DateTime.MinValue)
                {
                    cmd.Parameters.Add("@data", SqlDbType.Date).Value = data;
                }
                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Lancamento l = new Lancamento();
                            l.Id = readLong(reader, 0);
                            l.Descricao = readStr(reader, 1);
                            l.Data = readDateTime(reader, 2);
                            l.Valor = readDecimal(reader, 3);
                            l.Categoria = CategoriaRepo.Instance.Obter(readInt(reader, 4));
                            lancamentos.Add(l);
                        }
                    }
                }
            }

            return lancamentos;
        }

        public void Excluir(long id)
        {
            if (id == 0)
            {
                throw new MiseException("Id não informado!");
            }

            using (SqlConnection conn = new SqlConnection(CONN))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(
                    "delete from lancamento " +
                    "where id = @id "
                    , conn);

                cmd.Parameters.Add("@id", SqlDbType.BigInt).Value = id;

                cmd.ExecuteNonQuery();
            }
        }

        public bool TemLancamentoVinculadoACategoria(int idCategoria)
        {
            using (SqlConnection conn = new SqlConnection(CONN))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();

                cmd.CommandText =
                    "select count(id_categoria) " +
                    "from lancamento " +
                    "where id_categoria = @idCategoria";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@idCategoria", SqlDbType.Int).Value = idCategoria;

                cmd.Connection = conn;

                int count = (int) cmd.ExecuteScalar();

                return count > 0;
            }
        }

        public decimal ObterTotal(DateTime data)
        {
            List<Lancamento> lista = Listar(data);
            decimal total = 0;
            foreach (var item in lista)
            {
                total += item.Valor;
            }

            return total;
        }
    }
}
