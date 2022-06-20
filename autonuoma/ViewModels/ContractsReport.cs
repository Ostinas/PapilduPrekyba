using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace Org.Ktu.Isk.P175B602.Autonuoma.ViewModels.ContractsReport
{
	/// <summary>
	/// View model for single order in a report.
	/// </summary>
	public class Uzsakymas
	{
		[DisplayName("Užsakymas")]
		public int Nr { get; set; }

		[DisplayName("Data")]
		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
		public DateTime UzsakymoData { get; set; }

		public string Vardas { get; set; }

		public string Pavarde { get; set; }

		[DisplayName("Užsakymą sudaręs darbuotojas")]
		public string Darbuotojas { get; set; }

		public string KlientoID { get; set; }

		[DisplayName("Sudarytų užsakymų vertė")]
		public decimal Kaina { get; set; }

		[DisplayName("Papildomų prekių vertė")]
		public decimal PaslauguKaina { get; set; }

		public decimal BendraSuma { get; set; }

		public decimal BendraSumaPaslaug { get; set; }

		[DisplayName("Užsakymo būsena")]
		public string Busena { get; set; }

		public int IvykdytuSkaicius { get; set; }
	}

	/// <summary>
	/// View model for whole report.
	/// </summary>
	public class Report
	{
		[DataType(DataType.DateTime)]
		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
		public DateTime? DateFrom { get; set; }

		[DataType(DataType.DateTime)]
		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
		public DateTime? DateTo { get; set; }

		[DataType(DataType.Text)]
		[DisplayFormat(DataFormatString = "----------")]
		public string? Status { get; set; }

		public IEnumerable<SelectListItem> Busenos { get; set; }

		public List<Uzsakymas> Uzsakymai { get; set; }

		public decimal VisoSumaSutartciu { get; set; }

		public decimal VisoSumaPaslaugu { get; set; }

		public int VisoIvykdyta { get; set; }
	}
}