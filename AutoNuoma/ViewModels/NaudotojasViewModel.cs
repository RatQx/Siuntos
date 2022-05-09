using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace AutoNuoma.Models
{
    public class NaudotojasViewModel
    {

        [DisplayName("vardas")]
        public string vardas { get; set; }

        [DisplayName("pavardė")]
        public string pavarde { get; set; }

        [DisplayName("prisijungimo vardas")]
        public string prisijungimo_vardas { get; set; }

        [DisplayName("elektroninis paštas")]
        public string el_pastas { get; set; }
        [DisplayName("slaptazodis")]
        public string slaptazodis { get; set; }
        [DisplayName("telefono numeris")]
        public int telefono_numeris { get; set; }

        [DisplayName("gyvenamosios vietos adresas")]
        public string gyvenamosios_vietos_adresas { get; set; }
        [DisplayName("gimimo data")]
        public DateTime gimimo_data { get; set; }
        [DisplayName("lytis")]
        public int lytis { get; set; }
       
    }
}