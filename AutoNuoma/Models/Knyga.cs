using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AutoNuoma.Models
{
    public class Knyga
    {

     //   [DisplayName("pavadinimas")]
      //  [MaxLength(30)]
     //   [Required]
        public string pavadinimas { get; set; }
    //    [DisplayName("autorius")]
   //     [MaxLength(30)]
   //     [Required]
        public string autorius { get; set; }
     //   [DisplayName("ISBN")]
      //  [MaxLength(20)]
   //     [Required]
        public string ISBN { get; set; }
   //     [DisplayName("kaina")]
  //      [Required]
        public double kaina { get; set; }
      //  [DisplayName("išleidimo metai")]
     //   [Required]
        public int isleidimo_metai { get; set; }
     //   [DisplayName("puslapių skaičius")]
     //   [Required]
        public int puslapiu_skaicius { get; set; }
     //   [DisplayName("leidykla")]
    //    [Required]
        public string leidykla { get; set; }
      //  [DisplayName("kiekis")]
    //    [Required]
        public int kiekis { get; set; }
        public int iskeliama_saraso_pradzia { get; set; }
  //      [DisplayName("kalba")]
 //      [Required]
        public int kalba { get; set; }
    //    [DisplayName("žanras")]
   //     [Required]
        public int zanras { get; set; }

    }
}