using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SmallStructuresTakeOffs.Models
{
    public class RebarPresentationVM
    {
        public class RebarRequestsVM
        {
            [Display(Name = "CTRL No")]
            public int RebarRequestVMId { get; set; }

            [Display(Name = "REBAR SIZE")]
            public RebarNomination RebarRequestVMNomination { get; set; }

            [Display(Name = "REBAR QTY")]
            public int RebarRequestVMQty { get; set; }

            [Display(Name = "REBAR LENGTH")]
            public decimal RebarRequestVMLength { get; set; }

            //public long RebReqProjId { get; set; }
            [Display(Name = "STRUCTURE")]
            public string RebarRequestVMStructure { get; set; }

            //[Display(Name = "REBAR SHAPE")]
            //public string RebReqDescription { get; set; }

            //public ICollection<RebarWasting> RebarWastings { get; set; }


        }
        //public IEnumerable<RebarRequest> RebarRequestsVM { get =>  RebarRequestsVM; }
        public IEnumerable<RebarWasting> RebarWastingsVM { get; set; }
        public IEnumerable<RebarFabrication> RebarFabricationsVM { get; set; }

        public class RebarFabricationVM
        {
            [Display(Name = "REBAR SHAPE")]
            public int RebarFabricationVMId { get; set; }

            [Display(Name = "Req.No")]
            public int RebarFabricationVMReqNo { get; set; }

            [Display(Name = "Fab.Qty")]
            public int RebarFabricationVMQuantity { get; set; }

            [Display(Name = "Fab.Length")]
            public decimal RebarFabricationVMLength { get; set; }

            [Display(Name = "Nom")]
            public RebarNomination RebarFabricationVMNomination { get; set; }

            [Display(Name = "Waste.Qty")]
            public int RebarWastedQuantity { get; set; }

            [Display(Name = "Waste.Length")]
            public decimal RebarWastedLength { get; set; }

            [Display(Name = "Source")]
            public FabricationSource RebarFabricationSource { get; set; }

        }

    }
}
