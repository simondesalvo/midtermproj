using System;
using System.Collections.Generic;
using System.Text;

namespace midtermproj
{
    abstract class Member
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime Enroll { get; set; }
        public bool Employee { get; set; }
        public Member()
        {

        }
        public Member(int id, string name, DateTime enroll,bool employee)
        {
<<<<<<< HEAD
            id = ID; name = Name; enroll = Enroll;
=======
            id = Id; name = Name; enroll = Enroll; employee = Employee;
>>>>>>> 8f3b2036152f648fae3d18b34ac01bde7f593f48
        }


        abstract public void CheckIn(ClubClass club);
        abstract public int IdAssign();

    }
}
