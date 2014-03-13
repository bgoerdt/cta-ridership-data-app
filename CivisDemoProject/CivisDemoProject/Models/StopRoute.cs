using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;

namespace CivisDemoProject.Models
{
	public class StopRoute
	{
		public StopRoute(){}
		public StopRoute(int id, string rt)
		{
			stop_id = id;
			route = rt;
		}

		[Key]
		public int ID { get; set; }
		public int stop_id { get; set; }
		public string route { get; set; }
	}
}