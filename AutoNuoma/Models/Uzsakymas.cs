using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AutoNuoma.Models
{
    public class Uzsakymas
    {
        [DisplayName("ID")]
        [Required]
        public int id { get; set; }

        [DisplayName("Užsakymo data")]
        [Required]
        public DateTime uzsakymo_data { get; set; }

        [DisplayName("uzsakymo_busena")]
        [Required]
        public string uzsakymo_busena { get; set; }

        [DisplayName("Pristatymo data")]
        [Required]
        public DateTime pristatymo_data { get; set; }

        [DisplayName("Užsakovas")]
        [Required]
        public int uzsakovas { get; set; }

        [DisplayName("Užsakymo kodas")]
        [Required]
        public string uzsakymo_kodas { get; set; }

        [DisplayName("Mokėjimo data")]
        [Required]
        public DateTime mokejimo_data { get; set; }

        [DisplayName("Kaina")]
        [Required]
        public double kaina { get; set; }
    }
}