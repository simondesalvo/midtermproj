using System;
using System.Collections.Generic;

namespace midtermproj
{       //at least four clubs, eventually getting some file i/o stuff with Joe, basic details like name and address
    public enum St
    {
        Michigan,
        Ohio,
        Indiana
    }
    public enum Ci
    {
        Detroit,
        AnnArbor,
        Columbus,
        Toledo,
        Pawnee
    }

    public class ClubClass
    {
        public string ClubName { get; set; }
        public string StreetAddress { get; set; }
        public Ci City{ get; set; }
        public St State { get; set; }

        public ClubClass() { }
        public ClubClass(string ClubName, string StreetAddress, Ci City, St State)
        {
            this.ClubName = ClubName;
            this.StreetAddress = StreetAddress;
            this.City = City;
            this.State = State;
        }

        List<ClubClass> ClubList = new List<ClubClass>
        {
            new ClubClass("Prof Oaks House of PikaPain", "123 Wolverine Ct", Ci.AnnArbor, St.Michigan),
            new ClubClass("Joe Lewis Memorial Punch Out", "123 Woodward Ave", Ci.Detroit, St.Michigan),
            new ClubClass("Whip It Good", "123 Devo Ln", Ci.Columbus, St.Ohio),
            new ClubClass("We Fought a War With Michigan for This!?", "123 Toledo St", Ci.Toledo, St.Ohio),
            new ClubClass("Ron Swanson's Pyramid of Greatness", "123 Parks Dr", Ci.Pawnee, St.Indiana)
        };

        public void PrintClubs()
        {
            for (int i = 0; i< ClubList.Count; i++)
            {
                Console.WriteLine((i) + " " + ClubList[i].ClubName + " " + ClubList[i].StreetAddress + " " + ClubList[i].City + " " + ClubList[i].State);
            }
        }
        
        
    }
}
