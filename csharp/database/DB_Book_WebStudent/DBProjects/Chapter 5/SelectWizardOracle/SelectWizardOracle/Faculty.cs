using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SelectWizardOracle
{
    public partial class FacultyForm : Form
    {
        public FacultyForm()
        {
            InitializeComponent();
        }
        private void FacultyForm_Load(object sender, EventArgs e)
        {
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
            ComboMethod.Items.Add("TableAdapter Method");
            ComboMethod.Items.Add("LINQ & DataSet Method");
            this.ComboMethod.SelectedIndex = 0;
        }
        private void cmdSelect_Click(object sender, EventArgs e)
        {
            this.facultyTableAdapter.ClearBeforeFill = true;
            string strName = FindName(ComboName.Text);
            if (strName == "No Match")
                MessageBox.Show("No Matched Faculty Image Found!");
            else
            {
                if (this.ComboMethod.Text == "LINQ & DataSet Method")
                    LINQtoDataSet();
                else
                {
                    this.facultyTableAdapter.FillByFacultyName(cSE_DEPTDataSet.FACULTY, ComboName.Text);
                    if (cSE_DEPTDataSet.FACULTY.Count == 0)
                        MessageBox.Show("No Matched Faculty Found!");
                }
            }
        }
        private string FindName(string fName)
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
        private void LINQtoDataSet()
        {
            this.facultyTableAdapter.Fill(cSE_DEPTDataSet.FACULTY);
            var facultyinfo = (from fi in cSE_DEPTDataSet.FACULTY
                               where fi.Field<string>("faculty_name").Equals(ComboName.Text)
                               select fi);
            foreach (var fRow in facultyinfo)
            {
                this.TitleLabel.Text = fRow.TITLE;
                this.OfficeLabel.Text = fRow.OFFICE;
                this.PhoneLabel.Text = fRow.PHONE;
                this.CollegeLabel.Text = fRow.COLLEGE;
                this.EmailLabel.Text = fRow.EMAIL;
            }
        }
        private void cmdBack_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
