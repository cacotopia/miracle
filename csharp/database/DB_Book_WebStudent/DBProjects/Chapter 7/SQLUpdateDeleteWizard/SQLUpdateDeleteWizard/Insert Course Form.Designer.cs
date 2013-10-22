namespace SQLUpdateDeleteWizard
{
    partial class InsertCourseForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InsertCourseForm));
            this.ComboMethod = new System.Windows.Forms.ComboBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label9 = new System.Windows.Forms.Label();
            this.cmdSelect = new System.Windows.Forms.Button();
            this.txtCourse = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdInsert = new System.Windows.Forms.Button();
            this.txtFacultyID = new System.Windows.Forms.TextBox();
            this.facultyBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cSE_DEPTDataSet = new SQLUpdateDeleteWizard.CSE_DEPTDataSet();
            this.EnrollLabel = new System.Windows.Forms.Label();
            this.CourseInfoBox = new System.Windows.Forms.GroupBox();
            this.CreditsLabel = new System.Windows.Forms.Label();
            this.ClassRoomLabel = new System.Windows.Forms.Label();
            this.ScheduleLabel = new System.Windows.Forms.Label();
            this.CourseTitleLabel = new System.Windows.Forms.Label();
            this.txtEnroll = new System.Windows.Forms.TextBox();
            this.txtCredits = new System.Windows.Forms.TextBox();
            this.txtClassRoom = new System.Windows.Forms.TextBox();
            this.txtSchedule = new System.Windows.Forms.TextBox();
            this.txtCourseID = new System.Windows.Forms.TextBox();
            this.courseBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.PictureBox1 = new System.Windows.Forms.PictureBox();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.ComboName = new System.Windows.Forms.ComboBox();
            this.FacultyNameLabel = new System.Windows.Forms.Label();
            this.cmdBack = new System.Windows.Forms.Button();
            this.facultyTableAdapter = new SQLUpdateDeleteWizard.CSE_DEPTDataSetTableAdapters.FacultyTableAdapter();
            this.courseTableAdapter = new SQLUpdateDeleteWizard.CSE_DEPTDataSetTableAdapters.CourseTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.facultyBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cSE_DEPTDataSet)).BeginInit();
            this.CourseInfoBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.courseBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
            this.GroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ComboMethod
            // 
            this.ComboMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboMethod.FormattingEnabled = true;
            this.ComboMethod.Location = new System.Drawing.Point(94, 19);
            this.ComboMethod.Name = "ComboMethod";
            this.ComboMethod.Size = new System.Drawing.Size(152, 21);
            this.ComboMethod.TabIndex = 1;
            // 
            // Label2
            // 
            this.Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.Location = new System.Drawing.Point(13, 72);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(75, 20);
            this.Label2.TabIndex = 4;
            this.Label2.Text = "Course Title";
            this.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label9
            // 
            this.Label9.AutoSize = true;
            this.Label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label9.Location = new System.Drawing.Point(6, 22);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(85, 13);
            this.Label9.TabIndex = 0;
            this.Label9.Text = "Insert Method";
            // 
            // cmdSelect
            // 
            this.cmdSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSelect.Location = new System.Drawing.Point(295, 161);
            this.cmdSelect.Name = "cmdSelect";
            this.cmdSelect.Size = new System.Drawing.Size(73, 31);
            this.cmdSelect.TabIndex = 3;
            this.cmdSelect.Text = "Select";
            this.cmdSelect.UseVisualStyleBackColor = true;
            // 
            // txtCourse
            // 
            this.txtCourse.Location = new System.Drawing.Point(94, 72);
            this.txtCourse.Name = "txtCourse";
            this.txtCourse.Size = new System.Drawing.Size(152, 20);
            this.txtCourse.TabIndex = 5;
            // 
            // Label1
            // 
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.Location = new System.Drawing.Point(13, 20);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(75, 20);
            this.Label1.TabIndex = 0;
            this.Label1.Text = "Faculty ID";
            this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmdCancel
            // 
            this.cmdCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdCancel.Location = new System.Drawing.Point(295, 198);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(73, 31);
            this.cmdCancel.TabIndex = 4;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cmdInsert
            // 
            this.cmdInsert.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdInsert.Location = new System.Drawing.Point(295, 124);
            this.cmdInsert.Name = "cmdInsert";
            this.cmdInsert.Size = new System.Drawing.Size(73, 31);
            this.cmdInsert.TabIndex = 2;
            this.cmdInsert.Text = "Insert";
            this.cmdInsert.UseVisualStyleBackColor = true;
            this.cmdInsert.Click += new System.EventHandler(this.cmdInsert_Click);
            // 
            // txtFacultyID
            // 
            this.txtFacultyID.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.facultyBindingSource, "faculty_id", true));
            this.txtFacultyID.Location = new System.Drawing.Point(94, 21);
            this.txtFacultyID.Name = "txtFacultyID";
            this.txtFacultyID.Size = new System.Drawing.Size(152, 20);
            this.txtFacultyID.TabIndex = 1;
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
            // EnrollLabel
            // 
            this.EnrollLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EnrollLabel.Location = new System.Drawing.Point(13, 171);
            this.EnrollLabel.Name = "EnrollLabel";
            this.EnrollLabel.Size = new System.Drawing.Size(75, 27);
            this.EnrollLabel.TabIndex = 12;
            this.EnrollLabel.Text = "Enrollment";
            this.EnrollLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CourseInfoBox
            // 
            this.CourseInfoBox.Controls.Add(this.Label2);
            this.CourseInfoBox.Controls.Add(this.txtCourse);
            this.CourseInfoBox.Controls.Add(this.Label1);
            this.CourseInfoBox.Controls.Add(this.txtFacultyID);
            this.CourseInfoBox.Controls.Add(this.EnrollLabel);
            this.CourseInfoBox.Controls.Add(this.CreditsLabel);
            this.CourseInfoBox.Controls.Add(this.ClassRoomLabel);
            this.CourseInfoBox.Controls.Add(this.ScheduleLabel);
            this.CourseInfoBox.Controls.Add(this.CourseTitleLabel);
            this.CourseInfoBox.Controls.Add(this.txtEnroll);
            this.CourseInfoBox.Controls.Add(this.txtCredits);
            this.CourseInfoBox.Controls.Add(this.txtClassRoom);
            this.CourseInfoBox.Controls.Add(this.txtSchedule);
            this.CourseInfoBox.Controls.Add(this.txtCourseID);
            this.CourseInfoBox.Location = new System.Drawing.Point(12, 88);
            this.CourseInfoBox.Name = "CourseInfoBox";
            this.CourseInfoBox.Size = new System.Drawing.Size(258, 202);
            this.CourseInfoBox.TabIndex = 1;
            this.CourseInfoBox.TabStop = false;
            this.CourseInfoBox.Text = "New Course Information";
            // 
            // CreditsLabel
            // 
            this.CreditsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreditsLabel.Location = new System.Drawing.Point(13, 145);
            this.CreditsLabel.Name = "CreditsLabel";
            this.CreditsLabel.Size = new System.Drawing.Size(75, 27);
            this.CreditsLabel.TabIndex = 10;
            this.CreditsLabel.Text = "Credits";
            this.CreditsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ClassRoomLabel
            // 
            this.ClassRoomLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClassRoomLabel.Location = new System.Drawing.Point(13, 118);
            this.ClassRoomLabel.Name = "ClassRoomLabel";
            this.ClassRoomLabel.Size = new System.Drawing.Size(75, 27);
            this.ClassRoomLabel.TabIndex = 8;
            this.ClassRoomLabel.Text = "Classroom";
            this.ClassRoomLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ScheduleLabel
            // 
            this.ScheduleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ScheduleLabel.Location = new System.Drawing.Point(13, 94);
            this.ScheduleLabel.Name = "ScheduleLabel";
            this.ScheduleLabel.Size = new System.Drawing.Size(75, 27);
            this.ScheduleLabel.TabIndex = 6;
            this.ScheduleLabel.Text = "Schedule";
            this.ScheduleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CourseTitleLabel
            // 
            this.CourseTitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CourseTitleLabel.Location = new System.Drawing.Point(13, 48);
            this.CourseTitleLabel.Name = "CourseTitleLabel";
            this.CourseTitleLabel.Size = new System.Drawing.Size(75, 20);
            this.CourseTitleLabel.TabIndex = 2;
            this.CourseTitleLabel.Text = "Course ID";
            this.CourseTitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtEnroll
            // 
            this.txtEnroll.Location = new System.Drawing.Point(94, 175);
            this.txtEnroll.Name = "txtEnroll";
            this.txtEnroll.Size = new System.Drawing.Size(152, 20);
            this.txtEnroll.TabIndex = 13;
            // 
            // txtCredits
            // 
            this.txtCredits.Location = new System.Drawing.Point(94, 149);
            this.txtCredits.Name = "txtCredits";
            this.txtCredits.Size = new System.Drawing.Size(152, 20);
            this.txtCredits.TabIndex = 11;
            // 
            // txtClassRoom
            // 
            this.txtClassRoom.Location = new System.Drawing.Point(94, 123);
            this.txtClassRoom.Name = "txtClassRoom";
            this.txtClassRoom.Size = new System.Drawing.Size(152, 20);
            this.txtClassRoom.TabIndex = 9;
            // 
            // txtSchedule
            // 
            this.txtSchedule.Location = new System.Drawing.Point(94, 98);
            this.txtSchedule.Name = "txtSchedule";
            this.txtSchedule.Size = new System.Drawing.Size(152, 20);
            this.txtSchedule.TabIndex = 7;
            // 
            // txtCourseID
            // 
            this.txtCourseID.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.courseBindingSource, "course_id", true));
            this.txtCourseID.Location = new System.Drawing.Point(94, 47);
            this.txtCourseID.Name = "txtCourseID";
            this.txtCourseID.Size = new System.Drawing.Size(152, 20);
            this.txtCourseID.TabIndex = 3;
            this.txtCourseID.TextChanged += new System.EventHandler(this.txtCourseID_TextChanged);
            // 
            // courseBindingSource
            // 
            this.courseBindingSource.DataMember = "Course";
            this.courseBindingSource.DataSource = this.cSE_DEPTDataSet;
            // 
            // PictureBox1
            // 
            this.PictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("PictureBox1.Image")));
            this.PictureBox1.Location = new System.Drawing.Point(300, 23);
            this.PictureBox1.Name = "PictureBox1";
            this.PictureBox1.Size = new System.Drawing.Size(54, 48);
            this.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureBox1.TabIndex = 17;
            this.PictureBox1.TabStop = false;
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.ComboMethod);
            this.GroupBox1.Controls.Add(this.Label9);
            this.GroupBox1.Controls.Add(this.ComboName);
            this.GroupBox1.Controls.Add(this.FacultyNameLabel);
            this.GroupBox1.Location = new System.Drawing.Point(12, 12);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(257, 70);
            this.GroupBox1.TabIndex = 0;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Method and Faculty Information";
            // 
            // ComboName
            // 
            this.ComboName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboName.FormattingEnabled = true;
            this.ComboName.Location = new System.Drawing.Point(94, 43);
            this.ComboName.Name = "ComboName";
            this.ComboName.Size = new System.Drawing.Size(152, 21);
            this.ComboName.TabIndex = 3;
            // 
            // FacultyNameLabel
            // 
            this.FacultyNameLabel.AutoSize = true;
            this.FacultyNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FacultyNameLabel.Location = new System.Drawing.Point(7, 46);
            this.FacultyNameLabel.Name = "FacultyNameLabel";
            this.FacultyNameLabel.Size = new System.Drawing.Size(84, 13);
            this.FacultyNameLabel.TabIndex = 2;
            this.FacultyNameLabel.Text = "Faculty Name";
            this.FacultyNameLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // cmdBack
            // 
            this.cmdBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdBack.Location = new System.Drawing.Point(295, 237);
            this.cmdBack.Name = "cmdBack";
            this.cmdBack.Size = new System.Drawing.Size(73, 31);
            this.cmdBack.TabIndex = 5;
            this.cmdBack.Text = "Back";
            this.cmdBack.UseVisualStyleBackColor = true;
            this.cmdBack.Click += new System.EventHandler(this.cmdBack_Click);
            // 
            // facultyTableAdapter
            // 
            this.facultyTableAdapter.ClearBeforeFill = true;
            // 
            // courseTableAdapter
            // 
            this.courseTableAdapter.ClearBeforeFill = true;
            // 
            // InsertCourseForm
            // 
            this.AcceptButton = this.cmdInsert;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(386, 309);
            this.Controls.Add(this.cmdSelect);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdInsert);
            this.Controls.Add(this.CourseInfoBox);
            this.Controls.Add(this.PictureBox1);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.cmdBack);
            this.Name = "InsertCourseForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CSE DEPT Insert Course Form";
            this.Load += new System.EventHandler(this.InsertCourseForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.facultyBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cSE_DEPTDataSet)).EndInit();
            this.CourseInfoBox.ResumeLayout(false);
            this.CourseInfoBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.courseBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.ComboBox ComboMethod;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label9;
        internal System.Windows.Forms.Button cmdSelect;
        internal System.Windows.Forms.TextBox txtCourse;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Button cmdCancel;
        internal System.Windows.Forms.Button cmdInsert;
        internal System.Windows.Forms.TextBox txtFacultyID;
        internal System.Windows.Forms.Label EnrollLabel;
        internal System.Windows.Forms.GroupBox CourseInfoBox;
        internal System.Windows.Forms.Label CreditsLabel;
        internal System.Windows.Forms.Label ClassRoomLabel;
        internal System.Windows.Forms.Label ScheduleLabel;
        internal System.Windows.Forms.Label CourseTitleLabel;
        internal System.Windows.Forms.TextBox txtEnroll;
        internal System.Windows.Forms.TextBox txtCredits;
        internal System.Windows.Forms.TextBox txtClassRoom;
        internal System.Windows.Forms.TextBox txtSchedule;
        internal System.Windows.Forms.TextBox txtCourseID;
        internal System.Windows.Forms.PictureBox PictureBox1;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.ComboBox ComboName;
        internal System.Windows.Forms.Label FacultyNameLabel;
        internal System.Windows.Forms.Button cmdBack;
        private CSE_DEPTDataSet cSE_DEPTDataSet;
        private System.Windows.Forms.BindingSource facultyBindingSource;
        private SQLUpdateDeleteWizard.CSE_DEPTDataSetTableAdapters.FacultyTableAdapter facultyTableAdapter;
        private System.Windows.Forms.BindingSource courseBindingSource;
        private SQLUpdateDeleteWizard.CSE_DEPTDataSetTableAdapters.CourseTableAdapter courseTableAdapter;
    }
}