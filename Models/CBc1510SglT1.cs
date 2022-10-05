using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmallStructuresTakeOffs.Enums;

namespace SmallStructuresTakeOffs.Models
{
    public class CBc1510SglT1 : CatchBasin
    {
        public override decimal CBLength { get; set; } = 2m + 11.75m / 12m;
        public override decimal CBWidth { get; set; } = 2m + 2.5m / 12m;
        public override decimal CBBaseThickness { get; set; } = .75m;
        public override decimal CBWallThickness { get; set; } = .5m;
        public override ICollection<CBreinforcement> CBreinforcements
        {
            get => this.TheReinforcements(); set => this.TheReinforcements();
        }
        public CBc1510Confg CBc1510Confgs { get; set; }
        public override ICollection<CBreinforcement> TheReinforcements()
        {
            IList<CBreinforcement> cbReinf = new List<CBreinforcement>();

            switch (this.CBc1510Confgs)
            {
                case CBc1510Confg.Single:
                    {
                        cbReinf.Add(
                            new CBreinforcement
                            {
                                CBId = CatchBasinId,
                                CBRebarNom = RebarNomination.No4,
                                CBreinfCode = "rb01",
                                CBreinfQty = 10,
                                CBreinfLength = CBHeight + CBBaseThickness - (5m / 12m),
                                CBreinfShape = "Straight, Vertical",
                                TotalLength = (10m) * (CBHeight + CBBaseThickness - (5m / 12m)),
                                TotalWeight = (10m) * (CBHeight + CBBaseThickness - (5m / 12m)) * .668m
                            });
                        cbReinf.Add(
                            new CBreinforcement
                            {
                                CBId = CatchBasinId,
                                CBRebarNom = RebarNomination.No4,
                                CBreinfCode = "rb02",
                                CBreinfQty = (int)Math.Ceiling(CBHeight) + 1,
                                CBreinfLength = 2m * (CBLength + CBWidth + (5m / 12m)) + 2,
                                CBreinfShape = "Square Ring Shape, 2'-Overlap",
                                TotalLength = ((int)Math.Ceiling(CBHeight) + 1) * (2m * (CBLength + CBWidth + (5m / 12m)) + 2),
                                TotalWeight = ((int)Math.Ceiling(CBHeight) + 1) * (2m * (CBLength + CBWidth + (5m / 12m)) + 2) * .668m
                            });
                        cbReinf.Add(
                            new CBreinforcement
                            {
                                CBId = CatchBasinId,
                                CBRebarNom = RebarNomination.No3,
                                CBreinfCode = "rb03",
                                CBreinfQty = 8,
                                CBreinfLength = 2m,
                                CBreinfShape = "L Shape, 6\" x 18\", at Curb",
                                TotalLength = (8m) * (2m),
                                TotalWeight = (8m) * (2m) * .376m
                            });
                        cbReinf.Add(
                        new CBreinforcement
                        {
                            CBId = CatchBasinId,
                            CBRebarNom = RebarNomination.No4,
                            CBreinfCode = "rb04",
                            CBreinfQty = 2,
                            CBreinfLength = CBLength + 2m * CBWallThickness - 4m/12,
                            CBreinfShape = "Straight Shape, Longitudinal, at Curb",
                            TotalLength = (2m) * (CBLength + 2m * CBWallThickness - 4m / 12),
                            TotalWeight = (2m) * (CBLength + 2m * CBWallThickness - 4m / 12) * .668m
                        });


                        return cbReinf;
                    }
                case CBc1510Confg.Double:
                    {
                        cbReinf.Add(
                            new CBreinforcement
                            {
                                CBId = CatchBasinId,
                                CBRebarNom = RebarNomination.No4,
                                CBreinfCode = "rb01",
                                CBreinfQty = 14,
                                CBreinfLength = CBHeight + CBBaseThickness - (5m / 12m),
                                CBreinfShape = "Straight, Vertical",
                                TotalLength = (14m) * (CBHeight + CBBaseThickness - (5m / 12m)),
                                TotalWeight = (14m) * (CBHeight + CBBaseThickness - (5m / 12m)) * .668m
                            });
                        cbReinf.Add(
                            new CBreinforcement
                            {
                                CBId = CatchBasinId,
                                CBRebarNom = RebarNomination.No4,
                                CBreinfCode = "rb02",
                                CBreinfQty = (int)Math.Ceiling(CBHeight) + 1,
                                CBreinfLength = 2m * (CBLength + CBWidth + (5m / 12m)) + 2,
                                CBreinfShape = "Square Ring Shape, 2'-Overlap",
                                TotalLength = ((int)Math.Ceiling(CBHeight) + 1) * (2m * (CBLength + CBWidth + (5m / 12m)) + 2),
                                TotalWeight = ((int)Math.Ceiling(CBHeight) + 1) * (2m * (CBLength + CBWidth + (5m / 12m)) + 2) * .668m
                            });
                        cbReinf.Add(
                            new CBreinforcement
                            {
                                CBId = CatchBasinId,
                                CBRebarNom = RebarNomination.No3,
                                CBreinfCode = "rb03",
                                CBreinfQty = 15,
                                CBreinfLength = 2m,
                                CBreinfShape = "L Shape, 6\" x 18\", at Curb",
                                TotalLength = (15m) * (2m),
                                TotalWeight = (15m) * (2m) * .376m
                            });
                        cbReinf.Add(
                            new CBreinforcement
                            {
                                CBId = CatchBasinId,
                                CBRebarNom = RebarNomination.No4,
                                CBreinfCode = "rb04",
                                CBreinfQty = 2,
                                CBreinfLength = 2m * CBLength + 3m * CBWallThickness - 4m / 12,
                                CBreinfShape = "Straight Shape, Longitudinal, at Curb",
                                TotalLength = (2m) * (2m * CBLength + 3m * CBWallThickness - 4m / 12),
                                TotalWeight = (2m) * (2m * CBLength + 3m * CBWallThickness - 4m / 12) * .668m
                            });

                        return cbReinf;
                    }
                default:
                    return 
                        null;
            }
        }
        public override decimal PourBottom(decimal CBHeight) 
        {
            switch(this.CBc1510Confgs)
            {
                case CBc1510Confg.Single:
                    {
                        if (CBHeight < 8)
                        {
                            return
                                (2M * (CBLength + 2M * CBWallThickness + CBWidth) * CBWallThickness * (CBHeight + .5m - 2m)/*Walls*/
                                + CBLength * CBWidth * .75m  /*Base*/)
                                / 27M; /*CY*/
                        }
                        else
                        {
                            return
                                (2M * (CBLength + 2M * (CBWallThickness + 2m / 12m) + CBWidth) * (CBWallThickness + 2m / 12m) * (CBHeight + .5m - 2m) +/*Walls*/
                                CBLength * CBWidth * .75m  /*Base*/) / 27M; /*CY*/
                        }
                    }
                case CBc1510Confg.Double:
                    {
                        if (CBHeight < 8)
                        {
                            return
                                (2M * (2m * CBLength + CBWallThickness + 2M * CBWallThickness + CBWidth) * CBWallThickness * (CBHeight + .5m - 2m) +/*Walls*/
                                CBLength * CBWidth * .75m  /*Base*/) / 27M; /*CY*/
                        }
                        else
                        {
                            return
                                (2M * (2m * CBLength + CBWallThickness + 2M * (CBWallThickness + 2m / 12m) + CBWidth) * (CBWallThickness + 2m / 12m) * (CBHeight + .5m - 2m) +/*Walls*/
                                CBLength * CBWidth * .75m  /*Base*/) / 27M; /*CY*/

                            //    ((CBLength + 2M * (8m/12m)) * (CBWidth + 2M * (8m/12m)) * (8m/12m) + /*Base*/
                            //2M * ((CBLength + 2M * (8m/12m)) + CBWidth) * (8m/12m) * base.CBHeight /*Walls*/
                            //) / 27M; /*CY*/
                        }
                    }
                    default:
                    return 0;

            }
        }
        public override decimal PourTop()
        {
            switch (this.CBc1510Confgs)
            {
                case CBc1510Confg.Single:
                    {
                        return
                            (2M * (CBLength + 2M * CBWallThickness + CBWidth) * CBWallThickness * 2m  /*Walls*/
                            +(CBLength + 2m * CBWallThickness) * ( CBWallThickness + .5m ) * .5m  /*Curb Portion*/ 
                            +(CBLength + 2m * CBWallThickness) * 2.5m * 7m / 12m /*Pan Portion*/) / 27m;
                    }
                case CBc1510Confg.Double:
                    {
                        return
                            (2m * (2m * CBLength + CBWallThickness + 2M * CBWallThickness + CBWidth) * CBWallThickness * 2m  /*Walls*/ 
                            + (2m * CBLength + CBWallThickness + 2m * CBWallThickness) * (CBWallThickness + .5m) * .5m /*Curb Portion*/ 
                            + (2m * CBLength + CBWallThickness + 2m * CBWallThickness) * 2.5m * 7m / 12m /*Pan Portion*/) / 27m;
                    }
                default:
                    return 0;
            }
        }
        public override decimal PourApron()
        {
            return 0m;
                //((11m * 10m * 2m/12m  -
                //3m * 4M * 2m/12m +
                //(2m * (11m + 10M) + 2m * (4m + 3m)) * (((3m + 9m) * (6m / 2m) )/ 144))) / 27m;

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
            if (CBHeight < 8)
            {
                return
                    2M * (CBLength + CBWidth + 4M *  CBWallThickness) * (CBHeight +.5m) + /*OutsideWalls*/
                    2M * (CBLength + CBWidth) * (CBHeight +.5m); /*InsideWalls*/
            }
            else { 
                return
                    2M * (CBLength + CBWidth + 4M *  (CBWallThickness + 2m/12m)) * (CBHeight + .5m - 2m) + /*OutsideWalls*/
                    2M * (CBLength + CBWidth) * (CBHeight + .5m - 2m ) + /*InsideWalls*/

                    2M * (CBLength + CBWidth + 4M *  (CBWallThickness)) * (2m) + /*OutsideWalls*/
                    2M * (CBLength + CBWidth) * (2m); /*InsideWalls*/

            }
        }
        public override decimal InstBottomForms(decimal CBHeight)
        {
            if (CBHeight < 8)
            {
                return
                    2M * (CBLength + CBWidth + 4M *  CBWallThickness) * (CBHeight +.5m - 2m) + /*OutsideWalls*/
                    2M * (CBLength + CBWidth) * (CBHeight +.5m - 2m); /*InsideWalls*/
            }else
            {
                return
                    2M * (CBLength + CBWidth + 4M *  (CBWallThickness + 2m/12m)) * (CBHeight +.5m - 2m) + /*OutsideWalls*/
                    2M * (CBLength + CBWidth) * (CBHeight +.5m - 2m); /*InsideWalls*/
            }
        }
        public override decimal InstTopForms()
        {
            return
                2M * (CBLength + CBWidth + 4M *  CBWallThickness ) * 2m + /*OutsideWalls*/
                2M * (CBLength + CBWidth) * 2m; /*InsideWalls*/

        }
        public override decimal RebVertLength(decimal CBHeight)
        {
            return CBHeight + .5m  - (3m/12m + 1.5m/12m);
        }
        public override int RebSqRingEa (decimal CBHeight)
        {
            return (int)(Math.Ceiling((CBHeight + .5m - (3m + 1.5m)/12m) / 1.5m)) + 1;
        }
        public decimal RebNo3Length() { return 2m; }
        public decimal RebNo3Qty() { return 9m; }
        public decimal RebNo4Strth() { return CBLength + 2m * CBWallThickness - 1.5m * 2m / 12m;  }
        public decimal RebNo4StrthEa() { return 1m; }
        public override decimal CBRebarTakeOfflb(decimal CBHeight)
        {
            return 0;
        }
    }
}
