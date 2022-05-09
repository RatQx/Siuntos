using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutoNuoma.ViewModels
{
    public class ParduotaKnygaViewModel
    {
        [DisplayName("pavadinimas")]
        public string pavadinimas { get; set; }
        [DisplayName("autorius")]
        public string autorius { get; set; }
        [DisplayName("ISBN")]
        public string ISBN { get; set; }
        [DisplayName("kaina")]
        public double kaina { get; set; }
        [DisplayName("išleidimo metai")]
        public int isleidimo_metai { get; set; }
        [DisplayName("puslapių skaičius")]
        public int puslapiu_skaicius { get; set; }
        [DisplayName("leidykla")]
        public string leidykla { get; set; }
        [DisplayName("kiekis")]
        public int kiekis { get; set; }
        [DisplayName("kalba")]
        public string kalba { get; set; }
        [DisplayName("žanras")]
        public string zanras { get; set; }
        [DisplayName("data")]
        public DateTime data { get; set; }

    }
}