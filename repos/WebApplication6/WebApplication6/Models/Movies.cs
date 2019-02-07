using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace WebApplication6.Models
{
    public class Movies
    {
        public Int32 id { get; set; }
        public string Name { get; set; }
        public DateTime dateR { get; set; }
        public string genre { get; set; }
        public string Rating { get; set; }
    }
    public class moviecontext : DbContext
    {
        public DbSet<Movies>Movies{ get; set; }
    }
}