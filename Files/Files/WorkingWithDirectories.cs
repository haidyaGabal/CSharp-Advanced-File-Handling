using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Files
{
    public class WorkingWithDirectories
    {
        public void DisplayMessage()
        {
            Console.WriteLine("Welcome to file explorer app");
            Console.WriteLine("Please enter folder path:");

            string sInput = Console.ReadLine();

            // If the user enters nothing, use the current directory.
            if (string.IsNullOrWhiteSpace(sInput))
            {
                sInput = Directory.GetCurrentDirectory();
            }

            // Convert the entered path into an absolute path.
            string spath = Path.GetFullPath(sInput);

            // Check whether the directory exists.
            if (!Directory.Exists(spath))
            {
                Console.WriteLine("Directory does not exist!");
                return;
            }

            // Display the current directory path.
            Console.WriteLine($"\nCurrent Path: {spath}");

            // Get and display all subdirectories.
            Console.WriteLine("\nFolders:");

            string[] folders = Directory.GetDirectories(spath);

            foreach (var folder in folders)
            {
                Console.WriteLine(Path.GetFileName(folder));
            }

            // Get and display all files.
            Console.WriteLine("\nFiles:");

            string[] files = Directory.GetFiles(spath);

            foreach (var file in files)
            {
                Console.WriteLine(Path.GetFileName(file));
            }
            Console.WriteLine("\nMore inforamation about files:");
            // Display files
            Console.WriteLine("\nFiles:");
            // Create DirectoryInfo object
            DirectoryInfo directoryInfo = new DirectoryInfo(spath);
            FileInfo[] filesinfo = directoryInfo.GetFiles();

            foreach (FileInfo file in filesinfo)
            {
                Console.WriteLine($"Name: {file.Name}");
                Console.WriteLine($"Size: {file.Length} bytes");
                Console.WriteLine($"Extension: {file.Extension}");
                Console.WriteLine("----------------------");
            }


            ////////////////// More Methods //////////////////

            Console.WriteLine("\n////////// More Methods //////////");

            // Gets the current working directory of the application.
            string currentPath = Directory.GetCurrentDirectory();
            Console.WriteLine($"Current Directory: {currentPath}");

            // Checks whether the specified directory exists.
            bool exists = Directory.Exists(currentPath);
            Console.WriteLine($"Directory Exists: {exists}");

            // Returns an array of all subdirectory paths.
            string[] folders2 = Directory.GetDirectories(currentPath);
            Console.WriteLine($"Number of Folders: {folders2.Length}");

            // Returns an array of all file paths.
            string[] files2 = Directory.GetFiles(currentPath);
            Console.WriteLine($"Number of Files: {files2.Length}");

            // Converts a path into an absolute path.
            string fullPath = Path.GetFullPath(currentPath);
            Console.WriteLine($"Full Path: {fullPath}");

            // Extracts the final name from a path.
            string name = Path.GetFileName(currentPath);
            Console.WriteLine($"Directory Name: {name}");
        }
    }
}