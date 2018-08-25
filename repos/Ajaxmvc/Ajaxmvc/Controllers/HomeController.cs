using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ajaxmvc.Controllers
{
    public class HomeController : Controller
    {
        testingEntities te = new testingEntities();
        public ActionResult Index()
        {
            
            return View();
        }
        public ActionResult All()
        {
          var a=  te.logins.ToList();
            return PartialView("my",a);
        }
        public ActionResult few3()
        {

            var a = te.logins.OrderBy(c => c.id).Take (3);
            return PartialView("my", a);


        }
        public ActionResult few6()
        {
            var a = te.logins.OrderBy(c => c.id).Take(6);
            return PartialView("my", a);



        }
        public PartialViewResult abc()
        {

            return PartialView();
        }

    }
}