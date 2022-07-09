using System;
using System.Collections.Generic;
using System.Text;
using SmallStructuresTakeOffs.Models;

namespace SmallStructuresTakeOffs
{
    public class RebarFabrication
    {
        public int RebarFabricationId { get; set; }
        public int RebarFabricationReqNo { get; set; }
        public int RebarFabricationQuantity { get; set; }
        public decimal RebarFabricationLength { get; set; }
        public RebarNomination RebarFabricationNomination { get; set; }
        public string RebFabStructure { get; set; }
        public int RebarWastedQuantity { get; set; }
        public int RebarWastedReqNo { get; set; }
        public decimal RebarWastedLength { get; set; }
        public FabricationSource Source { get; set; }
        //public decimal RebFabWeight { get; set; }
    }

    public enum FabricationSource
    { 
        FullStick,
        Waste
    }
}
