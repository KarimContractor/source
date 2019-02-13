using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Blood_Donation_Management_System.Models;
namespace Blood_Donation_Management_System.Controllers
{
    public class AdminController : Controller
    {
        ProCont con = new ProCont();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Stock()
        {
            var a = (from abc in con.BloodCollecteds select abc).ToList();
            return View(a);
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(DonorInfo di)
        {
            if (TryValidateModel(di))
            {
                DonorInfo don = new DonorInfo();
                don.Id = 0;
                don.addon = DateTime.Now.Date.ToString();
                don.Address1 = di.Address1;
                don.Address2 = di.Address2;
                don.City = di.City;
                don.CNICNo = di.CNICNo;
                don.ContactNo = di.ContactNo;
                don.Country = di.Country;
                don.DOB = di.DOB;
                don.Email = di.Email;
                don.FirstName = di.FirstName;
                don.Gender = di.Gender;
                don.LastName = di.LastName;
                don.MiddleName = di.MiddleName;
                con.DonorInfos.Add(don);
                con.SaveChanges();
                Session["MR"] = don.Id;
                return RedirectToAction("Questions",controllerName:"Admin");
            }
            else { return View(); }
        }
        public ActionResult Registerdlist()
        {
            var a = (from abc in con.DonorInfos select abc).ToList();
            return View(a);
        }
        public ActionResult Questions()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Questions(Questions qs)
        {
            if (qs.Doyouhavediabetes.Equals(!true) && qs.Haveyoueverhadacomaorstroke.Equals(!true) && qs.HaveyoueverhadapositivetestfortheHIVAIDSvirus.Equals(!true) &&
                qs.Haveyoueverhadcancer.Equals(!true) && qs.HaveyoueverhadCrohnsdisease.Equals(!true) && qs.Haveyoueverhadepilepsyorfainting.Equals(!true) &&
                qs.Haveyoueverhadkidneyorbloodproblems.Equals(!true) && qs.Haveyoueverhadmalaria.Equals(!true) && qs.Haveyoueverhadproblemswithyourheartorlungs.Equals(!true) &&
                qs.Haveyoueverreceivedaduramaterbraincoveringgraft.Equals(!true) && qs.Inthelast12monthshaveyoubeeninjailorprison.Equals(!true) && qs.Inthelast12monthshaveyouhadagraft.Equals(!true) &&
                qs.Inthelast12monthshaveyouhadclosecontactwithapersonwhohashadhepatitisoryellowjaundice.Equals(!true) && qs.Inthelast3monthshaveyouhadatattoo.Equals(!true) &&
                qs.Inthelast3monthshaveyouhadavaccination.Equals(!true) && qs.Inthelast3monthshaveyouhadskinorearpiercing.Equals(!true) && qs.Inthelast6monthshaveyouconsultedadoctorforahealthproblemhadsurgeryormedicaltreatment.Equals(!true) &&
                qs.Inthelast6monthshaveyouhadelectrolysis.Equals(!true) && qs.Inthelast6monthshaveyouhadhepatitis.Equals(!true) && qs.Inthelast6monthshaveyoureceivedbloodorbloodproducts.Equals(!true)
                )
            {
                Questions q = new Questions();
                q.MRNo = Convert.ToInt32(Session["MR"].ToString());
                q.Doyouhavediabetes = qs.Doyouhavediabetes;
                q.Haveyoueverhadacomaorstroke = qs.Haveyoueverhadacomaorstroke;
                q.HaveyoueverhadapositivetestfortheHIVAIDSvirus = qs.HaveyoueverhadapositivetestfortheHIVAIDSvirus;
                q.Haveyoueverhadcancer = qs.Haveyoueverhadcancer;
                q.HaveyoueverhadCrohnsdisease = qs.HaveyoueverhadCrohnsdisease;
                q.Haveyoueverhadepilepsyorfainting = qs.Haveyoueverhadepilepsyorfainting;
                q.Haveyoueverhadkidneyorbloodproblems = qs.Haveyoueverhadkidneyorbloodproblems;
                q.Haveyoueverhadmalaria = qs.Haveyoueverhadmalaria;
                q.Haveyoueverhadproblemswithyourheartorlungs = qs.Haveyoueverhadproblemswithyourheartorlungs;
                q.Haveyoueverreceivedaduramaterbraincoveringgraft = qs.Haveyoueverreceivedaduramaterbraincoveringgraft;
                q.Inthelast12monthshaveyoubeeninjailorprison = qs.Inthelast12monthshaveyoubeeninjailorprison;
                q.Inthelast12monthshaveyouhadagraft = qs.Inthelast12monthshaveyouhadagraft;
                q.Inthelast12monthshaveyouhadclosecontactwithapersonwhohashadhepatitisoryellowjaundice = qs.Inthelast12monthshaveyouhadclosecontactwithapersonwhohashadhepatitisoryellowjaundice;
                q.Inthelast3monthshaveyouhadatattoo = qs.Inthelast3monthshaveyouhadatattoo;
                q.Inthelast3monthshaveyouhadavaccination = qs.Inthelast3monthshaveyouhadavaccination;
                q.Inthelast3monthshaveyouhadskinorearpiercing = qs.Inthelast3monthshaveyouhadskinorearpiercing;
                q.Inthelast6monthshaveyouconsultedadoctorforahealthproblemhadsurgeryormedicaltreatment = qs.Inthelast6monthshaveyouconsultedadoctorforahealthproblemhadsurgeryormedicaltreatment;
                q.Inthelast6monthshaveyouhadelectrolysis = qs.Inthelast6monthshaveyouhadelectrolysis;
                q.Inthelast6monthshaveyouhadhepatitis = qs.Inthelast6monthshaveyouhadhepatitis;
                q.Inthelast6monthshaveyoureceivedbloodorbloodproducts = qs.Inthelast6monthshaveyoureceivedbloodorbloodproducts;

                con.Questions.Add(q);
                con.SaveChangesAsync();
                BloodCollected bc = new BloodCollected();
                bc.MRNo = q.MRNo;
                
                bc.takentime = DateTime.Now.ToLocalTime();
                bc.expires = DateTime.Now.ToLocalTime().AddDays(40);
                con.BloodCollecteds.Add(bc);
                return RedirectToAction("Registerdlist", controllerName:"Admin");
            }
            return View();
        }


    }
}