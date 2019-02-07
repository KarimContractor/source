using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace Blood_Donation_Management_System.Models
{
    public class BloodStock
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int MrNo { get; set; }
        [Required]
        public DateTime Taken { get; set; }
        [Required]
        public DateTime Expires { get; set; }
    }
}