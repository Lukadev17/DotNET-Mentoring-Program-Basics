namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            string startPath = "C:\\Users\\Luka_Gagnidze\\Desktop\\materials";

            var visitor = new FileSystemVisitor(startPath);

            foreach (var item in visitor.Traverse())
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("=== Only .pdf Files ===");

            var visitorWithFilter = new FileSystemVisitor(startPath, path => path.EndsWith(".docx"));

            foreach (var item in visitorWithFilter.Traverse())
            {
                Console.WriteLine(item);
            }
        }
    }
}
