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

        public MultiClubMember(int id, string name, DateTime enroll, string club, bool employee, int points, double bill, int checkins, bool status,DateTime lastTimeBilled) : base(id, name, enroll, club, employee, bill,status,lastTimeBilled)
        {
            Points = points;
            Checkins = checkins;
        }

        #region PrivateMethods
        private void _Billing()
        {
            FileIO membersDb = new FileIO();
            MultiClubMember multiClubMember = new MultiClubMember();
            List<MultiClubMember> mcMembers = new List<MultiClubMember>();
            for (int i = 0; i < membersDb.MultiMembersDbPull().Count; i++)
            {
                multiClubMember = membersDb.MultiMembersDbPull()[i];

                if (DateTime.Now.Day == multiClubMember.LastTimeBilled.Day && DateTime.Now.Date != multiClubMember.LastTimeBilled.Date && multiClubMember.Status==true)
                {
                    if (multiClubMember.Employee)
                    {
                        multiClubMember.Bill += 20;
                    }
                    else
                    {
                        multiClubMember.Bill += 25;
                    }

                    multiClubMember.LastTimeBilled = DateTime.Now;
                }

                mcMembers.Add(multiClubMember);
            }

            membersDb.MultiMembersDbPush(mcMembers);
        }

        private bool _DrawFromFile(int input)
        {
            bool idMatch = false;
            FileIO membersDb = new FileIO();
            List<int> memberIDs = new List<int>();
            for (int i = 0; i < membersDb.MultiMembersDbPull().Count; i++)
            {
                if (membersDb.MultiMembersDbPull()[i].ID == input)
                {
                    idMatch = true;
                }

            }
            return idMatch;
        }
        private int _CountMembers()
        {
            FileIO membersDb = new FileIO();
            List<MultiClubMember> membersList = new List<MultiClubMember>();
            foreach (MultiClubMember member in membersDb.MultiMembersDbPull())
            {
                membersList.Add(member);

            }
            return membersList.Count;
        }
        #endregion

        #region Public
        public override void CheckIn(Club club)
        {
            if (Status)
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
                UpdatePoints();
            }
            else
            {
                Console.Clear();
                Utility.PrintYellow($"{Name} is no longer a member. They will have to re-up membership to enter.\nPress any key to return to main menu.");
                Console.ReadKey();
            }

        }

        public override int AssignID()
        {
            if (ID == 0)
            {
                Club = "All";
                ID = 600 + _CountMembers();
            }
            else
            {
                Utility.PrintYellow("Member already has an ID number.");
            }
            return ID;
        }

        public void DisplayInfo()
        {
            Utility.PrintCyan($"Name: {Name}\nID: {ID}\nDate of Enrollment: {Enroll}\n Accumulated Points: {Points}\nMulticlub Member!");
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

        }

        public override void DisplayFees()
        {
            Utility.PrintGreen($"Name: {Name}");
            Utility.PrintGreen($"Fees due: ${Bill}.00");
            Utility.PrintGreen($"Points Earned: {Points}");
        }

        public MultiClubMember FindMember(int id)
        {
            FileIO membersDB = new FileIO();
            MultiClubMember member = new MultiClubMember();

            if (_DrawFromFile(id))
            {
                member = membersDB.MultiMembersDbPull().Find(m => m.ID == id);
                member.DisplayInfo();
                Console.ReadKey();
            }
            else
            {
                Utility.PrintYellow($"The ID {id} is not in the database. Press any key to return to the main menu.");
                Console.ReadKey();
            }
            Console.Clear();



            return member;
        }

        public void DBAdd()
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
        public static void StartUp()
        {
            MultiClubMember multiClubMember = new MultiClubMember();
            multiClubMember._Billing();
        }
        public void DBRemove()
        {
            FileIO membersDB = new FileIO();
            List<MultiClubMember> tempMember = new List<MultiClubMember>();

            for (int i = 0; i < membersDB.MultiMembersDbPull().Count; i++)
            {
                if (membersDB.MultiMembersDbPull()[i].ID == ID)
                {
                    Status = false;
                    tempMember.Add(this);
                }
                else
                {
                    tempMember.Add(membersDB.MultiMembersDbPull()[i]);
                }
            }
            membersDB.MultiMembersDbPush(tempMember);
        }
        public void UpdatePoints()
        {
            FileIO membersDB = new FileIO();
            List<MultiClubMember> tempMember = new List<MultiClubMember>();

            for (int i = 0; i < membersDB.MultiMembersDbPull().Count; i++)
            {
                if (membersDB.MultiMembersDbPull()[i].ID == ID)
                {
                    
                    tempMember.Add(this);
                }
                else
                {
                    tempMember.Add(membersDB.MultiMembersDbPull()[i]);
                }
            }
            membersDB.MultiMembersDbPush(tempMember);
        }
        #endregion
    }
}

