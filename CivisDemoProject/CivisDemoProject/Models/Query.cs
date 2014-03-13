using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Data.SqlClient;

namespace CivisDemoProject.Models
{
	public class CTAQuery
	{
		public List<List<object>> getLongestRoute()
		{
			List<List<object>> results = new List<List<object>>();

			SqlConnection localConn = new SqlConnection("Data Source=(LocalDB)\\v11.0;AttachDbFilename=|DataDirectory|\\BusStops.mdf;AttachDbFilename=|DataDirectory|\\StopRoutes.mdf;Integrated Security=True");
			string query = "SELECT StopRoutes.route, COUNT(StopRoutes.route) AS number_of_stops FROM StopRoutes GROUP BY StopRoutes.route ORDER BY number_of_stops DESC";
			localConn.Close();
			localConn.Open();
			SqlCommand cmd = new SqlCommand(query, localConn);
			SqlDataReader sqlReader = cmd.ExecuteReader();
			results.Add(new List<object>() { "Route", "Number of Stops" });
			while (sqlReader.Read())
			{
				List<object> values = new List<object>();
				values.Add(sqlReader["route"]);
				values.Add(sqlReader["number_of_stops"]);
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
			string query = "SELECT StopRoutes.stop_id, on_street, cross_street, COUNT(StopRoutes.stop_id) AS number_of_routes FROM StopRoutes, BusStops WHERE StopRoutes.stop_id = BusStops.stop_id GROUP BY StopRoutes.stop_id, on_street, cross_street ORDER BY number_of_routes DESC";
			localConn.Close();
			localConn.Open();
			SqlCommand cmd = new SqlCommand(query, localConn);
			SqlDataReader sqlReader = cmd.ExecuteReader();
			results.Add(new List<object>() { "Stop ID", "Street", "Cross Street", "Number of Routes" });
			while (sqlReader.Read())
			{
				List<object> values = new List<object>();
				values.Add(sqlReader["stop_id"]);
				values.Add(sqlReader["on_street"]);
				values.Add(sqlReader["cross_street"]);
				values.Add(sqlReader["number_of_routes"]);

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
			string query = "SELECT stop_id, on_street, cross_street, boardings FROM BusStops ORDER BY boardings DESC";
			localConn.Close();
			localConn.Open();
			SqlCommand cmd = new SqlCommand(query, localConn);
			SqlDataReader sqlReader = cmd.ExecuteReader();
			results.Add(new List<object>() { "Stop ID", "Street", "Cross Street", "Boardings" });
			while (sqlReader.Read())
			{
				List<object> values = new List<object>();
				values.Add(sqlReader["stop_id"]);
				values.Add(sqlReader["on_street"]);
				values.Add(sqlReader["cross_street"]);
				values.Add(sqlReader["boardings"]);

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
			string query = "SELECT stop_id, on_street, cross_street, alightings FROM BusStops ORDER BY alightings DESC";
			localConn.Close();
			localConn.Open();
			SqlCommand cmd = new SqlCommand(query, localConn);
			SqlDataReader sqlReader = cmd.ExecuteReader();
			results.Add(new List<object>() { "Stop ID", "Street", "Cross Street", "Alightings" });
			while (sqlReader.Read())
			{
				List<object> values = new List<object>();
				values.Add(sqlReader["stop_id"]);
				values.Add(sqlReader["on_street"]);
				values.Add(sqlReader["cross_street"]);
				values.Add(sqlReader["alightings"]);

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
			string query = "SELECT stop_id, on_street, cross_street, boardings, alightings, (boardings-alightings) as net_boardings FROM BusStops ORDER BY ABS(boardings-alightings) DESC";
			localConn.Close();
			localConn.Open();
			SqlCommand cmd = new SqlCommand(query, localConn);
			SqlDataReader sqlReader = cmd.ExecuteReader();
			results.Add(new List<object>() { "Stop ID", "Street", "Cross Street", "Boardings", "Alightings", "NET" });
			while (sqlReader.Read())
			{
				List<object> values = new List<object>();
				values.Add(sqlReader["stop_id"]);
				values.Add(sqlReader["on_street"]);
				values.Add(sqlReader["cross_street"]);
				values.Add(sqlReader["boardings"]);
				values.Add(sqlReader["alightings"]);
				values.Add(sqlReader["net_boardings"].ToString());

				results.Add(values);
			}
			sqlReader.Close();
			localConn.Close();

			return results;
		}


	}
}