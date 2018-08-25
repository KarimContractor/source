using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCconnprac.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            try
            {
                Response.Cache.SetNoStore();
                if (Session["Role"].ToString() != "")
                {
                    return checklog(Session["Role"].ToString());
                }
                else
                {
                    return View();
                }

            }
            catch (Exception ex) { ViewBag.data = ex.Message; }
            
            ViewBag.Role = Session["Role"];
            return View();
        }
        public ActionResult checklog(string role)
        {
            if (role.Equals("Admin"))
            {
                Session["Role"] = role;
                return RedirectToAction("Index", "Admin");
            }


            else if (role.Equals("Student"))
            {
                Session["Role"] = role;
                ViewBag.Role = Session["Role"];
                return View("Index");
            }

            else if (role.Equals("Teacher"))
            {
                Session["Role"] = role;
                return RedirectToAction("Index", "Teacher");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }


        }
    }
}