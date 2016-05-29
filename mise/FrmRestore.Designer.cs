namespace mise
{
    partial class FrmRestore
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRestore));
            this.btnSelecionar = new System.Windows.Forms.Button();
            this.txtArquivo = new System.Windows.Forms.TextBox();
            this.btnRestaurar = new System.Windows.Forms.Button();
            this.bgWorker = new System.ComponentModel.BackgroundWorker();
            this.lblRestaurado = new mise.component.FadingLabel();
            this.SuspendLayout();
            // 
            // btnSelecionar
            // 
            this.btnSelecionar.BackColor = System.Drawing.SystemColors.Window;
            this.btnSelecionar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSelecionar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelecionar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSelecionar.Location = new System.Drawing.Point(13, 14);
            this.btnSelecionar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSelecionar.Name = "btnSelecionar";
            this.btnSelecionar.Size = new System.Drawing.Size(112, 35);
            this.btnSelecionar.TabIndex = 6;
            this.btnSelecionar.Text = "Arquivo...";
            this.btnSelecionar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSelecionar.UseVisualStyleBackColor = false;
            this.btnSelecionar.Click += new System.EventHandler(this.btnSelecionar_Click);
            // 
            // txtArquivo
            // 
            this.txtArquivo.Location = new System.Drawing.Point(13, 57);
            this.txtArquivo.Name = "txtArquivo";
            this.txtArquivo.Size = new System.Drawing.Size(506, 26);
            this.txtArquivo.TabIndex = 7;
            // 
            // btnRestaurar
            // 
            this.btnRestaurar.BackColor = System.Drawing.SystemColors.Window;
            this.btnRestaurar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRestaurar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRestaurar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRestaurar.Location = new System.Drawing.Point(375, 118);
            this.btnRestaurar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnRestaurar.Name = "btnRestaurar";
            this.btnRestaurar.Size = new System.Drawing.Size(144, 35);
            this.btnRestaurar.TabIndex = 8;
            this.btnRestaurar.Text = "Restaurar";
            this.btnRestaurar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRestaurar.UseVisualStyleBackColor = false;
            this.btnRestaurar.Click += new System.EventHandler(this.btnRestaurar_Click);
            // 
            // bgWorker
            // 
            this.bgWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorker_DoWork);
            // 
            // lblRestaurado
            // 
            this.lblRestaurado.AutoSize = true;
            this.lblRestaurado.FadingSpeed = 10;
            this.lblRestaurado.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRestaurado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lblRestaurado.InitialColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lblRestaurado.Location = new System.Drawing.Point(12, 125);
            this.lblRestaurado.Name = "lblRestaurado";
            this.lblRestaurado.Size = new System.Drawing.Size(123, 20);
            this.lblRestaurado.TabIndex = 22;
            this.lblRestaurado.Text = "✓ Restaurado!";
            this.lblRestaurado.Visible = false;
            // 
            // FrmRestore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(531, 179);
            this.Controls.Add(this.lblRestaurado);
            this.Controls.Add(this.btnRestaurar);
            this.Controls.Add(this.txtArquivo);
            this.Controls.Add(this.btnSelecionar);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmRestore";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Restaurar Backup";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSelecionar;
        private System.Windows.Forms.TextBox txtArquivo;
        private System.Windows.Forms.Button btnRestaurar;
        private System.ComponentModel.BackgroundWorker bgWorker;
        private component.FadingLabel lblRestaurado;
    }
}