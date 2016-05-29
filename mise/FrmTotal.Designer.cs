using mise.component;
namespace mise
{
    partial class FrmTotal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTotal));
            this.label1 = new System.Windows.Forms.Label();
            this.cbxTipoPagamento = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblTroco = new System.Windows.Forms.Label();
            this.gridPagamento = new System.Windows.Forms.DataGridView();
            this.tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.lblRestante = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblTotalPago = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtValor = new mise.component.NumTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.gridPagamento)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(433, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Valor";
            // 
            // cbxTipoPagamento
            // 
            this.cbxTipoPagamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxTipoPagamento.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbxTipoPagamento.FormattingEnabled = true;
            this.cbxTipoPagamento.Location = new System.Drawing.Point(147, 29);
            this.cbxTipoPagamento.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbxTipoPagamento.Name = "cbxTipoPagamento";
            this.cbxTipoPagamento.Size = new System.Drawing.Size(264, 28);
            this.cbxTipoPagamento.TabIndex = 0;
            this.cbxTipoPagamento.SelectedIndexChanged += new System.EventHandler(this.cbxTipoPagamento_SelectedIndexChanged);
            this.cbxTipoPagamento.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbxTipoPagamento_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(143, 9);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(163, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Forma de Pagamento";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(373, 115);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Troco";
            // 
            // lblTroco
            // 
            this.lblTroco.AutoSize = true;
            this.lblTroco.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTroco.Location = new System.Drawing.Point(373, 135);
            this.lblTroco.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTroco.Name = "lblTroco";
            this.lblTroco.Size = new System.Drawing.Size(72, 20);
            this.lblTroco.TabIndex = 5;
            this.lblTroco.Text = "R$ 0,00";
            // 
            // gridPagamento
            // 
            this.gridPagamento.AllowUserToAddRows = false;
            this.gridPagamento.AllowUserToDeleteRows = false;
            this.gridPagamento.BackgroundColor = System.Drawing.SystemColors.Window;
            this.gridPagamento.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gridPagamento.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.gridPagamento.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridPagamento.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tipo,
            this.valor});
            this.gridPagamento.Location = new System.Drawing.Point(10, 27);
            this.gridPagamento.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gridPagamento.Name = "gridPagamento";
            this.gridPagamento.ReadOnly = true;
            this.gridPagamento.RowHeadersVisible = false;
            this.gridPagamento.Size = new System.Drawing.Size(355, 136);
            this.gridPagamento.TabIndex = 6;
            // 
            // tipo
            // 
            this.tipo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.tipo.HeaderText = "Forma Pagamento";
            this.tipo.Name = "tipo";
            this.tipo.ReadOnly = true;
            this.tipo.Width = 250;
            // 
            // valor
            // 
            this.valor.HeaderText = "Valor";
            this.valor.Name = "valor";
            this.valor.ReadOnly = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(373, 71);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Restante";
            // 
            // lblRestante
            // 
            this.lblRestante.AutoSize = true;
            this.lblRestante.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRestante.Location = new System.Drawing.Point(373, 91);
            this.lblRestante.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRestante.Name = "lblRestante";
            this.lblRestante.Size = new System.Drawing.Size(72, 20);
            this.lblRestante.TabIndex = 8;
            this.lblRestante.Text = "R$ 0,00";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(255, 271);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(158, 20);
            this.label5.TabIndex = 9;
            this.label5.Text = "F10 - Concluir Venda";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(13, 37);
            this.lblTotal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(82, 20);
            this.lblTotal.TabIndex = 12;
            this.lblTotal.Text = "R$ 00,00";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 9);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 20);
            this.label8.TabIndex = 11;
            this.label8.Text = "Total";
            // 
            // lblTotalPago
            // 
            this.lblTotalPago.AutoSize = true;
            this.lblTotalPago.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalPago.Location = new System.Drawing.Point(373, 47);
            this.lblTotalPago.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalPago.Name = "lblTotalPago";
            this.lblTotalPago.Size = new System.Drawing.Size(72, 20);
            this.lblTotalPago.TabIndex = 14;
            this.lblTotalPago.Text = "R$ 0,00";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(373, 27);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(85, 20);
            this.label9.TabIndex = 13;
            this.label9.Text = "Total Pago";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 271);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(195, 20);
            this.label6.TabIndex = 15;
            this.label6.Text = "F9 - Forma de Pagamento";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.gridPagamento);
            this.groupBox1.Controls.Add(this.lblTotalPago);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.lblRestante);
            this.groupBox1.Controls.Add(this.lblTroco);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(7, 70);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(541, 183);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Pagamentos";
            // 
            // txtValor
            // 
            this.txtValor.AutoComma = false;
            this.txtValor.Dec = 2;
            this.txtValor.Location = new System.Drawing.Point(437, 32);
            this.txtValor.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtValor.Name = "txtValor";
            this.txtValor.Size = new System.Drawing.Size(111, 26);
            this.txtValor.TabIndex = 0;
            this.txtValor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtValor_KeyDown);
            // 
            // FrmTotal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(560, 308);
            this.Controls.Add(this.cbxTipoPagamento);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtValor);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmTotal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Total";
            this.Shown += new System.EventHandler(this.FrmTotal_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmPagamento_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.gridPagamento)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private NumTextBox txtValor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxTipoPagamento;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblTroco;
        private System.Windows.Forms.DataGridView gridPagamento;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblRestante;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblTotalPago;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn valor;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}