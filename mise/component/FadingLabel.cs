using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mise.component
{
    public class FadingLabel : Label
    {
        private int _fadingSpeed = 10;

        public FadingLabel()
        {
            this.Hide();
        }

        public void ShowAndFade()
        {
            this.Show();
            this.ForeColor = InitialColor;

            var t = new Timer();
            t.Interval = 100;
            t.Tick += (s, z) =>
            {
                int red = this.ForeColor.R + _fadingSpeed <= 255 ? this.ForeColor.R + _fadingSpeed : 255;
                int green = this.ForeColor.G + _fadingSpeed <= 255 ? this.ForeColor.G + _fadingSpeed : 255;
                int blue = this.ForeColor.B + _fadingSpeed <= 255 ? this.ForeColor.B + _fadingSpeed : 255;

                this.ForeColor = Color.FromArgb(red, green, blue);

                if (this.ForeColor.G >= this.BackColor.G ||
                    this.ForeColor.R >= this.BackColor.R ||
                    this.ForeColor.B >= this.BackColor.B)
                {
                    t.Stop();
                    this.ForeColor = this.BackColor;
                    this.Hide();
                }
            };

            t.Start();
        }

        public Color InitialColor
        {
            get;
            set;
        }

        public int FadingSpeed
        {
            get { return _fadingSpeed; }
            set { _fadingSpeed = value; }
        }
    }
}
