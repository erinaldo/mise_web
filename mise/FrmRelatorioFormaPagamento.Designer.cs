namespace mise
{
    partial class FrmRelatorioFormaPagamento
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRelatorioFormaPagamento));
            this.gridPagamentos = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnVisualizar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btImprimir = new System.Windows.Forms.Button();
            this.dtIni = new System.Windows.Forms.DateTimePicker();
            this.dtFim = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.gridPagamentos)).BeginInit();
            this.SuspendLayout();
            // 
            // gridPagamentos
            // 
            this.gridPagamentos.AllowUserToAddRows = false;
            this.gridPagamentos.AllowUserToDeleteRows = false;
            this.gridPagamentos.BackgroundColor = System.Drawing.SystemColors.Window;
            this.gridPagamentos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gridPagamentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridPagamentos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn4});
            this.gridPagamentos.Location = new System.Drawing.Point(12, 71);
            this.gridPagamentos.Name = "gridPagamentos";
            this.gridPagamentos.ReadOnly = true;
            this.gridPagamentos.RowHeadersVisible = false;
            this.gridPagamentos.Size = new System.Drawing.Size(485, 353);
            this.gridPagamentos.TabIndex = 31;
            this.gridPagamentos.SortCompare += new System.Windows.Forms.DataGridViewSortCompareEventHandler(this.gridPagamentos_SortCompare);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn1.HeaderText = "Forma de Pagamento";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 340;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewTextBoxColumn4.HeaderText = "Total";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 120;
            // 
            // btnVisualizar
            // 
            this.btnVisualizar.BackColor = System.Drawing.SystemColors.Window;
            this.btnVisualizar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnVisualizar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnVisualizar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightGray;
            this.btnVisualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVisualizar.ForeColor = System.Drawing.Color.Black;
            this.btnVisualizar.Location = new System.Drawing.Point(385, 28);
            this.btnVisualizar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnVisualizar.Name = "btnVisualizar";
            this.btnVisualizar.Size = new System.Drawing.Size(112, 35);
            this.btnVisualizar.TabIndex = 36;
            this.btnVisualizar.Text = "Visualizar";
            this.btnVisualizar.UseVisualStyleBackColor = false;
            this.btnVisualizar.Click += new System.EventHandler(this.btnVisualizar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(182, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 20);
            this.label2.TabIndex = 34;
            this.label2.Text = "Data Final";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 20);
            this.label1.TabIndex = 32;
            this.label1.Text = "Data Inicial";
            // 
            // btImprimir
            // 
            this.btImprimir.BackColor = System.Drawing.SystemColors.Window;
            this.btImprimir.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btImprimir.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btImprimir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightGray;
            this.btImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btImprimir.ForeColor = System.Drawing.Color.Black;
            this.btImprimir.Location = new System.Drawing.Point(385, 432);
            this.btImprimir.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btImprimir.Name = "btImprimir";
            this.btImprimir.Size = new System.Drawing.Size(112, 35);
            this.btImprimir.TabIndex = 37;
            this.btImprimir.Text = "Imprimir";
            this.btImprimir.UseVisualStyleBackColor = false;
            this.btImprimir.Click += new System.EventHandler(this.btImprimir_Click);
            // 
            // dtIni
            // 
            this.dtIni.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtIni.Location = new System.Drawing.Point(16, 32);
            this.dtIni.Name = "dtIni";
            this.dtIni.Size = new System.Drawing.Size(135, 26);
            this.dtIni.TabIndex = 38;
            // 
            // dtFim
            // 
            this.dtFim.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFim.Location = new System.Drawing.Point(186, 32);
            this.dtFim.Name = "dtFim";
            this.dtFim.Size = new System.Drawing.Size(142, 26);
            this.dtFim.TabIndex = 39;
            // 
            // FrmRelatorioFormaPagamento
            // 
            this.AcceptButton = this.btnVisualizar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(523, 481);
            this.Controls.Add(this.dtFim);
            this.Controls.Add(this.dtIni);
            this.Controls.Add(this.btImprimir);
            this.Controls.Add(this.btnVisualizar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gridPagamentos);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmRelatorioFormaPagamento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Relatório Analítico - Por Forma de Pagamento";
            this.Load += new System.EventHandler(this.FrmRelatorioFormaPagamento_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridPagamentos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gridPagamentos;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.Button btnVisualizar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btImprimir;
        private System.Windows.Forms.DateTimePicker dtIni;
        private System.Windows.Forms.DateTimePicker dtFim;
    }
}