using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace Org.Ktu.Isk.P175B602.Autonuoma.ViewModels
{
	/// <summary>
	/// View model for editing data of 'Parduotuve' entity.
	/// </summary>
	public class ParduotuveEditVM
	{
		/// <summary>
		/// Entity data.
		/// </summary>
		public class ParduotuveM
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
			public int FkMiestas { get; set; }

			[DisplayName("Aukštesnis padalinys")]
			public int? FkParduotuve{ get; set; }
		}

		/// <summary>
		/// Select lists for making drop downs for choosing values of entity fields.
		/// </summary>
		public class ListsM
		{
			public IList<SelectListItem> Miestai { get; set; }
			public IList<SelectListItem> AukstesniPadaliniai { get; set; }
		}

		/// <summary>
		/// Entity view.
		/// </summary>
		public ParduotuveM Parduotuve { get; set; } = new ParduotuveM();

		/// <summary>
		/// Lists for drop down controls.
		/// </summary>
		public ListsM Lists { get; set; } = new ListsM();
	}
}