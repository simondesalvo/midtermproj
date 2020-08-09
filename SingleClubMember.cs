using System;
using System.Collections.Generic;
using System.Text;

namespace midtermproj
{
    class Single_Club_Member : Member
    {
        public Single_Club_Member()
        {

        }
        public Single_Club_Member(int id, string name, DateTime enroll, int club, bool employee,double bill) : base(id, name, enroll,club,employee,bill)
        {


        }
        public override void CheckIn(ClubClass club)
        {
            
            

        }

        public override int IdAssign()
        {
            int idConstructor = 1;
            int gymMembers = 0;
            ClubClass club = new ClubClass();
            if (ID == 0)
            {
                    Console.Clear();
                    Utility.PrintGreen("Which gym does the member which to enroll in?");
                    club.PrintClubs();
                    idConstructor += Validate.NumberRange($"Please enter the gym of interest for applicant (0-{ClubClass.ListClubs().Count})", ClubClass.ListClubs().Count);
                idConstructor = idConstructor * 100;
                for (int i =0; i</*memberDb*/; i++)
                {
                    if (/*memberDb*/[i].ID>=idConstructor || /*memberDb*/[i].ID < idConstructor + 100)
                    {
                        gymMembers++;
                    }
                }
               ID = idConstructor + gymMembers;
            }
            else
            {
                Console.Clear();
                Utility.PrintYellow("Member already has an ID number.");
            }

            return ID;
        }
    }
}
