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

namespace SQLSelectRTObject
{
    public partial class FacultyForm : Form
    {
        private Label[] FacultyLabel = new Label[7];

        public FacultyForm()
        {
            InitializeComponent();
            ComboName.Items.Add("Ying Bai");
            ComboName.Items.Add("Satish Bhalla");
            ComboName.Items.Add("Black Anderson");
            ComboName.Items.Add("Steve Johnson");
            ComboName.Items.Add("Jenney King");
            ComboName.Items.Add("Alice Brown");
            ComboName.Items.Add("Debby Angles");
            ComboName.Items.Add("Jeff Henry");
            ComboName.SelectedIndex = 0;
            ComboMethod.Items.Add("DataAdapter Method");
            ComboMethod.Items.Add("DataReader Method");
            this.ComboMethod.SelectedIndex = 0;
        }
        private void cmdSelect_Click(object sender, EventArgs e)
        {
            string cmdString = "SELECT faculty_id, faculty_name, office, phone, college, title, email FROM Faculty ";
            cmdString += "WHERE faculty_name LIKE @name";
            SqlDataAdapter FacultyDataAdapter= new SqlDataAdapter();
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

            for (int pos2 = 0; pos2<= 6; pos2++)         //Initialize the object array
                FacultyLabel[pos2] = new Label();
            MapFacultyTable(FacultyLabel);
            foreach (DataRow row in FacultyTable.Rows)
            {
                foreach (DataColumn column in FacultyTable.Columns)
                {
                    FacultyLabel[pos1].Text = row[column].ToString();
                    pos1++;
                }
            }
        }
        private void MapFacultyTable(Object[] fLabel)
        {
            fLabel[2] = OfficeLabel;     //The order must be identical
            fLabel[3] = PhoneLabel;      //with the real order in the query string
            fLabel[4] = CollegeLabel;
            fLabel[5] = TitleLabel;
            fLabel[6] = EmailLabel;
        }
        private void FillFacultyReader(SqlDataReader FacultyReader)
        {
            int intIndex = 0;

            for (intIndex = 0; intIndex <= 6; intIndex++)        //Initialize the object array
                FacultyLabel[intIndex] = new Label();       
            MapFacultyTable(FacultyLabel);
            while (FacultyReader.Read())
            {
                for (intIndex = 0; intIndex <= FacultyReader.FieldCount - 1; intIndex++)
                    FacultyLabel[intIndex].Text = FacultyReader.GetString(intIndex);
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
            return strName;
        }
        private void cmdBack_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
