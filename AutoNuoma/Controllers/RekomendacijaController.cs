using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoNuoma.Repos;
using AutoNuoma.ViewModels;
namespace AutoNuoma.Controllers
{
    public class RekomendacijaController : Controller
    {
        KnygaRepository knygaRepository = new KnygaRepository(); //knygu perziurai
       // ZanraiRepository zandraiRepository = new ZanraiRepository(); //knygu pardavimu stebejimui
        RekomenduojamaKnygaRepository rekomenduojamaKnygaRepository = new RekomenduojamaKnygaRepository(); //rekomenduojamu knygu perziurai
        


        public ActionResult Edit()
        {
            ModelState.Clear();
            return View(rekomenduojamaKnygaRepository.GetKnyga());
        }
        public ActionResult Index()
        {
            ModelState.Clear();
            return View(rekomenduojamaKnygaRepository.GetKnyga());
        }
        public ActionResult Create()
        {
            ModelState.Clear();
            return View(knygaRepository.GetKnyga());
        }


        public ActionResult Add(string id)
        {
            KnygaEditViewModel knygaEditViewModel = knygaRepository.GetKnyga(id);
            return View(knygaEditViewModel);
        }

        [HttpPost]
        public ActionResult Add(string id, FormCollection collection)
        {
            try
            {
                bool naudojama = false;


                if (!naudojama)
                {
                    rekomenduojamaKnygaRepository.AddKnyga(id);
                }

                return RedirectToAction("Create");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(string id)
        {
            RekomenduojamaKnygaEditViewModel knygaEditViewModel = rekomenduojamaKnygaRepository.GetKnyga(id);
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
                    rekomenduojamaKnygaRepository.deleteKnyga(id);
                }

                return RedirectToAction("Edit");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Show()
        {
            return View(rekomenduojamaKnygaRepository.GetKnyga());
        }

        [HttpPost]
        public ActionResult Show(FormCollection collection)
        {
            try
            {
                bool naudojama = false;


                if (!naudojama)
                {
                    rekomenduojamaKnygaRepository.DeleteKnygos();
                    rekomenduojamaKnygaRepository.AddKnygos();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Check(string zanras, DateTime from, DateTime to)
        {
            //cia turi atvaizduoti visas knygas, kurios yra parduotos
            return View(rekomenduojamaKnygaRepository.GetSold(zanras, from, to));
        }

        [HttpPost]
        public ActionResult Check(string zanras, DateTime from, DateTime to, FormCollection collection)
        {
            try
            {
                bool naudojama = false;


                if (!naudojama)
                {
                    rekomenduojamaKnygaRepository.AddSold(zanras, from, to);
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
            //var kalbos = kalbosRepository.GetKalba();
            //var zandrai = zandraiRepository.GetZanrai();
            List<SelectListItem> selectListItemsK = new List<SelectListItem>();
            List<SelectListItem> selectListItemsZ = new List<SelectListItem>();
/*
            foreach (var item in kalbos)
            {
                selectListItemsK.Add(new SelectListItem() { Value = Convert.ToString(item.id_kalbos), Text = item.pavadinimas });
            }
            foreach (var item in zandrai)
            {
                selectListItemsZ.Add(new SelectListItem() { Value = Convert.ToString(item.id_zanrai), Text = item.pavadinimas });
            }
*/
            knygaEditViewModel.zanrasList = selectListItemsZ;
            knygaEditViewModel.kalbaList = selectListItemsK;
        }
    }
}