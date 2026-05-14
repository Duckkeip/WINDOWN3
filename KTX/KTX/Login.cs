using KTX.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1;

public partial class fLogin : Form
{
    public fLogin()
    {
        InitializeComponent();
    }
    private void btCancel_Click(object sender, EventArgs e)
    {
        Application.Exit();
    }
    private void btLogin_Click(object sender, EventArgs e)
    {
        if (txtName.Text == "")
        {
            toolTip1.Show("Bạn phải nhập tên người dùng?", txtName, 0, 0, 1000);
            txtName.Select();
        }
        else if (txtPassword.Text == "")
        {
            toolTip1.Show("Hãy nhập mật khẩu?", txtPassword, 0, 0, 1000);
            txtPassword.Select();
        }
        else
        {
            try
            {
                using (var db = new EFCore())
                {
                    Utility.staff = db.Staffs.SingleOrDefault(e => e.Username == txtName.Text && e.Password == txtPassword.Text);
                    if (Utility.staff != null) //Nếu đăng nhập thành công
                        DialogResult = DialogResult.OK; //đóng form
                    else
                        MessageBox.Show("Sai tên người dùng hoặc mật khẩu");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi"); ;
            }
        }
    }

    private void txtPassword_TextChanged(object sender, EventArgs e)
    {

    }

    private void txtName_TextChanged(object sender, EventArgs e)
    {

    }

    private void fLogin_Load(object sender, EventArgs e)
    {

    }
}

