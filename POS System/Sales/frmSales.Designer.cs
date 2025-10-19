namespace WindowsFormsApp1.Sales
{
    partial class frmSales
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pnlSales = new System.Windows.Forms.Panel();
            this.pnldgvSales = new System.Windows.Forms.Panel();
            this.dgvSalesList = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.cbFilter = new System.Windows.Forms.ComboBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.txtSearchSales = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pnl = new System.Windows.Forms.Panel();
            this.dgvSalesDetails = new System.Windows.Forms.DataGridView();
            this.pnlSalesLabel = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.pnlSales.SuspendLayout();
            this.pnldgvSales.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalesList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.pnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalesDetails)).BeginInit();
            this.pnlSalesLabel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 69.45404F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.54596F));
            this.tableLayoutPanel1.Controls.Add(this.pnlSales, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.pnl, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1447, 558);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // pnlSales
            // 
            this.pnlSales.Controls.Add(this.pnldgvSales);
            this.pnlSales.Controls.Add(this.label2);
            this.pnlSales.Controls.Add(this.cbFilter);
            this.pnlSales.Controls.Add(this.pictureBox2);
            this.pnlSales.Controls.Add(this.txtSearchSales);
            this.pnlSales.Controls.Add(this.label1);
            this.pnlSales.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSales.Location = new System.Drawing.Point(3, 3);
            this.pnlSales.Name = "pnlSales";
            this.pnlSales.Size = new System.Drawing.Size(999, 552);
            this.pnlSales.TabIndex = 5;
            // 
            // pnldgvSales
            // 
            this.pnldgvSales.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnldgvSales.Controls.Add(this.dgvSalesList);
            this.pnldgvSales.Location = new System.Drawing.Point(0, 183);
            this.pnldgvSales.Name = "pnldgvSales";
            this.pnldgvSales.Size = new System.Drawing.Size(999, 360);
            this.pnldgvSales.TabIndex = 13;
            // 
            // dgvSalesList
            // 
            this.dgvSalesList.AllowUserToAddRows = false;
            this.dgvSalesList.AllowUserToDeleteRows = false;
            this.dgvSalesList.AllowUserToOrderColumns = true;
            this.dgvSalesList.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.dgvSalesList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvSalesList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvSalesList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvSalesList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSalesList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSalesList.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.dgvSalesList.Location = new System.Drawing.Point(0, 0);
            this.dgvSalesList.Name = "dgvSalesList";
            this.dgvSalesList.ReadOnly = true;
            this.dgvSalesList.RowHeadersWidth = 51;
            this.dgvSalesList.RowTemplate.Height = 24;
            this.dgvSalesList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvSalesList.Size = new System.Drawing.Size(999, 360);
            this.dgvSalesList.TabIndex = 12;
            this.dgvSalesList.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvSalesList_DataBindingComplete);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(3, 141);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(145, 36);
            this.label2.TabIndex = 11;
            this.label2.Text = "Sales LIst";
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
            "Date",
            "User Name",
            "Total"});
            this.cbFilter.Location = new System.Drawing.Point(757, 57);
            this.cbFilter.Name = "cbFilter";
            this.cbFilter.Size = new System.Drawing.Size(229, 37);
            this.cbFilter.TabIndex = 9;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.pictureBox2.Image = global::WindowsFormsApp1.Properties.Resources.magnifier_search_magnifyng_glass_icon_153921;
            this.pictureBox2.Location = new System.Drawing.Point(20, 54);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(52, 45);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 8;
            this.pictureBox2.TabStop = false;
            // 
            // txtSearchSales
            // 
            this.txtSearchSales.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.txtSearchSales.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSearchSales.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchSales.ForeColor = System.Drawing.Color.DarkGray;
            this.txtSearchSales.Location = new System.Drawing.Point(73, 54);
            this.txtSearchSales.Multiline = true;
            this.txtSearchSales.Name = "txtSearchSales";
            this.txtSearchSales.Size = new System.Drawing.Size(670, 45);
            this.txtSearchSales.TabIndex = 7;
            this.txtSearchSales.Text = "     Search Items";
            this.txtSearchSales.Click += new System.EventHandler(this.txtSearchProducts_Click);
            this.txtSearchSales.TextChanged += new System.EventHandler(this.txtSearchProducts_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(191, 36);
            this.label1.TabIndex = 6;
            this.label1.Text = "Sales Search";
            // 
            // pnl
            // 
            this.pnl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.pnl.Controls.Add(this.dgvSalesDetails);
            this.pnl.Controls.Add(this.pnlSalesLabel);
            this.pnl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl.Location = new System.Drawing.Point(1008, 3);
            this.pnl.Name = "pnl";
            this.pnl.Size = new System.Drawing.Size(436, 552);
            this.pnl.TabIndex = 6;
            // 
            // dgvSalesDetails
            // 
            this.dgvSalesDetails.AllowUserToAddRows = false;
            this.dgvSalesDetails.AllowUserToDeleteRows = false;
            this.dgvSalesDetails.AllowUserToOrderColumns = true;
            this.dgvSalesDetails.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.dgvSalesDetails.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvSalesDetails.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvSalesDetails.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvSalesDetails.ColumnHeadersHeight = 35;
            this.dgvSalesDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSalesDetails.GridColor = System.Drawing.Color.Gray;
            this.dgvSalesDetails.Location = new System.Drawing.Point(0, 54);
            this.dgvSalesDetails.Name = "dgvSalesDetails";
            this.dgvSalesDetails.ReadOnly = true;
            this.dgvSalesDetails.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dgvSalesDetails.RowHeadersWidth = 51;
            this.dgvSalesDetails.RowTemplate.Height = 24;
            this.dgvSalesDetails.Size = new System.Drawing.Size(436, 498);
            this.dgvSalesDetails.TabIndex = 0;
            this.dgvSalesDetails.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvSalesDetails_DataBindingComplete);
            // 
            // pnlSalesLabel
            // 
            this.pnlSalesLabel.Controls.Add(this.label3);
            this.pnlSalesLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSalesLabel.Location = new System.Drawing.Point(0, 0);
            this.pnlSalesLabel.Name = "pnlSalesLabel";
            this.pnlSalesLabel.Size = new System.Drawing.Size(436, 54);
            this.pnlSalesLabel.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Gray;
            this.label3.Location = new System.Drawing.Point(3, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(187, 36);
            this.label3.TabIndex = 5;
            this.label3.Text = "Sales Details";
            // 
            // frmSales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(1447, 558);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmSales";
            this.Text = "Sales";
            this.Load += new System.EventHandler(this.frmSales_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.pnlSales.ResumeLayout(false);
            this.pnlSales.PerformLayout();
            this.pnldgvSales.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalesList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.pnl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalesDetails)).EndInit();
            this.pnlSalesLabel.ResumeLayout(false);
            this.pnlSalesLabel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel pnlSales;
        private System.Windows.Forms.Panel pnl;
        private System.Windows.Forms.Panel pnlSalesLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbFilter;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnldgvSales;
        private System.Windows.Forms.TextBox txtSearchSales;
        private System.Windows.Forms.DataGridView dgvSalesDetails;
        private System.Windows.Forms.DataGridView dgvSalesList;
    }
}