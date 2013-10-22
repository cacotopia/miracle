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

namespace SQLUpdateDeleteRTObject
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
            SqlCommand sqlCommand = new SqlCommand("SELECT faculty_name FROM Faculty", logForm.sqlConnection);
            SqlDataReader sqlReader = sqlCommand.ExecuteReader();
            while (sqlReader.Read())
            {
                ComboName.Items.Add(sqlReader[0].ToString());
            }                                   
        }
        private void cmdSelect_Click(object sender, EventArgs e)
        {
            string cmdString = "SELECT faculty_id, faculty_name, office, phone, college, title, email FROM Faculty ";
            cmdString += "WHERE faculty_name LIKE @name";
            SqlDataAdapter FacultyDataAdapter = new SqlDataAdapter();
            SqlCommand sqlCommand = new SqlCommand();
            SqlDataReader sqlDataReader;
            DataTable sqlDataTable = new DataTable();
            LogInForm logForm = new LogInForm();
            logForm = logForm.getLogInForm();

            sqlCommand.Connection = logForm.sqlConnection;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = cmdString;
            sqlCommand.Parameters.Add("@name", SqlDbType.Char).Value = ComboName.Text;
            string strName = ShowFaculty(ComboName.Text);
            if (strName == "No Match")
                MessageBox.Show("No Matched Faculty Image found!");
            if (ComboMethod.Text == "DataAdapter Method")
            {
                FacultyDataAdapter.SelectCommand = sqlCommand;
                FacultyDataAdapter.Fill(sqlDataTable);
                if (sqlDataTable.Rows.Count > 0)
                    FillFacultyTable(ref sqlDataTable);
                else
                    MessageBox.Show("No matched faculty found!");
                sqlDataTable.Dispose();
                FacultyDataAdapter.Dispose();
            }
            else if (ComboMethod.Text == "DataReader Method")
            {
                sqlDataReader = sqlCommand.ExecuteReader();
                if (sqlDataReader.HasRows == true)
                    FillFacultyReader(sqlDataReader);
                else
                    MessageBox.Show("No matched faculty found!");
                sqlDataReader.Close();
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
        private void FillFacultyReader(SqlDataReader FacultyReader)
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
            string cmdString = "UPDATE Faculty SET faculty_name = @name, office = @office, phone = @phone, " +
                               "college = @college, title = @title, email = @email " +
                               "WHERE (faculty_name LIKE @Param1)";
            LogInForm logForm = new LogInForm();
            logForm = logForm.getLogInForm();
            SqlCommand sqlCommand = new SqlCommand();
            int intUpdate = 0;

            sqlCommand.Connection = logForm.sqlConnection;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = cmdString;
            UpdateParameters(ref sqlCommand);
            intUpdate = sqlCommand.ExecuteNonQuery();
            sqlCommand.Dispose();
            ComboName.Items.Clear();
            UpdateFaculty();
            if (intUpdate == 0)
                MessageBox.Show("The data updating is failed");
        }
        private void UpdateParameters(ref SqlCommand cmd)
        {
            cmd.Parameters.Add("@name", SqlDbType.Char).Value = txtName.Text;
            cmd.Parameters.Add("@office", SqlDbType.Char).Value = txtOffice.Text;
            cmd.Parameters.Add("@phone", SqlDbType.Char).Value = txtPhone.Text;
            cmd.Parameters.Add("@college", SqlDbType.Char).Value = txtCollege.Text;
            cmd.Parameters.Add("@title", SqlDbType.Char).Value = txtTitle.Text;
            cmd.Parameters.Add("@email", SqlDbType.Char).Value = txtEmail.Text;
            cmd.Parameters.Add("@Param1", SqlDbType.Char).Value = ComboName.Text;
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            string cmdString = "DELETE FROM Faculty WHERE (faculty_name LIKE @Param1)";
            MessageBoxButtons vbButton = MessageBoxButtons.YesNo;
            LogInForm logForm = new LogInForm();
            logForm = logForm.getLogInForm();
            SqlCommand sqlCommand = new SqlCommand();
            DialogResult Answer;
            int intDelete = 0;

            Answer = MessageBox.Show("Do you want to delete this record?", "Delete", vbButton);

            if (Answer == System.Windows.Forms.DialogResult.Yes)
            {
                sqlCommand.Connection = logForm.sqlConnection;
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.CommandText = cmdString;
                sqlCommand.Parameters.Add("@Param1", SqlDbType.Char).Value = ComboName.Text;
                intDelete = sqlCommand.ExecuteNonQuery();
                sqlCommand.Dispose();
                
                if (intDelete == 0)
                    MessageBox.Show("The data Deleting is failed");

                for (intDelete = 0; intDelete < 7; intDelete++)            // clean up the Faculty textbox array
                    FacultyTextBox[intDelete].Text = string.Empty;
            }
        }
    }
}
