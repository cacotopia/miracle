namespace SQLInsertWizard
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
            this.PhotoBox = new System.Windows.Forms.PictureBox();
            this.EmailLabel = new System.Windows.Forms.Label();
            this.ComboMethod = new System.Windows.Forms.ComboBox();
            this.TitleLabel = new System.Windows.Forms.Label();
            this.FacultyNameLabel = new System.Windows.Forms.Label();
            this.ComboName = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdDelete = new System.Windows.Forms.Button();
            this.CollegeLabel = new System.Windows.Forms.Label();
            this.cmdInsert = new System.Windows.Forms.Button();
            this.cmdSelect = new System.Windows.Forms.Button();
            this.cmdUpdate = new System.Windows.Forms.Button();
            this.OfficeLabel = new System.Windows.Forms.Label();
            this.cmdBack = new System.Windows.Forms.Button();
            this.PhoneLabel = new System.Windows.Forms.Label();
            this.FacultyInfoBox = new System.Windows.Forms.GroupBox();
            this.FacultyBox = new System.Windows.Forms.GroupBox();
            this.facultyBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cSE_DEPTDataSet = new SQLInsertWizard.CSE_DEPTDataSet();
            this.facultyTableAdapter = new SQLInsertWizard.CSE_DEPTDataSetTableAdapters.FacultyTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.PhotoBox)).BeginInit();
            this.FacultyInfoBox.SuspendLayout();
            this.FacultyBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.facultyBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cSE_DEPTDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // PhotoBox
            // 
            this.PhotoBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PhotoBox.Location = new System.Drawing.Point(15, 27);
            this.PhotoBox.Name = "PhotoBox";
            this.PhotoBox.Size = new System.Drawing.Size(171, 179);
            this.PhotoBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PhotoBox.TabIndex = 54;
            this.PhotoBox.TabStop = false;
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
            // ComboMethod
            // 
            this.ComboMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboMethod.FormattingEnabled = true;
            this.ComboMethod.Location = new System.Drawing.Point(110, 45);
            this.ComboMethod.Name = "ComboMethod";
            this.ComboMethod.Size = new System.Drawing.Size(134, 21);
            this.ComboMethod.TabIndex = 3;
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
            // FacultyNameLabel
            // 
            this.FacultyNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FacultyNameLabel.Location = new System.Drawing.Point(13, 20);
            this.FacultyNameLabel.Name = "FacultyNameLabel";
            this.FacultyNameLabel.Size = new System.Drawing.Size(88, 16);
            this.FacultyNameLabel.TabIndex = 0;
            this.FacultyNameLabel.Text = "Faculty Name";
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
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Query Method";
            // 
            // cmdDelete
            // 
            this.cmdDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdDelete.Location = new System.Drawing.Point(306, 243);
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.Size = new System.Drawing.Size(80, 32);
            this.cmdDelete.TabIndex = 53;
            this.cmdDelete.Text = "Delete";
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
            // cmdInsert
            // 
            this.cmdInsert.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdInsert.Location = new System.Drawing.Point(112, 243);
            this.cmdInsert.Name = "cmdInsert";
            this.cmdInsert.Size = new System.Drawing.Size(80, 32);
            this.cmdInsert.TabIndex = 51;
            this.cmdInsert.Text = "Insert";
            // 
            // cmdSelect
            // 
            this.cmdSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSelect.Location = new System.Drawing.Point(15, 243);
            this.cmdSelect.Name = "cmdSelect";
            this.cmdSelect.Size = new System.Drawing.Size(80, 32);
            this.cmdSelect.TabIndex = 50;
            this.cmdSelect.Text = "Select";
            this.cmdSelect.Click += new System.EventHandler(this.cmdSelect_Click);
            // 
            // cmdUpdate
            // 
            this.cmdUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdUpdate.Location = new System.Drawing.Point(209, 243);
            this.cmdUpdate.Name = "cmdUpdate";
            this.cmdUpdate.Size = new System.Drawing.Size(80, 32);
            this.cmdUpdate.TabIndex = 52;
            this.cmdUpdate.Text = "Update";
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
            this.cmdBack.Location = new System.Drawing.Point(396, 243);
            this.cmdBack.Name = "cmdBack";
            this.cmdBack.Size = new System.Drawing.Size(75, 32);
            this.cmdBack.TabIndex = 55;
            this.cmdBack.Text = "Back";
            this.cmdBack.Click += new System.EventHandler(this.cmdBack_Click);
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
            // FacultyInfoBox
            // 
            this.FacultyInfoBox.Controls.Add(this.EmailLabel);
            this.FacultyInfoBox.Controls.Add(this.CollegeLabel);
            this.FacultyInfoBox.Controls.Add(this.PhoneLabel);
            this.FacultyInfoBox.Controls.Add(this.OfficeLabel);
            this.FacultyInfoBox.Controls.Add(this.TitleLabel);
            this.FacultyInfoBox.Location = new System.Drawing.Point(227, 94);
            this.FacultyInfoBox.Name = "FacultyInfoBox";
            this.FacultyInfoBox.Size = new System.Drawing.Size(264, 143);
            this.FacultyInfoBox.TabIndex = 49;
            this.FacultyInfoBox.TabStop = false;
            this.FacultyInfoBox.Text = "Faculty Information";
            // 
            // FacultyBox
            // 
            this.FacultyBox.Controls.Add(this.ComboMethod);
            this.FacultyBox.Controls.Add(this.label1);
            this.FacultyBox.Controls.Add(this.ComboName);
            this.FacultyBox.Controls.Add(this.FacultyNameLabel);
            this.FacultyBox.Location = new System.Drawing.Point(227, 12);
            this.FacultyBox.Name = "FacultyBox";
            this.FacultyBox.Size = new System.Drawing.Size(264, 76);
            this.FacultyBox.TabIndex = 48;
            this.FacultyBox.TabStop = false;
            this.FacultyBox.Text = "Name and Method";
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
            // FacultyForm
            // 
            this.AcceptButton = this.cmdSelect;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(506, 290);
            this.Controls.Add(this.PhotoBox);
            this.Controls.Add(this.cmdDelete);
            this.Controls.Add(this.cmdInsert);
            this.Controls.Add(this.cmdSelect);
            this.Controls.Add(this.cmdUpdate);
            this.Controls.Add(this.cmdBack);
            this.Controls.Add(this.FacultyInfoBox);
            this.Controls.Add(this.FacultyBox);
            this.Name = "FacultyForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CSE DEPT Faculty Form";
            this.Load += new System.EventHandler(this.FacultyForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PhotoBox)).EndInit();
            this.FacultyInfoBox.ResumeLayout(false);
            this.FacultyBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.facultyBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cSE_DEPTDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.PictureBox PhotoBox;
        internal System.Windows.Forms.Label EmailLabel;
        internal System.Windows.Forms.ComboBox ComboMethod;
        internal System.Windows.Forms.Label TitleLabel;
        internal System.Windows.Forms.Label FacultyNameLabel;
        internal System.Windows.Forms.ComboBox ComboName;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Button cmdDelete;
        internal System.Windows.Forms.Label CollegeLabel;
        internal System.Windows.Forms.Button cmdInsert;
        internal System.Windows.Forms.Button cmdSelect;
        internal System.Windows.Forms.Button cmdUpdate;
        internal System.Windows.Forms.Label OfficeLabel;
        internal System.Windows.Forms.Button cmdBack;
        internal System.Windows.Forms.Label PhoneLabel;
        internal System.Windows.Forms.GroupBox FacultyInfoBox;
        internal System.Windows.Forms.GroupBox FacultyBox;
        private CSE_DEPTDataSet cSE_DEPTDataSet;
        private System.Windows.Forms.BindingSource facultyBindingSource;
        private SQLInsertWizard.CSE_DEPTDataSetTableAdapters.FacultyTableAdapter facultyTableAdapter;
    }
}