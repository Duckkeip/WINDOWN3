using KTX.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using WinFormsApp1.Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WinFormsApp1
{
    public partial class fEditStudent : Form
    {
        long ID;
        Student student;
        EFCore db = new EFCore();

        public fEditStudent(long ID)
        {
            InitializeComponent();
            this.ID = ID;
        }

        private void fEditStudent_Load(object sender, EventArgs e)
        {
            student = db.Students.Single(p => p.StudentID == ID);
            Text += " - Mã SV " + student.StudentID.ToString();
            studentName.Text = student.Name;
            studentAddress.Text = student.Address;
            studentClass.Text = student.Class;
            studentDoB.Text = student.DoB.ToString();
            if (student.Gender.Equals("Nam")) maleCheck.Checked = true;
            else femaleCheck.Checked = true;
        }

        private void studentName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(studentName.Text))
            {
                toolTip1.Show("Hãy nhập tên sinh viên?", studentName, 0, 0, 1000);
                //e.Cancel = true;
            }
            else if (studentName.Text.Length > 100)
            {
                toolTip1.Show("Tên khách hàng <= 100 ký tự?", studentName, 0, 0, 1000);
                e.Cancel = true;
            }
        }

        private void studentClass_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrWhiteSpace(studentClass.Text))
            {
                toolTip1.Show("Hãy nhập tên lớp?", studentClass, 0, 0, 1000);
                e.Cancel = true;
            }
            else if (studentClass.Text.Length > 250)
            {
                toolTip1.Show("Địa chỉ <= 50 ký tự?", studentClass, 0, 0, 1000);
                e.Cancel = true;
            }
        }



        private void studentDoB_Validating(object sender, CancelEventArgs e)
        {
            if (studentDoB.Value.Date > DateTime.Now.Date)
            {
                toolTip1.Show("Ngày/tháng/năm <= hiện tại?", studentDoB, 0, 0,
               1000);
                e.Cancel = true;
            }

        }

        private void studentAddress_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(studentAddress.Text))
            {
                toolTip1.Show("Hãy nhập quê quán?", studentAddress, 0, 0, 1000);
                e.Cancel = true;
            }
            else if (studentAddress.Text.Length > 100)
            {
                toolTip1.Show("Quê quán <= 100 ký tự?", studentAddress, 0, 0, 1000);
                e.Cancel = true;
            }
        }



        private void fEditStudent_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = false;
        }



        private void btSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(studentName.Text))
            {
                toolTip1.Show("Hãy nhập tên sinh viên phòng?", studentName, 0, 0, 1000);
                return;
            }
            if (string.IsNullOrWhiteSpace(studentDoB.Text))
            {
                toolTip1.Show("Hãy nhập ngày tháng năm sinh?", studentDoB, 0, 0, 1000);
                return;
            }
            if (string.IsNullOrWhiteSpace(studentClass.Text))
            {
                toolTip1.Show("Hãy nhập lớp học?", studentClass, 0, 0, 1000);
                return;
            }
            if (string.IsNullOrWhiteSpace(studentAddress.Text))
            {
                toolTip1.Show("Hãy nhập địa chỉ?", studentAddress, 0, 0, 1000);
                return;
            }
            try
            {
                student.Name = studentName.Text;
                student.DoB = studentDoB.Value.Date;
                student.Class = studentClass.Text;
                
                 if ((femaleCheck.CheckState == CheckState.Checked && maleCheck.CheckState == CheckState.Checked) || (femaleCheck.CheckState == CheckState.Unchecked && maleCheck.CheckState == CheckState.Unchecked)) student.Gender = "Khác";
                else if (femaleCheck.CheckState == CheckState.Checked) student.Gender = "Nữ";
                else if (maleCheck.CheckState == CheckState.Checked) student.Gender = "Nam";
                student.Address = studentAddress.Text;
                //db.Update(student);
                db.SaveChanges();
                toolTip1.Show("Lưu thành công.", btSave, 0, 0, 1000);
            }
            catch (Exception ex)
            {
                toolTip1.Show("Lưu thất bại? Error: " + ex.Message, btSave, 0, 0, 1000);
            }
            studentName.Focus();
        }

        private void btClose_Click_1(object sender, EventArgs e)
        {
            Close();
        }
    }
}
