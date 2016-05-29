namespace mise
{
    partial class FrmFornecedores
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmFornecedores));
            this.label1 = new System.Windows.Forms.Label();
            this.txtNomeFantasia = new System.Windows.Forms.TextBox();
            this.gridFornecedores = new System.Windows.Forms.DataGridView();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolBtnNovo = new System.Windows.Forms.ToolStripButton();
            this.toolBtnAlterar = new System.Windows.Forms.ToolStripButton();
            this.toolBtnExcluir = new System.Windows.Forms.ToolStripButton();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NomeFantasia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Contato = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Telefone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridFornecedores)).BeginInit();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(72, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nome Fantasia";
            // 
            // txtNomeFantasia
            // 
            this.txtNomeFantasia.Location = new System.Drawing.Point(76, 34);
            this.txtNomeFantasia.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtNomeFantasia.Name = "txtNomeFantasia";
            this.txtNomeFantasia.Size = new System.Drawing.Size(340, 26);
            this.txtNomeFantasia.TabIndex = 1;
            // 
            // gridFornecedores
            // 
            this.gridFornecedores.AllowUserToAddRows = false;
            this.gridFornecedores.AllowUserToDeleteRows = false;
            this.gridFornecedores.BackgroundColor = System.Drawing.SystemColors.Window;
            this.gridFornecedores.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gridFornecedores.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.gridFornecedores.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.gridFornecedores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridFornecedores.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.NomeFantasia,
            this.Contato,
            this.Telefone});
            this.gridFornecedores.Location = new System.Drawing.Point(76, 75);
            this.gridFornecedores.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gridFornecedores.MultiSelect = false;
            this.gridFornecedores.Name = "gridFornecedores";
            this.gridFornecedores.ReadOnly = true;
            this.gridFornecedores.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.gridFornecedores.RowHeadersWidth = 30;
            this.gridFornecedores.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gridFornecedores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridFornecedores.Size = new System.Drawing.Size(803, 488);
            this.gridFornecedores.TabIndex = 3;
            this.gridFornecedores.SelectionChanged += new System.EventHandler(this.gridFornecedores_SelectionChanged);
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.BackColor = System.Drawing.SystemColors.Window;
            this.btnPesquisar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPesquisar.Location = new System.Drawing.Point(424, 30);
            this.btnPesquisar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(112, 35);
            this.btnPesquisar.TabIndex = 2;
            this.btnPesquisar.Text = "Buscar";
            this.btnPesquisar.UseVisualStyleBackColor = false;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            // 
            // toolStrip
            // 
            this.toolStrip.AutoSize = false;
            this.toolStrip.Dock = System.Windows.Forms.DockStyle.Left;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolBtnNovo,
            this.toolBtnAlterar,
            this.toolBtnExcluir});
            this.toolStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(50, 588);
            this.toolStrip.TabIndex = 5;
            this.toolStrip.Text = "toolStrip1";
            // 
            // toolBtnNovo
            // 
            this.toolBtnNovo.AutoSize = false;
            this.toolBtnNovo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolBtnNovo.Image = ((System.Drawing.Image)(resources.GetObject("toolBtnNovo.Image")));
            this.toolBtnNovo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolBtnNovo.Name = "toolBtnNovo";
            this.toolBtnNovo.Size = new System.Drawing.Size(48, 48);
            this.toolBtnNovo.Text = "Novo";
            this.toolBtnNovo.Click += new System.EventHandler(this.toolBtnNovo_Click);
            // 
            // toolBtnAlterar
            // 
            this.toolBtnAlterar.AutoSize = false;
            this.toolBtnAlterar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolBtnAlterar.Enabled = false;
            this.toolBtnAlterar.Image = ((System.Drawing.Image)(resources.GetObject("toolBtnAlterar.Image")));
            this.toolBtnAlterar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolBtnAlterar.Name = "toolBtnAlterar";
            this.toolBtnAlterar.Size = new System.Drawing.Size(48, 48);
            this.toolBtnAlterar.Text = "Alterar";
            this.toolBtnAlterar.Click += new System.EventHandler(this.toolBtnAlterar_Click);
            // 
            // toolBtnExcluir
            // 
            this.toolBtnExcluir.AutoSize = false;
            this.toolBtnExcluir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolBtnExcluir.Enabled = false;
            this.toolBtnExcluir.Image = ((System.Drawing.Image)(resources.GetObject("toolBtnExcluir.Image")));
            this.toolBtnExcluir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolBtnExcluir.Name = "toolBtnExcluir";
            this.toolBtnExcluir.Size = new System.Drawing.Size(48, 48);
            this.toolBtnExcluir.Text = "Excluir";
            this.toolBtnExcluir.Click += new System.EventHandler(this.toolBtnExcluir_Click);
            // 
            // id
            // 
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // NomeFantasia
            // 
            this.NomeFantasia.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.NomeFantasia.HeaderText = "Nome Fantasia";
            this.NomeFantasia.Name = "NomeFantasia";
            this.NomeFantasia.ReadOnly = true;
            this.NomeFantasia.Width = 400;
            // 
            // Contato
            // 
            this.Contato.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Contato.HeaderText = "Contato";
            this.Contato.Name = "Contato";
            this.Contato.ReadOnly = true;
            this.Contato.Width = 200;
            // 
            // Telefone
            // 
            this.Telefone.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Telefone.HeaderText = "Telefone";
            this.Telefone.Name = "Telefone";
            this.Telefone.ReadOnly = true;
            this.Telefone.Width = 150;
            // 
            // FrmFornecedores
            // 
            this.AcceptButton = this.btnPesquisar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(905, 588);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.btnPesquisar);
            this.Controls.Add(this.gridFornecedores);
            this.Controls.Add(this.txtNomeFantasia);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmFornecedores";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fornecedores";
            this.Load += new System.EventHandler(this.FrmFornecedores_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridFornecedores)).EndInit();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNomeFantasia;
        private System.Windows.Forms.DataGridView gridFornecedores;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton toolBtnAlterar;
        private System.Windows.Forms.ToolStripButton toolBtnNovo;
        private System.Windows.Forms.ToolStripButton toolBtnExcluir;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn NomeFantasia;
        private System.Windows.Forms.DataGridViewTextBoxColumn Contato;
        private System.Windows.Forms.DataGridViewTextBoxColumn Telefone;
    }
}