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
    public class DetailController : Controller
    {
        private TravelBookingEntities db = new TravelBookingEntities();

        // GET: /Default1/
        public ActionResult Index()
        {
            var table_bus = db.Table_bus.Include(t => t.Table_day).Include(t => t.Table_route);
            return View(table_bus.ToList());
        }




        public ActionResult SeatInfo(int? id)
        {

            var name = from a in db.Table_bus.Where(a=> a.B_id == id) select a.B_name;
            
            ViewBag.busname = name.FirstOrDefault();



            ViewBag.seat = from a in db.Table_bus.Where(a => a.B_id == id) select a.Available_Seats;

            return View();
        }

        public ActionResult Confirmed()
        {

            return View();
        }


        // GET: /Default1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Table_bus table_bus = db.Table_bus.Find(id);
            if (table_bus == null)
            {
                return HttpNotFound();
            }
            return View(table_bus);
        }

        // GET: /Default1/Create
        [AuthLog(Roles = "Admin")]
        public ActionResult Create()
        {
            ViewBag.Day = new SelectList(db.Table_day, "Day", "Day");
            ViewBag.R_id = new SelectList(db.Table_route, "R_id", "R_id");
            return View();
        }

        // POST: /Default1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="B_id,B_name,Time,Available_Seats,R_id,Day")] Table_bus table_bus)
        {
            if (ModelState.IsValid)
            {
                db.Table_bus.Add(table_bus);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Day = new SelectList(db.Table_day, "Day", "Day", table_bus.Day);
            ViewBag.R_id = new SelectList(db.Table_route, "R_id", "R_id", table_bus.R_id);
            return View(table_bus);
        }

        // GET: /Default1/Edit/5
         [AuthLog(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Table_bus table_bus = db.Table_bus.Find(id);
            if (table_bus == null)
            {
                return HttpNotFound();
            }
            ViewBag.Day = new SelectList(db.Table_day, "Day", "Day", table_bus.Day);
            ViewBag.R_id = new SelectList(db.Table_route, "R_id", "R_id", table_bus.R_id);
            return View(table_bus);
        }

        // POST: /Default1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="B_id,B_name,Time,Available_Seats,R_id,Day")] Table_bus table_bus)
        {
            if (ModelState.IsValid)
            {
                db.Entry(table_bus).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Day = new SelectList(db.Table_day, "Day", "Day", table_bus.Day);
            ViewBag.R_id = new SelectList(db.Table_route, "R_id", "R_id", table_bus.R_id);
            return View(table_bus);
        }

        // GET: /Default1/Delete/5
         [AuthLog(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Table_bus table_bus = db.Table_bus.Find(id);
            if (table_bus == null)
            {
                return HttpNotFound();
            }
            return View(table_bus);
        }

        // POST: /Default1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Table_bus table_bus = db.Table_bus.Find(id);
            db.Table_bus.Remove(table_bus);
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
