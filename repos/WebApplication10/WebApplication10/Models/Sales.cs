using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApplication10.Models
{
    public class Sales
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        
        public int CustomerId { get; set; }
        public int OrderId { get; set; }
    }
}