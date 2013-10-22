namespace InsertWizard_Project
{
    partial class InsertFacultyForm
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
            this.components = new System.ComponentModel.Container();
            this.Label19 = new System.Windows.Forms.Label();
            this.txtPhotoName = new System.Windows.Forms.TextBox();
            this.Label9 = new System.Windows.Forms.Label();
            this.GroupBox3 = new System.Windows.Forms.GroupBox();
            this.txtPhotoLocation = new System.Windows.Forms.TextBox();
            this.Label8 = new System.Windows.Forms.Label();
            this.Label7 = new System.Windows.Forms.Label();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.txtID = new System.Windows.Forms.TextBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.cmdBack = new System.Windows.Forms.Button();
            this.txtOffice = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.Label6 = new System.Windows.Forms.Label();
            this.cmdInsert = new System.Windows.Forms.Button();
            this.Label5 = new System.Windows.Forms.Label();
            this.PhotoBox = new System.Windows.Forms.PictureBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.comboMethod = new System.Windows.Forms.ComboBox();
            this.cmdSelect = new System.Windows.Forms.Button();
            this.txtCollege = new System.Windows.Forms.TextBox();
            this.chkPhoto = new System.Windows.Forms.CheckBox();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.facultyBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cSE_DEPTDataSet = new InsertWizard_Project.CSE_DEPTDataSet();
            this.facultyTableAdapter = new InsertWizard_Project.CSE_DEPTDataSetTableAdapters.FacultyTableAdapter();
            this.GroupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PhotoBox)).BeginInit();
            this.GroupBox1.SuspendLayout();
            this.GroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.facultyBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cSE_DEPTDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // Label19
            // 
            this.Label19.AutoSize = true;
            this.Label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label19.Location = new System.Drawing.Point(3, 25);
            this.Label19.Name = "Label19";
            this.Label19.Size = new System.Drawing.Size(65, 13);
            this.Label19.TabIndex = 0;
            this.Label19.Text = "Faculty ID";
            // 
            // txtPhotoName
            // 
            this.txtPhotoName.Enabled = false;
            this.txtPhotoName.Location = new System.Drawing.Point(100, 19);
            this.txtPhotoName.Name = "txtPhotoName";
            this.txtPhotoName.Size = new System.Drawing.Size(242, 20);
            this.txtPhotoName.TabIndex = 1;
            // 
            // Label9
            // 
            this.Label9.AutoSize = true;
            this.Label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label9.Location = new System.Drawing.Point(2, 61);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(49, 13);
            this.Label9.TabIndex = 25;
            this.Label9.Text = "Method";
            // 
            // GroupBox3
            // 
            this.GroupBox3.Controls.Add(this.txtPhotoLocation);
            this.GroupBox3.Controls.Add(this.Label8);
            this.GroupBox3.Controls.Add(this.Label7);
            this.GroupBox3.Controls.Add(this.txtPhotoName);
            this.GroupBox3.Location = new System.Drawing.Point(195, 13);
            this.GroupBox3.Name = "GroupBox3";
            this.GroupBox3.Size = new System.Drawing.Size(358, 72);
            this.GroupBox3.TabIndex = 24;
            this.GroupBox3.TabStop = false;
            this.GroupBox3.Text = "Faculty photo";
            // 
            // txtPhotoLocation
            // 
            this.txtPhotoLocation.Enabled = false;
            this.txtPhotoLocation.Location = new System.Drawing.Point(100, 45);
            this.txtPhotoLocation.Name = "txtPhotoLocation";
            this.txtPhotoLocation.Size = new System.Drawing.Size(242, 20);
            this.txtPhotoLocation.TabIndex = 3;
            this.txtPhotoLocation.Text = "Default Location";
            // 
            // Label8
            // 
            this.Label8.AutoSize = true;
            this.Label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label8.Location = new System.Drawing.Point(6, 46);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(93, 13);
            this.Label8.TabIndex = 2;
            this.Label8.Text = "Photo Location";
            // 
            // Label7
            // 
            this.Label7.AutoSize = true;
            this.Label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label7.Location = new System.Drawing.Point(6, 22);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(76, 13);
            this.Label7.TabIndex = 0;
            this.Label7.Text = "Photo Name";
            // 
            // cmdCancel
            // 
            this.cmdCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdCancel.Location = new System.Drawing.Point(480, 229);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(73, 31);
            this.cmdCancel.TabIndex = 29;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(74, 22);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(70, 20);
            this.txtID.TabIndex = 1;
            this.txtID.TextChanged += new System.EventHandler(this.txtID_TextChanged);
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.Location = new System.Drawing.Point(7, 48);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(41, 13);
            this.Label3.TabIndex = 2;
            this.Label3.Text = "Office";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.Location = new System.Drawing.Point(152, 25);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(84, 13);
            this.Label1.TabIndex = 2;
            this.Label1.Text = "Faculty Name";
            // 
            // cmdBack
            // 
            this.cmdBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdBack.Location = new System.Drawing.Point(480, 268);
            this.cmdBack.Name = "cmdBack";
            this.cmdBack.Size = new System.Drawing.Size(73, 31);
            this.cmdBack.TabIndex = 30;
            this.cmdBack.Text = "Back";
            this.cmdBack.UseVisualStyleBackColor = true;
            this.cmdBack.Click += new System.EventHandler(this.cmdBack_Click);
            // 
            // txtOffice
            // 
            this.txtOffice.Location = new System.Drawing.Point(59, 44);
            this.txtOffice.Name = "txtOffice";
            this.txtOffice.Size = new System.Drawing.Size(177, 20);
            this.txtOffice.TabIndex = 3;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.Location = new System.Drawing.Point(7, 22);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(32, 13);
            this.Label2.TabIndex = 0;
            this.Label2.Text = "Title";
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(59, 19);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(177, 20);
            this.txtTitle.TabIndex = 1;
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label6.Location = new System.Drawing.Point(7, 123);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(37, 13);
            this.Label6.TabIndex = 8;
            this.Label6.Text = "Email";
            // 
            // cmdInsert
            // 
            this.cmdInsert.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdInsert.Location = new System.Drawing.Point(480, 155);
            this.cmdInsert.Name = "cmdInsert";
            this.cmdInsert.Size = new System.Drawing.Size(73, 31);
            this.cmdInsert.TabIndex = 27;
            this.cmdInsert.Text = "Insert";
            this.cmdInsert.UseVisualStyleBackColor = true;
            this.cmdInsert.Click += new System.EventHandler(this.cmdInsert_Click);
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label5.Location = new System.Drawing.Point(7, 100);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(49, 13);
            this.Label5.TabIndex = 6;
            this.Label5.Text = "College";
            // 
            // PhotoBox
            // 
            this.PhotoBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PhotoBox.Location = new System.Drawing.Point(12, 101);
            this.PhotoBox.Name = "PhotoBox";
            this.PhotoBox.Size = new System.Drawing.Size(168, 189);
            this.PhotoBox.TabIndex = 31;
            this.PhotoBox.TabStop = false;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(59, 119);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(177, 20);
            this.txtEmail.TabIndex = 9;
            // 
            // comboMethod
            // 
            this.comboMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboMethod.FormattingEnabled = true;
            this.comboMethod.Location = new System.Drawing.Point(57, 58);
            this.comboMethod.Name = "comboMethod";
            this.comboMethod.Size = new System.Drawing.Size(123, 21);
            this.comboMethod.TabIndex = 26;
            // 
            // cmdSelect
            // 
            this.cmdSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSelect.Location = new System.Drawing.Point(480, 192);
            this.cmdSelect.Name = "cmdSelect";
            this.cmdSelect.Size = new System.Drawing.Size(73, 31);
            this.cmdSelect.TabIndex = 28;
            this.cmdSelect.Text = "Select";
            this.cmdSelect.UseVisualStyleBackColor = true;
            // 
            // txtCollege
            // 
            this.txtCollege.Location = new System.Drawing.Point(59, 94);
            this.txtCollege.Name = "txtCollege";
            this.txtCollege.Size = new System.Drawing.Size(177, 20);
            this.txtCollege.TabIndex = 7;
            // 
            // chkPhoto
            // 
            this.chkPhoto.AutoSize = true;
            this.chkPhoto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkPhoto.Location = new System.Drawing.Point(21, 22);
            this.chkPhoto.Name = "chkPhoto";
            this.chkPhoto.Size = new System.Drawing.Size(104, 17);
            this.chkPhoto.TabIndex = 23;
            this.chkPhoto.Text = "Faculty Photo";
            this.chkPhoto.UseVisualStyleBackColor = true;
            this.chkPhoto.CheckedChanged += new System.EventHandler(this.chkPhoto_CheckedChanged);
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.Label19);
            this.GroupBox1.Controls.Add(this.txtID);
            this.GroupBox1.Controls.Add(this.Label1);
            this.GroupBox1.Controls.Add(this.txtName);
            this.GroupBox1.Location = new System.Drawing.Point(195, 91);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(358, 54);
            this.GroupBox1.TabIndex = 21;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Faculty ID and name";
            // 
            // txtName
            // 
            this.txtName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.facultyBindingSource, "faculty_name", true));
            this.txtName.Location = new System.Drawing.Point(242, 22);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(110, 20);
            this.txtName.TabIndex = 3;
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label4.Location = new System.Drawing.Point(7, 74);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(43, 13);
            this.Label4.TabIndex = 4;
            this.Label4.Text = "Phone";
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(59, 69);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(177, 20);
            this.txtPhone.TabIndex = 5;
            // 
            // GroupBox2
            // 
            this.GroupBox2.Controls.Add(this.Label6);
            this.GroupBox2.Controls.Add(this.txtEmail);
            this.GroupBox2.Controls.Add(this.Label5);
            this.GroupBox2.Controls.Add(this.txtCollege);
            this.GroupBox2.Controls.Add(this.Label4);
            this.GroupBox2.Controls.Add(this.txtPhone);
            this.GroupBox2.Controls.Add(this.Label3);
            this.GroupBox2.Controls.Add(this.txtOffice);
            this.GroupBox2.Controls.Add(this.Label2);
            this.GroupBox2.Controls.Add(this.txtTitle);
            this.GroupBox2.Location = new System.Drawing.Point(195, 151);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(251, 151);
            this.GroupBox2.TabIndex = 22;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Text = "Faculty information";
            // 
            // facultyBindingSource
            // 
            this.facultyBindingSource.DataMember = "Faculty";
            this.facultyBindingSource.DataSource = this.cSE_DEPTDataSet;
            // 
            // cSE_DEPTDataSet
            // 
            this.cSE_DEPTDataSet.DataSetName = "CSE_DEPTDataSet";
            this.cSE_DEPTDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // facultyTableAdapter
            // 
            this.facultyTableAdapter.ClearBeforeFill = true;
            // 
            // InsertFacultyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(571, 315);
            this.Controls.Add(this.Label9);
            this.Controls.Add(this.GroupBox3);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdBack);
            this.Controls.Add(this.cmdInsert);
            this.Controls.Add(this.PhotoBox);
            this.Controls.Add(this.comboMethod);
            this.Controls.Add(this.cmdSelect);
            this.Controls.Add(this.chkPhoto);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.GroupBox2);
            this.Name = "InsertFacultyForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CSE DEPT Insert Faculty Form";
            this.Load += new System.EventHandler(this.InsertFacultyForm_Load);
            this.GroupBox3.ResumeLayout(false);
            this.GroupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PhotoBox)).EndInit();
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.GroupBox2.ResumeLayout(false);
            this.GroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.facultyBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cSE_DEPTDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label Label19;
        internal System.Windows.Forms.TextBox txtPhotoName;
        internal System.Windows.Forms.Label Label9;
        internal System.Windows.Forms.GroupBox GroupBox3;
        internal System.Windows.Forms.TextBox txtPhotoLocation;
        internal System.Windows.Forms.Label Label8;
        internal System.Windows.Forms.Label Label7;
        internal System.Windows.Forms.Button cmdCancel;
        internal System.Windows.Forms.TextBox txtID;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Button cmdBack;
        internal System.Windows.Forms.TextBox txtOffice;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.TextBox txtTitle;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.Button cmdInsert;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.PictureBox PhotoBox;
        internal System.Windows.Forms.TextBox txtEmail;
        internal System.Windows.Forms.ComboBox comboMethod;
        internal System.Windows.Forms.Button cmdSelect;
        internal System.Windows.Forms.TextBox txtCollege;
        internal System.Windows.Forms.CheckBox chkPhoto;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.TextBox txtName;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.TextBox txtPhone;
        internal System.Windows.Forms.GroupBox GroupBox2;
        private CSE_DEPTDataSet cSE_DEPTDataSet;
        private System.Windows.Forms.BindingSource facultyBindingSource;
        private InsertWizard_Project.CSE_DEPTDataSetTableAdapters.FacultyTableAdapter facultyTableAdapter;
    }
}