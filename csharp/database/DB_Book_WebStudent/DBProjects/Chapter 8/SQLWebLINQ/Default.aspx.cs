using System;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.Linq;
using System.Data.Linq.Mapping;

public partial class _Default : System.Web.UI.Page 
{
    CSE_DEPTDataContext cse_dept = new CSE_DEPTDataContext();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            UpdateFaculty();
            ComboName.SelectedIndex = 0;
        } 
    }
    void UpdateFaculty()
    {
        ComboName.Items.Clear();
        var faculty = (from fi in cse_dept.Faculties
                       let fields = "faculty_name"
                       select fi);
        foreach (var f in faculty)
        {
            ComboName.Items.Add(f.faculty_name);
        }
    }
    protected void cmdInsert_Click(object sender, EventArgs e)
    {
        Faculty newFaculty = new Faculty();
        newFaculty.faculty_id = txtID.Text;
        newFaculty.faculty_name = txtName.Text;
        newFaculty.title = txtTitle.Text;
        newFaculty.office = txtOffice.Text;
        newFaculty.phone = txtPhone.Text;
        newFaculty.college = txtCollege.Text;
        newFaculty.email = txtEmail.Text;

        // Add the faculty members to the Faculty table.
        cse_dept.Faculties.InsertOnSubmit(newFaculty);
        cse_dept.SubmitChanges();
        ComboName.Items.Clear();
        UpdateFaculty();
        Application["FacultyImage"] = txtPhoto.Text;
    }
    protected void cmdSelect_Click(object sender, EventArgs e)
    {
        string strName = ShowFaculty(ComboName.Text);
        var faculty = (from fi in cse_dept.Faculties
                       where fi.faculty_name == ComboName.Text
                       select fi);

        foreach (var f in faculty)
        {
            txtID.Text = f.faculty_id;
            txtName.Text = f.faculty_name;
            txtTitle.Text = f.title;
            txtOffice.Text = f.office;
            txtPhone.Text = f.phone;
            txtCollege.Text = f.college;
            txtEmail.Text = f.email;
        }
    }
    protected void cmdUpdate_Click(object sender, EventArgs e)
    {
        Faculty fi = cse_dept.Faculties.Where(f => f.faculty_name == ComboName.Text).First();
        // updating the existing faculty information
        fi.faculty_name = txtName.Text;
        fi.title = txtTitle.Text;
        fi.office = txtOffice.Text;
        fi.phone = txtPhone.Text;
        fi.college = txtCollege.Text;
        fi.email = txtEmail.Text;
        cse_dept.SubmitChanges();
        ComboName.Items.Clear();
        UpdateFaculty();
    }
    protected void cmdDelete_Click(object sender, EventArgs e)
    {
        var faculty = (from fi in cse_dept.Faculties
                       where fi.faculty_name == ComboName.Text
                       select fi).Single<Faculty>();
        cse_dept.Faculties.DeleteOnSubmit(faculty);
        cse_dept.SubmitChanges();
        // clean up all textboxes
        txtID.Text = string.Empty;
        txtName.Text = string.Empty;
        txtOffice.Text = string.Empty;
        txtTitle.Text = string.Empty;
        txtPhone.Text = string.Empty;
        txtCollege.Text = string.Empty;
        txtEmail.Text = string.Empty;
        ComboName.Items.Clear();
        UpdateFaculty();
    }
    protected void cmdExit_Click(object sender, EventArgs e)
    {
        Response.Write("<script>window.close()</script>");
    }
    private string ShowFaculty(string fName)
    {
        string FacultyImage;
        switch (fName)
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
                FacultyImage = "No Match";
                break;
        }
        if (FacultyImage != "No Match")
            PhotoBox.ImageUrl = FacultyImage;
        else
            if (((string)Application["FacultyImage"] == string.Empty) || (string)Application["FacultyImage"] == null)
                FacultyImage = "Default.jpg";
            else
                FacultyImage = (string)Application["FacultyImage"];
        PhotoBox.ImageUrl = FacultyImage;

        return FacultyImage;
    }
}
