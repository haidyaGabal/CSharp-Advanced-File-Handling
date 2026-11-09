using System.Text;

namespace Files
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            //  WorkingWithDirectories directories = new WorkingWithDirectories();

            // directories.DisplayMessage();

            //SimpleFileExplorer explorer = new SimpleFileExplorer();

            //try
            //{
            //    while (true)
            //    {
            //        Console.WriteLine("\n===== Simple File Explorer =====");
            //        Console.WriteLine("1. List files and folders");
            //        Console.WriteLine("2. Create directory");
            //        Console.WriteLine("3. Create file");
            //        Console.WriteLine("4. Append to file");
            //        Console.WriteLine("5. Exit");

            //        Console.Write("Choose an option: ");
            //        string choice = Console.ReadLine();

            //        switch (choice)
            //        {
            //            case "1":
            //                explorer.List();
            //                break;

            //            case "2":
            //                explorer.CreateDirectory();
            //                break;

            //            case "3":
            //                explorer.CreateFile();
            //                break;

            //            case "4":
            //                explorer.AppendToFile();
            //                break;

            //            case "5":
            //                Console.WriteLine("Goodbye!");
            //                return;

            //            default:
            //                Console.WriteLine("Invalid choice!");
            //                break;
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine($"An error occurred: {ex.Message}");
            //}
            


            var items = new List<ItemModel>
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

           

            var content = ConvertToString(items);
            FileHelper.Create("data.txt", content);

            static string ConvertToString(List<ItemModel> data)
            {
                StringBuilder stringBuilder = new StringBuilder();

                foreach (ItemModel item in data)
                {
                    stringBuilder.AppendLine($"Id#{item.Id}");
                    stringBuilder.AppendLine($"Name#{item.Name}");
                    stringBuilder.AppendLine($"Price#{item.Price}");
                    stringBuilder.AppendLine($"Quantity#{item.Quantity}");

                    // Separate each item
                    stringBuilder.AppendLine();
                }

                return stringBuilder.ToString();
            }
        }
    }
}
