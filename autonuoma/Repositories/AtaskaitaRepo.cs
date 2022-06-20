using System.Data;
using MySql.Data.MySqlClient;

using ContractsReport = Org.Ktu.Isk.P175B602.Autonuoma.ViewModels.ContractsReport;


namespace Org.Ktu.Isk.P175B602.Autonuoma.Repositories
{
	/// <summary>
	/// Database operations related to reports.
	/// </summary>
	public class AtaskaitaRepo
	{
		public static List<ContractsReport.Uzsakymas> GetContracts(DateTime? dateFrom, DateTime? dateTo, String status)
		{
			var result = new List<ContractsReport.Uzsakymas>();

			var query =
				$@"SELECT
					uzs.nr,
					uzs.uzsakymo_data,
					kln.vardas,
					kln.pavarde,
					kln.id_klientas,
					uzs.suma,
					IFNULL(SUM(prek.kaina*up.kiekis), 0) paslaugu_kaina,
					bs1.bendra_suma,
					bs2.bendra_suma bendra_suma_paslaugu,
					CONCAT(darb.vardas,' ', darb.pavarde) AS darbuotojas, 
					UPPER(bus.name) AS busena,
					SUM(IF(bus.name = 'Įvykdytas', 1, 0)) AS ivykdytu_skaicius
				FROM
					`uzsakymai` uzs
					INNER JOIN `klientai` kln ON kln.id_klientas = uzs.fk_id_klientas
					LEFT JOIN `uzsakymo_prekes` up ON up.fk_uzsakymas = uzs.nr
					LEFT JOIN `prekes` prek ON prek.kodas = up.fk_preke
					LEFT JOIN `darbuotojai` darb ON darb.darbuotojo_id = uzs.fk_darbuotojo_id
					LEFT JOIN (
							SELECT * 
							FROM `busenos` 
							WHERE name = IFNUll(?status, name)
								
							) AS bus 
							ON uzs.busena=bus.id		
					LEFT JOIN
						(
							SELECT
								kln1.id_klientas,
								SUM(uzs1.suma) AS bendra_suma
							FROM `uzsakymai` uzs1, `klientai` kln1
							WHERE
								kln1.id_klientas=uzs1.fk_id_klientas
								AND uzs1.uzsakymo_data >= IFNULL(?nuo, uzs1.uzsakymo_data)
								AND uzs1.uzsakymo_data <= IFNULL(?iki, uzs1.uzsakymo_data)
								GROUP BY kln1.id_klientas
						) AS bs1
						ON bs1.id_klientas = kln.id_klientas
					LEFT JOIN
						(
							SELECT
								kln2.id_klientas,
								IFNULL(SUM(up2.kiekis*prek2.kaina), 0) AS bendra_suma
							FROM
								`uzsakymai` uzs2
								INNER JOIN `klientai` kln2 ON kln2.id_klientas = uzs2.fk_id_klientas
								LEFT JOIN `uzsakymo_prekes` up2 ON up2.fk_uzsakymas = uzs2.nr
								LEFT JOIN `prekes` prek2 ON prek2.kodas = up2.fk_preke
							WHERE
								uzs2.uzsakymo_data >= IFNULL(?nuo, uzs2.uzsakymo_data)
								AND uzs2.uzsakymo_data <= IFNULL(?iki, uzs2.uzsakymo_data)
							GROUP BY kln2.id_klientas
						) AS bs2
						ON bs2.id_klientas = kln.id_klientas
				WHERE
					uzs.uzsakymo_data >= IFNULL(?nuo, uzs.uzsakymo_data)
					AND uzs.uzsakymo_data <= IFNULL(?iki, uzs.uzsakymo_data)
					AND bus.name = IFNULL(?status, bus.name)
				GROUP BY 
					uzs.nr, kln.id_klientas
				ORDER BY 
					kln.pavarde ASC, kln.vardas ASC";

			var dt =
				Sql.Query(query, args => {
					args.Add("?nuo", MySqlDbType.DateTime).Value = dateFrom;
					args.Add("?iki", MySqlDbType.DateTime).Value = dateTo;
					args.Add("?status", MySqlDbType.String).Value = status;
				});

			foreach( DataRow item in dt )
			{
				result.Add(new ContractsReport.Uzsakymas
				{
					Nr = Convert.ToInt32(item["nr"]),
					UzsakymoData = Convert.ToDateTime(item["uzsakymo_data"]),
					KlientoID = Convert.ToString(item["id_klientas"]),
					Vardas = Convert.ToString(item["vardas"]),
					Pavarde = Convert.ToString(item["pavarde"]),
					Darbuotojas = Convert.ToString(item["darbuotojas"]),
					Kaina = Convert.ToDecimal(item["suma"]),
					PaslauguKaina = Convert.ToDecimal(item["paslaugu_kaina"]),
					BendraSuma = Convert.ToDecimal(item["bendra_suma"]),
					BendraSumaPaslaug = Convert.ToDecimal(item["bendra_suma_paslaugu"]),
					Busena = Convert.ToString(item["busena"]),
					IvykdytuSkaicius = Convert.ToInt32(item["ivykdytu_skaicius"])
				}); ;
			}
			return result;
		}
	}
}