using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace Org.Ktu.Isk.P175B602.Autonuoma.ViewModels
{
	/// <summary>
	/// View model for editing data of 'Darbuotojas' entity.
	/// </summary>
	public class DarbuotojasEditVM
	{
		/// <summary>
		/// Entity data.
		/// </summary>
		public class DarbuotojasM
		{
			[DisplayName("Tabelio Nr.")]
			[Required]
			public string Tabelis { get; set; }

			[DisplayName("Vardas")]
			[Required]
			public string Vardas { get; set; }

			[DisplayName("Pavardė")]
			[Required]
			public string Pavarde { get; set; }

			[DisplayName("Parduotuvės ID")]
			[Required]
			public int PardId { get; set; }
		}

		/// <summary>
		/// Select lists for making drop downs for choosing values of entity fields.
		/// </summary>
		public class ListsM
		{
			public IList<SelectListItem> Parduotuves { get; set; }
		}

		/// <summary>
		/// Entity view.
		/// </summary>
		public DarbuotojasM Darbuotojas { get; set; } = new DarbuotojasM();

		/// <summary>
		/// Lists for drop down controls.
		/// </summary>
		public ListsM Lists { get; set; } = new ListsM();
	}
}