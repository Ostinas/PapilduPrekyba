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
	/// Database operations related to 'Darbuotojas' entity.
	/// </summary>
	public class DarbuotojasRepo
	{
		public static List<Darbuotojas> List()
		{
			var darbuotojai = new List<Darbuotojas>();
			
			string query = $@"SELECT * FROM `darbuotojai` ORDER BY darbuotojo_id ASC";
			var dt = Sql.Query(query);

			foreach( DataRow item in dt )
			{
				darbuotojai.Add(new Darbuotojas
				{
					Tabelis = Convert.ToString(item["darbuotojo_id"]),
					Vardas = Convert.ToString(item["vardas"]),
					Pavarde = Convert.ToString(item["pavarde"]),
					PardId = Convert.ToInt32(item["fk_parduotuves_id"])
				});
			}

			return darbuotojai;
		}

		public static DarbuotojasEditVM Find(string tabnr)
		{
			var query = $@"SELECT * FROM `darbuotojai` WHERE darbuotojo_id=?tab";

			var dt = 
				Sql.Query(query, args => {
					args.Add("?tab", MySqlDbType.VarChar).Value = tabnr;
				});

			if( dt.Count > 0 )
			{
				var darbuotojas = new DarbuotojasEditVM();

				foreach( DataRow item in dt )
				{
					darbuotojas.Darbuotojas.Tabelis = Convert.ToString(item["darbuotojo_id"]);
					darbuotojas.Darbuotojas.Vardas = Convert.ToString(item["vardas"]);
					darbuotojas.Darbuotojas.Pavarde = Convert.ToString(item["pavarde"]);
					darbuotojas.Darbuotojas.PardId = Convert.ToInt32(item["fk_parduotuves_id"]);
				}

				return darbuotojas;
			}

			return null;
		}

		public static DarbuotojasListVM FindForDeletion(string tabnr)
		{
			var query = $@"SELECT * FROM `darbuotojai` WHERE darbuotojo_id=?tab";

			var dt =
				Sql.Query(query, args => {
					args.Add("?tab", MySqlDbType.VarChar).Value = tabnr;
				});

			if (dt.Count > 0)
			{
				var darbuotojas = new DarbuotojasListVM();

				foreach (DataRow item in dt)
				{
					darbuotojas.Tabelis = Convert.ToString(item["darbuotojo_id"]);
					darbuotojas.Vardas = Convert.ToString(item["vardas"]);
					darbuotojas.Pavarde = Convert.ToString(item["pavarde"]);
					darbuotojas.PardId = Convert.ToInt32(item["fk_parduotuves_id"]);
				}

				return darbuotojas;
			}

			return null;
		}

		public static void Update(DarbuotojasEditVM darb)
		{						
			var query = 
				$@"UPDATE `darbuotojai`
				SET 
					vardas=?vardas, 
					pavarde=?pavarde
					fk_parduotuves_id=?fk_parduotuves_id
				WHERE 
					darbuotojo_id=?tab";

			Sql.Update(query, args => {
				args.Add("?vardas", MySqlDbType.VarChar).Value = darb.Darbuotojas.Vardas;
				args.Add("?pavarde", MySqlDbType.VarChar).Value = darb.Darbuotojas.Pavarde;
				//args.Add("?tab", MySqlDbType.VarChar).Value = darb.Darbuotojas.Tabelis;
				args.Add("?fk_parduotuves_id", MySqlDbType.Int32).Value = darb.Darbuotojas.PardId;
			});				
		}

		public static void Insert(DarbuotojasEditVM darb)
		{							
			var query = 
				$@"INSERT INTO `darbuotojai`
				(
					vardas,
					pavarde,
					fk_parduotuves_id
				)
				VALUES(
					?vardas,
					?pavarde,
					?fk_parduotuves_id
				)";

			Sql.Insert(query, args => {
				args.Add("?vardas", MySqlDbType.VarChar).Value = darb.Darbuotojas.Vardas;
				args.Add("?pavarde", MySqlDbType.VarChar).Value = darb.Darbuotojas.Pavarde;
				//args.Add("?tabelio_nr", MySqlDbType.VarChar).Value = darb.Tabelis;
				args.Add("?fk_parduotuves_id", MySqlDbType.Int32).Value = darb.Darbuotojas.PardId;
			});				
		}

		public static void Delete(string id)
		{			
			var query = $@"DELETE FROM `darbuotojai` WHERE darbuotojo_id=?id";
			Sql.Delete(query, args => {
				args.Add("?id", MySqlDbType.VarChar).Value = id;
			});			
		}
	}
}