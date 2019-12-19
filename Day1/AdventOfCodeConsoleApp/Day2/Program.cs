using System;
using System.Collections.Generic;
using System.Linq;

namespace Day2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            // 0 based

            // handle each function type:
            // 1 => Addition
            // 2 => Multiplication
            // 99 => Halt
            // Once you're done processing an opcode, move to the next one by stepping forward 4 positions.

            // Before running the program, replace position 1 with the value 12 and replace position 2 with the value 2. 
            string intcodeInput = "1,0,0,3,1,1,2,3,1,3,4,3,1,5,0,3,2,1,9,19,1,19,5,23,2,6,23,27,1,6,27,31,2,31,9,35,1,35,6,39,1,10,39,43,2,9,43,47,1,5,47,51,2,51,6,55,1,5,55,59,2,13,59,63,1,63,5,67,2,67,13,71,1,71,9,75,1,75,6,79,2,79,6,83,1,83,5,87,2,87,9,91,2,9,91,95,1,5,95,99,2,99,13,103,1,103,5,107,1,2,107,111,1,111,5,0,99,2,14,0,0";
            
            List<int> intcodeParsedInput = intcodeInput.Split(',').Select(int.Parse).ToList();

            for (int noun = 0; noun <= 100; noun++)
            {
                for (int verb = 0; verb <= 100; verb++)
                {
                    var startingIntcode = new List<int>(intcodeParsedInput);
                    startingIntcode[1] = noun;
                    startingIntcode[2] = verb;
                    var finalIntcode = RunIntcode(0, startingIntcode);
                    if (finalIntcode[0] == 19690720)
                    {
                        Console.WriteLine($"noun {noun}");
                        Console.WriteLine($"verb {verb}");
                    }
                }
            }
            
            // What value is left at position 0 after the program halts?
            Console.WriteLine(intcodeParsedInput[0]);

            List<int> RunIntcode(int currentIndex, List<int> currentIntcode)
            {
                var opcode = currentIntcode[currentIndex];
                var firstPosition = currentIntcode[currentIndex + 1];
                var secondPosition = currentIntcode[currentIndex + 2];
                var overwritePosition = currentIntcode[currentIndex + 3];

                int value = 0;
                switch (opcode)
                {
                    case 1:
                        value = currentIntcode[firstPosition] + currentIntcode[secondPosition];
                        break;
                    case 2:
                        value = currentIntcode[firstPosition] * currentIntcode[secondPosition];
                        break;
                    case 99:
                        return currentIntcode;
                }
                currentIntcode[overwritePosition] = value;
                return RunIntcode(currentIndex + 4, currentIntcode);
            }
        }
    }
}