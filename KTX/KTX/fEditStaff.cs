using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp1.Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WinFormsApp1
{
    public partial class fEditStaff : Form
    {
        string staffId;
        DataAPI dataAPI = new DataAPI();
        public fEditStaff(string id)
        {
            InitializeComponent();
            this.staffId = id;
        }
        private void staffAddress_TextChanged(object sender, EventArgs e)
        {

        }

        private void fEditStaff_Load(object sender, EventArgs e)
        {
            DataSet data = new DataSet();
            data = dataAPI.GetAllWhere("Staffs", "StaffID", staffId.ToString());

            DataTable dataTable = data.Tables[0];
            DataRow row = dataTable.Rows[0];

            staffID.Text = row[0].ToString();       // StaffID
            staffName.Text = row[1].ToString();     // Name
            staffAddress.Text = row[2].ToString();  // Address
            staffPhone.Text = row[3].ToString();    // Phone
            staffUsername.Text = row[4].ToString(); // Username
            staffPassword.Text = row[5].ToString(); // Password
        }

        private void staffClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void fEditStaff_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = false;
        }

        private void staffID_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(staffID.Text))
            {
                toolTip1.Show("Hãy nhập mã nhân viên?", staffID, 0, 0, 1000);
                //e.Cancel = true;
            }
            else if (staffID.Text.Length > 10)
            {
                toolTip1.Show("Mã nhân viên <= 10 ký tự?", staffID, 0, 0, 1000);
                e.Cancel = true;
            }
        }

        private void staffName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(staffID.Text))
            {
                toolTip1.Show("Hãy nhập tên nhân viên?", staffName, 0, 0, 1000);
                e.Cancel = true;
            }
            else if (staffID.Text.Length > 50)
            {
                toolTip1.Show("Tên nhân viên <= 50 ký tự?", staffName, 0, 0, 1000);
                e.Cancel = true;
            }
        }

        private void staffAddress_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(staffID.Text))
            {
                toolTip1.Show("Hãy nhập địa chỉ của nhân viên?", staffAddress, 0, 0, 1000);
                e.Cancel = true;
            }
            else if (staffID.Text.Length > 100)
            {
                toolTip1.Show("Địa chỉ <= 100 ký tự?", staffAddress, 0, 0, 1000);
                e.Cancel = true;
            }
        }

        private void staffPhone_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(staffPhone.Text))
            {
                toolTip1.Show("Hãy nhập số điện thoại của nhân viên?", staffPhone, 0, 0, 1000);
                e.Cancel = true;
            }
            else if (staffPhone.Text.Length > 100)
            {
                toolTip1.Show("Số điện thoại <= 100 ký tự?", staffPhone, 0, 0, 1000);
                e.Cancel = true;
            }
        }

        private void staffSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(staffID.Text))
            {
                toolTip1.Show("Hãy nhập mã nhân viên?", staffID, 0, 0, 1000);
                return;
            }
            if (string.IsNullOrWhiteSpace(staffName.Text))
            {
                toolTip1.Show("Hãy nhập tên nhân viên?", staffName, 0, 0, 1000);
                return;
            }
            if (string.IsNullOrWhiteSpace(staffAddress.Text))
            {
                toolTip1.Show("Hãy nhập địa chỉ nhân viên?", staffAddress, 0, 0, 1000);
                return;
            }
            if (string.IsNullOrWhiteSpace(staffPhone.Text))
            {
                toolTip1.Show("Hãy nhập số điện thoại nhân viên?", staffPhone, 0, 0, 1000);
                return;
            }
            string newRoom = "(N'" + staffName.Text + "', N'" +
                staffAddress.Text + "', '" + staffPhone.Text + "', '" +
                staffUsername.Text + "', '" + staffPassword.Text + "', 1)";
            dataAPI.Delete("Staffs", "StaffID", staffId);
            dataAPI.InsertInto("Staffs (Name, Address, Phone, Username, Password, Role)", newRoom);
            if (dataAPI.InsertInto("Staffs", newRoom))
            {
                MessageBox.Show("Sửa dữ liệu nhân viên thành công!");
            }
        }
    }
}
