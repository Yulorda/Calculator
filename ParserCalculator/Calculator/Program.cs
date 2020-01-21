using System;
using ParserCalculator;

namespace ConsoleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            ParserFunction.AddFunction("pi", new PiFunction());

            for (; ;)
            {
                Console.WriteLine("Результат: " + Parser.Start(Console.ReadLine()));
            }
        }
    }
}
