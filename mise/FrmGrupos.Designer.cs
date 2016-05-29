namespace mise
{
    partial class FrmGrupos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmGrupos));
            this.gridGrupos = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolBtnNovo = new System.Windows.Forms.ToolStripButton();
            this.toolBtnAlterar = new System.Windows.Forms.ToolStripButton();
            this.toolBtnExcluir = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridGrupos)).BeginInit();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridGrupos
            // 
            this.gridGrupos.AllowUserToAddRows = false;
            this.gridGrupos.AllowUserToDeleteRows = false;
            this.gridGrupos.BackgroundColor = System.Drawing.SystemColors.Window;
            this.gridGrupos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gridGrupos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.gridGrupos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.gridGrupos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridGrupos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.Nome});
            this.gridGrupos.Location = new System.Drawing.Point(79, 14);
            this.gridGrupos.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gridGrupos.MultiSelect = false;
            this.gridGrupos.Name = "gridGrupos";
            this.gridGrupos.ReadOnly = true;
            this.gridGrupos.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.gridGrupos.RowHeadersWidth = 30;
            this.gridGrupos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gridGrupos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridGrupos.Size = new System.Drawing.Size(350, 381);
            this.gridGrupos.TabIndex = 1;
            this.gridGrupos.SelectionChanged += new System.EventHandler(this.gridGrupos_SelectionChanged);
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
            this.Nome.Width = 300;
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
            this.toolStrip.Size = new System.Drawing.Size(50, 409);
            this.toolStrip.TabIndex = 7;
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
            // FrmGrupos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(456, 409);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.gridGrupos);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmGrupos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Grupos";
            this.Load += new System.EventHandler(this.FrmGrupos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridGrupos)).EndInit();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gridGrupos;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton toolBtnNovo;
        private System.Windows.Forms.ToolStripButton toolBtnAlterar;
        private System.Windows.Forms.ToolStripButton toolBtnExcluir;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nome;
    }
}