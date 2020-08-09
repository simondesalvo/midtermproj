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
            List<ClubClass> clubs = new List<ClubClass>();

            StreamReader reader = new StreamReader("../../../ClubDb.txt");

            string clubline = reader.ReadLine();
            while (clubline != null)
            {
                string[] clubsplit = clubline.Split('|');
                //Look enum.parse (might get rid of enums)
                clubs.Add(new ClubClass(clubsplit[0], clubsplit[1], Enum.Parse(typeof(Ci), clubsplit[2]), Enum.Parse(St, clubsplit[3])));
                clubline = reader.ReadLine();

            }

            reader.Close();
            for (int i = 0; i < clubs.Count; i++)
            {
                //Print the list of the clubs
            }

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
