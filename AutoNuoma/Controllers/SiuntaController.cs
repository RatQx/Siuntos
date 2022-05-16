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
    public class SiuntaController : Controller
    {
        SiuntaRepository siuntaRepository = new SiuntaRepository();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            Siunta siunta = new Siunta();
            return View(siunta);
        }

        [HttpPost]
        public ActionResult Create(Siunta collection)
        {
            try
            {
                siuntaRepository.addSiunta(collection);

                return RedirectToAction("Pay", "Uzsakymas", new { area = "" });
            }
            catch
            {
                return View(collection);
            }
        }

        public ActionResult Edit(string id)
        {
            return View(siuntaRepository.GetSiunta(id));
        }

        // POST: Test/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Siunta collection)
        {
            try
            {
                siuntaRepository.updateSiunta(collection);

                return RedirectToAction("Index");
            }
            catch
            {
                return View(collection);
            }
        }
    }
}
