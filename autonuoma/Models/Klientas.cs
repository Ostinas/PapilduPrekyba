using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace Org.Ktu.Isk.P175B602.Autonuoma.Models
{
	/// <summary>
	/// Model of 'Klientas' entity.
	/// </summary>
	public class Klientas
	{
		[DisplayName("Id")]
		public string Id { get; set; }

		[DisplayName("Asmens kodas")]
		[Required]
		public string AsmensKodas { get; set; }
		
		[DisplayName("Vardas")]
		[Required]
		public string Vardas { get; set; }

		[DisplayName("Pavardė")]
		[Required]
		public string Pavarde { get; set; }

		[DisplayName("Telefonas")]
		[Required]
		public string Telefonas { get; set; }

		[DisplayName("Elektroninis paštas")]
		[EmailAddress]
		[Required]
		public string Epastas { get; set; }

        [DisplayName("Adresas")]
        [Required]
        public string Adresas { get; set; }
    }
}