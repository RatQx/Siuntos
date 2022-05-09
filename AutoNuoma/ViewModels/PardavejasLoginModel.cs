using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoNuoma.Models;

namespace AutoNuoma.ViewModels
{
    public class PardavejasLoginModel
    {
        [DisplayName("prisijungimo vardas")]
        [Required]
        public string prisijungimo_vardas { get; set; }
        [DisplayName("slaptazodis")]
        [Required]
        public string slaptazodis { get; set; }
    }
}