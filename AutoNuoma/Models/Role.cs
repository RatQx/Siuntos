using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AutoNuoma.Models
{
    public class Role
    {
        //   [DisplayName("ID")]
        public int id_roles { get; set; }
        //  [DisplayName("Rusis")]
        //  [Required]
        public string pavadinimas { get; set; }
    }
}