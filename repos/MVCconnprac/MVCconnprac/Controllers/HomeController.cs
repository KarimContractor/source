using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Data;
using System.ComponentModel;

namespace MVCconnprac.Controllers
{
    public class HomeController : Controller
    {
        //SqlConnection con = new SqlConnection("server=DESKTOP-VKTSVTO; database=mvcconpra; user id=sa; password=123");
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
            return View();
        }
        [HttpPost]
        public ActionResult login(login lg)
        {
            testingEntities te = new testingEntities();
            var v = (from ob in te.logins where ob.Username.Equals(lg.Username) && ob.password.Equals(lg.password) select ob.role).FirstOrDefault();
            if (v != null)
            {
                if (v.ToString().Equals("Admin"))
                {
                    Session["Role"] = v.ToString();
                    return RedirectToAction("Index", "Admin");
                }


                else if (v.ToString().Equals("Student"))
                {
                    Session["Role"] = v.ToString();
                    return RedirectToAction("Index", "Student");
                }

                else if (v.ToString().Equals("Teacher"))
                {
                    Session["Role"] = v.ToString();
                    return RedirectToAction("Index", "Teacher");
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
                //checklog(v.ToString());
                
            }
            else
            {
                ViewBag.data = "Wrong username or password";
                return View();
            }
            /*SqlDataAdapter da = new SqlDataAdapter("select * from logins where username='"+ user +"' and pass='"+pass+"'",con);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                string Role = dt.Rows[0][3].ToString();
                return checklog(Role);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }*/
            
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
                return RedirectToAction("Index", "Teacher");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }



        }
        public ActionResult register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult register(login ls)
        {

            testingEntities et = new testingEntities();
            if (ModelState.IsValid)
            {
                et.logins.Add(ls);
                
                if (et.SaveChanges() > 0)
                {
                    ViewBag.data = "Account registered successfully......";
                }
            }
            else {
                return View();
            }
            return View();

        }

    }
}