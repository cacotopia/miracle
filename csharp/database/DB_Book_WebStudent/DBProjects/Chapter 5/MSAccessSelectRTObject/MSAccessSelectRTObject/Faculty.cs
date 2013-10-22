﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AccessSelectRTObject
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
            this.cmdSelect_Click(this.cmdSelect, null);
            ComboMethod.Items.Add("DataAdapter Method");
            ComboMethod.Items.Add("DataReader Method");
            ComboMethod.Items.Add("LINQ & Object Method");
            this.ComboMethod.SelectedIndex = 0;
        }
        private void cmdSelect_Click(object sender, EventArgs e)
        {
            string cmdString = "SELECT faculty_id, faculty_name, office, phone, college, title, email FROM Faculty ";
            cmdString += "WHERE faculty_name = @Param1";
            OleDbDataAdapter FacultyDataAdapter= new OleDbDataAdapter();
            OleDbCommand accCommand = new OleDbCommand();
            OleDbDataReader accDataReader;
            DataTable accDataTable = new DataTable();
            DataSet ds = new DataSet();
            LogInForm logForm = new LogInForm();
            logForm = logForm.getLogInForm();

            accCommand.Connection = logForm.accConnection;
            accCommand.CommandType = CommandType.Text;
            accCommand.CommandText = cmdString;
            accCommand.Parameters.Add("@Param1", OleDbType.Char).Value = ComboName.Text;
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
            else    //LINQ to Object Method is selected
            {
                FacultyDataAdapter.SelectCommand = accCommand;
                FacultyDataAdapter.Fill(ds, "Faculty");
                var facultyinfo = (from fi in ds.Tables["Faculty"].AsEnumerable()
                                   where fi.Field<string>("faculty_name").Equals(ComboName.Text)
                                   select fi);
                foreach (var fRow in facultyinfo)
                {
                    this.TitleLabel.Text = fRow.Field<string>("title");
                    this.OfficeLabel.Text = fRow.Field<string>("office");
                    this.PhoneLabel.Text = fRow.Field<string>("phone");
                    this.CollegeLabel.Text = fRow.Field<string>("college");
                    this.EmailLabel.Text = fRow.Field<string>("email");
                }
            }
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
        private void FillFacultyReader(OleDbDataReader FacultyReader)
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
