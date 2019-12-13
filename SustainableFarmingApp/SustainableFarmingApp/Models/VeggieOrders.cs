using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SustainableFarmingApp.Models
{
    public class VeggieOrders
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }

        public string Name { get; set; }
        public string location { get; set; }
        public string NameOfVeggie { get; set; }
        public int VeggieAmount { get; set; }

    }
}
