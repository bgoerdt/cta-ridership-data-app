using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.IO;

namespace CivisDemoProject.Models
{
	public class BusStop
	{
		public BusStop(){}
		public BusStop(int id, string street, string cross, double boards, double alights, double lat, double lng)
		{
			stop_id = id;
			on_street = street;
			cross_street = cross;
			boardings = boards;
			alightings = alights;
			this.lat = lat;
			this.lng = lng;
		}

		[Key]
		public int ID { get; set; }
		public int stop_id { get; set; }
		public string on_street { get; set; }
		public string cross_street { get; set; }
		public double boardings { get; set; }
		public double alightings { get; set; }
		public double lat { get; set; }
		public double lng { get; set; }
	}
}