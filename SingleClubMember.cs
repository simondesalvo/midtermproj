using System;
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
        public SingleClubMember(int id, string name, DateTime enroll, int club, bool employee, double bill) : base(id, name, enroll, club, employee, bill)
        {


        }
        private List<SingleClubMember> _singleMembers = new List<SingleClubMember>();
        private void _PopulateSingleMemberList()
        {
            FileIO database = new FileIO();
            foreach(SingleClubMember member in database.SingleMemberDbPull())
            {
                _singleMembers.Add(member);
            }
        }
        private int CountMembers(int club)
        {
            FileIO membersDb = new FileIO();
            List<SingleClubMember> membersList = new List<SingleClubMember>();
            foreach (SingleClubMember member in membersDb.SingleMemberDbPull())
            {
                if (member.Club == club)
                {
                    membersList.Add(member);
                }
            }
            return membersList.Count;
        }
        public SingleClubMember FindMember(int iD)
        {
            FileIO membersDB = new FileIO();
            SingleClubMember member = new SingleClubMember();
            member = (SingleClubMember)membersDB.SingleMemberDbPull().Find(m => m.ID == iD);
            return member;
        }

        public override void CheckIn(Club club)
        {
            
            if (ID==0&&club.ClubName== "Prof Oaks House of PikaPain")
            {
                Utility.PrintGreen($"{Name} is permitted to enter!");
            }
            else if (ID == 1 && club.ClubName == "Joe Lewis Memorial Punch Out")
            {
                Utility.PrintGreen($"{Name} is permitted to enter!");
            }
            else if (ID == 2 && club.ClubName == "Whip It Good")
            {
                Utility.PrintGreen($"{Name} is permitted to enter!");
            }
            else if (ID == 3 && club.ClubName == "We Fought a War With Michigan for This!?")
            {
                Utility.PrintGreen($"{Name} is permitted to enter!");
            }
            else if (ID == 4 && club.ClubName == "Ron Swanson's Pyramid of Greatness")
            {
                Utility.PrintGreen($"{Name} is permitted to enter!");
            }
            else
            {
                Utility.PrintYellow($"{Name} is not permitted to enter.");
            }
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Name: {Name}\nID: {ID}\nDate of Enrollment: {Enroll}\nAssigned Club: ");
        }
        public override int AssignID()
        {
            Club clubs = new Club();
            if (ID == 0)
            {
                Console.Clear();
                Utility.PrintGreen("Which club does the member which to enroll in?");

                clubs.PrintClubs();

                Club = Validate.NumberRange($"Please enter the club of interest for applicant (0-{midtermproj.Club.ListClubs().Count-1})", midtermproj.Club.ListClubs().Count-1);
                
                //club ID is tied to club; 100's place designates the club they belong to at a glance, with 600's designating a multiclub member
                ID = (1+Club) * 100 + CountMembers(Club);

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
        public void DBshenanigans()
        {
            FileIO membersDB = new FileIO();
            List<SingleClubMember> tempMember = new List<SingleClubMember>();

            for (int i =0; i< membersDB.SingleMemberDbPull().Count; i++)
            {
                tempMember.Add(membersDB.SingleMemberDbPull()[i]);
            }
            //foreach(SingleClubMember member in membersDB.SingleMemberDbPull())
            //{
            //    tempMember.Add(member);
            //}
            tempMember.Add(this);
            membersDB.SingleMembersDbPush(tempMember);
  

        }
    }
}
