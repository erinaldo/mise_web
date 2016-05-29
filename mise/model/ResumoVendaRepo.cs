using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mise.model
{
    public class ResumoVendaRepo :SuperDAO
    {
        private static ResumoVendaRepo _INSTANCE;

        private ProdutoRepo _produtoRepo;

        private ResumoVendaRepo() : base() {
            _produtoRepo = ProdutoRepo.Instance;
        }

        public static ResumoVendaRepo Instance
        {
            get
            {
                if (_INSTANCE == null)
                    _INSTANCE = new ResumoVendaRepo();

                return _INSTANCE;
            }
        }

        public List<ResumoVenda> GerarResumoAnalitico(DateTime ini, DateTime fim)
        {
            List<ResumoVenda> resumo = new List<ResumoVenda>();

            using (SqlConnection conn = new SqlConnection(CONN))
            {
                string sql = "select p.codigo, sum(i.qtd) as totalQtd, sum(i.preco) as total from produto p" +
                    "join item i on i.id_produto = p.id " +
                    "join venda v on i.id_venda = v.id " +
                    "where v.data_hora between @ini and @fim " +
                    "group by p.codigo";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@ini", SqlDbType.Date).Value = ini;
                cmd.Parameters.Add("@fim", SqlDbType.Date).Value = fim;

                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            long codigo = readLong(reader, 0);
                            decimal qtd = readDecimal(reader, 1);
                            decimal preco = readDecimal(reader, 2);

                            resumo.Add(new ResumoVenda(_produtoRepo.Obter(codigo), qtd, preco));
                        }
                    }
                }
            }

            return resumo;
        }
    }
}
