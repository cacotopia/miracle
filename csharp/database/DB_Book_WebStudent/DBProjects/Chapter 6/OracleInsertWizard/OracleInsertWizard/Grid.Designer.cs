namespace OracleInsertWizard
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
            System.Windows.Forms.Label fACULTY_IDLabel;
            System.Windows.Forms.Label fACULTY_NAMELabel;
            System.Windows.Forms.Label oFFICELabel;
            System.Windows.Forms.Label pHONELabel;
            System.Windows.Forms.Label cOLLEGELabel;
            System.Windows.Forms.Label tITLELabel;
            System.Windows.Forms.Label eMAILLabel;
            this.cSE_DEPTDataSet1 = new OracleInsertWizard.CSE_DEPTDataSet();
            this.fACULTYBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.fACULTYTableAdapter1 = new OracleInsertWizard.CSE_DEPTDataSetTableAdapters.FACULTYTableAdapter();
            this.tableAdapterManager1 = new OracleInsertWizard.CSE_DEPTDataSetTableAdapters.TableAdapterManager();
            this.fACULTYBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
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
            this.fACULTYBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.fACULTY_IDTextBox = new System.Windows.Forms.TextBox();
            this.fACULTY_NAMETextBox = new System.Windows.Forms.TextBox();
            this.oFFICETextBox = new System.Windows.Forms.TextBox();
            this.pHONETextBox = new System.Windows.Forms.TextBox();
            this.cOLLEGETextBox = new System.Windows.Forms.TextBox();
            this.tITLETextBox = new System.Windows.Forms.TextBox();
            this.eMAILTextBox = new System.Windows.Forms.TextBox();
            fACULTY_IDLabel = new System.Windows.Forms.Label();
            fACULTY_NAMELabel = new System.Windows.Forms.Label();
            oFFICELabel = new System.Windows.Forms.Label();
            pHONELabel = new System.Windows.Forms.Label();
            cOLLEGELabel = new System.Windows.Forms.Label();
            tITLELabel = new System.Windows.Forms.Label();
            eMAILLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.cSE_DEPTDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fACULTYBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fACULTYBindingNavigator)).BeginInit();
            this.fACULTYBindingNavigator.SuspendLayout();
            this.SuspendLayout();
            // 
            // cSE_DEPTDataSet1
            // 
            this.cSE_DEPTDataSet1.DataSetName = "CSE_DEPTDataSet";
            this.cSE_DEPTDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // fACULTYBindingSource
            // 
            this.fACULTYBindingSource.DataMember = "FACULTY";
            this.fACULTYBindingSource.DataSource = this.cSE_DEPTDataSet1;
            // 
            // fACULTYTableAdapter1
            // 
            this.fACULTYTableAdapter1.ClearBeforeFill = true;
            // 
            // tableAdapterManager1
            // 
            this.tableAdapterManager1.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager1.COURSETableAdapter = null;
            this.tableAdapterManager1.FACULTYTableAdapter = this.fACULTYTableAdapter1;
            this.tableAdapterManager1.LOGINTableAdapter = null;
            this.tableAdapterManager1.STUDENTCOURSETableAdapter = null;
            this.tableAdapterManager1.STUDENTTableAdapter = null;
            this.tableAdapterManager1.UpdateOrder = OracleInsertWizard.CSE_DEPTDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // fACULTYBindingNavigator
            // 
            this.fACULTYBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.fACULTYBindingNavigator.BindingSource = this.fACULTYBindingSource;
            this.fACULTYBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.fACULTYBindingNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
            this.fACULTYBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.fACULTYBindingNavigatorSaveItem});
            this.fACULTYBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.fACULTYBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.fACULTYBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.fACULTYBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.fACULTYBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.fACULTYBindingNavigator.Name = "fACULTYBindingNavigator";
            this.fACULTYBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.fACULTYBindingNavigator.Size = new System.Drawing.Size(304, 25);
            this.fACULTYBindingNavigator.TabIndex = 0;
            this.fACULTYBindingNavigator.Text = "bindingNavigator1";
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
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            this.bindingNavigatorMoveNextItem.Click += new System.EventHandler(this.bindingNavigatorMoveNextItem_Click);
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
            // fACULTYBindingNavigatorSaveItem
            // 
            this.fACULTYBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.fACULTYBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("fACULTYBindingNavigatorSaveItem.Image")));
            this.fACULTYBindingNavigatorSaveItem.Name = "fACULTYBindingNavigatorSaveItem";
            this.fACULTYBindingNavigatorSaveItem.Size = new System.Drawing.Size(23, 23);
            this.fACULTYBindingNavigatorSaveItem.Text = "Save Data";
            this.fACULTYBindingNavigatorSaveItem.Click += new System.EventHandler(this.fACULTYBindingNavigatorSaveItem_Click_2);
            // 
            // fACULTY_IDLabel
            // 
            fACULTY_IDLabel.AutoSize = true;
            fACULTY_IDLabel.Location = new System.Drawing.Point(51, 70);
            fACULTY_IDLabel.Name = "fACULTY_IDLabel";
            fACULTY_IDLabel.Size = new System.Drawing.Size(72, 13);
            fACULTY_IDLabel.TabIndex = 1;
            fACULTY_IDLabel.Text = "FACULTY ID:";
            // 
            // fACULTY_IDTextBox
            // 
            this.fACULTY_IDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.fACULTYBindingSource, "FACULTY_ID", true));
            this.fACULTY_IDTextBox.Location = new System.Drawing.Point(149, 67);
            this.fACULTY_IDTextBox.Name = "fACULTY_IDTextBox";
            this.fACULTY_IDTextBox.Size = new System.Drawing.Size(100, 20);
            this.fACULTY_IDTextBox.TabIndex = 2;
            // 
            // fACULTY_NAMELabel
            // 
            fACULTY_NAMELabel.AutoSize = true;
            fACULTY_NAMELabel.Location = new System.Drawing.Point(51, 96);
            fACULTY_NAMELabel.Name = "fACULTY_NAMELabel";
            fACULTY_NAMELabel.Size = new System.Drawing.Size(92, 13);
            fACULTY_NAMELabel.TabIndex = 3;
            fACULTY_NAMELabel.Text = "FACULTY NAME:";
            // 
            // fACULTY_NAMETextBox
            // 
            this.fACULTY_NAMETextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.fACULTYBindingSource, "FACULTY_NAME", true));
            this.fACULTY_NAMETextBox.Location = new System.Drawing.Point(149, 93);
            this.fACULTY_NAMETextBox.Name = "fACULTY_NAMETextBox";
            this.fACULTY_NAMETextBox.Size = new System.Drawing.Size(100, 20);
            this.fACULTY_NAMETextBox.TabIndex = 4;
            // 
            // oFFICELabel
            // 
            oFFICELabel.AutoSize = true;
            oFFICELabel.Location = new System.Drawing.Point(51, 122);
            oFFICELabel.Name = "oFFICELabel";
            oFFICELabel.Size = new System.Drawing.Size(47, 13);
            oFFICELabel.TabIndex = 5;
            oFFICELabel.Text = "OFFICE:";
            // 
            // oFFICETextBox
            // 
            this.oFFICETextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.fACULTYBindingSource, "OFFICE", true));
            this.oFFICETextBox.Location = new System.Drawing.Point(149, 119);
            this.oFFICETextBox.Name = "oFFICETextBox";
            this.oFFICETextBox.Size = new System.Drawing.Size(100, 20);
            this.oFFICETextBox.TabIndex = 6;
            // 
            // pHONELabel
            // 
            pHONELabel.AutoSize = true;
            pHONELabel.Location = new System.Drawing.Point(51, 148);
            pHONELabel.Name = "pHONELabel";
            pHONELabel.Size = new System.Drawing.Size(48, 13);
            pHONELabel.TabIndex = 7;
            pHONELabel.Text = "PHONE:";
            // 
            // pHONETextBox
            // 
            this.pHONETextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.fACULTYBindingSource, "PHONE", true));
            this.pHONETextBox.Location = new System.Drawing.Point(149, 145);
            this.pHONETextBox.Name = "pHONETextBox";
            this.pHONETextBox.Size = new System.Drawing.Size(100, 20);
            this.pHONETextBox.TabIndex = 8;
            // 
            // cOLLEGELabel
            // 
            cOLLEGELabel.AutoSize = true;
            cOLLEGELabel.Location = new System.Drawing.Point(51, 174);
            cOLLEGELabel.Name = "cOLLEGELabel";
            cOLLEGELabel.Size = new System.Drawing.Size(59, 13);
            cOLLEGELabel.TabIndex = 9;
            cOLLEGELabel.Text = "COLLEGE:";
            // 
            // cOLLEGETextBox
            // 
            this.cOLLEGETextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.fACULTYBindingSource, "COLLEGE", true));
            this.cOLLEGETextBox.Location = new System.Drawing.Point(149, 171);
            this.cOLLEGETextBox.Name = "cOLLEGETextBox";
            this.cOLLEGETextBox.Size = new System.Drawing.Size(100, 20);
            this.cOLLEGETextBox.TabIndex = 10;
            // 
            // tITLELabel
            // 
            tITLELabel.AutoSize = true;
            tITLELabel.Location = new System.Drawing.Point(51, 200);
            tITLELabel.Name = "tITLELabel";
            tITLELabel.Size = new System.Drawing.Size(40, 13);
            tITLELabel.TabIndex = 11;
            tITLELabel.Text = "TITLE:";
            // 
            // tITLETextBox
            // 
            this.tITLETextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.fACULTYBindingSource, "TITLE", true));
            this.tITLETextBox.Location = new System.Drawing.Point(149, 197);
            this.tITLETextBox.Name = "tITLETextBox";
            this.tITLETextBox.Size = new System.Drawing.Size(100, 20);
            this.tITLETextBox.TabIndex = 12;
            // 
            // eMAILLabel
            // 
            eMAILLabel.AutoSize = true;
            eMAILLabel.Location = new System.Drawing.Point(51, 226);
            eMAILLabel.Name = "eMAILLabel";
            eMAILLabel.Size = new System.Drawing.Size(42, 13);
            eMAILLabel.TabIndex = 13;
            eMAILLabel.Text = "EMAIL:";
            // 
            // eMAILTextBox
            // 
            this.eMAILTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.fACULTYBindingSource, "EMAIL", true));
            this.eMAILTextBox.Location = new System.Drawing.Point(149, 223);
            this.eMAILTextBox.Name = "eMAILTextBox";
            this.eMAILTextBox.Size = new System.Drawing.Size(100, 20);
            this.eMAILTextBox.TabIndex = 14;
            // 
            // GridForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 271);
            this.Controls.Add(fACULTY_IDLabel);
            this.Controls.Add(this.fACULTY_IDTextBox);
            this.Controls.Add(fACULTY_NAMELabel);
            this.Controls.Add(this.fACULTY_NAMETextBox);
            this.Controls.Add(oFFICELabel);
            this.Controls.Add(this.oFFICETextBox);
            this.Controls.Add(pHONELabel);
            this.Controls.Add(this.pHONETextBox);
            this.Controls.Add(cOLLEGELabel);
            this.Controls.Add(this.cOLLEGETextBox);
            this.Controls.Add(tITLELabel);
            this.Controls.Add(this.tITLETextBox);
            this.Controls.Add(eMAILLabel);
            this.Controls.Add(this.eMAILTextBox);
            this.Controls.Add(this.fACULTYBindingNavigator);
            this.Name = "GridForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Grid";
            this.Load += new System.EventHandler(this.GridForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cSE_DEPTDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fACULTYBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fACULTYBindingNavigator)).EndInit();
            this.fACULTYBindingNavigator.ResumeLayout(false);
            this.fACULTYBindingNavigator.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CSE_DEPTDataSet cSE_DEPTDataSet1;
        private System.Windows.Forms.BindingSource fACULTYBindingSource;
        private OracleInsertWizard.CSE_DEPTDataSetTableAdapters.FACULTYTableAdapter fACULTYTableAdapter1;
        private OracleInsertWizard.CSE_DEPTDataSetTableAdapters.TableAdapterManager tableAdapterManager1;
        private System.Windows.Forms.BindingNavigator fACULTYBindingNavigator;
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
        private System.Windows.Forms.ToolStripButton fACULTYBindingNavigatorSaveItem;
        private System.Windows.Forms.TextBox fACULTY_IDTextBox;
        private System.Windows.Forms.TextBox fACULTY_NAMETextBox;
        private System.Windows.Forms.TextBox oFFICETextBox;
        private System.Windows.Forms.TextBox pHONETextBox;
        private System.Windows.Forms.TextBox cOLLEGETextBox;
        private System.Windows.Forms.TextBox tITLETextBox;
        private System.Windows.Forms.TextBox eMAILTextBox;

    }
}