using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AutoNuoma.Models
{
    public class Darbuotojas
    {
        [DisplayName("ID")]
        [MaxLength(10)]
        [Required]
        public string id { get; set; }
        [DisplayName("Vardas")]
        [MaxLength(20)]
        [Required]
        public string vardas { get; set; }
        [DisplayName("Pavardė")]
        [MaxLength(20)]
        [Required]
        public string pavarde { get; set; }
        [DisplayName("Rolė")]
        [MaxLength(20)]
        [Required]
        public string role { get; set; }
        [DisplayName("Data")]        
        public DateTime idarbinimp_data { get; set; }
    }
}