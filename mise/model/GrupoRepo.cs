using mise.exception;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mise.model
{
    public class GrupoRepo :SuperDAO
    {
        private ConcurrentDictionary<int, Grupo> _grupos = new ConcurrentDictionary<int, Grupo>();
        public EventHandler Changed;

        private ProdutoRepo _produtoRepo = ProdutoRepo.Instance;

        private static GrupoRepo _INSTANCE;

        private GrupoRepo() : base() {
            Carregar();
        }

        public static GrupoRepo Instance
        {
            get
            {
                if (_INSTANCE == null)
                    _INSTANCE = new GrupoRepo();
                return _INSTANCE;
            }
        }


        public List<Grupo> Listar()
        {
            if (_grupos.Count == 0)
            {
                Carregar();
            }

            return 
                (from g in _grupos
                orderby g.Value.Nome
                select g.Value).ToList();
        }

        public void Carregar()
        {
            _grupos.Clear();

            using (SqlConnection conn = new SqlConnection(CONN))
            {
                SqlCommand cmd = new SqlCommand();
                
                cmd.CommandText = "select * from Grupo";
                cmd.CommandType = CommandType.Text;

                cmd.Connection = conn;
                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Grupo f = new Grupo(
                                readInt(reader, 0),
                                readStr(reader, 1));

                            _grupos.TryAdd(f.Id, f);
                        }
                    }
                }
            }

            OnChanged(EventArgs.Empty);
        }

        public Grupo Obter(int id)
        {
            Grupo g = null;
            _grupos.TryGetValue(id, out g);
            
            return g;
        }

        public Grupo Incluir(Grupo g)
        {
            if (g.Nome == null || g.Nome == "")
                throw new MiseException("Nome não informado!");

            using (SqlConnection conn = new SqlConnection(CONN))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(
                    "insert into grupo(nome) " +
                    "output inserted.id " +
                    "values(@nome)", conn);

                cmd.Parameters.Add("@nome", SqlDbType.VarChar).Value = g.Nome;

                int id = (int)cmd.ExecuteScalar();
                g.Id = id;
            }

            Carregar();
            return g;
        }


        public void Alterar(Grupo g)
        {
            if (g.Id == 0)
                throw new MiseException("Id não informado!");

            if (g.Nome == null || g.Nome == "")
                throw new MiseException("Nome não informado!");

            using (SqlConnection conn = new SqlConnection(CONN))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(
                    "update grupo " +
                    "set nome = @nome " +
                    "where id = @id "
                    , conn);

                cmd.Parameters.Add("@id", SqlDbType.Int).Value = g.Id;
                cmd.Parameters.Add("@nome", SqlDbType.VarChar).Value = g.Nome;

                cmd.ExecuteNonQuery();
            }

            Carregar();
        }

        protected virtual void OnChanged(EventArgs e)
        {
            if (Changed != null)
                Changed(this, e);
        }

        public void Excluir(int id)
        {
            if (id == 0)
            {
                throw new MiseException("Id não fornecido!");
            }

            if (_produtoRepo.TemProdutoVinculadoAGrupo(id))
                throw new MiseException("Grupo não pode ser excluído, pois possui vínculo com Produto(s).");

            using (SqlConnection conn = new SqlConnection(CONN))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(
                    "delete from grupo " +
                    "where id = @id "
                    , conn);

                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;

                cmd.ExecuteNonQuery();
            }

            Carregar();
        }

    }
}
