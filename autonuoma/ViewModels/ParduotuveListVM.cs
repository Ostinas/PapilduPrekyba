using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace Org.Ktu.Isk.P175B602.Autonuoma.ViewModels
{
	/// <summary>
	/// View model for displaying list of 'Parduotuve' entities.
	/// </summary>
	public class ParduotuveListVM
	{
		[DisplayName("Id")]
		public int Id { get; set; }


		[DisplayName("Pavadinimas")]
		[Required]
		public string Pavadinimas { get; set; }


		[DisplayName("Adresas")]
		[Required]
		public string Adresas { get; set; }


		[DisplayName("Telefonas")]
		[Required]
		public string Telefonas { get; set; }


		[DisplayName("El. paštas")]
		[Required]
		public string Epastas { get; set; }

		[DisplayName("Miestas")]
		[Required]
		public string Miestas { get; set; }

		[DisplayName("Aukštesnio padalinio id")]
		[Required]
		public int? Padalinys { get; set; }
	}
}