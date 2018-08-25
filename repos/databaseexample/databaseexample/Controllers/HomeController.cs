using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace databaseexample.Controllers
{
    public class HomeController : Controller
    {

        linqEntities lq = new linqEntities();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(login lg)
        {
            if (ModelState.IsValid)
            {
                lq.logins.Add(lg);
                lq.SaveChanges();
                return RedirectToAction("Register", "Home");
            }
            else
            {
                return View();
            }
        }
        public ActionResult Register()
        {
            return View((lq.logins.ToList()));
        }
        
        public ActionResult Delete(login lg)
        {
            

            lq.deletev(lg.id);

            return RedirectToAction("Register", "Home");
        }
        
        public ActionResult Edit(login lg)
        {
            if (ModelState.IsValid)
            {
                return View(lq.logins.Single(s => s.id == lg.id));
            }
            else { return View(); }
        }
        
        public ActionResult Details(login lg)
        {
            return View(lq.logins.Single(s=> s.id==lg.id));

        }

    }
}