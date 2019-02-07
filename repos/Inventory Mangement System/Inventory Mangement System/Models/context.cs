using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Inventory_Mangement_System.Models
{
    public class context: DbContext
    {
        public context() : base("name=dbcon") { }
        public DbSet<Customers> customer { get; set; }
        public DbSet<Logs> log { get; set; }
        public DbSet<Payables> Payable { get; set; }
        public DbSet<Providers> Provider { get; set; }
        public DbSet<Purchases> Purchase { get; set; }
        public DbSet<Recivables> Recivable { get; set; }
        public DbSet<Sales> Sale { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Orderdetail> Orderdetails { get; set; }
    }
}