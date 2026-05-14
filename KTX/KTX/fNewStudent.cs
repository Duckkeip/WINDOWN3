using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Linq;
using WinFormsApp1.Models;
using KTX.Models;

namespace WinFormsApp1
{
    public partial class fNewStudent : Form
    {
        string maleOrFemale;
        Student student;
        DataAPI dataAPI = new DataAPI();
        public fNewStudent()
        {
            InitializeComponent();
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            Close();
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
                //e.Cancel = true;
            }
            else if (studentAddress.Text.Length > 100)
            {
                toolTip1.Show("Quê quán <= 100 ký tự?", studentAddress, 0, 0, 1000);
                e.Cancel = true;
            }
        }


        private void fNewStudent_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = false;
        }

        private void maleCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (femaleCheck.Checked)
            {
                femaleCheck.Checked = false;

            }
        }

        private void femaleCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (maleCheck.Checked)
            {
                maleCheck.Checked = false;


            }
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
                student = new Student();
                student.Name = studentName.Text;
                student.DoB = studentDoB.Value.Date;
                student.Class = studentClass.Text;
                student.Gender = femaleCheck.Checked ? "Nam" : "Nữ";
                student.Address = studentAddress.Text;
                using (var db = new EFCore())
                {
                    db.Students.Add(student);
                    db.SaveChanges();
                }
                studentName.ResetText();
                studentDoB.ResetText();
                studentClass.ResetText();
                studentAddress.ResetText();
                femaleCheck.CheckState = CheckState.Unchecked;
                maleCheck.CheckState = CheckState.Unchecked;
                toolTip1.Show("Lưu thành công!", btSave, 0, 0, 1000);
            }
            catch (Exception ex)
            {
                toolTip1.Show("Lưu thất bại? Error: " + ex.Message, btSave, 0, 0, 1000);
            }
            studentName.Focus();
        }


        private void fNewStudent_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void studentClass_TextChanged(object sender, EventArgs e)
        {
        }
    }
}
