using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Infoview(string txtname, string txtfname,string txtcnic,string txtemail, string txtcontact)
        {
            ViewBag.Name = txtname;
            ViewBag.fname = txtfname;
            ViewBag.cnic = txtcnic;
            ViewBag.email = txtemail;
            ViewBag.contact = txtcontact;
            return View();
        }
    }
}