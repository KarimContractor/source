﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Blood_Donation_Management_System.Models;

namespace Blood_Donation_Management_System.Controllers
{
    public class HomeController : Controller
    {
        ProCont con = new ProCont();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login(Logs lg)
        {
                var a =await (from abc in con.Log where abc.UserName.Equals(lg.UserName) && abc.Password.Equals(lg.Password) select abc).FirstOrDefaultAsync();
                if (a != null)
                {
                if (a.Previlage.Equals("Admin"))
                {
                    TempData["id"] = a.Id;
                    Session["key"] = a.Id;
                    return RedirectToAction("Index", controllerName: "Admin");
                }
                else if (a.Previlage.Equals("Inhouse"))
                {
                    //TempData["id"] = a.Id;
                    Session["in"] = a.Id;
                    return RedirectToAction("Index", controllerName: "Inhouse");
                }
                else
                {
                    return View();
                }

                }
                else {
                    return View();
                }
            
            
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}