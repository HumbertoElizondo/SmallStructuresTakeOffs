using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmallStructuresTakeOffs.Models
{
    public class CBc1580 : CatchBasin
    {
        //private decimal V = 3m;

        public override decimal CBLength
        {
            get => 3m; 
            set
            {
                decimal L = 3m;
            }
        }
        public override decimal CBWidth { get => 2m; set { decimal W = 2m; } }
        public override decimal CBBaseThickness { get => .5m; set { decimal T = .5m; } }
        public override decimal CBWallThickness { get => .5m; set { decimal T = .5m; } }
        public override int CBVertBars { get => 14; set { decimal Bars = 14m; } }

        public override decimal CBSqRingL { get => 160m/12m; set { decimal R = 160m/12m; } }

        public override decimal PourBottom(decimal CBHeight) {
            if (CBHeight < 8)
            {
                return (
                    (CBLength + 2M * CBWallThickness) * (CBWidth + 2M * CBWallThickness) * CBBaseThickness + /*Base*/
                    2M * (CBLength + 2M * CBWallThickness + CBWidth) * CBWallThickness * CBHeight /*Walls*/
                ) / 27M; /*CY*/
            }
            else
            {

                return ((CBLength + 2M * (8m/12m)) * (CBWidth + 2M * (8m/12m)) * (8m/12m) + /*Base*/
                2M * ((CBLength + 2M * (8m/12m)) + CBWidth) * (8m/12m) * base.CBHeight /*Walls*/
                ) / 27M; /*CY*/
            }
        }
        public override decimal PourTop()
        {
            return 0M; /*No Tops in C-15.80*/
        }
        public override decimal PourApron()
        {
            return (((2M * 4M + 3M) * 2M + (2M * 4M + 2M - .5M * 2M) * 2M) * (0.25M + 0.5M) * .5M / 2M) / 27M + /* Outside Perfimeter CY*/
                ((2M * (4M + 3M) * (0.25M + 0.5M) * .5M / 2M))/ 27M + /* Inside Perfimeter CY*/
                ((11M * 10M - 4M * 3M) * 2M / 12M) / 27M; /*Apron*/
        }
        public override decimal PurchConcrete(decimal CBHeight)
        {
            return (PourApron()  + PourTop() + PourBottom(CBHeight)) * 1.15M;
        }
        public override decimal FabForms(decimal CBHeight)
        { 
            return 2M * (CBLength + 2M *  CBWallThickness + CBWidth + 2M *  CBWallThickness) * (CBHeight + .5M) + /*OutsideWalls*/
                2M * (CBLength + CBWidth) * (CBHeight); /*InsideWalls*/
        }
        public override decimal InstBottomForms(decimal CBHeight)
        {
            return 2M * (CBLength + 2M * 2M * CBWallThickness + CBWidth) * (CBHeight + .5M) + /*OutsideWalls*/
                2M * (CBLength + CBWidth) * (CBHeight); /*InsideWalls*/
        }
        public override decimal InstTopForms()
        {
            return 0M; /*No Tops in C-15.80*/
        }
        public override decimal RebVertLength(decimal CBHeight)
        {
            return CBHeight + .5M;
        }
        public override int RebSqRingEa (decimal CBHeight)
        {
            return (int)(Math.Ceiling(CBHeight))+1;
        }
    }
}
