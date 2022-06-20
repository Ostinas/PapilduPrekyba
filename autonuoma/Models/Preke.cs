using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace Org.Ktu.Isk.P175B602.Autonuoma.Models
{
	/// <summary>
	/// Model of 'Preke' entity.
	/// </summary>
	public class Preke
	{
		[DisplayName("Id")]
		public int Id { get; set; }

		[DisplayName("Pavadinimas")]
		public string Pavadinimas { get; set; }

		[DisplayName("Kaina")]
		public decimal Kaina { get; set; }

		[DisplayName("Aprašymas")]
		public string Aprasymas { get; set; }

		[DisplayName("Maistinė informacija")]
		public string Maistine_informacija { get; set; }

		[DisplayName("Galiojimo laikas")]
		[DataType(DataType.Date)]
		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
		public DateTime Galiojimo_laikas { get; set; }

		[DisplayName("Dieta")]
		public int Dieta { get; set; }

		[DisplayName("Kategorija")]
		public int FkKategorija { get; set; }
	}
}