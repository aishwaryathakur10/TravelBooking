using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Travel.Models;

namespace Travel.Controllers
{
    public class HomeController : Controller
    {
        private TravelBookingEntities db = new TravelBookingEntities();

       
        SearchBusModel model = new SearchBusModel();

        public ActionResult Index()
        {
            model.routemodel = new RouteViewModel();
            model.routemodel.R_id = -1;
            model.routemodel.routelist = db.Table_route.ToList();

      
            return View(model);         
        }


        [HttpPost]
        public ActionResult Index(SearchBusModel model, Table_bus bus)
        {
            
            model.routemodel.routelist = db.Table_route.ToList();
            List<Table_bus> busl = new List<Table_bus>();

            model.buslist = db.Table_bus.Where(c => c.R_id == model.routemodel.R_id).ToList();

            return View(model);

        }



        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }



        public ActionResult SeatInfo()
        {

            return View();
        }


    }
}