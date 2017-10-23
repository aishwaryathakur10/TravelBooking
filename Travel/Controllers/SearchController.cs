using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Travel.Models;

namespace Travel.Controllers
{
    public class SearchController : Controller
    {
        private TravelBookingEntities db = new TravelBookingEntities();

        // GET: /Search/
        public ActionResult Index()
        {
            var table_bus = db.Table_bus.Include(t => t.Table_day).Include(t => t.Table_route);
            return View(table_bus.ToList());
        }



        [AllowAnonymous]
        public ActionResult Search(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }



        //[HttpPost]
        //[AllowAnonymous]
        //public ActionResult Search(Table_city user)
        //{
        //     using (TravelBookingEntities User = new TravelBookingEntities())
        //{
        //    var UserInput= User.Table_city.Where(b => b.Source == user.City && b.Destination == user.City).FirstOrDefault();
        //    if (UserInput!=null)
        //    {
        //        //Session["Id"] = UserInput.id.ToString();
        //        //Session["UserName"] = UserInput.UserName.ToString();
        //        //return Redirect("#");
        //    }
        //    else
        //    {
        //        ModelState.AddModelError("","City Doesn't Exist");
        //    }

        //    // If we got this far, something failed, redisplay form
        //    return View();
        //}



        // GET: /Search/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Table_bus table_bus = db.Table_bus.Find(id);
        //    if (table_bus == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(table_bus);
        //}

        //// GET: /Search/Create
        //public ActionResult Create()
        //{
        //    ViewBag.Day = new SelectList(db.Table_day, "Day", "Day");
        //    ViewBag.R_id = new SelectList(db.Table_route, "R_id", "R_id");
        //    return View();
        //}

        //// POST: /Search/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include="B_id,B_name,Time,Available_Seats,R_id,Day")] Table_bus table_bus)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Table_bus.Add(table_bus);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.Day = new SelectList(db.Table_day, "Day", "Day", table_bus.Day);
        //    ViewBag.R_id = new SelectList(db.Table_route, "R_id", "R_id", table_bus.R_id);
        //    return View(table_bus);
        //}

        //// GET: /Search/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Table_bus table_bus = db.Table_bus.Find(id);
        //    if (table_bus == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.Day = new SelectList(db.Table_day, "Day", "Day", table_bus.Day);
        //    ViewBag.R_id = new SelectList(db.Table_route, "R_id", "R_id", table_bus.R_id);
        //    return View(table_bus);
        //}

        //// POST: /Search/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include="B_id,B_name,Time,Available_Seats,R_id,Day")] Table_bus table_bus)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(table_bus).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.Day = new SelectList(db.Table_day, "Day", "Day", table_bus.Day);
        //    ViewBag.R_id = new SelectList(db.Table_route, "R_id", "R_id", table_bus.R_id);
        //    return View(table_bus);
        //}

        //// GET: /Search/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Table_bus table_bus = db.Table_bus.Find(id);
        //    if (table_bus == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(table_bus);
        //}

        //// POST: /Search/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Table_bus table_bus = db.Table_bus.Find(id);
        //    db.Table_bus.Remove(table_bus);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
