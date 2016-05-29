namespace mise
{
    partial class FrmCategorias
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCategorias));
            this.gridCategorias = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolBtnNovo = new System.Windows.Forms.ToolStripButton();
            this.toolBtnAlterar = new System.Windows.Forms.ToolStripButton();
            this.toolBtnExcluir = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridCategorias)).BeginInit();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridCategorias
            // 
            this.gridCategorias.AllowUserToAddRows = false;
            this.gridCategorias.AllowUserToDeleteRows = false;
            this.gridCategorias.BackgroundColor = System.Drawing.SystemColors.Window;
            this.gridCategorias.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gridCategorias.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.gridCategorias.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.gridCategorias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridCategorias.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.Nome});
            this.gridCategorias.Location = new System.Drawing.Point(54, 14);
            this.gridCategorias.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gridCategorias.MultiSelect = false;
            this.gridCategorias.Name = "gridCategorias";
            this.gridCategorias.ReadOnly = true;
            this.gridCategorias.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.gridCategorias.RowHeadersWidth = 30;
            this.gridCategorias.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gridCategorias.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridCategorias.Size = new System.Drawing.Size(553, 380);
            this.gridCategorias.TabIndex = 3;
            this.gridCategorias.SelectionChanged += new System.EventHandler(this.gridCategorias_SelectionChanged);
            // 
            // id
            // 
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // Nome
            // 
            this.Nome.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Nome.HeaderText = "Nome";
            this.Nome.Name = "Nome";
            this.Nome.ReadOnly = true;
            this.Nome.Width = 500;
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
            this.toolStrip.Size = new System.Drawing.Size(50, 419);
            this.toolStrip.TabIndex = 9;
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
            // FrmCategorias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(637, 419);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.gridCategorias);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCategorias";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Categorias";
            this.Load += new System.EventHandler(this.FrmCategorias_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridCategorias)).EndInit();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gridCategorias;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton toolBtnNovo;
        private System.Windows.Forms.ToolStripButton toolBtnAlterar;
        private System.Windows.Forms.ToolStripButton toolBtnExcluir;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nome;
    }
}