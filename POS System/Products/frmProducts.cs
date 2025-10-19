using businessLayer;
using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.Products
{
    public partial class frmProducts : Form
    {
        private enum enMode { AddMode = 1, UpdateMode = 2 };
        enMode _mode = enMode.AddMode;
        short _productID = -1;
        public frmProducts(short productID)
        {
            InitializeComponent();

            _productID = productID;

            if(_productID == -1)
            {
                _mode = enMode.AddMode;
            }else
                _mode = enMode.UpdateMode;
        }

        Category _category;
        CategoryBLL _categoryBll;
        Product _product;
        ProductBLL _productBLL;
        private DataTable _dtAllProducts;
        private DataTable _dtProducts;



        //                      Data Grid View
        private async Task LoadProductsAsync()
        {
            _dtAllProducts = await ProductBLL.GetAllProducts(); // جلب البيانات من SQL
                                                                // نختار فقط الأعمدة المطلوبة للعرض
            _dtProducts = _dtAllProducts.DefaultView.ToTable(false, "ProductID", "ProductName", "CategoryName", "Quantity", "Price");
        }
        private async Task _GetAllProducts()
        {
            await LoadProductsAsync();

            // إعدادات DataGridView
            dgvProducts.AutoGenerateColumns = false;
            dgvProducts.AllowUserToAddRows = false;
            dgvProducts.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgvProducts.MultiSelect = false;
            dgvProducts.RowHeadersVisible = false;
            dgvProducts.EnableHeadersVisualStyles = false;
            dgvProducts.AllowUserToResizeColumns = false;
            dgvProducts.AllowUserToResizeRows = false;

            // مسح الأعمدة القديمة
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

            // إضافة أزرار Update و ProductInfo
            DataGridViewButtonColumn editBtn = new DataGridViewButtonColumn
            {
                HeaderText = "Update",
                Text = "✏️",
                UseColumnTextForButtonValue = true,
                Width = 150,
                Resizable = DataGridViewTriState.False
            };
            dgvProducts.Columns.Add(editBtn);

            DataGridViewButtonColumn infoBtn = new DataGridViewButtonColumn
            {
                HeaderText = "ProductInfo",
                Text = "ℹ️",
                UseColumnTextForButtonValue = true,
                Width = 150,
                Resizable = DataGridViewTriState.False
            };
            dgvProducts.Columns.Add(infoBtn);

            // ضبط عرض الأعمدة
            if (dgvProducts.Columns.Contains("ProductID")) dgvProducts.Columns["ProductID"].Width = 160;
            if (dgvProducts.Columns.Contains("ProductName")) dgvProducts.Columns["ProductName"].Width = 160;
            if (dgvProducts.Columns.Contains("CategoryName")) dgvProducts.Columns["CategoryName"].Width = 180;
            if (dgvProducts.Columns.Contains("Quantity")) dgvProducts.Columns["Quantity"].Width = 130;
            if (dgvProducts.Columns.Contains("Price")) dgvProducts.Columns["Price"].Width = 125;

            // حجم الصفوف والهيدر
            dgvProducts.RowTemplate.Height = 45;
            dgvProducts.ColumnHeadersHeight = 40;
            dgvProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            // ألوان الصفوف متبادلة
            dgvProducts.RowsDefaultCellStyle.BackColor = Color.FromArgb(30, 30, 30);
            dgvProducts.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(35, 35, 35);

            // تصميم الخطوط في الهيدر
            dgvProducts.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            dgvProducts.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(40, 40, 40);
            dgvProducts.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            // تصميم الخطوط في الصفوف
            dgvProducts.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgvProducts.ForeColor = Color.Gray;

            // ربط البيانات
            dgvProducts.DataSource = _dtProducts;

            // حدث الأزرار
            dgvProducts.CellClick -= dgvProducts_CellClick;
            dgvProducts.CellClick += dgvProducts_CellClick;
        }
        private void dgvProducts_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvProducts.ClearSelection();
            dgvProducts.CurrentCell = null;
        }
        private async void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ProductBLL productBLL = new ProductBLL();
            if (e.RowIndex < 0) return;

            if (dgvProducts.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                CategoryBLL categoryBLL = new CategoryBLL();
                string header = dgvProducts.Columns[e.ColumnIndex].HeaderText;
                var productID = dgvProducts.Rows[e.RowIndex].Cells["ProductID"].Value;
                var categoryName = dgvProducts.Rows[e.RowIndex].Cells["CategoryName"].Value;
                _productID = Convert.ToInt16(productID);


                _product = await productBLL.GetProductByID(_productID);
                if (_product == null)
                {
                    MessageBox.Show("خطأ في العثور على المنتج");
                    return;
                }

                if (header == "Update")
                {
                    _mode = enMode.UpdateMode;

                   await LoadData();
                }
                else if (header == "ProductInfo")
                {
                    pnlProductInfo.Visible = true;
                    lblProductName.Text = _product.ProductName;
                    lblCategoryName.Text = categoryName.ToString();
                    lblQuantity.Text = _product.Quantity.ToString();
                    lblPrice.Text = _product.Price.ToString();
                    lblCost.Text = _product.Cost.ToString();
                    lblExDate.Text = _product.ExpireDate.ToShortDateString();
                    lblBarcode.Text = _product.Barcode;
                }
            }
        }



        //                      Save Category
        async Task FillCategoryCB()
        {
            DataTable dt = await CategoryBLL.GetAllCategories();
            foreach (DataRow row in dt.Rows)
            cbCategory.Items.Add(row["CategoryName"]);
        }
        private void btnCategorySave_Click(object sender, EventArgs e)
        {
            if(IsTextBoxEmpty(txtCategoryName.Text,btnCategorySave))
            {
                return;
            }


            if (MessageBox.Show("هل انت متأكد من اضافة هذا الصنف؟", "تأكيد", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if(_category == null)
                    _category = new Category();

                _category.CategoryName = txtCategoryName.Text;
                    if (pbUserimg.ImageLocation == null) _category.ImagePath =  null;
                else _category.ImagePath = pbUserimg.ImageLocation;

                if (_categoryBll == null)
                    _categoryBll = new CategoryBLL();

                _categoryBll.CurrentCategory = _category;

                if (_categoryBll.Save())
                {
                    MessageBox.Show((" تم إضافة ") + $" كصنف  {_category.CategoryName} ");
                    cbCategory.Items.Add(txtCategoryName.Text);
                }
                else
                    MessageBox.Show((" تعذر إضافة ") + $" {_category.CategoryName} ");

            }
            else
                return;
        }



        //                      Save Product
        private DateTime? SafeSqlDate(DateTime dt)
        {
            if (dt < (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue ||
                dt > (DateTime)System.Data.SqlTypes.SqlDateTime.MaxValue)
                return null;
            return dt;
        }
        async Task MoveDataToDB()
        {
            CategoryBLL categoryBLL = new CategoryBLL(); 
            if(_product == null)
                _product = new Product();

            short CategoryID = await categoryBLL.GetCategoryID(cbCategory.Text);

            _product.ProductName = txtProductName.Text;
            _product.Barcode = txtBarcode.Text;
            _product.ExpireDate = SafeSqlDate( dtpExpireDate.Value) ?? DateTime.Now;
            _product.Price =Convert.ToDecimal( txtPrice.Text);
            _product.Cost =Convert.ToDecimal( txtCost.Text);
            _product.Quantity = Convert.ToInt16(nudQuantity.Value);
            _product.CategoryID = CategoryID;
        }
        private async void btnProductSave_Click(object sender, EventArgs e)
        {
            if (!Validation())
            {
                return;
            }

            if (_mode == enMode.AddMode)
            {
                if (MessageBox.Show($"هل انت متأكد من اضافة هذا المنتج؟", "تأكيد", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                   await MoveDataToDB(); // تعبي البيانات من الفورم للكائن _product

                    _productBLL = new ProductBLL();
                    _productBLL.CurrentProduct = _product;

                    if (_productBLL.Save())
                    {
                        MessageBox.Show($"تم إضافة المنتج {_product.ProductName}");
                        _mode = enMode.UpdateMode;

                        await _GetAllProducts(); // تحديث الـDataGridView بعد الإضافة
                    }
                    else
                    {
                        MessageBox.Show($"تعذر إضافة {_product.ProductName}");
                    }
                }
                else
                    return;
            }
            else // UpdateMode
            {
                if (MessageBox.Show($"هل انت متأكد من تعديل هذا المنتج؟", "تأكيد", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    await MoveDataToDB(); // تعبي البيانات الجديدة من الفورم للكائن _product

                    _productBLL = new ProductBLL(_product);
                    _productBLL.CurrentProduct = _product;

                    if (_productBLL.Save())
                    {
                        MessageBox.Show($"تم تعديل المنتج {_product.ProductName}");

                        await _GetAllProducts(); // تحديث الـDataGridView بعد التعديل
                    }
                    else
                    {
                        MessageBox.Show($"تعذر تعديل {_product.ProductName}");
                    }
                }
                else
                    return;
            }


        }



        //                      Load
        async Task LoadData()
        {
            ProductBLL productBLL = new ProductBLL();
            CategoryBLL categoryBLL = new CategoryBLL();
            await _GetAllProducts();
            await FillCategoryCB();

            if (_mode == enMode.AddMode)
            {
                _product = new Product();
                _productBLL = new ProductBLL();
                return;
            }
            _product = await productBLL.GetProductByID(_productID);

            if (_product == null)
            {
                MessageBox.Show("خطأ في جلب المنتج");
                return;
            }
            _productBLL = new ProductBLL(_product);
            _productBLL.CurrentProduct = _product;

            string CategoryName =await categoryBLL.GetCategoryName(_product.CategoryID);

            txtProductName.Text = _product.ProductName;
            cbCategory.Text = CategoryName;
            nudQuantity.Value = _product.Quantity;
            txtPrice.Text = _product.Price.ToString();
            txtCost.Text = _product.Cost.ToString();
            txtBarcode.Text = _product.Barcode.ToString();
            dtpExpireDate.Value = _product.ExpireDate;
        }
        private async void frmProducts_Load(object sender, EventArgs e)
        {
            await LoadData();
        }



        //                      Validation
        bool IsTextBoxEmpty(string input, Control control)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        bool Validation()
        {
            if (IsTextBoxEmpty(cbCategory.Text, btnProductSave) || IsTextBoxEmpty(txtProductName.Text, btnProductSave) || IsTextBoxEmpty(txtBarcode.Text, btnProductSave) ||
                IsTextBoxEmpty(txtCost.Text, btnProductSave) || IsTextBoxEmpty(txtPrice.Text, btnProductSave))
            {

                errorProvider1.SetError(btnProductSave, "بعض البيانات لا يمكن ان تكون فارغة ");
                return false;
            }
            if (_mode == enMode.AddMode && nudQuantity.Value == 0)
            {
                errorProvider1.SetError(btnProductSave, "كمية المنتج لا يمكن ان تكون 0");
                return false;
            }
            errorProvider1.SetError(btnProductSave, string.Empty);
            return true;
        }



        //                      Only Digit Barcode
        private void txtBarcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true; // Prevent the character from being entered
            }
        }

        private void lblSetImage_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string selectedFilePath = openFileDialog1.FileName;
                pbUserimg.Load(selectedFilePath);
                // pbPhoto.BackgroundImage = Image.FromFile(selectedFilePath);
                lblRemove.Visible = true;

            }
        }

        private void lblRemove_Click(object sender, EventArgs e)
        {
            pbUserimg.ImageLocation = null;
        }
    }
}
