using System;

namespace Task1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Enter lines of text, type exit to quit");

            while (true)
            {
                try
                {
                    string input = Console.ReadLine();

                    if (input == "exit")
                    {
                        break;
                    }

                    if (string.IsNullOrEmpty(input))
                    {
                        throw new ArgumentException("Input cannot be empty");
                    }

                    Console.WriteLine($"first charaacter: {input.Trim()[0]}");
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error: {e.Message}");
                }
            }
        }
    }
}