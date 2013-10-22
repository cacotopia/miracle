using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Data.EntityClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EDModel
{
    public partial class EDModelForm : Form
    {
        public EDModelForm()
        {
            InitializeComponent();
        }
        private void cmdShow_Click(object sender, EventArgs e)
        {
            string cmdString = "SELECT fname.faculty_name FROM EDModelEntitiesConnString.Faculty as fname";
            EntityConnection Conn = new EntityConnection("name=EDModelEntitiesConnString");
            Conn.Open();
            EntityCommand cmd = Conn.CreateCommand();
            cmd.CommandText = cmdString;
            EntityDataReader rd = cmd.ExecuteReader(CommandBehavior.SequentialAccess);
            FacultyList.Items.Clear();
            while (rd.Read())
            {
                FacultyList.Items.Add(rd["faculty_name"]);
            }
            Conn.Close();
        }
    }
}
