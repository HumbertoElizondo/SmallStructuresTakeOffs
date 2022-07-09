using SmallStructuresTakeOffs.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace SmallStructuresTakeOffs
{
    public class RebarRequest
    {
        public int RebarRequestId { get; set; }

        [Display(Name = "REBAR SIZE")]
        public RebarNomination RebarRequestNomination { get; set; }

        [Display(Name = "REBAR QTY")]
        public int RebarRequestQty { get; set; }

        [Display(Name = "REBAR LENGTH")]
        public decimal RebarRequestLength { get; set; }
        public long RebReqProjId { get; set; }
        public string Structure { get; set; }

        //[NotMapped]
        //public RebarLengths RebLength { get; set; }

        //public string RebLength { get; set; }

        [Display(Name = "REBAR SHAPE")]
        public string RebReqDescription { get; set; }

        public ICollection<RebarWasting> RebarWastings { get; set; }

    }
}
