namespace WinFormsApp1
{
    partial class fEditRoom
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
            roomClose = new Button();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            roomSave = new Button();
            roomPrice = new MaskedTextBox();
            label5 = new Label();
            roomType = new TextBox();
            roomStudent = new TextBox();
            roomStatus = new TextBox();
            SuspendLayout();
            // 
            // roomClose
            // 
            roomClose.Location = new Point(418, 226);
            roomClose.Name = "roomClose";
            roomClose.Size = new Size(130, 23);
            roomClose.TabIndex = 14;
            roomClose.Text = "Đóng";
            roomClose.UseVisualStyleBackColor = true;
            roomClose.Click += roomClose_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(47, 121);
            label4.Name = "label4";
            label4.Size = new Size(99, 15);
            label4.TabIndex = 16;
            label4.Text = "Tình trạng phòng";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(47, 75);
            label3.Name = "label3";
            label3.Size = new Size(104, 15);
            label3.TabIndex = 15;
            label3.Text = "Số lượng sinh viên";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(47, 36);
            label2.Name = "label2";
            label2.Size = new Size(67, 15);
            label2.TabIndex = 12;
            label2.Text = "Loại phòng";
            // 
            // roomSave
            // 
            roomSave.Location = new Point(263, 226);
            roomSave.Name = "roomSave";
            roomSave.Size = new Size(130, 23);
            roomSave.TabIndex = 4;
            roomSave.Text = "Lưu";
            roomSave.UseVisualStyleBackColor = true;
            roomSave.Click += roomSave_Click;
            // 
            // roomPrice
            // 
            roomPrice.Location = new Point(215, 166);
            roomPrice.Name = "roomPrice";
            roomPrice.Size = new Size(366, 23);
            roomPrice.TabIndex = 3;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(47, 169);
            label5.Name = "label5";
            label5.Size = new Size(62, 15);
            label5.TabIndex = 17;
            label5.Text = "Giá phòng";
            // 
            // roomType
            // 
            roomType.Location = new Point(215, 28);
            roomType.Name = "roomType";
            roomType.Size = new Size(366, 23);
            roomType.TabIndex = 0;
            // 
            // roomStudent
            // 
            roomStudent.Location = new Point(215, 72);
            roomStudent.Name = "roomStudent";
            roomStudent.Size = new Size(366, 23);
            roomStudent.TabIndex = 1;
            // 
            // roomStatus
            // 
            roomStatus.Location = new Point(215, 118);
            roomStatus.Name = "roomStatus";
            roomStatus.Size = new Size(366, 23);
            roomStatus.TabIndex = 2;
            // 
            // fEditRoom
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(623, 280);
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
            Name = "fEditRoom";
            Text = "Sửa thông tin phòng";
            FormClosing += fEditRoom_FormClosing;
            Load += fEditRoom_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ToolTip toolTip1;
        private TextBox roomID;
        private Button roomClose;
        private Label label4;
        private Label label3;
        private Label label2;
        private Button roomSave;
        private Label label1;
        private MaskedTextBox roomPrice;
        private Label label5;
        private TextBox roomType;
        private TextBox roomStudent;
        private TextBox roomStatus;
    }
}