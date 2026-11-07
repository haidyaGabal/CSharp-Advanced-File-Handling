using System;
using System.Collections.Generic;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Files
{
    internal class WaysToReadAndWriteOnFiles
    {
        public void SmallText()
        {
            string path = @"Data\notes.txt";

            // Read the entire file as one string
            string text = File.ReadAllText(path);

            Console.WriteLine("File Content:");
            Console.WriteLine(text);

            // Read the file into an array of lines
            string[] lines = File.ReadAllLines(path);

            Console.WriteLine("\nFile Lines:");

            foreach (string line in lines)
            {
                Console.WriteLine(line);
            }
        }
        public void TextLinesLazy()
        {
            //Read a text file line by line without loading all lines into memory first
            string path = @"Data\notes.txt";

            foreach (string line in File.ReadLines(path))
            {
                Console.WriteLine(line);
            }
        }
        public void LargeTextFile()
        {
            //deleing with stream
            //Read large text files efficiently using StreamReader
            //A StreamReader reads text from a file progressively instead of loading the entire file into memory
            // deleing with stream you must use keyword -->> using
            //using automatically closes the reader and releases resources
            string path = @"Data\large.txt";

            using (StreamReader reader = new StreamReader(path))
            {
                string line;

                while ((line = reader.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }
        
        }
        public void ReadAllBytes()
        {
            //like deleing with images
         
            string path = @"Data\image.jpg";

            byte[] bytes = File.ReadAllBytes(path);

            Console.WriteLine($"File size: {bytes.Length} bytes");

            Console.WriteLine("First 10 bytes:");

            for (int i = 0; i < Math.Min(10, bytes.Length); i++)
            {
                Console.WriteLine(bytes[i]);
            }
        }

        
        public void BigBytesFile()
        {
            //like deleing with vedio
            //Read or copy large binary files without loading the entire file into memory
            string sourcePath = @"Data\video.mp4";
            string destinationPath = @"Data\video-copy.mp4";

            byte[] buffer = new byte[8192];

            using (FileStream source = new FileStream(
                sourcePath, FileMode.Open, FileAccess.Read))
            using (FileStream destination = new FileStream(
                destinationPath, FileMode.Create, FileAccess.Write))
            {
                int bytesRead;

                while ((bytesRead = source.Read(buffer, 0, buffer.Length)) > 0)
                {
                    destination.Write(buffer, 0, bytesRead);
                }
            }

            Console.WriteLine("Video copied successfully!");
        

        }
        public void MemoryMappedFile()
        {//Access file contents through memory mapping
            string path = @"Data\notes.txt";

            using (var mappedFile = System.IO.MemoryMappedFiles.MemoryMappedFile.CreateFromFile(
                path,
                FileMode.Open,
                null,
                0,
                System.IO.MemoryMappedFiles.MemoryMappedFileAccess.Read))
            {
                using (var accessor = mappedFile.CreateViewAccessor(
                    0,
                    10,
                    System.IO.MemoryMappedFiles.MemoryMappedFileAccess.Read))
                {
                    byte[] buffer = new byte[10];

                    accessor.ReadArray(0, buffer, 0, buffer.Length);

                    string text = Encoding.UTF8.GetString(buffer);

                    Console.WriteLine(text);
                }
            }
        

         }

    }
}
