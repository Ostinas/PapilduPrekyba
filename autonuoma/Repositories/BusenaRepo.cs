using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using MySql.Data.MySqlClient;

using Org.Ktu.Isk.P175B602.Autonuoma.Models;


namespace Org.Ktu.Isk.P175B602.Autonuoma.Repositories
{
	/// <summary>
	/// Database operations for 'AutoBusena' entity.
	/// </summary>
	public class BusenaRepo
	{
		public static List<Busena> List()
		{
			List<Busena> busenos = new List<Busena>();

			string sqlquery = @"SELECT a.id, a.name FROM busenos a";
			var dt = Sql.Query(sqlquery);

			foreach (DataRow item in dt)
			{
				busenos.Add(new Busena
				{
					Id = Convert.ToInt32(item["id"]),
					Pavadinimas = Convert.ToString(item["name"])
				});
			}

			return busenos;
		}
	}
}