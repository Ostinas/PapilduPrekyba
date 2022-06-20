using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace Org.Ktu.Isk.P175B602.Autonuoma.ViewModels
{
	/// <summary>
	/// Model of 'Preke' entity used in creation and editing forms.
	/// </summary>
	public class PrekeEditVM
	{
		/// <summary>
		/// Entity data
		/// </summary>
		public class PrekeM
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
			[Required]
			public DateTime Galiojimo_laikas { get; set; }

			[DisplayName("Dieta")]
			[Required]
			public int Dieta { get; set; }

			[DisplayName("Kategorija")]
			[Required]
			public int FkKategorija { get; set; }
		}

		/// <summary>
		/// Select lists for making drop downs for choosing values of entity fields.
		/// </summary>
		public class ListsM
		{
			public IList<SelectListItem> Kategorijos { get; set; }
			public IList<SelectListItem> Dietos { get; set; }
		}

		/// <summary>
		/// Entity view.
		/// </summary>
		public PrekeM Preke { get; set; } = new PrekeM();

		/// <summary>
		/// Lists for drop down controls.
		/// </summary>
		public ListsM Lists { get; set; } = new ListsM();
	}
}