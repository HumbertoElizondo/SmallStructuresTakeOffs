using System;
using System.Collections.Generic;
using System.Text;
using SmallStructuresTakeOffs.Models;

namespace SmallStructuresTakeOffs
{
    public class RebarWasting
    {
        public int RebarWastingId { get; set; }
        public RebarNomination RebarWastingNomination { get; set; }
        public int RebarWastingQuantity { get; set; }
        public decimal RebarWastingLength { get; set; }
        public int RebarWastingReqNo { get; set; }

        public bool IsItAvailable { get; set;  }

        public int ReqNo { get; set; }
        public RebarRequest RebarRequest { get; set; }
    }
}
