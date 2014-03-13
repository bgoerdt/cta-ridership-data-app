using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Data.SqlClient;
using System.Drawing;

namespace CivisDemoProject.Models
{
	public class Visualize
	{
		public List<List<object>> getAllBusStops()
		{
			List<List<object>> results = new List<List<object>>();

			SqlConnection localConn = new SqlConnection("Data Source=(LocalDB)\\v11.0;AttachDbFilename=|DataDirectory|\\BusStops.mdf;AttachDbFilename=|DataDirectory|\\StopRoutes.mdf;Integrated Security=True");
			string query = "SELECT stop_id, lat, lng, on_street, cross_street, boardings, alightings FROM dbo.BusStops";
			localConn.Close();
			localConn.Open();
			SqlCommand cmd = new SqlCommand(query, localConn);
			SqlDataReader sqlReader = cmd.ExecuteReader();
			while (sqlReader.Read())
			{
				List<object> values = new List<object>();
				values.Add(sqlReader["stop_id"]);
				values.Add(sqlReader["lat"]);
				values.Add(sqlReader["lng"]);
				values.Add(sqlReader["on_street"]);
				values.Add(sqlReader["cross_street"]);
				values.Add(sqlReader["boardings"]);
				values.Add(sqlReader["alightings"]);
				results.Add(values);
			}
			sqlReader.Close();
			localConn.Close();

			return results;
		}

		public List<List<object>> getMostCommonStops()
		{
			List<List<object>> results = new List<List<object>>();

			SqlConnection localConn = new SqlConnection("Data Source=(LocalDB)\\v11.0;AttachDbFilename=|DataDirectory|\\BusStops.mdf;AttachDbFilename=|DataDirectory|\\StopRoutes.mdf;Integrated Security=True");
			string query = "SELECT StopRoutes.stop_id, lat, lng, on_street, cross_street, boardings, alightings, COUNT(StopRoutes.stop_id) AS number_of_routes FROM StopRoutes, BusStops WHERE StopRoutes.stop_id = BusStops.stop_id GROUP BY StopRoutes.stop_id, lat, lng, on_street, cross_street, boardings, alightings ORDER BY number_of_routes DESC";
			localConn.Close();
			localConn.Open();
			SqlCommand cmd = new SqlCommand(query, localConn);
			SqlDataReader sqlReader = cmd.ExecuteReader();

			int max = -1, min = 1000000;
			while (sqlReader.Read())
			{
				int num = Convert.ToInt32(sqlReader["number_of_routes"]);

				if (num < min)
					min = num;
				if (num > max)
					max = num;
			}
			sqlReader.Close();
			sqlReader = cmd.ExecuteReader();
;
			while (sqlReader.Read())
			{
				int routes = Convert.ToInt32(sqlReader["number_of_routes"]);

				List<object> values = new List<object>();
				values.Add(sqlReader["stop_id"]);
				values.Add(sqlReader["lat"]);
				values.Add(sqlReader["lng"]);
				values.Add(sqlReader["on_street"]);
				values.Add(sqlReader["cross_street"]);
				values.Add(sqlReader["boardings"]);
				values.Add(sqlReader["alightings"]);
				values.Add(routes);
				var color = convertValtoColor(min, max, routes);
				values.Add(color);

				results.Add(values);
			}
			sqlReader.Close();
			localConn.Close();

			return results;
		}

		public List<List<object>> getMostBoardedStops()
		{
			List<List<object>> results = new List<List<object>>();

			SqlConnection localConn = new SqlConnection("Data Source=(LocalDB)\\v11.0;AttachDbFilename=|DataDirectory|\\BusStops.mdf;AttachDbFilename=|DataDirectory|\\StopRoutes.mdf;Integrated Security=True");
			string query = "SELECT stop_id, lat, lng, on_street, cross_street, boardings, alightings FROM BusStops ORDER BY boardings DESC";
			localConn.Close();
			localConn.Open();
			SqlCommand cmd = new SqlCommand(query, localConn);
			SqlDataReader sqlReader = cmd.ExecuteReader();

			double max = -1, min = 1000000;
			while (sqlReader.Read())
			{
				double num = Convert.ToDouble(sqlReader["boardings"]);

				if (num < min)
					min = num;
				if (num > max)
					max = num;
			}
			sqlReader.Close();
			sqlReader = cmd.ExecuteReader();

			while (sqlReader.Read())
			{
				double boardings = Convert.ToInt32(sqlReader["boardings"]);

				List<object> values = new List<object>();
				values.Add(sqlReader["stop_id"]);
				values.Add(sqlReader["lat"]);
				values.Add(sqlReader["lng"]);
				values.Add(sqlReader["on_street"]);
				values.Add(sqlReader["cross_street"]);
				values.Add(sqlReader["boardings"]);
				values.Add(sqlReader["alightings"]);
				var color = convertValtoColor(min, max, boardings);
				values.Add(color);

				results.Add(values);
			}
			sqlReader.Close();
			localConn.Close();

			return results;
		}

