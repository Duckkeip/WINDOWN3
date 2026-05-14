namespace WinFormsApp1
{
    partial class fNewRoom
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            toolTip1 = new ToolTip(components);
            roomSave = new Button();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            roomClose = new Button();
            label5 = new Label();
            roomPrice = new TextBox();
            roomType = new TextBox();
            roomStudent = new TextBox();
            roomStatus = new TextBox();
            SuspendLayout();
            // 
            // roomSave
            // 
            roomSave.Location = new Point(249, 235);
            roomSave.Name = "roomSave";
            roomSave.Size = new Size(136, 23);
            roomSave.TabIndex = 4;
            roomSave.Text = "Lưu";
            roomSave.UseVisualStyleBackColor = true;
            roomSave.Click += roomSave_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(45, 34);
            label2.Name = "label2";
            label2.Size = new Size(67, 15);
            label2.TabIndex = 4;
            label2.Text = "Loại phòng";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(45, 73);
            label3.Name = "label3";
            label3.Size = new Size(104, 15);
            label3.TabIndex = 5;
            label3.Text = "Số lượng sinh viên";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(45, 119);
            label4.Name = "label4";
            label4.Size = new Size(99, 15);
            label4.TabIndex = 6;
            label4.Text = "Tình trạng phòng";
            // 
            // roomClose
            // 
            roomClose.Location = new Point(404, 235);
            roomClose.Name = "roomClose";
            roomClose.Size = new Size(136, 23);
            roomClose.TabIndex = 5;
            roomClose.Text = "Đóng";
            roomClose.UseVisualStyleBackColor = true;
            roomClose.Click += roomClose_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(45, 175);
            label5.Name = "label5";
            label5.Size = new Size(62, 15);
            label5.TabIndex = 7;
            label5.Text = "Giá phòng";
            // 
            // roomPrice
            // 
            roomPrice.Location = new Point(213, 172);
            roomPrice.Name = "roomPrice";
            roomPrice.Size = new Size(366, 23);
            roomPrice.TabIndex = 3;
            // 
            // roomType
            // 
            roomType.Location = new Point(213, 31);
            roomType.Name = "roomType";
            roomType.Size = new Size(366, 23);
            roomType.TabIndex = 0;
            // 
            // roomStudent
            // 
            roomStudent.Location = new Point(213, 70);
            roomStudent.Name = "roomStudent";
            roomStudent.Size = new Size(366, 23);
            roomStudent.TabIndex = 1;
            roomStudent.TextChanged += roomStudent_TextChanged;
            // 
            // roomStatus
            // 
            roomStatus.Location = new Point(213, 116);
            roomStatus.Name = "roomStatus";
            roomStatus.Size = new Size(366, 23);
            roomStatus.TabIndex = 2;
            roomStatus.Text = "Còn trống";
            // 
            // fNewRoom
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(620, 298);
            Controls.Add(roomStatus);
            Controls.Add(roomStudent);
            Controls.Add(roomType);
            Controls.Add(roomPrice);
            Controls.Add(label5);
            Controls.Add(roomClose);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(roomSave);
            Name = "fNewRoom";
            Text = "Nhập phòng mới";
            FormClosing += fNewRoom_FormClosing;
            Load += fNewRoom_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox roomID;
        private ToolTip toolTip1;
        private Button roomSave;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button roomClose;
        private Label label5;
        private TextBox roomPrice;
        private TextBox roomType;
        private TextBox roomStudent;
        private TextBox roomStatus;
    }
}