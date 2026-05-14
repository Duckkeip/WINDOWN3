namespace WinFormsApp1
{
    partial class fNewStudent
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
            label7 = new Label();
            maleCheck = new CheckBox();
            label6 = new Label();
            toolTip1 = new ToolTip(components);
            SuspendLayout();
            // 
            // btClose
            // 
            btClose.Location = new Point(480, 278);
            btClose.Name = "btClose";
            btClose.Size = new Size(159, 31);
            btClose.TabIndex = 8;
            btClose.Text = "Close";
            btClose.UseVisualStyleBackColor = true;
            btClose.Click += btClose_Click;
            // 
            // btSave
            // 
            btSave.Location = new Point(274, 278);
            btSave.Name = "btSave";
            btSave.Size = new Size(159, 31);
            btSave.TabIndex = 7;
            btSave.Text = "Add";
            btSave.UseVisualStyleBackColor = true;
            btSave.Click += btSave_Click;
            // 
            // studentDoB
            // 
            studentDoB.CustomFormat = "MM/dd/yyyy";
            studentDoB.Format = DateTimePickerFormat.Custom;
            studentDoB.Location = new Point(135, 129);
            studentDoB.Name = "studentDoB";
            studentDoB.Size = new Size(200, 23);
            studentDoB.TabIndex = 1;
            studentDoB.Validating += studentDoB_Validating;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(440, 134);
            label5.Name = "label5";
            label5.Size = new Size(52, 15);
            label5.TabIndex = 11;
            label5.Text = "Giới tính";
            // 
            // femaleCheck
            // 
            femaleCheck.AutoSize = true;
            femaleCheck.CheckAlign = ContentAlignment.MiddleRight;
            femaleCheck.Location = new Point(597, 133);
            femaleCheck.Name = "femaleCheck";
            femaleCheck.Size = new Size(42, 19);
            femaleCheck.TabIndex = 3;
            femaleCheck.Text = "Nữ";
            femaleCheck.UseVisualStyleBackColor = true;
            femaleCheck.CheckedChanged += femaleCheck_CheckedChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(21, 224);
            label4.Name = "label4";
            label4.Size = new Size(59, 15);
            label4.TabIndex = 21;
            label4.Text = "Quê quán";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(22, 135);
            label3.Name = "label3";
            label3.Size = new Size(60, 15);
            label3.TabIndex = 19;
            label3.Text = "Ngày sinh";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(21, 177);
            label2.Name = "label2";
            label2.Size = new Size(0, 15);
            label2.TabIndex = 16;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(22, 174);
            label1.Name = "label1";
            label1.Size = new Size(27, 15);
            label1.TabIndex = 14;
            label1.Text = "Lớp";
            label1.Click += label1_Click;
            // 
            // studentAddress
            // 
            studentAddress.Location = new Point(134, 221);
            studentAddress.Name = "studentAddress";
            studentAddress.Size = new Size(504, 23);
            studentAddress.TabIndex = 5;
            studentAddress.Validating += studentAddress_Validating;
            // 
            // studentName
            // 
            studentName.Location = new Point(135, 90);
            studentName.Name = "studentName";
            studentName.Size = new Size(504, 23);
            studentName.TabIndex = 0;
            studentName.Validating += studentName_Validating;
            // 
            // studentClass
            // 
            studentClass.Location = new Point(135, 174);
            studentClass.Name = "studentClass";
            studentClass.Size = new Size(504, 23);
            studentClass.TabIndex = 4;
            studentClass.TextChanged += studentClass_TextChanged;
            studentClass.Validating += studentClass_Validating;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label7.ForeColor = Color.IndianRed;
            label7.Location = new Point(135, 44);
            label7.Name = "label7";
            label7.Size = new Size(165, 20);
            label7.TabIndex = 25;
            label7.Text = "THÊM SINH VIÊN MỚI";
            // 
            // maleCheck
            // 
            maleCheck.AutoSize = true;
            maleCheck.CheckAlign = ContentAlignment.MiddleRight;
            maleCheck.Location = new Point(524, 133);
            maleCheck.Name = "maleCheck";
            maleCheck.Size = new Size(52, 19);
            maleCheck.TabIndex = 2;
            maleCheck.Text = "Nam";
            maleCheck.UseVisualStyleBackColor = true;
            maleCheck.CheckedChanged += maleCheck_CheckedChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(20, 90);
            label6.Name = "label6";
            label6.Size = new Size(75, 15);
            label6.TabIndex = 28;
            label6.Text = "Tên sinh viên";
            // 
            // fNewStudent
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(705, 331);
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
            Name = "fNewStudent";
            Text = "Thêm mới sinh viên";
            FormClosing += fNewStudent_FormClosing;
            Load += fNewStudent_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

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
        private Label label7;
        private CheckBox maleCheck;
        private Label label6;
        private Label label8;
        private TextBox studentRoom;
        private ToolTip toolTip1;
    }
}