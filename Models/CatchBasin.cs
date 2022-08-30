using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SmallStructuresTakeOffs.Models
{
    public abstract class CatchBasin
    {
        public int CatchBasinId { get; set; }
        public string CBCode { get; set; }
        public string Description { get; set; }
        public decimal CBHeight { get; set; }
        public abstract decimal CBLength { get; set; } // Interior Front Side of Catch Basin
        public abstract decimal CBWidth { get; set; } // Interior Width Side of Catch Basin
        public abstract decimal CBWallThickness { get; set; } // Thickness of wall
        public abstract decimal CBBaseThickness { get; set; } // Thickness of Floor
        public abstract int CBVertBars { get; set; } //Vertical Rebar qty
        public abstract decimal CBSqRingL { get; set; }
        public decimal CBRebFandI { get; set; }
        public decimal CBRebPurch { get; set; }

        [ForeignKey("Project")]
        public long ProjId { get; set; }
        public Project Project { get; set; }

        public abstract ICollection<CBreinforcement> CBreinforcements { get; set; }

        // Dictionary that all catch basins use
        public Dictionary<string, decimal> WeightDict = new Dictionary<string, decimal>
        {
            {"RebWeightNo2", 0.167M},
            {"RebWeightNo3", 0.376M},
            {"RebWeightNo4", 0.668M},
            {"RebWeightNo5", 1.050M},
        };


        /********** These are The Methods ***************/
        public abstract decimal PourBottom(decimal CBHeight);
        public abstract decimal PourTop();
        public abstract decimal PourApron();
        public abstract decimal PurchConcrete(decimal CBHeight);
        public abstract decimal FabForms(decimal CBHeight);
        public abstract decimal InstBottomForms(decimal CBHeight);
        public abstract decimal InstTopForms();
        public abstract decimal RebVertLength(decimal CBHeight);
        public abstract int RebSqRingEa(decimal CBheight);
        public abstract decimal CBRebarTakeOfflb(decimal CBHeight);
    }
}
