using MySql.Data.MySqlClient;
using System.Data;

using Org.Ktu.Isk.P175B602.Autonuoma.ViewModels;


namespace Org.Ktu.Isk.P175B602.Autonuoma.Repositories
{
	/// <summary>
	/// Database operations related to 'Parduotuve' entity.
	/// </summary>
	public class ParduotuveRepo
	{
		public static List<ParduotuveListVM> List()
		{
			var result = new List<ParduotuveListVM>();

			var query =
				$@"SELECT 
					pard.parduotuves_id AS id, 
					pard.pavadinimas, 
					pard.adresas,
					pard.telefonas,
					pard.epastas,
					m.pavadinimas AS miestas,
					pard.fk_parduotuves_id AS padalinys
				FROM 
					`parduotuves` pard
					LEFT JOIN `miestai` m ON pard.fk_miestas=m.id

				ORDER BY id ASC";
			var dt = Sql.Query(query);

			foreach (DataRow item in dt)
			{
				result.Add(new ParduotuveListVM
				{
					Id = Convert.ToInt32(item["id"]),
					Pavadinimas = Convert.ToString(item["pavadinimas"]),
					Adresas = Convert.ToString(item["adresas"]),
					Telefonas = Convert.ToString(item["telefonas"]),
					Epastas = Convert.ToString(item["epastas"]),
					Miestas = Convert.ToString(item["miestas"]),
					Padalinys = Sql.AllowNull(item["padalinys"], it => (int?)Convert.ToInt32(it))
			});
			}

			return result;
		}
		
		public static ParduotuveEditVM Find(int id)
		{
			var result = new ParduotuveEditVM();

			string qlquery = $@"SELECT * FROM `parduotuves` WHERE parduotuves_id=?id";
			var dt =
				Sql.Query(qlquery, args => {
					args.Add("?id", MySqlDbType.Int32).Value = id;
				});

			var sut = result.Parduotuve;

			foreach (DataRow item in dt)
			{
				sut.Id = Convert.ToInt32(item["parduotuves_id"]);
				sut.Pavadinimas= Convert.ToString(item["pavadinimas"]);
				sut.Adresas= Convert.ToString(item["adresas"]);
				sut.Telefonas= Convert.ToString(item["telefonas"]);
				sut.Epastas= Convert.ToString(item["epastas"]);
				sut.FkMiestas = Convert.ToInt32(item["fk_miestas"]);
				sut.FkParduotuve = Sql.AllowNull(item["fk_parduotuves_id"], it => (int?)Convert.ToInt32(it));
			}

			return result;
		}

		public static ParduotuveListVM FindForDeletion(int id)
		{
			var plvm = new ParduotuveListVM();

			var query =
				$@"SELECT
					pard.parduotuves_id,
					pard.pavadinimas,
					pard.adresas,
					pard.telefonas,
					pard.epastas,
					miest.pavadinimas AS miestas
				FROM
					`parduotuves` pard
					LEFT JOIN `miestai` miest ON miest.id=pard.fk_miestas
				WHERE
					pard.parduotuves_id = ?id";

			var dt =
				Sql.Query(query, args => {
					args.Add("?id", MySqlDbType.Int32).Value = id;
				});

			foreach (DataRow item in dt)
			{
				plvm.Id = Convert.ToInt32(item["parduotuves_id"]);
				plvm.Pavadinimas = Convert.ToString(item["pavadinimas"]);
				plvm.Adresas = Convert.ToString(item["adresas"]);
				plvm.Telefonas = Convert.ToString(item["telefonas"]);
				plvm.Epastas = Convert.ToString(item["epastas"]);
				plvm.Miestas = Convert.ToString(item["miestas"]);
			}

			return plvm;
		}
		public static void Update(ParduotuveEditVM evm)
		{
			var query =
				$@"UPDATE `parduotuves`
				SET
					`parduotuves_id` = ?id,
					`pavadinimas` = ?pavadinimas,
					`adresas` = ?adresas,
					`telefonas` = ?telefonas,
					`epastas` = ?epastas,
					`fk_miestas` = ?fk_miestas,
					`fk_parduotuves_id` = ?fk_parduotuves_id
				WHERE parduotuves_id=?id";

			Sql.Update(query, args => {
				args.Add("?pavadinimas", MySqlDbType.VarChar).Value = evm.Parduotuve.Pavadinimas;
				args.Add("?adresas", MySqlDbType.VarChar).Value = evm.Parduotuve.Adresas;
				args.Add("?telefonas", MySqlDbType.VarChar).Value = evm.Parduotuve.Telefonas;
				args.Add("?epastas", MySqlDbType.VarChar).Value = evm.Parduotuve.Epastas;
				args.Add("?fk_miestas", MySqlDbType.Int32).Value = evm.Parduotuve.FkMiestas;
				args.Add("?fk_parduotuves_id", MySqlDbType.Int32).Value = evm.Parduotuve.FkParduotuve?.ToString();
				args.Add("?id", MySqlDbType.Int32).Value = evm.Parduotuve.Id;
			});
		}
		
		public static void Insert(ParduotuveEditVM evm)
		{
			var query =
				$@"INSERT INTO `parduotuves` 
				(
					pavadinimas,
					adresas,
					telefonas,
					epastas,
					fk_miestas,
					fk_parduotuves_id
				)
				VALUES(
					?pavadinimas,
					?adresas,
					?telefonas,
					?epastas,
					?fk_miestas,
					?fk_parduotuves_id
				)";

			Sql.Insert(query, args => {
				args.Add("?pavadinimas", MySqlDbType.VarChar).Value = evm.Parduotuve.Pavadinimas;
				args.Add("?adresas", MySqlDbType.VarChar).Value = evm.Parduotuve.Adresas;
				args.Add("?telefonas", MySqlDbType.VarChar).Value = evm.Parduotuve.Telefonas;
				args.Add("?epastas", MySqlDbType.VarChar).Value = evm.Parduotuve.Epastas;
				args.Add("?fk_miestas", MySqlDbType.Int32).Value = evm.Parduotuve.FkMiestas;
				args.Add("?fk_parduotuves_id", MySqlDbType.Int32).Value = evm.Parduotuve.FkParduotuve;
			});

		}
		public static void Delete(int id)
		{
			var query = $@"DELETE FROM `parduotuves` where parduotuves_id=?id";
			Sql.Delete(query, args => {
				args.Add("?id", MySqlDbType.Int32).Value = id;
			});
		}
	}
}