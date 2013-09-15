//LINQToFileDirectoryDorm.cs
//using LINQ to search directories and determine file types.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;
namespace LINQToFileDirectory 
{
    public class LINQToDirectoryForm:Form 
	{
	  string currentDirectory;
	  Dictionary<string,int> found = new Dictionary<string,int>();
	  
	  public LINQToFileDirectoryForm()
	  {
	  InitializeComponent();
	  }
	  private void searchButton_Click(object sender,EventArgs e)
	  {
	    if (pathTextBox.Text !=string.Empty && !Directory.Exists(pathTextBox.Text)) 
		{
		 MessageBox.Show("Invalid Directory","Error",MessageBoxbuttons.OK,MessageBoxIcon.Error);
		}else 
		{
		 if(pathTextBox.Text== string.Empty) 
		    currentDirectory= Directory.GetCurrentDirectory();
		 else
		    currentDirectory =pathTextBox.Text
			directoryTextBox.Text= currentDirectory;
			pathTextBox.Clear();
			resultsTextBox.Clear();
			SearchDirectory(currentDirectory);
			
			CleanDirectory(currentDirectory);
			
			foreach(var current in found.Keys)
			{
			resultsTextBox.AppendText(string.Format("Found {0} {1} files.\r\n"),found[current],current);
			}//end foreach
		
		}
	  }
	  private void SearchDirectory(string folder)
	  {
	  string[] files = Directory.GetFiles(folder);
	  string[] directories= Directory.GetDirectories(folder);
	  
	  var extensions = (from file in files 
	                    select Path.GetExtensions(file)).Distinct();
	  foreach(var extension in extensions) 
	  {
	  var temp = extension;
	  var extensionCount = (from file in files 
	                         where Path.GetExtension(file)==temp
							 select file).Count;
	  if (found.ContainKey(extension))
	      found[extension] += extensionCount;
	  else 
	      found.Add(extension,extensionCount);
	  }
	  foreach(var subdirectory in directories)
	  {
	  SearchDirectory(subdirectory);
	  }
	  }
	  private void CleanDirectory(string folder)
	  {
	  string[] files = Directory.GetFiles(folder);
	  string[] directories= Directory.GetDirectoties(folder);
	  var backFiles= (from file in files 
	                  where Path.GetExtension(file)== ".bak"
					  select file);
	  foreach(var backup in backFiles)
	  {
	  DialogResult result= MessageBox.Show("Found backup file " + Path.GetFileName(backup) +".Delete?","Delete Backup",
	                                       MessageBoxButtons.YesNo,MessageBoxIcon.Question);
	  if(result == DialogResult.Yes) 
	  {
	  File.Delete(backup);
	  --found[".bak"];
	  if (found[".bak"] ==0)
	     found.Remove(".bak");
	  }
	  }
	  foreach(var subdirectory in directories)
	  {
	  CleanDirectory(subdirectory);
	  }
	  }
	  
	  
	}
}