using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;
using mise.model;
using System.Reflection;
using mise.log;

namespace mise.dbutil
{
    public class DBUtil
    {
        public static string CONN = Properties.Settings.Default.miseConn;
        public static bool BACKUP_ENABLED = Properties.Settings.Default.producao;

        private static Logger _logger = Logger.Instance;

        public static string BASE_DIR = AppDomain.CurrentDomain.GetData("DataDirectory") + "";

        public static void Backup()
        {
            if (BACKUP_ENABLED)
            {
                string bkpDir = BASE_DIR + "\\db_bkp\\";

                if (!Directory.Exists(bkpDir))
                {
                    Directory.CreateDirectory(bkpDir);
                }

                string lastDir = bkpDir + "\\last\\";
                if (!Directory.Exists(lastDir))
                {
                    Directory.CreateDirectory(lastDir);
                }

                foreach (var file in new DirectoryInfo(lastDir).GetFiles())
                {
                    file.Delete();
                }

                string zipDir = bkpDir + "\\zip";
                if (!Directory.Exists(zipDir))
                {
                    Directory.CreateDirectory(zipDir);
                }

                foreach (var file in new DirectoryInfo(zipDir).GetFiles())
                {
                    if (file.CreationTime < DateTime.Today.AddDays(-30))
                    {
                        file.Delete();
                    }
                }

                try
                {
                    using (var conn = new SqlConnection(CONN))
                    {
                        conn.Open();
                        string filePath = lastDir + "\\mise_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".bak";
                        string sqlBkp = @"backup database ""{0}"" to disk= N'{1}'";

                        string dbName = BASE_DIR + "\\mise.mdf";
                        SqlCommand cmd = new SqlCommand(string.Format(sqlBkp, dbName, filePath), conn);

                        cmd.ExecuteNonQuery();

                        string zipPath = zipDir +"\\mise_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".zip";
                        ZipFile.CreateFromDirectory(lastDir, zipPath);

                        SmtpClient client = new SmtpClient("smtp.gmail.com", 587) {
                            Credentials = new NetworkCredential("shinsekaimise@gmail.com", "otimo100"),
                            EnableSsl = true
                        };
                    
                        MailMessage mail = new MailMessage("shinsekaimise@gmail.com", "shinsekaimise@gmail.com");
                        mail.Attachments.Add(new Attachment(zipPath));
                        mail.Subject = "backup " + DateTime.Today.ToShortDateString();
                        client.Send(mail);
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public static void Restore(string fileName)
        {
            try
            {
                using (var conn = new SqlConnection(CONN))
                {
                    conn.Open();
                    string dir = BASE_DIR + "\\mise.mdf";

                    SqlCommand cmdUseMaster = new SqlCommand("use master;", conn);
                    cmdUseMaster.ExecuteNonQuery();

                    SqlCommand cmdAlter = new SqlCommand("alter database [" + dir + "] set single_user with rollback immediate;", conn);
                    cmdAlter.ExecuteNonQuery();

                    SqlCommand cmdRestore = new SqlCommand("restore database [" + dir + "] from disk= @dir;", conn);

                    cmdRestore.Parameters.Add("@dir", SqlDbType.VarChar).Value = fileName;
                    cmdRestore.ExecuteNonQuery();

                    SqlCommand cmdAlterBack = new SqlCommand("alter database [" + dir + "] set multi_user;", conn);
                    cmdAlterBack.ExecuteNonQuery();
                }

                // reseta repos
                ProdutoRepo.Instance.Carregar();
                FornecedorRepo.Instance.Carregar();
                FormaPagamentoRepo.Instance.Carregar();
                GrupoRepo.Instance.Carregar();
                CategoriaRepo.Instance.Carregar();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
