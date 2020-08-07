using System;
using System.Collections.Generic;
using System.Text;

namespace midtermproj
{
    abstract class Member
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Enroll { get; set; }
        public Member()
        {

        }
        public Member(int id, string name, DateTime enroll)
        {
            id = Id; name = Name; enroll = Enroll;
        }

        //deleted constructor
        abstract public void CheckIn(ClubClass club);
        abstract public int IdAssign(int memberID);

    }
}
