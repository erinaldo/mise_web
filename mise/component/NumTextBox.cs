using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mise.component
{
    public class NumTextBox:TextBox
    {
        private bool _autoComma = false;
        private int _dec = 0;
        public NumTextBox()
        {
            //base.Text = "0,00";
        } 

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            if (!onlyNumber(e.KeyChar))
            {
                e.Handled = true;
                return;
            }

            if (IsDec && !_autoComma)
            {
                int index = base.Text.IndexOf(',');
                
                if (base.SelectionLength < base.Text.Length && 
                    ((e.KeyChar == ',' && index > 0) || 
                        (char.IsDigit(e.KeyChar) && index >= 0 && index < base.Text.Length - _dec)))
                {
                    e.Handled = true;
                    return;
                }
            }

            base.OnKeyPress(e);
        }

        protected override void OnTextChanged(EventArgs e)
        {
            if (IsDec)
            {
                if (_autoComma)
                {
                    string nText = base.Text.Replace(",", "");
                    int index = _dec + 1;
                    if (nText.Length > index)
                    {
                        while (nText.IndexOf('0') == 0 && nText.Length > index)
                        {
                            nText = nText.Remove(0, 1);
                        }
                    }
                    else
                    {
                        nText = nText.PadLeft(index, '0');
                    }

                    base.Text = nText.Insert(nText.Length - _dec, ",");

                }
                else
                {
                    if (base.Text.Equals(","))
                    {
                        base.Text = base.Text.Insert(0, "0");
                    }
                }

                base.SelectionStart = base.Text.Length;
                base.SelectionLength = 0;
            }
            base.OnTextChanged(e);
        }

        protected override void OnGotFocus(EventArgs e)
        {
            SelectAll();
            base.OnGotFocus(e);
        }

        private bool onlyNumber(char c)
        {
            return char.IsDigit(c) || char.IsControl(c) || (IsDec && !_autoComma && c == ',');
        }

        public bool AutoComma
        {
            get { return _autoComma; }
            set { _autoComma = value; }
        }

        public bool IsDec
        {
            get { return _dec != 0; }
        }

        public int Dec
        {
            get { return _dec; }
            set { _dec = value; }
        }
    }
}
