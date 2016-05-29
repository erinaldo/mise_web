namespace mise
{
    partial class FrmConsultarPreco
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmConsultarPreco));
            this.gridProdutos = new System.Windows.Forms.DataGridView();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.rdCodigo = new System.Windows.Forms.RadioButton();
            this.rdNome = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtCodigo = new mise.component.NumTextBox();
            this.codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precoVenda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unidade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridProdutos)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridProdutos
            // 
            this.gridProdutos.AllowUserToAddRows = false;
            this.gridProdutos.AllowUserToDeleteRows = false;
            this.gridProdutos.AllowUserToResizeColumns = false;
            this.gridProdutos.AllowUserToResizeRows = false;
            this.gridProdutos.BackgroundColor = System.Drawing.SystemColors.Window;
            this.gridProdutos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gridProdutos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.gridProdutos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.gridProdutos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridProdutos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codigo,
            this.descricao,
            this.precoVenda,
            this.unidade});
            this.gridProdutos.Location = new System.Drawing.Point(27, 120);
            this.gridProdutos.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gridProdutos.MultiSelect = false;
            this.gridProdutos.Name = "gridProdutos";
            this.gridProdutos.ReadOnly = true;
            this.gridProdutos.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.gridProdutos.RowHeadersWidth = 30;
            this.gridProdutos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gridProdutos.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.gridProdutos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridProdutos.Size = new System.Drawing.Size(820, 357);
            this.gridProdutos.TabIndex = 7;
            // 
            // txtNome
            // 
            this.txtNome.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNome.Location = new System.Drawing.Point(15, 45);
            this.txtNome.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtNome.MaxLength = 20;
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(472, 26);
            this.txtNome.TabIndex = 10;
            this.txtNome.Visible = false;
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.SystemColors.Window;
            this.btnBuscar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscar.Location = new System.Drawing.Point(508, 41);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(112, 35);
            this.btnBuscar.TabIndex = 11;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // rdCodigo
            // 
            this.rdCodigo.AutoSize = true;
            this.rdCodigo.Checked = true;
            this.rdCodigo.Location = new System.Drawing.Point(15, 15);
            this.rdCodigo.Name = "rdCodigo";
            this.rdCodigo.Size = new System.Drawing.Size(77, 24);
            this.rdCodigo.TabIndex = 12;
            this.rdCodigo.TabStop = true;
            this.rdCodigo.Text = "Código";
            this.rdCodigo.UseVisualStyleBackColor = true;
            this.rdCodigo.CheckedChanged += new System.EventHandler(this.rdCodigo_CheckedChanged);
            // 
            // rdNome
            // 
            this.rdNome.AutoSize = true;
            this.rdNome.Location = new System.Drawing.Point(126, 15);
            this.rdNome.Name = "rdNome";
            this.rdNome.Size = new System.Drawing.Size(69, 24);
            this.rdNome.TabIndex = 13;
            this.rdNome.Text = "Nome";
            this.rdNome.UseVisualStyleBackColor = true;
            this.rdNome.CheckedChanged += new System.EventHandler(this.rdNome_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rdCodigo);
            this.panel1.Controls.Add(this.rdNome);
            this.panel1.Controls.Add(this.txtCodigo);
            this.panel1.Controls.Add(this.txtNome);
            this.panel1.Controls.Add(this.btnBuscar);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(697, 100);
            this.panel1.TabIndex = 14;
            // 
            // txtCodigo
            // 
            this.txtCodigo.AutoComma = false;
            this.txtCodigo.Dec = 0;
            this.txtCodigo.Location = new System.Drawing.Point(15, 45);
            this.txtCodigo.MaxLength = 18;
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(336, 26);
            this.txtCodigo.TabIndex = 0;
            // 
            // codigo
            // 
            this.codigo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.codigo.HeaderText = "Código";
            this.codigo.Name = "codigo";
            this.codigo.ReadOnly = true;
            this.codigo.Width = 220;
            // 
            // descricao
            // 
            this.descricao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.descricao.HeaderText = "Nome";
            this.descricao.Name = "descricao";
            this.descricao.ReadOnly = true;
            this.descricao.Width = 320;
            // 
            // precoVenda
            // 
            this.precoVenda.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.precoVenda.DefaultCellStyle = dataGridViewCellStyle1;
            this.precoVenda.HeaderText = "Preço Venda";
            this.precoVenda.Name = "precoVenda";
            this.precoVenda.ReadOnly = true;
            this.precoVenda.Width = 120;
            // 
            // unidade
            // 
            this.unidade.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.unidade.HeaderText = "Un Medida";
            this.unidade.Name = "unidade";
            this.unidade.ReadOnly = true;
            // 
            // FrmConsultarPreco
            // 
            this.AcceptButton = this.btnBuscar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(870, 501);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.gridProdutos);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmConsultarPreco";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consultar Preço";
            this.Shown += new System.EventHandler(this.FrmConsultarPreco_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.gridProdutos)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private component.NumTextBox txtCodigo;
        private System.Windows.Forms.DataGridView gridProdutos;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.RadioButton rdCodigo;
        private System.Windows.Forms.RadioButton rdNome;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn descricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn precoVenda;
        private System.Windows.Forms.DataGridViewTextBoxColumn unidade;
    }
}