using mise.exception;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using mise.model;

namespace mise
{
    public partial class FrmCancelarItem : Form
    {
        private Venda _venda;
        private int _sequencial;

        public FrmCancelarItem(Venda v)
        {
            InitializeComponent();
            _venda = v;
        }

        private void txtCancelarItem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = e.SuppressKeyPress = true;

                if (txtCancelarItem.Text == "")
                {
                    fadingLabel.Text = "Informe o número de um item!";
                    fadingLabel.ShowAndFade();
                    return;
                }

                int sequencial = Convert.ToInt32(txtCancelarItem.Text);

                try
                {
                    _venda.CancelarItem(sequencial);

                    this._sequencial = sequencial;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (MiseException me)
                {
                    fadingLabel.Text = me.Message;
                    fadingLabel.ShowAndFade();
                    
                    txtCancelarItem.SelectAll();
                }
                catch (Exception ee)
                {
                    MessageBox.Show(ee.Message + ee);
                }
            }
            else if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        public int Sequencial { get { return _sequencial; } }
    }
}
