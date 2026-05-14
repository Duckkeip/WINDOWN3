namespace WinFormsApp1
{
    partial class fLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fLogin));
            groupBox1 = new GroupBox();
            label3 = new Label();
            btCancel = new Button();
            label2 = new Label();
            btLogin = new Button();
            label1 = new Label();
            txtPassword = new TextBox();
            txtName = new TextBox();
            toolTip1 = new ToolTip(components);
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.Transparent;
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(btCancel);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(btLogin);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(txtPassword);
            groupBox1.Controls.Add(txtName);
            groupBox1.ForeColor = SystemColors.ActiveCaptionText;
            groupBox1.Location = new Point(340, 80);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(354, 238);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label3.ForeColor = Color.Navy;
            label3.Location = new Point(77, 9);
            label3.Name = "label3";
            label3.Size = new Size(207, 25);
            label3.TabIndex = 4;
            label3.Text = "WELCOM TO VAA KTX";
            // 
            // btCancel
            // 
            btCancel.BackColor = Color.IndianRed;
            btCancel.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            btCancel.ForeColor = SystemColors.ControlLightLight;
            btCancel.Location = new Point(207, 171);
            btCancel.Name = "btCancel";
            btCancel.Size = new Size(112, 41);
            btCancel.TabIndex = 3;
            btCancel.Text = "Cancel";
            btCancel.UseVisualStyleBackColor = false;
            btCancel.Click += btCancel_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = Color.FromArgb(0, 0, 192);
            label2.Location = new Point(20, 111);
            label2.Name = "label2";
            label2.Size = new Size(97, 25);
            label2.TabIndex = 3;
            label2.Text = "Password";
            // 
            // btLogin
            // 
            btLogin.BackColor = Color.IndianRed;
            btLogin.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            btLogin.ForeColor = SystemColors.ControlLightLight;
            btLogin.Location = new Point(60, 171);
            btLogin.Name = "btLogin";
            btLogin.Size = new Size(110, 41);
            btLogin.TabIndex = 2;
            btLogin.Text = "Login";
            btLogin.UseVisualStyleBackColor = false;
            btLogin.Click += btLogin_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.FromArgb(0, 0, 192);
            label1.Location = new Point(20, 61);
            label1.Name = "label1";
            label1.Size = new Size(101, 25);
            label1.TabIndex = 2;
            label1.Text = "Username";
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtPassword.Location = new Point(137, 112);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(195, 27);
            txtPassword.TabIndex = 1;
            txtPassword.TextChanged += txtPassword_TextChanged;
            // 
            // txtName
            // 
            txtName.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtName.Location = new Point(137, 61);
            txtName.Name = "txtName";
            txtName.Size = new Size(195, 27);
            txtName.TabIndex = 0;
            txtName.TextChanged += txtName_TextChanged;
            // 
            // fLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(997, 560);
            Controls.Add(groupBox1);
            Name = "fLogin";
            Text = "Login";
            Load += fLogin_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Label label2;
        private Label label1;
        private TextBox txtPassword;
        private TextBox txtName;
        private Button btLogin;
        private Button btCancel;
        private Label label3;
        private ToolTip toolTip1;
    }
}