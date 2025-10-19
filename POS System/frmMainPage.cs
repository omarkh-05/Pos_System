using businessLayer;
using Entities;
using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Categories;
using WindowsFormsApp1.Products;
using WindowsFormsApp1.Sales;
using WindowsFormsApp1.Users;

namespace WindowsFormsApp1
{
    public partial class frmMainPage : Form
    {
        public frmMainPage()
        {
            InitializeComponent();
        }
        SalesInvoise _ActiveInvoice;
        private DataTable _dtAllProducts;
        private DataTable _dtProducts;
        short _categoryID;
        short _productID = 1;
        bool _IsCategoryChosen = false;
        public byte _NumberOFSalesInvoice = 0;
         public string _NumberOfSalesLabel = "";

        //                  Add Category Buttons
        private async Task AddCategoryButtonsAsync()
        {
            pnlCategories.Controls.Clear();
            DataTable dt = await CategoryBLL.GetAllCategories();

            if (dt == null || dt.Rows.Count == 0)
            {
                MessageBox.Show("لا يوجد أصناف لعرضها");
                return;
            }

            foreach (DataRow row in dt.Rows)
            {
                Button btn = new Button();
                btn.Width = 160;
                btn.Height = 126;
                btn.Tag = row["CategoryID"];
                btn.FlatStyle = FlatStyle.Flat;
                btn.Margin = new Padding(10);
                btn.BackgroundImageLayout = ImageLayout.Stretch;

                // تحميل الصورة إذا موجودة
                if (row["ImagePath"] != DBNull.Value)
                {
                    string imgPath = row["ImagePath"].ToString();
                    if (System.IO.File.Exists(imgPath))
                        btn.BackgroundImage = Image.FromFile(imgPath);
                }

                // عند الضغط على زر الكاتيجوري
                btn.Click += async (s, e) =>
                {
                    _IsCategoryChosen = true;
                    short catID = Convert.ToInt16(btn.Tag);
                    _categoryID = catID;
                    await ShowProducts();
                };

                pnlCategories.Controls.Add(btn);
            }

            // إعداد FlowLayoutPanel
            pnlCategories.FlowDirection = FlowDirection.LeftToRight;
            pnlCategories.WrapContents = false;
            pnlCategories.AutoScroll = true; // Scroll أفقي
        }

       

        //                  Products Date Grid View
        private async Task LoadProductsByCategoryAsync(short categoryID)
        {
            _dtAllProducts = await ProductBLL.GetProductsByCategory(categoryID);

            // جلب فقط الأعمدة الموجودة في SP
            _dtProducts = _dtAllProducts.DefaultView.ToTable(false,
                "ProductID", "ProductName", "CategoryName", "Quantity", "Price", "Barcode");
        }
        private async Task LoadProductsAsync()
        {
            _dtAllProducts = await ProductBLL.GetAllProducts(); // جلب البيانات من SQL
                                                                // نختار فقط الأعمدة المطلوبة للعرض
            _dtProducts = _dtAllProducts.DefaultView.ToTable(false, "ProductID", "ProductName", "CategoryName", "Quantity", "Price", "Barcode");
        }
        public async Task ShowProducts()
        {

            if (_IsCategoryChosen)
            {
                await LoadProductsByCategoryAsync(_categoryID);
            }
            else
                await LoadProductsAsync();

            dgvProducts.AutoGenerateColumns = false;
            dgvProducts.AllowUserToAddRows = false;
            dgvProducts.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgvProducts.MultiSelect = false;
            dgvProducts.RowHeadersVisible = false;
            dgvProducts.EnableHeadersVisualStyles = false;
            dgvProducts.AllowUserToResizeColumns = false;
            dgvProducts.AllowUserToResizeRows = false;

            dgvProducts.Columns.Clear();

            // إنشاء الأعمدة من DataTable
            foreach (DataColumn col in _dtProducts.Columns)
            {
                dgvProducts.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    Name = col.ColumnName,
                    HeaderText = col.ColumnName,
                    DataPropertyName = col.ColumnName,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
                    Resizable = DataGridViewTriState.False
                });
            }

            // إضافة زر Update فقط
            DataGridViewButtonColumn editBtn = new DataGridViewButtonColumn
            {
                Name = "Update",
                HeaderText = "Update",
                Text = "✏️",
                UseColumnTextForButtonValue = true,
                Width = 150,
                Resizable = DataGridViewTriState.False,
            };
            DataGridViewButtonColumn Addbtn = new DataGridViewButtonColumn
            {
                Name = "Add",
                HeaderText = "Add",
                Text = "+",
                UseColumnTextForButtonValue = true,
                Width = 150,
                Resizable = DataGridViewTriState.False,
            };
            dgvProducts.Columns.Add(Addbtn);
            dgvProducts.Columns.Add(editBtn);
            // ضبط عرض الأعمدة
            dgvProducts.Columns["ProductID"].Width = 120;
            dgvProducts.Columns["ProductName"].Width = 550;
            if (dgvProducts.Columns.Contains("CategoryName")) dgvProducts.Columns["CategoryName"].Width = 175;
            dgvProducts.Columns["Quantity"].Width = 100;
            dgvProducts.Columns["Price"].Width = 100;
            dgvProducts.Columns["Barcode"].Width = 165;

