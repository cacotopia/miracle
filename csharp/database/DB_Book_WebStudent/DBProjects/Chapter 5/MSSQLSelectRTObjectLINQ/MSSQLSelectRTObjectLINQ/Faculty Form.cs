using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MSSQLSelectRTObjectLINQ
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
            this.cmdSelect_Click(this.cmdSelect, null);
            ComboMethod.Items.Add("LINQ to SQL Method");
            ComboMethod.Items.Add("LINQ - Single Record");
            this.ComboMethod.SelectedIndex = 0;
        }
        private void cmdSelect_Click(object sender, EventArgs e)
        {
            LogInForm logForm = new LogInForm();
            logForm = logForm.getLogInForm();

            string strName = ShowFaculty(ComboName.Text);
            if (strName == "No Match")
                MessageBox.Show("No Matched Faculty Image found!");
            if (ComboMethod.Text == "LINQ to SQL Method")
            {
                var f_info = from fi in logForm.cse_dept.Faculties
                             where fi.faculty_name == ComboName.Text
                             select fi;
                foreach (var f in f_info)
                {
                    TitleLabel.Text = f.title;
                    OfficeLabel.Text = f.office;
                    PhoneLabel.Text = f.phone;
                    CollegeLabel.Text = f.college;
                    EmailLabel.Text = f.email;
                }
            }
            else
            {
                Faculty faculty = logForm.cse_dept.Faculties.Single(fi => fi.faculty_name == ComboName.Text);
                TitleLabel.Text = faculty.title;
                OfficeLabel.Text = faculty.office;
                PhoneLabel.Text = faculty.phone;
                CollegeLabel.Text = faculty.college;
                EmailLabel.Text = faculty.email;
            }
            logForm.Close();
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
