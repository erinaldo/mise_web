using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using mise.config;
using mise.log;

namespace mise.external
{
    public class Balanca
    {
        private static Balanca _INSTANCE;
        private static bool _MOCK = !Properties.Settings.Default.producao;
        
        [DllImport("LePeso.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr _LePeso();

        [DllImport("LePeso.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int _AbrePortaSerial(string porta);

        [DllImport("LePeso.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int _FechaPortaSerial();

        [DllImport("LePeso.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void _AlteraModeloBalanca(int modelo);

        [DllImport("LePeso.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void _AlteraModoOperacao(int modo);

        private static string MODELO = Properties.Settings.Default.modeloBalanca;
        private static string PORTA = Config.Instance.PortaBalanca;
        private Logger _logger;
        
        private Balanca() {
            _logger = Logger.Instance;
            Init();
        }

        private void Init()
        {
            Console.WriteLine(PORTA);
            if (!_MOCK)
            {
                FecharConexao();
                _AlteraModeloBalanca(Convert.ToInt32(MODELO)); // US POP
                _AlteraModoOperacao(0);
                AbrirConexao();
            }
        }

        public static Balanca Instance
        {
            get
            {
                if (_INSTANCE == null)
                    _INSTANCE = new Balanca();
                return _INSTANCE;
            }
        }

        public void AbrirConexao()
        {
            if (!_MOCK)
            {
                int abriu = _AbrePortaSerial(PORTA);
                if (abriu != 1)
                {
                    _logger.Log("ERRO [LePeso._AbrePortaSerial] - codretorno: " + abriu);
                }
            }
        }

        public void FecharConexao()
        {
            if (!_MOCK)
            {
                int fechou = _FechaPortaSerial();
                if (fechou != 1)
                {
                    _logger.Log("ERRO [LePeso._FechaPortaSerial] - codretorno: " + fechou);
                }
            }
        }

        public string LerPeso()
        {
            string pesoTrim = Ler();

            if (pesoTrim.Contains('*'))
            {
                Init();
                pesoTrim = Ler();
                if (pesoTrim.Contains('*'))
                {
                    throw new Exception("Não foi possível ler peso! Verifique se a balança está conectada e tente novamente.");
                }
            }

            return pesoTrim;
        }

        private string Ler()
        {
            if (!_MOCK)
            {
                int len = 0;
                IntPtr pesoIntPtr = _LePeso();
                while (Marshal.ReadByte(pesoIntPtr, len) != 0)
                {
                    ++len;
                }

                byte[] array = new byte[len];
                Marshal.Copy(pesoIntPtr, array, 0, len);

                string retornoCompleto = System.Text.Encoding.Default.GetString(array).Trim();
                if (retornoCompleto.Contains("*"))
                {
                    _logger.Log("Erro [LePeso._LePeso] - retorno: " + retornoCompleto);
                }

                byte[] arrSomentePeso = new byte[6];
                arrSomentePeso[0] = array[18];
                arrSomentePeso[1] = array[19];
                arrSomentePeso[2] = array[20];
                arrSomentePeso[3] = array[21];
                arrSomentePeso[4] = array[22];
                arrSomentePeso[5] = array[23];

                return System.Text.Encoding.Default.GetString(arrSomentePeso).Trim();
            }
            else
            {
                return "0,879";
            }
        }
    }
}
