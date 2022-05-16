using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoNuoma.ViewModels
{
    public class SiuntaEditViewModel
    {
        [DisplayName("id")]
        [Required]
        public int id { get; set; }

        [DisplayName("siuntos_busena")]
        [Required]
        public string siuntos_busena { get; set; }

        [DisplayName("siuntos_svoris")]
        [Required]
        public double siuntos_svoris { get; set; }

        [DisplayName("siuntejo_adresas")]
        [Required]
        public string siuntejo_adresas { get; set; }

        [DisplayName("gavejo_numeris")]
        [Required]
        public string gavejo_numeris { get; set; }

        [DisplayName("gavejo_el_pastas")]
        [Required]
        public string gavejo_el_pastas { get; set; }

        [DisplayName("gavejo_adresas")]
        [Required]
        public string gavejo_adresas { get; set; }
    }
}