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
        public Single_Club_Member(int id, string name, DateTime enroll) : base(id, name, enroll)
        {

        }
        public override void CheckIn(ClubClass club)
        {


        }

        public override int IdAssign(int memberID)
        {
            ClubClass club = new ClubClass();
            if (memberID == 0)
            {
                Console.Clear();
                Utility.PrintGreen("Which gym does the member which to enroll in?");
                club.PrintClubs();

            }
            else
            {
                Console.Clear();
                Utility.PrintYellow("Member already has an ID number. Are you sure you wish to reassign this ID?");


            }

            return memberID;
        }
    }
}
