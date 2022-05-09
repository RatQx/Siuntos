using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AutoNuoma.Models
{
    public class Naudotojas
    {

        [DisplayName("vardas")]
        [Required]
        public string vardas { get; set; }

        [DisplayName("pavardė")]
        [Required]
        public string pavarde { get; set; }
        [DisplayName("prisijungimo vardas")]
        [Required]
        public string prisijungimo_vardas { get; set; }
        [DisplayName("elektroninis paštas")]
        [Required]
        public string el_pastas { get; set; }

        [DisplayName("telefono numeris")]
        [Required]
        public int telefono_numeris { get; set; }

        [DisplayName("gyvenamosios vietos adresas")]
        [Required]
        public string gyvenamosios_vietos_adresas { get; set; }
        [DisplayName("gimimo data")]
        [Required]
        public DateTime gimimo_data { get; set; }
        [DisplayName("lytis")]
        [Required]
        public int lytis { get; set; }
        [DisplayName("slaptazodis")]
        [Required]
        public string slaptazodis { get; set; }
        public int role { get; set; }
    }
}