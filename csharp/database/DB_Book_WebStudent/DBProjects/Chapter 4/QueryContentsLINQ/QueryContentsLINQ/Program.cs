using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QueryContentsLINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            // Modify this path as necessary.
            string startFolder = @"c:\program files\Microsoft Visual Studio 9.0\";

            // Take a snapshot of the file system.
            IEnumerable<System.IO.FileInfo> fileList = GetFiles(startFolder);

            string searchTerm = @"Visual Studio";

            // Search the contents of each file. The queryMatchingFiles is an IEnumerable<string>.
            var queryMatchingFiles =
                from file in fileList
                where file.Extension == ".htm"
                let fileText = GetFileText(file.FullName)
                where fileText.Contains(searchTerm)
                select file.FullName;

            // Execute the query.
            Console.WriteLine("The term \"{0}\" was found in:", searchTerm);
            foreach (string filename in queryMatchingFiles)
            {
                Console.WriteLine(filename);
            }

            // Keep the console window open in debug mode.
            Console.WriteLine("Press any key to exit ...");
            Console.ReadKey();
        }
        // Read the contents of the file.
        static string GetFileText(string name)
        {
            string fileContents = String.Empty;

            // If the file has been deleted since we took the snapshot, ignore it and return the empty string.
            if (System.IO.File.Exists(name))
                fileContents = System.IO.File.ReadAllText(name);
            return fileContents;            
        }
        // This method assumes that the application has discovery permissions for all folders under the specified path.
        static IEnumerable<System.IO.FileInfo> GetFiles(string path)
        {
            if (!System.IO.Directory.Exists(path))
                throw new System.IO.DirectoryNotFoundException();

            string[] fileNames = null;
            List<System.IO.FileInfo> files = new List<System.IO.FileInfo>();

            fileNames = System.IO.Directory.GetFiles(path, "*.*", System.IO.SearchOption.AllDirectories);            
            foreach (string name in fileNames)
            {
                files.Add(new System.IO.FileInfo(name));
            }
            return files;
        }
    }
}
