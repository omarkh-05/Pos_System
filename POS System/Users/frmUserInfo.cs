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

namespace WindowsFormsApp1.Users
{
    public partial class frmUserInfo : Form
    {
        //               Objects
        private enum enMode { AddMode = 1, UpdateMode = 2 };
        enMode _mode = enMode.AddMode;
        private byte _UserID = 0;
        User _user;
        UserBLL _userBLL;
        public frmUserInfo(byte UserID)
        {
            _UserID = UserID;
            InitializeComponent();
            if (_UserID == 0)
            {
                _mode = enMode.AddMode;
            }else
                _mode = enMode.UpdateMode;
        }
        private DataTable _dtAllUsers;
        private DataTable _dtUsers;



        //                       DataGridView
        private async Task LoadUsersAsync()
        {
            _dtAllUsers = await UserBLL.GetAllUsers(); // انتظر Task لينتهي
            _dtUsers = _dtAllUsers.DefaultView.ToTable(false, "UserID", "UserName", "Role", "IsActive");
        }
        private async Task _GetAllUsers()
        {
            await LoadUsersAsync(); // أولاً نحصل على البيانات

            // إعدادات أساسية للـ DataGridView
            dgvUserInfo.AutoGenerateColumns = false;
            dgvUserInfo.AllowUserToAddRows = false;
            dgvUserInfo.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgvUserInfo.MultiSelect = false;
            dgvUserInfo.RowHeadersVisible = false;
            dgvUserInfo.EnableHeadersVisualStyles = false;
            dgvUserInfo.AllowUserToResizeColumns = false;
            dgvUserInfo.AllowUserToResizeRows = false;

            // مسح الأعمدة القديمة
            dgvUserInfo.Columns.Clear();

            // إنشاء الأعمدة من DataTable المختار
            foreach (DataColumn col in _dtUsers.Columns)
            {
                dgvUserInfo.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    Name = col.ColumnName,
                    HeaderText = col.ColumnName,
                    DataPropertyName = col.ColumnName,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
                    Resizable = DataGridViewTriState.False
                });
            }

            // إضافة أزرار تعديل وحذف/يوزر
            DataGridViewButtonColumn editBtn = new DataGridViewButtonColumn
            {
                HeaderText = "Update",
                Text = "✏️",
                UseColumnTextForButtonValue = true,
                Width = 100,
                Resizable = DataGridViewTriState.False
            };
            dgvUserInfo.Columns.Add(editBtn);

            DataGridViewButtonColumn userBtn = new DataGridViewButtonColumn
            {
                HeaderText = "User",
                Text = "👤",
                UseColumnTextForButtonValue = true,
                Width = 100,
                Resizable = DataGridViewTriState.False
            };
            dgvUserInfo.Columns.Add(userBtn);
            DataGridViewButtonColumn deletebtn = new DataGridViewButtonColumn
            {
                HeaderText = "Delete",
                Text = "🗙",
                UseColumnTextForButtonValue = true,
                Width = 100,
                Resizable = DataGridViewTriState.False
            };
            dgvUserInfo.Columns.Add(deletebtn);

            // ضبط عرض بعض الأعمدة
            if (dgvUserInfo.Columns.Contains("UserID")) dgvUserInfo.Columns["UserID"].Width = 200;
            if (dgvUserInfo.Columns.Contains("UserName")) dgvUserInfo.Columns["UserName"].Width = 200;
            if (dgvUserInfo.Columns.Contains("Role")) dgvUserInfo.Columns["Role"].Width = 200;
            if (dgvUserInfo.Columns.Contains("IsActive")) dgvUserInfo.Columns["IsActive"].Width = 200;

            // حجم الصفوف والهيدر
            dgvUserInfo.RowTemplate.Height = 45;
            dgvUserInfo.ColumnHeadersHeight = 40;
            dgvUserInfo.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            // ألوان صفوف متبادلة
            dgvUserInfo.RowsDefaultCellStyle.BackColor =Color.FromArgb(30,30,30);
            dgvUserInfo.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(35, 35, 35);

            // تصميم الخطوط في الهيدر
            dgvUserInfo.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            dgvUserInfo.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(40, 40, 40);
            dgvUserInfo.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            // تصميم الخطوط في الصفوف
            dgvUserInfo.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgvUserInfo.ForeColor = Color.Gray;

            // ربط البيانات
            dgvUserInfo.DataSource = _dtUsers;

