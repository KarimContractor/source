using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Blood_Donation_Management_System.Models
{
    public class ProCont: DbContext
    {
        public ProCont() : base("Bloodcon") { }
        public DbSet<DonorInfo> DonorInfos { get; set; }
        public DbSet<Logs> Log { get; set; }
        public DbSet<Tests> Test { get; set; }
        public DbSet<BloodCollected> BloodCollecteds { get; set; }
        public DbSet<Questions> Questions { get; set; }
        public DbSet<BloodStock> bloodStocks { get; set; }
    }
}