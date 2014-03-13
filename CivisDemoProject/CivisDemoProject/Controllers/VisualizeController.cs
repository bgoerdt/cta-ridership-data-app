using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CivisDemoProject.Models;

namespace CivisDemoProject.Controllers
{
    public class VisualizeController : Controller
    {
		Visualize viz = new Visualize();

        //
        // GET: /Visualize/

        public ActionResult Index()
        {
            return View();
        }

		public JsonResult AllStopsQuery()
		{
			var results = viz.getAllBusStops();
			return Json(results, JsonRequestBehavior.AllowGet);
		}

		public JsonResult MostCommonStopsQuery()
		{
			var results = viz.getMostCommonStops();
			return Json(results, JsonRequestBehavior.AllowGet);
		}

		public JsonResult MostBoardedStopsQuery()
		{
			var results = viz.getMostBoardedStops();
			return Json(results, JsonRequestBehavior.AllowGet);
		}

		public JsonResult MostAlightedStopsQuery()
		{
			var results = viz.getMostAlightedStops();
			return Json(results, JsonRequestBehavior.AllowGet);
		}

		public JsonResult NetBoardingsQuery()
		{
			var results = viz.getNetBoardings();
			return Json(results, JsonRequestBehavior.AllowGet);
		}
    }
}
