using Microsoft.AspNetCore.Mvc;
using Org.Ktu.Isk.P175B602.Autonuoma.Repositories;

using ContractsReport = Org.Ktu.Isk.P175B602.Autonuoma.ViewModels.ContractsReport;


namespace Org.Ktu.Isk.P175B602.Autonuoma.Controllers
{
	/// <summary>
	/// Controller for producing reports.
	/// </summary>
	public class AtaskaitaController : Controller
	{
		/// <summary>
		/// Produces orders report.
		/// </summary>
		/// <param name="dateFrom">Starting date. Can be null.</param>
		/// <param name="dateTo">Ending date. Can be null.</param>
		/// <returns>Report view.</returns>
		public ActionResult Sutartys(DateTime? dateFrom, DateTime? dateTo, string status)
		{
			var report = new ContractsReport.Report();
			report.Busenos = BusenaRepo.List().Select(m => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem { Text = m.Pavadinimas, Value = m.Pavadinimas });
			report.Status = status;
			report.DateFrom = dateFrom;
			report.DateTo = dateTo?.AddHours(23).AddMinutes(59).AddSeconds(59); //move time of end date to end of day
			report.Uzsakymai = AtaskaitaRepo.GetContracts(report.DateFrom, report.DateTo, status);

			foreach (var item in report.Uzsakymai)
			{
				report.VisoSumaSutartciu += item.Kaina;
				report.VisoSumaPaslaugu += item.PaslauguKaina;
				report.VisoIvykdyta += item.IvykdytuSkaicius;
			}

			return View(report);
		}
	}
}
