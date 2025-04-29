namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var visitor = new FileSystemVisitor("C:\\Users\\Luka_Gagnidze\\Desktop\\materials", path => path.EndsWith(".txt"));

            visitor.Start += (s, e) => Console.WriteLine("Search started!");
            visitor.Finish += (s, e) => Console.WriteLine("Search finished!");

            visitor.FileFound += (s, e) =>
            {
                Console.WriteLine($"File found: {e.Path}");
            };

            visitor.DirectoryFound += (s, e) =>
            {
                Console.WriteLine($"Directory found: {e.Path}");
               
                if (e.Path.Contains("\\bin"))
                {
                    e.Exclude = true;
                }
            };

            visitor.FilteredFileFound += (s, e) =>
            {
                Console.WriteLine($"Filtered File: {e.Path}");
                
                if (e.Path.Contains("stop.txt"))
                {
                    e.Abort = true;
                }
            };

            visitor.FilteredDirectoryFound += (s, e) =>
            {
                Console.WriteLine($"Filtered Directory: {e.Path}");
            };

            
            foreach (var item in visitor.Traverse())
            {
                Console.WriteLine($"Result: {item}");
            }
        }
    }
}
