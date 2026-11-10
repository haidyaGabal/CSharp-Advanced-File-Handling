
using Files.Json;
using System.Text;

namespace Files
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var items = CreateSampleItems();

            var explorer = new SimpleFileExplorer();
            var fileReader = new WaysToReadAndWriteOnFiles();
            var converter = new ItemJsonConverter();

            bool running = true;

            while (running)
            {
                Console.Clear();
                Console.WriteLine("====================================");
                Console.WriteLine("       ADVANCED FILE HANDLING");
                Console.WriteLine("====================================");
                Console.WriteLine("1. Directory Operations");
                Console.WriteLine("2. File Explorer");
                Console.WriteLine("3. File Reading Techniques");
                Console.WriteLine("4. File Helper Operations");
                Console.WriteLine("5. Item Management - Text File");
                Console.WriteLine("6. JSON Operations");
                Console.WriteLine("0. Exit");
                Console.WriteLine("====================================");

                Console.Write("Choose an option: ");
                string choice = Console.ReadLine() ?? "";

                switch (choice)
                {
                    case "1":
                        RunAction(() => DirectoryMenu());
                        break;

                    case "2":
                        RunAction(() => FileExplorerMenu(explorer));
                        break;

                    case "3":
                        RunAction(() => ReadingMenu(fileReader));
                        break;

                    case "4":
                        RunAction(() => FileHelperMenu());
                        break;

                    case "5":
                        RunAction(() => SaveItemsToTextFile(items));
                        break;

                    case "6":
                        RunAction(() => JsonMenu(items, converter));
                        break;

                    case "0":
                        running = false;
                        Console.WriteLine("Goodbye!");
                        break;

                    default:
                        Console.WriteLine("Invalid choice!");
                        Pause();
                        break;
                }
            }
        }

        // Sample data
        static List<ItemModel> CreateSampleItems()
        {
            return new List<ItemModel>
            {
                new() { Id = 1, Name = "Notebook", Price = 44.43m, Quantity = 29 },
                new() { Id = 2, Name = "Pen", Price = 12.50m, Quantity = 100 },
                new() { Id = 3, Name = "Pencil", Price = 5.75m, Quantity = 80 },
                new() { Id = 4, Name = "Eraser", Price = 3.25m, Quantity = 50 },
                new() { Id = 5, Name = "Ruler", Price = 8.90m, Quantity = 35 },
                new() { Id = 6, Name = "Backpack", Price = 350.00m, Quantity = 15 },
                new() { Id = 7, Name = "Calculator", Price = 225.50m, Quantity = 12 },
                new() { Id = 8, Name = "Marker", Price = 18.75m, Quantity = 45 },
                new() { Id = 9, Name = "Highlighter", Price = 15.00m, Quantity = 60 },
                new() { Id = 10, Name = "Stapler", Price = 75.25m, Quantity = 20 },
                new() { Id = 11, Name = "Paper Clips", Price = 10.50m, Quantity = 90 },
                new() { Id = 12, Name = "Folder", Price = 22.00m, Quantity = 40 },
                new() { Id = 13, Name = "Drawing Book", Price = 55.75m, Quantity = 25 },
                new() { Id = 14, Name = "Water Bottle", Price = 95.00m, Quantity = 18 },
                new() { Id = 15, Name = "Pencil Case", Price = 65.50m, Quantity = 30 }
            };
        }

        // 1. Directory operations
        static void DirectoryMenu()
        {
            WorkingWithDirectories directories = new WorkingWithDirectories();

            directories.DisplayMessage();
        }

        // 2. File explorer
        static void FileExplorerMenu(SimpleFileExplorer explorer)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("===== FILE EXPLORER =====");
                Console.WriteLine("1. List files and folders");
                Console.WriteLine("2. Create directory");
                Console.WriteLine("3. Create file");
                Console.WriteLine("4. Append to file");
                Console.WriteLine("0. Back");
                Console.Write("Choose: ");

                string choice = Console.ReadLine() ?? "";

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

                    case "0":
                        return;

                    default:
                        Console.WriteLine("Invalid choice!");
                        break;
                }

                Pause();
            }
        }

        // 3. File reading techniques
        static void ReadingMenu(WaysToReadAndWriteOnFiles reader)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("===== FILE READING TECHNIQUES =====");
                Console.WriteLine("1. Read small text file");
                Console.WriteLine("2. Read text lines lazily");
                Console.WriteLine("3. Read large text file");
                Console.WriteLine("4. Read all bytes");
                Console.WriteLine("5. Read large binary file");
                Console.WriteLine("6. Memory mapped file");
                Console.WriteLine("0. Back");
                Console.Write("Choose: ");

                string choice = Console.ReadLine() ?? "";

                switch (choice)
                {
                    case "1":
                        reader.SmallText();
                        break;

                    case "2":
                        reader.TextLinesLazy();
                        break;

                    case "3":
                        reader.LargeTextFile();
                        break;

                    case "4":
                        reader.ReadAllBytes();
                        break;

                    case "5":
                        reader.BigBytesFile();
                        break;

                    case "6":
                        reader.MemoryMappedFile();
                        break;

                    case "0":
                        return;

                    default:
                        Console.WriteLine("Invalid choice!");
                        break;
                }

                Pause();
            }
        }

        // 4. File helper operations
        static void FileHelperMenu()
        {
            Console.Clear();
            Console.WriteLine("===== FILE HELPER =====");
            Console.WriteLine("1. Create / overwrite file");
            Console.WriteLine("2. Append to file");
            Console.WriteLine("3. Read file");
            Console.WriteLine("4. Delete file");
            Console.WriteLine("0. Back");
            Console.Write("Choose: ");

            string choice = Console.ReadLine() ?? "";

            if (choice == "0")
                return;

            Console.Write("Enter file path: ");
            string path = Console.ReadLine() ?? "";

            switch (choice)
            {
                case "1":
                    Console.Write("Enter content: ");
                    string content = Console.ReadLine() ?? "";
                    FileHelper.Create(path, content);
                    Console.WriteLine("File created successfully!");
                    break;

                case "2":
                    Console.Write("Enter text: ");
                    string text = Console.ReadLine() ?? "";
                    FileHelper.Append(path, text, true);
                    Console.WriteLine("Content appended successfully!");
                    break;

                case "3":
                    Console.WriteLine(FileHelper.ReadAll(path));
                    break;

                case "4":
                    bool deleted = FileHelper.Delete(path);
                    Console.WriteLine(deleted
                        ? "File deleted successfully!"
                        : "File does not exist.");
                    break;

                default:
                    Console.WriteLine("Invalid choice!");
                    break;
            }
        }

        // 5. Save items to text file
        static void SaveItemsToTextFile(List<ItemModel> items)
        {
            string content = ConvertToString(items);

            FileHelper.Create("data.txt", content);

            Console.WriteLine("Items saved to data.txt successfully!");
            Console.WriteLine();
            Console.WriteLine(content);
        }

        static string ConvertToString(List<ItemModel> data)
        {
            StringBuilder stringBuilder = new StringBuilder();

            foreach (ItemModel item in data)
            {
                stringBuilder.AppendLine($"Id#{item.Id}");
                stringBuilder.AppendLine($"Name#{item.Name}");
                stringBuilder.AppendLine($"Price#{item.Price}");
                stringBuilder.AppendLine($"Quantity#{item.Quantity}");
                stringBuilder.AppendLine("--------------------");
            }

            return stringBuilder.ToString();
        }

        // 6. JSON operations
        static void JsonMenu(
            List<ItemModel> items,
            ItemJsonConverter converter)
        {
            Console.Clear();
            Console.WriteLine("===== JSON OPERATIONS =====");
            Console.WriteLine("1. Convert items to JSON");
            Console.WriteLine("2. Save items to JSON file");
            Console.WriteLine("3. Read JSON file and convert back");
            Console.WriteLine("0. Back");
            Console.Write("Choose: ");

            string choice = Console.ReadLine() ?? "";

            switch (choice)
            {
                case "1":
                    string json = converter.Convert(items);
                    Console.WriteLine(json);
                    break;

                case "2":
                    string jsonContent = converter.Convert(items);
                    FileHelper.Create("items.json", jsonContent);
                    Console.WriteLine("Items saved to items.json!");
                    break;

                case "3":
                    string content = FileHelper.ReadAll("items.json");
                    List<ItemModel> result = converter.ConvertBack(content);

                    Console.WriteLine($"Number of items: {result.Count}");

                    foreach (ItemModel item in result)
                    {
                        Console.WriteLine(
                            $"{item.Id} | {item.Name} | {item.Price} | {item.Quantity}");
                    }
                    break;

                case "0":
                    return;

                default:
                    Console.WriteLine("Invalid choice!");
                    break;
            }
        }

        // Handle errors without closing the application
        static void RunAction(Action action)
        {
            try
            {
                action();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            Pause();
        }

        static void Pause()
        {
            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
