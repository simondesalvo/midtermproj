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

        public static void MainMenu()
        {
            Console.Clear();
            Utility.PrintGreen("Hello! Welcome to the IHeartDiamonds: Clubs Manager! Please select an option below!");
            for (int i = 0; i <mainMenu.Count; i++)
            {
                Utility.PrintGreen($"{i+1}. {mainMenu[i]} ");
            }

        }
    }
}
