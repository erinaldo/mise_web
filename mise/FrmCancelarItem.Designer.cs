namespace mise
{
    partial class FrmCancelarItem
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCancelarItem));
            this.txtCancelarItem = new mise.component.NumTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.fadingLabel = new mise.component.FadingLabel();
            this.SuspendLayout();
            // 
            // txtCancelarItem
            // 
            this.txtCancelarItem.AutoComma = true;
            this.txtCancelarItem.Dec = 0;
            this.txtCancelarItem.Location = new System.Drawing.Point(13, 34);
            this.txtCancelarItem.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCancelarItem.Name = "txtCancelarItem";
            this.txtCancelarItem.Size = new System.Drawing.Size(107, 26);
            this.txtCancelarItem.TabIndex = 11;
            this.txtCancelarItem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCancelarItem_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 20);
            this.label1.TabIndex = 12;
            this.label1.Text = "Nº do Item";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 95);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(145, 20);
            this.label8.TabIndex = 32;
            this.label8.Text = "ENTER - Confirmar";
            // 
            // fadingLabel
            // 
            this.fadingLabel.AutoSize = true;
            this.fadingLabel.FadingSpeed = 10;
            this.fadingLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fadingLabel.ForeColor = System.Drawing.Color.DarkRed;
            this.fadingLabel.InitialColor = System.Drawing.Color.DarkRed;
            this.fadingLabel.Location = new System.Drawing.Point(9, 65);
            this.fadingLabel.Name = "fadingLabel";
            this.fadingLabel.Size = new System.Drawing.Size(42, 20);
            this.fadingLabel.TabIndex = 33;
            this.fadingLabel.Text = "msg";
            this.fadingLabel.Visible = false;
            // 
            // FrmCancelarItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(306, 122);
            this.Controls.Add(this.fadingLabel);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtCancelarItem);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Location = new System.Drawing.Point(10, 10);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCancelarItem";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Cancelar Item";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private component.NumTextBox txtCancelarItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private component.FadingLabel fadingLabel;
    }
}