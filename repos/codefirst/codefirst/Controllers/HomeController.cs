using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using codefirst.Models;
namespace codefirst.Controllers
{
    public class HomeController : Controller
    {
        
        StudentContext objstd;
        
        public HomeController()
        {
            objstd = new StudentContext();
            
        }
        public ActionResult Index()
        {
            var student = objstd.Students.ToList();
            return View(student);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Student student)
        {
            objstd.Students.Add(student);
            objstd.SaveChanges();
            return View();
        }
        public ActionResult list()
        {
            var abc = objstd.Teachers.ToList();
            return View(abc);

        }

    }
}