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

        public static string GenerateCode(int length)
        {
            string valid = "abcdefghijklmnopqrstuvwxyz";
            StringBuilder sb = new StringBuilder();
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                byte[] uintBuffer = new byte[sizeof(uint)];

                while (length-- > 0)
                {
                    rng.GetBytes(uintBuffer);
                    uint num = BitConverter.ToUInt32(uintBuffer, 0);
                    sb.Append(valid[(int)(num % (uint)valid.Length)]);
                }
            }
            return sb.ToString();
        }

        public ActionResult Pay()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Pay(Uzsakymas collection)
        {
            try
            {
                uzsakymasrepository.updateUzsakymas(collection);

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
            Uzsakymas uzsakymas = new Uzsakymas();
            return View(uzsakymas);
        }

        [HttpPost]
        public ActionResult Create(Uzsakymas collection)
        {
            string uniqCode = GenerateCode(10);
            try
            {
                uzsakymasrepository.addUzsakymas(collection, uniqCode);

                return RedirectToAction("Create","Siunta", new { area = "" });
            }
            catch
            {
                return View(collection);
            }
        }

        public ActionResult Edit(string id)
        {
            return View(uzsakymasrepository.getUzsakymas(id));
        }

        [HttpPost]
        public ActionResult Edit(string id, Uzsakymas collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    uzsakymasrepository.updateUzsakymas(collection);
                }

                return RedirectToAction("Meniu");
            }
            catch
            {
                return View(collection);
            }
        }
    }
}