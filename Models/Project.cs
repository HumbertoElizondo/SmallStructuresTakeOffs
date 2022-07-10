using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmallStructuresTakeOffs.Models
{
    public class Project
    {
        public long ProjectId { get; set; }
        public string ProjectCode { get; set; }
        public string ProjectName { get; set; }
        public ICollection<RebarRequest> RebarRequests { get; set; }
        public ICollection<CatchBasin> CatchBasins { get; set; }
    }
}
