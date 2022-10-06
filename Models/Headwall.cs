using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks; 



namespace SmallStructuresTakeOffs.Models
{
    public abstract class Headwall
    {
        public int HeadwallId { get; set; }
        [ForeignKey("Project")]
        public long HWProjId { get; set; }
        public Project Project { get; set; }

        public int ThisHeadwallId { get; set; } // Seeded Information for Headwalls
        public string HWcode { get; set; }
        public abstract decimal PourBase();
        public abstract decimal PourWall();
        public abstract decimal FormBase();
        public abstract decimal FormWall();
        public abstract decimal FormFab();
    }
}
