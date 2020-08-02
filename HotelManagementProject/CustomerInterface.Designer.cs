namespace HotelManagementProject
{
    partial class CustomerInterface
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.roomListBox = new System.Windows.Forms.ListBox();
            this.newReservationButton = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.reservationListBox = new System.Windows.Forms.ListBox();
            this.userInformationGroupBox = new System.Windows.Forms.GroupBox();
            this.updateInformationButton = new System.Windows.Forms.Button();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.lastTextBox = new System.Windows.Forms.TextBox();
            this.firstTextBox = new System.Windows.Forms.TextBox();
            this.usernameTextBox = new System.Windows.Forms.TextBox();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.lastLabel = new System.Windows.Forms.Label();
            this.firstLabel = new System.Windows.Forms.Label();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.roomReservationCalendar = new System.Windows.Forms.MonthCalendar();
            this.hotelListBox = new System.Windows.Forms.ListBox();
            this.hotelLabel = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.userInformationGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.roomReservationCalendar);
            this.groupBox1.Controls.Add(this.hotelListBox);
            this.groupBox1.Controls.Add(this.hotelLabel);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.roomListBox);
            this.groupBox1.Controls.Add(this.newReservationButton);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.reservationListBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(269, 578);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Reservations";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 16);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(126, 13);
            this.label9.TabIndex = 5;
            this.label9.Text = "Rewards Points: <count>";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 272);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Room";
            // 
            // roomListBox
            // 
            this.roomListBox.FormattingEnabled = true;
            this.roomListBox.Location = new System.Drawing.Point(6, 288);
            this.roomListBox.Name = "roomListBox";
            this.roomListBox.Size = new System.Drawing.Size(254, 82);
            this.roomListBox.TabIndex = 13;
            // 
            // newReservationButton
            // 
            this.newReservationButton.Location = new System.Drawing.Point(6, 549);
            this.newReservationButton.Name = "newReservationButton";
            this.newReservationButton.Size = new System.Drawing.Size(254, 23);
            this.newReservationButton.TabIndex = 12;
            this.newReservationButton.Text = "New Reservation";
            this.newReservationButton.UseVisualStyleBackColor = true;
            this.newReservationButton.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(6, 161);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(254, 23);
            this.button3.TabIndex = 8;
            this.button3.Text = "Cancel Selected Reservation";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Active Reservations";
            // 
            // reservationListBox
            // 
            this.reservationListBox.FormattingEnabled = true;
            this.reservationListBox.Location = new System.Drawing.Point(6, 59);
            this.reservationListBox.Name = "reservationListBox";
            this.reservationListBox.Size = new System.Drawing.Size(254, 95);
            this.reservationListBox.TabIndex = 3;
            // 
            // userInformationGroupBox
            // 
            this.userInformationGroupBox.Controls.Add(this.updateInformationButton);
            this.userInformationGroupBox.Controls.Add(this.passwordTextBox);
            this.userInformationGroupBox.Controls.Add(this.lastTextBox);
            this.userInformationGroupBox.Controls.Add(this.firstTextBox);
            this.userInformationGroupBox.Controls.Add(this.usernameTextBox);
            this.userInformationGroupBox.Controls.Add(this.passwordLabel);
            this.userInformationGroupBox.Controls.Add(this.lastLabel);
            this.userInformationGroupBox.Controls.Add(this.firstLabel);
            this.userInformationGroupBox.Controls.Add(this.usernameLabel);
            this.userInformationGroupBox.Location = new System.Drawing.Point(287, 12);
            this.userInformationGroupBox.Name = "userInformationGroupBox";
            this.userInformationGroupBox.Size = new System.Drawing.Size(184, 223);
            this.userInformationGroupBox.TabIndex = 5;
            this.userInformationGroupBox.TabStop = false;
            this.userInformationGroupBox.Text = "Update User Information";
            // 
            // updateInformationButton
            // 
            this.updateInformationButton.Location = new System.Drawing.Point(9, 187);
            this.updateInformationButton.Name = "updateInformationButton";
            this.updateInformationButton.Size = new System.Drawing.Size(164, 23);
            this.updateInformationButton.TabIndex = 10;
            this.updateInformationButton.Text = "Update Information";
            this.updateInformationButton.UseVisualStyleBackColor = true;
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Location = new System.Drawing.Point(9, 161);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.Size = new System.Drawing.Size(164, 20);
            this.passwordTextBox.TabIndex = 9;
            // 
            // lastTextBox
            // 
            this.lastTextBox.Location = new System.Drawing.Point(9, 122);
            this.lastTextBox.Name = "lastTextBox";
            this.lastTextBox.Size = new System.Drawing.Size(164, 20);
            this.lastTextBox.TabIndex = 7;
            // 
            // firstTextBox
            // 
            this.firstTextBox.Location = new System.Drawing.Point(9, 83);
            this.firstTextBox.Name = "firstTextBox";
            this.firstTextBox.Size = new System.Drawing.Size(164, 20);
            this.firstTextBox.TabIndex = 6;
            // 
            // usernameTextBox
            // 
            this.usernameTextBox.Location = new System.Drawing.Point(9, 44);
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.Size = new System.Drawing.Size(164, 20);
            this.usernameTextBox.TabIndex = 5;
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Location = new System.Drawing.Point(6, 145);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(53, 13);
            this.passwordLabel.TabIndex = 4;
            this.passwordLabel.Text = "Password";
            // 
            // lastLabel
            // 
            this.lastLabel.AutoSize = true;
            this.lastLabel.Location = new System.Drawing.Point(6, 106);
            this.lastLabel.Name = "lastLabel";
            this.lastLabel.Size = new System.Drawing.Size(58, 13);
            this.lastLabel.TabIndex = 3;
            this.lastLabel.Text = "Last Name";
            // 
            // firstLabel
            // 
            this.firstLabel.AutoSize = true;
            this.firstLabel.Location = new System.Drawing.Point(6, 67);
            this.firstLabel.Name = "firstLabel";
            this.firstLabel.Size = new System.Drawing.Size(57, 13);
            this.firstLabel.TabIndex = 2;
            this.firstLabel.Text = "First Name";
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Location = new System.Drawing.Point(6, 28);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(55, 13);
            this.usernameLabel.TabIndex = 1;
            this.usernameLabel.Text = "Username";
            // 
            // roomReservationCalendar
            // 
            this.roomReservationCalendar.Location = new System.Drawing.Point(21, 375);
            this.roomReservationCalendar.Name = "roomReservationCalendar";
            this.roomReservationCalendar.TabIndex = 7;
            // 
            // hotelListBox
            // 
            this.hotelListBox.FormattingEnabled = true;
            this.hotelListBox.Location = new System.Drawing.Point(6, 213);
            this.hotelListBox.Name = "hotelListBox";
            this.hotelListBox.Size = new System.Drawing.Size(254, 56);
            this.hotelListBox.TabIndex = 15;
            // 
            // hotelLabel
            // 
            this.hotelLabel.AutoSize = true;
            this.hotelLabel.Location = new System.Drawing.Point(6, 197);
            this.hotelLabel.Name = "hotelLabel";
            this.hotelLabel.Size = new System.Drawing.Size(32, 13);
            this.hotelLabel.TabIndex = 15;
            this.hotelLabel.Text = "Hotel";
            // 
            // CustomerInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(485, 601);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.userInformationGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "CustomerInterface";
            this.Text = "Customer Interface";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.userInformationGroupBox.ResumeLayout(false);
            this.userInformationGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ListBox roomListBox;
        private System.Windows.Forms.Button newReservationButton;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox reservationListBox;
        private System.Windows.Forms.GroupBox userInformationGroupBox;
        private System.Windows.Forms.Button updateInformationButton;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.TextBox lastTextBox;
        private System.Windows.Forms.TextBox firstTextBox;
        private System.Windows.Forms.TextBox usernameTextBox;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.Label lastLabel;
        private System.Windows.Forms.Label firstLabel;
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.MonthCalendar roomReservationCalendar;
        private System.Windows.Forms.ListBox hotelListBox;
        private System.Windows.Forms.Label hotelLabel;
    }
}