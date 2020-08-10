using System;
using System.Collections.Generic;
using System.Text;

namespace midtermproj
{
    class MultiClubMember : Member
    {
        public int Points { get; set; }

        public int Checkins { get; set; }
        public MultiClubMember() { }

        public MultiClubMember(int id, string name, DateTime enroll, int club, bool employee, int points, double bill, int checkins, bool status) : base(id, name, enroll, club, employee, bill,status)
        {
            Points = points;
            Checkins = checkins;
        }


        private List<MultiClubMember> _multiClubMembers = new List<MultiClubMember>();

        private void _PopulateMultiMemberList()
        {
            FileIO database = new FileIO();
            foreach (MultiClubMember member in database.MultiMembersDbPull())
            {
                _multiClubMembers.Add(member);
            }
        }
        public void StartUp()
        {
            _PopulateMultiMemberList();
        }
        private int CountMembers()
        {
            FileIO membersDb = new FileIO();
            List<MultiClubMember> membersList = new List<MultiClubMember>();
            foreach (MultiClubMember member in membersDb.MultiMembersDbPull())
            {
                membersList.Add(member);

            }
            return membersList.Count;
        }

        public override void CheckIn(Club club)
        {
            Console.WriteLine($"{Name} is welcome at {club.ClubName}");
            Points += 5;
            Checkins++;
            if (Employee)
            {
                EmployeeCountedPoints();
            }
            else
            {
                CountedPoints();
            }
        }

        public override int AssignID()
        {
            if (ID == 0)
            {
                Club = 6;
                ID = 600 + CountMembers();
            }
            else
            {
                Utility.PrintYellow("Member already has an ID number.");
            }
            return ID;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Name: {Name}\nID: {ID}\nDate of Enrollment: {Enroll}\n Accumulated Points: {Points}");
        }

        public void CountedPoints()
        {
            if (Checkins > 15 && Checkins < 30)
            {
                Points += 1;
            }
            else if (Checkins >= 30 && Checkins < 50)
            {
                Points += 2;
            }
            else if (Checkins >= 50 && Checkins < 100)
            {
                Points += 3;
            }
            else if (Checkins >= 100 && Checkins < 200)
            {
                Points += 4;
            }
            else if (Checkins >= 200 && Checkins < 1000)
            {
                Points += 5;
            }
            else if (Checkins >= 1000)
            {
                Console.WriteLine("Congratulations!! You get a CHICKEN!!!!!!");
                Points = 0;
            }
            else
            {
                Console.WriteLine("I don't know what you did but you did it");
            }
        }

        public void EmployeeCountedPoints()
        {
            if (Checkins > 15 && Checkins < 30)
            {
                Points += 1;
            }
            else if (Checkins >= 30 && Checkins < 50)
            {
                Points += 2;
            }
            else if (Checkins >= 50 && Checkins < 100)
            {
                Points += 3;
            }
            else if (Checkins >= 100 && Checkins < 200)
            {
                Points += 4;
            }
            else if (Checkins >= 200 && Checkins < 500)
            {
                Points += 5;
            }
            else if (Checkins >= 500)
            {
                Console.WriteLine("Congratulations!! You get a CHICKEN!!!!!!");
                Points = 0;
            }
            else
            {
                Console.WriteLine("I don't know what you did but you did it");
            }
        }

        public override void DisplayFees()
        {
            Utility.PrintGreen($"Name: {Name}");
            Utility.PrintGreen($"Fees due: {Bill}");
            Utility.PrintGreen($"Points Earned: {Points}");
        }




        public MultiClubMember FindMember(int iD)
        {
            FileIO membersDB = new FileIO();
            MultiClubMember member = new MultiClubMember();
            member = membersDB.MultiMembersDbPull().Find(m => m.ID == iD);

            Console.Clear();
            member.DisplayInfo();
            Console.ReadKey();

            return member;
        }

        public void DBshenanigans()
        {
            FileIO membersDB = new FileIO();
            List<MultiClubMember> tempMember = new List<MultiClubMember>();

            for (int i = 0; i < membersDB.MultiMembersDbPull().Count; i++)
            {
                tempMember.Add(membersDB.MultiMembersDbPull()[i]);
            }

            tempMember.Add(this);
            membersDB.MultiMembersDbPush(tempMember);
        }


    }
}
