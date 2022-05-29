using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoNuoma.Repos;
using AutoNuoma.Models;
using System.Security.Cryptography;
using System.Text;
using AutoNuoma.ViewModels;

namespace AutoNuoma.Controllers
{
    public class UzsakymasController : Controller
    {
        UzsakymasRepository uzsakymasrepository = new UzsakymasRepository();


        public ActionResult Pay()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Pay(Uzsakymas collection)
        {
            try
            {
                return RedirectToAction("Index", "Home", new { area = "" });
            }
            catch
            {
                return View(collection);
            }
        }

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Check()
        {
            return View(uzsakymasrepository.GetUzsakymas());
        }
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult Check()
        {
            return View(uzsakymasrepository.GetUzsakymus());
        }

        [HttpPost]
        public ActionResult Create(Uzsakymas collection)
        {
            try
            {

                return RedirectToAction("Create","Siunta", new { area = "" });
            }
            catch
            {
                return View(collection);
            }
        }

    }
}