﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace midtermproj
{
    class SingleClubMember : Member
    {
        public SingleClubMember()
        {

        }

        public SingleClubMember(int id, string name, DateTime enroll, string club, bool employee, double bill, bool status) : base(id, name, enroll, club, employee, bill, status)
        {


        }

        private List<SingleClubMember> _singleMembers = new List<SingleClubMember>();
        private List<int> _idNumbers = new List<int>();
        private int CountMembers()
        {

            FileIO membersDb = new FileIO();
            List<SingleClubMember> membersList = new List<SingleClubMember>();
            foreach (SingleClubMember member in membersDb.SingleMemberDbPull())
            {
                membersList.Add(member);
            }
            return membersList.Count;

        }
        private bool DrawFromFile(int input)
        {
            bool idMatch = false;
            FileIO membersDb = new FileIO();
            List<int> memberIDs = new List<int>();
            for(int i=0; i< membersDb.SingleMemberDbPull().Count;i++)
            {
                if (membersDb.SingleMemberDbPull()[i].ID == input)
                {
                    idMatch = true;
                }
                
            }
            return idMatch;
        }

        public SingleClubMember FindMember(int id)
        {
            FileIO membersDB = new FileIO();
            SingleClubMember member = new SingleClubMember();
            if (DrawFromFile(id))
            {
                member = membersDB.SingleMemberDbPull().Find(m => m.ID == id);
            }
            else
            {
                Utility.PrintYellow($"The ID {id} is not in the database. Press any key to return to the main menu.");
                Console.ReadKey();
            }
            return member;
        }

        public override void CheckIn(Club checkIn)
        {

            if (Club.Trim() == checkIn.ClubName.Trim())
            {
                Utility.PrintGreen($"{Name} is permitted to enter! \nPress any key to return to main menu.");
                Console.ReadKey();
            }
            else
            {
                Utility.PrintYellow($"{Name} is not permitted to enter. \nPress any key to return to main menu");
                Console.ReadKey();
            }
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Name: {Name}\nID: {ID}\nDate of Enrollment: {Enroll}\nAssigned Club: {Club}");
        }
        public override int AssignID()
        {
            int input = -1;
            Club clubs = new Club();
            if (ID == 0)
            {
                Console.Clear();
                Utility.PrintGreen("Which club does the member which to enroll in?");

                clubs.DisplayClubs();

                input = Validate.NumberRange($"Please enter the club of interest for applicant (0-{clubs.CountClubs() - 1})", clubs.CountClubs() - 1);
                clubs = clubs.PullClubs(input);
                Club = clubs.ClubName;
                //club ID is tied to club; 100's place designates the club they belong to at a glance, with 600's designating a multiclub member
                ID = (1 + input) * 100 + CountMembers();

            }
            else
            {
                Console.Clear();
                Utility.PrintYellow("Member already has an ID number.");
            }

            return ID;
        }

        public override void DisplayFees()
        {
            Utility.PrintGreen($"Name: {Name}");
            Utility.PrintGreen($"Fees due: {Bill}");
        }
        public void DBAdd()
        {
            FileIO membersDB = new FileIO();
            List<SingleClubMember> tempMember = new List<SingleClubMember>();

            for (int i = 0; i < membersDB.SingleMemberDbPull().Count; i++)
            {
                tempMember.Add(membersDB.SingleMemberDbPull()[i]);
            }

            tempMember.Add(this);
            membersDB.SingleMembersDbPush(tempMember);
        }

        public void DBRemove()
        {
            FileIO membersDB = new FileIO();
            List<SingleClubMember> tempMember = new List<SingleClubMember>();

            for (int i = 0; i < membersDB.SingleMemberDbPull().Count; i++)
            {
                if (membersDB.SingleMemberDbPull()[i].ID == ID)
                {
                    Status = false;
                    tempMember.Add(this);
                }
                else
                {
                    tempMember.Add(membersDB.SingleMemberDbPull()[i]);
                }
            }
            membersDB.SingleMembersDbPush(tempMember);
        }
    }
}
