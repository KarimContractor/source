using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication6.Controllers
{
    public class HomeController : Controller
    {
        ELibraryEntities eLibrary = new ELibraryEntities();
        public ActionResult Index()
        {
            
            return View(eLibrary.Admins.ToList());
        }
        public ActionResult Create()
        {


            return View();
        }
        [HttpPost]
        public ActionResult Create(Admin ad)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            else {
                eLibrary.Admins.Add(ad);
                eLibrary.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
        }
        public ActionResult Edit(Admin ad)
        {
            return View(eLibrary.Admins.Single(s=>s.Id==ad.Id));
        }
        [HttpPost]
        public ActionResult Edits(Admin ad)
        {
            var a = (from abc in eLibrary.Admins where abc.Id.Equals(ad.Id) select abc).FirstOrDefault();
            a.Name = ad.Name;
            a.UserName = ad.UserName;
            a.Password = ad.Password;
            a.status = ad.status;
            Edit(a);
            eLibrary.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Delete(Admin ad)
        {
            var a = (from abc in eLibrary.Admins where abc.Id.Equals(ad.Id) select abc).FirstOrDefault();
            eLibrary.Admins.Remove(a);
            eLibrary.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
        public ActionResult Details(Admin ad)
        {

            var a = (from abc in eLibrary.Admins where abc.Id.Equals(ad.Id) select abc).FirstOrDefault();
            return View(a);
        }



    }
}