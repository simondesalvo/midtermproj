using System;
using System.Collections.Generic;
using System.IO;

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

    public class Club
    {
        public string ClubName { get; set; }
        public string StreetAddress { get; set; }
        public Ci City { get; set; }
        public St State { get; set; }

        public Club() { }
        public Club(string ClubName, string StreetAddress, Ci City, St State)
        {
            this.ClubName = ClubName;
            this.StreetAddress = StreetAddress;
            this.City = City;
            this.State = State;
        }
       

        //public static List<Club> ListClubs()
        //{
        //    List<Club> ClubList = new List<Club>
        //    {
        //        new Club("Prof Oaks House of PikaPain", "123 Wolverine Ct", Ci.AnnArbor, St.Michigan),
        //        new Club("Joe Lewis Memorial Punch Out", "123 Woodward Ave", Ci.Detroit, St.Michigan),
        //        new Club("Whip It Good", "123 Devo Ln", Ci.Columbus, St.Ohio),
        //        new Club("We Fought a War With Michigan for This!?", "123 Toledo St", Ci.Toledo, St.Ohio),
        //        new Club("Ron Swanson's Pyramid of Greatness", "123 Parks Dr", Ci.Pawnee, St.Indiana)
        //    };

        //    return ClubList;
        //}

        public void DisplayClubs()
        {
            FileIO clubDB = new FileIO();
            List<Club> clubs = new List<Club>();
            for(int i=0;i<clubDB.ClubsDbPull().Count;i++)
            {
                Utility.PrintCyan($"{i} {clubDB.ClubsDbPull()[i].ClubName}");
            }
        }
        public int CountClubs()
        {
            FileIO clubDB = new FileIO();
            List<Club> clubs = new List<Club>();
            int clubCount = clubDB.ClubsDbPull().Count;
            return clubCount;
        }
        public Club ListClubs(int input)
        {
            FileIO clubDB = new FileIO();
            List<Club> clubs = new List<Club>();
            for (int i = 0; i < clubDB.ClubsDbPull().Count; i++)
            {
                clubs.Add(clubDB.ClubsDbPull()[i]);
            }
            return clubs[input];
        }
    }
}