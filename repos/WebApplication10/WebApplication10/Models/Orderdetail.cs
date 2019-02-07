using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication10.Models
{
    public class Orderdetail
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public int StockId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        //public virtual Stock { get; set; }
        //public virtual Order Order { get; set; }
    }
}