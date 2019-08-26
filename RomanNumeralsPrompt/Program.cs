using RomanNumeralsEngine;
using System;

namespace RomanNumeralsPrompt
{
    class Program
    {
        static void Main(string[] args)
        {
            var engine = new RomanEngine();
            Console.WriteLine("I convert Decimals to Roman Numerals and vice versa.");
            Console.Write("Enter one or the other: ");
            var input = Console.ReadLine();
            var output = string.Empty;
            while (input.ToLower() != "exit")
            {
                output = int.TryParse(input, out var result) 
                    ? engine.Convert(result) 
                    : engine.Convert(input.ToUpper()).ToString();
                Console.WriteLine($"'{input.ToUpper()}' converted is '{output}'");
                Console.Write("Enter a Roman Numeral or a Decimal (exit to leave): ");
                input = Console.ReadLine();
            }
            Console.WriteLine("Thankyou for using the Roman Numeral Converter...");
        }
    }
}
