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
    public class KurjerisController : Controller
    {
        SiuntaRepository siuntaRepository = new SiuntaRepository();

        public ActionResult Index()
        {
            return View(siuntaRepository.Select());
        }

        public ActionResult Meniu()
        {
            return View(siuntaRepository.Select());
        }

        public ActionResult Paimti(string kodas)
        {
            siuntaRepository.ChangeBusena(kodas, "Paimtas");

            return View(siuntaRepository.Select());
        }

        public ActionResult Sandelyje(string kodas)
        {
            siuntaRepository.ChangeBusena(kodas, "Sandelyje");

            return View(siuntaRepository.Select());
        }

        public ActionResult Pristatyti(string kodas)
        {
            siuntaRepository.ChangeBusena(kodas, "Pristatyta");

            return View(siuntaRepository.Select());
        }
    }
}