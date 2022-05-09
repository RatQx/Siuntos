using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoNuoma.Repos;
using AutoNuoma.Models;
using System.Net;
using System.Configuration;
using System.Diagnostics;

namespace AutoNuoma.Controllers
{
    public class AnalitikasController : Controller
    {
        AnalitikasRepository analitikasRepository = new AnalitikasRepository();
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Analitikas a)
        {
            if (ModelState.IsValid)
            {
                string password = analitikasRepository.getUsername(a.prisijungimo_vardas);
                if (password != null)
                {
                    if (password == a.slaptazodis)
                    {
                        return RedirectToAction("Meniu", "Analitikas");
                    }
                    else
                    {
                        ModelState.AddModelError("", "invalid Username or Password");
                        return View();
                    }
                }
                else
                {
                    ModelState.AddModelError("", "invalid Username or Password");
                    return View();
                }


            }
            else
            {
                return View(a);
            }

        }


        public ActionResult Meniu()
        {
            return View("Meniu");
        }        
    }
}