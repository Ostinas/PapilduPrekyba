using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace Org.Ktu.Isk.P175B602.Autonuoma.ViewModels
{
	/// <summary>
	/// View model for displaying list oft 'Uzsakymas' entities.
	/// </summary>
	public class UzsakymasListVM
	{
		[DisplayName("Nr.")]
		[Required]
		public int Nr { get; set; }


		[DisplayName("Užsakymo data")]
		[DataType(DataType.Date)]
		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
		public DateTime Data { get; set; }


		[DisplayName("Suma")]
		[Required]
		public decimal Suma { get; set; }


		[DisplayName("Parduotuvės id")]
		
        public int PardId { get; set; }


		[DisplayName("Darbuotojas")]
		[Required]
		public string Darbuotojas { get; set; }


		[DisplayName("Būsena")]
		[Required]
		public string Busena { get; set; }

		[DisplayName("Klientas")]
		[Required]
		public string Klientas { get; set; }
	}
}