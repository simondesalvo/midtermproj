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
        public int Club { get; set; }
        public double Bill { get; set; }
        public bool Employee { get; set; }
        public Member()
        {

        }
        public Member(int id, string name, DateTime enroll, int club,  bool employee,double bill)
        {


            id = ID; name = Name; enroll = Enroll; club = Club; employee = Employee; bill = Bill;

        }


        abstract public void CheckIn(ClubClass club);
        abstract public int AssignID();
        abstract public void DisplayFees();

    }
}
