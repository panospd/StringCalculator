using StringCalculator.core;
using System;
using System.Text.RegularExpressions;

namespace StringCalculator.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to String calculator!");
            Console.WriteLine(string.Empty);
            Usage();
            Console.WriteLine(string.Empty);
            
            var userInput = string.Empty;

            while(userInput != "exit")
            {
                Console.WriteLine("Please provide some numbers to calculate");
                var command = Console.ReadLine();
                Console.WriteLine("Result: " + Calculator.Add(Regex.Unescape(command)));

                Console.WriteLine("Type 'exit' if you want to exit the program. Press any other key to do more calculations.");
                userInput = Console.ReadLine();
            }
        }

        private static void Usage()
        {
            Console.WriteLine("How to use:");
            Console.WriteLine("By default the delimiter is ','. Therefore by typing '1,2,3 the program will return 6'");
            Console.WriteLine("You can provide a custom delimiter like: '//;\n1;2;3'. This will return 6.");
            Console.WriteLine("You can provide multiple delimiters like: '//[***][%]1%2***3'. This will return 6 again.");
        }
    }
}
