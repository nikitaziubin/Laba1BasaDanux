using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Matche
    {
        public int id { get; set; }
        public static int ID { get; set; }

        public int homeTeamGoals { get; set; }
        public int visitorTeamGoals { get; set; }
        public int division { get; set; }
        public string date { get; set; }
        public int stadiumID { get; set; }

        public Matche(int homeTeamGoals, int visitorTeamGoals, int division, string date, int stadiumID)
        {
            id = ID + 1;
            ID++;
            this.homeTeamGoals = homeTeamGoals;
            this.visitorTeamGoals = visitorTeamGoals;
            this.division = division;
            this.date = date;
            this.stadiumID = stadiumID;
        }
    }
}
