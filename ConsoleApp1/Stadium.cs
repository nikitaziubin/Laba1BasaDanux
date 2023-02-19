using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApp1
{
    internal class Stadium
    {

        public int id { get; set; }
        public static int iID;

        public string adress { get; set; }
        public string name { get; set; }
        public int capacity { get; set; }
        public int max_capacity { get; set; }

        public Stadium(string adress, string name, int capacity, int max_capacity)
        {
            id = iID + 1;
            iID++;
            this.name = name;
            this.adress = adress;
            this.capacity = capacity;
            this.max_capacity = max_capacity;
        }
    }
}
