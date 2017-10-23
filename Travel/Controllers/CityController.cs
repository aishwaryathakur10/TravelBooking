using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Travel.Models;

namespace Travel.Controllers
{
    public class CityController : Controller
    {
        private TravelBookingEntities db = new TravelBookingEntities();

        // GET: /City/
        public ActionResult Index()
        {
            return View(db.Table_city.ToList());
        }

        // GET: /City/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Table_city table_city = db.Table_city.Find(id);
            if (table_city == null)
            {
                return HttpNotFound();
            }
            return View(table_city);
        }

        // GET: /City/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /City/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="C_id,City")] Table_city table_city)
        {
            if (ModelState.IsValid)
            {
                db.Table_city.Add(table_city);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(table_city);
        }

        // GET: /City/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Table_city table_city = db.Table_city.Find(id);
            if (table_city == null)
            {
                return HttpNotFound();
            }
            return View(table_city);
        }

        // POST: /City/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="C_id,City")] Table_city table_city)
        {
            if (ModelState.IsValid)
            {
                db.Entry(table_city).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(table_city);
        }

        // GET: /City/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Table_city table_city = db.Table_city.Find(id);
            if (table_city == null)
            {
                return HttpNotFound();
            }
            return View(table_city);
        }

        // POST: /City/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Table_city table_city = db.Table_city.Find(id);
            db.Table_city.Remove(table_city);
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
