using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace midtermproj
{
    class FileIO
    {
       

        #region Members

        public List<Member> MemberDbPull()
        {
            List<Member> members = new List<Member>();

            StreamReader reader = new StreamReader("../../../MembersDb.txt");

            string memberline = reader.ReadLine();
            while (memberline != null)
            {
                string[] membersplit = memberline.Split('|');
                if (membersplit.Length == 6)
                {
                    members.Add(new Single_Club_Member(int.Parse(membersplit[0]), membersplit[1], DateTime.Parse(membersplit[2]),
                                                       int.Parse(membersplit[3]), bool.Parse(membersplit[4]), double.Parse(membersplit[5])));
                    memberline = reader.ReadLine();
                }
                else if (membersplit.Length == 8)
                {
                    members.Add(new MultiClubMember(int.Parse(membersplit[0]), membersplit[1], DateTime.Parse(membersplit[2]),
                                                    int.Parse(membersplit[3]), bool.Parse(membersplit[4]), int.Parse(membersplit[5]),
                                                    double.Parse(membersplit[6]), int.Parse(membersplit[7])));
                    memberline = reader.ReadLine();
                }
            }
            reader.Close();

            return members;

        }

        public void MembersDbPush()
        {   //Make list here consistent.
            List<Member> membersDb = new List<Member>();

            StreamWriter writer = new StreamWriter("../../../MembersDb.txt");

            foreach (MultiClubMember member in membersDb)
            {
                writer.WriteLine($"{member.ID} | {member.Name} | {member.Enroll} | {member.Club} | {member.Employee} | {member.Points} | " +
                                 $"{member.Bill} | {member.Checkins} ");
            }

            foreach(Single_Club_Member member in membersDb)
            {
                writer.WriteLine($"{member.ID} | {member.Name} | {member.Enroll} | {member.Club} | {member.Employee} | {member.Bill} ");
            }
            writer.Close();
        }
        #endregion

        #region Club

        public List<ClubClass> ClubsDbPull()
        {
            List<ClubClass> clubs = new List<ClubClass>();

            StreamReader reader = new StreamReader("../../../ClubDb.txt");

            string clubline = reader.ReadLine();
            while (clubline != null)
            {
                string[] clubsplit = clubline.Split('|');
                clubs.Add(new ClubClass(clubsplit[0], clubsplit[1], (Ci)Enum.Parse(typeof(Ci),
                                        clubsplit[2]), (St)Enum.Parse(typeof(St), clubsplit[3])));
                clubline = reader.ReadLine();
            }
            reader.Close();

            return clubs;
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
        #endregion
    }
}
