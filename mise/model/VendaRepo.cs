using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mise.exception;

namespace mise.model
{
    public class VendaRepo : SuperDAO, IVendaRepo
    {

        private static VendaRepo _INSTANCE;

        private VendaRepo() : base() {}
        
        public static VendaRepo Instance
        {
            get
            {
                if (_INSTANCE == null)
                    _INSTANCE = new VendaRepo();

                return _INSTANCE;
            }
        }

        public Venda Incluir(Venda v)
        {
            if (v.Itens.Count == 0)
                throw new MiseException("Venda não possui itens!");
            if (v.TotalAPagar > 0)
                throw new MiseException("Venda possui saldo a pagar!");

            using (SqlConnection conn = new SqlConnection(CONN))
            {
                conn.Open();
                using (SqlTransaction t = conn.BeginTransaction("t1"))
                {
                    SqlCommand cmd = new SqlCommand("insert into Venda(data_hora) output inserted.id values(@data)", conn, t);

                    cmd.Parameters.Add("@data", SqlDbType.DateTime).Value = v.Data;

                    long id = (long) cmd.ExecuteScalar();
                    v.Id = id;

                    foreach (var i in v.Itens)
                    {
                        if (!i.Cancelado)
                        {
                            InserirItem(id, i, t);
                        }
                    }

                    int sequencial = 1;
                    foreach (var p in v.Pagamentos)
                    {
                        InserirPagamento(id, p, t, sequencial++);
                    }

                    t.Commit();
                }
            }
            return v;
        }

        private void InserirItem(long idVenda, Item i, SqlTransaction t)
        {
            string sql = "insert into Item(id_produto, id_venda, sequencial, qtd, preco) " +
                "values(@idProduto, @idVenda, @sequencial, @qtd, @preco)";
            SqlCommand cmd = new SqlCommand(sql, t.Connection, t);
            cmd.Parameters.Add("@idProduto", SqlDbType.BigInt).Value = i.Produto.Id;
            cmd.Parameters.Add("@idVenda", SqlDbType.BigInt).Value = idVenda;
            cmd.Parameters.Add("@sequencial", SqlDbType.BigInt).Value = i.Sequencial;
            cmd.Parameters.Add("@qtd", SqlDbType.Decimal).Value = i.Qtd;
            cmd.Parameters.Add("@preco", SqlDbType.Decimal).Value = i.PrecoUni;
            cmd.ExecuteNonQuery();
        }

        private void InserirPagamento(long idVenda, Venda.Pagamento p, SqlTransaction t, int sequencial)
        {
            string sql = "insert into Pagamento(id_venda, sequencial, valor, id_forma_pagamento) " +
                "values(@idVenda, @sequencial, @valor, @idFormaPagamento)";
            SqlCommand cmd = new SqlCommand(sql, t.Connection, t);
            cmd.Parameters.Add("@idVenda", SqlDbType.BigInt).Value = idVenda;
            cmd.Parameters.Add("@sequencial", SqlDbType.BigInt).Value = sequencial;
            cmd.Parameters.Add("@valor", SqlDbType.Decimal).Value = p.ValorSemTroco;
            cmd.Parameters.Add("@idFormaPagamento", SqlDbType.BigInt).Value = p.FormaPagamento.Id;
            cmd.ExecuteNonQuery();
        }

        public bool TemItemVinculadoAProduto(long idProduto)
        {
            using (SqlConnection conn = new SqlConnection(CONN))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                
                cmd.CommandText =
                    "select count(i.id_produto) " +
                    "from item i " +
                    "where i.id_produto = @idProduto";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@idProduto", SqlDbType.BigInt).Value = idProduto;

                cmd.Connection = conn;

                int count = (int) cmd.ExecuteScalar();

                return count > 0;
            }
        }

        public bool TemPagamentoVinculadoAFormaPagamento(int idFormaPagamento)
        {
            using (SqlConnection conn = new SqlConnection(CONN))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();

                cmd.CommandText =
                    "select count(p.id_forma_pagamento) " +
                    "from pagamento p " +
                    "where p.id_forma_pagamento = @idFormaPagamento";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@idFormaPagamento", SqlDbType.Int).Value = idFormaPagamento;

                cmd.Connection = conn;

                int count = (int)cmd.ExecuteScalar();

                return count > 0;
            }
        }

        public Dictionary<int, decimal> GerarResumoDiario(DateTime data)
        {
            Dictionary<int, decimal> resumo = new Dictionary<int, decimal>();

            using (SqlConnection conn = new SqlConnection(CONN))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select f.id, sum(p.valor) as total from pagamento p " +
                    "join venda v on v.id = p.id_venda " +
                    "join formapagamento f on f.id = p.id_forma_pagamento " +
                    "where convert(date, v.data_hora) = @data " +
                    "group by (f.id); ";

                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@data", SqlDbType.Date).Value = data;

                cmd.Connection = conn;
                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            resumo.Add(readInt(reader, 0), readDecimal(reader, 1));
                        }
                    }
                }
            }

            return resumo;
        }

        public Venda Obter(long id)
        {
            if (id == 0)
                throw new Exception("Id não informado!");

            Venda venda = null;
            using (SqlConnection conn = new SqlConnection(CONN))
            {
                SqlCommand cmd = new SqlCommand();
                
                cmd.CommandText =
                    "select v.id, v.data_hora, p.sequencial, p.valor, f.id from venda v " +
                    "join pagamento p on v.id = p.id_venda " +
                    "join formapagamento f on p.id_forma_pagamento = f.id " +
                    "where v.id = @id; ";

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
                            if (venda == null)
                                venda = new Venda(readLong(reader, 0), readDateTime(reader, 1));
                            FormaPagamento f = FormaPagamentoRepo.Instance.Obter(readInt(reader, 4));
                            Venda.Pagamento p = new Venda.Pagamento(readDecimal(reader, 3), f, 0);
                            venda.Pagamentos.Add(p);
                        }
                    }
                }

                SqlCommand cmdItem = new SqlCommand(
                    "select p.codigo, i.sequencial, i.qtd, i.preco from item i " +
                    "join produto p on p.id = i.id_produto " +
                    "where id_venda = @id; ", conn);
                cmdItem.Parameters.Add("@id", SqlDbType.BigInt).Value = id;

                using (SqlDataReader reader = cmdItem.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Item item = new Item(readInt(reader, 1), ProdutoRepo.Instance.Obter(readLong(reader, 0)));
                            item.Qtd = readDecimal(reader, 2);
                            item.PrecoUni = readDecimal(reader, 3);
                            venda.Itens.Add(item);
                        }
                    }
                }
            }

            return venda;
        }

        public Dictionary<long, ResumoVenda> GerarResumoAnalitico(DateTime ini, DateTime fim)
        {
            Dictionary<long, ResumoVenda> resumo = new Dictionary<long, ResumoVenda>();

            using (SqlConnection conn = new SqlConnection(CONN))
            {
                string sql = "select p.codigo, sum(i.qtd) as totalQtd, sum(i.qtd * i.preco) as total from produto p " +
                    "join item i on i.id_produto = p.id " +
                    "join venda v on i.id_venda = v.id " +
                    "where convert(date, v.data_hora) between @ini and @fim " +
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

                            resumo.Add(codigo, new ResumoVenda(
                                ProdutoRepo.Instance.Obter(codigo), 
                                Decimal.Round(qtd, 3), 
                                Decimal.Round(preco,2)));
                        }
                    }
                }
            }

            return resumo;
        }

    }
}
