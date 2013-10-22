namespace AccessUpdateDeleteWizard_Project
{
    partial class StudentForm
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
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.studentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cSE_DEPTDataSet = new AccessUpdateDeleteWizard_Project.CSE_DEPTDataSet();
            this.Label6 = new System.Windows.Forms.Label();
            this.Label5 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.CourseList = new System.Windows.Forms.ListBox();
            this.studentCourseBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Label3 = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.StudentNameBox = new System.Windows.Forms.GroupBox();
            this.ComboMethod = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.ComboName = new System.Windows.Forms.ComboBox();
            this.PhotoBox = new System.Windows.Forms.PictureBox();
            this.StudentInfoBox = new System.Windows.Forms.GroupBox();
            this.txtSchoolYear = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.txtCredits = new System.Windows.Forms.TextBox();
            this.txtMajor = new System.Windows.Forms.TextBox();
            this.txtGPA = new System.Windows.Forms.TextBox();
            this.Label7 = new System.Windows.Forms.Label();
            this.cmdInsert = new System.Windows.Forms.Button();
            this.cmdSelect = new System.Windows.Forms.Button();
            this.CourseSelectedBox = new System.Windows.Forms.GroupBox();
            this.cmdBack = new System.Windows.Forms.Button();
            this.studentCourseTableAdapter = new AccessUpdateDeleteWizard_Project.CSE_DEPTDataSetTableAdapters.StudentCourseTableAdapter();
            this.studentTableAdapter = new AccessUpdateDeleteWizard_Project.CSE_DEPTDataSetTableAdapters.StudentTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.studentBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cSE_DEPTDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.studentCourseBindingSource)).BeginInit();
            this.StudentNameBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PhotoBox)).BeginInit();
            this.StudentInfoBox.SuspendLayout();
            this.CourseSelectedBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtEmail
            // 
            this.txtEmail.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.studentBindingSource, "email", true));
            this.txtEmail.Location = new System.Drawing.Point(83, 154);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(162, 20);
            this.txtEmail.TabIndex = 11;
            // 
            // studentBindingSource
            // 
            this.studentBindingSource.DataMember = "Student";
            this.studentBindingSource.DataSource = this.cSE_DEPTDataSet;
            // 
            // cSE_DEPTDataSet
            // 
            this.cSE_DEPTDataSet.DataSetName = "CSE_DEPTDataSet";
            this.cSE_DEPTDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // Label6
            // 
            this.Label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label6.Location = new System.Drawing.Point(6, 128);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(73, 20);
            this.Label6.TabIndex = 8;
            this.Label6.Text = "Credits";
            this.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label5
            // 
            this.Label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label5.Location = new System.Drawing.Point(6, 102);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(71, 20);
            this.Label5.TabIndex = 6;
            this.Label5.Text = "Major";
            this.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label4
            // 
            this.Label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label4.Location = new System.Drawing.Point(6, 76);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(71, 17);
            this.Label4.TabIndex = 4;
            this.Label4.Text = "GPA";
            this.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CourseList
            // 
            this.CourseList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CourseList.DataSource = this.studentCourseBindingSource;
            this.CourseList.DisplayMember = "course_id";
            this.CourseList.Location = new System.Drawing.Point(35, 19);
            this.CourseList.Name = "CourseList";
            this.CourseList.Size = new System.Drawing.Size(179, 93);
            this.CourseList.TabIndex = 0;
            // 
            // studentCourseBindingSource
            // 
            this.studentCourseBindingSource.DataMember = "StudentCourse";
            this.studentCourseBindingSource.DataSource = this.cSE_DEPTDataSet;
            // 
            // Label3
            // 
            this.Label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.Location = new System.Drawing.Point(6, 50);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(80, 20);
            this.Label3.TabIndex = 2;
            this.Label3.Text = "School Year";
            this.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtID
            // 
            this.txtID.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.studentBindingSource, "student_id", true));
            this.txtID.Location = new System.Drawing.Point(83, 24);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(161, 20);
            this.txtID.TabIndex = 1;
            // 
            // Label1
            // 
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.Location = new System.Drawing.Point(6, 29);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(96, 16);
            this.Label1.TabIndex = 0;
            this.Label1.Text = "Student Name";
            this.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // StudentNameBox
            // 
            this.StudentNameBox.Controls.Add(this.ComboMethod);
            this.StudentNameBox.Controls.Add(this.label8);
            this.StudentNameBox.Controls.Add(this.ComboName);
            this.StudentNameBox.Controls.Add(this.Label1);
            this.StudentNameBox.Location = new System.Drawing.Point(12, 12);
            this.StudentNameBox.Name = "StudentNameBox";
            this.StudentNameBox.Size = new System.Drawing.Size(237, 82);
            this.StudentNameBox.TabIndex = 0;
            this.StudentNameBox.TabStop = false;
            this.StudentNameBox.Text = "Name and Method";
            // 
            // ComboMethod
            // 
            this.ComboMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboMethod.FormattingEnabled = true;
            this.ComboMethod.Location = new System.Drawing.Point(104, 51);
            this.ComboMethod.Name = "ComboMethod";
            this.ComboMethod.Size = new System.Drawing.Size(127, 21);
            this.ComboMethod.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(6, 54);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(96, 16);
            this.label8.TabIndex = 2;
            this.label8.Text = "Query Method";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // ComboName
            // 
            this.ComboName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboName.FormattingEnabled = true;
            this.ComboName.Location = new System.Drawing.Point(104, 24);
            this.ComboName.Name = "ComboName";
            this.ComboName.Size = new System.Drawing.Size(127, 21);
            this.ComboName.TabIndex = 1;
            // 
            // PhotoBox
            // 
            this.PhotoBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PhotoBox.Location = new System.Drawing.Point(39, 100);
            this.PhotoBox.Name = "PhotoBox";
            this.PhotoBox.Size = new System.Drawing.Size(173, 196);
            this.PhotoBox.TabIndex = 37;
            this.PhotoBox.TabStop = false;
            // 
            // StudentInfoBox
            // 
            this.StudentInfoBox.Controls.Add(this.txtSchoolYear);
            this.StudentInfoBox.Controls.Add(this.txtEmail);
            this.StudentInfoBox.Controls.Add(this.Label6);
            this.StudentInfoBox.Controls.Add(this.Label5);
            this.StudentInfoBox.Controls.Add(this.Label4);
            this.StudentInfoBox.Controls.Add(this.Label3);
            this.StudentInfoBox.Controls.Add(this.Label2);
            this.StudentInfoBox.Controls.Add(this.txtCredits);
            this.StudentInfoBox.Controls.Add(this.txtMajor);
            this.StudentInfoBox.Controls.Add(this.txtGPA);
            this.StudentInfoBox.Controls.Add(this.txtID);
            this.StudentInfoBox.Controls.Add(this.Label7);
            this.StudentInfoBox.Location = new System.Drawing.Point(259, 148);
            this.StudentInfoBox.Name = "StudentInfoBox";
            this.StudentInfoBox.Size = new System.Drawing.Size(250, 192);
            this.StudentInfoBox.TabIndex = 2;
            this.StudentInfoBox.TabStop = false;
            this.StudentInfoBox.Text = "Student Information";
            // 
            // txtSchoolYear
            // 
            this.txtSchoolYear.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.studentBindingSource, "schoolYear", true));
            this.txtSchoolYear.Location = new System.Drawing.Point(83, 50);
            this.txtSchoolYear.Name = "txtSchoolYear";
            this.txtSchoolYear.Size = new System.Drawing.Size(162, 20);
            this.txtSchoolYear.TabIndex = 3;
            // 
            // Label2
            // 
            this.Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.Location = new System.Drawing.Point(6, 24);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(71, 20);
            this.Label2.TabIndex = 0;
            this.Label2.Text = "Student ID";
            this.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtCredits
            // 
            this.txtCredits.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.studentBindingSource, "credits", true));
            this.txtCredits.Location = new System.Drawing.Point(83, 128);
            this.txtCredits.Name = "txtCredits";
            this.txtCredits.Size = new System.Drawing.Size(162, 20);
            this.txtCredits.TabIndex = 9;
            // 
            // txtMajor
            // 
            this.txtMajor.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.studentBindingSource, "major", true));
            this.txtMajor.Location = new System.Drawing.Point(83, 102);
            this.txtMajor.Name = "txtMajor";
            this.txtMajor.Size = new System.Drawing.Size(162, 20);
            this.txtMajor.TabIndex = 7;
            // 
            // txtGPA
            // 
            this.txtGPA.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.studentBindingSource, "gpa", true));
            this.txtGPA.Location = new System.Drawing.Point(83, 76);
            this.txtGPA.Name = "txtGPA";
            this.txtGPA.Size = new System.Drawing.Size(162, 20);
            this.txtGPA.TabIndex = 5;
            // 
            // Label7
            // 
            this.Label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label7.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Label7.Location = new System.Drawing.Point(6, 155);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(80, 16);
            this.Label7.TabIndex = 10;
            this.Label7.Text = "Email";
            this.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmdInsert
            // 
            this.cmdInsert.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdInsert.Location = new System.Drawing.Point(99, 316);
            this.cmdInsert.Name = "cmdInsert";
            this.cmdInsert.Size = new System.Drawing.Size(69, 24);
            this.cmdInsert.TabIndex = 4;
            this.cmdInsert.Text = "Insert";
            // 
            // cmdSelect
            // 
            this.cmdSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSelect.Location = new System.Drawing.Point(19, 316);
            this.cmdSelect.Name = "cmdSelect";
            this.cmdSelect.Size = new System.Drawing.Size(69, 24);
            this.cmdSelect.TabIndex = 3;
            this.cmdSelect.Text = "Select";
            this.cmdSelect.Click += new System.EventHandler(this.cmdSelect_Click);
            // 
            // CourseSelectedBox
            // 
            this.CourseSelectedBox.Controls.Add(this.CourseList);
            this.CourseSelectedBox.Location = new System.Drawing.Point(259, 12);
            this.CourseSelectedBox.Name = "CourseSelectedBox";
            this.CourseSelectedBox.Size = new System.Drawing.Size(250, 128);
            this.CourseSelectedBox.TabIndex = 1;
            this.CourseSelectedBox.TabStop = false;
            this.CourseSelectedBox.Text = "Course Selected";
            // 
            // cmdBack
            // 
            this.cmdBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdBack.Location = new System.Drawing.Point(179, 316);
            this.cmdBack.Name = "cmdBack";
            this.cmdBack.Size = new System.Drawing.Size(69, 24);
            this.cmdBack.TabIndex = 5;
            this.cmdBack.Text = "Back";
            this.cmdBack.Click += new System.EventHandler(this.cmdBack_Click);
            // 
            // studentCourseTableAdapter
            // 
            this.studentCourseTableAdapter.ClearBeforeFill = true;
            // 
            // studentTableAdapter
            // 
            this.studentTableAdapter.ClearBeforeFill = true;
            // 
            // StudentForm
            // 
            this.AcceptButton = this.cmdSelect;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(525, 355);
            this.Controls.Add(this.cmdBack);
            this.Controls.Add(this.StudentNameBox);
            this.Controls.Add(this.PhotoBox);
            this.Controls.Add(this.StudentInfoBox);
            this.Controls.Add(this.cmdInsert);
            this.Controls.Add(this.cmdSelect);
            this.Controls.Add(this.CourseSelectedBox);
            this.Name = "StudentForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CSE DEPT Student Form";
            this.Load += new System.EventHandler(this.StudentForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.studentBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cSE_DEPTDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.studentCourseBindingSource)).EndInit();
            this.StudentNameBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PhotoBox)).EndInit();
            this.StudentInfoBox.ResumeLayout(false);
            this.StudentInfoBox.PerformLayout();
            this.CourseSelectedBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.TextBox txtEmail;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.ListBox CourseList;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.TextBox txtID;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.GroupBox StudentNameBox;
        internal System.Windows.Forms.ComboBox ComboName;
        internal System.Windows.Forms.PictureBox PhotoBox;
        internal System.Windows.Forms.GroupBox StudentInfoBox;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.TextBox txtCredits;
        internal System.Windows.Forms.TextBox txtMajor;
        internal System.Windows.Forms.TextBox txtGPA;
        internal System.Windows.Forms.TextBox txtSchoolYear;
        internal System.Windows.Forms.Label Label7;
        internal System.Windows.Forms.Button cmdInsert;
        internal System.Windows.Forms.Button cmdSelect;
        internal System.Windows.Forms.GroupBox CourseSelectedBox;
        internal System.Windows.Forms.Button cmdBack;
        internal System.Windows.Forms.ComboBox ComboMethod;
        internal System.Windows.Forms.Label label8;
        private CSE_DEPTDataSet cSE_DEPTDataSet;
        private System.Windows.Forms.BindingSource studentCourseBindingSource;
        private AccessUpdateDeleteWizard_Project.CSE_DEPTDataSetTableAdapters.StudentCourseTableAdapter studentCourseTableAdapter;
        private System.Windows.Forms.BindingSource studentBindingSource;
        private AccessUpdateDeleteWizard_Project.CSE_DEPTDataSetTableAdapters.StudentTableAdapter studentTableAdapter;

    }
}