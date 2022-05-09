using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AutoNuoma.ViewModels
{
    public class UzsakymaiViewModel
    {
        [DisplayName("uzsakymo_data")]
        [Required]
        public string uzsakymo_data { get; set; }
        [DisplayName("uzsakymo_busena")]
        [Required]
        public string uzsakymo_busena { get; set; }
        [DisplayName("uzsakymo_data")]
        [Required]
        public string pristatymo_data { get; set; }
        [DisplayName("uzsakovas")]
        [Required]
        public string uzsakovas { get; set; }
        [DisplayName("uzsakymo_kodas")]
        [Required]
        public string uzsakymo_kodas { get; set; }
        [DisplayName("mokejimo_data")]
        [Required]
        public string mokejimo_data { get; set; }
        [DisplayName("kaina")]
        [Required]
        public string kaina { get; set; }
    }
}