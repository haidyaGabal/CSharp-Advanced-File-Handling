using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Files
{
    internal class SimpleFileExplorer
    {
        public void List()
        {
            Console.WriteLine("Welcome to Simple File Explorer app");
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
        }
        public void CreateDirectory()
        {
            Console.WriteLine("Please enter folder path:");

            string sInput = Console.ReadLine();

            // Check if the input is empty.
            if (string.IsNullOrWhiteSpace(sInput))
            {
                Console.WriteLine("Path cannot be empty!");
                return;
            }

            // Create DirectoryInfo object.
            DirectoryInfo directoryInfo = new DirectoryInfo(sInput);

            // Check whether the directory already exists.
            if (directoryInfo.Exists)
            {
                Console.WriteLine("Directory already exists!");
                return;
            }

            // Create the directory.
            directoryInfo.Create();

            Console.WriteLine("Directory created successfully!");
        }
        public void CreateFile()
        {
            Console.WriteLine("Please enter directory path:");

            string directoryPath = Console.ReadLine();

            // Check if the input is empty.
            if (string.IsNullOrWhiteSpace(directoryPath))
            {
                Console.WriteLine("Path cannot be empty!");
                return;
            }

            // Check whether the directory exists.
            if (!Directory.Exists(directoryPath))
            {
                Console.WriteLine("Directory does not exist!");
                return;
            }

            Console.WriteLine("Please enter file name:");

            string fileName = Console.ReadLine();

            // Check if the file name is empty.
            if (string.IsNullOrWhiteSpace(fileName))
            {
                Console.WriteLine("File name cannot be empty!");
                return;
            }

            // Combine directory path and file name.
            string filePath = Path.Combine(directoryPath, fileName);

            // Create file and write content.
            File.WriteAllText(filePath, "Hello! This is my first file.");

            Console.WriteLine("File created successfully!");
        }
        public void AppendToFile()
        {
            Console.WriteLine("Please enter directory path:");

            string directoryPath = Console.ReadLine();

            // Check if the directory path is empty.
            if (string.IsNullOrWhiteSpace(directoryPath))
            {
                Console.WriteLine("Path cannot be empty!");
                return;
            }

            // Check whether the directory exists.
            if (!Directory.Exists(directoryPath))
            {
                Console.WriteLine("Directory does not exist!");
                return;
            }

            Console.WriteLine("Please enter file name:");

            string fileName = Console.ReadLine();

            // Check if the file name is empty.
            if (string.IsNullOrWhiteSpace(fileName))
            {
                Console.WriteLine("File name cannot be empty!");
                return;
            }

            // Combine directory path and file name.
            string filePath = Path.Combine(directoryPath, fileName);

            Console.WriteLine("Please enter text to append:");

            string content = Console.ReadLine();

            // Append text to the file.
            // If the file does not exist, it will be created.
            File.AppendAllText(filePath, content + Environment.NewLine);

            Console.WriteLine("Text appended successfully!");
        }

    }
}
