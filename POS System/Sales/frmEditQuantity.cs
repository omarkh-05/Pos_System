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
    public partial class frmEditQuantity : Form
    {
        public short frmQuantity {  get; set; }
        public frmEditQuantity(short Quantity)
        {
            InitializeComponent();
            numericUpDown1.Value = Quantity;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            frmQuantity = Convert.ToInt16( numericUpDown1.Value);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void numericUpDown1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSave.PerformClick(); // يضغط OK ويغلق الفورم
            }
        }

        private void numericUpDown1_Click(object sender, EventArgs e)
        {
            TextBox tb = numericUpDown1.Controls[1] as TextBox;
            if (tb != null)
            {
                tb.SelectAll();
            }
        }

        private void numericUpDown1_Enter(object sender, EventArgs e)
        {
            TextBox tb = numericUpDown1.Controls[1] as TextBox;
            if (tb != null)
            {
                tb.SelectAll();
            }
        }
    }
}
