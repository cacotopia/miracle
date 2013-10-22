using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SQLInsertWizard
{
    public partial class GridForm : Form
    {
        public GridForm()
        {
            InitializeComponent();
        }

        private void facultyBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.facultyBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.cSE_DEPTDataSet);

        }

        private void GridForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'cSE_DEPTDataSet.Faculty' table. You can move, or remove it, as needed.
            this.facultyTableAdapter.Fill(this.cSE_DEPTDataSet.Faculty);
            // TODO: This line of code loads data into the 'cSE_DEPTDataSet.Faculty' table. You can move, or remove it, as needed.
            this.facultyTableAdapter.Fill(this.cSE_DEPTDataSet.Faculty);

        }

        private void facultyBindingNavigatorSaveItem_Click_1(object sender, EventArgs e)
        {
            this.Validate();
            this.facultyBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.cSE_DEPTDataSet);

        }
    }
}
