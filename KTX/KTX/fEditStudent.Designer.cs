namespace WinFormsApp1
{
    partial class fEditStudent
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
            label6 = new Label();
            maleCheck = new CheckBox();
            label7 = new Label();
            btClose = new Button();
            btSave = new Button();
            studentDoB = new DateTimePicker();
            label5 = new Label();
            femaleCheck = new CheckBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            studentAddress = new TextBox();
            studentName = new TextBox();
            studentClass = new TextBox();
            SuspendLayout();
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(91, 139);
            label6.Name = "label6";
            label6.Size = new Size(75, 15);
            label6.TabIndex = 43;
            label6.Text = "Tên sinh viên";
            // 
            // maleCheck
            // 
            maleCheck.AutoSize = true;
            maleCheck.CheckAlign = ContentAlignment.MiddleRight;
            maleCheck.Location = new Point(595, 182);
            maleCheck.Name = "maleCheck";
            maleCheck.Size = new Size(52, 19);
            maleCheck.TabIndex = 31;
            maleCheck.Text = "Nam";
            maleCheck.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label7.ForeColor = Color.IndianRed;
            label7.Location = new Point(206, 93);
            label7.Name = "label7";
            label7.Size = new Size(207, 20);
            label7.TabIndex = 42;
            label7.Text = "SỬA THÔNG TIN SINH VIÊN";
            // 
            // btClose
            // 
            btClose.Location = new Point(551, 327);
            btClose.Name = "btClose";
            btClose.Size = new Size(159, 31);
            btClose.TabIndex = 36;
            btClose.Text = "Close";
            btClose.UseVisualStyleBackColor = true;
            btClose.Click += btClose_Click_1;
            // 
            // btSave
            // 
            btSave.Location = new Point(345, 327);
            btSave.Name = "btSave";
            btSave.Size = new Size(159, 31);
            btSave.TabIndex = 35;
            btSave.Text = "Save";
            btSave.UseVisualStyleBackColor = true;
            btSave.Click += btSave_Click;
            // 
            // studentDoB
            // 
            studentDoB.CustomFormat = "MM/dd/yyyy";
            studentDoB.Format = DateTimePickerFormat.Custom;
            studentDoB.Location = new Point(206, 178);
            studentDoB.Name = "studentDoB";
            studentDoB.Size = new Size(200, 23);
            studentDoB.TabIndex = 30;
            studentDoB.Validating += studentDoB_Validating;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(511, 183);
            label5.Name = "label5";
            label5.Size = new Size(52, 15);
            label5.TabIndex = 37;
            label5.Text = "Giới tính";
            // 
            // femaleCheck
            // 
            femaleCheck.AutoSize = true;
            femaleCheck.CheckAlign = ContentAlignment.MiddleRight;
            femaleCheck.Location = new Point(668, 182);
            femaleCheck.Name = "femaleCheck";
            femaleCheck.Size = new Size(42, 19);
            femaleCheck.TabIndex = 32;
            femaleCheck.Text = "Nữ";
            femaleCheck.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(92, 273);
            label4.Name = "label4";
            label4.Size = new Size(59, 15);
            label4.TabIndex = 41;
            label4.Text = "Quê quán";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(93, 184);
            label3.Name = "label3";
            label3.Size = new Size(60, 15);
            label3.TabIndex = 40;
            label3.Text = "Ngày sinh";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(92, 226);
            label2.Name = "label2";
            label2.Size = new Size(0, 15);
            label2.TabIndex = 39;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(93, 223);
            label1.Name = "label1";
            label1.Size = new Size(27, 15);
            label1.TabIndex = 38;
            label1.Text = "Lớp";
            // 
            // studentAddress
            // 
            studentAddress.Location = new Point(205, 270);
            studentAddress.Name = "studentAddress";
            studentAddress.Size = new Size(504, 23);
            studentAddress.TabIndex = 34;
            studentAddress.Validating += studentAddress_Validating;
            // 
            // studentName
            // 
            studentName.Location = new Point(206, 139);
            studentName.Name = "studentName";
            studentName.Size = new Size(504, 23);
            studentName.TabIndex = 29;
            studentName.Validating += studentName_Validating;
            // 
            // studentClass
            // 
            studentClass.Location = new Point(206, 223);
            studentClass.Name = "studentClass";
            studentClass.Size = new Size(504, 23);
            studentClass.TabIndex = 33;
            studentClass.Validating += studentClass_Validating;
            // 
            // fEditStudent
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label6);
            Controls.Add(maleCheck);
            Controls.Add(label7);
            Controls.Add(btClose);
            Controls.Add(btSave);
            Controls.Add(studentDoB);
            Controls.Add(label5);
            Controls.Add(femaleCheck);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(studentAddress);
            Controls.Add(studentName);
            Controls.Add(studentClass);
            Name = "fEditStudent";
            Text = "Sửa thông tin sinh viên";
            FormClosing += fEditStudent_FormClosing;
            Load += fEditStudent_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ToolTip toolTip1;
        private Label label6;
        private CheckBox maleCheck;
        private Label label7;
        private Button btClose;
        private Button btSave;
        private DateTimePicker studentDoB;
        private Label label5;
        private CheckBox femaleCheck;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox studentAddress;
        private TextBox studentName;
        private TextBox studentClass;
    }
}