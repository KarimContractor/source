using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApplication10.Models
{
    public class Recivables
    {
        [Key]
        public int Id { get; set; }
        public int SalesID { get; set; }
        public int CustomerID { get; set; }
        public DateTime dateadd { get; set; }
        public string Status { get; set; }
        public DateTime? updatedate { get; set; }
        public int SlipNo { get; set; }


    }
}