namespace WinClientSQLUpdateDelete
{
    partial class CourseForm
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
            this.ScheduleLabel = new System.Windows.Forms.Label();
            this.cmdDelete = new System.Windows.Forms.Button();
            this.CourseTitleLabel = new System.Windows.Forms.Label();
            this.txtEnroll = new System.Windows.Forms.TextBox();
            this.txtCredits = new System.Windows.Forms.TextBox();
            this.CourseInfoBox = new System.Windows.Forms.GroupBox();
            this.txtCourseName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.EnrollLabel = new System.Windows.Forms.Label();
            this.CreditsLabel = new System.Windows.Forms.Label();
            this.ClassRoomLabel = new System.Windows.Forms.Label();
            this.txtClassRoom = new System.Windows.Forms.TextBox();
            this.txtSchedule = new System.Windows.Forms.TextBox();
            this.txtCourseID = new System.Windows.Forms.TextBox();
            this.CourseBox = new System.Windows.Forms.GroupBox();
            this.CourseList = new System.Windows.Forms.ListBox();
            this.cmdSelect = new System.Windows.Forms.Button();
            this.ComboMethod = new System.Windows.Forms.ComboBox();
            this.NameBox = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ComboName = new System.Windows.Forms.ComboBox();
            this.FacultyNameLabel = new System.Windows.Forms.Label();
            this.cmdBack = new System.Windows.Forms.Button();
            this.cmdUpdate = new System.Windows.Forms.Button();
            this.CourseInfoBox.SuspendLayout();
            this.CourseBox.SuspendLayout();
            this.NameBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // ScheduleLabel
            // 
            this.ScheduleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ScheduleLabel.Location = new System.Drawing.Point(6, 75);
            this.ScheduleLabel.Name = "ScheduleLabel";
            this.ScheduleLabel.Size = new System.Drawing.Size(75, 27);
            this.ScheduleLabel.TabIndex = 4;
            this.ScheduleLabel.Text = "Schedule";
            this.ScheduleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmdDelete
            // 
            this.cmdDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdDelete.Location = new System.Drawing.Point(356, 62);
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.Size = new System.Drawing.Size(76, 23);
            this.cmdDelete.TabIndex = 4;
            this.cmdDelete.Text = "Delete";
            this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
            // 
            // CourseTitleLabel
            // 
            this.CourseTitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CourseTitleLabel.Location = new System.Drawing.Point(6, 30);
            this.CourseTitleLabel.Name = "CourseTitleLabel";
            this.CourseTitleLabel.Size = new System.Drawing.Size(75, 20);
            this.CourseTitleLabel.TabIndex = 0;
            this.CourseTitleLabel.Text = "Course ID";
            this.CourseTitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtEnroll
            // 
            this.txtEnroll.Location = new System.Drawing.Point(99, 156);
            this.txtEnroll.Name = "txtEnroll";
            this.txtEnroll.Size = new System.Drawing.Size(189, 20);
            this.txtEnroll.TabIndex = 11;
            // 
            // txtCredits
            // 
            this.txtCredits.Location = new System.Drawing.Point(99, 131);
            this.txtCredits.Name = "txtCredits";
            this.txtCredits.Size = new System.Drawing.Size(189, 20);
            this.txtCredits.TabIndex = 9;
            // 
            // CourseInfoBox
            // 
            this.CourseInfoBox.Controls.Add(this.txtCourseName);
            this.CourseInfoBox.Controls.Add(this.label2);
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
            this.CourseInfoBox.Location = new System.Drawing.Point(181, 118);
            this.CourseInfoBox.Name = "CourseInfoBox";
            this.CourseInfoBox.Size = new System.Drawing.Size(294, 188);
            this.CourseInfoBox.TabIndex = 2;
            this.CourseInfoBox.TabStop = false;
            this.CourseInfoBox.Text = "Course Information";
            // 
            // txtCourseName
            // 
            this.txtCourseName.Location = new System.Drawing.Point(98, 56);
            this.txtCourseName.Name = "txtCourseName";
            this.txtCourseName.Size = new System.Drawing.Size(189, 20);
            this.txtCourseName.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Course Name";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // EnrollLabel
            // 
            this.EnrollLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EnrollLabel.Location = new System.Drawing.Point(6, 152);
            this.EnrollLabel.Name = "EnrollLabel";
            this.EnrollLabel.Size = new System.Drawing.Size(75, 27);
            this.EnrollLabel.TabIndex = 10;
            this.EnrollLabel.Text = "Enrollment";
            this.EnrollLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CreditsLabel
            // 
            this.CreditsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreditsLabel.Location = new System.Drawing.Point(6, 127);
            this.CreditsLabel.Name = "CreditsLabel";
            this.CreditsLabel.Size = new System.Drawing.Size(75, 27);
            this.CreditsLabel.TabIndex = 8;
            this.CreditsLabel.Text = "Credits";
            this.CreditsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ClassRoomLabel
            // 
            this.ClassRoomLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClassRoomLabel.Location = new System.Drawing.Point(6, 101);
            this.ClassRoomLabel.Name = "ClassRoomLabel";
            this.ClassRoomLabel.Size = new System.Drawing.Size(75, 27);
            this.ClassRoomLabel.TabIndex = 6;
            this.ClassRoomLabel.Text = "Classroom";
            this.ClassRoomLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtClassRoom
            // 
            this.txtClassRoom.Location = new System.Drawing.Point(99, 106);
            this.txtClassRoom.Name = "txtClassRoom";
            this.txtClassRoom.Size = new System.Drawing.Size(189, 20);
            this.txtClassRoom.TabIndex = 7;
            // 
            // txtSchedule
            // 
            this.txtSchedule.Location = new System.Drawing.Point(99, 81);
            this.txtSchedule.Name = "txtSchedule";
            this.txtSchedule.Size = new System.Drawing.Size(189, 20);
            this.txtSchedule.TabIndex = 5;
            // 
            // txtCourseID
            // 
            this.txtCourseID.Location = new System.Drawing.Point(99, 31);
            this.txtCourseID.Name = "txtCourseID";
            this.txtCourseID.Size = new System.Drawing.Size(189, 20);
            this.txtCourseID.TabIndex = 1;
            // 
            // CourseBox
            // 
            this.CourseBox.Controls.Add(this.CourseList);
            this.CourseBox.Location = new System.Drawing.Point(12, 108);
            this.CourseBox.Name = "CourseBox";
            this.CourseBox.Size = new System.Drawing.Size(153, 196);
            this.CourseBox.TabIndex = 1;
            this.CourseBox.TabStop = false;
            this.CourseBox.Text = "Course List";
            // 
            // CourseList
            // 
            this.CourseList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CourseList.Location = new System.Drawing.Point(6, 19);
            this.CourseList.Name = "CourseList";
            this.CourseList.Size = new System.Drawing.Size(134, 158);
            this.CourseList.TabIndex = 0;
            this.CourseList.SelectedIndexChanged += new System.EventHandler(this.CourseList_SelectedIndexChanged);
            // 
            // cmdSelect
            // 
            this.cmdSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSelect.Location = new System.Drawing.Point(356, 12);
            this.cmdSelect.Name = "cmdSelect";
            this.cmdSelect.Size = new System.Drawing.Size(76, 23);
            this.cmdSelect.TabIndex = 3;
            this.cmdSelect.Text = "Select";
            this.cmdSelect.Click += new System.EventHandler(this.cmdSelect_Click);
            // 
            // ComboMethod
            // 
            this.ComboMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboMethod.FormattingEnabled = true;
            this.ComboMethod.Location = new System.Drawing.Point(103, 47);
            this.ComboMethod.Name = "ComboMethod";
            this.ComboMethod.Size = new System.Drawing.Size(152, 21);
            this.ComboMethod.TabIndex = 3;
            // 
            // NameBox
            // 
            this.NameBox.Controls.Add(this.ComboMethod);
            this.NameBox.Controls.Add(this.label1);
            this.NameBox.Controls.Add(this.ComboName);
            this.NameBox.Controls.Add(this.FacultyNameLabel);
            this.NameBox.Location = new System.Drawing.Point(12, 12);
            this.NameBox.Name = "NameBox";
            this.NameBox.Size = new System.Drawing.Size(297, 80);
            this.NameBox.TabIndex = 0;
            this.NameBox.TabStop = false;
            this.NameBox.Text = "Name and Method";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 2;
            this.label1.Text = "Query Method";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // ComboName
            // 
            this.ComboName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboName.FormattingEnabled = true;
            this.ComboName.Location = new System.Drawing.Point(103, 20);
            this.ComboName.Name = "ComboName";
            this.ComboName.Size = new System.Drawing.Size(152, 21);
            this.ComboName.TabIndex = 1;
            // 
            // FacultyNameLabel
            // 
            this.FacultyNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FacultyNameLabel.Location = new System.Drawing.Point(6, 23);
            this.FacultyNameLabel.Name = "FacultyNameLabel";
            this.FacultyNameLabel.Size = new System.Drawing.Size(100, 23);
            this.FacultyNameLabel.TabIndex = 0;
            this.FacultyNameLabel.Text = "Faculty Name";
            this.FacultyNameLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // cmdBack
            // 
            this.cmdBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdBack.Location = new System.Drawing.Point(356, 87);
            this.cmdBack.Name = "cmdBack";
            this.cmdBack.Size = new System.Drawing.Size(76, 23);
            this.cmdBack.TabIndex = 6;
            this.cmdBack.Text = "Back";
            this.cmdBack.Click += new System.EventHandler(this.cmdBack_Click);
            // 
            // cmdUpdate
            // 
            this.cmdUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdUpdate.Location = new System.Drawing.Point(356, 37);
            this.cmdUpdate.Name = "cmdUpdate";
            this.cmdUpdate.Size = new System.Drawing.Size(76, 23);
            this.cmdUpdate.TabIndex = 5;
            this.cmdUpdate.Text = "Update";
            this.cmdUpdate.Click += new System.EventHandler(this.cmdUpdate_Click);
            // 
            // CourseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 318);
            this.Controls.Add(this.cmdUpdate);
            this.Controls.Add(this.cmdDelete);
            this.Controls.Add(this.CourseInfoBox);
            this.Controls.Add(this.CourseBox);
            this.Controls.Add(this.cmdSelect);
            this.Controls.Add(this.NameBox);
            this.Controls.Add(this.cmdBack);
            this.Name = "CourseForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CSE DEPT Course Form ";
            this.CourseInfoBox.ResumeLayout(false);
            this.CourseInfoBox.PerformLayout();
            this.CourseBox.ResumeLayout(false);
            this.NameBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Label ScheduleLabel;
        internal System.Windows.Forms.Button cmdDelete;
        internal System.Windows.Forms.Label CourseTitleLabel;
        internal System.Windows.Forms.TextBox txtEnroll;
        internal System.Windows.Forms.TextBox txtCredits;
        internal System.Windows.Forms.GroupBox CourseInfoBox;
        internal System.Windows.Forms.Label EnrollLabel;
        internal System.Windows.Forms.Label CreditsLabel;
        internal System.Windows.Forms.Label ClassRoomLabel;
        internal System.Windows.Forms.TextBox txtClassRoom;
        internal System.Windows.Forms.TextBox txtSchedule;
        internal System.Windows.Forms.TextBox txtCourseID;
        internal System.Windows.Forms.GroupBox CourseBox;
        internal System.Windows.Forms.ListBox CourseList;
        internal System.Windows.Forms.Button cmdSelect;
        internal System.Windows.Forms.ComboBox ComboMethod;
        internal System.Windows.Forms.GroupBox NameBox;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.ComboBox ComboName;
        internal System.Windows.Forms.Label FacultyNameLabel;
        internal System.Windows.Forms.Button cmdBack;
        internal System.Windows.Forms.TextBox txtCourseName;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.Button cmdUpdate;
    }
}

