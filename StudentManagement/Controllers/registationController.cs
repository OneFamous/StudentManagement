using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StudentManagement.Models;

namespace StudentManagement.Controllers
{
    public class registationController : Controller
    {
        private managerEntities db = new managerEntities();

        // GET: registation
        public ActionResult Index()
        {
            var registation = db.registation.Include(r => r.batch).Include(r => r.course);
            return View(registation.ToList());
        }

        // GET: registation/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            registation registation = db.registation.Find(id);
            if (registation == null)
            {
                return HttpNotFound();
            }
            return View(registation);
        }

        // GET: registation/Create
        public ActionResult Create()
        {
            ViewBag.batch_id = new SelectList(db.batch, "id", "batch1");
            ViewBag.course_id = new SelectList(db.course, "id", "course1");
            return View();
        }

        // POST: registation/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,firstname,lastname,nic,course_id,batch_id,telno")] registation registation)
        {
            if (ModelState.IsValid)
            {
                db.registation.Add(registation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.batch_id = new SelectList(db.batch, "id", "batch1", registation.batch_id);
            ViewBag.course_id = new SelectList(db.course, "id", "course1", registation.course_id);
            return View(registation);
        }

        // GET: registation/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            registation registation = db.registation.Find(id);
            if (registation == null)
            {
                return HttpNotFound();
            }
            ViewBag.batch_id = new SelectList(db.batch, "id", "batch1", registation.batch_id);
            ViewBag.course_id = new SelectList(db.course, "id", "course1", registation.course_id);
            return View(registation);
        }

        // POST: registation/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,firstname,lastname,nic,course_id,batch_id,telno")] registation registation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(registation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.batch_id = new SelectList(db.batch, "id", "batch1", registation.batch_id);
            ViewBag.course_id = new SelectList(db.course, "id", "course1", registation.course_id);
            return View(registation);
        }

        // GET: registation/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            registation registation = db.registation.Find(id);
            if (registation == null)
            {
                return HttpNotFound();
            }
            return View(registation);
        }

        // POST: registation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            registation registation = db.registation.Find(id);
            db.registation.Remove(registation);
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
