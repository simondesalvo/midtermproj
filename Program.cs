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
            club = Menu.SelectClub();
            bool end = false;

            StartUp();
            while (!end)
            {
                end = Menu.DisplayMainMenu(club);
            }
            Console.Clear();
            Utility.PrintGreen("Thank you for using the IHeartDiamond: Clubs manager! Have a nice day!");

        }
        public static void StartUp()
        {
            MultiClubMember.StartUp();
            SingleClubMember.Startup();
        }
    }
}
