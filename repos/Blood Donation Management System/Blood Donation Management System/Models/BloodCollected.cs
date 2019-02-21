using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blood_Donation_Management_System.Models
{
    public class BloodCollected
    {
        public int Id { get; set; }
        public int MRNo { get; set; }
        public DateTime takentime { get; set; }
        public DateTime  expires { get; set; }
       // public ICollection<Tests> test { get; set; }
    }
}