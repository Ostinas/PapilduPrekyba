using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace Org.Ktu.Isk.P175B602.Autonuoma.ViewModels
{
	/// <summary>
	/// View model for editing data of 'Užsakymas' entity.
	/// </summary>
	public class UzsakymasEditVM
	{
		/// <summary>
		/// Entity data.
		/// </summary>
		public class UzsakymasM
		{
			[DisplayName("Nr")]
			public int Nr { get; set; }

			[DisplayName("Užsakymo data")]
			[DataType(DataType.Date)]
			[Required]
			public DateTime Data { get; set; }

			[DisplayName("Užsakymo kaina")]
			[Required]
			public decimal Kaina { get; set; }

			[DisplayName("Prekė")]
			[Required]
			public string Pavadinimas { get; set; }

			[DisplayName("Prekės kaina")]
			[Required]
			public decimal PrekesKaina { get; set; }

			[DisplayName("Prekės kiekis")]
			[Required]
			public int PrekesKiekis { get; set; }

			[DisplayName("Prekės aprašymas")]
			[Required]
			public string Aprasymas { get; set; }

			[DisplayName("Būsena")]
			[Required]
			public string Busena { get; set; }

			[DisplayName("Klientas")]
			[Required]
			public string FkKlientas { get; set; }

			[DisplayName("Darbuotojas")]
			[Required]
			public string FkDarbuotojas { get; set; }
		}

		/// <summary>
		/// Representation of 'UzsakytaPreke' entity in 'Uzsakymas' edit form.
		/// </summary>
		public class UzsakytaPrekeM
		{
			/// <summary>
			/// ID of the record in the form. Is used when adding and removing records.
			/// </summary>
			public int InListId { get; set; }

			[DisplayName("Prekė")]
			[Required]
			public string Preke { get; set; }

			[DisplayName("Kiekis")]
			[Required]
			[Range(1, int.MaxValue)]
			public int Kiekis { get; set; }

			[DisplayName("Kaina")]
			[Required]
			public decimal Kaina { get; set; }
		}

		/// <summary>
		/// Select lists for making drop downs for choosing values of entity fields.
		/// </summary>
		public class ListsM
		{
			public IList<SelectListItem> Klientai { get; set; }

			public IList<SelectListItem> Darbuotojai { get; set; }

			public IList<SelectListItem> Busenos { get; set; }

			public IList<SelectListItem> Prekes { get; set; }
		}


		/// <summary>
		/// Entity view.
		/// </summary>
		public UzsakymasM Uzsakymas { get; set; } = new UzsakymasM();

		/// <summary>
		/// Views of related 'UzsakytosPaslaugos' records.
		/// </summary>
		public IList<UzsakytaPrekeM> UzsakytosPrekes { get; set; } = new List<UzsakytaPrekeM>();

		/// <summary>
		/// Lists for drop down controls.
		/// </summary>
		public ListsM Lists { get; set; } = new ListsM();
	}
}