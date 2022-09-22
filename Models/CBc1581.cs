using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmallStructuresTakeOffs.Enums;

namespace SmallStructuresTakeOffs.Models
{
    public class CBc1581 : CatchBasin
    {
        public override decimal CBLength { get; set; } = 3m;
        //{
        //    get => 3m; 
        //    set
        //    {
        //        decimal L = 3m;
        //    }
        //}
        public override decimal CBWidth { get; set; } = 2m;
        //{ get => 2m; set { decimal W = 2m; } }
        public override decimal CBBaseThickness { get; set; } = .5m;
        //{ get => .5m; set { decimal T = .5m; } }
        public override decimal CBWallThickness { get; set; } = .5m;
        //{ get => .5m; set { decimal T = .5m; } }

        public CBc1581Slope CBc1581Slps { get; set; }


        public override int CBVertBars { get => 14; set { decimal Bars = 14m; } }

        public override decimal CBSqRingL { get => (CBLength + CBWidth + 1m/3m) * 2 + 1; set { decimal R = (CBLength + CBWidth + 1m/3m) * 2 + 1; } }

        public override ICollection<CBreinforcement> CBreinforcements
        {
            get => this.theReinforcements(); set => this.theReinforcements();
        }

        public override ICollection<CBreinforcement> theReinforcements()
        {
            IList<CBreinforcement> cbReinf = new List<CBreinforcement>();

            switch (this.CBc1581Slps)
            {
                case CBc1581Slope.Slope10_1:
                    {
                        decimal A = 3.6m / 12m;

                        cbReinf.Add(
                        new CBreinforcement
                        {
                            CBId = CatchBasinId,
                            CBRebarNom = RebarNomination.No4,
                            CBreinfCode = "rb01",
                            CBreinfQty = 14,
                            CBreinfLength = CBHeight + A  + CBBaseThickness - (5m / 12m),
                            CBreinfShape = "Straight, Vertical",
                            TotalLength = (14m) * (CBHeight + A + CBBaseThickness - (5m / 12m)),
                            TotalWeight = (14m) * (CBHeight + A + CBBaseThickness - (5m / 12m)) * .668m
                        });
                        cbReinf.Add(
                            new CBreinforcement
                            {
                                CBId = CatchBasinId,
                                CBRebarNom = RebarNomination.No4,
                                CBreinfCode = "rb02",
                                CBreinfQty = (int)Math.Ceiling(CBHeight + A) + 1,
                                CBreinfLength = 2m * (CBLength + CBWidth + 2m * (5m / 12m)) + 2m,
                                CBreinfShape = "Square Ring Shape, 2'-Overlap",
                                TotalLength = ((int)Math.Ceiling(CBHeight + A) + 1) * (2m * (CBLength + CBWidth + 2m * (5m / 12m)) + 2),
                                TotalWeight = ((int)Math.Ceiling(CBHeight + A) + 1) * (2m * (CBLength + CBWidth + 2m * (5m / 12m)) + 2) * .668m
                            });

                        return cbReinf;


                    }
                case CBc1581Slope.Slope8_1:
                    {
                        decimal A = 4.5m / 12m;

                        cbReinf.Add(
                            new CBreinforcement
                            {
                                CBId = CatchBasinId,
                                CBRebarNom = RebarNomination.No4,
                                CBreinfCode = "rb01",
                                CBreinfQty = 14,
                                CBreinfLength = CBHeight + A + CBBaseThickness - (5m / 12m),
                                CBreinfShape = "Straight, Vertical",
                                TotalLength = (14m) * (CBHeight + A + CBBaseThickness - (5m / 12m)),
                                TotalWeight = (14m) * (CBHeight + A + CBBaseThickness - (5m / 12m)) * .668m
                            });
                        cbReinf.Add(
                            new CBreinforcement
                            {
                                CBId = CatchBasinId,
                                CBRebarNom = RebarNomination.No4,
                                CBreinfCode = "rb02",
                                CBreinfQty = (int)Math.Ceiling(CBHeight + A) + 1,
                                CBreinfLength = 2m * (CBLength + CBWidth + 2m * (5m / 12m)) + 2m,
                                CBreinfShape = "Square Ring Shape, 2'-Overlap",
                                TotalLength = ((int)Math.Ceiling(CBHeight + A) + 1) * (2m * (CBLength + CBWidth + 2m * (5m / 12m)) + 2),
                                TotalWeight = ((int)Math.Ceiling(CBHeight + A) + 1) * (2m * (CBLength + CBWidth + 2m * (5m / 12m)) + 2) * .668m
                            });

                        return cbReinf;

                    }
                case CBc1581Slope.Slope6_1:
                    {
                        decimal A = 6m / 12m;

                        cbReinf.Add(
                            new CBreinforcement
                            {
                                CBId = CatchBasinId,
                                CBRebarNom = RebarNomination.No4,
                                CBreinfCode = "rb01",
                                CBreinfQty = 14,
                                CBreinfLength = CBHeight + A + CBBaseThickness - (5m / 12m),
                                CBreinfShape = "Straight, Vertical",
                                TotalLength = (14m) * (CBHeight + A + CBBaseThickness - (5m / 12m)),
                                TotalWeight = (14m) * (CBHeight + A + CBBaseThickness - (5m / 12m)) * .668m
                            });
                        cbReinf.Add(
                            new CBreinforcement
                            {
                                CBId = CatchBasinId,
                                CBRebarNom = RebarNomination.No4,
                                CBreinfCode = "rb02",
                                CBreinfQty = (int)Math.Ceiling(CBHeight + A) + 1,
                                CBreinfLength = 2m * (CBLength + CBWidth + 2m * (5m / 12m)) + 2m,
                                CBreinfShape = "Square Ring Shape, 2'-Overlap",
                                TotalLength = ((int)Math.Ceiling(CBHeight + A) + 1) * (2m * (CBLength + CBWidth + 2m * (5m / 12m)) + 2),
                                TotalWeight = ((int)Math.Ceiling(CBHeight + A) + 1) * (2m * (CBLength + CBWidth + 2m * (5m / 12m)) + 2) * .668m
                            });

                        return cbReinf;

                    }
                case CBc1581Slope.Slope4_1:
                    {
                        decimal A = 9m / 12m;

                        cbReinf.Add(
                            new CBreinforcement
                            {
                                CBId = CatchBasinId,
                                CBRebarNom = RebarNomination.No4,
                                CBreinfCode = "rb01",
                                CBreinfQty = 14,
                                CBreinfLength = CBHeight + A + CBBaseThickness - (5m / 12m),
                                CBreinfShape = "Straight, Vertical",
                                TotalLength = (14m) * (CBHeight + A + CBBaseThickness - (5m / 12m)),
                                TotalWeight = (14m) * (CBHeight + A + CBBaseThickness - (5m / 12m)) * .668m
                            });
                        cbReinf.Add(
                            new CBreinforcement
                            {
                                CBId = CatchBasinId,
                                CBRebarNom = RebarNomination.No4,
                                CBreinfCode = "rb02",
                                CBreinfQty = (int)Math.Ceiling(CBHeight + A) + 1,
                                CBreinfLength = 2m * (CBLength + CBWidth + 2m * (5m / 12m)) + 2m,
                                CBreinfShape = "Square Ring Shape, 2'-Overlap",
                                TotalLength = ((int)Math.Ceiling(CBHeight + A) + 1) * (2m * (CBLength + CBWidth + 2m * (5m / 12m)) + 2),
                                TotalWeight = ((int)Math.Ceiling(CBHeight + A) + 1) * (2m * (CBLength + CBWidth + 2m * (5m / 12m)) + 2) * .668m
                            });

                        return cbReinf;

                    }
                default: { return null; }
            }
        }


