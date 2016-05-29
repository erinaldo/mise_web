using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace mise.model
{
    public abstract class SuperDAO
    {
        private SqlConnection _conn;

        //public static string CONN = ConfigurationManager.ConnectionStrings["mise.Properties.Settings.miseConn"].ConnectionString;

        public static string CONN = Properties.Settings.Default.miseConn;

        public SuperDAO()
        {
            //_conn = new SqlConnection(CONN);
        }

        public SuperDAO(SqlConnection conn)
        {
            _conn = conn;
        }

        public string readStr(SqlDataReader reader, int index)
        {
            if (!reader.IsDBNull(index))
            {
                return reader.GetString(index);
            }
            return null;
        }

        public decimal readDecimal(SqlDataReader reader, int index)
        {
            if (!reader.IsDBNull(index))
            {
                return reader.GetDecimal(index);
            }
            return 0m;
        }

        public int readInt(SqlDataReader reader, int index)
        {
            if (!reader.IsDBNull(index))
            {
                return reader.GetInt32(index);
            }
            return 0;
        }

        public long readLong(SqlDataReader reader, int index)
        {
            if (!reader.IsDBNull(index))
            {
                return reader.GetInt64(index);
            }
            return 0;
        }

        public DateTime readDateTime(SqlDataReader reader, int index)
        {
            if (!reader.IsDBNull(index))
            {
                return reader.GetDateTime(index);
            }
            return default(DateTime);
        }
    }
}
