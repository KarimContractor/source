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
        
        public bool Inthelast3monthshaveyouhadavaccination { get; set; }
        public bool Inthelast6monthshaveyouconsultedadoctorforahealthproblemhadsurgeryormedicaltreatment {get;set;}
        public bool Doyouhavediabetes { get; set; }
        public bool Haveyoueverhadmalaria { get; set; }
        public bool Haveyoueverhadkidneyorbloodproblems { get; set; }
        public bool Haveyoueverhadproblemswithyourheartorlungs { get; set; }
        public bool Inthelast12monthshaveyouhadclosecontactwithapersonwhohashadhepatitisoryellowjaundice { get; set; }
        public bool Haveyoueverhadepilepsyorfainting { get; set; }
        public bool Haveyoueverhadacomaorstroke { get; set; }
        public bool Haveyoueverhadcancer { get; set; }
        public bool Inthelast12monthshaveyouhadagraft { get; set; }
        public bool HaveyoueverhadCrohnsdisease { get; set; }
        public bool Haveyoueverreceivedaduramaterbraincoveringgraft { get; set; }
        public bool HaveyoueverhadapositivetestfortheHIVAIDSvirus { get; set; }
        public bool Inthelast6monthshaveyoureceivedbloodorbloodproducts { get; set; }
        public bool Inthelast6monthshaveyouhadhepatitis { get; set; }
        public bool Inthelast3monthshaveyouhadskinorearpiercing { get; set; }
        public bool Inthelast3monthshaveyouhadatattoo { get; set; }
        public bool Inthelast6monthshaveyouhadelectrolysis { get; set; }
        public bool Inthelast12monthshaveyoubeeninjailorprison { get; set; }



    }
}