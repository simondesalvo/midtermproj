using System;
using System.Collections.Generic;
using System.Text;

namespace midtermproj
{
    class Utility
    {
        public static bool LoopProgram(string message)
        {
            bool end = false;
            string cont = "";
            Console.WriteLine(message);
            while (cont.ToLower() != "n")
            {
                cont = Console.ReadLine().ToLower();
                if (cont == "y")
                {
                    end = false;
                    break;
                }
                else if (cont == "n")
                {
                    end = true;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter (y) to continue and (n) to stop.");
                }
            }
            return end;
        }
        public static string GetInput(string message)
        {
            string input = "";
            PrintGreen(message);
            input = Console.ReadLine();
            return input;

        }
        public static void PrintGreen(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ResetColor();
        }
        public static void PrintYellow(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}

