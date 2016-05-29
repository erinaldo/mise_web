using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using mise.dbutil;
using mise.log;

namespace mise
{
    public partial class FrmRestore : Form
    {
        private Logger _logger = Logger.Instance;
        private FrmWait _frmWait = new FrmWait("Restaurando Backup");

        public FrmRestore()
        {
            InitializeComponent();
        }

        private void btnSelecionar_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog() { 
                Title = "Selecione o arquivo",
                Filter = "BAK Files|*.bak",
                InitialDirectory= @"C:\"
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                txtArquivo.Text = dialog.FileName;
            }
        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {

            if (txtArquivo.Text != "" && File.Exists(txtArquivo.Text))
            {
                bgWorker.RunWorkerAsync();
                _frmWait.ShowDialog();
            } else {
                MessageBox.Show("Arquivo de backup inválido!");
            }
        }

        private void bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                DBUtil.Restore(txtArquivo.Text);
            }
            catch (Exception ex)
            {
                _logger.Log(ex);
                MessageBox.Show(ex.Message);
            }

            this.Invoke((MethodInvoker)delegate
            {
                _frmWait.Close();
                lblRestaurado.ShowAndFade();
            });
        }
    }
}
