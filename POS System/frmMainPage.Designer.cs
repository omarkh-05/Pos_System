namespace WindowsFormsApp1
{
    partial class frmMainPage
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
            this.pnlNavbar = new System.Windows.Forms.Panel();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnCategories = new FontAwesome.Sharp.IconButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblUserName = new System.Windows.Forms.Label();
            this.iconButton4 = new FontAwesome.Sharp.IconButton();
            this.btnUser = new FontAwesome.Sharp.IconButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnProducts = new FontAwesome.Sharp.IconButton();
            this.btnSales = new FontAwesome.Sharp.IconButton();
            this.btnPOS = new FontAwesome.Sharp.IconButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlProducts = new System.Windows.Forms.Panel();
            this.dgvProducts = new System.Windows.Forms.DataGridView();
            this.pnlSearchBox = new System.Windows.Forms.Panel();
            this.btnrefresh = new FontAwesome.Sharp.IconButton();
            this.btnAddProductToSale = new FontAwesome.Sharp.IconButton();
            this.cbFilter = new System.Windows.Forms.ComboBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.txtSearchProducts = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlCategories = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlPosPoint = new System.Windows.Forms.Panel();
            this.pnlSales = new System.Windows.Forms.Panel();
            this.salesInvoise1 = new WindowsFormsApp1.SalesInvoise();
            this.pnlMoreSales = new System.Windows.Forms.Panel();
            this.lblOpenedSalesInvoice = new System.Windows.Forms.Label();
            this.btnAddNewSales = new FontAwesome.Sharp.IconButton();
            this.label3 = new System.Windows.Forms.Label();
            this.pnlMainPage = new System.Windows.Forms.Panel();
            this.pnlNavbar.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.pnlProducts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
            this.pnlSearchBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel1.SuspendLayout();
            this.pnlPosPoint.SuspendLayout();
            this.pnlSales.SuspendLayout();
            this.pnlMoreSales.SuspendLayout();
            this.pnlMainPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlNavbar
            // 
            this.pnlNavbar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.pnlNavbar.Controls.Add(this.groupBox5);
            this.pnlNavbar.Controls.Add(this.btnCategories);
            this.pnlNavbar.Controls.Add(this.groupBox2);
            this.pnlNavbar.Controls.Add(this.groupBox4);
            this.pnlNavbar.Controls.Add(this.groupBox1);
            this.pnlNavbar.Controls.Add(this.lblUserName);
            this.pnlNavbar.Controls.Add(this.iconButton4);
            this.pnlNavbar.Controls.Add(this.btnUser);
            this.pnlNavbar.Controls.Add(this.groupBox3);
            this.pnlNavbar.Controls.Add(this.btnProducts);
            this.pnlNavbar.Controls.Add(this.btnSales);
            this.pnlNavbar.Controls.Add(this.btnPOS);
            this.pnlNavbar.Controls.Add(this.label2);
            this.pnlNavbar.Controls.Add(this.label1);
            this.pnlNavbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlNavbar.Location = new System.Drawing.Point(0, 0);
            this.pnlNavbar.Name = "pnlNavbar";
            this.pnlNavbar.Size = new System.Drawing.Size(1800, 72);
            this.pnlNavbar.TabIndex = 0;
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox5.ForeColor = System.Drawing.Color.White;
            this.groupBox5.Location = new System.Drawing.Point(1045, 56);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(81, 10);
            this.groupBox5.TabIndex = 11;
            this.groupBox5.TabStop = false;
            // 
            // btnCategories
            // 
            this.btnCategories.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCategories.BackColor = System.Drawing.Color.Transparent;
            this.btnCategories.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCategories.FlatAppearance.BorderSize = 0;
            this.btnCategories.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCategories.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCategories.ForeColor = System.Drawing.Color.White;
            this.btnCategories.IconChar = FontAwesome.Sharp.IconChar.DollyFlatbed;
            this.btnCategories.IconColor = System.Drawing.Color.Gray;
            this.btnCategories.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnCategories.IconSize = 32;
            this.btnCategories.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCategories.Location = new System.Drawing.Point(1045, 8);
            this.btnCategories.Name = "btnCategories";
            this.btnCategories.Size = new System.Drawing.Size(217, 52);
            this.btnCategories.TabIndex = 10;
            this.btnCategories.Text = "Reports";
            this.btnCategories.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCategories.UseVisualStyleBackColor = false;
            this.btnCategories.Click += new System.EventHandler(this.btnCategories_Click);
            this.btnCategories.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.btnCategories.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(375, 56);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(86, 10);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox4.ForeColor = System.Drawing.Color.White;
            this.groupBox4.Location = new System.Drawing.Point(1291, 56);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(79, 10);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(574, 56);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(88, 10);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserName.ForeColor = System.Drawing.Color.DarkGray;
            this.lblUserName.Location = new System.Drawing.Point(12, 38);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(116, 25);
            this.lblUserName.TabIndex = 8;
            this.lblUserName.Text = "User_Name";
            // 
            // iconButton4
            // 
            this.iconButton4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.iconButton4.BackColor = System.Drawing.Color.Transparent;
            this.iconButton4.FlatAppearance.BorderSize = 0;
            this.iconButton4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton4.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconButton4.ForeColor = System.Drawing.Color.White;
            this.iconButton4.IconChar = FontAwesome.Sharp.IconChar.SignOut;
            this.iconButton4.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(193)))), ((int)(((byte)(7)))));
            this.iconButton4.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton4.Location = new System.Drawing.Point(1739, 11);
            this.iconButton4.Name = "iconButton4";
            this.iconButton4.Size = new System.Drawing.Size(58, 52);
            this.iconButton4.TabIndex = 7;
            this.iconButton4.UseVisualStyleBackColor = false;
            this.iconButton4.Click += new System.EventHandler(this.iconButton4_Click);
            // 
            // btnUser
            // 
            this.btnUser.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnUser.BackColor = System.Drawing.Color.Transparent;
            this.btnUser.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUser.FlatAppearance.BorderSize = 0;
            this.btnUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUser.ForeColor = System.Drawing.Color.White;
            this.btnUser.IconChar = FontAwesome.Sharp.IconChar.User;
            this.btnUser.IconColor = System.Drawing.Color.Gray;
            this.btnUser.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnUser.IconSize = 32;
            this.btnUser.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUser.Location = new System.Drawing.Point(1291, 8);
            this.btnUser.Name = "btnUser";
            this.btnUser.Size = new System.Drawing.Size(134, 52);
            this.btnUser.TabIndex = 6;
            this.btnUser.Text = "User";
            this.btnUser.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnUser.UseVisualStyleBackColor = false;
            this.btnUser.Click += new System.EventHandler(this.iconButton3_Click);
            this.btnUser.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.btnUser.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox3.ForeColor = System.Drawing.Color.White;
            this.groupBox3.Location = new System.Drawing.Point(786, 56);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(89, 10);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            // 
            // btnProducts
            // 
            this.btnProducts.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnProducts.BackColor = System.Drawing.Color.Transparent;
            this.btnProducts.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProducts.FlatAppearance.BorderSize = 0;
            this.btnProducts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProducts.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProducts.ForeColor = System.Drawing.Color.White;
            this.btnProducts.IconChar = FontAwesome.Sharp.IconChar.CartArrowDown;
            this.btnProducts.IconColor = System.Drawing.Color.Gray;
            this.btnProducts.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnProducts.IconSize = 32;
            this.btnProducts.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProducts.Location = new System.Drawing.Point(786, 8);
            this.btnProducts.Name = "btnProducts";
            this.btnProducts.Size = new System.Drawing.Size(194, 52);
            this.btnProducts.TabIndex = 6;
            this.btnProducts.Text = "Products";
            this.btnProducts.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnProducts.UseVisualStyleBackColor = false;
            this.btnProducts.Click += new System.EventHandler(this.iconButton2_Click);
            this.btnProducts.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.btnProducts.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            // 
            // btnSales
            // 
            this.btnSales.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSales.BackColor = System.Drawing.Color.Transparent;
            this.btnSales.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSales.FlatAppearance.BorderSize = 0;
            this.btnSales.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSales.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSales.ForeColor = System.Drawing.Color.White;
            this.btnSales.IconChar = FontAwesome.Sharp.IconChar.DollarSign;
            this.btnSales.IconColor = System.Drawing.Color.Gray;
            this.btnSales.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnSales.IconSize = 32;
            this.btnSales.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSales.Location = new System.Drawing.Point(574, 8);
            this.btnSales.Name = "btnSales";
            this.btnSales.Size = new System.Drawing.Size(147, 52);
            this.btnSales.TabIndex = 4;
            this.btnSales.Text = "Sales";
            this.btnSales.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSales.UseVisualStyleBackColor = false;
            this.btnSales.Click += new System.EventHandler(this.iconButton1_Click);
            this.btnSales.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.btnSales.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            // 
            // btnPOS
            // 
            this.btnPOS.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnPOS.BackColor = System.Drawing.Color.Transparent;
            this.btnPOS.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPOS.FlatAppearance.BorderSize = 0;
            this.btnPOS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPOS.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPOS.ForeColor = System.Drawing.Color.White;
            this.btnPOS.IconChar = FontAwesome.Sharp.IconChar.Calculator;
            this.btnPOS.IconColor = System.Drawing.Color.Gray;
            this.btnPOS.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnPOS.IconSize = 32;
            this.btnPOS.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPOS.Location = new System.Drawing.Point(375, 8);
            this.btnPOS.Name = "btnPOS";
            this.btnPOS.Size = new System.Drawing.Size(134, 52);
            this.btnPOS.TabIndex = 2;
            this.btnPOS.Text = "POS";
            this.btnPOS.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPOS.UseVisualStyleBackColor = false;
            this.btnPOS.Click += new System.EventHandler(this.btnPOS_Click);
            this.btnPOS.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.btnPOS.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(92, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "UP";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(13, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "FITCOMP";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.pnlProducts);
            this.pnlMain.Controls.Add(this.panel1);
            this.pnlMain.Controls.Add(this.pnlPosPoint);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1800, 1030);
            this.pnlMain.TabIndex = 1;
            // 
            // pnlProducts
            // 
            this.pnlProducts.Controls.Add(this.dgvProducts);
            this.pnlProducts.Controls.Add(this.pnlSearchBox);
            this.pnlProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlProducts.Location = new System.Drawing.Point(410, 220);
            this.pnlProducts.Name = "pnlProducts";
            this.pnlProducts.Size = new System.Drawing.Size(1390, 810);
            this.pnlProducts.TabIndex = 2;
            // 
            // dgvProducts
            // 
            this.dgvProducts.AllowUserToAddRows = false;
            this.dgvProducts.AllowUserToDeleteRows = false;
            this.dgvProducts.AllowUserToOrderColumns = true;
            this.dgvProducts.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.dgvProducts.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvProducts.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvProducts.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProducts.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.dgvProducts.Location = new System.Drawing.Point(0, 103);
            this.dgvProducts.Name = "dgvProducts";
            this.dgvProducts.ReadOnly = true;
            this.dgvProducts.RowHeadersWidth = 51;
            this.dgvProducts.RowTemplate.Height = 24;
            this.dgvProducts.Size = new System.Drawing.Size(1390, 707);
            this.dgvProducts.TabIndex = 5;
            this.dgvProducts.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvProducts_DataBindingComplete);
            // 
            // pnlSearchBox
            // 
            this.pnlSearchBox.Controls.Add(this.btnrefresh);
            this.pnlSearchBox.Controls.Add(this.btnAddProductToSale);
            this.pnlSearchBox.Controls.Add(this.cbFilter);
            this.pnlSearchBox.Controls.Add(this.pictureBox2);
            this.pnlSearchBox.Controls.Add(this.txtSearchProducts);
            this.pnlSearchBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSearchBox.Location = new System.Drawing.Point(0, 0);
            this.pnlSearchBox.Name = "pnlSearchBox";
            this.pnlSearchBox.Size = new System.Drawing.Size(1390, 103);
            this.pnlSearchBox.TabIndex = 4;
            // 
            // btnrefresh
            // 
            this.btnrefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnrefresh.FlatAppearance.BorderSize = 0;
            this.btnrefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnrefresh.IconChar = FontAwesome.Sharp.IconChar.Repeat;
            this.btnrefresh.IconColor = System.Drawing.Color.DarkGray;
            this.btnrefresh.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnrefresh.Location = new System.Drawing.Point(1344, 53);
            this.btnrefresh.Name = "btnrefresh";
            this.btnrefresh.Size = new System.Drawing.Size(43, 38);
            this.btnrefresh.TabIndex = 76;
            this.btnrefresh.UseVisualStyleBackColor = true;
            this.btnrefresh.Click += new System.EventHandler(this.btnrefresh_Click);
            // 
            // btnAddProductToSale
            // 
            this.btnAddProductToSale.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnAddProductToSale.FlatAppearance.BorderSize = 0;
            this.btnAddProductToSale.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddProductToSale.ForeColor = System.Drawing.Color.White;
            this.btnAddProductToSale.IconChar = FontAwesome.Sharp.IconChar.ArrowRight;
            this.btnAddProductToSale.IconColor = System.Drawing.Color.LightGray;
            this.btnAddProductToSale.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnAddProductToSale.Location = new System.Drawing.Point(969, 31);
            this.btnAddProductToSale.Name = "btnAddProductToSale";
            this.btnAddProductToSale.Size = new System.Drawing.Size(79, 45);
            this.btnAddProductToSale.TabIndex = 3;
            this.btnAddProductToSale.UseVisualStyleBackColor = false;
            this.btnAddProductToSale.Click += new System.EventHandler(this.btnAddProductToSale_Click);
            // 
            // cbFilter
            // 
            this.cbFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.cbFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilter.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFilter.ForeColor = System.Drawing.Color.Silver;
            this.cbFilter.FormattingEnabled = true;
            this.cbFilter.Items.AddRange(new object[] {
            "Name",
            "Barcode",
            "Price"});
            this.cbFilter.Location = new System.Drawing.Point(1059, 34);
            this.cbFilter.Name = "cbFilter";
            this.cbFilter.Size = new System.Drawing.Size(237, 37);
            this.cbFilter.TabIndex = 2;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.pictureBox2.Image = global::WindowsFormsApp1.Properties.Resources.magnifier_search_magnifyng_glass_icon_153921;
            this.pictureBox2.Location = new System.Drawing.Point(15, 31);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(60, 45);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // txtSearchProducts
            // 
            this.txtSearchProducts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.txtSearchProducts.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearchProducts.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchProducts.ForeColor = System.Drawing.Color.DarkGray;
            this.txtSearchProducts.Location = new System.Drawing.Point(76, 31);
            this.txtSearchProducts.Name = "txtSearchProducts";
            this.txtSearchProducts.Size = new System.Drawing.Size(887, 45);
            this.txtSearchProducts.TabIndex = 0;
            this.txtSearchProducts.Text = "     Search Items";
            this.txtSearchProducts.Click += new System.EventHandler(this.txtSearchProducts_Click);
            this.txtSearchProducts.TextChanged += new System.EventHandler(this.txtSearchProducts_TextChanged);
            this.txtSearchProducts.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearchProducts_KeyDown);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pnlCategories);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(410, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1390, 220);
            this.panel1.TabIndex = 1;
            // 
            // pnlCategories
            // 
            this.pnlCategories.AutoScroll = true;
            this.pnlCategories.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCategories.Location = new System.Drawing.Point(0, 0);
            this.pnlCategories.Margin = new System.Windows.Forms.Padding(100, 50, 50, 50);
            this.pnlCategories.Name = "pnlCategories";
            this.pnlCategories.Padding = new System.Windows.Forms.Padding(30, 50, 50, 50);
            this.pnlCategories.Size = new System.Drawing.Size(1390, 220);
            this.pnlCategories.TabIndex = 0;
            this.pnlCategories.WrapContents = false;
            // 
            // pnlPosPoint
            // 
            this.pnlPosPoint.Controls.Add(this.pnlSales);
            this.pnlPosPoint.Controls.Add(this.pnlMoreSales);
            this.pnlPosPoint.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlPosPoint.Location = new System.Drawing.Point(0, 0);
            this.pnlPosPoint.Name = "pnlPosPoint";
            this.pnlPosPoint.Size = new System.Drawing.Size(410, 1030);
            this.pnlPosPoint.TabIndex = 0;
            // 
            // pnlSales
            // 
            this.pnlSales.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.pnlSales.Controls.Add(this.salesInvoise1);
            this.pnlSales.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSales.Location = new System.Drawing.Point(0, 82);
            this.pnlSales.Name = "pnlSales";
            this.pnlSales.Size = new System.Drawing.Size(410, 948);
            this.pnlSales.TabIndex = 1;
            // 
            // salesInvoise1
            // 
            this.salesInvoise1.BackColor = System.Drawing.Color.Transparent;
            this.salesInvoise1.Location = new System.Drawing.Point(0, 0);
            this.salesInvoise1.Name = "salesInvoise1";
            this.salesInvoise1.Size = new System.Drawing.Size(410, 936);
            this.salesInvoise1.TabIndex = 0;
            // 
            // pnlMoreSales
            // 
            this.pnlMoreSales.Controls.Add(this.lblOpenedSalesInvoice);
            this.pnlMoreSales.Controls.Add(this.btnAddNewSales);
            this.pnlMoreSales.Controls.Add(this.label3);
            this.pnlMoreSales.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMoreSales.Location = new System.Drawing.Point(0, 0);
            this.pnlMoreSales.Name = "pnlMoreSales";
            this.pnlMoreSales.Size = new System.Drawing.Size(410, 82);
            this.pnlMoreSales.TabIndex = 0;
            // 
            // lblOpenedSalesInvoice
            // 
            this.lblOpenedSalesInvoice.AutoSize = true;
            this.lblOpenedSalesInvoice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblOpenedSalesInvoice.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblOpenedSalesInvoice.Location = new System.Drawing.Point(91, 54);
            this.lblOpenedSalesInvoice.Name = "lblOpenedSalesInvoice";
            this.lblOpenedSalesInvoice.Size = new System.Drawing.Size(23, 25);
            this.lblOpenedSalesInvoice.TabIndex = 13;
            this.lblOpenedSalesInvoice.Text = "0";
            // 
            // btnAddNewSales
            // 
            this.btnAddNewSales.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btnAddNewSales.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddNewSales.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnAddNewSales.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddNewSales.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddNewSales.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnAddNewSales.IconChar = FontAwesome.Sharp.IconChar.Plus;
            this.btnAddNewSales.IconColor = System.Drawing.Color.Gainsboro;
            this.btnAddNewSales.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnAddNewSales.Location = new System.Drawing.Point(231, 6);
            this.btnAddNewSales.Name = "btnAddNewSales";
            this.btnAddNewSales.Size = new System.Drawing.Size(176, 76);
            this.btnAddNewSales.TabIndex = 1;
            this.btnAddNewSales.Text = "Add New Sales";
            this.btnAddNewSales.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddNewSales.UseVisualStyleBackColor = false;
            this.btnAddNewSales.Click += new System.EventHandler(this.btnAddNewSales_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.LightGray;
            this.label3.Location = new System.Drawing.Point(3, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(138, 50);
            this.label3.TabIndex = 14;
            this.label3.Text = "Opened Sales\r\nInvoice : ";
            // 
            // pnlMainPage
            // 
            this.pnlMainPage.Controls.Add(this.pnlMain);
            this.pnlMainPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMainPage.Location = new System.Drawing.Point(0, 72);
            this.pnlMainPage.Name = "pnlMainPage";
            this.pnlMainPage.Size = new System.Drawing.Size(1800, 1030);
            this.pnlMainPage.TabIndex = 2;
            // 
            // frmMainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(1800, 1102);
            this.Controls.Add(this.pnlMainPage);
            this.Controls.Add(this.pnlNavbar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "frmMainPage";
            this.Text = "Main Page";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMainPage_Load);
            this.pnlNavbar.ResumeLayout(false);
            this.pnlNavbar.PerformLayout();
            this.pnlMain.ResumeLayout(false);
            this.pnlProducts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
            this.pnlSearchBox.ResumeLayout(false);
            this.pnlSearchBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.pnlPosPoint.ResumeLayout(false);
            this.pnlSales.ResumeLayout(false);
            this.pnlMoreSales.ResumeLayout(false);
            this.pnlMoreSales.PerformLayout();
            this.pnlMainPage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlNavbar;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlPosPoint;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private FontAwesome.Sharp.IconButton btnPOS;
        private FontAwesome.Sharp.IconButton btnUser;
        private System.Windows.Forms.GroupBox groupBox3;
        private FontAwesome.Sharp.IconButton btnSales;
        private FontAwesome.Sharp.IconButton iconButton4;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel pnlSales;
        private System.Windows.Forms.Panel pnlMoreSales;
        private FontAwesome.Sharp.IconButton btnAddNewSales;
        private System.Windows.Forms.Panel pnlMainPage;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnlProducts;
        private System.Windows.Forms.Panel pnlSearchBox;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox txtSearchProducts;
        private FontAwesome.Sharp.IconButton btnProducts;
        private System.Windows.Forms.DataGridView dgvProducts;
        private System.Windows.Forms.ComboBox cbFilter;
        private FontAwesome.Sharp.IconButton btnAddProductToSale;
        private FontAwesome.Sharp.IconButton btnCategories;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.FlowLayoutPanel pnlCategories;
        private FontAwesome.Sharp.IconButton btnrefresh;
        private SalesInvoise salesInvoise1;
        private System.Windows.Forms.Label lblOpenedSalesInvoice;
        private System.Windows.Forms.Label label3;
    }
}

