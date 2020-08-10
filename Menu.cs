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
                Utility.PrintCyan($"{i+1}. {mainMenu[i]} ");
            }
            Console.WriteLine("");
            int input = Validate.NumberRange($"Please select an option from (please input 1 - {mainMenu.Count}).",mainMenu.Count);
            if (input == 1)
            {
                ////check-in
                //Validate.Integer("Please input your ID number");
                //if (idInt >= 600)
                //{
                //    //MultiClubMember.CheckIn(/*we need some way to input the clubName*/);
                //}
                //else if (idInt < 600)
                //{
                //    //Single_Club_Member.CheckIn(/*same prob*/);
                //}
                //else
                //{
                //    Console.WriteLine("Uh oh.");
                //}
            }
            else if (input == 2)
            {
                //add member
                Console.WriteLine("Would you like to sign up for a single club membership (s) or a multi club membership(m)?");
                ConsoleKeyInfo singMult = Console.ReadKey();
                if (singMult.Key == ConsoleKey.S)
                {
                    bool confirm = false;
                    while (!confirm)
                    {
                        Single_Club_Member newMemb = new Single_Club_Member();
                        newMemb.Name = Utility.GetInput("What is the new member's name?");
                        newMemb.Enroll = DateTime.Now;
                        newMemb.AssignID();
                        newMemb.Employee = true;
                        newMemb.Bill = 10; //or anything we want as the default single club bill

                        Console.Clear();
                        newMemb.DisplayInfo();

                        confirm = Validate.YesNo("Does the above info look correct?");
                    }
                    Console.WriteLine("It worked! Yas!");
                    Console.ReadKey();
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
                Console.WriteLine("Congrats! it's 3!");
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
                Validate.YesNo("Are you sure you want to quit?");
            }
            else
            {
                Console.WriteLine("Uh oh, not a valid input");
            }
            
        }
    }
}
