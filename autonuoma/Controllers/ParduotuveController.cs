using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using Org.Ktu.Isk.P175B602.Autonuoma.Repositories;
using Org.Ktu.Isk.P175B602.Autonuoma.Models;
using Org.Ktu.Isk.P175B602.Autonuoma.ViewModels;


namespace Org.Ktu.Isk.P175B602.Autonuoma.Controllers
{
	/// <summary>
	/// Controller for working with 'Parduotuve' entity.
	/// </summary>
	public class ParduotuveController : Controller
	{

		/// <summary>
		/// This is invoked when either 'Index' action is requested or no action is provided.
		/// </summary>
		/// <returns>Entity list view.</returns>
		public ActionResult Index()
		{
			var parduotuves = ParduotuveRepo.List();
			return View(parduotuves);
		}

		/// <summary>
		/// This is invoked when creation form is first opened in browser.
		/// </summary>
		/// <returns>Creation form view.</returns>
		public ActionResult Create()
		{
			var parduotuveEvm = new ParduotuveEditVM();
			PopulateSelections(parduotuveEvm);
			return View(parduotuveEvm);
		}

		/// <summary>
		/// This is invoked when buttons are pressed in the creation form.
		/// </summary>
		/// <param name="ParduotuveEditVM">Entity model filled with latest data.</param>
		/// <returns>Returns creation from view or redirects back to Index if save is successfull.</returns>
		[HttpPost]
		public ActionResult Create(ParduotuveEditVM parduotuveEditVM)
		{
			var match = ParduotuveRepo.Find(parduotuveEditVM.Parduotuve.Id);

			if (match != null)
				ModelState.AddModelError("Parduotuve.Id", "Field value already exists in database.");

			//form field validation passed?
			if (ModelState.IsValid)
			{
				ParduotuveRepo.Insert(parduotuveEditVM);

				//save success, go back to the entity list
				return RedirectToAction("Index");
			}

			//form field validation failed, go back to the form
			PopulateSelections(parduotuveEditVM);
			return View(parduotuveEditVM);
		}

		/// <summary>
		/// This is invoked when editing form is first opened in browser.
		/// </summary>
		/// <param name="id">ID of the entity to edit.</param>
		/// <returns>Editing form view.</returns>
		public ActionResult Edit(int id)
		{
			var parduotuveEvm = ParduotuveRepo.Find(id);
			PopulateSelections(parduotuveEvm);

			return View(parduotuveEvm);
		}

		/// <summary>
		/// This is invoked when buttons are pressed in the editing form.
		/// </summary>
		/// <param name="id">ID of the entity being edited</param>
		/// <param name="parduotuveEvm">Entity model filled with latest data.</param>
		/// <returns>Returns editing from view or redirects back to Index if save is successfull.</returns>
		[HttpPost]
		public ActionResult Edit(int id, ParduotuveEditVM parduotuveEvm)
		{
			//form field validation passed?
			if (ModelState.IsValid)
			{
				ParduotuveRepo.Update(parduotuveEvm);

				//save success, go back to the entity list
				return RedirectToAction("Index");
			}

			//form field validation failed, go back to the form
			PopulateSelections(parduotuveEvm);
			return View(parduotuveEvm);
		}

		/// </summary>
		/// <param name="id">ID of the entity to delete.</param>
		/// <returns>Deletion form view.</returns>
		public ActionResult Delete(int id)
		{
			var parduotuveLvm = ParduotuveRepo.FindForDeletion(id);
			return View(parduotuveLvm);
		}

		/// <summary>
		/// This is invoked when deletion is confirmed in deletion form
		/// </summary>
		/// <param name="id">ID of the entity to delete.</param>
		/// <returns>Deletion form view on error, redirects to Index on success.</returns>
		[HttpPost]
		public ActionResult DeleteConfirm(int id)
		{
			//try deleting, this will fail if foreign key constraint fails
			try
			{
				ParduotuveRepo.Delete(id);

				//deletion success, redired to list form
				return RedirectToAction("Index");
			}
			//entity in use, deletion not permitted
			catch (MySql.Data.MySqlClient.MySqlException)
			{
				//enable explanatory message and show delete form
				ViewData["deletionNotPermitted"] = true;

				var parduotuveLvm = ParduotuveRepo.FindForDeletion(id);

				return View("Delete", parduotuveLvm);
			}
		}

		/// <summary>
		/// Populates select lists used to render drop down controls.
		/// </summary>
		/// <param name="prekeEvm">'Automobilis' view model to append to.</param>
		public void PopulateSelections(ParduotuveEditVM parduotuveEvm)
		{
			//load entities for the select lists
			var miestai = MiestasRepo.List();
			var padaliniai = ParduotuveRepo.List();

			//build select lists
			parduotuveEvm.Lists.Miestai =
				miestai.Select(it => {
					return
						new SelectListItem()
						{
							Value = Convert.ToString(it.Id),
							Text = it.Pavadinimas
						};
				})
				.ToList();
			parduotuveEvm.Lists.AukstesniPadaliniai =
				padaliniai.Select(it => {
					return
						new SelectListItem()
						{
							Value = Convert.ToString(it.Id),
							Text = it.Id.ToString()
						};
				})
				.ToList();
		}
	}
}
