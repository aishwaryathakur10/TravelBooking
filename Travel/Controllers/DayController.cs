using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Travel.CustomFilters;
using Travel.Models;

namespace Travel.Controllers
{
    public class DayController : Controller
    {
        private TravelBookingEntities db = new TravelBookingEntities();

        // GET: /Day/
             [AuthLog(Roles = "Admin")]
        public ActionResult Index()
        {
            var table_day = db.Table_day.Include(t => t.Table_route);
            return View(table_day.ToList());
        }

        // GET: /Day/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Table_day table_day = db.Table_day.Find(id);
            if (table_day == null)
            {
                return HttpNotFound();
            }
            return View(table_day);
        }

        // GET: /Day/Create
        public ActionResult Create()
        {
            ViewBag.R_id = new SelectList(db.Table_route, "R_id", "R_name");
            return View();
        }

        // POST: /Day/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="A_id,R_id,Day")] Table_day table_day)
        {
            if (ModelState.IsValid)
            {
                db.Table_day.Add(table_day);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.R_id = new SelectList(db.Table_route, "R_id", "R_name", table_day.R_id);
            return View(table_day);
        }

        // GET: /Day/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Table_day table_day = db.Table_day.Find(id);
            if (table_day == null)
            {
                return HttpNotFound();
            }
            ViewBag.R_id = new SelectList(db.Table_route, "R_id", "R_name", table_day.R_id);
            return View(table_day);
        }

        // POST: /Day/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="A_id,R_id,Day")] Table_day table_day)
        {
            if (ModelState.IsValid)
            {
                db.Entry(table_day).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.R_id = new SelectList(db.Table_route, "R_id", "R_name", table_day.R_id);
            return View(table_day);
        }

        // GET: /Day/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Table_day table_day = db.Table_day.Find(id);
            if (table_day == null)
            {
                return HttpNotFound();
            }
            return View(table_day);
        }

        // POST: /Day/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Table_day table_day = db.Table_day.Find(id);
            db.Table_day.Remove(table_day);
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
