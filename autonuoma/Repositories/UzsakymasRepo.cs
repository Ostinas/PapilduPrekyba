using MySql.Data.MySqlClient;
using System.Data;

using Org.Ktu.Isk.P175B602.Autonuoma.ViewModels;


namespace Org.Ktu.Isk.P175B602.Autonuoma.Repositories
{
    /// <summary>
    /// Database operations related to 'Užsakymas' entity.
    /// </summary>
    public class UzsakymasRepo
    {
        public static List<UzsakymasListVM> List()
        {
            var result = new List<UzsakymasListVM>();

            var query =
                $@"SELECT 
					uzsak.nr, 
					uzsak.uzsakymo_data as data, 
					CONCAT(darb.vardas,' ', darb.pavarde) as darbuotojas, 
					CONCAT(klien.vardas,' ',klien.pavarde) as klientas,
                    uzsak.suma,
					bus.name as busena
				FROM 
					`uzsakymai` uzsak
					LEFT JOIN `darbuotojai` darb ON uzsak.fk_darbuotojo_id=darb.darbuotojo_id
					LEFT JOIN `klientai` klien ON uzsak.fk_id_klientas=klien.id_klientas
					LEFT JOIN `busenos` bus ON uzsak.busena=bus.id				
				ORDER BY uzsak.nr ASC";
            var dt = Sql.Query(query);

            foreach (DataRow item in dt)
            {
                result.Add(new UzsakymasListVM
                {
                    Nr = Convert.ToInt32(item["nr"]),
                    Darbuotojas = Convert.ToString(item["darbuotojas"]),
                    Klientas = Convert.ToString(item["klientas"]),
                    Data = Convert.ToDateTime(item["data"]),
                    Busena = Convert.ToString(item["busena"]),
                    Suma = Convert.ToDecimal(item["suma"])
                });
            }

            return result;
        }

        public static UzsakymasEditVM Find(int nr)
        {
            var result = new UzsakymasEditVM();

            string qlquery =
                $@"SELECT 
                    uzsak.nr,
                    uzsak.uzsakymo_data,
                    uzsak.suma,
                    uzsak.busena,
                    uzsak.fk_id_klientas,
                    uzsak.fk_darbuotojo_id,
                    uzprek.kiekis,
                    prek.pavadinimas,
                    prek.kaina,
                    prek.aprasymas
                FROM 
                    `uzsakymai` uzsak 
                    LEFT JOIN `uzsakymo_prekes` uzprek ON uzsak.nr=uzprek.fk_uzsakymas
                    LEFT JOIN `prekes` prek ON uzprek.fk_preke=prek.kodas
                WHERE nr=?nr
                ORDER BY uzsak.nr ASC";

            var dt =
                Sql.Query(qlquery, args =>
                {
                    args.Add("?nr", MySqlDbType.Int32).Value = nr;
                    //args.Add("?data", MySqlDbType.DateTime).Value = data;
                });

            foreach (DataRow item in dt)
            {
                result.Uzsakymas.Nr = Convert.ToInt32(item["nr"]);
                result.Uzsakymas.Data = Convert.ToDateTime(item["uzsakymo_data"]);
                result.Uzsakymas.Kaina = Convert.ToDecimal(item["suma"]);
                result.Uzsakymas.Busena = Convert.ToString(item["busena"]);
                result.Uzsakymas.FkKlientas = Convert.ToString(item["fk_id_klientas"]);
                result.Uzsakymas.FkDarbuotojas = Convert.ToString(item["fk_darbuotojo_id"]);
                result.Uzsakymas.Pavadinimas = Convert.ToString(item["pavadinimas"]);
                result.Uzsakymas.PrekesKiekis = Sql.AllowNull(item["kiekis"], it => (int)Convert.ToInt32(it)); //Convert.ToInt32(item["kiekis"]);
                result.Uzsakymas.PrekesKaina = Sql.AllowNull(item["kaina"], it => (decimal)Convert.ToDecimal(it)); //Convert.ToDecimal(item["kaina"]);
                //result.Uzsakymas.Aprasymas = Convert.ToString(item["aprasymas"]);
            }

            return result;
        }

        public static void Update(UzsakymasEditVM evm)
        {
            var query =
                $@"UPDATE `uzsakymai`
				SET
                    `nr` = ?nr,
					`uzsakymo_data` = ?uzsakymo_data,
					`suma` = ?suma,
					`busena` = ?busena,
					`fk_id_klientas` = ?klientas,
					`fk_darbuotojo_id` = ?darbuotojas
				WHERE nr=?nr";

            Sql.Update(query, args =>
            {
                args.Add("?suma", MySqlDbType.Decimal).Value = evm.Uzsakymas.Kaina;
                args.Add("?busena", MySqlDbType.Int32).Value = evm.Uzsakymas.Busena;
                args.Add("?darbuotojas", MySqlDbType.VarChar).Value = evm.Uzsakymas.FkDarbuotojas;
                args.Add("?klientas", MySqlDbType.VarChar).Value = evm.Uzsakymas.FkKlientas;
                args.Add("?uzsakymo_data", MySqlDbType.DateTime).Value = evm.Uzsakymas.Data;

                args.Add("?nr", MySqlDbType.Int32).Value = evm.Uzsakymas.Nr;
            });
        }

        public static void Insert(UzsakymasEditVM evm)
        {
            var query =
                $@"INSERT INTO `uzsakymai` 
				(
					`uzsakymo_data`,
					`suma`,
					`busena`,
					`fk_id_klientas`,
					`fk_darbuotojo_id`
				)
				VALUES(
					?uzsakymo_data,
					?suma,
					?busena,
					?klientas,
					?darbuotojas
				)";

            var nr =
                Sql.Insert(query, args =>
                {
                    //args.Add("?nr", MySqlDbType.Int32).Value = evm.Uzsakymas.Nr;
                    args.Add("?uzsakymo_data", MySqlDbType.Date).Value = evm.Uzsakymas.Data;
                    args.Add("?suma", MySqlDbType.Decimal).Value = evm.Uzsakymas.Kaina;
                    args.Add("?busena", MySqlDbType.Int32).Value = evm.Uzsakymas.Busena;
                    args.Add("?darbuotojas", MySqlDbType.VarChar).Value = evm.Uzsakymas.FkDarbuotojas;
                    args.Add("?klientas", MySqlDbType.VarChar).Value = evm.Uzsakymas.FkKlientas;
                });

        }

        public static void Delete(int nr)
        {
            var query = $@"DELETE FROM `uzsakymai` where nr=?nr";
            Sql.Delete(query, args =>
            {
                args.Add("?nr", MySqlDbType.Int32).Value = nr;
            });
        }
    }
}