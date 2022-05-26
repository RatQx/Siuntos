using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoNuoma.Repos;
using AutoNuoma.Models;
using AutoNuoma.ViewModels;
using System.Security.Cryptography;
using System.Text;

namespace AutoNuoma.Controllers
{
    public class SiuntaController : Controller
    {
        SiuntaRepository siuntaRepository = new SiuntaRepository();
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

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            Siunta siunta = new Siunta();
            Uzsakymas uzsakymas = new Uzsakymas();
            return View(siunta);
        }

        [HttpPost]
        public ActionResult Create(Siunta collection, Uzsakymas collection2)
        {
            string uniqCode = GenerateCode(10);
            try
            {
                siuntaRepository.addSiunta(collection, uniqCode);
                uzsakymasrepository.addUzsakymas(collection2, uniqCode);

                return RedirectToAction("Pay", "Uzsakymas", new { area = "" });
            }
            catch
            {
                return View(collection);
            }
        }
        
        public ActionResult Atsiimti()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Atsiimti(Siunta collection)
        {
            try
            {
                string order_id = collection.uzsakymo_kodas;
                siuntaRepository.atsiimtiSiunta(order_id);
                uzsakymasrepository.atsiimtiUzsakymas(order_id);

                return RedirectToAction("Index", "Home", new { area = "" });
            }
            catch
            {
                return View(collection);
            }
        }
        
    }
}
