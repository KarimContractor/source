using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApplication7.Models
{
    public class Contactus
    {
        [Required]
        [StringLength(20)]
        public int Id { get; set; }
        [Required]
        [StringLength(20)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(20)]
        [Compare(nameof(FatherName))]
        public string LastName { get; set; }
        [Required]
        [StringLength(20)]
        [Compare(nameof(LastName))]
        public string FatherName { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Dateofbirth { get; set; }
        [Required]

        public string Address { get; set; }
        [Required]
        [RegularExpression("[A-Za-z1-9]{3,15}$")]
        public string UserName { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string MobileNumber { get; set; }
        [Required]
        [Range(5000, 150000)]
        public int Salary { get; set; }
    }
}