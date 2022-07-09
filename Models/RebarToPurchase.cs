using System;
using System.Collections.Generic;
using System.Text;
using SmallStructuresTakeOffs.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmallStructuresTakeOffs.Models
{
    public class RebarToPurchase
    {
        public int RebarToPurchaseId { get; set; }

        [Display(Name = "Reb Nom")]
        public RebarNomination RebarToPurchaseNomination { get; set; }

        [Display(Name = "Quantity")]
        public int RebarToPurchaseQuantity { get; set; }

        [Display(Name = "Req No")]
        public int RebarRequest { get; set;  }

        public decimal  RebarNomLengths   { get; set; }

    }
}






    