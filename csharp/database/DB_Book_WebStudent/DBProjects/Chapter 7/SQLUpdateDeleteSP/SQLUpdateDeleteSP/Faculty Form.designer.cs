namespace SQLUpdateDeleteSP
{
    partial class FacultyForm
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
            this.label8 = new System.Windows.Forms.Label();
            this.ComboMethod = new System.Windows.Forms.ComboBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCollege = new System.Windows.Forms.TextBox();
            this.FacultyBox = new System.Windows.Forms.GroupBox();
            this.ComboName = new System.Windows.Forms.ComboBox();
            this.FacultyNameLabel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.PhotoBox = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtOffice = new System.Windows.Forms.TextBox();
            this.cmdBack = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.FacultyInfoBox = new System.Windows.Forms.GroupBox();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.cmdDelete = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cmdInsert = new System.Windows.Forms.Button();
            this.cmdUpdate = new System.Windows.Forms.Button();
            this.cmdSelect = new System.Windows.Forms.Button();
            this.FacultyBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PhotoBox)).BeginInit();
            this.FacultyInfoBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(8, 156);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "Email";
            // 
            // ComboMethod
            // 
            this.ComboMethod.FormattingEnabled = true;
            this.ComboMethod.Location = new System.Drawing.Point(54, 24);
            this.ComboMethod.Name = "ComboMethod";
            this.ComboMethod.Size = new System.Drawing.Size(146, 21);
            this.ComboMethod.TabIndex = 59;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(92, 153);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(166, 20);
            this.txtEmail.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(8, 133);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "College";
            // 
            // txtCollege
            // 
            this.txtCollege.Location = new System.Drawing.Point(92, 126);
            this.txtCollege.Name = "txtCollege";
            this.txtCollege.Size = new System.Drawing.Size(166, 20);
            this.txtCollege.TabIndex = 10;
            // 
            // FacultyBox
            // 
            this.FacultyBox.Controls.Add(this.ComboName);
            this.FacultyBox.Controls.Add(this.FacultyNameLabel);
            this.FacultyBox.Location = new System.Drawing.Point(235, 9);
            this.FacultyBox.Name = "FacultyBox";
            this.FacultyBox.Size = new System.Drawing.Size(264, 47);
            this.FacultyBox.TabIndex = 51;
            this.FacultyBox.TabStop = false;
            this.FacultyBox.Text = "Faculty Name";
            // 
            // ComboName
            // 
            this.ComboName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboName.FormattingEnabled = true;
            this.ComboName.Location = new System.Drawing.Point(110, 15);
            this.ComboName.Name = "ComboName";
            this.ComboName.Size = new System.Drawing.Size(134, 21);
            this.ComboName.TabIndex = 1;
            // 
            // FacultyNameLabel
            // 
            this.FacultyNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FacultyNameLabel.Location = new System.Drawing.Point(13, 20);
            this.FacultyNameLabel.Name = "FacultyNameLabel";
            this.FacultyNameLabel.Size = new System.Drawing.Size(88, 16);
            this.FacultyNameLabel.TabIndex = 0;
            this.FacultyNameLabel.Text = "Faculty Name";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(8, 107);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Phone";
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(92, 100);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(166, 20);
            this.txtPhone.TabIndex = 8;
            // 
            // PhotoBox
            // 
            this.PhotoBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PhotoBox.Location = new System.Drawing.Point(23, 62);
            this.PhotoBox.Name = "PhotoBox";
            this.PhotoBox.Size = new System.Drawing.Size(171, 179);
            this.PhotoBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PhotoBox.TabIndex = 58;
            this.PhotoBox.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(8, 77);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Office";
            // 
            // txtOffice
            // 
            this.txtOffice.Location = new System.Drawing.Point(92, 74);
            this.txtOffice.Name = "txtOffice";
            this.txtOffice.Size = new System.Drawing.Size(166, 20);
            this.txtOffice.TabIndex = 6;
            // 
            // cmdBack
            // 
            this.cmdBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdBack.Location = new System.Drawing.Point(411, 250);
            this.cmdBack.Name = "cmdBack";
            this.cmdBack.Size = new System.Drawing.Size(88, 32);
            this.cmdBack.TabIndex = 57;
            this.cmdBack.Text = "Back";
            this.cmdBack.Click += new System.EventHandler(this.cmdBack_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(8, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Title";
            // 
            // FacultyInfoBox
            // 
            this.FacultyInfoBox.Controls.Add(this.label8);
            this.FacultyInfoBox.Controls.Add(this.txtEmail);
            this.FacultyInfoBox.Controls.Add(this.label7);
            this.FacultyInfoBox.Controls.Add(this.txtCollege);
            this.FacultyInfoBox.Controls.Add(this.label6);
            this.FacultyInfoBox.Controls.Add(this.txtPhone);
            this.FacultyInfoBox.Controls.Add(this.label5);
            this.FacultyInfoBox.Controls.Add(this.txtOffice);
            this.FacultyInfoBox.Controls.Add(this.label4);
            this.FacultyInfoBox.Controls.Add(this.txtTitle);
            this.FacultyInfoBox.Controls.Add(this.label3);
            this.FacultyInfoBox.Controls.Add(this.txtName);
            this.FacultyInfoBox.Location = new System.Drawing.Point(235, 62);
            this.FacultyInfoBox.Name = "FacultyInfoBox";
            this.FacultyInfoBox.Size = new System.Drawing.Size(264, 182);
            this.FacultyInfoBox.TabIndex = 52;
            this.FacultyInfoBox.TabStop = false;
            this.FacultyInfoBox.Text = "Faculty Information";
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(92, 48);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(166, 20);
            this.txtTitle.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(8, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Faculty Name";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(92, 22);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(166, 20);
            this.txtName.TabIndex = 2;
            // 
            // cmdDelete
            // 
            this.cmdDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdDelete.Location = new System.Drawing.Point(314, 250);
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.Size = new System.Drawing.Size(80, 32);
            this.cmdDelete.TabIndex = 56;
            this.cmdDelete.Text = "Delete";
            this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(5, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 60;
            this.label2.Text = "Method";
            // 
            // cmdInsert
            // 
            this.cmdInsert.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdInsert.Location = new System.Drawing.Point(120, 250);
            this.cmdInsert.Name = "cmdInsert";
            this.cmdInsert.Size = new System.Drawing.Size(80, 32);
            this.cmdInsert.TabIndex = 54;
            this.cmdInsert.Text = "Insert";
            this.cmdInsert.Click += new System.EventHandler(this.cmdInsert_Click);
            // 
            // cmdUpdate
            // 
            this.cmdUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdUpdate.Location = new System.Drawing.Point(217, 250);
            this.cmdUpdate.Name = "cmdUpdate";
            this.cmdUpdate.Size = new System.Drawing.Size(80, 32);
            this.cmdUpdate.TabIndex = 55;
            this.cmdUpdate.Text = "Update";
            this.cmdUpdate.Click += new System.EventHandler(this.cmdUpdate_Click);
            // 
            // cmdSelect
            // 
            this.cmdSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSelect.Location = new System.Drawing.Point(23, 250);
            this.cmdSelect.Name = "cmdSelect";
            this.cmdSelect.Size = new System.Drawing.Size(80, 32);
            this.cmdSelect.TabIndex = 53;
            this.cmdSelect.Text = "Select";
            this.cmdSelect.Click += new System.EventHandler(this.cmdSelect_Click);
            // 
            // FacultyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(515, 296);
            this.Controls.Add(this.ComboMethod);
            this.Controls.Add(this.FacultyBox);
            this.Controls.Add(this.PhotoBox);
            this.Controls.Add(this.cmdBack);
            this.Controls.Add(this.FacultyInfoBox);
            this.Controls.Add(this.cmdDelete);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmdInsert);
            this.Controls.Add(this.cmdUpdate);
            this.Controls.Add(this.cmdSelect);
            this.Name = "FacultyForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CSE DEPT Faculty Form";
            this.FacultyBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PhotoBox)).EndInit();
            this.FacultyInfoBox.ResumeLayout(false);
            this.FacultyInfoBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox ComboMethod;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtCollege;
        internal System.Windows.Forms.GroupBox FacultyBox;
        internal System.Windows.Forms.ComboBox ComboName;
        internal System.Windows.Forms.Label FacultyNameLabel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPhone;
        internal System.Windows.Forms.PictureBox PhotoBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtOffice;
        internal System.Windows.Forms.Button cmdBack;
        private System.Windows.Forms.Label label4;
        internal System.Windows.Forms.GroupBox FacultyInfoBox;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtName;
        internal System.Windows.Forms.Button cmdDelete;
        private System.Windows.Forms.Label label2;
        internal System.Windows.Forms.Button cmdInsert;
        internal System.Windows.Forms.Button cmdUpdate;
        internal System.Windows.Forms.Button cmdSelect;

    }
}