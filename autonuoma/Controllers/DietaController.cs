﻿using Microsoft.AspNetCore.Mvc;

using Org.Ktu.Isk.P175B602.Autonuoma.Repositories;
using Org.Ktu.Isk.P175B602.Autonuoma.Models;
using Org.Ktu.Isk.P175B602.Autonuoma.ViewModels;


namespace Org.Ktu.Isk.P175B602.Autonuoma.Controllers
{
	/// <summary>
	/// Controller for working with 'Dieta' entity.
	/// </summary>
	public class DietaController : Controller
	{
		/// <summary>
		/// This is invoked when either 'Index' action is requested or no action is provided.
		/// </summary>
		/// <returns>Entity list view.</returns>
		public ActionResult Index()
		{
			//gražinamas kategoriju sarašo vaizdas
			var dietos = DietaRepo.List();
			return View(dietos);
		}

		/// <summary>
		/// This is invoked when creation form is first opened in browser.
		/// </summary>
		/// <returns>Creation form view.</returns>
		public ActionResult Create()
		{
			var kat = new Dieta();
			return View(kat);
		}

		/// <summary>
		/// This is invoked when buttons are pressed in the creation form.
		/// </summary>
		/// <param name="kat">Entity model filled with latest data.</param>
		/// <returns>Returns creation from view or redirects back to Index if save is successfull.</returns>
		[HttpPost]
		public ActionResult Create(Dieta kat)
		{
			//do not allow creation of entity with 'Id' field matching existing one
			var match = DietaRepo.Find(kat.Id);

			if (match != null)
				ModelState.AddModelError("Id", "Field value already exists in database.");

			//form field validation passed?
			if (ModelState.IsValid)
			{
				DietaRepo.Insert(kat);

				//save success, go back to the entity list
				return RedirectToAction("Index");
			}

			//form field validation failed, go back to the form
			return View(kat);
		}

		/// <summary>
		/// This is invoked when editing form is first opened in browser.
		/// </summary>
		/// <param name="id">ID of the entity to edit.</param>
		/// <returns>Editing form view.</returns>
		public ActionResult Edit(int id)
		{
			return View(DietaRepo.Find(id));
		}

		/// <summary>
		/// This is invoked when buttons are pressed in the editing form.
		/// </summary>
		/// <param name="id">ID of the entity being edited</param>		
		/// <param name="darb">Entity model filled with latest data.</param>
		/// <returns>Returns editing from view or redirects back to Index if save is successfull.</returns>
		[HttpPost]
		public ActionResult Edit(string id, Dieta kat)
		{
			//form field validation passed?
			if (ModelState.IsValid)
			{
				DietaRepo.Update(kat);

				//save success, go back to the entity list
				return RedirectToAction("Index");
			}

			//form field validation failed, go back to the form
			return View(kat);
		}

		/// </summary>
		/// <param name="id">ID of the entity to delete.</param>
		/// <returns>Deletion form view.</returns>
		public ActionResult Delete(int id)
		{
			var kat = DietaRepo.Find(id);
			return View(kat);
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
				DietaRepo.Delete(id);

				//deletion success, redired to list form
				return RedirectToAction("Index");
			}
			//entity in use, deletion not permitted
			catch (MySql.Data.MySqlClient.MySqlException)
			{
				//enable explanatory message and show delete form
				ViewData["deletionNotPermitted"] = true;

				var kat = DietaRepo.Find(id);
				return View("Delete", kat);
			}
		}
	}
}
