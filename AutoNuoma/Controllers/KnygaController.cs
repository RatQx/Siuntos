using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoNuoma.Repos;
using AutoNuoma.ViewModels;
namespace AutoNuoma.Controllers
{
    public class KnygaController :Controller
    {
        KnygaRepository knygaRepository = new KnygaRepository();
        ZanraiRepository zandraiRepository = new ZanraiRepository();
        KalbosRepository kalbosRepository = new KalbosRepository();

        public ActionResult Index()
        {
            ModelState.Clear();
            return View(knygaRepository.GetKnyga());
        }

        public ActionResult Create()
        {
            KnygaEditViewModel knygasEditViewModel = new KnygaEditViewModel();
            PopulateSelections(knygasEditViewModel);
            return View(knygasEditViewModel);
        }

        [HttpPost]
        public ActionResult Create(KnygaEditViewModel collection)
        {
            try
            {
                KnygaEditViewModel knyga = knygaRepository.GetKnyga(collection.ISBN);

                if (knyga.ISBN !=null)
                {
                  //  ModelState.AddModelError("tabelio_nr", "Gydytojas su tokiu tabelio numeriu jau egzistuoja duomenų bazėje.");
                    return View(collection);
                }
                if (ModelState.IsValid)
                {
                    knygaRepository.addKnyga(collection);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                PopulateSelections(collection);
                return View(collection);
            }
        }

        public ActionResult Edit(string id)
        {
            KnygaEditViewModel knygaEditViewModel = knygaRepository.GetKnyga(id);
            PopulateSelections(knygaEditViewModel);
            return View(knygaEditViewModel);
        }

        [HttpPost]
        public ActionResult Edit(string id, KnygaEditViewModel collection)
        {
            try
            {
                knygaRepository.updateKnyga(collection);
                return RedirectToAction("Index");
            }
            catch
            {
                PopulateSelections(collection);
                return View(collection);
            }
        }

        public ActionResult Delete(string id)
        {
            KnygaEditViewModel knygaEditViewModel = knygaRepository.GetKnyga(id);
            return View(knygaEditViewModel);
        }

        [HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
        {
            try
            {
                bool naudojama = false;


                if (!naudojama)
                {
                    knygaRepository.deleteKnyga(id);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public void PopulateSelections(KnygaEditViewModel knygaEditViewModel)
        {
            var kalbos = kalbosRepository.GetKalba();
            var zandrai = zandraiRepository.GetZanrai();
            List<SelectListItem> selectListItemsK = new List<SelectListItem>();
            List<SelectListItem> selectListItemsZ = new List<SelectListItem>();

            foreach (var item in kalbos)
            {
                selectListItemsK.Add(new SelectListItem() { Value = Convert.ToString(item.id_kalbos), Text = item.pavadinimas });
            }
            foreach (var item in zandrai)
            {
                selectListItemsZ.Add(new SelectListItem() { Value = Convert.ToString(item.id_zanrai), Text = item.pavadinimas });
            }
            knygaEditViewModel.zanrasList = selectListItemsZ;
            knygaEditViewModel.kalbaList = selectListItemsK;



        }
    }
}