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
    public partial class fEditRoom : Form
    {
        EFCore db = new EFCore();
        int ID;
        Room room;
        public fEditRoom(int roomID)
        {
            InitializeComponent();
            this.ID = roomID;
        }

        private void fEditRoom_Load(object sender, EventArgs e)
        {
            room = db.Rooms.Single(p => p.RoomID == ID);
            Text += " - Mã phòng " + room.RoomID.ToString();
            roomType.Text = room.RoomType;
            roomStudent.Text = room.QuantityStudent.ToString();
            roomStatus.Text = room.Status;
            roomPrice.Text = room.Price.ToString();
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

        }

        private void roomClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void fEditRoom_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = false;
        }

        private void roomID_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(roomID.Text))
            {
                toolTip1.Show("Hãy nhập mã phòng?", roomID, 0, 0, 1000);
                //e.Cancel = true;
            }
            else if (roomID.Text.Length > 100)
            {
                toolTip1.Show("Mã phòng <= 50 ký tự?", roomID, 0, 0, 1000);
                e.Cancel = true;
            }
        }

        private void roomType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
