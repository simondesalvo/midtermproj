﻿using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace midtermproj
{
    class FileIO
    {
        #region Members

        public List<SingleClubMember> SingleMemberDbPull()
        {
            List<SingleClubMember> members = new List<SingleClubMember>();

            StreamReader reader = new StreamReader("../../../SingleMembersDb.txt");

            string memberline = reader.ReadLine();
            while (memberline != null)
            {
                string[] membersplit = memberline.Split('|');
                SingleClubMember memb = new SingleClubMember(int.Parse(membersplit[0]), membersplit[1], DateTime.Parse(membersplit[2]),
                                                       int.Parse(membersplit[3]), bool.Parse(membersplit[4]), double.Parse(membersplit[5]), bool.Parse(membersplit[6]));
                    members.Add(memb);
                    memberline = reader.ReadLine();
            }
            reader.Close();

            return members;

        }
        public List<MultiClubMember> MultiMembersDbPull()
        {
            List<MultiClubMember> members = new List<MultiClubMember>();

            StreamReader reader = new StreamReader("../../../MultiMembersDb.txt");

            string memberline = reader.ReadLine();
            while (memberline != null)
            {
                string[] membersplit = memberline.Split('|');
                members.Add(new MultiClubMember(int.Parse(membersplit[0]), membersplit[1], DateTime.Parse(membersplit[2]),
                                                int.Parse(membersplit[3]), bool.Parse(membersplit[4]), int.Parse(membersplit[5]),
                                                double.Parse(membersplit[6]), int.Parse(membersplit[7]), bool.Parse(membersplit[8])));
                memberline = reader.ReadLine();
            }
            reader.Close();

            return members;

        }
        public void SingleMembersDbPush(List<SingleClubMember> membersDb)
        {   //Make list here consistent.


            StreamWriter writer = new StreamWriter("../../../SingleMembersDb.txt");

            foreach (SingleClubMember member in membersDb)
            {
                if (member.ID < 600)
                {
                    writer.WriteLine($"{member.ID}|{member.Name}|{member.Enroll}|{member.Club}|{member.Employee}|{member.Bill}|{member.Status}");
                }

            }

            writer.Close();
        }
        public void MultiMembersDbPush(List<MultiClubMember> membersDb)
        {   //Make list here consistent.


            StreamWriter writer = new StreamWriter("../../../MultiMembersDb.txt");

            foreach (MultiClubMember member in membersDb)
            {

                writer.WriteLine($"{member.ID} | {member.Name} | {member.Enroll} | {member.Club} | {member.Employee} | {member.Points} | " +
             $"{member.Bill} | {member.Checkins} | {member.Status}");


            }

            writer.Close();
        }

        #endregion

        #region Club

        public List<Club> ClubsDbPull()
        {
            List<Club> clubs = new List<Club>();

            StreamReader reader = new StreamReader("../../../ClubDb.txt");

            string clubline = reader.ReadLine();
            while (clubline != null)
            {
                string[] clubsplit = clubline.Split('|');
                clubs.Add(new Club(clubsplit[0], clubsplit[1], (Ci)Enum.Parse(typeof(Ci),
                                        clubsplit[2]), (St)Enum.Parse(typeof(St), clubsplit[3])));
                clubline = reader.ReadLine();
            }
            reader.Close();
            return clubs;
        }

        public void ClubsDbPush()
        {
            List<Club> ClubDb = Club.ListClubs();

            StreamWriter writer = new StreamWriter("../../../ClubDb.txt");

            foreach (Club club in ClubDb)
            {
                writer.WriteLine($"{club.ClubName} | {club.StreetAddress} | {club.City} | {club.State}");
            }
            writer.Close();
        }

        #endregion
    }
}
