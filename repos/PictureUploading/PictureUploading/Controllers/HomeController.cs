using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace PictureUploading.Controllers
{
    public class HomeController : Controller
    {
        uploadingEntities en = new uploadingEntities();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Uploading(HttpPostedFileBase[] files)
        {
            string pic = null;
            string serverpath = "~/images/";
            bool isupload = false;
            foreach (HttpPostedFileBase f in files)
            {
                string upload = Path.Combine(Server.MapPath(serverpath + "" + Path.GetFileName(f.FileName)));
                f.SaveAs(upload);
                pic += Path.GetFileName(f.FileName) + ",";
                isupload = true;
                
            }
            if (isupload == true)
            {
                pictable tbl = new pictable();
                tbl.picpath = serverpath;
                tbl.picname = pic;
                en.pictables.Add(tbl);
                en.SaveChanges();
                ViewBag.msg = "Picture Uploaded";
            }
            else { ViewBag.msg = "Picture Not Uploaded"; }
            var listofimg = en.pictables.ToList();

            return View(listofimg);
        }

    }
}