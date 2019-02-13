using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Blood_Donation_Management_System.Models;


namespace Blood_Donation_Management_System.Controllers
{
    
    public class InhouseController : Controller
    {
        ProCont con = new ProCont();    
        // GET: Inhouse
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult BloodDetails(int MRno)
        {
            Session["MR"] = MRno;
            var a = (from abc in con.BloodCollecteds where abc.MRNo.Equals(MRno) select abc).FirstOrDefault();

            return View(a);
        }
        public ActionResult Tests()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Tests(Tests Ts)
        {
            int mr = Convert.ToInt32(Session["MR"].ToString());
            Tests tst = new Tests();
            tst.MRno = mr;
            tst.BloodAntiBodies = Ts.BloodAntiBodies;
            tst.BloodGroup = Ts.BloodGroup;
            tst.ChagasdiseaseTrypanosomacruzi = Ts.ChagasdiseaseTrypanosomacruzi;
            tst.Cytomegalovirus = Ts.Cytomegalovirus;
            tst.HeptitisB = Ts.HeptitisB;
            tst.HeptitisC = Ts.HeptitisC;
            tst.HIV1 = Ts.HIV1;
            tst.HIV2 = Ts.HIV2;
            tst.HTLV1 = Ts.HTLV1;
            tst.HTLV2 = Ts.HTLV2;
            tst.RH = Ts.RH;
            tst.SyphilisTreponemapallidum = Ts.SyphilisTreponemapallidum;
            tst.WestNileVirus = Ts.WestNileVirus;
            
            con.Test.Add(tst);
            con.SaveChanges();
            if (Ts.ChagasdiseaseTrypanosomacruzi.Equals(!true)&& Ts.Cytomegalovirus.Equals(!true)&& Ts.HeptitisB.Equals(!true)&& Ts.HeptitisC.Equals(!true)&&
                Ts.HIV1.Equals(!true)&& Ts.HIV2.Equals(!true)&& Ts.HTLV1.Equals(!true)&& Ts.HTLV2.Equals(!true)&& Ts.SyphilisTreponemapallidum.Equals(!true)&&
                Ts.WestNileVirus.Equals(!true))
            {
                
                var a = (from abc in con.BloodCollecteds where abc.MRNo.Equals(mr) select abc).FirstOrDefault();
                BloodStock bs = new BloodStock();
                bs.MrNo = a.MRNo;
                bs.Taken = a.takentime;
                bs.Expires = a.expires;
                con.bloodStocks.Add(bs);
                con.SaveChanges();
                

            }

            return View();
        }



    }
}