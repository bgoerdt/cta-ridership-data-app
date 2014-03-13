using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CivisDemoProject.Models;

namespace CivisDemoProject.Controllers
{
    public class QueryController : Controller
    {
		CTAQuery query = new CTAQuery();
        //
        // GET: /Query/

        public ActionResult Index()
        {
            return View();
        }

		public JsonResult LongestRouteQuery()
		{
			var result = query.getLongestRoute();
			return Json(result, JsonRequestBehavior.AllowGet);
		}

		public JsonResult MostCommonStopsQuery()
		{
			var results = query.getMostCommonStops();
			return Json(results, JsonRequestBehavior.AllowGet);
		}

		public JsonResult MostBoardedStopsQuery()
		{
			var results = query.getMostBoardedStops();
			return Json(results, JsonRequestBehavior.AllowGet);
		}

		public JsonResult MostAlightedStopsQuery()
		{
			var results = query.getMostAlightedStops();
			return Json(results, JsonRequestBehavior.AllowGet);
		}

		public JsonResult NetBoardingsQuery()
		{
			var results = query.getNetBoardings();
			return Json(results, JsonRequestBehavior.AllowGet);
		}
    }
}
