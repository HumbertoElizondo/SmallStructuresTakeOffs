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

        [Display(Name = "SqRing #4 (ea)")]
        public int SqRingRebEa { get; set; }

        [Display(Name = "VertL's #4 (ea)")]
        public int VertLsRebEa { get; set; }

        [Display(Name = "VertL's #4 (ft)")]
        public decimal VertLsRebL { get; set; }

        [Display(Name = "SqRing #4 (ft)")]
        public decimal SqRingRebL { get; set; }

        [Display(Name = "Pour Apron (cy)")]
        public decimal PourApron { get; set; }

        [Display(Name = "Purch Concrete (cy)")]
        public decimal PurchConcrete { get; set; }

        [Display(Name = "Reb #3 (Lng-ea)")]
        public int RebNo3LengthEa { get; set; }

        [Display(Name = "Reb #3 (Lng-ft)")]
        public decimal RebNo3Length  { get; set; }

        [Display(Name = "Reb #3 (Trn-ea)")]
        public int RebNo3TrnLengthEa { get; set; }

        [Display(Name = "Reb #3 (Trn-ft)")]
        public decimal RebNo3TrnLength { get; set; }

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

        [Display(Name = "Reb #4 (Lng-ft)")]
        public decimal RebNo4StgthL { get; set; }

        [Display(Name = "Reb #4 (Lng-ea)")]
        public int RebNo4StgthEa { get; set; }

        [Display(Name = "Reb #4 (Trn-ft)")]
        public decimal RebNo4TrnL { get; set; }

        [Display(Name = "Reb #4 (Trn-ea)")]
        public int RebNo4TrnEa { get; set; }

        public IList<CBreinforcement> CBreinforcementsVM { get; set; }

        public IList<HWreinforcement> HWreinforcementsVM { get; set; }


        public decimal HeightCB { get; set; }



        //public decimal Concrete => PourApron + ResVMPourBottomCY + ResVMPourWallCY;
    }
}
