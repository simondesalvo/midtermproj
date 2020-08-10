using System;
using System.Collections.Generic;
using System.Text;

namespace midtermproj
{
    class Menu
    {

        private static List<string> mainMenu = new List<string>
        {
            "Check In",
            "Add Member",
            "Display Member",
            "Remove Member",
            "Display Fees and Points",
            "Quit"
        };
        public static Club SelectClub()
        {
            Club club = new Club();
            return(club.ListClubs(Validate.NumberRange($"Hello! Welcome to the IHeartDiamonds: Clubs Manager: We've got members in Spades(tm)! Which club are you operating from? (input 0-{club.CountClubs() - 1})", club.CountClubs() - 1)));
        }

        public static void DisplayMainMenu(Club club)
        {

            Console.Clear();
            Club c = new Club();
            SingleClubMember s = new SingleClubMember();
            MultiClubMember m = new MultiClubMember();
            Utility.PrintGreen("Hello! Welcome to the IHeartDiamonds: Clubs Manager!");


            //ask what club they're at, for input into clubcheckin methods
            for (int i = 0; i < mainMenu.Count; i++)
            {
                Utility.PrintCyan($"{i + 1}. {mainMenu[i]} ");
            }
            Console.WriteLine("");
            int input = Validate.NumberRange($"Please select an option from (please input 1 - {mainMenu.Count}).", mainMenu.Count);
            if (input == 1)
            {
                int idNum = Validate.Integer("Please input your member's ID number:");
                if (idNum < 600)
                {
                    s=s.FindMember(idNum);
                    s.CheckIn(club);
                }
                else if (idNum >= 600)
                {
                    m=m.FindMember(idNum);
                    m.CheckIn(club);
                    Console.ReadKey();
                }

            }
            else if (input == 2)
            {
                //add member
                Console.WriteLine("Would you like to sign up for a single club membership (s) or a multi club membership(m)?");
                ConsoleKeyInfo singMult = Console.ReadKey();
                Console.Clear();
                if (singMult.Key == ConsoleKey.S)
                {

                    SingleClubMember newMemb = new SingleClubMember();
                    newMemb.Name = Utility.GetInput("What is the new member's name?");
                    newMemb.Enroll = DateTime.Now;
                    newMemb.AssignID();
                    newMemb.Employee = true;
                    newMemb.Bill = 10; //or anything we want as the default single club bill

                    Console.Clear();
                    newMemb.DisplayInfo();

                    if (Validate.YesNo("Does the above info look correct?"))
                    {
                        newMemb.DBAdd();
                    }
                  

                    Console.WriteLine("It worked! Yas!");
                    Console.ReadKey();
                    //time to write to file.io
                }
                else if (singMult.Key == ConsoleKey.M)
                {
                    //same business as single, but with multiclub class
                    MultiClubMember newMemb = new MultiClubMember();
                    newMemb.Name = Utility.GetInput("What is the new member's name?");
                    newMemb.Enroll = DateTime.Now;
                    newMemb.AssignID();
                    newMemb.Employee = true;
                    newMemb.Bill = 25; //or anything we want as the default single club bill

                    Console.Clear();
                    newMemb.DisplayInfo();

                    if (Validate.YesNo("Does the above info look correct?"))
                    {
                        newMemb.DBAdd();
                    }

                }
            }
            else if (input == 3)
            {
               int idNum = Validate.Integer("Please input your member's ID number:");
               if (idNum < 600)
                {
                    s.FindMember(idNum);
                }
               else if(idNum >= 600)
                {
                    m.FindMember(idNum);
                }

            }
            else if (input == 4)
            {
                //remove member
                int idNum = Validate.Integer("Please input your member's ID number:");
                if (idNum < 600)
                {
                    s=s.FindMember(idNum);
                    Console.WriteLine();
                    if (Validate.YesNo($"Are you sure you wish to delete {s.Name}?"))
                    {
                        s.DBRemove();
                    }
                    else
                    {
                        s.Status = true;
                    }
                       
                }
                else if (idNum >= 600)
                {
                    m=m.FindMember(idNum);
                    Console.WriteLine();
                    if (Validate.YesNo($"Are you sure you wish to delete {m.Name}?"))
                    {
                        m.DBRemove();
                    }
                    else
                    {
                        m.Status = true;
                    }
                }

                //display member method
               


            }
            else if (input == 5)
            {
                int idNum = Validate.Integer("Please input your member's ID number:");
                if (idNum < 600)
                {
                    s.FindMember(idNum);
                }
                else if (idNum >= 600)
                {
                    m.FindMember(idNum);
                }
            }
            else if (input == 6)
            {
                Validate.YesNo("Are you sure you want to quit?");
            }
            else
            {
                Console.WriteLine("Uh oh, not a valid input");
            }

        }
    }
}
