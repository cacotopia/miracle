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
using System.Data.OracleClient;

namespace OracleUpdateDeleteSP
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
            OracleCommand oraCommand = new OracleCommand("SELECT faculty_name FROM Faculty", logForm.oraConnection);
            OracleDataReader oraReader = oraCommand.ExecuteReader();
            while (oraReader.Read())
            {
                ComboName.Items.Add(oraReader[0].ToString());
            }                                   
        }
        private void cmdSelect_Click(object sender, EventArgs e)
        {
            string cmdString = "SELECT faculty_id, faculty_name, office, phone, college, title, email FROM Faculty ";
            cmdString += "WHERE faculty_name =: FacultyName";
            OracleDataAdapter FacultyDataAdapter = new OracleDataAdapter();
            OracleCommand oraCommand = new OracleCommand();
            OracleDataReader oraDataReader;
            DataTable oraDataTable = new DataTable();
            LogInForm logForm = new LogInForm();
            logForm = logForm.getLogInForm();

            oraCommand.Connection = logForm.oraConnection;
            oraCommand.CommandType = CommandType.Text;
            oraCommand.CommandText = cmdString;
            oraCommand.Parameters.Add("FacultyName", OracleType.Char).Value = ComboName.Text;
            string strName = ShowFaculty(ComboName.Text);
            if (strName == "No Match")
                MessageBox.Show("No Matched Faculty Image found!");
            if (ComboMethod.Text == "DataAdapter Method")
            {
                FacultyDataAdapter.SelectCommand = oraCommand;
                FacultyDataAdapter.Fill(oraDataTable);
                if (oraDataTable.Rows.Count > 0)
                    FillFacultyTable(ref oraDataTable);
                else
                    MessageBox.Show("No matched faculty found!");
                oraDataTable.Dispose();
                FacultyDataAdapter.Dispose();
            }
            else if (ComboMethod.Text == "DataReader Method")
            {
                oraDataReader = oraCommand.ExecuteReader();
                if (oraDataReader.HasRows == true)
                    FillFacultyReader(oraDataReader);
                else
                    MessageBox.Show("No matched faculty found!");
                oraDataReader.Close();
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
        private void FillFacultyReader(OracleDataReader FacultyReader)
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
            string cmdString = "UpdateFaculty_SP";
            LogInForm logForm = new LogInForm();
            logForm = logForm.getLogInForm();
            OracleCommand oraCommand = new OracleCommand();
            int intUpdate = 0;

            oraCommand.Connection = logForm.oraConnection;
            oraCommand.CommandType = CommandType.StoredProcedure;
            oraCommand.CommandText = cmdString;
            UpdateParameters(ref oraCommand);
            intUpdate = oraCommand.ExecuteNonQuery();
            oraCommand.Dispose();
            ComboName.Items.Clear();
            UpdateFaculty();
            if (intUpdate == 0)
                MessageBox.Show("The data updating is failed");
        }
        private void UpdateParameters(ref OracleCommand cmd)
        {
            cmd.Parameters.Add("inName", OracleType.Char).Value = txtName.Text;
            cmd.Parameters.Add("inOffice", OracleType.Char).Value = txtOffice.Text;
            cmd.Parameters.Add("inPhone", OracleType.Char).Value = txtPhone.Text;
            cmd.Parameters.Add("inCollege", OracleType.Char).Value = txtCollege.Text;
            cmd.Parameters.Add("inTitle", OracleType.Char).Value = txtTitle.Text;
            cmd.Parameters.Add("inEmail", OracleType.Char).Value = txtEmail.Text;
            cmd.Parameters.Add("FacultyName", OracleType.Char).Value = ComboName.Text;
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            string cmdString = "DeleteFaculty_SP";
            MessageBoxButtons vbButton = MessageBoxButtons.YesNo;
            LogInForm logForm = new LogInForm();
            logForm = logForm.getLogInForm();
            OracleCommand oraCommand = new OracleCommand();
            DialogResult Answer;
            int intDelete = 0;

            Answer = MessageBox.Show("Do you want to delete this record?", "Delete", vbButton);

            if (Answer == System.Windows.Forms.DialogResult.Yes)
            {
                oraCommand.Connection = logForm.oraConnection;
                oraCommand.CommandType = CommandType.StoredProcedure;
                oraCommand.CommandText = cmdString;
                oraCommand.Parameters.Add("FacultyName", OracleType.Char).Value = ComboName.Text;
                intDelete = oraCommand.ExecuteNonQuery();
                oraCommand.Dispose();

                if (intDelete == 0)
                    MessageBox.Show("The data Deleting is failed");

                for (intDelete = 0; intDelete < 7; intDelete++)            // clean up the Faculty textbox array
                    FacultyTextBox[intDelete].Text = string.Empty;
            }
        }
    }
}
