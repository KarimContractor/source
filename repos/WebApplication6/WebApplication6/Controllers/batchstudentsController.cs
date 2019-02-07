using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication6;

namespace WebApplication6.Controllers
{
    public class batchstudentsController : Controller
    {
        private imsEntities1 db = new imsEntities1();

        // GET: batchstudents
        public ActionResult Index()
        {
            var batchstudents = db.batchstudents.Include(b => b.batch).Include(b => b.student);
            return View(batchstudents.ToList());
        }

        // GET: batchstudents/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            batchstudent batchstudent = db.batchstudents.Find(id);
            if (batchstudent == null)
            {
                return HttpNotFound();
            }
            return View(batchstudent);
        }

        // GET: batchstudents/Create
        public ActionResult Create()
        {
            ViewBag.batchid = new SelectList(db.batches, "id", "Name");
            ViewBag.studentid = new SelectList(db.students, "id", "Name");
            return View();
        }

        // POST: batchstudents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,batchid,studentid")] batchstudent batchstudent)
        {
            if (ModelState.IsValid)
            {
                db.batchstudents.Add(batchstudent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.batchid = new SelectList(db.batches, "id", "Name", batchstudent.batchid);
            ViewBag.studentid = new SelectList(db.students, "id", "Name", batchstudent.studentid);
            return View(batchstudent);
        }

        // GET: batchstudents/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            batchstudent batchstudent = db.batchstudents.Find(id);
            if (batchstudent == null)
            {
                return HttpNotFound();
            }
            ViewBag.batchid = new SelectList(db.batches, "id", "Name", batchstudent.batchid);
            ViewBag.studentid = new SelectList(db.students, "id", "Name", batchstudent.studentid);
            return View(batchstudent);
        }

        // POST: batchstudents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,batchid,studentid")] batchstudent batchstudent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(batchstudent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.batchid = new SelectList(db.batches, "id", "Name", batchstudent.batchid);
            ViewBag.studentid = new SelectList(db.students, "id", "Name", batchstudent.studentid);
            return View(batchstudent);
        }

        // GET: batchstudents/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            batchstudent batchstudent = db.batchstudents.Find(id);
            if (batchstudent == null)
            {
                return HttpNotFound();
            }
            return View(batchstudent);
        }

        // POST: batchstudents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            batchstudent batchstudent = db.batchstudents.Find(id);
            db.batchstudents.Remove(batchstudent);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
