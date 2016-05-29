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
    public class CategoriaRepo : SuperDAO
    {
        private static CategoriaRepo INSTANCE;
        private Dictionary<int, Categoria> _categorias = new Dictionary<int, Categoria>();

        private CategoriaRepo() : base() {
            Carregar();
        }

        public static CategoriaRepo Instance
        {
            get
            {
                if (INSTANCE == null)
                    INSTANCE = new CategoriaRepo();

                return INSTANCE;
            }
        }

        public Categoria Incluir(Categoria c)
        {
            if (c.Nome == null || c.Nome == "")
                throw new MiseException("Nome não informado!");

            using (SqlConnection conn = new SqlConnection(CONN))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(
                    "insert into categoria(nome) " +
                    "output inserted.id " +
                    "values(@nome)", conn);

                cmd.Parameters.Add("@nome", SqlDbType.VarChar).Value = c.Nome;

                int id = (int)cmd.ExecuteScalar();
                c.Id = id;
            }

            Carregar();

            return c;
        }

        public Categoria Obter(int id)
        {
            Categoria c = null;
            _categorias.TryGetValue(id, out c);
            return c;
        }

        public Categoria Obter_OLD(int id)
        {
            Categoria c = null;

            using (SqlConnection conn = new SqlConnection(CONN))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select * from Categoria where id = @id";
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
                            c = new Categoria(
                                readInt(reader, 0),
                                readStr(reader, 1));
                        }
                    }
                }
            }

            return c;
        }

        public Categoria Alterar(Categoria c)
        {
            if (c.Id == 0)
                throw new MiseException("Id não informado!");

            if (c.Nome == null || c.Nome == "")
                throw new MiseException("Descrição não informada!");

            using (SqlConnection conn = new SqlConnection(CONN))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(
                    "update categoria " +
                    "set nome = @nome " +
                    "where id = @id "
                    , conn);

                cmd.Parameters.Add("@id", SqlDbType.Int).Value = c.Id;
                cmd.Parameters.Add("@nome", SqlDbType.VarChar).Value = c.Nome;

                cmd.ExecuteNonQuery();
            }

            Carregar();

            return c;
        }

        public List<Categoria> Listar()
        {
            return _categorias.Select(x => x.Value).ToList();
        }

        public void Carregar()
        {
            _categorias.Clear();
            using (SqlConnection conn = new SqlConnection(CONN))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select * from Categoria";
                cmd.CommandType = CommandType.Text;

                cmd.Connection = conn;
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Categoria c = new Categoria(
                                readInt(reader, 0),
                                readStr(reader, 1));
                            _categorias.Add(c.Id, c);
                        }
                    }
                }
            }
        }

        public void Excluir(int id)
        {
            if (id == 0)
            {
                throw new MiseException("Id não informado!");
            }

            if (LancamentoRepo.Instance.TemLancamentoVinculadoACategoria(id))
                throw new MiseException("Categoria não pode ser excluída, pois possui vínculo com Lançamento(s).");

            using (SqlConnection conn = new SqlConnection(CONN))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(
                    "delete from categoria " +
                    "where id = @id "
                    , conn);

                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;

                cmd.ExecuteNonQuery();
            }

            Carregar();
        }

    }
}
