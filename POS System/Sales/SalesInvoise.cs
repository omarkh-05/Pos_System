using businessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Sales;
using Entities;
using WindowsFormsApp1.Users;

namespace WindowsFormsApp1
{
    public partial class SalesInvoise : UserControl
    {
        public SalesInvoise()
        {
            InitializeComponent();
        }

        private void dgvSales_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;


            if (dgvSales.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                string header = dgvSales.Columns[e.ColumnIndex].HeaderText;
                if (header == "Delete")
                {
                    if (MessageBox.Show("هل انت متأكد من حذف هذا المنتج؟", "تأكيد", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (dgvSales.CurrentRow != null)
                        {
                            dgvSales.Rows.Remove(dgvSales.CurrentRow);
                            UpdateTotalLabel(); // لو عندك دالة تحسب التوتال
                        }
                    }
                    else
                        return;
                }
                if (header == "Edit")
                {
                    short SalesQuantity = Convert.ToInt16(dgvSales.CurrentRow.Cells["cQuantity"].Value);

                    using (var editQuantity = new frmEditQuantity(SalesQuantity))
                    {
                        if (editQuantity.ShowDialog() == DialogResult.OK)
                        {
                            dgvSales.CurrentRow.Cells["cQuantity"].Value = editQuantity.frmQuantity;
                        }
                    }
                }
            }
        }
        private void dgvSales_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // ✅ إذا تم الضغط على الهيدر أو عمود غير صالح -> اطلع فوراً
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            if (dgvSales.Columns[e.ColumnIndex].Name == "cQuantity")
            {
                var row = dgvSales.Rows[e.RowIndex];

                int qty;
                decimal price = Convert.ToDecimal(row.Cells["cUnitPrice"].Value);
                int stockQty = Convert.ToInt32(row.Cells["cStockQty"].Value);

                if (int.TryParse(row.Cells["cQuantity"].Value?.ToString(), out qty))
                {
                    if (qty < 0)
                    {
                        MessageBox.Show("الكمية لا يمكن أن تكون سالبة");
                        row.Cells["cQuantity"].Value = 1;
                        qty = 1;
                    }
                    if (qty > stockQty)
                    {
                        MessageBox.Show("الكمية اكبر من الكمية المتوفرة في المخزن");
                        row.Cells["cQuantity"].Value = stockQty;
                        qty = stockQty;
                    }

                    row.Cells["cSubTotal"].Value = qty * price;
                    UpdateTotalLabel();
                }
                else
                {
                    MessageBox.Show("الكمية يجب أن تكون رقم صحيح");
                    row.Cells["cQuantity"].Value = 1;
                }
            }
        }
        public void AddCurrentProductToSales(string dgvproductName, decimal dgvprice, int dgvstockQty)
        {
            string productName = dgvproductName;
            decimal price = dgvprice;
            int stockQty = dgvstockQty;

            // إذا المنتج موجود بالفعل في Sales
            foreach (DataGridViewRow salesRow in dgvSales.Rows)
            {
                if (salesRow.Cells["cProduct"].Value.ToString() == productName)
                {
                    int currentQty = Convert.ToInt16(salesRow.Cells["cQuantity"].Value);
                    if (currentQty < stockQty)
                    {
                        int newQty = currentQty + 1;
                        salesRow.Cells["cQuantity"].Value = newQty;
                        salesRow.Cells["cSubTotal"].Value = newQty * price;
                    }
                    UpdateTotalLabel();
                    return;
                }
            }

            // إذا المنتج جديد
            dgvSales.Rows.Add(productName, 1, price, price, stockQty);
            UpdateTotalLabel();
        }


        void SalesDataGridSettings()
        {
            cbDiscount.SelectedIndex = 0;
            cbPaymentMethod.SelectedIndex = 0;
            if (!dgvSales.Columns.Contains("cStockQty"))
            {
                dgvSales.Columns.Add("cStockQty", "StockQty");
                dgvSales.Columns["cStockQty"].Visible = false;
            }
            DataGridViewButtonColumn Deletebtn = new DataGridViewButtonColumn
            {
                HeaderText = "Delete",
                Text = "-",
                UseColumnTextForButtonValue = true,
                Width = 60,
                Resizable = DataGridViewTriState.False,
            };
            DataGridViewButtonColumn Editbtn = new DataGridViewButtonColumn
            {
                HeaderText = "Edit",
                Text = "+",
                UseColumnTextForButtonValue = true,
                Width = 60,
                Resizable = DataGridViewTriState.False,
            };
            dgvSales.Columns.Add(Editbtn);
            dgvSales.Columns.Add(Deletebtn);

        }
        decimal CalculateTotal()
        {
            decimal total = 0;

            foreach (DataGridViewRow row in dgvSales.Rows)
            {
                if (row.Cells["cSubTotal"].Value != null)
                {
                    total += Convert.ToDecimal(row.Cells["cSubTotal"].Value);
                }
            }

            return total;
        }
        private void UpdateTotalLabel()
        {
            lblTotalPrice.Text = CalculateTotal().ToString();
        }



