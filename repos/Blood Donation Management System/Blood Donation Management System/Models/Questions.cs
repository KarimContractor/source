using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace Blood_Donation_Management_System.Models
{
    public class Questions
    {
        [Key]
        public int Id { get; set; }
        public int MRNo { get; set; }
        [Required]
        public bool Inthelast3monthshaveyouhadavaccination { get; set; }
        [Required]
        public bool Inthelast6monthshaveyouconsultedadoctorforahealthproblemhadsurgeryormedicaltreatment {get;set;}
        [Required]
        public bool Doyouhavediabetes { get; set; }
        [Required]
        public bool Haveyoueverhadmalaria { get; set; }
        [Required]
        public bool Haveyoueverhadkidneyorbloodproblems { get; set; }
        [Required]
        public bool Haveyoueverhadproblemswithyourheartorlungs { get; set; }
        [Required]
        public bool Inthelast12monthshaveyouhadclosecontactwithapersonwhohashadhepatitisoryellowjaundice { get; set; }
        [Required]
        public bool Haveyoueverhadepilepsyorfainting { get; set; }
        [Required]
        public bool Haveyoueverhadacomaorstroke { get; set; }
        [Required]
        public bool Haveyoueverhadcancer { get; set; }
        [Required]
        public bool Inthelast12monthshaveyouhadagraft { get; set; }
        [Required]
        public bool HaveyoueverhadCrohnsdisease { get; set; }
        [Required]
        public bool Haveyoueverreceivedaduramaterbraincoveringgraft { get; set; }
        [Required]
        public bool HaveyoueverhadapositivetestfortheHIVAIDSvirus { get; set; }
        [Required]
        public bool Inthelast6monthshaveyoureceivedbloodorbloodproducts { get; set; }
        [Required]
        public bool Inthelast6monthshaveyouhadhepatitis { get; set; }
        [Required]
        public bool Inthelast3monthshaveyouhadskinorearpiercing { get; set; }
        [Required]
        public bool Inthelast3monthshaveyouhadatattoo { get; set; }
        [Required]
        public bool Inthelast6monthshaveyouhadelectrolysis { get; set; }
        [Required]
        public bool Inthelast12monthshaveyoubeeninjailorprison { get; set; }



    }
}