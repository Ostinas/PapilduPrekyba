using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace Org.Ktu.Isk.P175B602.Autonuoma.ViewModels
{
	/// <summary>
	/// View model for editing data of 'Klientas' entity.
	/// </summary>
	public class KlientasEditVM
	{
		/// <summary>
		/// Entity data.
		/// </summary>
		public class KlientasM
		{
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

			[DisplayName("El. paštas")]
			[Required]
			public string Epastas { get; set; }

			[DisplayName("Adresas")]
			[Required]
			public string Adresas{ get; set; }
		}

		/// <summary>
		/// Select lists for making drop downs for choosing values of entity fields.
		/// </summary>
		public class ListsM
		{
			public IList<SelectListItem> Klientai { get; set; }
		}

		/// <summary>
		/// Entity view.
		/// </summary>
		public KlientasM Klientas { get; set; } = new KlientasM();

		/// <summary>
		/// Lists for drop down controls.
		/// </summary>
		public ListsM Lists { get; set; } = new ListsM();
	}
}