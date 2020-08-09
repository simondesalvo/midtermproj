using System;
using System.Collections.Generic;
using System.Text;

namespace midtermproj
{
    class Menu
    {
        public static List<string> mainMenu = new List<string>
        {
            "Add Member",
            "Display Member",
            "Remove Member",
            "Display Fees and Points",
            "Quit"
        };

        public static void DisplayMainMenu()
        {
            Console.Clear();
            Utility.PrintGreen("Hello! Welcome to the IHeartDiamonds: Clubs Manager!");
            for (int i = 0; i <mainMenu.Count; i++)
            {
                Utility.PrintGreen($"{i+1}. {mainMenu[i]} ");
            }
            Console.WriteLine("");
            Validate.NumberRange($"Please select an option from (please input 1 - {mainMenu.Count}).",mainMenu.Count);
        }
    }
}
