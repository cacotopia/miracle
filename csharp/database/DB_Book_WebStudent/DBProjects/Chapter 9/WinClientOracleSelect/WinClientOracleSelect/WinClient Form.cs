using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WinClientOracleSelect
{
    public partial class FacultyForm : Form
    {
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

            ComboMethod.Items.Add("Object Method");
            ComboMethod.Items.Add("Stored Procedure Method");
            ComboMethod.Items.Add("DataSet Method");
            ComboMethod.SelectedIndex = 0;
        }

        private void cmdSelect_Click(object sender, EventArgs e)
        {
            WS_OracleSelect.WebServiceOracleSelect wsOracleSelect = new WS_OracleSelect.WebServiceOracleSelect();
            WS_OracleSelect.OracleSelectResult wsOracleResult = new WS_OracleSelect.OracleSelectResult();
            DataSet wsDataSet = new DataSet();

            ShowFaculty(ComboName.Text);
            if (ComboMethod.Text == "Object Method")
            {
                try { wsOracleResult = wsOracleSelect.GetOracleSelect(ComboName.Text); }
                catch (Exception err) {MessageBox.Show("Web service is wrong: " + err.Message);}
                ProcessObject(ref wsOracleResult);
            }
            else if (ComboMethod.Text == "Stored Procedure Method")
            {
                try { wsOracleResult = wsOracleSelect.GetOracleSelectSP(ComboName.Text); }
                catch (Exception err) { MessageBox.Show("Web service is wrong: " + err.Message); }
                ProcessObject(ref wsOracleResult);
            }
            else
            {
                try { wsDataSet = wsOracleSelect.GetOracleSelectDataSet(ComboName.Text); }
                catch (Exception err) { MessageBox.Show("Web service is wrong: " + err.Message); }
                FillFacultyDataSet(ref wsDataSet);
            }
        }
        private void ProcessObject(ref WS_OracleSelect.OracleSelectResult wsResult)
        {
            if (wsResult.OracleRequestOK == true)
                FillFacultyObject(ref wsResult);
            else
                MessageBox.Show("Faculty information cannot be retrieved: " + wsResult.OracleRequestError);
        }

        private void FillFacultyObject(ref WS_OracleSelect.OracleSelectResult oraResult)
        {
            txtID.Text = oraResult.FacultyID;
            txtOffice.Text = oraResult.FacultyOffice;
            txtPhone.Text = oraResult.FacultyPhone;
            txtCollege.Text = oraResult.FacultyCollege;
            txtTitle.Text = oraResult.FacultyTitle;
            txtEmail.Text = oraResult.FacultyEmail;
        }
        private void FillFacultyDataSet(ref DataSet ds)
        {
            DataTable FacultyTable = new DataTable();
            DataRow FacultyRow;

            FacultyTable = ds.Tables["Faculty"];
            FacultyRow = FacultyTable.Rows[0];          		 //only one rwo in the Faculty table
            txtID.Text = FacultyRow["faculty_id"].ToString();
            txtOffice.Text = FacultyRow["office"].ToString();
            txtPhone.Text = FacultyRow["phone"].ToString();
            txtCollege.Text = FacultyRow["college"].ToString();
            txtTitle.Text = FacultyRow["title"].ToString();
            txtEmail.Text = FacultyRow["email"].ToString();
        }
        private void ShowFaculty(string strName)
        {
            string FacultyImage = string.Empty;
            switch (strName)
            {
                case "Black Anderson":
                    FacultyImage = "Anderson.jpg";
                    break;
                case "Ying Bai":
                    FacultyImage = "Bai.jpg";
                    break;
                case "Satish Bhalla":
                    FacultyImage = "Satish.jpg";
                    break;
                case "Steve Johnson":
                    FacultyImage = "Johnson.jpg";
                    break;
                case "Jenney King":
                    FacultyImage = "King.jpg";
                    break;
                case "Alice Brown":
                    FacultyImage = "Brown.jpg";
                    break;
                case "Debby Angles":
                    FacultyImage = "Angles.jpg";
                    break;
                case "Jeff Henry":
                    FacultyImage = "Henry.jpg";
                    break;
                default:
                    MessageBox.Show("No match faculty found!");
                    break;
            }
            PhotoBox.SizeMode = PictureBoxSizeMode.StretchImage;
            PhotoBox.Image = System.Drawing.Image.FromFile(FacultyImage);
        }
        private void cmdBack_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
