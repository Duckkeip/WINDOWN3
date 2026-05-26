using Guna.UI2.WinForms;
using Guna.UI2.WinForms.Suite;
using KTX;
using KTX.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Reporting.Map.WebForms.BingMaps;
using Microsoft.Reporting.WinForms;
using Microsoft.ReportingServices.Interfaces;
using Microsoft.ReportingServices.ReportProcessing.ReportObjectModel;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Numerics;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp1.Models;
using static Guna.UI2.Native.WinApi;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WinFormsApp1
{

    public partial class QLKTX : Form
    {
        private System.Windows.Forms.Timer contractTimer;
        public QLKTX()
        {
            InitializeComponent();

        }
        public void reportStudentAndContract()
        {
            tabPage15.Controls.Clear();

            EFCore db = new EFCore();
            var reportViewer = new ReportViewer
            {
                ProcessingMode = ProcessingMode.Local
            };
            reportViewer.LocalReport.DataSources.Add(new
            ReportDataSource("DataSet1", db.Contracts.Select(s => new { StudentID = s.Student.StudentID, Name = s.Student.Name, Gender = s.Student.Gender, s.RoomID, s.Price }).ToList()));
            reportViewer.Dock = DockStyle.Fill;
            reportViewer.LocalReport.ReportPath =
            Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName +
            "\\Report\\rStudentGroupByContract.rdlc";
            Controls.Add(reportViewer);
            reportViewer.RefreshReport();
            tabPage15.Controls.Add(reportViewer);

        }
        public void reportRooms()
        {
            // Xóa reportViewer cũ trong tabPage16
            tabPage16.Controls.Clear();

            EFCore db = new EFCore();
            var reportViewer = new ReportViewer
            {
                ProcessingMode = ProcessingMode.Local
            };
            reportViewer.LocalReport.DataSources.Add(new
            ReportDataSource("DataSet1", db.Rooms.ToList()));
            reportViewer.Dock = DockStyle.Fill;
            reportViewer.LocalReport.ReportPath =
            Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName +
            "\\Report\\RoomChart.rdlc";
            reportViewer.RefreshReport();
            tabPage16.Controls.Add(reportViewer);
        }
        public void reportContract()
        {
            tabPage9.Controls.Clear();

            EFCore db = new EFCore();
            var reportViewer = new ReportViewer
            {
                ProcessingMode = ProcessingMode.Local
            };
            reportViewer.LocalReport.DataSources.Add(new
            ReportDataSource("DataSet2", db.Contracts.ToList()));
            reportViewer.Dock = DockStyle.Fill;
            reportViewer.LocalReport.ReportPath =
            Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName +
            "\\Report\\Contract.rdlc";
            Controls.Add(reportViewer);
            reportViewer.RefreshReport();
            tabPage9.Controls.Add(reportViewer);

        }
        public void reportBill(long id)
        {
            EFCore db = new EFCore();
            var reportViewer = new ReportViewer
            {
                ProcessingMode = ProcessingMode.Local
            };
            reportViewer.LocalReport.DataSources.Add(new
            ReportDataSource("DataSet1", db.Contracts.Where(s => s.StudentID == id).Select(s => new { StudentID = s.Student.StudentID, Name = s.Student.Name, Gender = s.Student.Gender, s.RoomID, s.Price }).ToList()));
            printID.Dock = DockStyle.Top;
            reportViewer.Dock = DockStyle.Fill;
            reportViewer.LocalReport.ReportPath =
            Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName +
            "\\Report\\Bill.rdlc";
            Controls.Add(printID);
            Controls.Add(reportViewer);
            reportViewer.RefreshReport();
            tabPage18.Controls.Add(reportViewer);

        }

        private void LoadStudents()
        {
            using (var db = new EFCore())
            {
                dataGridView1.DataSource = db.Students.Select(x => new { x.StudentID, x.Name, x.DoB, x.Class, x.Gender, x.Address }).ToList();
                dataGridView6.DataSource = db.Students.Select(x => new { x.StudentID, x.Name, x.DoB, x.Class, x.Gender, x.Address }).ToList();
                CountStudent.Text = "Số sinh viên: " + db.Students.Count().ToString();
            }
        }

        private void ContractTimer_Tick(object sender, EventArgs e)
        {
            UpdateCountDown();
            using (var db = new EFCore())
            {
                var expiredContracts = db.Contracts
                    .Where(c => c.EndDate <= DateTime.Now && c.IsNotified == false)
                    .Include(c => c.Student)
                    .ToList();

                foreach (var contract in expiredContracts)
                {
                    MessageBox.Show($"Hợp đồng #{contract.ContractID} của sinh viên {contract.Student.Name} đã hết hạn!");

                    // Đánh dấu đã thông báo
                    contract.IsNotified = true;
                    db.SaveChanges();
                }
            }
        }
        private void LoadRooms()
        {
            using (var db = new EFCore())
            {
                dataGridView2.DataSource = db.Rooms.Select(x => new {
                    x.RoomID,
                    x.RoomType,
                    x.QuantityStudent,
                    x.Status,
                    x.Price,
                    
                }).ToList();
            }
        }

        private void LoadContracts()
        {
            using (var db = new EFCore())
            {
                dataGridView3.DataSource = db.Contracts.Select(x => new {
                    x.ContractID,
                    x.StartDate,
                    x.EndDate,
                    x.StudentID,
                    x.RoomID,
                    x.Price,
                    
                }).ToList();

                // Cập nhật đếm ngược ngay
                if (!dataGridView3.Columns.Contains("CountDown"))
                    dataGridView3.Columns.Add("CountDown", "Còn lại");
                UpdateCountDown();
            }
        }
        private void QLKTX_Load(object sender, EventArgs e)
        {
            reportStudentAndContract();
            reportRooms();
            reportContract();
            using (var db = new EFCore())
            {
                LoadStudents();
                dataGridView6.DataSource = db.Students.Select(x => new { x.StudentID, x.Name, x.DoB, x.Class, x.Gender, x.Address }).ToList();
                LoadRooms();
                LoadContracts();
                dataGridView9.DataSource = db.Contracts.Select(x => new { x.ContractID, x.StartDate, x.EndDate, x.StudentID, x.RoomID, x.Price }).ToList();
                dataGridView4.DataSource = db.Staffs.Select(x => new { x.StaffID, x.Name, x.Address, x.Phone }).ToList();
            }


            // Login 
            fLogin f = new fLogin();

            if (f.ShowDialog() != DialogResult.OK)
                Application.Exit();
            else
            {
                f.Close();
                contractTimer = new System.Windows.Forms.Timer();
                contractTimer.Interval = 1000; // mỗi 1 giây
                contractTimer.Tick += ContractTimer_Tick;
                contractTimer.Start();
                if (Utility.staff != null)
                {
                    // Chào người dùng đăng nhập
                    hello.Text += " " + Utility.staff.Name;


                    // PHÂN QUYỀN USER THEO ROLE

                    // LEVEL 1
                    if (Utility.staff.Role == 1)
                    {
                        // Toàn quyền
                        // xem/xóa/sửa/nhập dữ liệu

                    }

                    // LEVEL 2
                    if (Utility.staff.Role == 2)
                    {
                        //Nhập liệu
                        // Không sửa xóa 
                        dataGridView1.ReadOnly = true;
                        dataGridView1.CellContentClick -= dataGridView1_CellContentClick;

                        dataGridView2.ReadOnly = true;
                        dataGridView2.CellContentClick -= dataGridView2_CellContentClick;

                        dataGridView4.ReadOnly = true;
                        dataGridView4.CellContentClick -= dataGridView4_CellContentClick;

                        dataGridView3.ReadOnly = true;
                        dataGridView3.CellContentClick -= dataGridView3_CellContentClick;

                        // Báo cáo 

                    }

                    // LEVEL 3
                    if (Utility.staff.Role == 3)
                    {
                        // Báo cáo 
                        tabControl1.Visible = false;
                        tabControl2.Visible = false;

                    }
                }

            }
        }
        private void UpdateCountDown()
        {
            foreach (DataGridViewRow row in dataGridView3.Rows)
            {
                if (row.Cells["EndDate"].Value != null)
                {
                    DateTime endDate = Convert.ToDateTime(row.Cells["EndDate"].Value);
                    TimeSpan remaining = endDate - DateTime.Now;

                    if (remaining.TotalSeconds <= 0)
                        row.Cells["CountDown"].Value = "Đã hết hạn";
                    else
                        row.Cells["CountDown"].Value = $"{remaining.Days} ngày {remaining.Hours} giờ {remaining.Minutes} phút {remaining.Seconds} giây";
                }
            }
        }
        private void QLKTX_Activated(object sender, EventArgs e)
        {
            using (var db = new EFCore())
            {
                dataGridView1.DataSource = db.Students.Select(x => new { x.StudentID, x.Name, x.DoB, x.Class, x.Gender, x.Address }).ToList();
                dataGridView2.DataSource = db.Rooms.Select(x => new { x.RoomID, x.RoomType, x.QuantityStudent, x.Status, x.Price }).ToList();
                dataGridView3.DataSource = db.Contracts.Select(x => new {
                    x.ContractID,
                    x.StartDate,
                    x.EndDate,
                    x.StudentID,
                    x.RoomID,
                    x.Price
                }).ToList();

                // Thêm cột đếm ngược nếu chưa có
                if (!dataGridView3.Columns.Contains("CountDown"))
                {
                    dataGridView3.Columns.Add("CountDown", "Còn lại");
                }
                UpdateCountDown(); // cập nhật ngay lần đầu
                dataGridView4.DataSource = db.Staffs.Select(x => new { x.StaffID, x.Name, x.Address, x.Phone }).ToList();
            }
        }

        private void studentAdd_Click(object sender, EventArgs e)
        {
            if (Utility.IsOpeningForm("fNewStudent")) ;
            fNewStudent f = new fNewStudent();
            if (f.ShowDialog() == DialogResult.OK)
            {
                LoadStudents();
                
            }
        }

        private void addNewRoom_Click(object sender, EventArgs e)
        {
            if (Utility.IsOpeningForm("fNewRoom")) ;
            fNewRoom f = new fNewRoom();
            if (f.ShowDialog() == DialogResult.OK)
            {
                LoadRooms();
                reportRooms();
            }
        }

        private void addNewStaff_Click(object sender, EventArgs e)
        {
            if (Utility.IsOpeningForm("fNewStaff")) ;
            fNewStaff f = new fNewStaff();
            f.Show();
        }

        private void roomType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void roomStatus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name.Equals("Xóa"))
            {
                try
                {
                    long StudentID = Convert.ToInt64(dataGridView1.Rows[e.RowIndex].Cells["StudentID"].Value);
                    using (var db = new EFCore())
                    {
                        Student student =
                        db.Students.Single(c => c.StudentID == StudentID);
                        if (MessageBox.Show("Bạn muốn xóa khách hàng " + student.Name,
                        "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                        == DialogResult.Yes)
                        {
                            db.Students.Remove(student);
                            db.SaveChanges();
                            QLKTX_Activated(sender, e);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi, chưa xóa được? Error: " + ex.Message);
                }
            }

            if (dataGridView1.Columns[e.ColumnIndex].Name.Equals("Sửa"))
            {
                try
                {
                    if (Utility.IsOpeningForm("fEditStudent")) ;
                    fEditStudent f = new fEditStudent((long)dataGridView1.Rows[e.RowIndex].Cells["StudentID"].Value);
                    f.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi, chưa sửa được? Error: " + ex.Message);
                }
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView2.Columns[e.ColumnIndex].Name.Equals("Delete"))
            {
                try
                {

                    int RoomID = Convert.ToInt32(dataGridView2.Rows[e.RowIndex].Cells["RoomID"].Value);
                    using (var db = new EFCore())
                    {
                        Room room =
                        db.Rooms.Single(c => c.RoomID == RoomID);
                        if (MessageBox.Show("Bạn muốn xóa phòng " + room.RoomID,
                        "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                        == DialogResult.Yes)
                        {
                            db.Rooms.Remove(room);
                            db.SaveChanges();
                            QLKTX_Activated(sender, e);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi, chưa xóa được? Error: " + ex.Message);
                }
            }
            if (dataGridView2.Columns[e.ColumnIndex].Name.Equals("Edit"))
            {
                try
                {
                    if (!Utility.IsOpeningForm("fEditRoom"))
                    {
                        fEditRoom f = new fEditRoom((int)dataGridView2.Rows[e.RowIndex].Cells["RoomID"].Value);
                        f.ShowDialog();
                        LoadRooms(); // cập nhật lại danh sách phòng sau khi sửa
                        reportRooms();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi, chưa sửa được? Error: " + ex.Message);
                }
            }


        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView4.Columns[e.ColumnIndex].Name.Equals("Xoa"))
            {
                try
                {
                    string staffID = dataGridView4.Rows[e.RowIndex].Cells["StaffID"].Value.ToString();
                    if (MessageBox.Show("Bạn muốn xóa nhân viên " + dataGridView4.Rows[e.RowIndex].Cells["Name"].Value, "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (true)
                        {
                            MessageBox.Show("Xóa dữ liệu thành công?");
                            QLKTX_Activated(sender, e);

                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi, chưa xóa được? Error: " + ex.Message);
                }
            }
            if (dataGridView4.Columns[e.ColumnIndex].Name.Equals("Sua"))
            {
                try
                {
                    if (Utility.IsOpeningForm("fEditStaff")) ;
                    fEditStaff f = new fEditStaff((string)dataGridView4.Rows[e.RowIndex].Cells["StaffID"].Value);
                    f.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi, chưa sửa được? Error: " + ex.Message);
                }
            }

        }
        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView3.Columns[e.ColumnIndex].Name.Equals("contractRemove"))
            {
                try
                {
                    int ContractID = Convert.ToInt32(dataGridView3.Rows[e.RowIndex].Cells["ID"].Value);
                    using (var db = new EFCore())
                    {
                        Contract contract =
                        db.Contracts.Single(c => c.ContractID == ContractID);

                        if (MessageBox.Show("Bạn muốn xóa hợp đồng " + contract.ContractID,
                        "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                        == DialogResult.Yes)
                        {
                            // Cập nhật lại trạng thái phòng về còn chỗ
                            Room room = db.Rooms.Single(r => r.RoomID == contract.RoomID);
                            int currentOccupants = db.Contracts.Count(c => c.RoomID == contract.RoomID);
                            if (currentOccupants - 1 < room.QuantityStudent)
                            {
                                room.Status = "Còn chỗ";
                                db.Rooms.Update(room);
                            }

                            db.Contracts.Remove(contract);
                            db.SaveChanges();
                            QLKTX_Activated(sender, e);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi, chưa xóa được? Error: " + ex.Message);
                }
            }
            if (dataGridView3.Columns[e.ColumnIndex].Name.Equals("contractEdit"))
            {
                addContract.Enabled = false;
                try
                {
                    int ContractID = Convert.ToInt32(dataGridView3.Rows[e.RowIndex].Cells["ID"].Value);
                    using (var db = new EFCore())
                    {
                        Contract contract =
                        db.Contracts.Single(c => c.ContractID == ContractID);
                        contractID.Text = contract.ContractID.ToString();
                        contractStudentID.Text = contract.StudentID.ToString();
                        contractRoomID.Text = contract.RoomID.ToString();
                        dateTimePickerStart.Text = contract.StartDate.ToString();
                        dateTimePickerEnd.Text = contract.EndDate.ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi, chưa sửa được? Error: " + ex.Message);
                }
            }
        }

        private void addContract_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(contractRoomID.Text))
            {
                toolTip1.Show("Hãy nhập mã phòng?", contractRoomID, 0, 0, 1000);
                return;
            }
            if (string.IsNullOrWhiteSpace(contractStudentID.Text))
            {
                toolTip1.Show("Hãy nhập mã sinh viên?", contractStudentID, 0, 0, 1000);
                return;
            }
            // DateTimePickerStart | DateTimePickerEnd
            // Truy vấn dữ liệu
            using (var db = new EFCore())
            {
                long studentID = long.Parse(contractStudentID.Text);
                int rooomID = int.Parse(contractRoomID.Text);
                Student student = db.Students.Single(s => s.StudentID == studentID);
                Room room = db.Rooms.Single(r => r.RoomID == rooomID);
                // nam không ở phòng nữ và ngược lại
                if (!student.Gender.Equals(room.RoomType)) MessageBox.Show("Sinh viên " + student.Gender + " không thể ở phòng " + room.RoomType);

                // Kiểm tra có phải hợp đồng mới không => mã số sinh viên đã tồn tại thì thời gian bắt đầu phải >
                // ngày kết thức của hợp đồng cũ, nêu không sẽ thông báo còn trong hợp đồng
                bool StudentExists = db.Contracts.Any(c => c.StudentID == studentID);
                // hợp đồng có tồn tại
                if (StudentExists)
                {
                    //DateTime currentDate = DateTime.UtcNow; // Ngày hiện tại

                    // Lấy hợp đồng cuối cùng của sinh viên mà ngày kết thúc < ngày bát đầu của hợp đồng mới
                    Contract latestContract = db.Contracts.Where(c => c.StudentID == studentID && c.EndDate < dateTimePickerStart.Value)
                        .OrderByDescending(c => c.EndDate)
                        .FirstOrDefault();
                    if (latestContract == null)
                    {
                        MessageBox.Show("Ngày kết thúc của hợp đồng cũ phải < hơn ngày bắt đầu của hợp đồng mới");

                    }
                    else if (dateTimePickerStart.Value > dateTimePickerEnd.Value)
                    {
                        MessageBox.Show("Ngày bắt đầu của hợp đồng phải bé hơn ngày kết thúc");

                    }
                    else
                    {
                        // Tiếp tục với quá trình lưu thông tin hợp đồng mới
                        Contract contract = new Contract();
                        contract.StudentID = long.Parse(contractStudentID.Text);
                        contract.RoomID = int.Parse(contractRoomID.Text);
                        contract.StartDate = dateTimePickerStart.Value;
                        contract.EndDate = dateTimePickerEnd.Value;
                        contract.Price = room.Price;
                        db.Contracts.Add(contract);
                        db.SaveChanges();
                        LoadRooms();      // thêm
                        LoadContracts();
                        QLKTX_Activated(sender, e);
                        toolTip1.Show("Thêm hợp đồng thành công!", addContract);

                    }
                }
                else
                {
                    // Sinh viên chưa có hợp đồng nào -> thêm mới luôn
                    if (dateTimePickerStart.Value >= dateTimePickerEnd.Value)
                    {
                        MessageBox.Show("Ngày bắt đầu phải bé hơn ngày kết thúc!");
                        return;
                    }

                    // Kiểm tra phòng còn chỗ không
                    int currentOccupants = db.Contracts.Count(c => c.RoomID == rooomID && c.EndDate > DateTime.Now);
                    if (currentOccupants >= room.QuantityStudent)
                    {
                        MessageBox.Show("Phòng " + rooomID + " đã đầy!");
                        return;
                    }

                    Contract contract = new Contract();
                    contract.StudentID = studentID;
                    contract.RoomID = rooomID;
                    contract.StartDate = dateTimePickerStart.Value;
                    contract.EndDate = dateTimePickerEnd.Value;
                    contract.Price = room.Price;
                    db.Contracts.Add(contract);

                    // Cập nhật trạng thái phòng nếu đầy
                    if (currentOccupants + 1 >= room.QuantityStudent)
                    {
                        room.Status = "Đầy";
                        db.Rooms.Update(room);
                    }
                    db.Rooms.Update(room);
                    db.SaveChanges();
                    LoadRooms();      // thêm
                    LoadContracts();
                    QLKTX_Activated(sender, e);
                    toolTip1.Show("Thêm hợp đồng thành công!", addContract);
                }

            }

        }

        private void saveContract_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(contractRoomID.Text))
            {
                toolTip1.Show("Hãy nhập mã phòng?", contractRoomID, 0, 0, 1000);
                return;
            }
            if (string.IsNullOrWhiteSpace(contractStudentID.Text))
            {
                toolTip1.Show("Hãy nhập mã sinh viên?", contractStudentID, 0, 0, 1000);
                return;
            }
            // ✅ Sửa - chỉ kiểm tra ngày kết thúc phải sau ngày bắt đầu
            if (dateTimePickerEnd.Value <= dateTimePickerStart.Value)
            {
                MessageBox.Show("Ngày kết thúc phải sau ngày bắt đầu!");
                return;
            }


            using (EFCore db = new EFCore())
            {
                try
                {
                    long studentID = long.Parse(contractStudentID.Text);
                    int rooomID = int.Parse(contractRoomID.Text);
                    Student student = db.Students.Single(s => s.StudentID == studentID);
                    Room room = db.Rooms.Single(r => r.RoomID == rooomID);
                    // nam không ở phòng nữ và ngược lại
                    if (!student.Gender.Equals(room.RoomType))
                    {
                        MessageBox.Show("Sinh viên " + student.Gender + " không thể ở phòng " + room.RoomType);
                        return;
                    }

                    // Kiểm tra xem hợp đồng có tồn tại không
                    // Thêm mới
                    if (string.IsNullOrWhiteSpace(contractID.Text))
                    {
                        // Kiểm tra sinh viên đã có hợp đồng chưa
                        bool studentHasContract = db.Contracts.Any(c => c.StudentID == studentID);
                        if (studentHasContract)
                        {
                            MessageBox.Show("Sinh viên này đã có hợp đồng rồi!");
                            return;
                        }

                        // Kiểm tra phòng còn chỗ không
                        int currentOccupants = db.Contracts.Count(c => c.RoomID == rooomID);
                        if (currentOccupants >= room.QuantityStudent)
                        {
                            MessageBox.Show("Phòng " + rooomID + " đã đầy!");
                            return;
                        }

                        Contract newContract = new Contract();
                        newContract.StartDate = dateTimePickerStart.Value;
                        newContract.EndDate = dateTimePickerEnd.Value;
                        newContract.StudentID = studentID;
                        newContract.RoomID = rooomID;
                        newContract.Price = room.Price;
                        db.Contracts.Add(newContract);

                        // Cập nhật trạng thái phòng nếu đầy
                        if (currentOccupants + 1 >= room.QuantityStudent)
                        {
                            room.Status = "Đầy";
                            db.Rooms.Update(room);
                        }

                        db.SaveChanges();
                        toolTip1.Show("Thêm hợp đồng thành công!", saveContract, 0, 0, 1000);
                    }
                    // Sửa
                    else
                    {
                        Contract contractToUpdate = db.Contracts.SingleOrDefault(c => c.ContractID == int.Parse(contractID.Text));
                        if (contractToUpdate != null)
                        {
                            contractToUpdate.StartDate = dateTimePickerStart.Value;
                            contractToUpdate.EndDate = dateTimePickerEnd.Value;
                            contractToUpdate.StudentID = studentID;
                            contractToUpdate.RoomID = rooomID;
                            db.SaveChanges();
                            toolTip1.Show("Cập nhật hợp đồng thành công!", saveContract, 0, 0, 1000);
                        }
                    }
                    QLKTX_Activated(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã xảy ra lỗi khi cập nhật hợp đồng: " + ex.Message);
                }
            }

        }






        private void search_find_sv_Click(object sender, EventArgs e)
        {
            using (var db = new EFCore())
            {
                // Xây dựng câu truy vấn dựa trên giá trị của các TextBox
                dataGridView6.DataSource = db.Students.Where(s => s.StudentID == long.Parse(sv_id.Text)).Select(x => new { x.StudentID, x.Name, x.DoB, x.Class, x.Gender, x.Address }).ToList();
            }
        }

        private void contractCancel_Click(object sender, EventArgs e)
        {
            addContract.Enabled = true;
            contractRoomID.ResetText();
            contractStudentID.ResetText();
            dateTimePickerStart.ResetText();
            dateTimePickerEnd.ResetText();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var db = new EFCore())
            {
                // Xây dựng câu truy vấn dựa trên giá trị của các TextBox
                dataGridView9.DataSource = db.Contracts.Where(s => s.StudentID == long.Parse(sv_contract_id.Text)).
                    Select(x => new { x.ContractID, x.StartDate, x.EndDate, x.StudentID, x.RoomID, x.Price }).ToList();
            }
        }

        private void dataGridView6_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Print_Click(object sender, EventArgs e)
        {
            progressBar.Visible = true;
            long id = long.Parse(printID.Text);
            DoPrintProcess(id);
        }
        private void DoPrintProcess(long id)
        {
            progressBar.Maximum = 100;
            Thread processThread = new Thread(() =>
            {
                for (int i = 0; i <= 100; i++)
                {
                    progressBar.Invoke((MethodInvoker)delegate
                    {
                        progressBar.Value = i;
                    });
                    Thread.Sleep(50);
                }
                progressBar.Invoke((MethodInvoker)delegate
                {
                    progressBar.Visible = false;
                    Print.Visible = false;
                    reportBill(id);
                });
            });
            processThread.Start();
        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }
    }
}