        public override decimal PourBottom(decimal CBHeight) 
        {
            switch (this.CBc1581Slps)
            {
                case CBc1581Slope.Slope10_1:
                {
                        decimal A = 3.6m / 12m;
                        if (CBHeight <= 8)
                        {
                            return
                                ((CBLength + 2M * CBWallThickness) * (CBWidth + 2M * CBWallThickness) * CBBaseThickness + /*Base*/
                                2M * (CBLength + 2M * CBWallThickness + CBWidth) * CBWallThickness * (CBHeight + A/2m) /*Walls*/
                            ) / 27M; /*CY*/
                        }
                        else
                        {

                            return
                                (
                                    (CBLength + 2M * (CBWallThickness + 2m / 12m)) * (CBWidth + 2M * (CBWallThickness + 2m / 12m)) * (CBWallThickness + 2m / 12m) + /*Base*/
                                    2M * ((CBLength + 2M * (CBWallThickness + 2m / 12m)) + CBWidth) * (CBWallThickness + 2m / 12m) * (CBHeight + A / 2m) /*Walls*/
                                ) / 27M; /*CY*/
                        }
                    }
                case CBc1581Slope.Slope8_1:
                {
                    decimal A = 4.5m / 12m;
                        if (CBHeight <= 8)
                        {
                            return
                                ((CBLength + 2M * CBWallThickness) * (CBWidth + 2M * CBWallThickness) * CBBaseThickness + /*Base*/
                                2M * (CBLength + 2M * CBWallThickness + CBWidth) * CBWallThickness * (CBHeight + A / 2m) /*Walls*/
                            ) / 27M; /*CY*/
                        }
                        else
                        {

                            return
                                (
                                    (CBLength + 2M * (CBWallThickness + 2m / 12m)) * (CBWidth + 2M * (CBWallThickness + 2m / 12m)) * (CBWallThickness + 2m / 12m) + /*Base*/
                                    2M * ((CBLength + 2M * (CBWallThickness + 2m / 12m)) + CBWidth) * (CBWallThickness + 2m / 12m) * (CBHeight + A / 2m) /*Walls*/
                                ) / 27M; /*CY*/
                        }
                    }
                case CBc1581Slope.Slope6_1:
                {
                    decimal A = 6m / 12m;

                        if (CBHeight <= 8)
                        {
                            return
                                ((CBLength + 2M * CBWallThickness) * (CBWidth + 2M * CBWallThickness) * CBBaseThickness + /*Base*/
                                2M * (CBLength + 2M * CBWallThickness + CBWidth) * CBWallThickness * (CBHeight + A / 2m) /*Walls*/
                            ) / 27M; /*CY*/
                        }
                        else
                        {

                            return
                                (
                                    (CBLength + 2M * (CBWallThickness + 2m / 12m)) * (CBWidth + 2M * (CBWallThickness + 2m / 12m)) * (CBWallThickness + 2m / 12m) + /*Base*/
                                    2M * ((CBLength + 2M * (CBWallThickness + 2m / 12m)) + CBWidth) * (CBWallThickness + 2m / 12m) * (CBHeight + A / 2m) /*Walls*/
                                ) / 27M; /*CY*/
                        }
                    }
                case CBc1581Slope.Slope4_1:
                {
                    decimal A = 9m / 12m;

                        if (CBHeight <= 8)
                        {
                            return
                                ((CBLength + 2M * CBWallThickness) * (CBWidth + 2M * CBWallThickness) * CBBaseThickness  /*Base*/
                                + 2M * (CBLength + 2M * CBWallThickness + CBWidth) * CBWallThickness * (CBHeight + A / 2m) /*Walls*/
                                ) / 27M;
                            /*CY*/
                        }
                        else
                        {

                            return
                                (
                                    (CBLength + 2M * (CBWallThickness + 2m / 12m)) * (CBWidth + 2M * (CBWallThickness + 2m / 12m)) * (CBWallThickness + 2m / 12m) + /*Base*/
                                    2M * ((CBLength + 2M * (CBWallThickness + 2m / 12m)) + CBWidth) * (CBWallThickness + 2m / 12m) * (CBHeight + A / 2m) /*Walls*/
                                ) / 27M; /*CY*/
                        }
                }
                default: { return 0; }
            }
        }
        public override decimal PourTop()
        {
            return 0M; /*No Tops in C-15.80*/
        }
        public override decimal PourApron()

