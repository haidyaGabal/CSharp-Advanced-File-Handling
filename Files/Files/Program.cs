namespace Files
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            WorkingWithDirectories directories = new WorkingWithDirectories();

            // directories.DisplayMessage();

            SimpleFileExplorer explorer = new SimpleFileExplorer();

            try
            {
                while (true)
                {
                    Console.WriteLine("\n===== Simple File Explorer =====");
                    Console.WriteLine("1. List files and folders");
                    Console.WriteLine("2. Create directory");
                    Console.WriteLine("3. Create file");
                    Console.WriteLine("4. Append to file");
                    Console.WriteLine("5. Exit");

                    Console.Write("Choose an option: ");
                    string choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            explorer.List();
                            break;

                        case "2":
                            explorer.CreateDirectory();
                            break;

                        case "3":
                            explorer.CreateFile();
                            break;

                        case "4":
                            explorer.AppendToFile();
                            break;

                        case "5":
                            Console.WriteLine("Goodbye!");
                            return;

                        default:
                            Console.WriteLine("Invalid choice!");
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
