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
	public class PrekeRepo
	{
		public static List<PrekeListVM> List()
		{
			var result = new List<PrekeListVM>();

			var query =
				$@"SELECT
					md.kodas,
					md.pavadinimas,
					md.kaina,
					md.aprasymas,
					md.maistine_informacija,
					md.galiojimo_laikas,
					diet.name AS dieta,
					kat.pavadinimas AS kategorija
				FROM
					`prekes` md
					LEFT JOIN `kategorijos` kat ON kat.id=md.fk_kategorija
					LEFT JOIN `dietos` diet ON diet.id=md.dieta
				ORDER BY md.kodas ASC";

			var dt = Sql.Query(query);

			foreach (DataRow item in dt)
			{
				result.Add(new PrekeListVM
				{
					Id = Convert.ToInt32(item["kodas"]),
					Pavadinimas = Convert.ToString(item["pavadinimas"]),
					Kaina = Convert.ToDecimal(item["kaina"]),
					Aprasymas = Convert.ToString(item["aprasymas"]),
					Maistine_informacija = Convert.ToString(item["maistine_informacija"]),
					Galiojimo_laikas = Convert.ToDateTime(item["galiojimo_laikas"]),
					Dieta = Convert.ToString(item["dieta"]),
					Kategorija = Convert.ToString(item["kategorija"])
				});
			}

			return result;
		}

		public static List<Preke> ListForKategorija(int prekeId)
		{
			var result = new List<Preke>();

			var query = $@"SELECT * FROM `prekes` WHERE fk_kategorija=?kategorijaId ORDER BY id ASC";

			var dt =
				Sql.Query(query, args => {
					args.Add("?kategorijaId", MySqlDbType.Int32).Value = prekeId;
				});

			foreach (DataRow item in dt)
			{
				result.Add(new Preke
				{
					Id = Convert.ToInt32(item["kodas"]),
					Pavadinimas = Convert.ToString(item["pavadinimas"]),
					Kaina = Convert.ToDecimal(item["kaina"]),
					Aprasymas = Convert.ToString(item["aprasymas"]),
					Maistine_informacija = Convert.ToString(item["maistine_informacija"]),
					Galiojimo_laikas = Convert.ToDateTime(item["galiojimo_laikas"]),
					Dieta = Convert.ToInt32(item["dieta"]),
					FkKategorija = Convert.ToInt32(item["fk_kategorija"])
				});
			}

			return result;
		}

		public static PrekeEditVM Find(int id)
		{
			var pevm = new PrekeEditVM();

			var query = $@"SELECT * FROM `prekes` WHERE kodas=?id";

			var dt =
				Sql.Query(query, args => {
					args.Add("?id", MySqlDbType.Int32).Value = id;
				});

			foreach (DataRow item in dt)
			{
				pevm.Preke.Id = Convert.ToInt32(item["kodas"]);
				pevm.Preke.Pavadinimas = Convert.ToString(item["pavadinimas"]);
				pevm.Preke.Kaina = Convert.ToDecimal(item["kaina"]);
				pevm.Preke.Aprasymas = Convert.ToString(item["aprasymas"]);
				pevm.Preke.Maistine_informacija = Convert.ToString(item["maistine_informacija"]);
				pevm.Preke.Galiojimo_laikas = Convert.ToDateTime(item["galiojimo_laikas"]);
				pevm.Preke.Dieta = Convert.ToInt32(item["dieta"]);
				pevm.Preke.FkKategorija = Convert.ToInt32(item["fk_kategorija"]);
			}

			return pevm;
		}

		public static PrekeListVM FindForDeletion(int id)
		{
			var plvm = new PrekeListVM();

			var query = $@"SELECT * FROM `prekes` WHERE kodas=?id";

			var dt =
				Sql.Query(query, args => {
					args.Add("?id", MySqlDbType.Int32).Value = id;
				});

			foreach (DataRow item in dt)
			{
				plvm.Id = Convert.ToInt32(item["kodas"]);
				plvm.Pavadinimas = Convert.ToString(item["pavadinimas"]);
				plvm.Kaina = Convert.ToDecimal(item["kaina"]);
				plvm.Aprasymas = Convert.ToString(item["aprasymas"]);
				plvm.Maistine_informacija = Convert.ToString(item["maistine_informacija"]);
				plvm.Galiojimo_laikas = Convert.ToDateTime(item["galiojimo_laikas"]);
			}

			return plvm;
		}

		public static void Update(PrekeEditVM prekeEvm)
		{
			var query =
				$@"UPDATE `prekes`
				SET
					pavadinimas=?pavadinimas,
					kaina=?kaina,
					aprasymas=?aprasymas,
					maistine_informacija=?maistine_informacija,
					galiojimo_laikas=?galiojimo_laikas,
					dieta=?dieta,
					fk_kategorija=?kategorija
				WHERE
					kodas=?id";

			Sql.Update(query, args => {
				args.Add("?pavadinimas", MySqlDbType.VarChar).Value = prekeEvm.Preke.Pavadinimas;
				args.Add("?kaina", MySqlDbType.VarChar).Value = prekeEvm.Preke.Kaina;
				args.Add("?id", MySqlDbType.VarChar).Value = prekeEvm.Preke.Id;
				args.Add("?aprasymas", MySqlDbType.VarChar).Value = prekeEvm.Preke.Aprasymas;
				args.Add("?maistine_informacija", MySqlDbType.VarChar).Value = prekeEvm.Preke.Maistine_informacija;
				args.Add("?galiojimo_laikas", MySqlDbType.VarChar).Value = prekeEvm.Preke.Galiojimo_laikas;
				args.Add("?dieta", MySqlDbType.VarChar).Value = prekeEvm.Preke.Dieta;
				args.Add("?kategorija", MySqlDbType.VarChar).Value = prekeEvm.Preke.FkKategorija;
			});
		}

		public static void Insert(PrekeEditVM prekeEvm)
		{
			var query =
				$@"INSERT INTO `prekes`
				(
					pavadinimas,
					kaina,
					aprasymas,
					maistine_informacija,
					galiojimo_laikas,
					dieta,
					fk_kategorija
				)
				VALUES(
					?pavadinimas,
					?kaina,
					?aprasymas,
					?maistine_informacija,
					?galiojimo_laikas,
					?dieta,
					?kategorija
				)";

			Sql.Insert(query, args => {
				args.Add("?pavadinimas", MySqlDbType.VarChar).Value = prekeEvm.Preke.Pavadinimas;
				args.Add("?kaina", MySqlDbType.VarChar).Value = prekeEvm.Preke.Kaina;
				args.Add("?aprasymas", MySqlDbType.VarChar).Value = prekeEvm.Preke.Aprasymas;
				args.Add("?maistine_informacija", MySqlDbType.VarChar).Value = prekeEvm.Preke.Maistine_informacija;
				args.Add("?galiojimo_laikas", MySqlDbType.VarChar).Value = prekeEvm.Preke.Galiojimo_laikas;
				args.Add("?dieta", MySqlDbType.VarChar).Value = prekeEvm.Preke.Dieta;
				args.Add("?kategorija", MySqlDbType.VarChar).Value = prekeEvm.Preke.FkKategorija;
			});
		}

		public static void Delete(int id)
		{
			var query = $@"DELETE FROM `prekes` WHERE kodas=?id";
			Sql.Delete(query, args => {
				args.Add("?id", MySqlDbType.Int32).Value = id;
			});
		}

		public static void DeleteForUzsakymas(int uzsakymas)
		{
			var query =
				$@"DELETE FROM a
				USING `uzsakytos_paslaugos` as a
				WHERE a.fk_sutartis=?fkid";

			Sql.Delete(query, args => {
				args.Add("?fkid", MySqlDbType.Int32).Value = uzsakymas;
			});
		}
	}
}