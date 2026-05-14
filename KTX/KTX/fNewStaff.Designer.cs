namespace WinFormsApp1
{
    partial class fNewStaff
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
            staffClose = new Button();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            staffSave = new Button();
            staffID = new TextBox();
            label1 = new Label();
            staffName = new TextBox();
            staffAddress = new TextBox();
            staffPhone = new TextBox();
            toolTip1 = new ToolTip(components);
            SuspendLayout();
            // 
            // staffClose
            // 
            staffClose.Location = new Point(420, 229);
            staffClose.Name = "staffClose";
            staffClose.Size = new Size(75, 23);
            staffClose.TabIndex = 5;
            staffClose.Text = "Đóng";
            staffClose.UseVisualStyleBackColor = true;
            staffClose.Click += staffClose_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(31, 165);
            label4.Name = "label4";
            label4.Size = new Size(76, 15);
            label4.TabIndex = 16;
            label4.Text = "Số điện thoại";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(31, 119);
            label3.Name = "label3";
            label3.Size = new Size(43, 15);
            label3.TabIndex = 15;
            label3.Text = "Địa chỉ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(31, 80);
            label2.Name = "label2";
            label2.Size = new Size(80, 15);
            label2.TabIndex = 12;
            label2.Text = "Tên nhân viên";
            // 
            // staffSave
            // 
            staffSave.Location = new Point(265, 229);
            staffSave.Name = "staffSave";
            staffSave.Size = new Size(75, 23);
            staffSave.TabIndex = 4;
            staffSave.Text = "Lưu";
            staffSave.UseVisualStyleBackColor = true;
            staffSave.Click += staffSave_Click;
            // 
            // staffID
            // 
            staffID.Location = new Point(199, 35);
            staffID.Name = "staffID";
            staffID.Size = new Size(366, 23);
            staffID.TabIndex = 0;
            staffID.Validating += staffID_Validating;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(31, 38);
            label1.Name = "label1";
            label1.Size = new Size(79, 15);
            label1.TabIndex = 8;
            label1.Text = "Mã nhân viên";
            // 
            // staffName
            // 
            staffName.Location = new Point(199, 77);
            staffName.Name = "staffName";
            staffName.Size = new Size(366, 23);
            staffName.TabIndex = 1;
            staffName.Validating += staffName_Validating;
            // 
            // staffAddress
            // 
            staffAddress.Location = new Point(199, 116);
            staffAddress.Name = "staffAddress";
            staffAddress.Size = new Size(366, 23);
            staffAddress.TabIndex = 2;
            staffAddress.Validating += staffAddress_Validating;
            // 
            // staffPhone
            // 
            staffPhone.Location = new Point(199, 162);
            staffPhone.Name = "staffPhone";
            staffPhone.Size = new Size(366, 23);
            staffPhone.TabIndex = 3;
            staffPhone.Validating += staffPhone_Validating;
            // 
            // fNewStaff
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(635, 311);
            Controls.Add(staffPhone);
            Controls.Add(staffAddress);
            Controls.Add(staffName);
            Controls.Add(staffClose);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(staffSave);
            Controls.Add(staffID);
            Controls.Add(label1);
            Name = "fNewStaff";
            Text = "Thêm mới nhân viên";
            FormClosing += fNewStaff_FormClosing;
            Load += fNewStaff_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button staffClose;
        private Label label4;
        private Label label3;
        private Label label2;
        private Button staffSave;
        private TextBox staffID;
        private Label label1;
        private TextBox staffName;
        private TextBox staffAddress;
        private TextBox staffPhone;
        private ToolTip toolTip1;
    }
}