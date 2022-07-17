using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmallStructuresTakeOffs.Models
{
    public class ResultsVM
    {
        public int ResVMId { get; set; }
        public int ResVMHWStrId { get; set; }

        [Display(Name = "HW Code")]
        public string ResVMHWcode { get; set; }

        [Display(Name = "HW Description")]
        public string ResVMHWDescription { get; set; }

        [Display(Name = "Pour Bottom (cy)")]
        public decimal ResVMPourBottomCY { get; set; }

        [Display(Name = "Pour Top (cy)")]
        public decimal ResVMPourWallCY { get; set; }

        [Display(Name = "Form Bottom (sf)")]
        public decimal ResVMFormBase { get; set; }

        [Display(Name = "Form Top (sf)")]
        public decimal ResVMFormWall { get; set; }

        [Display(Name = "Form Fab (sf)")]
        public decimal ResVMFormFab { get; set; }

        [Display(Name = "Reb#4 F&I (lb)")]
        public decimal ResVMRebNo4Req { get; set; }

        [Display(Name = "Reb#4 Buy (lb)")]
        public decimal ResVMRebNo4Purch { get; set; }

        [Display(Name = "Sq Ring (ea)")]
        public int SqRingRebEa { get; set; }

        [Display(Name = "Vert L's (ea)")]
        public int VertLsRebEa { get; set; }

        [Display(Name = "Vert L's (ft)")]
        public decimal VertLsRebL { get; set; }

        [Display(Name = "Sq Ring (ft)")]
        public decimal SqRingRebL { get; set; }

        [Display(Name = "Pour Apron (cy)")]
        public decimal PourApron { get; set; }

        [Display(Name = "Purch Concr(cy)")]
        public decimal PurchConcrete { get; set; }

        public int RebNo3LengthEa { get; set; }
        public decimal RebNo3Length  { get; set; }

        public int RebNo3WidthEa { get; set; }
        public decimal RebNo3Width { get; set; }

        public int RebNo4DowelEa { get; set; }
        public decimal RebNo4DowelLength { get; set; }

        [Display(Name = "Reb#3 F&I (lb)")]
        public decimal ResVMRebNo3Req { get; set; }

        [Display(Name = "Reb#3 Buy (lb)")]
        public decimal ResVMRebNo3Purch { get; set; }

        [Display(Name = "Reb Buy (lb)")]
        public decimal ResVMRebPurch { get; set;  }

        [Display(Name = "Reb F&I (lb)")]
        public decimal ResVMRebFandI { get; set; }



        //public decimal Concrete => PourApron + ResVMPourBottomCY + ResVMPourWallCY;
    }
}
