using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mise.log
{
    public class Logger
    {
        private static Logger _INSTANCE;
        private StreamWriter _writer;
        private static string LOG_DIR = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), Properties.Settings.Default.localAppDir) + Properties.Settings.Default.logDir;

        private Logger()
        {
            if (!Directory.Exists(LOG_DIR))
            {
                Directory.CreateDirectory(LOG_DIR);
            }

            string path = @"" + LOG_DIR + DateTime.Today.ToString("yyyyMMdd") + ".txt";

            _writer = new StreamWriter(path, true);
            _writer.AutoFlush = true;
        }

        public static Logger Instance
        {
            get
            {
                if (_INSTANCE == null)
                    _INSTANCE = new Logger();

                return _INSTANCE;
            }
        }

        public void Log(string line)
        {
            _writer.WriteLine("[" + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString() + "] " + line);
        }

        public void Log(Exception e)
        {
            _writer.WriteLine("[" + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString() + "] " + e.Message);
            _writer.WriteLine(e.StackTrace);
        }

        public void Close()
        {
            _writer.Flush();
            _writer.Close();
        }
    }
}
