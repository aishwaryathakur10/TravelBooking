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
    public class BookedController : Controller
    {
        private TravelBookingEntities db = new TravelBookingEntities();

        // GET: /Booked/
        public ActionResult Index()
        {
            return View(db.Table_booked.ToList());
        }



        public ActionResult SeatInfo()
        {
            return View();
        }






        // GET: /Booked/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Table_booked table_booked = db.Table_booked.Find(id);
            if (table_booked == null)
            {
                return HttpNotFound();
            }
            return View(table_booked);
        }

        // GET: /Booked/Create
        public ActionResult Create()
        {
            var userid = from a in db.AspNetUsers.Where(a => a.UserName == User.Identity.Name) select a.Id;
            ViewBag.id = userid.FirstOrDefault();


            //bool seatExists = from a in db.Table_booked.Any(a =>a.Seat_No);

            //if (seatExists)  
            //{
            //    ViewBag.seat = true;
            //}

            return View();
        }

        // POST: /Booked/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Booked_id,Seat_No,Status,Id")] Table_booked table_booked)
        {
            
            if (ModelState.IsValid)
            {
                db.Table_booked.Add(table_booked);
                db.SaveChanges();
                return RedirectToAction("Confirmed", "Detail");
            }

            return View(table_booked);
        }

        // GET: /Booked/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Table_booked table_booked = db.Table_booked.Find(id);
            if (table_booked == null)
            {
                return HttpNotFound();
            }
            return View(table_booked);
        }

        // POST: /Booked/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Booked_id,Seat_No,Status,Id")] Table_booked table_booked)
        {
            if (ModelState.IsValid)
            {
                db.Entry(table_booked).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(table_booked);
        }

        // GET: /Booked/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Table_booked table_booked = db.Table_booked.Find(id);
            if (table_booked == null)
            {
                return HttpNotFound();
            }
            return View(table_booked);
        }

        // POST: /Booked/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Table_booked table_booked = db.Table_booked.Find(id);
            db.Table_booked.Remove(table_booked);
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
