using System;
using System.IO;

namespace AdventOfCodeConsoleApp
{
    internal class Program
    {
        private static readonly string textFile = @"C:\Work\PizzaAndProgramming\AdventOfCode\Day1\puzzleInput.txt";

        public static void Main(string[] args)
        {
//take its mass, divide by three, round down, and subtract 2.
            string[] lines = File.ReadAllLines(textFile);
            double sumOfLines = 0;
            foreach (var line in lines)
            {
                var number = double.Parse(line);
                CalculateFuel(number);
            }
            Console.WriteLine(sumOfLines);

            void CalculateFuel(double number)
            {
                var roundedDownNumber = Math.Floor(number / 3);
                if (roundedDownNumber <= 2)
                {
                    return;
                }
                var finalFuelNumber = roundedDownNumber - 2;
                sumOfLines += finalFuelNumber;
                CalculateFuel(finalFuelNumber);
            }
        }
        
    }
}