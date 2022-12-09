using SmallStructuresTakeOffs.Enums;
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
        public string HWDescription { get; set; }
        public PipeSet PipeNo { get; set; }

        
        public abstract decimal SD630_I_D { get; set; }
        public abstract decimal SD630_A { get; set; }
        public abstract decimal SD630_B { get; set; }
        public abstract decimal SD630_C { get; set; }
        public abstract decimal SD630_D { get; set; }
        public abstract decimal SD630_E { get; set; }
        public abstract decimal SD630_F { get; set; }
        public abstract decimal SD630_G { get; set; }
        public abstract decimal SD630_L { get; set; }
        public abstract decimal SD630_H { get; set; }
        public abstract decimal SD630_X { get; set; }
        public abstract decimal SD630_Y { get; set; }
        public abstract decimal SD630_Z { get; set; }

        public abstract decimal ConcrCY { get; set; }
        public abstract decimal ReinfLB { get; set; }


        public decimal RebNo4Req { get; set; }
        public decimal RebNo4Purch { get; set; }



        public decimal HWRebFandI { get; set; }
        public decimal HWRebPurch { get; set; }
        public abstract ICollection<HWreinforcement> HWreinforcements { get; set; }
        public abstract ICollection<HWreinforcement> TheReinforcements();
        public abstract decimal PourBase();
        public abstract decimal PourWall();
        public abstract decimal FormBase();
        public abstract decimal FormWall();
        public abstract decimal FormFab();
        //public abstract decimal HWRebarTakeOfflb();

        public abstract decimal EngConcr();
        
        public abstract decimal EngReinf();

    }
}
