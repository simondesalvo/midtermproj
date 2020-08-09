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
            bool end = false;
            while (!end)
            {
                Menu.DisplayMainMenu();

                #region AddMember
                /*    1)Add member;
                //            What is  members name? ________________; name goes into name property of member object Variable for now.

                check DB; if they are there, say already a member! (probably if() conditional; bounce to main menu)

                                Single or Multigym? 

                                    --->new member(); new member object created, goes on list of members                


                                                                SINGLE STUFF
                                                                "What gym do they want to join?"
                //                  member.IDassign()  -> # Xxx     X = gym
                                                                    xx = how many registered to that gym


                                                                   Multistuff
                                      member.IDassign() 

                                                                    Display Info
                                                            "Does this look correct?"
                                        If Yes,
                                            After object is filled in, add it to the file IO
                                        If No,

                */
                #endregion

                #region Display Info
                /*
                            Prompt user: Who are you looking up?
                            Scan list of ALL members
                            membername.DiplayInfo();
                            press ket to return to main menu. Clear console and resets main menu
                 */
                #endregion

                #region Remove Member
                /*
                        Prompt user: Who do you want to remove?
                        Input name, search list
                        name.DisplayInfo()
                        "Are you sure you wish to delete this person?"
                            (Y/N)
                        if Y, delete from list (using index). This will remove from database as it is rewriten to file IO
                        if N, the return to main menu
                        Option: return to remove member instead

                                   */
                #endregion

                #region  Fees / Points
                /*
                    Prmopt user for "Please input member Name"
                                    Search list of ALL members
                                conditional: 
                                        if (employee is true)
                                        {
                                                discount fees for both (fee * 0.9)
                                         }
                                            if multimember (Show Fees and points earned)
                                             else if single member (show fees)
                            */
                #endregion

                #region Quit
                /*

                ends loop and closes things
                maybe upload to file IO when closing        


                */
                end = Validate.YesNo("Are you sure you want to quit?");
                #endregion
            }
            Console.Clear();
            Console.Beep(800,200); Console.Beep(400, 200); Console.Beep(200, 200); Console.Beep(100, 200);
            Utility.PrintGreen("Thank you for using the IHeartDiamond: Clubs manager! Have a nice day!");
        }
    }
}
