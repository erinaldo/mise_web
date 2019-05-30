using mise.log;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mise.config
{
    class Config
    {
        private static string CONFIG_FILE_DIR = Path.Combine(
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), Properties.Settings.Default.localAppDir), 
            Properties.Settings.Default.configFile);

        private static Config _INSTANCE;

        private Logger _logger = Logger.Instance;

        private string _portaImpressora;
        private string _portaBalanca;
        private string _fone;
        private string _pw;

        private Config()
        {
            _portaImpressora = Properties.Settings.Default.portaImpressora;
            _portaBalanca = Properties.Settings.Default.portaBalanca;
            _fone = Properties.Settings.Default.fone;
            _pw = Properties.Settings.Default.pw;
            
            if (File.Exists(CONFIG_FILE_DIR))
            {
                string[] arquivo = File.ReadAllLines(CONFIG_FILE_DIR);
                if (arquivo.Length > 0)
                {
                    foreach (string linha in arquivo)
                    {
                        try
                        {
                            if (linha.Contains("portaBalanca="))
                            {
                                _portaBalanca = linha.Substring(linha.IndexOf("=") + 1);
                            } else if (linha.Contains("portaImpressora="))
                            {
                                _portaImpressora = linha.Substring(linha.IndexOf("=") + 1);
                            } else if (linha.Contains("fone="))
                            {
                                _fone = linha.Substring(linha.IndexOf("=") + 1);
                            } else if (linha.Contains("pw="))
                            {
                                _pw = linha.Substring(linha.IndexOf("=") + 1);
                            }
                        } catch (Exception e)
                        {
                            _logger.Log("Erro ao ler config.properties");
                            _logger.Log(e);
                        }
                    }
                }
            }
        }

        public static Config Instance
        {
            get
            {
                if (_INSTANCE == null)
                    _INSTANCE = new Config();

                return _INSTANCE;
            }
        }

        public string PortaImpressora
        {
            get
            {
                return _portaImpressora;
            }
        }

        public string PortaBalanca
        {
            get
            {
                return _portaBalanca;
            }
        }

        public string Fone
        {
            get
            {
                return _fone;
            }
        }

        public string Pw
        {
            get
            {
                return _pw;
            }
        }
    }
}
