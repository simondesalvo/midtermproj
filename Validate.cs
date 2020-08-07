using System;
using System.Collections.Generic;
using System.Text;

namespace midtermproj
{
    class Validate
    {
        public static int Integer(string message)
        {
            string input = "";
            int intInput = -1;
            input = Utility.GetInput(message);
            while (int.TryParse(input,out intInput))
            {
                Console.Beep();
                input = Utility.GetInput(message);
            }
            return = intInput;

        }
        public static bool YesNo(string message)
        {
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

    }

}
