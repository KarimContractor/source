using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
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

            try
            {
                if (Session["in"].ToString() != null)
                {
                    var id = Convert.ToInt32(Session["in"].ToString());
                    var a = (from abc in con.Log where abc.Id.Equals(id) select abc).FirstOrDefault();
                    //Session["id"] = a.Id;
                    if (Session["in"].ToString() != null)
                    {
                        return View();
                    }
                    else
                    {
                        return RedirectToAction("Login", controllerName: "Home");
                    }
                }
                else
                {
                    return RedirectToAction("Index", controllerName: "Home");
                }
            }
            catch (Exception) { return RedirectToAction("Login", controllerName: "Home"); }
        }
        [HttpPost]
        public async Task<ActionResult> BloodDetails(int MRno)
        {
            try
            {
                Session["MR"] = MRno;
                var a = await (from abc in con.BloodCollecteds where abc.MRNo.Equals(MRno) select abc).FirstOrDefaultAsync();
                Session["bcid"] = a.Id;
                //con.BloodCollecteds.ToListAsync();
                return View(a);
            } catch (Exception) { return RedirectToAction("Index", controllerName: "Inhouse"); }
        }
        
        public ActionResult Bloodgroup()
        {
            try
            {
                if (Session["in"].ToString() != null)
                {

                    return View();
                }
                else { return RedirectToAction("Login", controllerName: "Home"); }
            }
            catch (Exception) { return RedirectToAction("Index", controllerName: "Inhouse"); }

        }
        [HttpPost]
        public ActionResult Bloodgroup(Tests ts)
        {
            //Tests tsc = new Tests();
            int mr = Convert.ToInt32(Session["MR"].ToString());
            Session["MRno"] = mr;
            Session["BloodGroup"] = ts.BloodGroup;
            Session["RH"] = ts.RH;
            Session["BloodAntiBodies"] = ts.BloodAntiBodies;
            return RedirectToAction("HIV", controllerName: "Inhouse");
        }
        public ActionResult HIV()
        {
            //Tests tsc = new Tests();
           // tsc.BloodAntiBodies = ts.BloodAntiBodies;
            //tsc.BloodGroup = ts.BloodGroup;
            //tsc.RH = ts.RH;

            try
            {
                if (Session["in"].ToString() != null)
                {

                    return View();
                }
                else { return RedirectToAction("Login", controllerName: "Home"); }
            }
            catch (Exception) { return RedirectToAction("Index", controllerName: "Inhouse"); }

        }
        [HttpPost]
        public ActionResult HIV(Tests ts)
        {
            Session["HIV1"] = ts.HIV1;
            Session["HIV2"] = ts.HIV2;


            return RedirectToAction("Heptitis", controllerName: "Inhouse");
        }
        public ActionResult Heptitis()
        {
            try
            {
                if (Session["in"].ToString() != null)
                {

                    return View();
                }
                else { return RedirectToAction("Login", controllerName: "Home"); }
            }
            catch (Exception) { return RedirectToAction("Index", controllerName: "Inhouse"); }

        }
        [HttpPost]
        public ActionResult Heptitis(Tests ts)
        {
            Session["HeptitisB"] = ts.HeptitisB;
            Session["HeptitisC"] = ts.HeptitisC;
            
            return RedirectToAction("HTLV", controllerName: "Inhouse");
        }
        public ActionResult HTLV()
        {
            try
            {
                if (Session["in"].ToString() != null)
                {

                    return View();
                }
                else { return RedirectToAction("Login", controllerName: "Home"); }
            }
            catch (Exception) { return RedirectToAction("Index", controllerName: "Inhouse"); }

        }
        [HttpPost]
        public ActionResult HTLV(Tests ts)
        {
            Session["HTLV1"] = ts.HTLV1;
            Session["HTLV2"] = ts.HTLV2;

            return RedirectToAction("Tests", controllerName: "Inhouse");
        }

        public ActionResult Tests()
        {
            try
            {
                if (Session["in"].ToString() != null)
                {

                    return View();
                }
                else { return RedirectToAction("Login", controllerName: "Home"); }
            }
            catch (Exception) { return RedirectToAction("Index", controllerName: "Inhouse"); }
        }
        [HttpPost]
        public async Task<ActionResult> Tests(Tests Ts)
        {
            int mr = Convert.ToInt32(Session["MR"].ToString());

            Tests tss = new Tests();
            tss.BCId =Convert.ToInt32(Session["bcid"]);
            tss.BloodAntiBodies = Session["BloodAntiBodies"].ToString();
            tss.MRno =Convert.ToInt32( Session["MRno"].ToString());
            tss.BloodGroup = Session["BloodGroup"].ToString();
            tss.RH=Convert.ToBoolean(Session["RH"].ToString());
            tss.HIV1 = Convert.ToBoolean(Session["HIV1"].ToString());
            tss.HIV2= Convert.ToBoolean(Session["HIV2"].ToString());
            tss.HeptitisB = Convert.ToBoolean(Session["HeptitisB"] .ToString());
            tss.HeptitisC= Convert.ToBoolean(Session["HeptitisC"].ToString()) ;
            tss.HTLV1= Convert.ToBoolean(Session["HTLV1"].ToString());
            tss.HTLV2 = Convert.ToBoolean(Session["HTLV2"].ToString());
            tss.ChagasdiseaseTrypanosomacruzi = Ts.ChagasdiseaseTrypanosomacruzi;
            tss.Cytomegalovirus = Ts.Cytomegalovirus;
            tss.SyphilisTreponemapallidum = Ts.SyphilisTreponemapallidum;
            tss.WestNileVirus = Ts.WestNileVirus;
            con.Test.Add(tss);
            if (tss.ChagasdiseaseTrypanosomacruzi.Equals(!true) && tss.Cytomegalovirus.Equals(!true) && tss.HeptitisB.Equals(!true) && tss.HeptitisC.Equals(!true) &&
                tss.HIV1.Equals(!true) && tss.HIV2.Equals(!true) && tss.HTLV1.Equals(!true) && tss.HTLV2.Equals(!true) && tss.SyphilisTreponemapallidum.Equals(!true) &&
                tss.WestNileVirus.Equals(!true))
            {   var a = (from abc in con.BloodCollecteds where abc.MRNo.Equals(mr) select abc).FirstOrDefault();
                BloodStock bs = new BloodStock();
                bs.MrNo = a.MRNo;
                bs.Taken = a.takentime;
                bs.Expires = a.expires;
                con.bloodStocks.Add(bs);
                await con.SaveChangesAsync();

                Session.Remove("HTLV2");
                Session.Remove("HTLV1");
                Session.Remove("HeptitisC");
                Session.Remove("HeptitisB");
                Session.Remove("HIV2");
                Session.Remove("HIV1");
                Session.Remove("RH");
                Session.Remove("BloodGroup");
                Session.Remove("bcid");
                Session.Remove("MRno");
                Session.Remove("BloodAntiBodies");
               return RedirectToAction("Index", controllerName: "Inhouse");
            }
            else
            {
                return View();
            }
        }



    }
}