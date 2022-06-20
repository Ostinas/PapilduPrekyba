using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace Org.Ktu.Isk.P175B602.Autonuoma.ViewModels
{
	/// <summary>
	/// Model of 'Preke' entity used in lists.
	/// </summary>
	public class PrekeListVM
	{
		[DisplayName("Id")]
		public int Id { get; set; }

		[DisplayName("Pavadinimas")]
		[Required]
		public string Pavadinimas { get; set; }

		[DisplayName("Kaina")]
		[Required]
		public decimal Kaina { get; set; }

		[DisplayName("Aprašymas")]
		[Required]
		public string Aprasymas { get; set; }

		[DisplayName("Maistinė informacija")]
		[Required]
		public string Maistine_informacija { get; set; }

		[DisplayName("Galiojimo laikas")]
		[DataType(DataType.Date)]
		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
		[Required]
		public DateTime Galiojimo_laikas { get; set; }

		[DisplayName("Dieta")]
		[Required]
		public string Dieta { get; set; }

		[DisplayName("Kategorija")]
		[Required]
		public string Kategorija { get; set; }
	}
}