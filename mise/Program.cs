using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using mise.log;
using System.IO;

namespace mise
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string localAppData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            
            AppDomain.CurrentDomain.SetData("LocalAppDataDir", Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData));

            string misePath = Path.Combine(localAppData, Properties.Settings.Default.localAppDir);
            
            if (!Directory.Exists(misePath))
                Directory.CreateDirectory(misePath);

            string dataPath = Path.Combine(misePath, "data");
            if (!Directory.Exists(dataPath))
                Directory.CreateDirectory(dataPath);

            AppDomain.CurrentDomain.SetData("DataDirectory", dataPath);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            AppDomain.CurrentDomain.UnhandledException += (s, e) =>
            {
                Exception excep = e.ExceptionObject as Exception;
                if (excep != null)
                {
                    string message = "Exception:\n" + excep + "\n\n";
                    string innerexcep = "Inner Exception:\n" + excep.InnerException;
                    MessageBox.Show(message + innerexcep, "Error");
                }
            };

            Application.Run(new FrmMain());

        }
    }
}
