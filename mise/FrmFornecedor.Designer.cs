namespace mise
{
    partial class FrmFornecedor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmFornecedor));
            this.label1 = new System.Windows.Forms.Label();
            this.txtNomeFantasia = new System.Windows.Forms.TextBox();
            this.txtRazaoSocial = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtContato = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTelefone = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtObs = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.fadingLabel = new mise.component.FadingLabel();
            this.btFechar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 19);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nome Fantasia";
            // 
            // txtNomeFantasia
            // 
            this.txtNomeFantasia.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNomeFantasia.Location = new System.Drawing.Point(19, 44);
            this.txtNomeFantasia.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtNomeFantasia.MaxLength = 50;
            this.txtNomeFantasia.Name = "txtNomeFantasia";
            this.txtNomeFantasia.Size = new System.Drawing.Size(514, 26);
            this.txtNomeFantasia.TabIndex = 1;
            // 
            // txtRazaoSocial
            // 
            this.txtRazaoSocial.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtRazaoSocial.Location = new System.Drawing.Point(19, 100);
            this.txtRazaoSocial.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtRazaoSocial.MaxLength = 50;
            this.txtRazaoSocial.Name = "txtRazaoSocial";
            this.txtRazaoSocial.Size = new System.Drawing.Size(514, 26);
            this.txtRazaoSocial.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 75);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Razão Social";
            // 
            // txtContato
            // 
            this.txtContato.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtContato.Location = new System.Drawing.Point(19, 156);
            this.txtContato.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtContato.MaxLength = 50;
            this.txtContato.Name = "txtContato";
            this.txtContato.Size = new System.Drawing.Size(514, 26);
            this.txtContato.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 131);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Contato";
            // 
            // txtTelefone
            // 
            this.txtTelefone.Location = new System.Drawing.Point(19, 212);
            this.txtTelefone.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtTelefone.MaxLength = 50;
            this.txtTelefone.Name = "txtTelefone";
            this.txtTelefone.Size = new System.Drawing.Size(183, 26);
            this.txtTelefone.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 187);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Telefone";
            // 
            // txtObs
            // 
            this.txtObs.Location = new System.Drawing.Point(19, 268);
            this.txtObs.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtObs.MaxLength = 200;
            this.txtObs.Multiline = true;
            this.txtObs.Name = "txtObs";
            this.txtObs.Size = new System.Drawing.Size(514, 78);
            this.txtObs.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 243);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "Observação";
            // 
            // btnSalvar
            // 
            this.btnSalvar.BackColor = System.Drawing.SystemColors.Window;
            this.btnSalvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalvar.Location = new System.Drawing.Point(301, 357);
            this.btnSalvar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(112, 35);
            this.btnSalvar.TabIndex = 10;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = false;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // fadingLabel
            // 
            this.fadingLabel.AutoSize = true;
            this.fadingLabel.FadingSpeed = 10;
            this.fadingLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fadingLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.fadingLabel.InitialColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.fadingLabel.Location = new System.Drawing.Point(15, 363);
            this.fadingLabel.Name = "fadingLabel";
            this.fadingLabel.Size = new System.Drawing.Size(73, 20);
            this.fadingLabel.TabIndex = 11;
            this.fadingLabel.Text = "✓ Salvo!";
            this.fadingLabel.Visible = false;
            // 
            // btFechar
            // 
            this.btFechar.BackColor = System.Drawing.SystemColors.Window;
            this.btFechar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btFechar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btFechar.Location = new System.Drawing.Point(421, 357);
            this.btFechar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btFechar.Name = "btFechar";
            this.btFechar.Size = new System.Drawing.Size(112, 35);
            this.btFechar.TabIndex = 19;
            this.btFechar.Text = "Fechar";
            this.btFechar.UseVisualStyleBackColor = false;
            // 
            // FrmFornecedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.CancelButton = this.btFechar;
            this.ClientSize = new System.Drawing.Size(562, 406);
            this.Controls.Add(this.btFechar);
            this.Controls.Add(this.fadingLabel);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.txtObs);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtTelefone);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtContato);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtRazaoSocial);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNomeFantasia);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmFornecedor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fornecedor";
            this.Load += new System.EventHandler(this.FrmFornecedor_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNomeFantasia;
        private System.Windows.Forms.TextBox txtRazaoSocial;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtContato;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTelefone;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtObs;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSalvar;
        private component.FadingLabel fadingLabel;
        private System.Windows.Forms.Button btFechar;
    }
}