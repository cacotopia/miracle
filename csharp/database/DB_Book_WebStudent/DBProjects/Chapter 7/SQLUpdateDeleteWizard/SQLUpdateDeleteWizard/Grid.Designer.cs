namespace SQLUpdateDeleteWizard
{
    partial class GridForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GridForm));
            System.Windows.Forms.Label faculty_idLabel;
            System.Windows.Forms.Label faculty_nameLabel;
            System.Windows.Forms.Label officeLabel;
            System.Windows.Forms.Label phoneLabel;
            System.Windows.Forms.Label collegeLabel;
            System.Windows.Forms.Label titleLabel;
            System.Windows.Forms.Label emailLabel;
            this.cSE_DEPTDataSet = new SQLUpdateDeleteWizard.CSE_DEPTDataSet();
            this.facultyBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.facultyTableAdapter = new SQLUpdateDeleteWizard.CSE_DEPTDataSetTableAdapters.FacultyTableAdapter();
            this.tableAdapterManager = new SQLUpdateDeleteWizard.CSE_DEPTDataSetTableAdapters.TableAdapterManager();
            this.facultyBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.facultyBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.faculty_idTextBox = new System.Windows.Forms.TextBox();
            this.faculty_nameTextBox = new System.Windows.Forms.TextBox();
            this.officeTextBox = new System.Windows.Forms.TextBox();
            this.phoneTextBox = new System.Windows.Forms.TextBox();
            this.collegeTextBox = new System.Windows.Forms.TextBox();
            this.titleTextBox = new System.Windows.Forms.TextBox();
            this.emailTextBox = new System.Windows.Forms.TextBox();
            faculty_idLabel = new System.Windows.Forms.Label();
            faculty_nameLabel = new System.Windows.Forms.Label();
            officeLabel = new System.Windows.Forms.Label();
            phoneLabel = new System.Windows.Forms.Label();
            collegeLabel = new System.Windows.Forms.Label();
            titleLabel = new System.Windows.Forms.Label();
            emailLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.cSE_DEPTDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.facultyBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.facultyBindingNavigator)).BeginInit();
            this.facultyBindingNavigator.SuspendLayout();
            this.SuspendLayout();
            // 
            // cSE_DEPTDataSet
            // 
            this.cSE_DEPTDataSet.DataSetName = "CSE_DEPTDataSet";
            this.cSE_DEPTDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // facultyBindingSource
            // 
            this.facultyBindingSource.DataMember = "Faculty";
            this.facultyBindingSource.DataSource = this.cSE_DEPTDataSet;
            // 
            // facultyTableAdapter
            // 
            this.facultyTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.CourseTableAdapter = null;
            this.tableAdapterManager.FacultyTableAdapter = this.facultyTableAdapter;
            this.tableAdapterManager.LogInTableAdapter = null;
            this.tableAdapterManager.StudentCourseTableAdapter = null;
            this.tableAdapterManager.StudentTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = SQLUpdateDeleteWizard.CSE_DEPTDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // facultyBindingNavigator
            // 
            this.facultyBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.facultyBindingNavigator.BindingSource = this.facultyBindingSource;
            this.facultyBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.facultyBindingNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
            this.facultyBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem,
            this.facultyBindingNavigatorSaveItem});
            this.facultyBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.facultyBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.facultyBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.facultyBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.facultyBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.facultyBindingNavigator.Name = "facultyBindingNavigator";
            this.facultyBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.facultyBindingNavigator.Size = new System.Drawing.Size(333, 25);
            this.facultyBindingNavigator.TabIndex = 0;
            this.facultyBindingNavigator.Text = "bindingNavigator1";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 23);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Current position";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(42, 16);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 6);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 20);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 20);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 6);
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorAddNewItem.Text = "Add new";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(23, 20);
            this.bindingNavigatorDeleteItem.Text = "Delete";
            // 
            // facultyBindingNavigatorSaveItem
            // 
            this.facultyBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.facultyBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("facultyBindingNavigatorSaveItem.Image")));
            this.facultyBindingNavigatorSaveItem.Name = "facultyBindingNavigatorSaveItem";
            this.facultyBindingNavigatorSaveItem.Size = new System.Drawing.Size(23, 23);
            this.facultyBindingNavigatorSaveItem.Text = "Save Data";
            this.facultyBindingNavigatorSaveItem.Click += new System.EventHandler(this.facultyBindingNavigatorSaveItem_Click_1);
            // 
            // faculty_idLabel
            // 
            faculty_idLabel.AutoSize = true;
            faculty_idLabel.Location = new System.Drawing.Point(68, 68);
            faculty_idLabel.Name = "faculty_idLabel";
            faculty_idLabel.Size = new System.Drawing.Size(52, 13);
            faculty_idLabel.TabIndex = 1;
            faculty_idLabel.Text = "faculty id:";
            // 
            // faculty_idTextBox
            // 
            this.faculty_idTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.facultyBindingSource, "faculty_id", true));
            this.faculty_idTextBox.Location = new System.Drawing.Point(144, 65);
            this.faculty_idTextBox.Name = "faculty_idTextBox";
            this.faculty_idTextBox.Size = new System.Drawing.Size(100, 20);
            this.faculty_idTextBox.TabIndex = 2;
            // 
            // faculty_nameLabel
            // 
            faculty_nameLabel.AutoSize = true;
            faculty_nameLabel.Location = new System.Drawing.Point(68, 94);
            faculty_nameLabel.Name = "faculty_nameLabel";
            faculty_nameLabel.Size = new System.Drawing.Size(70, 13);
            faculty_nameLabel.TabIndex = 3;
            faculty_nameLabel.Text = "faculty name:";
            // 
            // faculty_nameTextBox
            // 
            this.faculty_nameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.facultyBindingSource, "faculty_name", true));
            this.faculty_nameTextBox.Location = new System.Drawing.Point(144, 91);
            this.faculty_nameTextBox.Name = "faculty_nameTextBox";
            this.faculty_nameTextBox.Size = new System.Drawing.Size(100, 20);
            this.faculty_nameTextBox.TabIndex = 4;
            // 
            // officeLabel
            // 
            officeLabel.AutoSize = true;
            officeLabel.Location = new System.Drawing.Point(68, 120);
            officeLabel.Name = "officeLabel";
            officeLabel.Size = new System.Drawing.Size(36, 13);
            officeLabel.TabIndex = 5;
            officeLabel.Text = "office:";
            // 
            // officeTextBox
            // 
            this.officeTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.facultyBindingSource, "office", true));
            this.officeTextBox.Location = new System.Drawing.Point(144, 117);
            this.officeTextBox.Name = "officeTextBox";
            this.officeTextBox.Size = new System.Drawing.Size(100, 20);
            this.officeTextBox.TabIndex = 6;
            // 
            // phoneLabel
            // 
            phoneLabel.AutoSize = true;
            phoneLabel.Location = new System.Drawing.Point(68, 146);
            phoneLabel.Name = "phoneLabel";
            phoneLabel.Size = new System.Drawing.Size(40, 13);
            phoneLabel.TabIndex = 7;
            phoneLabel.Text = "phone:";
            // 
            // phoneTextBox
            // 
            this.phoneTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.facultyBindingSource, "phone", true));
            this.phoneTextBox.Location = new System.Drawing.Point(144, 143);
            this.phoneTextBox.Name = "phoneTextBox";
            this.phoneTextBox.Size = new System.Drawing.Size(100, 20);
            this.phoneTextBox.TabIndex = 8;
            // 
            // collegeLabel
            // 
            collegeLabel.AutoSize = true;
            collegeLabel.Location = new System.Drawing.Point(68, 172);
            collegeLabel.Name = "collegeLabel";
            collegeLabel.Size = new System.Drawing.Size(44, 13);
            collegeLabel.TabIndex = 9;
            collegeLabel.Text = "college:";
            // 
            // collegeTextBox
            // 
            this.collegeTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.facultyBindingSource, "college", true));
            this.collegeTextBox.Location = new System.Drawing.Point(144, 169);
            this.collegeTextBox.Name = "collegeTextBox";
            this.collegeTextBox.Size = new System.Drawing.Size(100, 20);
            this.collegeTextBox.TabIndex = 10;
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.Location = new System.Drawing.Point(68, 198);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new System.Drawing.Size(26, 13);
            titleLabel.TabIndex = 11;
            titleLabel.Text = "title:";
            // 
            // titleTextBox
            // 
            this.titleTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.facultyBindingSource, "title", true));
            this.titleTextBox.Location = new System.Drawing.Point(144, 195);
            this.titleTextBox.Name = "titleTextBox";
            this.titleTextBox.Size = new System.Drawing.Size(100, 20);
            this.titleTextBox.TabIndex = 12;
            // 
            // emailLabel
            // 
            emailLabel.AutoSize = true;
            emailLabel.Location = new System.Drawing.Point(68, 224);
            emailLabel.Name = "emailLabel";
            emailLabel.Size = new System.Drawing.Size(34, 13);
            emailLabel.TabIndex = 13;
            emailLabel.Text = "email:";
            // 
            // emailTextBox
            // 
            this.emailTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.facultyBindingSource, "email", true));
            this.emailTextBox.Location = new System.Drawing.Point(144, 221);
            this.emailTextBox.Name = "emailTextBox";
            this.emailTextBox.Size = new System.Drawing.Size(100, 20);
            this.emailTextBox.TabIndex = 14;
            // 
            // GridForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(333, 277);
            this.Controls.Add(faculty_idLabel);
            this.Controls.Add(this.faculty_idTextBox);
            this.Controls.Add(faculty_nameLabel);
            this.Controls.Add(this.faculty_nameTextBox);
            this.Controls.Add(officeLabel);
            this.Controls.Add(this.officeTextBox);
            this.Controls.Add(phoneLabel);
            this.Controls.Add(this.phoneTextBox);
            this.Controls.Add(collegeLabel);
            this.Controls.Add(this.collegeTextBox);
            this.Controls.Add(titleLabel);
            this.Controls.Add(this.titleTextBox);
            this.Controls.Add(emailLabel);
            this.Controls.Add(this.emailTextBox);
            this.Controls.Add(this.facultyBindingNavigator);
            this.Name = "GridForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Grid";
            this.Load += new System.EventHandler(this.GridForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cSE_DEPTDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.facultyBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.facultyBindingNavigator)).EndInit();
            this.facultyBindingNavigator.ResumeLayout(false);
            this.facultyBindingNavigator.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CSE_DEPTDataSet cSE_DEPTDataSet;
        private System.Windows.Forms.BindingSource facultyBindingSource;
        private SQLUpdateDeleteWizard.CSE_DEPTDataSetTableAdapters.FacultyTableAdapter facultyTableAdapter;
        private SQLUpdateDeleteWizard.CSE_DEPTDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingNavigator facultyBindingNavigator;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripButton facultyBindingNavigatorSaveItem;
        private System.Windows.Forms.TextBox faculty_idTextBox;
        private System.Windows.Forms.TextBox faculty_nameTextBox;
        private System.Windows.Forms.TextBox officeTextBox;
        private System.Windows.Forms.TextBox phoneTextBox;
        private System.Windows.Forms.TextBox collegeTextBox;
        private System.Windows.Forms.TextBox titleTextBox;
        private System.Windows.Forms.TextBox emailTextBox;

    }
}