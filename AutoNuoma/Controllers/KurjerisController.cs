using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoNuoma.Repos;
using AutoNuoma.Models;

namespace AutoNuoma.Controllers
{
    public class KurjerisController : Controller
    {
        DarbuotojasRepository darbuotojasRepository = new DarbuotojasRepository();
        public ActionResult Meniu()
        {
            return View("Meniu");
        }
    }
}