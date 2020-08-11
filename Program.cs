using System;

using System.Threading;

using System.Collections.Generic;
using System.IO;


namespace midtermproj
{
    class Program
    {
        static void Main(string[] args)
        {
            Club club = new Club();
            StartUp();
            club = Menu.SelectClub();
            bool end = false;


            while (!end)
            {
                end = Menu.DisplayMainMenu(club);
            }
            Console.Clear();
            Utility.PrintGreen("Thank you for using the IHeartDiamond: Clubs manager! Have a nice day!");
            Console.Beep(1000,200); Console.Beep(500, 200); Console.Beep(250, 200); Console.Beep(125, 200); Console.Beep(60, 200);

        }
        public static void StartUp()
        {
            MultiClubMember.StartUp();
            SingleClubMember.Startup();
        }
    }
}
