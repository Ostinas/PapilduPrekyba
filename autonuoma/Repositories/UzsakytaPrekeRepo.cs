using System.Data;
using MySql.Data.MySqlClient;

using Newtonsoft.Json;

using Org.Ktu.Isk.P175B602.Autonuoma.Models;
using Org.Ktu.Isk.P175B602.Autonuoma.ViewModels;


namespace Org.Ktu.Isk.P175B602.Autonuoma.Repositories
{
	/// <summary>
	/// Database operations related to 'UzsakytosPrekes' entity.
	/// </summary>
	public class UzsakytaPrekeRepo
	{
		public static List<UzsakymasEditVM.UzsakytaPrekeM> List(int uzsakymasId)
		{
			var prekes = new List<UzsakymasEditVM.UzsakytaPrekeM>();

			var query =
                $@"SELECT 
					uzsak.kiekis,
					uzsak.fk_uzsakymas as uzsakymas,
					uzsak.fk_uzsakymo_data as data,
					prek.pavadinimas as preke,
					prek.kaina as kaina
				FROM 
					`uzsakymo_prekes` uzsak
					LEFT JOIN `prekes` prek ON uzsak.fk_preke=prek.kodas
				WHERE fk_uzsakymas = ?uzsakymasId
				ORDER BY fk_preke ASC, fk_uzsakymo_data ASC";

            var dt =
				Sql.Query(query, args => {
					args.Add("?uzsakymasId", MySqlDbType.Int32).Value = uzsakymasId;
				});

			var inListId = 0;

			foreach (DataRow item in dt)
			{
				prekes.Add(new UzsakymasEditVM.UzsakytaPrekeM
				{
					InListId = inListId,
					Preke = Convert.ToString(item["preke"]),
					Kiekis = Convert.ToInt32(item["kiekis"]),
					Kaina = Convert.ToDecimal(item["kaina"])
				});

				//advance in list ID for next entry
				inListId += 1;
			}

			return prekes;
		}

		public static void Insert(int uzsaykmasId, UzsakymasEditVM.UzsakytaPrekeM up)
		{
            //deserialize 'Preke' foreign keys from 'UzsakytaPreke' view model key
/*            var fks =
                JsonConvert.DeserializeAnonymousType(
                    up.Preke,
                    //this creates object of correct shape that is filled in by the JSON deserializer
                    new
                    {

                        FkPreke = 1,
                        UzsakymoData = DateTime.Now
                    }
                );*/

            var query =
				$@"INSERT INTO `uzsakymo_prekes`
					(
						kiekis,
						kodas,
						fk_preke,
						fk_uzsakymas,
						fk_uzsakymo_data
					)
					VALUES(
						?kiekis,
						?kodas,
						?fk_preke,
						?fk_uzsakymas,
						?fk_uzsakymo_data
					)";

			Sql.Insert(query, args => {
				args.Add("?kiekis", MySqlDbType.Int32).Value = uzsaykmasId;
				args.Add("?kaina", MySqlDbType.Decimal).Value = up.Kaina;
				args.Add("?preke", MySqlDbType.String).Value = up.Preke;
				args.Add("?fk_uzsakymas", MySqlDbType.Int32).Value = up.InListId;
				//args.Add("?fk_uzsakymo_data", MySqlDbType.Date).Value = up.Kiekis;
			});
		}

		public static void DeleteForUzsakymas(int uzsakymas)
		{
			var query =
				$@"DELETE FROM `uzsakytos_prekes`
				WHERE fk_uzsakymas=?fk_uzsakymas";

			Sql.Delete(query, args => {
				args.Add("?fk_uzsakymas", MySqlDbType.Int32).Value = uzsakymas;
			});
		}
	}
}