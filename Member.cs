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
        public bool Status { get; set; }
        public Member()
        {

        }
        public Member(int id, string name, DateTime enroll, int club,  bool employee,double bill,bool status)
        {


            ID = id; Name = name; Enroll = enroll; Club = club; Employee = employee; Bill = bill; Status = status;

        }


        abstract public void CheckIn(Club club);
        abstract public int AssignID();
        abstract public void DisplayFees();

    }
}
