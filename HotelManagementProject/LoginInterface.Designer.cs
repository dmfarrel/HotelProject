namespace HotelManagementProject
{
    partial class LoginInterface
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
            this.accountGroupBox = new System.Windows.Forms.GroupBox();
            this.accountButton = new System.Windows.Forms.Button();
            this.accountPasswordTextBox = new System.Windows.Forms.TextBox();
            this.customerRadioButton = new System.Windows.Forms.RadioButton();
            this.accountFirstTextBox = new System.Windows.Forms.TextBox();
            this.accountUsernameTextBox = new System.Windows.Forms.TextBox();
            this.accountPasswordLabel = new System.Windows.Forms.Label();
            this.accountFirstLabel = new System.Windows.Forms.Label();
            this.accountUsernameLabel = new System.Windows.Forms.Label();
            this.employeeRadioButton = new System.Windows.Forms.RadioButton();
            this.loginGroupBox = new System.Windows.Forms.GroupBox();
            this.loginButton = new System.Windows.Forms.Button();
            this.loginPasswordTextBox = new System.Windows.Forms.TextBox();
            this.loginUsernameTextBox = new System.Windows.Forms.TextBox();
            this.loginPasswordLabel = new System.Windows.Forms.Label();
            this.loginUsernameLabel = new System.Windows.Forms.Label();
            this.accountDOBTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.accountGroupBox.SuspendLayout();
            this.loginGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // accountGroupBox
            // 
            this.accountGroupBox.Controls.Add(this.accountDOBTextBox);
            this.accountGroupBox.Controls.Add(this.label1);
            this.accountGroupBox.Controls.Add(this.accountButton);
            this.accountGroupBox.Controls.Add(this.accountPasswordTextBox);
            this.accountGroupBox.Controls.Add(this.customerRadioButton);
            this.accountGroupBox.Controls.Add(this.accountFirstTextBox);
            this.accountGroupBox.Controls.Add(this.accountUsernameTextBox);
            this.accountGroupBox.Controls.Add(this.accountPasswordLabel);
            this.accountGroupBox.Controls.Add(this.accountFirstLabel);
            this.accountGroupBox.Controls.Add(this.accountUsernameLabel);
            this.accountGroupBox.Controls.Add(this.employeeRadioButton);
            this.accountGroupBox.Location = new System.Drawing.Point(190, 6);
            this.accountGroupBox.Name = "accountGroupBox";
            this.accountGroupBox.Size = new System.Drawing.Size(184, 275);
            this.accountGroupBox.TabIndex = 4;
            this.accountGroupBox.TabStop = false;
            this.accountGroupBox.Text = "Create New Account";
            // 
            // accountButton
            // 
            this.accountButton.Location = new System.Drawing.Point(6, 233);
            this.accountButton.Name = "accountButton";
            this.accountButton.Size = new System.Drawing.Size(164, 23);
            this.accountButton.TabIndex = 10;
            this.accountButton.Text = "Create Account";
            this.accountButton.UseVisualStyleBackColor = true;
            this.accountButton.Click += new System.EventHandler(this.accountButton_Click);
            // 
            // accountPasswordTextBox
            // 
            this.accountPasswordTextBox.Location = new System.Drawing.Point(9, 122);
            this.accountPasswordTextBox.Name = "accountPasswordTextBox";
            this.accountPasswordTextBox.Size = new System.Drawing.Size(164, 20);
            this.accountPasswordTextBox.TabIndex = 9;
            // 
            // customerRadioButton
            // 
            this.customerRadioButton.AutoSize = true;
            this.customerRadioButton.Location = new System.Drawing.Point(6, 187);
            this.customerRadioButton.Name = "customerRadioButton";
            this.customerRadioButton.Size = new System.Drawing.Size(69, 17);
            this.customerRadioButton.TabIndex = 8;
            this.customerRadioButton.TabStop = true;
            this.customerRadioButton.Text = "Customer";
            this.customerRadioButton.UseVisualStyleBackColor = true;
            // 
            // accountFirstTextBox
            // 
            this.accountFirstTextBox.Location = new System.Drawing.Point(9, 83);
            this.accountFirstTextBox.Name = "accountFirstTextBox";
            this.accountFirstTextBox.Size = new System.Drawing.Size(164, 20);
            this.accountFirstTextBox.TabIndex = 6;
            // 
            // accountUsernameTextBox
            // 
            this.accountUsernameTextBox.Location = new System.Drawing.Point(9, 44);
            this.accountUsernameTextBox.Name = "accountUsernameTextBox";
            this.accountUsernameTextBox.Size = new System.Drawing.Size(164, 20);
            this.accountUsernameTextBox.TabIndex = 5;
            // 
            // accountPasswordLabel
            // 
            this.accountPasswordLabel.AutoSize = true;
            this.accountPasswordLabel.Location = new System.Drawing.Point(6, 106);
            this.accountPasswordLabel.Name = "accountPasswordLabel";
            this.accountPasswordLabel.Size = new System.Drawing.Size(53, 13);
            this.accountPasswordLabel.TabIndex = 4;
            this.accountPasswordLabel.Text = "Password";
            // 
            // accountFirstLabel
            // 
            this.accountFirstLabel.AutoSize = true;
            this.accountFirstLabel.Location = new System.Drawing.Point(6, 67);
            this.accountFirstLabel.Name = "accountFirstLabel";
            this.accountFirstLabel.Size = new System.Drawing.Size(35, 13);
            this.accountFirstLabel.TabIndex = 2;
            this.accountFirstLabel.Text = "Name";
            // 
            // accountUsernameLabel
            // 
            this.accountUsernameLabel.AutoSize = true;
            this.accountUsernameLabel.Location = new System.Drawing.Point(6, 28);
            this.accountUsernameLabel.Name = "accountUsernameLabel";
            this.accountUsernameLabel.Size = new System.Drawing.Size(55, 13);
            this.accountUsernameLabel.TabIndex = 1;
            this.accountUsernameLabel.Text = "Username";
            // 
            // employeeRadioButton
            // 
            this.employeeRadioButton.AutoSize = true;
            this.employeeRadioButton.Location = new System.Drawing.Point(6, 210);
            this.employeeRadioButton.Name = "employeeRadioButton";
            this.employeeRadioButton.Size = new System.Drawing.Size(71, 17);
            this.employeeRadioButton.TabIndex = 0;
            this.employeeRadioButton.TabStop = true;
            this.employeeRadioButton.Text = "Employee";
            this.employeeRadioButton.UseVisualStyleBackColor = true;
            // 
            // loginGroupBox
            // 
            this.loginGroupBox.Controls.Add(this.loginButton);
            this.loginGroupBox.Controls.Add(this.loginPasswordTextBox);
            this.loginGroupBox.Controls.Add(this.loginUsernameTextBox);
            this.loginGroupBox.Controls.Add(this.loginPasswordLabel);
            this.loginGroupBox.Controls.Add(this.loginUsernameLabel);
            this.loginGroupBox.Location = new System.Drawing.Point(12, 73);
            this.loginGroupBox.Name = "loginGroupBox";
            this.loginGroupBox.Size = new System.Drawing.Size(172, 150);
            this.loginGroupBox.TabIndex = 3;
            this.loginGroupBox.TabStop = false;
            this.loginGroupBox.Text = "Login";
            // 
            // loginButton
            // 
            this.loginButton.Location = new System.Drawing.Point(9, 114);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(153, 23);
            this.loginButton.TabIndex = 4;
            this.loginButton.Text = "Login";
            this.loginButton.UseVisualStyleBackColor = true;
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // loginPasswordTextBox
            // 
            this.loginPasswordTextBox.Location = new System.Drawing.Point(9, 86);
            this.loginPasswordTextBox.Name = "loginPasswordTextBox";
            this.loginPasswordTextBox.Size = new System.Drawing.Size(153, 20);
            this.loginPasswordTextBox.TabIndex = 3;
            // 
            // loginUsernameTextBox
            // 
            this.loginUsernameTextBox.Location = new System.Drawing.Point(9, 43);
            this.loginUsernameTextBox.Name = "loginUsernameTextBox";
            this.loginUsernameTextBox.Size = new System.Drawing.Size(153, 20);
            this.loginUsernameTextBox.TabIndex = 2;
            // 
            // loginPasswordLabel
            // 
            this.loginPasswordLabel.AutoSize = true;
            this.loginPasswordLabel.Location = new System.Drawing.Point(6, 66);
            this.loginPasswordLabel.Name = "loginPasswordLabel";
            this.loginPasswordLabel.Size = new System.Drawing.Size(53, 13);
            this.loginPasswordLabel.TabIndex = 1;
            this.loginPasswordLabel.Text = "Password";
            // 
            // loginUsernameLabel
            // 
            this.loginUsernameLabel.AutoSize = true;
            this.loginUsernameLabel.Location = new System.Drawing.Point(6, 27);
            this.loginUsernameLabel.Name = "loginUsernameLabel";
            this.loginUsernameLabel.Size = new System.Drawing.Size(55, 13);
            this.loginUsernameLabel.TabIndex = 0;
            this.loginUsernameLabel.Text = "Username";
            // 
            // accountDOBTextBox
            // 
            this.accountDOBTextBox.Location = new System.Drawing.Point(9, 161);
            this.accountDOBTextBox.Name = "accountDOBTextBox";
            this.accountDOBTextBox.Size = new System.Drawing.Size(164, 20);
            this.accountDOBTextBox.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 145);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Date of Birth";
            // 
            // LoginInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(386, 293);
            this.Controls.Add(this.accountGroupBox);
            this.Controls.Add(this.loginGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "LoginInterface";
            this.Text = "Login";
            this.Load += new System.EventHandler(this.LoginInterface_Load);
            this.accountGroupBox.ResumeLayout(false);
            this.accountGroupBox.PerformLayout();
            this.loginGroupBox.ResumeLayout(false);
            this.loginGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox accountGroupBox;
        private System.Windows.Forms.Button accountButton;
        private System.Windows.Forms.TextBox accountPasswordTextBox;
        private System.Windows.Forms.RadioButton customerRadioButton;
        private System.Windows.Forms.TextBox accountFirstTextBox;
        private System.Windows.Forms.TextBox accountUsernameTextBox;
        private System.Windows.Forms.Label accountPasswordLabel;
        private System.Windows.Forms.Label accountFirstLabel;
        private System.Windows.Forms.Label accountUsernameLabel;
        private System.Windows.Forms.RadioButton employeeRadioButton;
        private System.Windows.Forms.GroupBox loginGroupBox;
        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.TextBox loginPasswordTextBox;
        private System.Windows.Forms.TextBox loginUsernameTextBox;
        private System.Windows.Forms.Label loginPasswordLabel;
        private System.Windows.Forms.Label loginUsernameLabel;
        private System.Windows.Forms.TextBox accountDOBTextBox;
        private System.Windows.Forms.Label label1;
    }
}