		public List<List<object>> getMostAlightedStops()
		{
			List<List<object>> results = new List<List<object>>();

			SqlConnection localConn = new SqlConnection("Data Source=(LocalDB)\\v11.0;AttachDbFilename=|DataDirectory|\\BusStops.mdf;AttachDbFilename=|DataDirectory|\\StopRoutes.mdf;Integrated Security=True");
			string query = "SELECT stop_id, lat, lng, on_street, cross_street, boardings, alightings FROM BusStops ORDER BY alightings DESC";
			localConn.Close();
			localConn.Open();
			SqlCommand cmd = new SqlCommand(query, localConn);
			SqlDataReader sqlReader = cmd.ExecuteReader();

			double max = -1, min = 1000000;
			while (sqlReader.Read())
			{
				double num = Convert.ToDouble(sqlReader["alightings"]);

				if (num < min)
					min = num;
				if (num > max)
					max = num;
			}
			sqlReader.Close();
			sqlReader = cmd.ExecuteReader();

			while (sqlReader.Read())
			{
				double alightings = Convert.ToInt32(sqlReader["alightings"]);

				List<object> values = new List<object>();
				values.Add(sqlReader["stop_id"]);
				values.Add(sqlReader["lat"]);
				values.Add(sqlReader["lng"]);
				values.Add(sqlReader["on_street"]);
				values.Add(sqlReader["cross_street"]);
				values.Add(sqlReader["boardings"]);
				values.Add(sqlReader["alightings"]);
				var color = convertValtoColor(min, max, alightings);
				values.Add(color);

				results.Add(values);
			}
			sqlReader.Close();
			localConn.Close();

			return results;
		}

		public List<List<object>> getNetBoardings()
		{
			List<List<object>> results = new List<List<object>>();

			SqlConnection localConn = new SqlConnection("Data Source=(LocalDB)\\v11.0;AttachDbFilename=|DataDirectory|\\BusStops.mdf;AttachDbFilename=|DataDirectory|\\StopRoutes.mdf;Integrated Security=True");
			string query = "SELECT stop_id, lat, lng, on_street, cross_street, boardings, alightings, (boardings-alightings) as net_boardings FROM BusStops ORDER BY ABS(boardings-alightings) DESC";
			localConn.Close();
			localConn.Open();
			SqlCommand cmd = new SqlCommand(query, localConn);
			SqlDataReader sqlReader = cmd.ExecuteReader();

			double max = -1, min = 1000000;
			while (sqlReader.Read())
			{
				double boardings = Convert.ToDouble(sqlReader["boardings"]);
				double alightings = Convert.ToDouble(sqlReader["alightings"]);

				double net = boardings - alightings;

				if (net < min)
					min = net;
				if (net > max)
					max = net;
			}
			sqlReader.Close();
			sqlReader = cmd.ExecuteReader();

			while (sqlReader.Read())
			{
				double boardings = Convert.ToDouble(sqlReader["boardings"]);
				double alightings = Convert.ToInt32(sqlReader["alightings"]);
				double net = boardings - alightings;

				List<object> values = new List<object>();
				values.Add(sqlReader["stop_id"]);
				values.Add(sqlReader["lat"]);
				values.Add(sqlReader["lng"]);
				values.Add(sqlReader["on_street"]);
				values.Add(sqlReader["cross_street"]);
				values.Add(sqlReader["boardings"]);
				values.Add(sqlReader["alightings"]);
				values.Add(sqlReader["net_boardings"].ToString());
				var color = convertValtoColor(min, max, net);
				values.Add(color);

				results.Add(values);
			}
			sqlReader.Close();
			localConn.Close();

			return results;
		}

		// method written based on http://www.efg2.com/Lab/ScienceAndEngineering/Spectra.htm
		public string convertValtoColor(double min, double max, double val)
		{
			double gamma = 0.8;

			// determine the wavelength
			double minWave = 400;
			double maxWave = 780;
			double wavelength = (val - min) / (max - min) * ( maxWave - minWave ) + minWave;
			double r=0, g=0, b=0;
			double factor;

			// determine the RGB values from the wavelength
			if (wavelength >= 380.0 && wavelength < 440.0)
			{
				r = -(wavelength - 440.0) / (440.0 - 380.0);
				g = 0;
				b = 1;
			}
			else if (wavelength < 490.0)
			{
				r = 0;
				g = (wavelength - 440.0) / (490.0 - 440.0);
				b = 1;
			}
			else if (wavelength < 510.0)
			{
				r = 0;
				g = 1;
				b = -(wavelength - 510.0) / (510.0 - 490.0);
			}
			else if (wavelength < 580.0)
			{
				r = (wavelength - 510.0) / (580.0 - 510.0);
				g = 1;
				b = 0;
			}
			else if (wavelength < 645.0)
			{
				r = 1;
				g = -(wavelength - 645.0) / (645.0 - 580.0);
				b = 0;
			}
			else if (wavelength <= 780.0)
			{
				r = 1;
				g = 0;
				b = 0;
			}
			
			// determine the factor
			if (wavelength > 380.0 && wavelength <= 419.0)
				factor = 0.3 + 0.7 * (wavelength - 380.0) / (420.0 - 380.0);
			else if (wavelength <= 700.0)
				factor = 1.0;
			else if (wavelength <= 780.0)
				factor = 0.3 + 0.7 * (780.0 - wavelength) / (780.0 - 700.0);
			else
				factor = 0.0;

			int red = (int)(255 * Math.Pow((r * factor), gamma));
			int green = (int)(255 * Math.Pow((g * factor), gamma));
			int blue = (int)(255 * Math.Pow((b * factor), gamma));

			if (red < 0)
				red = 0;
			if (green < 0)
				green = 0;
			if (blue < 0)
				blue = 0;

			Color color = Color.FromArgb(red, green, blue);

			return "#" + color.R.ToString("X2") + color.G.ToString("X2") + color.B.ToString("X2");
		}
	}
}