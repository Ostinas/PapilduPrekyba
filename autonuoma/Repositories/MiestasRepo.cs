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
	/// Database operations for 'Miestas' entity.
	/// </summary>
	public class MiestasRepo
	{
		public static List<Miestas> List()
		{
			List<Miestas> miestai = new List<Miestas>();

			string sqlquery = @"SELECT id, pavadinimas FROM miestai";
			var dt = Sql.Query(sqlquery);

			foreach (DataRow item in dt)
			{
				miestai.Add(new Miestas
				{
					Id = Convert.ToInt32(item["id"]),
					Pavadinimas = Convert.ToString(item["pavadinimas"])
				});
			}

			return miestai;
		}
	}
}