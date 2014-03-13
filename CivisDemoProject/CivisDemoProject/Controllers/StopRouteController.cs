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
    public class StopRouteController : Controller
    {
        private RidershipDbContext db = new RidershipDbContext();

        //
        // GET: /StopRoute/

        public ActionResult Index()
        {
			//db.loadStopRouteData();
            return View(db.StopRoutes.ToList());
        }
    }
}