        {
            return ((11m * 10m * 2m/12m  -
                3m * 4M * 2m/12m +
                (2m * (11m + 10M) + 2m * (4m + 3m)) * (((3m + 9m) * (6m / 2m) )/ 144))) / 27m;

            //return (((2M * 4M + 3M) * 2M + (2M * 4M + 2M - .5M * 2M) * 2M) * (0.25M + 0.5M) * .5M / 2M) / 27M + /* Outside Perfimeter CY*/
            //    ((2M * (4M + 3M) * (0.25M + 0.5M) * .5M / 2M))/ 27M + /* Inside Perfimeter CY*/
            //    ((11M * 10M - 4M * 3M) * 2M / 12M) / 27M; /*Apron*/
        }
        public override decimal PurchConcrete(decimal CBHeight)
        {
            return (PourApron()  + PourTop() + PourBottom(CBHeight)) * 1.25M;
        }
        public override decimal FabForms(decimal CBHeight)
        {
            switch (this.CBc1581Slps)
            {
                case CBc1581Slope.Slope10_1:
                    {
                        decimal A = 3.6m / 12m;

                        if (CBHeight <= 8)
                        {
                            return
                                2M * (CBLength + 2M * CBWallThickness + CBWidth) * (CBHeight + A + CBBaseThickness) + /*OutsideWalls*/
                                2M * (CBLength + CBWidth) * (CBHeight + A); /*InsideWalls*/

                        }
                        else
                        {
                            return
                                2M * (CBLength + 2M * (CBWallThickness + 2m/12m) + CBWidth) * (CBHeight + A + CBBaseThickness) + /*OutsideWalls*/
                                2M * (CBLength + CBWidth) * (CBHeight + A); /*InsideWalls*/
                        }
                    }
                case CBc1581Slope.Slope8_1:
                    {
                        decimal A = 4.5m / 12m;

                        if (CBHeight <= 8)
                        {
                            return
                                2M * (CBLength + 2M * CBWallThickness + CBWidth) * (CBHeight + A + CBBaseThickness) + /*OutsideWalls*/
                                2M * (CBLength + CBWidth) * (CBHeight + A); /*InsideWalls*/

                        }
                        else
                        {
                            return
                                2M * (CBLength + 2M * (CBWallThickness + 2m / 12m) + CBWidth) * (CBHeight + A + CBBaseThickness) + /*OutsideWalls*/
                                2M * (CBLength + CBWidth) * (CBHeight + A); /*InsideWalls*/
                        }
                    }
                case CBc1581Slope.Slope6_1:
                    {
                        decimal A = 6m / 12m;

                        if (CBHeight <= 8)
                        {
                            return
                                2M * (CBLength + 2M * CBWallThickness + CBWidth) * (CBHeight + A + CBBaseThickness) + /*OutsideWalls*/
                                2M * (CBLength + CBWidth) * (CBHeight + A); /*InsideWalls*/

                        }
                        else
                        {
                            return
                                2M * (CBLength + 2M * (CBWallThickness + 2m / 12m) + CBWidth) * (CBHeight + A + CBBaseThickness) + /*OutsideWalls*/
                                2M * (CBLength + CBWidth) * (CBHeight + A); /*InsideWalls*/
                        }
                    }
                case CBc1581Slope.Slope4_1:
                    {
                        decimal A = 9m / 12m;

                        if (CBHeight <= 8)
                        {
                            return
                                2M * (CBLength + 2M * CBWallThickness + CBWidth) * (CBHeight + A + CBBaseThickness) + /*OutsideWalls*/
                                2M * (CBLength + CBWidth) * (CBHeight + A); /*InsideWalls*/

                        }
                        else
                        {
                            return
                                2M * (CBLength + 2M * (CBWallThickness + 2m / 12m) + CBWidth) * (CBHeight + A + CBBaseThickness) + /*OutsideWalls*/
                                2M * (CBLength + CBWidth) * (CBHeight + A); /*InsideWalls*/
                        }
                    }
                default: return 0;
            }
        }
        public override decimal InstBottomForms(decimal CBHeight)
        {
            switch (this.CBc1581Slps)
            {
                case CBc1581Slope.Slope10_1:
                    {
                        decimal A = 3.6m / 12m;

                        if (CBHeight <= 8)
                        {
                            return
                                2M * (CBLength + 2M * CBWallThickness + CBWidth) * (CBHeight + A + CBBaseThickness) + /*OutsideWalls*/
                                2M * (CBLength + CBWidth) * (CBHeight + A); /*InsideWalls*/

                        }
                        else
                        {
                            return
                                2M * (CBLength + 2M * (CBWallThickness + 2m / 12m) + CBWidth) * (CBHeight + A + CBBaseThickness) + /*OutsideWalls*/
                                2M * (CBLength + CBWidth) * (CBHeight + A); /*InsideWalls*/
                        }
                    }
                case CBc1581Slope.Slope8_1:
                    {
                        decimal A = 4.5m / 12m;

                        if (CBHeight <= 8)
                        {
                            return
                                2M * (CBLength + 2M * CBWallThickness + CBWidth) * (CBHeight + A + CBBaseThickness) + /*OutsideWalls*/
                                2M * (CBLength + CBWidth) * (CBHeight + A); /*InsideWalls*/

                        }
                        else
                        {
                            return
                                2M * (CBLength + 2M * (CBWallThickness + 2m / 12m) + CBWidth) * (CBHeight + A + CBBaseThickness) + /*OutsideWalls*/
                                2M * (CBLength + CBWidth) * (CBHeight + A); /*InsideWalls*/
                        }
                    }
                case CBc1581Slope.Slope6_1:
                    {
                        decimal A = 6m / 12m;

                        if (CBHeight <= 8)
                        {
                            return
                                2M * (CBLength + 2M * CBWallThickness + CBWidth) * (CBHeight + A + CBBaseThickness) + /*OutsideWalls*/
                                2M * (CBLength + CBWidth) * (CBHeight + A); /*InsideWalls*/

                        }
                        else
                        {
                            return
                                2M * (CBLength + 2M * (CBWallThickness + 2m / 12m) + CBWidth) * (CBHeight + A + CBBaseThickness) + /*OutsideWalls*/
                                2M * (CBLength + CBWidth) * (CBHeight + A); /*InsideWalls*/
                        }
                    }
                case CBc1581Slope.Slope4_1:
                    {
                        decimal A = 9m / 12m;

                        if (CBHeight <= 8)
                        {
                            return
                                2M * (CBLength + 2M * CBWallThickness + CBWidth) * (CBHeight + A + CBBaseThickness) + /*OutsideWalls*/
                                2M * (CBLength + CBWidth) * (CBHeight + A); /*InsideWalls*/

                        }
                        else
                        {
                            return
                                2M * (CBLength + 2M * (CBWallThickness + 2m / 12m) + CBWidth) * (CBHeight + A + CBBaseThickness) + /*OutsideWalls*/
                                2M * (CBLength + CBWidth) * (CBHeight + A); /*InsideWalls*/
                        }
                    }
                default: return 0;
            }
        }
        public override decimal InstTopForms()
        {
            return 0M; /*No Tops in C-15.80*/
        }
        public override decimal RebVertLength(decimal CBHeight)
        {
            return CBHeight + CBBaseThickness  - (3m/12m + 1.5m/12m);
        }
        public override int RebSqRingEa (decimal CBHeight)
        {
            return (int)(Math.Ceiling(CBHeight + CBBaseThickness))+1;
        }

        public override decimal CBRebarTakeOfflb(decimal CBHeight)
        {
            return
                0;
            //throw new NotImplementedException();
        }
    }
}
