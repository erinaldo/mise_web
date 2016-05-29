using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace mise.external
{
    public class Balanca
    {
        private static Balanca _INSTANCE;
        private static bool _MOCK = Properties.Settings.Default.balancaMock;
        
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
        private static string PORTA = Properties.Settings.Default.portaBalanca;

        private Balanca() {
            if (!_MOCK)
            {
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
            }
        }

        public void FecharConexao()
        {
            if (!_MOCK)
            {
                int fechou = _FechaPortaSerial();
            }
        }

        public string LerPeso()
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

                byte[] arrSomentePeso = new byte[6];
                arrSomentePeso[0] = array[18];
                arrSomentePeso[1] = array[19];
                arrSomentePeso[2] = array[20];
                arrSomentePeso[3] = array[21];
                arrSomentePeso[4] = array[22];
                arrSomentePeso[5] = array[23];

                string pesoTrim = System.Text.Encoding.Default.GetString(arrSomentePeso).Trim();

                return pesoTrim;
            }
            else
            {
                return "0,879";
            }
        }
    }
}
