namespace AccessInsertRTObject
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
            this.TitleLabel = new System.Windows.Forms.Label();
            this.cmdDelete = new System.Windows.Forms.Button();
            this.EmailLabel = new System.Windows.Forms.Label();
            this.PhotoBox = new System.Windows.Forms.PictureBox();
            this.cmdInsert = new System.Windows.Forms.Button();
            this.ComboMethod = new System.Windows.Forms.ComboBox();
            this.ComboName = new System.Windows.Forms.ComboBox();
            this.FacultyInfoBox = new System.Windows.Forms.GroupBox();
            this.CollegeLabel = new System.Windows.Forms.Label();
            this.PhoneLabel = new System.Windows.Forms.Label();
            this.OfficeLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdUpdate = new System.Windows.Forms.Button();
            this.cmdSelect = new System.Windows.Forms.Button();
            this.FacultyBox = new System.Windows.Forms.GroupBox();
            this.FacultyNameLabel = new System.Windows.Forms.Label();
            this.cmdBack = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PhotoBox)).BeginInit();
            this.FacultyInfoBox.SuspendLayout();
            this.FacultyBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // TitleLabel
            // 
            this.TitleLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.TitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleLabel.Location = new System.Drawing.Point(16, 25);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(228, 16);
            this.TitleLabel.TabIndex = 0;
            // 
            // cmdDelete
            // 
            this.cmdDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdDelete.Location = new System.Drawing.Point(305, 243);
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.Size = new System.Drawing.Size(80, 32);
            this.cmdDelete.TabIndex = 68;
            this.cmdDelete.Text = "Delete";
            // 
            // EmailLabel
            // 
            this.EmailLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.EmailLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EmailLabel.Location = new System.Drawing.Point(16, 113);
            this.EmailLabel.Name = "EmailLabel";
            this.EmailLabel.Size = new System.Drawing.Size(228, 16);
            this.EmailLabel.TabIndex = 4;
            // 
            // PhotoBox
            // 
            this.PhotoBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PhotoBox.Location = new System.Drawing.Point(14, 27);
            this.PhotoBox.Name = "PhotoBox";
            this.PhotoBox.Size = new System.Drawing.Size(171, 179);
            this.PhotoBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PhotoBox.TabIndex = 70;
            this.PhotoBox.TabStop = false;
            // 
            // cmdInsert
            // 
            this.cmdInsert.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdInsert.Location = new System.Drawing.Point(111, 243);
            this.cmdInsert.Name = "cmdInsert";
            this.cmdInsert.Size = new System.Drawing.Size(80, 32);
            this.cmdInsert.TabIndex = 66;
            this.cmdInsert.Text = "Insert";
            this.cmdInsert.Click += new System.EventHandler(this.cmdInsert_Click);
            // 
            // ComboMethod
            // 
            this.ComboMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboMethod.FormattingEnabled = true;
            this.ComboMethod.Location = new System.Drawing.Point(110, 45);
            this.ComboMethod.Name = "ComboMethod";
            this.ComboMethod.Size = new System.Drawing.Size(134, 21);
            this.ComboMethod.TabIndex = 3;
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
            // FacultyInfoBox
            // 
            this.FacultyInfoBox.Controls.Add(this.EmailLabel);
            this.FacultyInfoBox.Controls.Add(this.CollegeLabel);
            this.FacultyInfoBox.Controls.Add(this.PhoneLabel);
            this.FacultyInfoBox.Controls.Add(this.OfficeLabel);
            this.FacultyInfoBox.Controls.Add(this.TitleLabel);
            this.FacultyInfoBox.Location = new System.Drawing.Point(226, 94);
            this.FacultyInfoBox.Name = "FacultyInfoBox";
            this.FacultyInfoBox.Size = new System.Drawing.Size(264, 143);
            this.FacultyInfoBox.TabIndex = 64;
            this.FacultyInfoBox.TabStop = false;
            this.FacultyInfoBox.Text = "Faculty Information";
            // 
            // CollegeLabel
            // 
            this.CollegeLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.CollegeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CollegeLabel.Location = new System.Drawing.Point(16, 88);
            this.CollegeLabel.Name = "CollegeLabel";
            this.CollegeLabel.Size = new System.Drawing.Size(228, 16);
            this.CollegeLabel.TabIndex = 3;
            // 
            // PhoneLabel
            // 
            this.PhoneLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PhoneLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PhoneLabel.Location = new System.Drawing.Point(16, 69);
            this.PhoneLabel.Name = "PhoneLabel";
            this.PhoneLabel.Size = new System.Drawing.Size(228, 16);
            this.PhoneLabel.TabIndex = 2;
            // 
            // OfficeLabel
            // 
            this.OfficeLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.OfficeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OfficeLabel.Location = new System.Drawing.Point(16, 47);
            this.OfficeLabel.Name = "OfficeLabel";
            this.OfficeLabel.Size = new System.Drawing.Size(228, 16);
            this.OfficeLabel.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Query Method";
            // 
            // cmdUpdate
            // 
            this.cmdUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdUpdate.Location = new System.Drawing.Point(208, 243);
            this.cmdUpdate.Name = "cmdUpdate";
            this.cmdUpdate.Size = new System.Drawing.Size(80, 32);
            this.cmdUpdate.TabIndex = 67;
            this.cmdUpdate.Text = "Update";
            // 
            // cmdSelect
            // 
            this.cmdSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSelect.Location = new System.Drawing.Point(14, 243);
            this.cmdSelect.Name = "cmdSelect";
            this.cmdSelect.Size = new System.Drawing.Size(80, 32);
            this.cmdSelect.TabIndex = 65;
            this.cmdSelect.Text = "Select";
            this.cmdSelect.Click += new System.EventHandler(this.cmdSelect_Click);
            // 
            // FacultyBox
            // 
            this.FacultyBox.Controls.Add(this.ComboMethod);
            this.FacultyBox.Controls.Add(this.label1);
            this.FacultyBox.Controls.Add(this.ComboName);
            this.FacultyBox.Controls.Add(this.FacultyNameLabel);
            this.FacultyBox.Location = new System.Drawing.Point(226, 12);
            this.FacultyBox.Name = "FacultyBox";
            this.FacultyBox.Size = new System.Drawing.Size(264, 76);
            this.FacultyBox.TabIndex = 63;
            this.FacultyBox.TabStop = false;
            this.FacultyBox.Text = "Name and Method";
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
            // cmdBack
            // 
            this.cmdBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdBack.Location = new System.Drawing.Point(395, 243);
            this.cmdBack.Name = "cmdBack";
            this.cmdBack.Size = new System.Drawing.Size(75, 32);
            this.cmdBack.TabIndex = 69;
            this.cmdBack.Text = "Back";
            this.cmdBack.Click += new System.EventHandler(this.cmdBack_Click);
            // 
            // FacultyForm
            // 
            this.AcceptButton = this.cmdSelect;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 291);
            this.Controls.Add(this.cmdDelete);
            this.Controls.Add(this.PhotoBox);
            this.Controls.Add(this.cmdInsert);
            this.Controls.Add(this.FacultyInfoBox);
            this.Controls.Add(this.cmdUpdate);
            this.Controls.Add(this.cmdSelect);
            this.Controls.Add(this.FacultyBox);
            this.Controls.Add(this.cmdBack);
            this.Name = "FacultyForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CSE DEPT Faculty Form";
            ((System.ComponentModel.ISupportInitialize)(this.PhotoBox)).EndInit();
            this.FacultyInfoBox.ResumeLayout(false);
            this.FacultyBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Label TitleLabel;
        internal System.Windows.Forms.Button cmdDelete;
        internal System.Windows.Forms.Label EmailLabel;
        internal System.Windows.Forms.PictureBox PhotoBox;
        internal System.Windows.Forms.Button cmdInsert;
        internal System.Windows.Forms.ComboBox ComboMethod;
        internal System.Windows.Forms.ComboBox ComboName;
        internal System.Windows.Forms.GroupBox FacultyInfoBox;
        internal System.Windows.Forms.Label CollegeLabel;
        internal System.Windows.Forms.Label PhoneLabel;
        internal System.Windows.Forms.Label OfficeLabel;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Button cmdUpdate;
        internal System.Windows.Forms.Button cmdSelect;
        internal System.Windows.Forms.GroupBox FacultyBox;
        internal System.Windows.Forms.Label FacultyNameLabel;
        internal System.Windows.Forms.Button cmdBack;
    }
}