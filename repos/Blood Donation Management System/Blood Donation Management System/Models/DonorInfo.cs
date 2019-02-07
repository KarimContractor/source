using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blood_Donation_Management_System.Models
{
    public class DonorInfo
    {
        [Key]
        public int Id { get; set; }
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //[Index]
       // public int MRNo { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public string DOB { get; set; }
        [Required]
        public string CNICNo { get; set; }
        [Required]
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string ContactNo { get; set; }
        [Required]
        public string Email { get; set; }
        
        public string addon { get; set; }

        public string updatedon { get; set; }
    }
}