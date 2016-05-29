namespace mise
{
    partial class FrmLancamento
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLancamento));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.cbCategoria = new System.Windows.Forms.ComboBox();
            this.btnNovaCategoria = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.fadingLabel = new mise.component.FadingLabel();
            this.txtValor = new mise.component.NumTextBox();
            this.txtData = new System.Windows.Forms.MaskedTextBox();
            this.btFechar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Data";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 175);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Descrição";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Categoria";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 119);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Valor";
            // 
            // txtDescricao
            // 
            this.txtDescricao.Location = new System.Drawing.Point(16, 198);
            this.txtDescricao.MaxLength = 150;
            this.txtDescricao.Multiline = true;
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(455, 107);
            this.txtDescricao.TabIndex = 3;
            // 
            // cbCategoria
            // 
            this.cbCategoria.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbCategoria.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbCategoria.FormattingEnabled = true;
            this.cbCategoria.Location = new System.Drawing.Point(16, 86);
            this.cbCategoria.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbCategoria.Name = "cbCategoria";
            this.cbCategoria.Size = new System.Drawing.Size(380, 28);
            this.cbCategoria.TabIndex = 1;
            // 
            // btnNovaCategoria
            // 
            this.btnNovaCategoria.BackColor = System.Drawing.SystemColors.Window;
            this.btnNovaCategoria.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnNovaCategoria.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnNovaCategoria.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightGray;
            this.btnNovaCategoria.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNovaCategoria.ForeColor = System.Drawing.Color.Black;
            this.btnNovaCategoria.Location = new System.Drawing.Point(404, 82);
            this.btnNovaCategoria.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnNovaCategoria.Name = "btnNovaCategoria";
            this.btnNovaCategoria.Size = new System.Drawing.Size(40, 35);
            this.btnNovaCategoria.TabIndex = 21;
            this.btnNovaCategoria.Text = "...";
            this.btnNovaCategoria.UseVisualStyleBackColor = false;
            this.btnNovaCategoria.Click += new System.EventHandler(this.btnNovaCategoria_Click);
            // 
            // btnSalvar
            // 
            this.btnSalvar.BackColor = System.Drawing.SystemColors.Window;
            this.btnSalvar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSalvar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnSalvar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightGray;
            this.btnSalvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalvar.ForeColor = System.Drawing.Color.Black;
            this.btnSalvar.Location = new System.Drawing.Point(239, 313);
            this.btnSalvar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(112, 35);
            this.btnSalvar.TabIndex = 4;
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
            this.fadingLabel.Location = new System.Drawing.Point(12, 320);
            this.fadingLabel.Name = "fadingLabel";
            this.fadingLabel.Size = new System.Drawing.Size(73, 20);
            this.fadingLabel.TabIndex = 22;
            this.fadingLabel.Text = "✓ Salvo!";
            this.fadingLabel.Visible = false;
            // 
            // txtValor
            // 
            this.txtValor.AutoComma = false;
            this.txtValor.Dec = 2;
            this.txtValor.Location = new System.Drawing.Point(16, 144);
            this.txtValor.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtValor.MaxLength = 6;
            this.txtValor.Name = "txtValor";
            this.txtValor.Size = new System.Drawing.Size(125, 26);
            this.txtValor.TabIndex = 2;
            // 
            // txtData
            // 
            this.txtData.Location = new System.Drawing.Point(16, 32);
            this.txtData.Mask = "00/00/0000";
            this.txtData.Name = "txtData";
            this.txtData.Size = new System.Drawing.Size(125, 26);
            this.txtData.TabIndex = 23;
            this.txtData.ValidatingType = typeof(System.DateTime);
            // 
            // btFechar
            // 
            this.btFechar.BackColor = System.Drawing.SystemColors.Window;
            this.btFechar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btFechar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btFechar.Location = new System.Drawing.Point(359, 313);
            this.btFechar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btFechar.Name = "btFechar";
            this.btFechar.Size = new System.Drawing.Size(112, 35);
            this.btFechar.TabIndex = 24;
            this.btFechar.Text = "Fechar";
            this.btFechar.UseVisualStyleBackColor = false;
            // 
            // FrmLancamento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.CancelButton = this.btFechar;
            this.ClientSize = new System.Drawing.Size(483, 366);
            this.Controls.Add(this.btFechar);
            this.Controls.Add(this.txtData);
            this.Controls.Add(this.fadingLabel);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.btnNovaCategoria);
            this.Controls.Add(this.cbCategoria);
            this.Controls.Add(this.txtValor);
            this.Controls.Add(this.txtDescricao);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmLancamento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lançamento";
            this.Load += new System.EventHandler(this.FrmLancamento_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDescricao;
        private component.NumTextBox txtValor;
        private System.Windows.Forms.ComboBox cbCategoria;
        private System.Windows.Forms.Button btnNovaCategoria;
        private System.Windows.Forms.Button btnSalvar;
        private component.FadingLabel fadingLabel;
        private System.Windows.Forms.MaskedTextBox txtData;
        private System.Windows.Forms.Button btFechar;
    }
}