        //                  Sales Panel Buttons
        private void btnCancel_Click(object sender, EventArgs e)
        {
            var mainForm = this.FindForm() as frmMainPage; // ✅ جلب الفورم الحقيقي

            if (this.Parent != null)
            {
                if (mainForm._NumberOFSalesInvoice != 0)
                {
                    // إزالة اليوزر كونترول الحالي من البانل
                    this.Parent.Controls.Remove(this);
                    this.Dispose();

                    mainForm._NumberOFSalesInvoice -= 1;
                    mainForm.RefreshInvoiceCount(mainForm._NumberOFSalesInvoice);
                }
                else
                {
                    dgvSales.Rows.Clear();
                    lblTotalPrice.Text = "--";
                    lblDiscount.Text = "--";
                    cbDiscount.Enabled = true;
                    cbDiscount.SelectedIndex = 0;
                }
            }
        }
        private void cbDiscount_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (lblTotalPrice.Text == "--" || lblTotalPrice.Text == "0")
            {
                return;
            }
            decimal total = decimal.Parse(lblTotalPrice.Text);
            decimal discountAmount = 0;
            switch (cbDiscount.Text)
            {
                case "10%":
                    discountAmount = total * 0.1m;
                    break;
                case "20%":
                    discountAmount = total * 0.2m;
                    break;
                case "30%":
                    discountAmount = total * 0.3m;
                    break;
            }
            total -= discountAmount;
            lblDiscount.Text = discountAmount.ToString("0.00");
            lblTotalPrice.Text = total.ToString("0.00");
        }
        private async void btnPlaceOrder_Click(object sender, EventArgs e)
        {
            if (dgvSales.Rows.Count == 0)
            {
                MessageBox.Show("لا يوجد منتجات لإتمام الطلب", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string discountUsed = cbDiscount.Text == "None" ? "" : cbDiscount.Text;

            // إنشاء DataTable لتمريره كـ TVP
            DataTable dtProducts = new DataTable();
            dtProducts.Columns.Add("ProductName", typeof(string));
            dtProducts.Columns.Add("Quantity", typeof(short));
            dtProducts.Columns.Add("UnitPrice", typeof(decimal));
            dtProducts.Columns.Add("SubTotal", typeof(decimal));

            foreach (DataGridViewRow row in dgvSales.Rows)
            {
                if (row.IsNewRow) continue;

                string productName = row.Cells["cProduct"].Value.ToString();
                short quantity = Convert.ToInt16(row.Cells["cQuantity"].Value);
                decimal unitPrice = Convert.ToDecimal(row.Cells["cUnitPrice"].Value);
                decimal subTotal = Convert.ToDecimal(row.Cells["cSubTotal"].Value);

                dtProducts.Rows.Add(productName, quantity, unitPrice, subTotal);
            }

            SalesDetail sale = new SalesDetail
            {
                SalesDate = DateTime.Now,
                UserID = Convert.ToByte(UserSession.UserID),
                SalesDetails = dtProducts,
                Total = decimal.Parse(lblTotalPrice.Text),
                PaymentMethod = cbPaymentMethod.Text,
                DiscountUsed = discountUsed
            };

            SalesDetailBLL salesBLL = new SalesDetailBLL(sale);

            bool result = await salesBLL.SaveAsync();

            if (result)
            {
                MessageBox.Show("تم حفظ الفاتورة بنجاح", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvSales.Rows.Clear();
                lblTotalPrice.Text = "0";
                lblDiscount.Text = "None";
                cbDiscount.Enabled = true;
                cbDiscount.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("حدث خطأ أثناء حفظ الفاتورة", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }



        //                  Sales Invoice Load
        private void SalesInvoise_Load(object sender, EventArgs e)
        {
            SalesDataGridSettings();
        }

    }
}
