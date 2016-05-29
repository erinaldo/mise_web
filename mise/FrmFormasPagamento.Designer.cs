namespace mise
{
    partial class FrmFormasPagamento
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmFormasPagamento));
            this.gridFormasPagamento = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Indice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolBtnNovo = new System.Windows.Forms.ToolStripButton();
            this.toolBtnAlterar = new System.Windows.Forms.ToolStripButton();
            this.toolBtnExcluir = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.toolBtnUp = new System.Windows.Forms.ToolStripButton();
            this.toolBtnDown = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridFormasPagamento)).BeginInit();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridFormasPagamento
            // 
            this.gridFormasPagamento.AllowUserToAddRows = false;
            this.gridFormasPagamento.AllowUserToDeleteRows = false;
            this.gridFormasPagamento.BackgroundColor = System.Drawing.SystemColors.Window;
            this.gridFormasPagamento.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gridFormasPagamento.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.gridFormasPagamento.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.gridFormasPagamento.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridFormasPagamento.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.Indice,
            this.Nome});
            this.gridFormasPagamento.Location = new System.Drawing.Point(67, 14);
            this.gridFormasPagamento.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gridFormasPagamento.MultiSelect = false;
            this.gridFormasPagamento.Name = "gridFormasPagamento";
            this.gridFormasPagamento.ReadOnly = true;
            this.gridFormasPagamento.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.gridFormasPagamento.RowHeadersWidth = 30;
            this.gridFormasPagamento.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gridFormasPagamento.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridFormasPagamento.Size = new System.Drawing.Size(414, 431);
            this.gridFormasPagamento.TabIndex = 0;
            this.gridFormasPagamento.SelectionChanged += new System.EventHandler(this.gridFormasPagamento_SelectionChanged);
            // 
            // id
            // 
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.id.Visible = false;
            // 
            // Indice
            // 
            this.Indice.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Indice.HeaderText = "Ordem";
            this.Indice.Name = "Indice";
            this.Indice.ReadOnly = true;
            this.Indice.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Indice.Width = 80;
            // 
            // Nome
            // 
            this.Nome.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Nome.HeaderText = "Nome";
            this.Nome.Name = "Nome";
            this.Nome.ReadOnly = true;
            this.Nome.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Nome.Width = 300;
            // 
            // toolStrip
            // 
            this.toolStrip.AutoSize = false;
            this.toolStrip.Dock = System.Windows.Forms.DockStyle.Left;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolBtnNovo,
            this.toolBtnAlterar,
            this.toolBtnExcluir,
            this.toolStripLabel2,
            this.toolBtnUp,
            this.toolBtnDown});
            this.toolStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(50, 459);
            this.toolStrip.TabIndex = 6;
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
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(48, 15);
            this.toolStripLabel2.Text = "                      ";
            // 
            // toolBtnUp
            // 
            this.toolBtnUp.AutoSize = false;
            this.toolBtnUp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolBtnUp.Enabled = false;
            this.toolBtnUp.Image = ((System.Drawing.Image)(resources.GetObject("toolBtnUp.Image")));
            this.toolBtnUp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolBtnUp.Name = "toolBtnUp";
            this.toolBtnUp.Size = new System.Drawing.Size(48, 48);
            this.toolBtnUp.Text = "Excluir";
            this.toolBtnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // toolBtnDown
            // 
            this.toolBtnDown.AutoSize = false;
            this.toolBtnDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolBtnDown.Enabled = false;
            this.toolBtnDown.Image = ((System.Drawing.Image)(resources.GetObject("toolBtnDown.Image")));
            this.toolBtnDown.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolBtnDown.Name = "toolBtnDown";
            this.toolBtnDown.Size = new System.Drawing.Size(48, 48);
            this.toolBtnDown.Text = "Excluir";
            this.toolBtnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // FrmFormasPagamento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(513, 459);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.gridFormasPagamento);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmFormasPagamento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Formas de Pagamento";
            this.Load += new System.EventHandler(this.FrmFormasPagamento_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridFormasPagamento)).EndInit();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gridFormasPagamento;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton toolBtnNovo;
        private System.Windows.Forms.ToolStripButton toolBtnAlterar;
        private System.Windows.Forms.ToolStripButton toolBtnExcluir;
        private System.Windows.Forms.ToolStripButton toolBtnUp;
        private System.Windows.Forms.ToolStripButton toolBtnDown;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Indice;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nome;
    }
}