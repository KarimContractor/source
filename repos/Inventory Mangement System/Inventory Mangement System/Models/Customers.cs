using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inventory_Mangement_System.Models
{
    public class Customers
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Rating { get; set; }
        public DateTime Customerfrom { get; set; }

    }
}