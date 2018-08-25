using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AjaxConn.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult States()
        {
            

            return PartialView();
        }

        public PartialViewResult City()

        {
            ViewBag.Message = "Your contact page.";

            return PartialView();
        }
    }
}