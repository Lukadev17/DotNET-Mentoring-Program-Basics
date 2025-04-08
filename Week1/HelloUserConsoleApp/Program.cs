using HelloUserClassLibrary;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length == 0)
        {
            Console.WriteLine("Please provide a username.");
            return;
        }

        string username = args[0];
        string message = HelloUserService.HelloUser(username);
        Console.WriteLine(message);
    }
}