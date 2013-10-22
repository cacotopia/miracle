using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AccessUpdateDeleteSP
{
    public partial class FacultyForm : Form
    {
        private TextBox[] FacultyTextBox = new TextBox[7];          // modified on 12-3-2008
        InsertFacultyForm InsertFaculty = new InsertFacultyForm();

        public FacultyForm()
        {
            InitializeComponent();
            UpdateFaculty();                        		    // added in nov 15 2008
            ComboName.SelectedIndex = 0;
            ComboMethod.Items.Add("DataAdapter Method");
            ComboMethod.Items.Add("DataReader Method");
            this.ComboMethod.SelectedIndex = 0;           
        }

        public void UpdateFaculty()
        {
            LogInForm logForm = new LogInForm();
            logForm = logForm.getLogInForm();
            OleDbCommand accCommand = new OleDbCommand("SELECT faculty_name FROM Faculty", logForm.accConnection);
            OleDbDataReader accReader = accCommand.ExecuteReader();
            while (accReader.Read())
            {
                ComboName.Items.Add(accReader[0].ToString());
            }                                   
        }
        private void cmdSelect_Click(object sender, EventArgs e)
        {
            string cmdString = "SELECT faculty_id, faculty_name, office, phone, college, title, email FROM Faculty ";
            cmdString += "WHERE faculty_name = name";
            OleDbDataAdapter FacultyDataAdapter = new OleDbDataAdapter();
            OleDbCommand accCommand = new OleDbCommand();
            OleDbDataReader accDataReader;
            DataTable accDataTable = new DataTable();
            LogInForm logForm = new LogInForm();
            logForm = logForm.getLogInForm();

            accCommand.Connection = logForm.accConnection;
            accCommand.CommandType = CommandType.Text;
            accCommand.CommandText = cmdString;
            accCommand.Parameters.Add("name", OleDbType.Char).Value = ComboName.Text;
            string strName = ShowFaculty(ComboName.Text);
            if (strName == "No Match")
                MessageBox.Show("No Matched Faculty Image found!");
            if (ComboMethod.Text == "DataAdapter Method")
            {
                FacultyDataAdapter.SelectCommand = accCommand;
                FacultyDataAdapter.Fill(accDataTable);
                if (accDataTable.Rows.Count > 0)
                    FillFacultyTable(ref accDataTable);
                else
                    MessageBox.Show("No matched faculty found!");
                accDataTable.Dispose();
                FacultyDataAdapter.Dispose();
            }
            else if (ComboMethod.Text == "DataReader Method")
            {
                accDataReader = accCommand.ExecuteReader();
                if (accDataReader.HasRows == true)
                    FillFacultyReader(accDataReader);
                else
                    MessageBox.Show("No matched faculty found!");
                accDataReader.Close();
            }
            else
                MessageBox.Show("Invalid Method Selected!");
        }
 
        private void FillFacultyTable(ref DataTable FacultyTable)
        {
            int pos1 = 0;

            for (int pos2 = 0; pos2<= 6; pos2++)        //Initialize the object array
                FacultyTextBox[pos2] = new TextBox();       // modified on 12-3-2008
            MapFacultyTable(FacultyTextBox);                //
            foreach (DataRow row in FacultyTable.Rows)
            {
                foreach (DataColumn column in FacultyTable.Columns)
                {
                    FacultyTextBox[pos1].Text = row[column].ToString();     //
                    pos1++;
                }
            }
        }
        private void MapFacultyTable(Object[] fText)        // modified on 12-3-2008
        {
            fText[1] = txtName;                             //
            fText[2] = txtOffice;     //The order must be identical
            fText[3] = txtPhone;      //with the real order in the query string
            fText[4] = txtCollege;
            fText[5] = txtTitle;
            fText[6] = txtEmail;
        }
        private void FillFacultyReader(OleDbDataReader FacultyReader)
        {
            int intIndex = 0;

            for (intIndex = 0; intIndex <= 6; intIndex++)        //Initialize the object array
                FacultyTextBox[intIndex] = new TextBox();
            MapFacultyTable(FacultyTextBox);
            while (FacultyReader.Read())
            {
                for (intIndex = 0; intIndex <= FacultyReader.FieldCount - 1; intIndex++)
                    FacultyTextBox[intIndex].Text = FacultyReader.GetString(intIndex);
            }
        }
        private string ShowFaculty(string fName)
        {
            string strName;
            switch (fName)
            {
                case "Black Anderson":
                    strName = "Anderson.jpg";
                    break;
                case "Ying Bai":
                    strName = "Bai.jpg";
                    break;
                case "Satish Bhalla":
                    strName = "Satish.jpg";
                    break;
                case "Steve Johnson":
                    strName = "Johnson.jpg";
                    break;
                case "Jenney King":
                    strName = "King.jpg";
                    break;
                case "Alice Brown":
                    strName = "Brown.jpg";
                    break;
                case "Debby Angles":
                    strName = "Angles.jpg";
                    break;
                case "Jeff Henry":
                    strName = "Henry.jpg";
                    break;
                default:
                    strName = "No Match";
                    break;
            }
            if (strName != "No Match")
            {
                PhotoBox.SizeMode = PictureBoxSizeMode.StretchImage;
                PhotoBox.Image = System.Drawing.Image.FromFile(strName);
            }
            else           // added in nov 16, 2008
            {
                PhotoBox.SizeMode = PictureBoxSizeMode.StretchImage;
                if ((InsertFaculty.chkPhoto.Checked == true) && (InsertFaculty.txtPhotoLocation.Text == "Default Location"))
                {
                    strName = InsertFaculty.txtPhotoName.Text;
                    PhotoBox.Image = System.Drawing.Image.FromFile(strName);
                }
                if ((InsertFaculty.chkPhoto.Checked == true) && (InsertFaculty.txtPhotoLocation.Text != "Default Location"))
                {
                    strName = InsertFaculty.txtPhotoLocation.Text + "\\" + InsertFaculty.txtPhotoName.Text;
                    PhotoBox.Image = System.Drawing.Image.FromFile(strName);
                }
            }
            return strName;
        }
        private void cmdInsert_Click(object sender, EventArgs e)
        {
            InsertFaculty.setFacultyForm(this);
            InsertFaculty.Show();
        }
        
        private void cmdBack_Click(object sender, EventArgs e)
        {
            InsertFaculty.Close();
            this.Hide();
        }

        private void cmdUpdate_Click(object sender, EventArgs e)
        {
            string cmdString = "AccessUpdateSP";
            LogInForm logForm = new LogInForm();
            logForm = logForm.getLogInForm();
            OleDbCommand accCommand = new OleDbCommand();
            int intUpdate = 0;

            accCommand.Connection = logForm.accConnection;
            accCommand.CommandType = CommandType.StoredProcedure;
            accCommand.CommandText = cmdString;
            UpdateParameters(ref accCommand);
            intUpdate = accCommand.ExecuteNonQuery();
            accCommand.Dispose();
            ComboName.Items.Clear();
            UpdateFaculty();
            if (intUpdate == 0)
                MessageBox.Show("The data updating is failed");
        }
        private void UpdateParameters(ref OleDbCommand cmd)
        {
            cmd.Parameters.Add("name", OleDbType.Char).Value = txtName.Text;
            cmd.Parameters.Add("office", OleDbType.Char).Value = txtOffice.Text;
            cmd.Parameters.Add("phone", OleDbType.Char).Value = txtPhone.Text;
            cmd.Parameters.Add("college", OleDbType.Char).Value = txtCollege.Text;
            cmd.Parameters.Add("title", OleDbType.Char).Value = txtTitle.Text;
            cmd.Parameters.Add("email", OleDbType.Char).Value = txtEmail.Text;
            cmd.Parameters.Add("FacultyName", OleDbType.Char).Value = ComboName.Text;
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            string cmdString = "AccessDeleteSP";
            MessageBoxButtons vbButton = MessageBoxButtons.YesNo;
            LogInForm logForm = new LogInForm();
            logForm = logForm.getLogInForm();
            OleDbCommand accCommand = new OleDbCommand();
            DialogResult Answer;
            int intDelete = 0;

            Answer = MessageBox.Show("Do you want to delete this record?", "Delete", vbButton);

            if (Answer == System.Windows.Forms.DialogResult.Yes)
            {
                accCommand.Connection = logForm.accConnection;
                accCommand.CommandType = CommandType.StoredProcedure;
                accCommand.CommandText = cmdString;
                accCommand.Parameters.Add("FacultyName", OleDbType.Char).Value = ComboName.Text;
                intDelete = accCommand.ExecuteNonQuery();
                accCommand.Dispose();
                
                if (intDelete == 0)
                    MessageBox.Show("The data Deleting is failed");

                for (intDelete = 0; intDelete < 7; intDelete++)            // clean up the Faculty textbox array
                    FacultyTextBox[intDelete].Text = string.Empty;
            }
        }
    }
}
