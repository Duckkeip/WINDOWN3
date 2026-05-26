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
using WinFormsApp1.Models;

namespace WinFormsApp1
{
    public partial class fNewRoom : Form
    {
        Room room;
        public fNewRoom()
        {
            InitializeComponent();
        }

        private void roomClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void roomSave_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(roomType.Text))
            {
                toolTip1.Show("Hãy nhập loại phòng?", roomID, 0, 0, 1000);
                return;
            }
            if (string.IsNullOrWhiteSpace(roomStudent.Text))
            {
                toolTip1.Show("Hãy nhập số lượng sinh viên phòng?", roomStudent, 0, 0, 1000);
                return;
            }
            if (string.IsNullOrWhiteSpace(roomStatus.Text))
            {
                toolTip1.Show("Hãy nhập trạng thái phòng?", roomStatus, 0, 0, 1000);
                return;
            }
            try
            {
                room = new Room();
                room.RoomType = roomType.Text;
                room.QuantityStudent = int.Parse(roomStudent.Text);
                room.Status = roomStatus.Text;
                room.Price = decimal.Parse(roomPrice.Text);
                using (var db = new EFCore())
                {
                    db.Rooms.Add(room);
                    db.SaveChanges();
                }
                roomType.SelectedIndex = -1;
                roomStudent.ResetText();
                roomStatus.SelectedIndex = -1;
                roomPrice.ResetText();
                toolTip1.Show("Lưu thành công!", roomSave, 0, 0, 1000);
            }
            catch (Exception ex)
            {
                toolTip1.Show("Lưu thất bại? Error: " + ex.Message, roomSave, 0, 0, 1000);
            }
            roomType.Focus();
        }

        private void fNewRoom_Load(object sender, EventArgs e)
        {

        }





        private void fNewRoom_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = false;
        }

        private void roomStudent_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