            // حدث الأزرار
            dgvUserInfo.CellClick -= dgvUserInfo_CellClick;
            dgvUserInfo.CellClick += dgvUserInfo_CellClick;
        }
        private void dgvUserInfo_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvUserInfo.ClearSelection();
            dgvUserInfo.CurrentCell = null;
        }
        private async void dgvUserInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            UserBLL userBLL = new UserBLL();
            if (e.RowIndex < 0) return;

            if (dgvUserInfo.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                string header = dgvUserInfo.Columns[e.ColumnIndex].HeaderText;
                var UserID = dgvUserInfo.Rows[e.RowIndex].Cells["UserID"].Value;
                _UserID = Convert.ToByte( UserID);

                if (header == "Update")
                {
                    label7.Text = "New Password :";
                    _user = await userBLL.GetUserByID(_UserID);
                    if (_user != null)
                    {
                        _userBLL = new UserBLL(_user);
                        _mode = enMode.UpdateMode;
                        txtUserName.Text = _user.UserName;
                        cbRole.Text = _user.Role;
                        rbActive1.Checked = _user.IsActive ? true : false;
                        pbUserimg.ImageLocation = _user.ImagePath;
                    }
                    else
                    {
                        MessageBox.Show("خطاء في العثور على المستخدم");
                    }
                }
                else if (header == "User")
                {
                    label7.Text = "Confirm Pass :";
                    _user = await userBLL.GetUserByID(_UserID);
                    if (_user != null)
                    {
                        pnlUserInfo.Visible = true;
                        lblUserName.Text = _user.UserName;
                        lblRole.Text = _user.Role;
                        lblActive.Text = _user.IsActive ? "Active" : "Not Active";
                        customPictureBox1.ImageLocation = _user.ImagePath;
                    }
                    else
                    {
                        MessageBox.Show("خطاء في العثور على المستخدم");
                    }
                }
                else if (header == "Delete")
                {
                    label7.Text = "Confirm Pass :";
                    if (MessageBox.Show("هل انت متأكد من تعطيل هذا المستخدم؟", "تأكيد", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        userBLL.Delete(_UserID);
                    }
                    await _GetAllUsers();
                }
            }
        }



        //              Image
        private void SetImage_Click(object sender, EventArgs e)
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



        //               Data
         void LoadData()
        {
            if(_mode == enMode.AddMode)
            {
                _user = new User();
                _userBLL = new UserBLL();
                return;
            }

            
        }
         void MoveDataToDB()
        {
            if(_user == null)
                _user = new User();

            _user.UserName = txtUserName.Text;
            _user.Password = UserBLL.ComputeHash(txtConfirmPass.Text);
            _user.Role = cbRole.Text;
            _user.ImagePath = pbUserimg.ImageLocation; ;
            _user.IsActive = rbActive1.Checked?true:false;
        }
        private async void btnSave_Click(object sender, EventArgs e)
        {
          if(!Validation())
            {  
            return;
            }
               

            if (_mode == enMode.AddMode)
            {
                if (MessageBox.Show("هل انت متأكد من اضافة هذا المستخدم؟", "تأكيد", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    MoveDataToDB();

                        _userBLL = new UserBLL();

                    _userBLL.currentuser = _user;

                    if (_userBLL.Save())
                    {
                        MessageBox.Show((" تم إضافة ") + $" كمستخدم  {_user.UserName} ");
                        _mode = enMode.UpdateMode;

                        await _GetAllUsers();
                    }
                    else
                        MessageBox.Show((" تعذر إضافة ") + $" {_user.UserName} ");

                }
                else
                    return;
            }else
            {
                if (UserBLL.ComputeHash(txtPassword.Text) != _user.Password)
                {
                    errorProvider1.SetError(btnSave,"كلمة السر الحالية غير مطابقة مع كلمة السر الاصلية");
                    return;
                }
                if (MessageBox.Show("هل انت متأكد من تعديل هذا المستخدم؟", "تأكيد", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    MoveDataToDB();

                        _userBLL = new UserBLL(_user);

                    _userBLL.currentuser = _user;

                
                    if (_userBLL.Save())
                    {
                        MessageBox.Show((" تم تعديل ") + $" كمستخدم  {_user.UserName} ");

                        await _GetAllUsers();
                    }
                    else
                        MessageBox.Show((" تعذر تعديل ") + $" {_user.UserName} ");

                    label7.Text = "Confirm Pass :";

                }
                else

                    return;
            }
        }



        //              Validation
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
            if (IsTextBoxEmpty(txtUserName.Text, btnSave) || IsTextBoxEmpty(txtConfirmPass.Text, btnSave) || IsTextBoxEmpty(cbRole.Text, btnSave) || pbUserimg.ImageLocation == null || txtConfirmPass.Text.Length <= 15)
            {
                errorProvider1.SetError(btnSave, "بعض البيانات لا يمكن ان تكون فارغة / كلمة المرور اقل من 16 حرف");
                return false;
            }
            else if ( _mode==enMode.AddMode && txtPassword.Text != txtConfirmPass.Text)
            {
                errorProvider1.SetError(btnSave, "كلمة المرور غير متطابقة مع تأكيد كلمة المرور");
                return false;
            }
            errorProvider1.SetError(btnSave, string.Empty);
            return true;
        }



        //              Load
        private async void frmUserInfo_Load(object sender, EventArgs e)
        {
           await _GetAllUsers();
            LoadData();
        }



        //              Refresh
        private async void btnrefresh_Click(object sender, EventArgs e)
        {
            await _GetAllUsers();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void pbUserimg_Click(object sender, EventArgs e)
        {

        }
    }
}
