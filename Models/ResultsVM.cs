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

        [Display(Name = "PourBase (cy)")]
        public decimal ResVMPourBottomCY { get; set; }

        [Display(Name = "PourWall (cy)")]
        public decimal ResVMPourWallCY { get; set; }

        [Display(Name = "FormBase (sf)")]
        public decimal ResVMFormBase { get; set; }

        [Display(Name = "FormWall (sf)")]
        public decimal ResVMFormWall { get; set; }

        [Display(Name = "FormFab (sf)")]
        public decimal ResVMFormFab { get; set; }

        [Display(Name = "Reb#4 F&I (lb)")]
        public decimal ResVMRebNo4Req { get; set; }

        [Display(Name = "Reb#4 Buy (lb)")]
        public decimal ResVMRebNo4Purch { get; set; }

        [Display(Name = "SqRing (ea)")]
        public int SqRingRebEa { get; set; }

        [Display(Name = "Vert L's (ea)")]
        public int VertLsRebEa { get; set; }

        [Display(Name = "Vert L's (ft)")]
        public decimal VertLsRebL { get; set; }

        [Display(Name = "SqRing (ft)")]
        public decimal SqRingRebL { get; set; }
    }
}
