using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AutoNuoma.Models
{
    public class Siunta
    {
        [DisplayName("ID")]
        public int id { get; set; }

        [DisplayName("uzsakymo_kodas")]
        [Required]
        public int uzsakymo_kodas { get; set; }

        [DisplayName("Siuntos būsena")]
        [Required]
        public string siuntos_busena { get; set; }

        [DisplayName("Siuntėjo adresas")]
        [Required]
        public string siuntejo_adresas { get; set; }

        [DisplayName("Gavėjo adresas")]
        [Required]
        public string gavejo_adresas { get; set; }

        [DisplayName("Gavėjo numeris")]
        [Required]
        public string gavejo_numeris { get; set; }

        [DisplayName("Gavėjo el. paštas")]
        [Required]
        public string gavejo_el_pastas { get; set; }

        [DisplayName("Siuntos svoris")]
        [Required]
        public double siuntos_svoris { get; set; }
    }
}