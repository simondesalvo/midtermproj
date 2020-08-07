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
        public Single_Club_Member(int id, string name) : base(id, name)
        {

        }
        public override void CheckIn(ClubClass club)
        {
            
            
        }

        public override int IdAssign(int memberID)
        {
            if (memberID == 0)
            {

            }
            else 
            {
                Utility.PrintYellow("Member already has an ID number. Are you sure you wish to reassign this ID?");


            }

            return memberID;
        }
    }
}
