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
    public class AdministratoriusController : Controller
    {
        //AdministratoriusRepository administratoriusRepository = new AdministratoriusRepository();
        public ActionResult Login()
        {
            return View();
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Login(Administratorius admin)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        string password = administratoriusRepository.getUsername(admin.prisijungimo_vardas);
        //        if (password != null)
        //        {
        //            if (password == admin.slaptazodis)
        //            {
        //                return RedirectToAction("Meniu", "Administratorius");
        //            }
        //            else
        //            {
        //                ModelState.AddModelError("", "invalid Username or Password");
        //                return View();
        //            }
        //        }
        //        else
        //        {
        //            ModelState.AddModelError("", "invalid Username or Password");
        //            return View();
        //        }
        //    }
        //    else
        //    {
        //        return View(admin);
        //    }

        //}
        
        
        public ActionResult Meniu()
        {
            return View("Meniu");
        }
    }
    
}