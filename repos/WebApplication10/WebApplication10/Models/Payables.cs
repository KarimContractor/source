using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication10.Models
{
    public class Payables
    {
        public int Id { get; set; }
        public int PurchasesID { get; set; }
        public int ProvidersID { get; set; }
        public DateTime dateadd { get; set; }
        public string Status { get; set; }
        public DateTime? updatedate { get; set; }
        public int SlipNo { get; set; }


    }
}