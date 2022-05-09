using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AutoNuoma.Models
{
    public class Administratorius
    {

        [DisplayName("ID")]
        [MaxLength(10)]
        [Required]
        public int id { get; set; }
        [DisplayName("Vardas")]
        [MaxLength(20)]
        [Required]
        public string vardas { get; set; }
        [DisplayName("Pavardė")]
        [MaxLength(20)]
        [Required]
        public string pavarde { get; set; }
        [DisplayName("Role")]
        [MaxLength(40)]
        [Required]
        public string role { get; set; }
        [DisplayName("Data")]
        [MaxLength(20)]
        [Required]
        public DateTime idarbinimp_data { get; set; }
    }
}