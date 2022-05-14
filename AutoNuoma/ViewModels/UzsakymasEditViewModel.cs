using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AutoNuoma.ViewModels
{
    public class UzsakymasEditViewModel
    {
        [DisplayName("id")]
        [Required]
        public int id { get; set; }
        [DisplayName("uzsakymo_data")]
        [Required]
        public DateTime uzsakymo_data { get; set; }
        [DisplayName("uzsakymo_busena")]
        [Required]
        public string uzsakymo_busena { get; set; }
        [DisplayName("pristatymo_data")]
        [Required]
        public DateTime pristatymo_data { get; set; }
        [DisplayName("uzsakovas")]
        [Required]
        public int uzsakovas { get; set; }
        [DisplayName("uzsakymo_kodas")]
        [Required]
        public int uzsakymo_kodas { get; set; }
        [DisplayName("mokejimo_data")]
        [Required]
        public DateTime mokejimo_data { get; set; }
        [DisplayName("kaina")]
        [Required]
        public double kaina { get; set; }
    }
}