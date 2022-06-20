using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using Newtonsoft.Json;

using Org.Ktu.Isk.P175B602.Autonuoma.Repositories;
using Org.Ktu.Isk.P175B602.Autonuoma.ViewModels;

namespace Org.Ktu.Isk.P175B602.Autonuoma.Controllers
{
    /// <summary>
    /// Controller for working with 'Užsakymas' entity.
    /// </summary>
    public class UzsakymasController : Controller
    {
        /// <summary>
        /// This is invoked when either 'Index' action is requested or no action is provided.
        /// </summary>
        /// <returns>Entity list view.</returns>
        public ActionResult Index()
        {
            return View(UzsakymasRepo.List());
        }

        /// <summary>
        /// This is invoked when creation form is first opened in a browser.
        /// </summary>
        /// <returns>Entity creation form.</returns>
        public ActionResult Create()
        {
            var uzsakymasEvm = new UzsakymasEditVM();
            uzsakymasEvm.Uzsakymas.Data = DateTime.Now;

            PopulateLists(uzsakymasEvm);

            return View(uzsakymasEvm);
        }


        /// <summary>
        /// This is invoked when buttons are pressed in the creation form.
        /// </summary>
        /// <param name="save">If not null, indicates that 'Save' button was clicked.</param>
        /// <param name="add">If not null, indicates that 'Add' button was clicked.</param>
        /// <param name="remove">If not null, indicates that 'Remove' button was clicked and contains in-list-id of the item to remove.</param>
        /// <param name="uzsakymasEvm">Entity view model filled with latest data.</param>
        /// <returns>Returns creation from view or redirets back to Index if save is successfull.</returns>
        [HttpPost]
        public ActionResult Create(int? save, int? add, int? remove, UzsakymasEditVM uzsakymasEvm)
        {
            //addition of new 'UzsakytosPrekes' record was requested?
            if (add != null)
            {
                //add entry for the new record
                var up =
                    new UzsakymasEditVM.UzsakytaPrekeM
                    {
                        InListId =
                            uzsakymasEvm.UzsakytosPrekes.Count > 0 ?
                            uzsakymasEvm.UzsakytosPrekes.Max(it => it.InListId) + 1 :
                            0,

                        Preke = null,
                        Kiekis = 0,
                        Kaina = 0
                    };
                uzsakymasEvm.UzsakytosPrekes.Add(up);

                //make sure @Html helper is not reusing old model state containing the old list
                ModelState.Clear();

                //go back to the form
                PopulateLists(uzsakymasEvm);
                return View(uzsakymasEvm);
            }

            //removal of existing 'UzsakytosPrekes' record was requested?
            if (remove != null)
            {
                //filter out 'UzsakytosPrekes' record having in-list-id the same as the given one
                uzsakymasEvm.UzsakytosPrekes =
                    uzsakymasEvm
                        .UzsakytosPrekes
                        .Where(it => it.InListId != remove.Value)
                        .ToList();

                //make sure @Html helper is not reusing old model state containing the old list
                ModelState.Clear();

                //go back to the form
                PopulateLists(uzsakymasEvm);
                return View(uzsakymasEvm);
            }

            //save of the form data was requested?
            if (save != null)
            {

                var match = UzsakymasRepo.Find(uzsakymasEvm.Uzsakymas.Nr);

                if (match != null)
                    ModelState.AddModelError("Uzsakymas.Nr", "Field value already exists in database.");

                //form field validation passed?
                if (ModelState.IsValid)
                {
                    //create new 'Uzsakymas'
                    //uzsakymasEvm.Uzsakymas.Nr = UzsakymasRepo.Insert(uzsakymasEvm);

                    //create new 'UzsakytosPaslaugos' records
                    foreach (var upVm in uzsakymasEvm.UzsakytosPrekes)
                        UzsakytaPrekeRepo.Insert(uzsakymasEvm.Uzsakymas.Nr, upVm);

                    //save success, go back to the entity list
                    return RedirectToAction("Index");
                }
                //form field validation failed, go back to the form
                else
                {
                    PopulateLists(uzsakymasEvm);
                    return View(uzsakymasEvm);
                }
            }

            //should not reach here
            throw new Exception("Should not reach here.");
        }

        /// <summary>
        /// This is invoked when editing form is first opened in browser.
        /// </summary>
        /// <param name="id">ID of the entity to edit.</param>
        /// <returns>Editing form view.</returns>
        public ActionResult Edit(int id)
        {
            var uzsakymasEvm = UzsakymasRepo.Find(id);

            uzsakymasEvm.UzsakytosPrekes = UzsakytaPrekeRepo.List(id);
            PopulateLists(uzsakymasEvm);

            return View(uzsakymasEvm);
        }

