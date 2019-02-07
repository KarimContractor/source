using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApplication10.Models
{
    public class Stock
    {
        [Key]
        
        public int id { get; set; }
        //[RegularExpression("$[A-Za-z]$",ErrorMessage ="Please Enter a Valid Name")]
        public string Name { get; set; }
        public string Category { get; set; }
        public int Quantity { get; set; }
        
        public int UnitPriceavg { get; set; }
        
    }
}