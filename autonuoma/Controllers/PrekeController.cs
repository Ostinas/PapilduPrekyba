using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using Org.Ktu.Isk.P175B602.Autonuoma.Repositories;
using Org.Ktu.Isk.P175B602.Autonuoma.Models;
using Org.Ktu.Isk.P175B602.Autonuoma.ViewModels;


namespace Org.Ktu.Isk.P175B602.Autonuoma.Controllers
{
	/// <summary>
	/// Controller for working with 'Preke' entity.
	/// </summary>
	public class PrekeController : Controller
	{

		/// <summary>
		/// This is invoked when either 'Index' action is requested or no action is provided.
		/// </summary>
		/// <returns>Entity list view.</returns>
		public ActionResult Index()
		{
			var prekes = PrekeRepo.List();
			return View(prekes);
		}

		/// <summary>
		/// This is invoked when creation form is first opened in browser.
		/// </summary>
		/// <returns>Creation form view.</returns>
		public ActionResult Create()
		{
			var prekeEvm = new PrekeEditVM();
			PopulateSelections(prekeEvm);
			return View(prekeEvm);
		}

		/// <summary>
		/// This is invoked when buttons are pressed in the creation form.
		/// </summary>
		/// <param name="prekeEditVM">Entity model filled with latest data.</param>
		/// <returns>Returns creation from view or redirects back to Index if save is successfull.</returns>
		[HttpPost]
		public ActionResult Create(PrekeEditVM prekeEditVM)
		{
			//form field validation passed?
			if (ModelState.IsValid)
			{
				PrekeRepo.Insert(prekeEditVM);

				//save success, go back to the entity list
				return RedirectToAction("Index");
			}

			//form field validation failed, go back to the form
			PopulateSelections(prekeEditVM);
			return View(prekeEditVM);
		}

		/// <summary>
		/// This is invoked when editing form is first opened in browser.
		/// </summary>
		/// <param name="id">ID of the entity to edit.</param>
		/// <returns>Editing form view.</returns>
		public ActionResult Edit(int id)
		{
			var prekeEvm = PrekeRepo.Find(id);
			PopulateSelections(prekeEvm);

			return View(prekeEvm);
		}

		/// <summary>
		/// This is invoked when buttons are pressed in the editing form.
		/// </summary>
		/// <param name="id">ID of the entity being edited</param>
		/// <param name="prekeEvm">Entity model filled with latest data.</param>
		/// <returns>Returns editing from view or redirects back to Index if save is successfull.</returns>
		[HttpPost]
		public ActionResult Edit(int id, PrekeEditVM prekeEvm)
		{
			//form field validation passed?
			if (ModelState.IsValid)
			{
				PrekeRepo.Update(prekeEvm);

				//save success, go back to the entity list
				return RedirectToAction("Index");
			}

			//form field validation failed, go back to the form
			PopulateSelections(prekeEvm);
			return View(prekeEvm);
		}

		/// </summary>
		/// <param name="id">ID of the entity to delete.</param>
		/// <returns>Deletion form view.</returns>
		public ActionResult Delete(int id)
		{
			var prekeLvm = PrekeRepo.FindForDeletion(id);
			return View(prekeLvm);
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
				PrekeRepo.Delete(id);

				//deletion success, redired to list form
				return RedirectToAction("Index");
			}
			//entity in use, deletion not permitted
			catch (MySql.Data.MySqlClient.MySqlException)
			{
				//enable explanatory message and show delete form
				ViewData["deletionNotPermitted"] = true;

				var prekeLvm = PrekeRepo.FindForDeletion(id);

				return View("Delete", prekeLvm);
			}
		}

		/// <summary>
		/// Populates select lists used to render drop down controls.
		/// </summary>
		/// <param name="prekeEvm">'Automobilis' view model to append to.</param>
		public void PopulateSelections(PrekeEditVM prekeEvm)
		{
			//load entities for the select lists
			var kategorijos = KategorijaRepo.List();
			var dietos = DietaRepo.List();

			//build select lists
			prekeEvm.Lists.Kategorijos =
				kategorijos.Select(it => {
					return
						new SelectListItem()
						{
							Value = Convert.ToString(it.Id),
							Text = it.Pavadinimas
						};
				})
				.ToList();
			prekeEvm.Lists.Dietos =
				dietos.Select(it => {
					return
						new SelectListItem()
						{
							Value = Convert.ToString(it.Id),
							Text = it.Name
						};
				})
				.ToList();
		}
	}
}
