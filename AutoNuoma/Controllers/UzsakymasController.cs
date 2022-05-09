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
    public class UzsakymasController : Controller
    {
        UzsakymasRepository uzsakymasRepository = new UzsakymasRepository();
        public ActionResult Index()
        {
            //gražinamas uzsakymo sarašo vaizdas
            return View(uzsakymasRepository.GetUzsakymas());
        }
        public ActionResult Meniu()
        {
            return View("Meniu");
        }
    }
}