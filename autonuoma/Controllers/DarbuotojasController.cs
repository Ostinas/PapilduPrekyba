using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Org.Ktu.Isk.P175B602.Autonuoma.Repositories;
using Org.Ktu.Isk.P175B602.Autonuoma.Models;
using Org.Ktu.Isk.P175B602.Autonuoma.ViewModels;


namespace Org.Ktu.Isk.P175B602.Autonuoma.Controllers
{
	/// <summary>
	/// Controller for working with 'Darbuotojas' entity.
	/// </summary>
	public class DarbuotojasController : Controller
	{
		/// <summary>
		/// This is invoked when either 'Index' action is requested or no action is provided.
		/// </summary>
		/// <returns>Entity list view.</returns>
		public ActionResult Index()
		{
			//gražinamas darbuotoju sarašo vaizdas
			return View(DarbuotojasRepo.List());
		}

		/// <summary>
		/// This is invoked when creation form is first opened in browser.
		/// </summary>
		/// <returns>Creation form view.</returns>
		public ActionResult Create()
		{
/*			var darb = new Darbuotojas();
			return View(darb);*/
			var darbuotojasEvm = new DarbuotojasEditVM();
			PopulateLists(darbuotojasEvm);
			return View(darbuotojasEvm);
		}

		/// <summary>
		/// This is invoked when buttons are pressed in the creation form.
		/// </summary>
		/// <param name="darb">Entity model filled with latest data.</param>
		/// <returns>Returns creation from view or redirects back to Index if save is successfull.</returns>
		[HttpPost]
		public ActionResult Create(DarbuotojasEditVM darb)
		{
			//do not allow creation of entity with 'tabelis' field matching existing one
			var match = DarbuotojasRepo.Find(darb.Darbuotojas.Tabelis);

			if( match !=null )
				ModelState.AddModelError("tabelis", "Field value already exists in database.");

			//form field validation passed?
			if (ModelState.IsValid)
			{
				DarbuotojasRepo.Insert(darb);

				//save success, go back to the entity list
				return RedirectToAction("Index");
			}
			PopulateLists(darb);
			//form field validation failed, go back to the form
			return View(darb);
		}

		/// <summary>
		/// This is invoked when editing form is first opened in browser.
		/// </summary>
		/// <param name="id">ID of the entity to edit.</param>
		/// <returns>Editing form view.</returns>
		public ActionResult Edit(string id)
		{
			var darbuotojasEvm = DarbuotojasRepo.Find(id);
			PopulateLists(darbuotojasEvm);
			return View(darbuotojasEvm);
		}

		/// <summary>
		/// This is invoked when buttons are pressed in the editing form.
		/// </summary>
		/// <param name="id">ID of the entity being edited</param>		
		/// <param name="darb">Entity model filled with latest data.</param>
		/// <returns>Returns editing from view or redirects back to Index if save is successfull.</returns>
		[HttpPost]
		public ActionResult Edit(string id, DarbuotojasEditVM darb)
		{
			//form field validation passed?
			if (ModelState.IsValid)
			{
				DarbuotojasRepo.Update(darb);

				//save success, go back to the entity list
				return RedirectToAction("Index");
			}
			PopulateLists(darb);
			//form field validation failed, go back to the form
			return View(darb);
		}

		/// </summary>
		/// <param name="id">ID of the entity to delete.</param>
		/// <returns>Deletion form view.</returns>
		public ActionResult Delete(string id)
		{
			var darb = DarbuotojasRepo.FindForDeletion(id);
			return View(darb);
		}

		/// <summary>
		/// This is invoked when deletion is confirmed in deletion form
		/// </summary>
		/// <param name="id">ID of the entity to delete.</param>
		/// <returns>Deletion form view on error, redirects to Index on success.</returns>
		[HttpPost]
		public ActionResult DeleteConfirm(string id)
		{
			//try deleting, this will fail if foreign key constraint fails
			try 
			{
				DarbuotojasRepo.Delete(id);

				//deletion success, redired to list form
				return RedirectToAction("Index");
			}
			//entity in use, deletion not permitted
			catch( MySql.Data.MySqlClient.MySqlException )
			{
				//enable explanatory message and show delete form
				ViewData["deletionNotPermitted"] = true;

				var darb = DarbuotojasRepo.Find(id);
				return View("Delete", darb);
			}
		}

		/// <summary>
		/// Populates select lists used to render drop down controls.
		/// </summary>
		/// <param name="darbuotojasEvm">'Uzsakymas' view model to append to.</param>
		private void PopulateLists(DarbuotojasEditVM darbuotojasEvm)
        {
            //load entities for the select lists
            var parduotuves = ParduotuveRepo.List();

            //build select lists
            darbuotojasEvm.Lists.Parduotuves =
                parduotuves
                    .Select(it =>
                    {
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
