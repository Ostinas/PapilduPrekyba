using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

using Org.Ktu.Isk.P175B602.Autonuoma.Models;
using Org.Ktu.Isk.P175B602.Autonuoma.ViewModels;

namespace Org.Ktu.Isk.P175B602.Autonuoma.Repositories
{
	/// <summary>
	/// Database operations for 'Kategorijos' entity.
	/// </summary>
	public class KategorijaRepo
	{
		public static List<Kategorija> List()
		{
			var kategorijos = new List<Kategorija>();

			string sqlquery = @"SELECT * FROM kategorijos ORDER BY id ASC";
			var dt = Sql.Query(sqlquery);

			foreach (DataRow item in dt)
			{
				kategorijos.Add(new Kategorija
				{
					Id = Convert.ToInt32(item["id"]),
					Pavadinimas = Convert.ToString(item["pavadinimas"])
				});
			}

			return kategorijos;
		}

		public static Kategorija Find(int id)
		{
			var kategorija = new Kategorija();

			var query = $@"SELECT * FROM `kategorijos` WHERE id=?id";

			var dt =
				Sql.Query(query, args => {
					args.Add("?id", MySqlDbType.Int32).Value = id;
				});

			foreach (DataRow item in dt)
			{
				kategorija.Id = Convert.ToInt32(item["id"]);
				kategorija.Pavadinimas = Convert.ToString(item["pavadinimas"]);
			}

			return kategorija;
		}

		public static void Update(Kategorija kat)
		{
			var query =
				$@"UPDATE `kategorijos`
				SET 
					pavadinimas=?pavadinimas
				WHERE 
					id=?id";

			Sql.Update(query, args => {
				args.Add("?id", MySqlDbType.Int32).Value = kat.Id;
				args.Add("?pavadinimas", MySqlDbType.VarChar).Value = kat.Pavadinimas;
			});
		}

		public static void Insert(Kategorija kat)
		{
			var query =
				$@"INSERT INTO `kategorijos`
				(
					id,
					pavadinimas
				)
				VALUES(
					?id,
					?pavadinimas
				)";

			Sql.Insert(query, args => {
				args.Add("?id", MySqlDbType.Int32).Value = kat.Id;
				args.Add("?pavadinimas", MySqlDbType.VarChar).Value = kat.Pavadinimas;
			});
		}

		public static void Delete(int id)
		{
			var query = $@"DELETE FROM `kategorijos` WHERE id=?id";
			Sql.Delete(query, args => {
				args.Add("?id", MySqlDbType.VarChar).Value = id;
			});
		}
	}
}