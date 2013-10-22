using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OracleInsertWizard
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
            this.fACULTYBindingSource.EndEdit();
            this.tableAdapterManager1.UpdateAll(this.cSE_DEPTDataSet1);

        }

        private void GridForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'cSE_DEPTDataSet1.FACULTY' table. You can move, or remove it, as needed.
            this.fACULTYTableAdapter1.Fill(this.cSE_DEPTDataSet1.FACULTY);
        }

        private void facultyBindingNavigatorSaveItem_Click_1(object sender, EventArgs e)
        {
            this.Validate();
            this.fACULTYBindingSource.EndEdit();
            this.tableAdapterManager1.UpdateAll(this.cSE_DEPTDataSet1);

        }

        private void fACULTYBindingNavigatorSaveItem_Click_2(object sender, EventArgs e)
        {
            this.Validate();
            this.fACULTYBindingSource.EndEdit();
            this.tableAdapterManager1.UpdateAll(this.cSE_DEPTDataSet1);

        }

        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {

        }
    }
}
