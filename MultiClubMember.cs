using System;
using System.Collections.Generic;
using System.Text;

namespace midtermproj
{
    class MultiClubMember : Member
    {
        public int Points { get; set; }
        public double Bill { get; set; }
        public int Checkins { get; set; }
        public MultiClubMember() { }

        public MultiClubMember(int id, string name, DateTime enroll, int points, double bill, int checkins):base(id,name,enroll)
        {
            Points = points;
            Bill = bill;
            Checkins = checkins;
        }
       
        public override void CheckIn(ClubClass club)
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

        public override int IdAssign()
        {
            if (Id == 0)
            {
                Id = 600+"multiDB.Count"
            }
            else
            {
                Utility.PrintYellow("Member already has an ID number.");
            }
            return Id;
        }
        
        public void DisplayInfo()
        {
            Console.WriteLine($"Name: {Name}\nID: {Id}\nDate of Enrollment: {Enroll}\n Accumulated Points: {Points}");
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
    }
}
