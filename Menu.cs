using System;
using System.Collections.Generic;
using System.Text;

namespace midtermproj
{
    class Menu
    {
        
        private static List<string> mainMenu = new List<string>
        {
            "Check In Member",
            "Add Member",
            "Display Member",
            "Remove Member",
            "Display Fees and Points",
            "Quit"
        };
        public static Club SelectClub()
        {
            Club club = new Club();
            Utility.PrintGreen($"Hello! Welcome to the IHeartDiamonds: Clubs Manager: We've got members in Spades(tm)!");
            club.DisplayClubs();
            return (club.PullClubs(Validate.NumberRange($"Which club are you operating from? (input 0-{club.CountClubs() - 1})", club.CountClubs() - 1)));

        }

        public static bool DisplayMainMenu(Club club)
        {
            string inputMembership = "";
            bool output = false;
            Console.Clear();
            SingleClubMember s = new SingleClubMember();
            MultiClubMember m = new MultiClubMember();
            Utility.PrintGreen($"{club.ClubName}: Operations");

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
                    s = s.FindMember(idNum);
                    if (s.ID == 0)
                    {

                    }
                    else
                    {
                        s.CheckIn(club);
                    }
                }
                else if (idNum >= 600)
                {
                    m = m.FindMember(idNum);
                    if (m.ID == 0)
                    {

                    }
                    else
                    {
                        m.CheckIn(club);
                    }
                }

            }
            else if (input == 2)
            {
                //add member

                inputMembership = Utility.GetKeyInput("Would you like to sign up for a Single club membership (s) or a Multi-club membership (m)?"); ;
                Console.Clear();
                if (inputMembership == "s")
                {
                    SingleClubMember newMemb = new SingleClubMember();
                    newMemb.Name = Utility.GetInput("What is the new member's name?");
                    newMemb.Enroll = DateTime.Now;
                    newMemb.LastTimeBilled = DateTime.Now;
                    newMemb.AssignID();
                    newMemb.Status = true;
                    newMemb.Bill = 10;

                    Console.Clear();
                    newMemb.DisplayInfo();

                    if (Validate.YesNo("Does the above info look correct? (input Y/N)"))
                    {
                        newMemb.DBAdd();
                        Utility.PrintGreen($"{newMemb.Name} added to the database!");
                        Console.ReadKey();
                    }

                }
                else if (inputMembership == "m")
                {
                    //same business as single, but with multiclub class
                    MultiClubMember newMemb = new MultiClubMember();
                    newMemb.Name = Utility.GetInput("What is the new member's name?");
                    newMemb.Enroll = DateTime.Now;
                    newMemb.LastTimeBilled = DateTime.Now;
                    newMemb.AssignID();
                    newMemb.Status = true;
                    newMemb.Bill = 25; //or anything we want as the default single club bill

                    Console.Clear();
                    newMemb.DisplayInfo();

                    if (Validate.YesNo("Does the above info look correct? Input (Y/N)"))
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
                    s = s.FindMember(idNum);
                    if (s.ID == 0)
                    {

                    }
                    else
                    {
                        Console.Clear();
                        s.DisplayInfo();
                        Utility.PrintGreen("Press any key to return to the main menu.");
                        Console.ReadKey();
                    }

                }
                else if (idNum >= 600)
                {
                    m = m.FindMember(idNum);
                    if (m.ID == 0)
                    {

                    }
                    else
                    {
                        Console.Clear();
                        m.DisplayInfo();
                        Utility.PrintGreen("Press any key to return to the main menu.");
                        Console.ReadKey();
                    }

                }

            }
            else if (input == 4)
            {
                //remove member
                int idNum = Validate.Integer("Please input your member's ID number: ");
                if (idNum < 600)
                {
                    s = s.FindMember(idNum);
                    if (s.ID == 0)
                    {

                    }
                    else
                    {
                        if (Validate.YesNo($"Are you sure you wish to delete {s.Name}? Input (Y/N)."))
                        {
                            s.DBRemove();
                        }
                    }

                }
                else if (idNum >= 600)
                {
                    m = m.FindMember(idNum);
                    if (m.ID == 0)
                    {

                    }
                    else
                    {
                        if (Validate.YesNo($"Are you sure you wish to delete {m.Name}? Input (Y/N)."))
                        {
                            m.DBRemove();
                        }
                    }
                }

                //display member method



            }
            else if (input == 5)
            {
                int idNum = Validate.Integer("Please input your member's ID number: ");
                if (idNum < 600)
                {
                    s = s.FindMember(idNum);
                    if (s.ID == 0)
                    {

                    }
                    else
                    {
                        Console.Clear();
                        s.DisplayFees();
                        Console.ReadKey();
                    }


                }
                else if (idNum >= 600)
                {
                    m = m.FindMember(idNum);
                    if (m.ID == 0)
                    {

                    }
                    else
                    {
                        Console.Clear();
                        m.DisplayFees();
                        Console.ReadKey();
                    }

                }
            }
            else if (input == 6)
            {
                output = Validate.YesNo("Are you sure you want to quit?");

            }
            else
            {
                Console.WriteLine("Uh oh, not a valid input");
            }
            return output;

        }
    }
}
