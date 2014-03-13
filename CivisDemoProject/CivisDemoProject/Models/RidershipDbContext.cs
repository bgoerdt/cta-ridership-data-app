using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.IO;

namespace CivisDemoProject.Models
{
	public class RidershipDbContext : DbContext
	{
		public DbSet<BusStop> BusStops { get; set; }
		public DbSet<StopRoute> StopRoutes { get; set; }

		public void loadStopRouteData()
		{
			StreamReader reader = new StreamReader("C:\\Users\\bgoerdt\\Documents\\Visual Studio 2012\\Projects\\CivisDemoProject\\lat-lng_CTA_Ridership_Avg_Weekday_Bus_Stop_Boardings_in_October_2012.csv");
			string line = "";

			// skip header
			reader.ReadLine();

			while ((line = reader.ReadLine()) != null)
			{
				// work around list of routes is there is more than one route
				string[] split = line.Split('"');
				if (split.Length != 1)
				{
					string[] streetSplit = split[0].Split(',');
					string[] routeSplit = split[1].Split(',');
					foreach (string route in routeSplit)
					{
						StopRoutes.Add(new StopRoute(Convert.ToInt32(streetSplit[0]), route));
						this.SaveChanges();
					}
				}
				else
				{
					split = line.Split(',');
					StopRoutes.Add(new StopRoute(Convert.ToInt32(split[0]), split[3]));
					this.SaveChanges();
				}
			}

			reader.Close();
		}

		public void loadBusStopData()
		{
			StreamReader reader = new StreamReader("C:\\Users\\bgoerdt\\Documents\\Visual Studio 2012\\Projects\\CivisDemoProject\\lat-lng_CTA_Ridership_Avg_Weekday_Bus_Stop_Boardings_in_October_2012.csv");
			string line = "";

			// skip header
			reader.ReadLine();

			while ((line = reader.ReadLine()) != null)
			{
				// work around list of routes is there is more than one route
				string[] split = line.Split('"');
				if (split.Length != 1)
				{
					string[] split1 = split[0].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
					string[] split2 = split[2].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
					BusStops.Add(new BusStop(Convert.ToInt32(split1[0]), split1[1], split1[2], Convert.ToDouble(split2[0]), Convert.ToDouble(split2[1]), Convert.ToDouble(split2[4]), Convert.ToDouble(split2[5])));
					this.SaveChanges();
				}
				else
				{
					split = line.Split(',');
					BusStop stop = new BusStop(Convert.ToInt32(split[0]), split[1], split[2], Convert.ToDouble(split[4]), Convert.ToDouble(split[5]), Convert.ToDouble(split[8]), Convert.ToDouble(split[9]));
					BusStops.Add(stop);
					this.SaveChanges();
				}
			}

			reader.Close();
		}
	}
}