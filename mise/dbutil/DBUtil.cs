using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.IO.Compression;
using System.Net.Mail;
using System.Net;
using mise.model;
using mise.log;
using mise.config;

namespace mise.dbutil
{
    public class DBUtil
    {
        public static string CONN = Properties.Settings.Default.miseConn;
        public static bool BACKUP_ENABLED = Properties.Settings.Default.producao;

        public static string EMAIL = Properties.Settings.Default.email;
        public static string PW = Config.Instance.Pw;

        private static Logger _logger = Logger.Instance;

        public static string BASE_DIR = AppDomain.CurrentDomain.GetData("DataDirectory") + "";
        public static string BKP_DIR = BASE_DIR + "\\db_bkp\\";
        public static string ZIP_DIR = BKP_DIR + "\\zip\\";
        public static string LAST_DIR = BKP_DIR + "\\last\\";

        public static void Backup()
        {
            if (BACKUP_ENABLED && ShouldBackup())
            {
                try
                {
                    CreateAndClearDirs();
                    DateTime inicio = DateTime.Now;
                    PerformBackup();
                    _logger.Log("tempo total de backup: " + (DateTime.Now - inicio).TotalSeconds);
                    SendMail();
                    _logger.Log("mandou email async");
                }
                catch (Exception e)
                {
                    _logger.Log(e);
                    throw e;
                }

            }
        }

        private static void CreateAndClearDirs()
        {
            if (!Directory.Exists(BKP_DIR))
            {
                Directory.CreateDirectory(BKP_DIR);
            }

            if (!Directory.Exists(LAST_DIR))
            {
                Directory.CreateDirectory(LAST_DIR);
            }

            foreach (var file in new DirectoryInfo(LAST_DIR).GetFiles())
            {
                file.Delete();
            }

            if (!Directory.Exists(ZIP_DIR))
            {
                Directory.CreateDirectory(ZIP_DIR);
            }

            foreach (var file in new DirectoryInfo(ZIP_DIR).GetFiles())
            {
                if (file.CreationTime < DateTime.Today.AddDays(-30))
                {
                    file.Delete();
                }
            }
        }

        private static bool ShouldBackup()
        {
            foreach (var file in new DirectoryInfo(ZIP_DIR).GetFiles())
            {
                // só faz um backup por dia
                if (file.CreationTime.Date.Equals(DateTime.Today))
                {
                    return false;
                }
            }

            return true;
        }

        private static String PerformBackup()
        {
            using (var conn = new SqlConnection(CONN))
            {
                conn.Open();
                string filePath = LAST_DIR + "\\mise_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".bak";
                string sqlBkp = @"backup database ""{0}"" to disk= N'{1}'";

                string dbName = BASE_DIR + "\\mise.mdf";
                SqlCommand cmd = new SqlCommand(string.Format(sqlBkp, dbName, filePath), conn);

                cmd.ExecuteNonQuery();
            }
            return "";
        }

        private static void SendMail()
        {
            string zipPath = ZIP_DIR + "\\mise_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".zip";
            ZipFile.CreateFromDirectory(LAST_DIR, zipPath);

            SmtpClient client = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential(EMAIL, PW),
                EnableSsl = true,
                Timeout = 200000
            };

            MailMessage mail = new MailMessage(EMAIL, EMAIL);
            mail.Attachments.Add(new Attachment(zipPath));
            mail.Subject = "backup " + DateTime.Today.ToShortDateString();
            client.SendMailAsync(mail);
        }

        public static void Restore(string fileName)
        {
            try
            {
                using (var conn = new SqlConnection(CONN))
                {
                    conn.Open();
                    string dir = BASE_DIR + "\\mise.mdf";
                    string dirLog = BASE_DIR + "\\mise_log.ldf";

                    SqlCommand cmdUseMaster = new SqlCommand("use master;", conn);
                    cmdUseMaster.ExecuteNonQuery();


                    SqlCommand cmdAlter = new SqlCommand("alter database [" + dir + "] set single_user with rollback immediate;", conn);
                    cmdAlter.ExecuteNonQuery();

                    SqlCommand cmdRestore = new SqlCommand("restore database [" + dir + "] from disk= @dir "+
                        "with recovery, " +
                        "move 'mise' to @newDataPath, "+
                        "move 'mise_log' to @newLogPath;", conn);

                    cmdRestore.Parameters.Add("@dir", SqlDbType.VarChar).Value = fileName;
                    cmdRestore.Parameters.Add("@newDataPath", SqlDbType.VarChar).Value = dir;
                    cmdRestore.Parameters.Add("@newLogPath", SqlDbType.VarChar).Value = dirLog;
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
            catch (Exception e)
            {
                _logger.Log(e);
                throw e;
            }
        }
        public static void ConsultaFileList()
        {
            try
            {
                using (var conn = new SqlConnection(CONN))
                {
                    conn.Open();
                    
                    string fileName = "C:\\Users\\junji\\Downloads\\mise_20180122_200651\\mise_20180122_200644.bak";

                    SqlCommand cmdUseMaster = new SqlCommand("use master;", conn);
                    cmdUseMaster.ExecuteNonQuery();
                    
                    SqlCommand cmdRestoreFileListOnly = new SqlCommand("restore filelistonly from disk= @dir;", conn);

                    cmdRestoreFileListOnly.Parameters.Add("@dir", SqlDbType.VarChar).Value = fileName;
                    string pathDb = "";
                    string pathLog = "";
                    using (SqlDataReader reader = cmdRestoreFileListOnly.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                _logger.Log("-");
                                string logicalName = reader.GetString(0);
                                string physicalName = reader.GetString(1);
                                if (logicalName == "mise")
                                {
                                    pathDb = physicalName;
                                } else if (logicalName == "mise_log")
                                {
                                    pathLog = physicalName;
                                }
                            }
                        }

                        _logger.Log(pathDb);
                        _logger.Log(pathLog);
                    }

                }
                
            }
            catch (Exception e)
            {
                _logger.Log(e);
                throw e;
            }
        }
        
    }
}
