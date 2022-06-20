using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

using Org.Ktu.Isk.P175B602.Autonuoma.Models;


namespace Org.Ktu.Isk.P175B602.Autonuoma.Repositories
{
	/// <summary>
	/// Database operations for 'Dietos' entity.
	/// </summary>
	public class DietaRepo
	{
		public static List<Dieta> List()
		{
			List<Dieta> dietos = new List<Dieta>();

			string sqlquery = @"SELECT * FROM dietos a";
			var dt = Sql.Query(sqlquery);

			foreach (DataRow item in dt)
			{
				dietos.Add(new Dieta
				{
					Id = Convert.ToInt32(item["id"]),
					Name = Convert.ToString(item["name"])
				});
			}

			return dietos;
		}

		public static Dieta Find(int id)
		{
			var dieta = new Dieta();

			var query = $@"SELECT * FROM `dietos` WHERE id=?id";

			var dt =
				Sql.Query(query, args => {
					args.Add("?id", MySqlDbType.Int32).Value = id;
				});

			foreach (DataRow item in dt)
			{
				dieta.Id = Convert.ToInt32(item["id"]);
				dieta.Name = Convert.ToString(item["name"]);
			}

			return dieta;
		}

		public static void Update(Dieta dieta)
		{
			var query =
				$@"UPDATE `dietos`
				SET 
					name=?name
				WHERE 
					id=?id";

			Sql.Update(query, args => {
				args.Add("?id", MySqlDbType.Int32).Value = dieta.Id;
				args.Add("?name", MySqlDbType.VarChar).Value = dieta.Name;
			});
		}

		public static void Insert(Dieta dieta)
		{
			var query =
				$@"INSERT INTO `dietos`
				(
					id,
					name
				)
				VALUES(
					?id,
					?name
				)";

			Sql.Insert(query, args => {
				args.Add("?id", MySqlDbType.Int32).Value = dieta.Id;
				args.Add("?name", MySqlDbType.VarChar).Value = dieta.Name;
			});
		}

		public static void Delete(int id)
		{
			var query = $@"DELETE FROM `dietos` WHERE id=?id";
			Sql.Delete(query, args => {
				args.Add("?id", MySqlDbType.Int32).Value = id;
			});
		}
	}
}