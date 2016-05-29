namespace mise
{
    partial class FrmProdutos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmProdutos));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gridProdutos = new System.Windows.Forms.DataGridView();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.toolBar = new System.Windows.Forms.ToolStrip();
            this.toolBtnNovo = new System.Windows.Forms.ToolStripButton();
            this.toolBtnAlterar = new System.Windows.Forms.ToolStripButton();
            this.toolBtnExcluir = new System.Windows.Forms.ToolStripButton();
            this.codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precoVenda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridProdutos)).BeginInit();
            this.toolBar.SuspendLayout();
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
            this.precoVenda});
            this.gridProdutos.Location = new System.Drawing.Point(69, 83);
            this.gridProdutos.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gridProdutos.MultiSelect = false;
            this.gridProdutos.Name = "gridProdutos";
            this.gridProdutos.ReadOnly = true;
            this.gridProdutos.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.gridProdutos.RowHeadersWidth = 30;
            this.gridProdutos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gridProdutos.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.gridProdutos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridProdutos.Size = new System.Drawing.Size(716, 630);
            this.gridProdutos.TabIndex = 6;
            this.gridProdutos.SelectionChanged += new System.EventHandler(this.gridProdutos_SelectionChanged);
            // 
            // txtDescricao
            // 
            this.txtDescricao.Location = new System.Drawing.Point(69, 34);
            this.txtDescricao.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtDescricao.MaxLength = 20;
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(269, 26);
            this.txtDescricao.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(65, 9);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Nome";
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.SystemColors.Window;
            this.btnBuscar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscar.Location = new System.Drawing.Point(346, 30);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(112, 35);
            this.btnBuscar.TabIndex = 5;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // toolBar
            // 
            this.toolBar.AutoSize = false;
            this.toolBar.Dock = System.Windows.Forms.DockStyle.Left;
            this.toolBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolBtnNovo,
            this.toolBtnAlterar,
            this.toolBtnExcluir});
            this.toolBar.Location = new System.Drawing.Point(0, 0);
            this.toolBar.Name = "toolBar";
            this.toolBar.Size = new System.Drawing.Size(50, 741);
            this.toolBar.TabIndex = 8;
            this.toolBar.Text = "toolStrip1";
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
            this.descricao.Width = 340;
            // 
            // precoVenda
            // 
            this.precoVenda.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.precoVenda.DefaultCellStyle = dataGridViewCellStyle1;
            this.precoVenda.HeaderText = "Preço Venda";
            this.precoVenda.Name = "precoVenda";
            this.precoVenda.ReadOnly = true;
            // 
            // FrmProdutos
            // 
            this.AcceptButton = this.btnBuscar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(824, 741);
            this.Controls.Add(this.toolBar);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.txtDescricao);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.gridProdutos);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmProdutos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Produtos";
            this.Load += new System.EventHandler(this.FrmProdutos2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridProdutos)).EndInit();
            this.toolBar.ResumeLayout(false);
            this.toolBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gridProdutos;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.ToolStrip toolBar;
        private System.Windows.Forms.ToolStripButton toolBtnAlterar;
        private System.Windows.Forms.ToolStripButton toolBtnNovo;
        private System.Windows.Forms.ToolStripButton toolBtnExcluir;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn descricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn precoVenda;
    }
}