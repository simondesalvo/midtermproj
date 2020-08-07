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
        public bool Employee { get; set; }
        public Member()
        {

        }
        public Member(int id, string name, DateTime enroll,bool employee)
        {
            id = Id; name = Name; enroll = Enroll; employee = Employee;
        }


        abstract public void CheckIn(ClubClass club);
        abstract public int IdAssign();

    }
}
