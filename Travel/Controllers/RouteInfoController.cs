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
    public class RouteInfoController : Controller
    {
        private TravelBookingEntities db = new TravelBookingEntities();

        // GET: /RouteInfo/
        public ActionResult Index()
        {
            return View(db.Table_route.ToList());
            //return RedirectToAction("Info", "RouteInfo");
        }



        public ActionResult Info()
        {
            return View();
        }
     


        // GET: /RouteInfo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Table_route table_route = db.Table_route.Find(id);
            if (table_route == null)
            {
                return HttpNotFound();
            }
            return View(table_route);
        }

        // GET: /RouteInfo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /RouteInfo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="R_id,S_id,D_id")] Table_route table_route)
        {
            if (ModelState.IsValid)
            {
                db.Table_route.Add(table_route);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(table_route);
        }

        // GET: /RouteInfo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Table_route table_route = db.Table_route.Find(id);
            if (table_route == null)
            {
                return HttpNotFound();
            }
            return View(table_route);
        }

        // POST: /RouteInfo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="R_id,S_id,D_id")] Table_route table_route)
        {
            if (ModelState.IsValid)
            {
                db.Entry(table_route).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(table_route);
        }

        // GET: /RouteInfo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Table_route table_route = db.Table_route.Find(id);
            if (table_route == null)
            {
                return HttpNotFound();
            }
            return View(table_route);
        }

        // POST: /RouteInfo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Table_route table_route = db.Table_route.Find(id);
            db.Table_route.Remove(table_route);
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
