using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCconnprac.Controllers
{
    public class TeacherController : Controller
    {
        // GET: Teacher
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
                return RedirectToAction("Index", "Student");
            }

            else if (role.Equals("Teacher"))
            {
                Session["Role"] = role;
                ViewBag.Role = Session["Role"];
                return View("Index");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }


        }
    }
}