        /// <summary>
        /// This is invoked when buttons are pressed in the editing form.
        /// </summary>
        /// <param name="id">ID of the entity being edited</param>
        /// <param name="save">If not null, indicates that 'Save' button was clicked.</param>
        /// <param name="add">If not null, indicates that 'Add' button was clicked.</param>
        /// <param name="remove">If not null, indicates that 'Remove' button was clicked and contains in-list-id of the item to remove.</param>
        /// <param name="uzsakymasEvm">Entity view model filled with latest data.</param>
        /// <returns>Returns editing from view or redired back to Index if save is successfull.</returns>
        [HttpPost]
        public ActionResult Edit(int id, int? save, int? add, int? remove, UzsakymasEditVM uzsakymasEvm)
        {
            //addition of new 'UzsakytosPrekes' record was requested?
            if (add != null)
            {
                //add entry for the new record
                var up =
                    new UzsakymasEditVM.UzsakytaPrekeM
                    {
                        InListId =
                            uzsakymasEvm.UzsakytosPrekes.Count > 0 ?
                            uzsakymasEvm.UzsakytosPrekes.Max(it => it.InListId) + 1 :
                            0,

                        Preke = null,
                        Kiekis = 0,
                        Kaina = 0
                    };
                uzsakymasEvm.UzsakytosPrekes.Add(up);

                //make sure @Html helper is not reusing old model state containing the old list
                ModelState.Clear();

                //go back to the form
                PopulateLists(uzsakymasEvm);
                return View(uzsakymasEvm);
            }

            //removal of existing 'UzsakytosPrekes' record was requested?
            if (remove != null)
            {
                //filter out 'UzsakytosPrekes' record having in-list-id the same as the given one
                uzsakymasEvm.UzsakytosPrekes =
                    uzsakymasEvm
                        .UzsakytosPrekes
                        .Where(it => it.InListId != remove.Value)
                        .ToList();

                //make sure @Html helper is not reusing old model state containing the old list
                ModelState.Clear();

                //go back to the form
                PopulateLists(uzsakymasEvm);
                return View(uzsakymasEvm);
            }

            //save of the form data was requested?
            if (save != null)
            {
                //form field validation passed?
                if (ModelState.IsValid)
                {
                    //update 'Uzsakymas'
                    UzsakymasRepo.Update(uzsakymasEvm);

                    //delete all old 'UzsakytosPrekes' records
                    UzsakytaPrekeRepo.DeleteForUzsakymas(uzsakymasEvm.Uzsakymas.Nr);

                    //create new 'UzsakytosPrekes' records
                    foreach (var upVm in uzsakymasEvm.UzsakytosPrekes)
                        UzsakytaPrekeRepo.Insert(uzsakymasEvm.Uzsakymas.Nr, upVm);

                    //save success, go back to the entity list
                    return RedirectToAction("Index");
                }
                //form field validation failed, go back to the form
                else
                {
                    PopulateLists(uzsakymasEvm);
                    return View(uzsakymasEvm);
                }
            }

            //should not reach here
            throw new Exception("Should not reach here.");
        }

        /// <summary>
        /// This is invoked when deletion form is first opened in browser.
        /// </summary>
        /// <param name="id">ID of the entity to delete.</param>
        /// <returns>Deletion form view.</returns>
        public ActionResult Delete(int id)
        {
            var uzsakymasEvm = UzsakymasRepo.Find(id);
            return View(uzsakymasEvm);
        }

        /// <summary>
        /// This is invoked when deletion is confirmed in deletion form
        /// </summary>
        /// <param name="id">ID of the entity to delete.</param>
        /// <returns>Deletion form view on error, redirects to Index on success.</returns>
        [HttpPost]
        public ActionResult DeleteConfirm(int id)
        {
            //load 'Uzsakymas'
            var uzsakymasEvm = UzsakymasRepo.Find(id);

            //'Uzsakymas' is in the state where deletion is permitted?
            if (uzsakymasEvm.Uzsakymas.Busena.Equals("ivykdytas"))
            {
                //delete the entity
                UzsakytaPrekeRepo.DeleteForUzsakymas(id);
                UzsakymasRepo.Delete(id);

                //redired to list form
                return RedirectToAction("Index");
            }
            //'Uzsakymas' is in state where deletion is not permitted
            else
            {
                //enable explanatory message and show delete form
                ViewData["deletionNotPermitted"] = true;
                return View("Delete", uzsakymasEvm);
            }
        }

        /// <summary>
        /// Populates select lists used to render drop down controls.
        /// </summary>
        /// <param name="uzsakymasEvm">'Uzsakymas' view model to append to.</param>
        private void PopulateLists(UzsakymasEditVM uzsakymasEvm)
        {
            //load entities for the select lists
            var busenos = BusenaRepo.List();
            var darbuotojai = DarbuotojasRepo.List();
            var klientai = KlientasRepo.List();
            var prekes = PrekeRepo.List();

            //build select lists
            uzsakymasEvm.Lists.Busenos =
                busenos
                    .Select(it =>
                    {
                        return
                            new SelectListItem
                            {
                                Value = Convert.ToString(it.Id),
                                Text = it.Pavadinimas
                            };
                    })
                    .ToList();

            uzsakymasEvm.Lists.Darbuotojai =
                darbuotojai
                    .Select(it =>
                    {
                        return
                            new SelectListItem
                            {
                                Value = it.Tabelis,
                                Text = $"{it.Vardas} {it.Pavarde}"
                            };
                    })
                    .ToList();

            uzsakymasEvm.Lists.Klientai =
                klientai
                    .Select(it =>
                    {
                        return
                            new SelectListItem
                            {
                                Value = it.Id,
                                Text = $"{it.Vardas} {it.Pavarde}"
                            };
                    })
                    .ToList();

            uzsakymasEvm.Lists.Prekes =
                prekes
                    .Select(it =>
                    {
                        return
                            new SelectListItem
                            {
                                Value = Convert.ToString(it.Id),
                                Text = $"{it.Pavadinimas} {it.Kaina} EUR"
                            };
                    })
                    .ToList();
        }
    }
}