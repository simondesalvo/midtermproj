using System;
using System.Collections.Generic;
using System.Text;

namespace midtermproj
{
    abstract class Member
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Member()
        {

        }
        public Member(int id, string name)
        {
            id = Id; name = Name;
        }
        abstract public void CheckIn(ClubClass club);

    }
}
