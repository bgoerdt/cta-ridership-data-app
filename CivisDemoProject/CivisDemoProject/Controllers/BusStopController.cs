using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CivisDemoProject.Models;

namespace CivisDemoProject.Controllers
{
    public class BusStopController : Controller
    {
        private RidershipDbContext db = new RidershipDbContext();

        //
        // GET: /BusStop/

        public ActionResult Index()
        {
			//db.loadBusStopData();
            return View(db.BusStops.ToList());
        }
    }
}