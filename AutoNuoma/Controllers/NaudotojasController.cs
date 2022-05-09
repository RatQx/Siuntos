using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoNuoma.Repos;
using AutoNuoma.Models;
using AutoNuoma.ViewModels;

namespace AutoNuoma.Controllers
{
    public class NaudotojasController : Controller
    {
        NaudotojasRepository naudotojasRepository = new NaudotojasRepository();
        LytisRepository lytisRepository = new LytisRepository();
        RolesRepository rolesRepository = new RolesRepository();

        public ActionResult Index()
        {
            ModelState.Clear();
            //gražinamas darbuotoju sarašo vaizdas
            return View(naudotojasRepository.getNaudotojai());
        }
        public ActionResult Create()
        {
            NaudotojasRegisterViewModel naudotojasViewModel = new NaudotojasRegisterViewModel();
            PopulateSelections(naudotojasViewModel);
            return View(naudotojasViewModel);
        }
/*
        [HttpPost]
        public ActionResult Create(NaudotojasRegisterViewModel collection)
        {
            try
            {
                if (collection. != null)
                {
                    foreach (var item in collection.darbuotojai)
                    {
                        naudotojasRepository.addNaudotojas(item);
                    }
                }

                return RedirectToAction("Index");
            }
            catch
            {
                PopulateSelectionsDarbuotojai(collection);
                return View(collection);
            }
        }
        */
     /*   public ActionResult Edit(string id)
        {
            NaudotojasRegisterViewModel editViewModel = new NaudotojasRegisterViewModel();
            editViewModel = naudotojasRepository.getNaudotojai(id);

            //Užpildomi pasirinkimų sąrašai
            PopulateSelections(editViewModel);
            return View(editViewModel);
        }



        // POST: Darbuotojas/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, DarbuotojasEditViewModel collection)
        {
            try
            {
                naudotojasRepository.updateDarbuotojas(collection);
                return RedirectToAction("Index");
            }
            catch
            {
                PopulateSelections(collection);
                return View(collection);
            }
        }

        public ActionResult Delete(int id)
        {
            return View(naudotojasRepository.getDarbuotojas(id));
        }

        // POST: Darbuotojas/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                bool naudojama = false;

                if (!naudojama)
                {
                    naudotojasRepository.deleteDarbuotojas(id);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }*/
        public void PopulateSelections(NaudotojasRegisterViewModel darbuotojasEditViewModel)
        {
            var lytys = lytisRepository.GetLytis();

            List<SelectListItem> selectListLytis = new List<SelectListItem>();


            foreach (var item in lytys)
            {
                selectListLytis.Add(new SelectListItem() { Value = Convert.ToString(item.pavadinimas), Text = item.pavadinimas });
            }


            darbuotojasEditViewModel.LytisList = selectListLytis;

        }

      /*  public void PopulateSelectionsDarbuotojai(NaudotojasRegisterViewModel darbuotojasEditViewModel)
        {
            var lytys = lytisRepository.GetLytis();

            List<SelectListItem> selectListLytis= new List<SelectListItem>();


            foreach (var item in lytys)
            {
                selectListLytis.Add(new SelectListItem() { Value = Convert.ToString(item.pavadinimas), Text = item.pavadinimas });
            }
            darbuotojasEditViewModel.LytisList = selectListLytis;
            if (darbuotojasEditViewModel.darbuotojai != null)
            {
                int count = darbuotojasEditViewModel.darbuotojai.Count;
                for (int i = 0; i < count; i++)
                {
                    darbuotojasEditViewModel.darbuotojai[i].vaistineList = selectListLytis;
                    darbuotojasEditViewModel.darbuotojai[i].fk_key = darbuotojasEditViewModel.darbuotojai[i].fk_vaistine;

                }
            }
        }
        */

    }
}
