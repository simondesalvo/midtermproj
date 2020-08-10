using System;
using System.Collections.Generic;
using System.Text;

namespace midtermproj
{
    class Single_Club_Member : Member
    {
        public Single_Club_Member()
        {

        }
        public Single_Club_Member(int id, string name, DateTime enroll, int club, bool employee, double bill) : base(id, name, enroll, club, employee, bill)
        {


        }
        private int CountMembers(int club)
        {
            FileIO membersDb = new FileIO();
            List<Single_Club_Member> membersList = new List<Single_Club_Member>();
            foreach (Single_Club_Member member in membersDb.MemberDbPull())
            {
                if (member.Club == club)
                {
                    membersList.Add(member);
                }
            }
            return membersList.Count;
        }
        private Single_Club_Member FindMember(int iD)
        {
            FileIO membersDb = new FileIO();
            Single_Club_Member member = new Single_Club_Member();
            member = (Single_Club_Member)membersDb.MemberDbPull().Find(m => m.ID == iD);
            return member;

        }

        public override void CheckIn(ClubClass club)
        {
            


        }
        public void DisplayInfo()
        {
            Console.WriteLine($"Name: {Name}\nID: {ID}\nDate of Enrollment: {Enroll}\nAssigned Club: ");
        }
        public override int AssignID()
        {
            ClubClass clubs = new ClubClass();
            if (ID == 0)
            {
                Console.Clear();
                Utility.PrintGreen("Which club does the member which to enroll in?");

                clubs.PrintClubs();

                Club = Validate.NumberRange($"Please enter the club of interest for applicant (0-{ClubClass.ListClubs().Count-1})", ClubClass.ListClubs().Count-1);
                
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
    }
}
