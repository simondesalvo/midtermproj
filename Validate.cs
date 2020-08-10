using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace midtermproj
{
    class Validate
    {
        public static int Integer(string message)
        {
            //validates if a number is an integer. additional parameters can be added via regex

            string input = "";
            int intInput = -1;
            input = Utility.GetInput(message);
            while (!int.TryParse(input,out intInput))
            {

                input = Utility.GetInput(message);
            }

            return intInput;
        }
        public static bool YesNo(string message)
        {
            //validates a Yes or no response being entered. returns true if yes is selected, false if no is selected.

            string input = "";
            input = Utility.GetInput(message);
            bool end = false;
            while (!end)
            {
                if (input.ToLower() == "y")
                {
                    return !end;
                }
                else if (input.ToLower() == "n")
                {
                    Console.Clear();
                    return end;
                }
                else
                {
                    input = Utility.GetInput("Please enter  \"y\" for yes or \"n\" for no.");
                }
            }
            return end;
        }
        public static int NumberRange(string message,int range)
        {
            int output = -1;
            while (true)
            {
                output = Integer(message);
                if (output > range||output<0)
                {
                    
                    continue;
                }
                else
                {
                    return output;
                }
            }
        }
        public static string InputClub(string c)
        {
            Regex regex = new Regex("^[sm]$");
            while (!regex.IsMatch(c.ToLower()))
            {
                Console.Clear();
                Utility.PrintGreen("Please enter \"s\" for Single-Club membership or \"m\" for Multi-Club membership.");
                c = Console.ReadKey().KeyChar.ToString();
            }
            return c.ToLower();
        }

        }
    }

