using mise.component;
namespace mise
{
    partial class FrmMain
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.lblQtd = new System.Windows.Forms.Label();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.gridItem = new System.Windows.Forms.DataGridView();
            this.sequencial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precoUn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qtd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Unidade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subtotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblTotal = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblPreco = new System.Windows.Forms.Label();
            this.grpItem = new System.Windows.Forms.GroupBox();
            this.txtQtd = new mise.component.NumTextBox();
            this.txtPreco = new mise.component.NumTextBox();
            this.txtCodigo = new mise.component.NumTextBox();
            this.grpTotal = new System.Windows.Forms.GroupBox();
            this.grpProduto = new System.Windows.Forms.GroupBox();
            this.lblProduto = new System.Windows.Forms.Label();
            this.grpItens = new System.Windows.Forms.GroupBox();
            this.menu = new System.Windows.Forms.MenuStrip();
            this.menuItemCadastros = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemProdutos = new System.Windows.Forms.ToolStripMenuItem();
            this.fornecedoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gruposToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.formasDePagamentoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lançamentosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.doDiaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.categoriasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripResumo = new System.Windows.Forms.ToolStripMenuItem();
            this.resumoDiarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.analíticoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemSair = new System.Windows.Forms.ToolStripMenuItem();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.lblDataHora = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.bgWorker = new System.ComponentModel.BackgroundWorker();
            this.timerDataHora = new System.Windows.Forms.Timer(this.components);
            this.doDiaToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.gridItem)).BeginInit();
            this.grpItem.SuspendLayout();
            this.grpTotal.SuspendLayout();
            this.grpProduto.SuspendLayout();
            this.grpItens.SuspendLayout();
            this.menu.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblQtd
            // 
            this.lblQtd.AutoSize = true;
            this.lblQtd.Location = new System.Drawing.Point(7, 22);
            this.lblQtd.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblQtd.Name = "lblQtd";
            this.lblQtd.Size = new System.Drawing.Size(79, 20);
            this.lblQtd.TabIndex = 0;
            this.lblQtd.Text = "Qtd/ Peso";
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.BackColor = System.Drawing.SystemColors.Window;
            this.lblCodigo.Location = new System.Drawing.Point(7, 78);
            this.lblCodigo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(59, 20);
            this.lblCodigo.TabIndex = 2;
            this.lblCodigo.Text = "Código";
            // 
            // gridItem
            // 
            this.gridItem.AllowUserToAddRows = false;
            this.gridItem.AllowUserToDeleteRows = false;
            this.gridItem.AllowUserToResizeColumns = false;
            this.gridItem.AllowUserToResizeRows = false;
            this.gridItem.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.gridItem.BackgroundColor = System.Drawing.SystemColors.Window;
            this.gridItem.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridItem.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.gridItem.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.gridItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridItem.ColumnHeadersVisible = false;
            this.gridItem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.sequencial,
            this.codigo,
            this.nome,
            this.precoUn,
            this.qtd,
            this.Unidade,
            this.subtotal});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.Padding = new System.Windows.Forms.Padding(2);
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridItem.DefaultCellStyle = dataGridViewCellStyle5;
            this.gridItem.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gridItem.GridColor = System.Drawing.Color.White;
            this.gridItem.Location = new System.Drawing.Point(11, 27);
            this.gridItem.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gridItem.MultiSelect = false;
            this.gridItem.Name = "gridItem";
            this.gridItem.ReadOnly = true;
            this.gridItem.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridItem.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.gridItem.RowHeadersVisible = false;
            this.gridItem.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gridItem.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.gridItem.ShowEditingIcon = false;
            this.gridItem.Size = new System.Drawing.Size(974, 495);
            this.gridItem.TabIndex = 4;
            this.gridItem.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.gridItem_RowsAdded);
            this.gridItem.Click += new System.EventHandler(this.gridItem_Click);
            this.gridItem.Enter += new System.EventHandler(this.gridItem_Enter);
            // 
            // sequencial
            // 
            this.sequencial.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.sequencial.HeaderText = "#";
            this.sequencial.Name = "sequencial";
            this.sequencial.ReadOnly = true;
            this.sequencial.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.sequencial.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.sequencial.Width = 43;
            // 
            // codigo
            // 
            this.codigo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.codigo.HeaderText = "Código";
            this.codigo.Name = "codigo";
            this.codigo.ReadOnly = true;
            this.codigo.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.codigo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.codigo.Width = 210;
            // 
            // nome
            // 
            this.nome.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.nome.HeaderText = "Produto";
            this.nome.Name = "nome";
            this.nome.ReadOnly = true;
            this.nome.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.nome.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.nome.Width = 240;
            // 
            // precoUn
            // 
            this.precoUn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.precoUn.DefaultCellStyle = dataGridViewCellStyle1;
            this.precoUn.HeaderText = "Preço Un";
            this.precoUn.Name = "precoUn";
            this.precoUn.ReadOnly = true;
            this.precoUn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.precoUn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.precoUn.Width = 120;
            // 
            // qtd
            // 
            this.qtd.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.qtd.DefaultCellStyle = dataGridViewCellStyle2;
            this.qtd.HeaderText = "Qtd";
            this.qtd.Name = "qtd";
            this.qtd.ReadOnly = true;
            this.qtd.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.qtd.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.qtd.Width = 120;
            // 
            // Unidade
            // 
            this.Unidade.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Unidade.DefaultCellStyle = dataGridViewCellStyle3;
            this.Unidade.HeaderText = "Un Medida";
            this.Unidade.Name = "Unidade";
            this.Unidade.ReadOnly = true;
            this.Unidade.Width = 70;
            // 
            // subtotal
            // 
            this.subtotal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.subtotal.DefaultCellStyle = dataGridViewCellStyle4;
            this.subtotal.HeaderText = "Subtotal";
            this.subtotal.Name = "subtotal";
            this.subtotal.ReadOnly = true;
            this.subtotal.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.subtotal.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.subtotal.Width = 120;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(7, 31);
            this.lblTotal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(116, 31);
            this.lblTotal.TabIndex = 6;
            this.lblTotal.Text = "R$ 0,00";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(598, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 18);
            this.label2.TabIndex = 7;
            this.label2.Text = "F7 - Canc. Venda";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(481, 0);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 18);
            this.label3.TabIndex = 8;
            this.label3.Text = "F6 - Canc. Item";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(312, 0);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 18);
            this.label4.TabIndex = 12;
            this.label4.Text = "F3 - Qtd";
            // 
            // lblPreco
            // 
            this.lblPreco.AutoSize = true;
            this.lblPreco.Location = new System.Drawing.Point(7, 134);
            this.lblPreco.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPreco.Name = "lblPreco";
            this.lblPreco.Size = new System.Drawing.Size(50, 20);
            this.lblPreco.TabIndex = 14;
            this.lblPreco.Text = "Preço";
            // 
            // grpItem
            // 
            this.grpItem.Controls.Add(this.txtQtd);
            this.grpItem.Controls.Add(this.txtPreco);
            this.grpItem.Controls.Add(this.lblQtd);
            this.grpItem.Controls.Add(this.lblPreco);
            this.grpItem.Controls.Add(this.txtCodigo);
            this.grpItem.Controls.Add(this.lblCodigo);
            this.grpItem.Location = new System.Drawing.Point(12, 27);
            this.grpItem.Name = "grpItem";
            this.grpItem.Size = new System.Drawing.Size(224, 207);
            this.grpItem.TabIndex = 23;
            this.grpItem.TabStop = false;
            this.grpItem.Text = "Item";
            // 
            // txtQtd
            // 
            this.txtQtd.AutoComma = false;
            this.txtQtd.Dec = 3;
            this.txtQtd.Location = new System.Drawing.Point(11, 47);
            this.txtQtd.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtQtd.MaxLength = 6;
            this.txtQtd.Name = "txtQtd";
            this.txtQtd.Size = new System.Drawing.Size(103, 26);
            this.txtQtd.TabIndex = 1;
            this.txtQtd.ReadOnlyChanged += new System.EventHandler(this.txtQtd_ReadOnlyChanged);
            this.txtQtd.TextChanged += new System.EventHandler(this.txtQtd_TextChanged);
            this.txtQtd.Enter += new System.EventHandler(this.txtQtd_Enter);
            this.txtQtd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtQtd_KeyDown);
            this.txtQtd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQtd_KeyPress);
            // 
            // txtPreco
            // 
            this.txtPreco.AutoComma = false;
            this.txtPreco.Dec = 2;
            this.txtPreco.Location = new System.Drawing.Point(11, 159);
            this.txtPreco.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPreco.MaxLength = 6;
            this.txtPreco.Name = "txtPreco";
            this.txtPreco.Size = new System.Drawing.Size(103, 26);
            this.txtPreco.TabIndex = 13;
            this.txtPreco.ReadOnlyChanged += new System.EventHandler(this.txtPreco_ReadOnlyChanged);
            this.txtPreco.Enter += new System.EventHandler(this.txtPreco_Enter);
            this.txtPreco.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPreco_KeyDown);
            // 
            // txtCodigo
            // 
            this.txtCodigo.AutoComma = true;
            this.txtCodigo.Dec = 0;
            this.txtCodigo.Location = new System.Drawing.Point(11, 103);
            this.txtCodigo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCodigo.MaxLength = 18;
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(206, 26);
            this.txtCodigo.TabIndex = 0;
            this.txtCodigo.TabStop = false;
            this.txtCodigo.ReadOnlyChanged += new System.EventHandler(this.txtCodigo_ReadOnlyChanged);
            this.txtCodigo.Enter += new System.EventHandler(this.txtCodigo_Enter);
            this.txtCodigo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodigo_KeyDown);
            // 
            // grpTotal
            // 
            this.grpTotal.Controls.Add(this.lblTotal);
            this.grpTotal.Location = new System.Drawing.Point(12, 240);
            this.grpTotal.Name = "grpTotal";
            this.grpTotal.Size = new System.Drawing.Size(224, 93);
            this.grpTotal.TabIndex = 24;
            this.grpTotal.TabStop = false;
            this.grpTotal.Text = "TOTAL";
            // 
            // grpProduto
            // 
            this.grpProduto.Controls.Add(this.lblProduto);
            this.grpProduto.Location = new System.Drawing.Point(248, 27);
            this.grpProduto.Name = "grpProduto";
            this.grpProduto.Size = new System.Drawing.Size(992, 73);
            this.grpProduto.TabIndex = 25;
            this.grpProduto.TabStop = false;
            this.grpProduto.Text = "Produto";
            // 
            // lblProduto
            // 
            this.lblProduto.AutoSize = true;
            this.lblProduto.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProduto.Location = new System.Drawing.Point(7, 26);
            this.lblProduto.Name = "lblProduto";
            this.lblProduto.Size = new System.Drawing.Size(0, 24);
            this.lblProduto.TabIndex = 0;
            // 
            // grpItens
            // 
            this.grpItens.Controls.Add(this.gridItem);
            this.grpItens.Location = new System.Drawing.Point(248, 105);
            this.grpItens.Name = "grpItens";
            this.grpItens.Size = new System.Drawing.Size(992, 537);
            this.grpItens.TabIndex = 26;
            this.grpItens.TabStop = false;
            this.grpItens.Text = "Itens";
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemCadastros,
            this.lançamentosToolStripMenuItem,
            this.toolStripResumo,
            this.menuItemSair});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(1252, 24);
            this.menu.TabIndex = 27;
            this.menu.Text = "menu";
            // 
            // menuItemCadastros
            // 
            this.menuItemCadastros.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemProdutos,
            this.fornecedoresToolStripMenuItem,
            this.gruposToolStripMenuItem,
            this.formasDePagamentoToolStripMenuItem});
            this.menuItemCadastros.Name = "menuItemCadastros";
            this.menuItemCadastros.Size = new System.Drawing.Size(71, 20);
            this.menuItemCadastros.Text = "Cadastros";
            // 
            // menuItemProdutos
            // 
            this.menuItemProdutos.Name = "menuItemProdutos";
            this.menuItemProdutos.Size = new System.Drawing.Size(193, 22);
            this.menuItemProdutos.Text = "Produtos";
            this.menuItemProdutos.Click += new System.EventHandler(this.menuItemProdutos_Click);
            // 
            // fornecedoresToolStripMenuItem
            // 
            this.fornecedoresToolStripMenuItem.Name = "fornecedoresToolStripMenuItem";
            this.fornecedoresToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.fornecedoresToolStripMenuItem.Text = "Fornecedores";
            this.fornecedoresToolStripMenuItem.Click += new System.EventHandler(this.fornecedoresToolStripMenuItem_Click);
            // 
            // gruposToolStripMenuItem
            // 
            this.gruposToolStripMenuItem.Name = "gruposToolStripMenuItem";
            this.gruposToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.gruposToolStripMenuItem.Text = "Grupos";
            this.gruposToolStripMenuItem.Click += new System.EventHandler(this.gruposToolStripMenuItem_Click);
            // 
            // formasDePagamentoToolStripMenuItem
            // 
            this.formasDePagamentoToolStripMenuItem.Name = "formasDePagamentoToolStripMenuItem";
            this.formasDePagamentoToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.formasDePagamentoToolStripMenuItem.Text = "Formas de Pagamento";
            this.formasDePagamentoToolStripMenuItem.Click += new System.EventHandler(this.formasDePagamentoToolStripMenuItem_Click);
            // 
            // lançamentosToolStripMenuItem
            // 
            this.lançamentosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.doDiaToolStripMenuItem,
            this.categoriasToolStripMenuItem});
            this.lançamentosToolStripMenuItem.Name = "lançamentosToolStripMenuItem";
            this.lançamentosToolStripMenuItem.Size = new System.Drawing.Size(90, 20);
            this.lançamentosToolStripMenuItem.Text = "Lançamentos";
            // 
            // doDiaToolStripMenuItem
            // 
            this.doDiaToolStripMenuItem.Name = "doDiaToolStripMenuItem";
            this.doDiaToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.doDiaToolStripMenuItem.Text = "Do dia";
            this.doDiaToolStripMenuItem.Click += new System.EventHandler(this.doDiaToolStripMenuItem_Click);
            // 
            // categoriasToolStripMenuItem
            // 
            this.categoriasToolStripMenuItem.Name = "categoriasToolStripMenuItem";
            this.categoriasToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.categoriasToolStripMenuItem.Text = "Categorias";
            this.categoriasToolStripMenuItem.Click += new System.EventHandler(this.categoriasToolStripMenuItem_Click);
            // 
            // toolStripResumo
            // 
            this.toolStripResumo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.doDiaToolStripMenuItem1,
            this.resumoDiarioToolStripMenuItem,
            this.analíticoToolStripMenuItem});
            this.toolStripResumo.Name = "toolStripResumo";
            this.toolStripResumo.Size = new System.Drawing.Size(56, 20);
            this.toolStripResumo.Text = "Vendas";
            // 
            // resumoDiarioToolStripMenuItem
            // 
            this.resumoDiarioToolStripMenuItem.Name = "resumoDiarioToolStripMenuItem";
            this.resumoDiarioToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.resumoDiarioToolStripMenuItem.Text = "Resumo Diário";
            this.resumoDiarioToolStripMenuItem.Click += new System.EventHandler(this.resumoDiarioToolStripMenuItem_Click);
            // 
            // analíticoToolStripMenuItem
            // 
            this.analíticoToolStripMenuItem.Name = "analíticoToolStripMenuItem";
            this.analíticoToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.analíticoToolStripMenuItem.Text = "Resumo Analítico";
            this.analíticoToolStripMenuItem.Click += new System.EventHandler(this.analíticoToolStripMenuItem_Click);
            // 
            // menuItemSair
            // 
            this.menuItemSair.Name = "menuItemSair";
            this.menuItemSair.Size = new System.Drawing.Size(38, 20);
            this.menuItemSair.Text = "Sair";
            this.menuItemSair.Click += new System.EventHandler(this.menuItemSair_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(233, 0);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 18);
            this.label5.TabIndex = 28;
            this.label5.Text = "F2 - Total";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(382, 0);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 18);
            this.label6.TabIndex = 29;
            this.label6.Text = "F4 - Balança";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(823, 0);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(149, 18);
            this.label7.TabIndex = 30;
            this.label7.Text = "F11 - Consulta Preço";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(980, 0);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(103, 18);
            this.label8.TabIndex = 31;
            this.label8.Text = "F12 - Resumo";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(728, 0);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(87, 18);
            this.label9.TabIndex = 32;
            this.label9.Text = "F9 - Cupom";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.lblDataHora);
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.label8);
            this.flowLayoutPanel1.Controls.Add(this.label7);
            this.flowLayoutPanel1.Controls.Add(this.label9);
            this.flowLayoutPanel1.Controls.Add(this.label2);
            this.flowLayoutPanel1.Controls.Add(this.label3);
            this.flowLayoutPanel1.Controls.Add(this.label6);
            this.flowLayoutPanel1.Controls.Add(this.label4);
            this.flowLayoutPanel1.Controls.Add(this.label5);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 648);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1252, 46);
            this.flowLayoutPanel1.TabIndex = 33;
            // 
            // lblDataHora
            // 
            this.lblDataHora.AutoSize = true;
            this.lblDataHora.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDataHora.Location = new System.Drawing.Point(1112, 0);
            this.lblDataHora.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDataHora.Name = "lblDataHora";
            this.lblDataHora.Size = new System.Drawing.Size(136, 17);
            this.lblDataHora.TabIndex = 6;
            this.lblDataHora.Text = "99/99/9999 99:99";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1091, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(13, 18);
            this.label1.TabIndex = 33;
            this.label1.Text = "|";
            // 
            // bgWorker
            // 
            this.bgWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorker_DoWork);
            // 
            // timerDataHora
            // 
            this.timerDataHora.Tick += new System.EventHandler(this.timerDataHora_Tick);
            // 
            // doDiaToolStripMenuItem1
            // 
            this.doDiaToolStripMenuItem1.Name = "doDiaToolStripMenuItem1";
            this.doDiaToolStripMenuItem1.Size = new System.Drawing.Size(167, 22);
            this.doDiaToolStripMenuItem1.Text = "Do Dia";
            this.doDiaToolStripMenuItem1.Click += new System.EventHandler(this.doDiaToolStripMenuItem1_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1252, 694);
            this.Controls.Add(this.grpItem);
            this.Controls.Add(this.grpTotal);
            this.Controls.Add(this.grpItens);
            this.Controls.Add(this.grpProduto);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.menu);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menu;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "mise";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.Click += new System.EventHandler(this.FrmMain_Click);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmMain_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.gridItem)).EndInit();
            this.grpItem.ResumeLayout(false);
            this.grpItem.PerformLayout();
            this.grpTotal.ResumeLayout(false);
            this.grpTotal.PerformLayout();
            this.grpProduto.ResumeLayout(false);
            this.grpProduto.PerformLayout();
            this.grpItens.ResumeLayout(false);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblQtd;
        private NumTextBox txtCodigo;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.DataGridView gridItem;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private NumTextBox txtPreco;
        private System.Windows.Forms.Label lblPreco;
        private System.Windows.Forms.GroupBox grpItem;
        private System.Windows.Forms.GroupBox grpTotal;
        private System.Windows.Forms.GroupBox grpProduto;
        private System.Windows.Forms.Label lblProduto;
        private System.Windows.Forms.GroupBox grpItens;
        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem menuItemCadastros;
        private System.Windows.Forms.ToolStripMenuItem menuItemProdutos;
        private System.Windows.Forms.ToolStripMenuItem fornecedoresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gruposToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem formasDePagamentoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuItemSair;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ToolStripMenuItem toolStripResumo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.ToolStripMenuItem lançamentosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem doDiaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem categoriasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resumoDiarioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem analíticoToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker bgWorker;
        private mise.component.NumTextBox txtQtd;
        private System.Windows.Forms.DataGridViewTextBoxColumn sequencial;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn nome;
        private System.Windows.Forms.DataGridViewTextBoxColumn precoUn;
        private System.Windows.Forms.DataGridViewTextBoxColumn qtd;
        private System.Windows.Forms.DataGridViewTextBoxColumn Unidade;
        private System.Windows.Forms.DataGridViewTextBoxColumn subtotal;
        private System.Windows.Forms.Label lblDataHora;
        private System.Windows.Forms.Timer timerDataHora;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem doDiaToolStripMenuItem1;
    }
}