            dgvProducts.RowTemplate.Height = 45;
            dgvProducts.ColumnHeadersHeight = 40;
            dgvProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            dgvProducts.RowsDefaultCellStyle.BackColor = Color.FromArgb(30, 30, 30);
            dgvProducts.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(35, 35, 35);

            dgvProducts.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            dgvProducts.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(40, 40, 40);
            dgvProducts.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            dgvProducts.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgvProducts.ForeColor = Color.Gray;

            dgvProducts.DataSource = _dtProducts;

            dgvProducts.CellClick -= dgvProducts_CellClick;
            dgvProducts.CellClick += dgvProducts_CellClick;
        }
        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;


            if (dgvProducts.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                var productID = dgvProducts.Rows[e.RowIndex].Cells["ProductID"].Value;
                string header = dgvProducts.Columns[e.ColumnIndex].HeaderText;
                _productID = Convert.ToInt16(productID);
                if (header == "Update")
                {
                    frmProducts frmProducts = new frmProducts(_productID);
                    if (CheckIfFormOpen(frmProducts))
                    {
                        return;
                    }

                    OpenFormInPanel(frmProducts);
                }
                if (header == "Add")
                {
                    if (dgvProducts.CurrentRow == null) return;

                    var row = dgvProducts.CurrentRow;

                    string dgvproductName = row.Cells["ProductName"].Value.ToString();
                    decimal dgvprice = Convert.ToDecimal(row.Cells["Price"].Value);
                    int dgvstockQty = Convert.ToInt32(row.Cells["Quantity"].Value);

                    if(_ActiveInvoice == null)
                   salesInvoise1.AddCurrentProductToSales(dgvproductName, dgvprice, dgvstockQty);
                    else if(_NumberOFSalesInvoice == 0)
                        salesInvoise1.AddCurrentProductToSales(dgvproductName, dgvprice, dgvstockQty);
                    else
                        _ActiveInvoice.AddCurrentProductToSales(dgvproductName, dgvprice, dgvstockQty);
                }
            }

        }
        private void dgvProducts_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvProducts.ClearSelection();
            dgvProducts.CurrentCell = null;
        }



        //                  Add New Invoice
        public void UpdateNumberOfInvoise(byte NumberOFSalesInvoice)
        {
            _NumberOFSalesInvoice += 1;
            lblOpenedSalesInvoice.Text = _NumberOFSalesInvoice.ToString();
        }
        public void RefreshInvoiceCount(byte Numberofslaesinvois)
        {
            lblOpenedSalesInvoice.Text = Numberofslaesinvois.ToString();
        }
        private void btnAddNewSales_Click(object sender, EventArgs e)
        {
            UpdateNumberOfInvoise(_NumberOFSalesInvoice);

            SalesInvoise newInvoice = new SalesInvoise();

            // ضبط الـ Dock حتى يغطي كامل البانل أو حسب تصميمك
            newInvoice.Dock = DockStyle.Fill;

            // إضافته فوق العناصر السابقة في البانل
            pnlSales.Controls.Add(newInvoice);
            newInvoice.BringToFront();

            _ActiveInvoice = newInvoice;
        }



        //                  Load
        private async void frmMainPage_Load(object sender, EventArgs e)
        {
            await AddCategoryButtonsAsync();
            await ShowProducts();

            cbFilter.SelectedIndex = 1;
            ChangingUserNameLabel();
        }



        //                  Open Menu Buttons in Panel
        private Form currentForm = null; // متغير لتخزين الفورم المفتوح حالياً
        private void OpenFormInPanel(Form frm)
        {
            if (frm == null) return; // حماية من null
            try
            {
                pnlSearchBox.Visible = false;
                pnlCategories.Enabled = false;
                // اغلق الفورم الحالي إن وجد
                if (currentForm != null)
                {
                    if (!currentForm.IsDisposed)
                    {
                        currentForm.Close();
                    }
                    pnlProducts?.Controls.Remove(currentForm);
                    currentForm?.Dispose();
                    currentForm = null;
                }

                currentForm = frm;

                frm.TopLevel = false;
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.Dock = DockStyle.Fill;

                pnlProducts?.Controls.Add(frm);
                frm.BringToFront();
                frm.Show();

                // حدث عند إغلاق الفورم يدوياً
                frm.FormClosed += (s, e) =>
                {
                    currentForm = null;
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show($"حدث خطأ أثناء فتح الفورم: {ex.Message}");
            }
        }
        private bool CheckIfFormOpen(Form frm)
        {
            if (frm == null) return false; // حماية من null

            if (currentForm != null && !currentForm.IsDisposed)
            {
                if (currentForm.GetType() == frm.GetType())
                {
                    MessageBox.Show("انت في هذه الصفحة حاليا");
                    return true;
                }
            }
            return false;
        }



        //                  Menu Buttons hover
        void Button_MouseEnter(object sender, EventArgs e)
        {
            if (sender is IconButton btn)
            {

                btn.BackColor = TransparencyKey;
                btn.ForeColor = Color.FromArgb(192, 0, 0);
                btn.IconColor = Color.FromArgb(192, 0, 0);
            }
        }
        void Button_MouseLeave(object sender, EventArgs e)
        {
            if (sender is IconButton btn)
            {
                btn.BackColor = TransparencyKey;
                btn.ForeColor = Color.White;
                btn.IconColor = Color.Gray;
            }
        }



        //                  NavBar
        private void iconButton4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("هل تريد تأكيد تسجيل الخروج", "تأكيد", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string path = ConfigurationManager.AppSettings["LogPath"];

                using (StreamWriter writer = new StreamWriter(path, true))
                {
                    writer.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - User {UserSession.UserName} logged out");
                }

                this.Close();
                frmUserLogin frmUserLogin = new frmUserLogin();
                frmUserLogin.ShowDialog();
            }
            else
                return;

        }
        private async void btnPOS_Click(object sender, EventArgs e)
        {
            if (currentForm != null && !currentForm.IsDisposed)
            {
                currentForm.Close();
                pnlSearchBox.Visible = true;
                pnlCategories.Enabled = true;

                await ShowProducts();
            }
            else
                MessageBox.Show("انت في هذه الصفحة حاليا");

        }
        private void iconButton3_Click(object sender, EventArgs e)
        {
            frmUserInfo frmUserInfo = new frmUserInfo(0);
            if (CheckIfFormOpen(frmUserInfo))
            {
                return;
            }
            OpenFormInPanel(frmUserInfo);
        }
        private void iconButton2_Click(object sender, EventArgs e)
        {
            frmProducts frmProducts = new frmProducts(-1);
            if (CheckIfFormOpen(frmProducts))
            {
                return;
            }
            OpenFormInPanel(frmProducts);
        }
        private void iconButton1_Click(object sender, EventArgs e)
        {
            frmSales frmSales = new frmSales();
            if (CheckIfFormOpen(frmSales))
            {
                return;
            }
            OpenFormInPanel(frmSales);
        }
        private void btnCategories_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Coming Soon");
            return;

            frmCategories frmCategories = new frmCategories();
            if (CheckIfFormOpen(frmCategories))
            {
                return;
            }
            OpenFormInPanel(frmCategories);
        }
        void ChangingUserNameLabel()
        {
           lblUserName.Text = UserSession.UserName;
        }



        //                  Search Panel
        private void txtSearchProducts_Click(object sender, EventArgs e)
        {
            txtSearchProducts.Text = "";
        }
        private void txtSearchProducts_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;

                if (dgvProducts.Rows.Count == 0) return; // لو ما فيه أي صفوف

                // إذا لم يكن هناك صف محدد حاليًا، اختار أول صف
                if (dgvProducts.CurrentRow == null)
                {
                    dgvProducts.CurrentCell = dgvProducts.Rows[0].Cells[0];
                }

                btnAddProductToSale.PerformClick();
            }
        }
        private void txtSearchProducts_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";
            //Map Selected Filter to real Column name 
            switch (cbFilter.Text)
            {
                case "Name":
                    FilterColumn = "ProductName";
                    break;

                case "Barcode":
                    FilterColumn = "Barcode";
                    break;

                case "Price":
                    FilterColumn = "Price";
                    break;

                default:
                    FilterColumn = "Barcode";
                    break;

            }

            //Reset the filters in case nothing selected or filter value conains nothing.
            if (txtSearchProducts.Text.Trim() == "" || FilterColumn == "None")
            {
                _dtProducts.DefaultView.RowFilter = "";
                return;
            }


            if (FilterColumn == "Price")
                //in this case we deal with integer not string.
                try
                {
                    _dtProducts.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtSearchProducts.Text.Trim());
                }
                catch
                {
                    MessageBox.Show("لا يمكن كتابة احرف");
                }

            else
                _dtProducts.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtSearchProducts.Text.Trim());
        }
        private async void btnrefresh_Click(object sender, EventArgs e)
        {
            _IsCategoryChosen = false;
            await ShowProducts();
        }
        private void btnAddProductToSale_Click(object sender, EventArgs e)
        {
            if (dgvProducts.CurrentRow == null) return;

            var row = dgvProducts.CurrentRow;

            string dgvproductName = row.Cells["ProductName"].Value.ToString();
            decimal dgvprice = Convert.ToDecimal(row.Cells["Price"].Value);
            int dgvstockQty = Convert.ToInt32(row.Cells["Quantity"].Value);
            salesInvoise1.AddCurrentProductToSales(dgvproductName, dgvprice, dgvstockQty);
        }



    }
}
