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
    public class PardavejasController : Controller
    {
        PardavejasRepository pardavejoRepository = new PardavejasRepository();
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Pardavejas pardavejas)
        {
            if (ModelState.IsValid)
            {
                string password = pardavejoRepository.getUsername(pardavejas.prisijungimo_vardas);
                if (password != null)
                {
                    if (password == pardavejas.slaptazodis)
                    {
                        return RedirectToAction("Meniu", "Pardavejas");
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
                return View(pardavejas);
            }

        }


        public ActionResult Meniu()
        {
            return View("Meniu");
        }
    }
}