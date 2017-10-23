using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Travel.Models;

namespace Travel.Controllers
{
    public class AdminController : Controller
    {

        private TravelBookingEntities db = new TravelBookingEntities();

        BusViewModel model = new BusViewModel();
        public ActionResult Index()
        {


            model.C_id = -1;
            model.citylist = db.Table_city.ToList();


            return View(model);
        }
	}
}