namespace HotelManagementProject
{
    partial class TransactionInterface
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
            this.rewardGroupBox = new System.Windows.Forms.GroupBox();
            this.paymentGroupBox = new System.Windows.Forms.GroupBox();
            this.rewardPointsLabel = new System.Windows.Forms.Label();
            this.rewardListBox = new System.Windows.Forms.ListBox();
            this.costLabel = new System.Windows.Forms.Label();
            this.cardNumberLabel = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.codeLabel = new System.Windows.Forms.Label();
            this.dateLabel = new System.Windows.Forms.Label();
            this.cardNumberTextBox = new System.Windows.Forms.TextBox();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.codeTextBox = new System.Windows.Forms.TextBox();
            this.dateTextBox = new System.Windows.Forms.TextBox();
            this.submitButton = new System.Windows.Forms.Button();
            this.rewardGroupBox.SuspendLayout();
            this.paymentGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // rewardGroupBox
            // 
            this.rewardGroupBox.Controls.Add(this.rewardListBox);
            this.rewardGroupBox.Controls.Add(this.rewardPointsLabel);
            this.rewardGroupBox.Location = new System.Drawing.Point(12, 12);
            this.rewardGroupBox.Name = "rewardGroupBox";
            this.rewardGroupBox.Size = new System.Drawing.Size(224, 192);
            this.rewardGroupBox.TabIndex = 0;
            this.rewardGroupBox.TabStop = false;
            this.rewardGroupBox.Text = "Reward";
            // 
            // paymentGroupBox
            // 
            this.paymentGroupBox.Controls.Add(this.submitButton);
            this.paymentGroupBox.Controls.Add(this.dateTextBox);
            this.paymentGroupBox.Controls.Add(this.codeTextBox);
            this.paymentGroupBox.Controls.Add(this.nameTextBox);
            this.paymentGroupBox.Controls.Add(this.cardNumberTextBox);
            this.paymentGroupBox.Controls.Add(this.dateLabel);
            this.paymentGroupBox.Controls.Add(this.codeLabel);
            this.paymentGroupBox.Controls.Add(this.nameLabel);
            this.paymentGroupBox.Controls.Add(this.cardNumberLabel);
            this.paymentGroupBox.Controls.Add(this.costLabel);
            this.paymentGroupBox.Location = new System.Drawing.Point(242, 12);
            this.paymentGroupBox.Name = "paymentGroupBox";
            this.paymentGroupBox.Size = new System.Drawing.Size(208, 192);
            this.paymentGroupBox.TabIndex = 1;
            this.paymentGroupBox.TabStop = false;
            this.paymentGroupBox.Text = "Payment";
            // 
            // rewardPointsLabel
            // 
            this.rewardPointsLabel.AutoSize = true;
            this.rewardPointsLabel.Location = new System.Drawing.Point(6, 16);
            this.rewardPointsLabel.Name = "rewardPointsLabel";
            this.rewardPointsLabel.Size = new System.Drawing.Size(94, 13);
            this.rewardPointsLabel.TabIndex = 2;
            this.rewardPointsLabel.Text = "Reward Points: <>";
            // 
            // rewardListBox
            // 
            this.rewardListBox.FormattingEnabled = true;
            this.rewardListBox.Location = new System.Drawing.Point(6, 32);
            this.rewardListBox.Name = "rewardListBox";
            this.rewardListBox.Size = new System.Drawing.Size(212, 147);
            this.rewardListBox.TabIndex = 2;
            // 
            // costLabel
            // 
            this.costLabel.AutoSize = true;
            this.costLabel.Location = new System.Drawing.Point(6, 16);
            this.costLabel.Name = "costLabel";
            this.costLabel.Size = new System.Drawing.Size(46, 13);
            this.costLabel.TabIndex = 0;
            this.costLabel.Text = "Cost: <>";
            // 
            // cardNumberLabel
            // 
            this.cardNumberLabel.AutoSize = true;
            this.cardNumberLabel.Location = new System.Drawing.Point(6, 32);
            this.cardNumberLabel.Name = "cardNumberLabel";
            this.cardNumberLabel.Size = new System.Drawing.Size(99, 13);
            this.cardNumberLabel.TabIndex = 1;
            this.cardNumberLabel.Text = "Credit Card Number";
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(6, 71);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(89, 13);
            this.nameLabel.TabIndex = 2;
            this.nameLabel.Text = "Cardholder Name";
            // 
            // codeLabel
            // 
            this.codeLabel.AutoSize = true;
            this.codeLabel.Location = new System.Drawing.Point(6, 110);
            this.codeLabel.Name = "codeLabel";
            this.codeLabel.Size = new System.Drawing.Size(28, 13);
            this.codeLabel.TabIndex = 3;
            this.codeLabel.Text = "CVC";
            // 
            // dateLabel
            // 
            this.dateLabel.AutoSize = true;
            this.dateLabel.Location = new System.Drawing.Point(91, 110);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new System.Drawing.Size(61, 13);
            this.dateLabel.TabIndex = 4;
            this.dateLabel.Text = "Expiry Date";
            // 
            // cardNumberTextBox
            // 
            this.cardNumberTextBox.Location = new System.Drawing.Point(9, 48);
            this.cardNumberTextBox.Name = "cardNumberTextBox";
            this.cardNumberTextBox.Size = new System.Drawing.Size(193, 20);
            this.cardNumberTextBox.TabIndex = 2;
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(9, 87);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(193, 20);
            this.nameTextBox.TabIndex = 5;
            // 
            // codeTextBox
            // 
            this.codeTextBox.Location = new System.Drawing.Point(9, 126);
            this.codeTextBox.Name = "codeTextBox";
            this.codeTextBox.Size = new System.Drawing.Size(77, 20);
            this.codeTextBox.TabIndex = 6;
            // 
            // dateTextBox
            // 
            this.dateTextBox.Location = new System.Drawing.Point(94, 126);
            this.dateTextBox.Name = "dateTextBox";
            this.dateTextBox.Size = new System.Drawing.Size(108, 20);
            this.dateTextBox.TabIndex = 7;
            // 
            // submitButton
            // 
            this.submitButton.Location = new System.Drawing.Point(7, 153);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(195, 23);
            this.submitButton.TabIndex = 8;
            this.submitButton.Text = "Submit";
            this.submitButton.UseVisualStyleBackColor = true;
            this.submitButton.Click += new System.EventHandler(this.submitButton_Click);
            // 
            // TransactionInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 217);
            this.Controls.Add(this.paymentGroupBox);
            this.Controls.Add(this.rewardGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "TransactionInterface";
            this.Text = "Transaction";
            this.rewardGroupBox.ResumeLayout(false);
            this.rewardGroupBox.PerformLayout();
            this.paymentGroupBox.ResumeLayout(false);
            this.paymentGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox rewardGroupBox;
        private System.Windows.Forms.ListBox rewardListBox;
        private System.Windows.Forms.Label rewardPointsLabel;
        private System.Windows.Forms.GroupBox paymentGroupBox;
        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.TextBox dateTextBox;
        private System.Windows.Forms.TextBox codeTextBox;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.TextBox cardNumberTextBox;
        private System.Windows.Forms.Label dateLabel;
        private System.Windows.Forms.Label codeLabel;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label cardNumberLabel;
        private System.Windows.Forms.Label costLabel;
    }
}