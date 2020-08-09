using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace midtermproj
{
    class FileIO
    {
        public void MemberDbPull()
        {
            List<Member> membersDb = new List<Member>();

            StreamReader reader = new StreamReader("../../../MembersDb.txt");

            string memberscheck = reader.ReadLine();
            while (memberscheck != null)
            {
                memberscheck = reader.ReadLine();
            }
            reader.Close();

        }

        public void ClubsDbPull()
        {
            List<ClubClass> ClubDb = new List<ClubClass>();

            StreamReader reader = new StreamReader("../../../ClubDb.txt");

            string clubcheck = reader.ReadLine();
            while (clubcheck != null)
            {
                clubcheck = reader.ReadLine();
            }
            reader.Close();
        }

        public void MembersDbPush()
        {
            List<Member> membersDb = new List<Member>();
            membersDb.Add(new Single_Club_Member(500, "Joey C", Convert.ToDateTime(23 / 01 / 2013), 2, false, 40));

            StreamWriter writer = new StreamWriter("../../../MembersDb.txt");

            foreach (Member member in membersDb)
            {
                writer.WriteLine($"{member.ID} | {member.Name} | {member.Enroll} | {member.Club} {member.Employee} | {member.Bill}");
            }
            writer.Close();
        }


        public void ClubsDbPush()
        {
            List<ClubClass> ClubDb = ClubClass.ListClubs();

            StreamWriter writer = new StreamWriter("../../../ClubDb.txt");

            foreach (ClubClass club in ClubDb)
            {
                writer.WriteLine($"{club.ClubName} | {club.StreetAddress} | {club.City} | {club.State}");
            }
            writer.Close();
        }

    }
}
