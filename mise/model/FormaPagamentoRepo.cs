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
    public class FormaPagamentoRepo : SuperDAO, IFormaPagamentoRepo
    {
        private ConcurrentDictionary<int, FormaPagamento> _formasPagamento = new ConcurrentDictionary<int, FormaPagamento>();
        private static FormaPagamentoRepo _INSTANCE;
        public EventHandler Changed;

        private FormaPagamentoRepo() : base() {
            Carregar();
        }
        
        public static FormaPagamentoRepo Instance
        {
            get
            {
                if (_INSTANCE == null)
                    _INSTANCE = new FormaPagamentoRepo();

                return _INSTANCE;
            }
        }

        public FormaPagamento Obter(int id)
        {
            if (_formasPagamento.Count == 0)
            {
                Carregar();
            }

            FormaPagamento f = null;
            _formasPagamento.TryGetValue(id, out f);

            return f;
        }

        public List<FormaPagamento> Listar()
        {
            if (_formasPagamento.Count == 0)
            {
                Carregar();
            }

            return (from f in _formasPagamento
                    orderby f.Value.Indice
                    select f.Value).ToList();
        }

        public void Carregar()
        {
            _formasPagamento.Clear();
            using (SqlConnection conn = new SqlConnection(CONN))
            {
                SqlCommand cmd = new SqlCommand();
                SqlDataReader reader;

                cmd.CommandText = "select * from FormaPagamento ";
                cmd.CommandType = CommandType.Text;

                cmd.Connection = conn;
                conn.Open();

                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        FormaPagamento f = new FormaPagamento(
                            readInt(reader, 0),
                            readStr(reader, 1),
                            readInt(reader, 2));
                        _formasPagamento.TryAdd(f.Id, f);
                    }
                }
            }

            OnChanged(EventArgs.Empty);
        }

        public FormaPagamento Incluir(FormaPagamento f)
        {
            if (f.Nome == null || f.Nome == "")
                throw new MiseException("Nome não informado!");

            using (SqlConnection conn = new SqlConnection(CONN))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(
                    "insert into formapagamento(nome, indice) " +
                    "output inserted.id " +
                    "values(@nome, (select max(indice) + 1 from formapagamento))", conn);

                cmd.Parameters.Add("@nome", SqlDbType.VarChar).Value = f.Nome;

                int id = (int) cmd.ExecuteScalar();
                f.Id = id;
            }

            Carregar();
            return f;
        }


        public void Alterar(FormaPagamento f)
        {

            if (f.Id == 0)
            {
                throw new MiseException("Id não informado!");
            }

            if (f.Nome == null || f.Nome == "")
                throw new MiseException("Nome não informado!");

            using (SqlConnection conn = new SqlConnection(CONN))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(
                    "update formapagamento " +
                    "set nome = @nome " +
                    "where id = @id "
                    , conn);

                cmd.Parameters.Add("@id", SqlDbType.Int).Value = f.Id;
                cmd.Parameters.Add("@nome", SqlDbType.VarChar).Value = f.Nome;

                cmd.ExecuteNonQuery();
            }
            
            Carregar();
        }

        public void Excluir(int id)
        {

            if (id == 0)
            {
                throw new MiseException("Id não fornecido!");
            }

            FormaPagamento f = Obter(id);
            if (f.IsDinheiro)
                throw new MiseException("Forma de Pagamento DINHEIRO não pode ser excluída!");
            

            if (VendaRepo.Instance.TemPagamentoVinculadoAFormaPagamento(id))
                throw new MiseException("Forma de Pagamento não pode ser excluída, pois possui vínculo com Venda(s).");

            using (SqlConnection conn = new SqlConnection(CONN))
            {
                conn.Open();
                using (SqlTransaction t = conn.BeginTransaction("t1"))
                {
                    SqlCommand cmd = new SqlCommand(
                        "delete from formapagamento where id = @id "
                        , conn, t);

                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                    cmd.ExecuteNonQuery();

                    organizarSequencia(t);
                    t.Commit();
                }
            }

            Carregar();
        }

        /* chamar isso dentro de uma transacao */
        private void organizarSequencia(SqlTransaction t)
        {
            SqlCommand cmd = new SqlCommand(
                "select id from formapagamento order by indice "
                , t.Connection, t);
            List<int> ids = new List<int>();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ids.Add(readInt(reader, 0));
                    }
                }
            }

            int indice = 1;
            foreach (var id in ids)
            {
                SqlCommand cmdUpdate = new SqlCommand(
                        "update formapagamento set indice = @indice where id = @id ", 
                        t.Connection, t);
                cmdUpdate.Parameters.Add("@id", SqlDbType.Int).Value = id;
                cmdUpdate.Parameters.Add("@indice", SqlDbType.Int).Value = indice;
                cmdUpdate.ExecuteNonQuery();
                indice++;
            }
        }

        public void Reordenar(List<int> ids)
        {
            FormaPagamento f = Obter(ids[0]);
            if (!f.IsDinheiro) throw new MiseException("DINHEIRO não pode ter ordem alterada!");

            using (SqlConnection conn = new SqlConnection(CONN))
            {
                conn.Open();

                int indice = 1;
                foreach (var id in ids)
                {
                    SqlCommand cmdUpdate = new SqlCommand(
                            "update formapagamento set indice = @indice where id = @id ",
                            conn);

                    cmdUpdate.Parameters.Add("@id", SqlDbType.Int).Value = id;
                    cmdUpdate.Parameters.Add("@indice", SqlDbType.Int).Value = indice;
                    cmdUpdate.ExecuteNonQuery();
                    indice++;
                }
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
