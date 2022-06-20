using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace Org.Ktu.Isk.P175B602.Autonuoma.ViewModels
{
	/// <summary>
	/// View model for displaying list of 'Darbuotojas' entities.
	/// </summary>
	public class DarbuotojasListVM
	{
		[DisplayName("Tabelio Nr.")]
		[MaxLength(10)]
		[Required]
		public string Tabelis { get; set; }

		[DisplayName("Vardas")]
		[MaxLength(20)]
		[Required]
		public string Vardas { get; set; }

		[DisplayName("Pavardė")]
		[MaxLength(20)]
		[Required]
		public string Pavarde { get; set; }

		[DisplayName("Parduotuvės ID")]
		[Required]
		public int PardId { get; set; }
	}
}