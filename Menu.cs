using System;
using System.Collections.Generic;
using System.Text;

namespace midtermproj
{
    class Menu
    {
        
        public static List<string> mainMenu = new List<string>
        {
            "Check In",
            "Add Member",
            "Display Member",
            "Remove Member",
            "Display Fees and Points",
            "Quit"
        };

        public static void DisplayMainMenu()
        {
            Console.Clear();
            ClubClass c = new ClubClass();
            Single_Club_Member s = new Single_Club_Member();
            MultiClubMember m = new MultiClubMember();
            Utility.PrintGreen("Hello! Welcome to the IHeartDiamonds: Clubs Manager!");


            //ask what club they're at, for input into clubcheckin methods
            for (int i = 0; i <mainMenu.Count; i++)
            {
                Utility.PrintGreen($"{i+1}. {mainMenu[i]} ");
            }
            Console.WriteLine("");
            int input = Validate.NumberRange($"Please select an option from (please input 1 - {mainMenu.Count}).",mainMenu.Count);
            if (input == 1)
            {
                //check-in
                Console.WriteLine("Please input your ID number");
                string idString = Console.ReadLine();
                int idInt;
                int.TryParse(idString, out idInt);
                if (idInt >= 600)
                {
                    MultiClubMember.CheckIn(/*we need some way to input the clubName*/);
                }
                else if (idInt < 600)
                {
                    Single_Club_Member.CheckIn(/*same prob*/);
                }
                else
                {
                    Console.WriteLine("Uh oh.");
                }
            }
            else if (input == 2)
            {
                //add member
                Console.WriteLine("Would you like to sign up for a single club membership or a multi club membership?");
                ConsoleKeyInfo singMult = Console.ReadKey();
                if (singMult.Key == ConsoleKey.S)
                {
                    Console.WriteLine("Name?");
                    string newName = Console.ReadLine();
                    Console.WriteLine("Date?");
                    DateTime date = DateTime.Parse(Console.ReadLine());
                    c.PrintClubs();
                    Console.WriteLine("Club number?");
                    string club = Console.ReadLine();
                    int clubNum;
                    int.TryParse(club, out clubNum);
                    bool employee = true;
                    double bill = 10; //or anything we want as the default single club bill
                    int id = s.IdAssign();

                    Single_Club_Member newMemb = new Single_Club_Member(id, newName, date, clubNum, employee, bill);
                    //time to write to file.io
                }
                else if (singMult.Key == ConsoleKey.M)
                {
                    //same business as single, but with multiclub class
                }
            }
            else if (input == 3)
            {
                //display member
            }
            else if(input == 4)
            {
                //remove member
                Console.WriteLine("Input member number");
                //display member method
                Console.WriteLine();
                if (Validate.YesNo($"Are you sure you wish to delete {s.Name}?"))
                {
                    //remove file.io method
                }
                else
                {
                    //return to main menu
                }
                

            }
            else if (input == 5)
            {
                //display fees and points
                Console.WriteLine("Single or Multi");
                ConsoleKeyInfo singMult = Console.ReadKey();
                if (singMult.Key == ConsoleKey.S)
                {
                    Console.WriteLine("Member id?");
                    //display feepoints here
                }
                else if (singMult.Key == ConsoleKey.M)
                {
                    Console.WriteLine("Member ID?");
                    //display feepoints
                }
                else
                {
                    Console.WriteLine("Uh oh");
                }
            }
            else if (input == 6)
            {
                //quit
            }
            else
            {
                Console.WriteLine("Uh oh, not a valid input");
            }
            
        }
    }
}
