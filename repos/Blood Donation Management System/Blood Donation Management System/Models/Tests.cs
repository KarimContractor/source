using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Blood_Donation_Management_System.Models
{
    public class Tests
    {
        [Key]
        public int Id { get; set; }
        public int MRno { get; set; }
        public int BCId { get; set; }
        public string BloodGroup { get; set; }
        public bool RH { get; set; }
        public string BloodAntiBodies { get; set; }
        public bool HIV1 { get; set; }
        public bool HIV2 { get; set; }
        public bool HTLV1 { get; set; }
        public bool HTLV2 { get; set; }
        public bool HeptitisB { get; set; }
        public bool HeptitisC { get; set; }
        public bool SyphilisTreponemapallidum { get; set; }
        public bool WestNileVirus { get; set; }
        public bool ChagasdiseaseTrypanosomacruzi { get; set; }
        public bool Cytomegalovirus { get; set; }
    }
}