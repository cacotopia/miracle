namespace SampleWizards_Project
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
            this.components = new System.ComponentModel.Container();
            this.cmdDelete = new System.Windows.Forms.Button();
            this.FacultyNameLabel = new System.Windows.Forms.Label();
            this.cmdInsert = new System.Windows.Forms.Button();
            this.cmdSelect = new System.Windows.Forms.Button();
            this.cmdUpdate = new System.Windows.Forms.Button();
            this.EmailLabel = new System.Windows.Forms.Label();
            this.facultyBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cSE_DEPTDataSet = new SampleWizards_Project.CSE_DEPTDataSet();
            this.PhotoBox = new System.Windows.Forms.PictureBox();
            this.FacultyBox = new System.Windows.Forms.GroupBox();
            this.ComboMethod = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ComboName = new System.Windows.Forms.ComboBox();
            this.CollegeLabel = new System.Windows.Forms.Label();
            this.PhoneLabel = new System.Windows.Forms.Label();
            this.TitleLabel = new System.Windows.Forms.Label();
            this.OfficeLabel = new System.Windows.Forms.Label();
            this.cmdBack = new System.Windows.Forms.Button();
            this.FacultyInfoBox = new System.Windows.Forms.GroupBox();
            this.facultyTableAdapter = new SampleWizards_Project.CSE_DEPTDataSetTableAdapters.FacultyTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.facultyBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cSE_DEPTDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PhotoBox)).BeginInit();
            this.FacultyBox.SuspendLayout();
            this.FacultyInfoBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdDelete
            // 
            this.cmdDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdDelete.Location = new System.Drawing.Point(312, 243);
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.Size = new System.Drawing.Size(80, 32);
            this.cmdDelete.TabIndex = 36;
            this.cmdDelete.Text = "Delete";
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
            // cmdInsert
            // 
            this.cmdInsert.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdInsert.Location = new System.Drawing.Point(118, 243);
            this.cmdInsert.Name = "cmdInsert";
            this.cmdInsert.Size = new System.Drawing.Size(80, 32);
            this.cmdInsert.TabIndex = 34;
            this.cmdInsert.Text = "Insert";
            // 
            // cmdSelect
            // 
            this.cmdSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSelect.Location = new System.Drawing.Point(21, 243);
            this.cmdSelect.Name = "cmdSelect";
            this.cmdSelect.Size = new System.Drawing.Size(80, 32);
            this.cmdSelect.TabIndex = 33;
            this.cmdSelect.Text = "Select";
            this.cmdSelect.Click += new System.EventHandler(this.cmdSelect_Click);
            // 
            // cmdUpdate
            // 
            this.cmdUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdUpdate.Location = new System.Drawing.Point(215, 243);
            this.cmdUpdate.Name = "cmdUpdate";
            this.cmdUpdate.Size = new System.Drawing.Size(80, 32);
            this.cmdUpdate.TabIndex = 35;
            this.cmdUpdate.Text = "Update";
            // 
            // EmailLabel
            // 
            this.EmailLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.EmailLabel.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.facultyBindingSource, "email", true));
            this.EmailLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EmailLabel.Location = new System.Drawing.Point(16, 113);
            this.EmailLabel.Name = "EmailLabel";
            this.EmailLabel.Size = new System.Drawing.Size(228, 16);
            this.EmailLabel.TabIndex = 4;
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
            // PhotoBox
            // 
            this.PhotoBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PhotoBox.Location = new System.Drawing.Point(21, 27);
            this.PhotoBox.Name = "PhotoBox";
            this.PhotoBox.Size = new System.Drawing.Size(171, 179);
            this.PhotoBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PhotoBox.TabIndex = 38;
            this.PhotoBox.TabStop = false;
            // 
            // FacultyBox
            // 
            this.FacultyBox.Controls.Add(this.ComboMethod);
            this.FacultyBox.Controls.Add(this.label1);
            this.FacultyBox.Controls.Add(this.ComboName);
            this.FacultyBox.Controls.Add(this.FacultyNameLabel);
            this.FacultyBox.Location = new System.Drawing.Point(233, 12);
            this.FacultyBox.Name = "FacultyBox";
            this.FacultyBox.Size = new System.Drawing.Size(264, 76);
            this.FacultyBox.TabIndex = 31;
            this.FacultyBox.TabStop = false;
            this.FacultyBox.Text = "Faculty Name";
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
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Query Method";
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
            // CollegeLabel
            // 
            this.CollegeLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.CollegeLabel.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.facultyBindingSource, "college", true));
            this.CollegeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CollegeLabel.Location = new System.Drawing.Point(16, 88);
            this.CollegeLabel.Name = "CollegeLabel";
            this.CollegeLabel.Size = new System.Drawing.Size(228, 16);
            this.CollegeLabel.TabIndex = 3;
            // 
            // PhoneLabel
            // 
            this.PhoneLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PhoneLabel.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.facultyBindingSource, "phone", true));
            this.PhoneLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PhoneLabel.Location = new System.Drawing.Point(16, 69);
            this.PhoneLabel.Name = "PhoneLabel";
            this.PhoneLabel.Size = new System.Drawing.Size(228, 16);
            this.PhoneLabel.TabIndex = 2;
            // 
            // TitleLabel
            // 
            this.TitleLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.TitleLabel.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.facultyBindingSource, "title", true));
            this.TitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleLabel.Location = new System.Drawing.Point(16, 25);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(228, 16);
            this.TitleLabel.TabIndex = 0;
            // 
            // OfficeLabel
            // 
            this.OfficeLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.OfficeLabel.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.facultyBindingSource, "office", true));
            this.OfficeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OfficeLabel.Location = new System.Drawing.Point(16, 47);
            this.OfficeLabel.Name = "OfficeLabel";
            this.OfficeLabel.Size = new System.Drawing.Size(228, 16);
            this.OfficeLabel.TabIndex = 1;
            // 
            // cmdBack
            // 
            this.cmdBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdBack.Location = new System.Drawing.Point(409, 243);
            this.cmdBack.Name = "cmdBack";
            this.cmdBack.Size = new System.Drawing.Size(88, 32);
            this.cmdBack.TabIndex = 37;
            this.cmdBack.Text = "Back";
            this.cmdBack.Click += new System.EventHandler(this.cmdBack_Click);
            // 
            // FacultyInfoBox
            // 
            this.FacultyInfoBox.Controls.Add(this.EmailLabel);
            this.FacultyInfoBox.Controls.Add(this.CollegeLabel);
            this.FacultyInfoBox.Controls.Add(this.PhoneLabel);
            this.FacultyInfoBox.Controls.Add(this.OfficeLabel);
            this.FacultyInfoBox.Controls.Add(this.TitleLabel);
            this.FacultyInfoBox.Location = new System.Drawing.Point(233, 94);
            this.FacultyInfoBox.Name = "FacultyInfoBox";
            this.FacultyInfoBox.Size = new System.Drawing.Size(264, 143);
            this.FacultyInfoBox.TabIndex = 32;
            this.FacultyInfoBox.TabStop = false;
            this.FacultyInfoBox.Text = "Faculty Information";
            // 
            // facultyTableAdapter
            // 
            this.facultyTableAdapter.ClearBeforeFill = true;
            // 
            // FacultyForm
            // 
            this.AcceptButton = this.cmdSelect;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(521, 295);
            this.Controls.Add(this.cmdDelete);
            this.Controls.Add(this.cmdInsert);
            this.Controls.Add(this.cmdSelect);
            this.Controls.Add(this.cmdUpdate);
            this.Controls.Add(this.PhotoBox);
            this.Controls.Add(this.FacultyBox);
            this.Controls.Add(this.cmdBack);
            this.Controls.Add(this.FacultyInfoBox);
            this.Name = "FacultyForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CSE DEPT Faculty Form";
            this.Load += new System.EventHandler(this.FacultyForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.facultyBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cSE_DEPTDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PhotoBox)).EndInit();
            this.FacultyBox.ResumeLayout(false);
            this.FacultyInfoBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Button cmdDelete;
        internal System.Windows.Forms.Label FacultyNameLabel;
        internal System.Windows.Forms.Button cmdInsert;
        internal System.Windows.Forms.Button cmdSelect;
        internal System.Windows.Forms.Button cmdUpdate;
        internal System.Windows.Forms.Label EmailLabel;
        internal System.Windows.Forms.PictureBox PhotoBox;
        internal System.Windows.Forms.GroupBox FacultyBox;
        internal System.Windows.Forms.ComboBox ComboName;
        internal System.Windows.Forms.Label CollegeLabel;
        internal System.Windows.Forms.Label PhoneLabel;
        internal System.Windows.Forms.Label TitleLabel;
        internal System.Windows.Forms.Label OfficeLabel;
        internal System.Windows.Forms.Button cmdBack;
        internal System.Windows.Forms.GroupBox FacultyInfoBox;
        private CSE_DEPTDataSet cSE_DEPTDataSet;
        private System.Windows.Forms.BindingSource facultyBindingSource;
        private SampleWizards_Project.CSE_DEPTDataSetTableAdapters.FacultyTableAdapter facultyTableAdapter;
        internal System.Windows.Forms.ComboBox ComboMethod;
        internal System.Windows.Forms.Label label1;
    }
}