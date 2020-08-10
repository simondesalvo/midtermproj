﻿using System;
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
        public Club PullClubs(int input)
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