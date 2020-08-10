using System;
using System.Collections.Generic;
using System.Text;

namespace midtermproj
{
    class Utility
    {

        public static string GetInput(string message)
        {
            //used to display a message in green, then return the user's response
            
            string input = "";
            PrintGreen(message);
            input = Console.ReadLine();
            return input;

        }
        public static void PrintGreen(string message)
        {
            //Makes text green. Nothing too fancy

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ResetColor();
        }
        public static void PrintCyan(string message)
        {
            //Makes text cyan. Nothing too fancy

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(message);
            Console.ResetColor();
        }
        public static void PrintYellow(string message)
        {
            //Makes text yellow. Maybe good for error messages?
            
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(message);
            Console.ResetColor();
        }
        public static string GetKeyInput(string message)
        {
            //used to display a message in green, then return the user's response
            string input = "";
            PrintGreen(message);
            input = Console.ReadKey().KeyChar.ToString();
            return Validate.InputClub(input);
        }
    }
}

