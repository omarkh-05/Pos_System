using businessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.Sales
{
    public partial class frmSales : Form
    {
        public frmSales()
        {
            InitializeComponent();
        }
        private DataTable _dtAllSales;
        private DataTable _dtSales;
        private DataTable _dtAllSalesDetails;
        private DataTable _dtSalesDetails;
        int _SalesID = -1;


        //                      Data Grid View
        private async Task LoadSalesAsync()
        {
            _dtAllSales = await SalesBLL.GetAllSales();

            // نختار الأعمدة المطلوبة للعرض فقط
            _dtSales = _dtAllSales.DefaultView.ToTable(false, "SalesID", "SalesDate", "Total", "UserName");
        }
        public async Task ShowSales()
        {
            await LoadSalesAsync();

            dgvSalesList.AutoGenerateColumns = false;
            dgvSalesList.AllowUserToAddRows = false;
            dgvSalesList.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgvSalesList.MultiSelect = false;
            dgvSalesList.RowHeadersVisible = false;
            dgvSalesList.EnableHeadersVisualStyles = false;
            dgvSalesList.AllowUserToResizeColumns = false;
            dgvSalesList.AllowUserToResizeRows = false;

            dgvSalesList.Columns.Clear();

            // إنشاء الأعمدة من DataTable
            foreach (DataColumn col in _dtSales.Columns)
            {
                dgvSalesList.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    Name = col.ColumnName,
                    HeaderText = col.ColumnName,
                    DataPropertyName = col.ColumnName,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
                    Resizable = DataGridViewTriState.False
                });
            }

            // إضافة زر ShowInfo
            DataGridViewButtonColumn infoBtn = new DataGridViewButtonColumn
            {
                HeaderText = "ShowInfo",
                Text = "ℹ️",
                UseColumnTextForButtonValue = true,
                Width = 200,
                Resizable = DataGridViewTriState.False
            };
            dgvSalesList.Columns.Add(infoBtn);

            // ضبط عرض الأعمدة
            dgvSalesList.Columns["SalesID"].Width = 200;
            dgvSalesList.Columns["SalesDate"].Width = 250;
            dgvSalesList.Columns["Total"].Width = 200;
            dgvSalesList.Columns["UserName"].Width = 200;

            dgvSalesList.RowTemplate.Height = 45;
            dgvSalesList.ColumnHeadersHeight = 40;
            dgvSalesList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            dgvSalesList.RowsDefaultCellStyle.BackColor = Color.FromArgb(30, 30, 30);
            dgvSalesList.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(35, 35, 35);

            dgvSalesList.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            dgvSalesList.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(40, 40, 40);
            dgvSalesList.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            dgvSalesList.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgvSalesList.ForeColor = Color.Gray;

            dgvSalesList.DataSource = _dtSales;

            // حدث الأزرار
            dgvSalesList.CellClick -= dgvSales_CellClick;
            dgvSalesList.CellClick += dgvSales_CellClick;
        }
        private async void dgvSales_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dgvSalesList.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                var salesID = dgvSalesList.Rows[e.RowIndex].Cells["SalesID"].Value;
                _SalesID = Convert.ToInt32(salesID);
                string header = dgvSalesList.Columns[e.ColumnIndex].HeaderText;

                if (header == "ShowInfo")
                {
                    await  ShowSalesDetails();
                }
            }
        }
        private void dgvSalesList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvSalesList.ClearSelection();
            dgvSalesList.CurrentCell = null;
        }




        //                      Sales Details Data Grid View
        private async Task LoadSalesDetailsAsync()
        {
            _dtAllSalesDetails = await SalesDetailBLL.GetSaleDetailsAsync(_SalesID);

            // نختار الأعمدة المطلوبة للعرض فقط
            _dtSalesDetails = _dtAllSalesDetails.DefaultView.ToTable(false, "ProductName", "Quantity", "UnitPrice", "SubTotal");
        }
        public async Task ShowSalesDetails()
        {
            await LoadSalesDetailsAsync();

            dgvSalesDetails.AutoGenerateColumns = false;
            dgvSalesDetails.AllowUserToAddRows = false;
            dgvSalesDetails.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgvSalesDetails.MultiSelect = false;
            dgvSalesDetails.RowHeadersVisible = false;
            dgvSalesDetails.EnableHeadersVisualStyles = false;
            dgvSalesDetails.AllowUserToResizeColumns = false;
            dgvSalesDetails.AllowUserToResizeRows = false;

            dgvSalesDetails.Columns.Clear();

            // إنشاء الأعمدة من DataTable
            foreach (DataColumn col in _dtSalesDetails.Columns)
            {
                dgvSalesDetails.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    HeaderText = col.ColumnName,
                    Name = col.ColumnName,
                    DataPropertyName = col.ColumnName,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
                    Resizable = DataGridViewTriState.False
                });
            }

            // ضبط عرض الأعمدة
            dgvSalesDetails.Columns["ProductName"].Width = 150;
            dgvSalesDetails.Columns["Quantity"].Width = 100;
            dgvSalesDetails.Columns["UnitPrice"].Width = 105;
            dgvSalesDetails.Columns["SubTotal"].Width = 100;
            
            dgvSalesDetails.RowTemplate.Height = 45;
            dgvSalesDetails.ColumnHeadersHeight = 40;
            dgvSalesDetails.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            
            dgvSalesDetails.RowsDefaultCellStyle.BackColor = Color.FromArgb(30, 30, 30);
            dgvSalesDetails.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(35, 35, 35);
            
            dgvSalesDetails.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            dgvSalesDetails.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(40, 40, 40);
            dgvSalesDetails.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            
            dgvSalesDetails.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgvSalesDetails.ForeColor = Color.Gray;

            dgvSalesDetails.DataSource = _dtSalesDetails;
        }
        private void dgvSalesDetails_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvSalesDetails.ClearSelection();
            dgvSalesDetails.CurrentCell = null;
        }


        //                      Load          
        private async void frmSales_Load(object sender, EventArgs e)
        {
           await ShowSales();
            await ShowSalesDetails();
            cbFilter.SelectedIndex = 1;
        }



        //                      Search
        private void txtSearchProducts_Click(object sender, EventArgs e)
        {
            txtSearchSales.Text = "";
        }
        private void txtSearchProducts_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";
            //Map Selected Filter to real Column name 
            switch (cbFilter.Text)
            {
                case "Date":
                    FilterColumn = "SalesDate";
                    break;

                case "User Name":
                    FilterColumn = "UserName";
                    break;

                case "Total":
                    FilterColumn = "Total";
                    break;

                default:
                    FilterColumn = "SalesDate";
                    break;

            }
            if (txtSearchSales.Text.Trim() == "" || FilterColumn == "None")
            {
                _dtSales.DefaultView.RowFilter = "";
                return;
            }

            if (FilterColumn == "Total")
            {
                //in this case we deal with integer not string.
                try
                {
                    _dtSales.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtSearchSales.Text.Trim());
                }
                catch
                {
                    MessageBox.Show("لا يمكن كتابة احرف");
                }
            }
            else if (FilterColumn == "SalesDate") // فلترة حسب التاريخ/الوقت
            {
                // نحوله إلى نص ونستخدم LIKE عليه
                _dtSales.DefaultView.RowFilter = string.Format("CONVERT([{0}], System.String) LIKE '%{1}%'", FilterColumn, txtSearchSales.Text.Trim().Replace("'", "''"));
            }

            else // باقي الأعمدة النصّيّة مثل UserName
                _dtSales.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtSearchSales.Text.Trim().Replace("'", "''"));
        }

    }
}
