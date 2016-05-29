using mise.component;
namespace mise
{
    partial class FrmProduto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmProduto));
            this.label1 = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtUnMedida = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.cbGrupo = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cbFornecedor = new System.Windows.Forms.ComboBox();
            this.btnNovoGrupo = new System.Windows.Forms.Button();
            this.btnNovoFornecedor = new System.Windows.Forms.Button();
            this.lblSalvo = new mise.component.FadingLabel();
            this.txtPrecoCusto = new mise.component.NumTextBox();
            this.txtPrecoVenda = new mise.component.NumTextBox();
            this.txtCodigo = new mise.component.NumTextBox();
            this.btFechar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(19, 19);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Código";
            // 
            // txtNome
            // 
            this.txtNome.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNome.Location = new System.Drawing.Point(23, 100);
            this.txtNome.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtNome.MaxLength = 20;
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(474, 26);
            this.txtNome.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(19, 75);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nome";
            // 
            // txtDescricao
            // 
            this.txtDescricao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescricao.Location = new System.Drawing.Point(23, 156);
            this.txtDescricao.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtDescricao.MaxLength = 50;
            this.txtDescricao.Multiline = true;
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(474, 52);
            this.txtDescricao.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(19, 131);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Descrição";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(19, 213);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Preço Venda";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(19, 269);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "Preço Custo";
            // 
            // txtUnMedida
            // 
            this.txtUnMedida.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtUnMedida.Location = new System.Drawing.Point(23, 350);
            this.txtUnMedida.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtUnMedida.MaxLength = 2;
            this.txtUnMedida.Name = "txtUnMedida";
            this.txtUnMedida.Size = new System.Drawing.Size(110, 26);
            this.txtUnMedida.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(19, 325);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 20);
            this.label6.TabIndex = 10;
            this.label6.Text = "Un. Medida";
            // 
            // btnSalvar
            // 
            this.btnSalvar.BackColor = System.Drawing.SystemColors.Window;
            this.btnSalvar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSalvar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnSalvar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightGray;
            this.btnSalvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalvar.ForeColor = System.Drawing.Color.Black;
            this.btnSalvar.Location = new System.Drawing.Point(313, 506);
            this.btnSalvar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(112, 35);
            this.btnSalvar.TabIndex = 20;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = false;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // cbGrupo
            // 
            this.cbGrupo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbGrupo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbGrupo.FormattingEnabled = true;
            this.cbGrupo.Location = new System.Drawing.Point(23, 406);
            this.cbGrupo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbGrupo.Name = "cbGrupo";
            this.cbGrupo.Size = new System.Drawing.Size(474, 28);
            this.cbGrupo.TabIndex = 13;
            this.cbGrupo.Leave += new System.EventHandler(this.cbGrupo_Leave);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(19, 381);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 20);
            this.label7.TabIndex = 14;
            this.label7.Text = "Grupo";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(19, 439);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(91, 20);
            this.label8.TabIndex = 16;
            this.label8.Text = "Fornecedor";
            // 
            // cbFornecedor
            // 
            this.cbFornecedor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbFornecedor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbFornecedor.FormattingEnabled = true;
            this.cbFornecedor.Location = new System.Drawing.Point(23, 464);
            this.cbFornecedor.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbFornecedor.Name = "cbFornecedor";
            this.cbFornecedor.Size = new System.Drawing.Size(474, 28);
            this.cbFornecedor.TabIndex = 15;
            this.cbFornecedor.Leave += new System.EventHandler(this.cbFornecedor_Leave);
            // 
            // btnNovoGrupo
            // 
            this.btnNovoGrupo.BackColor = System.Drawing.SystemColors.Window;
            this.btnNovoGrupo.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnNovoGrupo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnNovoGrupo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightGray;
            this.btnNovoGrupo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNovoGrupo.ForeColor = System.Drawing.Color.Black;
            this.btnNovoGrupo.Location = new System.Drawing.Point(505, 402);
            this.btnNovoGrupo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnNovoGrupo.Name = "btnNovoGrupo";
            this.btnNovoGrupo.Size = new System.Drawing.Size(40, 35);
            this.btnNovoGrupo.TabIndex = 22;
            this.btnNovoGrupo.Text = "...";
            this.btnNovoGrupo.UseVisualStyleBackColor = false;
            this.btnNovoGrupo.Click += new System.EventHandler(this.btnNovoGrupo_Click);
            // 
            // btnNovoFornecedor
            // 
            this.btnNovoFornecedor.BackColor = System.Drawing.SystemColors.Window;
            this.btnNovoFornecedor.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnNovoFornecedor.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnNovoFornecedor.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightGray;
            this.btnNovoFornecedor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNovoFornecedor.ForeColor = System.Drawing.Color.Black;
            this.btnNovoFornecedor.Location = new System.Drawing.Point(505, 460);
            this.btnNovoFornecedor.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnNovoFornecedor.Name = "btnNovoFornecedor";
            this.btnNovoFornecedor.Size = new System.Drawing.Size(40, 35);
            this.btnNovoFornecedor.TabIndex = 23;
            this.btnNovoFornecedor.Text = "...";
            this.btnNovoFornecedor.UseVisualStyleBackColor = false;
            this.btnNovoFornecedor.Click += new System.EventHandler(this.btnNovoFornecedor_Click);
            // 
            // lblSalvo
            // 
            this.lblSalvo.AutoSize = true;
            this.lblSalvo.FadingSpeed = 10;
            this.lblSalvo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSalvo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lblSalvo.InitialColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lblSalvo.Location = new System.Drawing.Point(19, 513);
            this.lblSalvo.Name = "lblSalvo";
            this.lblSalvo.Size = new System.Drawing.Size(73, 20);
            this.lblSalvo.TabIndex = 21;
            this.lblSalvo.Text = "✓ Salvo!";
            this.lblSalvo.Visible = false;
            // 
            // txtPrecoCusto
            // 
            this.txtPrecoCusto.AutoComma = false;
            this.txtPrecoCusto.Dec = 2;
            this.txtPrecoCusto.Location = new System.Drawing.Point(23, 294);
            this.txtPrecoCusto.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPrecoCusto.MaxLength = 6;
            this.txtPrecoCusto.Name = "txtPrecoCusto";
            this.txtPrecoCusto.Size = new System.Drawing.Size(110, 26);
            this.txtPrecoCusto.TabIndex = 9;
            // 
            // txtPrecoVenda
            // 
            this.txtPrecoVenda.AutoComma = false;
            this.txtPrecoVenda.Dec = 2;
            this.txtPrecoVenda.Location = new System.Drawing.Point(23, 238);
            this.txtPrecoVenda.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPrecoVenda.MaxLength = 6;
            this.txtPrecoVenda.Name = "txtPrecoVenda";
            this.txtPrecoVenda.Size = new System.Drawing.Size(110, 26);
            this.txtPrecoVenda.TabIndex = 7;
            // 
            // txtCodigo
            // 
            this.txtCodigo.AutoComma = false;
            this.txtCodigo.Dec = 0;
            this.txtCodigo.Location = new System.Drawing.Point(23, 44);
            this.txtCodigo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCodigo.MaxLength = 18;
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(402, 26);
            this.txtCodigo.TabIndex = 1;
            // 
            // btFechar
            // 
            this.btFechar.BackColor = System.Drawing.SystemColors.Window;
            this.btFechar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btFechar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btFechar.Location = new System.Drawing.Point(433, 506);
            this.btFechar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btFechar.Name = "btFechar";
            this.btFechar.Size = new System.Drawing.Size(112, 35);
            this.btFechar.TabIndex = 24;
            this.btFechar.Text = "Fechar";
            this.btFechar.UseVisualStyleBackColor = false;
            // 
            // FrmProduto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(567, 567);
            this.Controls.Add(this.btFechar);
            this.Controls.Add(this.btnNovoFornecedor);
            this.Controls.Add(this.btnNovoGrupo);
            this.Controls.Add(this.lblSalvo);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cbFornecedor);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cbGrupo);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.txtUnMedida);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtPrecoCusto);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtPrecoVenda);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtDescricao);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCodigo);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmProduto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Produto";
            this.Load += new System.EventHandler(this.FrmProduto_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private NumTextBox txtCodigo;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private NumTextBox txtPrecoCusto;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtUnMedida;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.ComboBox cbGrupo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbFornecedor;
        private NumTextBox txtPrecoVenda;
        private FadingLabel lblSalvo;
        private System.Windows.Forms.Button btnNovoGrupo;
        private System.Windows.Forms.Button btnNovoFornecedor;
        private System.Windows.Forms.Button btFechar;
    }
}