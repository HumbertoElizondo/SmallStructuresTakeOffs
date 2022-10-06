using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmallStructuresTakeOffs.Enums;

namespace SmallStructuresTakeOffs.Models
{
    public class CBp1572 : CatchBasin
    {
        //public override decimal CBLength { get => 2m + 11.75m/12m; set { decimal L = 2m + 11.75m/12m; } }
        public override decimal CBLength { get; set; } = 2m + 11.5m / 12m;

        //public override decimal CBWidth { get => 2m + 2.5m/12m; set { decimal W = 2m; } }
        //public override decimal CBWidth { get; set; } = 2m + 8.5m / 12m;
        public override decimal CBWidth { get; set; } = 2m + 8.5m / 12m;

        //public override decimal CBBaseThickness { get => .75m; set { decimal Tb = .75m; } }
        public override decimal CBBaseThickness { get; set; } = .75m;

        //public override decimal CBWallThickness { get => .5m; set { decimal Tw = .5m; } }
        public override decimal CBWallThickness { get; set; } = .5m;

        public override ICollection<CBreinforcement> CBreinforcements
        {
            get => this.TheReinforcements(); set => this.TheReinforcements();
        }
        //public CBc1510Confg CBc1510Confgs { get; set; }

        public CBp1570Type CBp1570Typ1 { get; set; }

        public override ICollection<CBreinforcement> TheReinforcements()
        {
            IList<CBreinforcement> cbReinf = new List<CBreinforcement>();

            //cbReinf.Add(
            //    new CBreinforcement
            //    {
            //        CBId = CatchBasinId,
            //        CBRebarNom = RebarNomination.No4,
            //        CBreinfCode = "rb01",
            //        CBreinfQty = 10,
            //        CBreinfLength = CBHeight + CBBaseThickness - (5m / 12m),
            //        CBreinfShape = "Straight, Vertical",
            //        TotalLength = (10m) * (CBHeight + CBBaseThickness - (5m / 12m)),
            //        TotalWeight = (10m) * (CBHeight + CBBaseThickness - (5m / 12m)) * .668m
            //    });
            //cbReinf.Add(
            //    new CBreinforcement
            //    {
            //        CBId = CatchBasinId,
            //        CBRebarNom = RebarNomination.No4,
            //        CBreinfCode = "rb02",
            //        CBreinfQty = (int)Math.Ceiling(CBHeight) + 1,
            //        CBreinfLength = 2m * (CBLength + CBWidth + (5m / 12m)) + 2,
            //        CBreinfShape = "Square Ring Shape, 2'-Overlap",
            //        TotalLength = ((int)Math.Ceiling(CBHeight) + 1) * (2m * (CBLength + CBWidth + (5m / 12m)) + 2),
            //        TotalWeight = ((int)Math.Ceiling(CBHeight) + 1) * (2m * (CBLength + CBWidth + (5m / 12m)) + 2) * .668m
            //    });
            //cbReinf.Add(
            //    new CBreinforcement
            //    {
            //        CBId = CatchBasinId,
            //        CBRebarNom = RebarNomination.No3,
            //        CBreinfCode = "rb03",
            //        CBreinfQty = 8,
            //        CBreinfLength = 2m,
            //        CBreinfShape = "L Shape, 6\" x 18\", at Curb",
            //        TotalLength = (8m) * (2m),
            //        TotalWeight = (8m) * (2m) * .376m
            //    });
            //cbReinf.Add(
            //new CBreinforcement
            //{
            //    CBId = CatchBasinId,
            //    CBRebarNom = RebarNomination.No4,
            //    CBreinfCode = "rb04",
            //    CBreinfQty = 2,
            //    CBreinfLength = CBLength + 2m * CBWallThickness - 4m / 12,
            //    CBreinfShape = "Straight Shape, Longitudinal, at Curb",
            //    TotalLength = (2m) * (CBLength + 2m * CBWallThickness - 4m / 12),
            //    TotalWeight = (2m) * (CBLength + 2m * CBWallThickness - 4m / 12) * .668m
            //});


            return cbReinf;
        }

        public override decimal PourBottom(decimal CBHeight) 
        {
            switch(this.CBp1570Typ1)
            {
                case CBp1570Type.Single:
                    {
                        if (CBHeight <= 4)
                        {
                            return
                                //(2M * (CBLength + 2M * CBWallThickness + CBWidth) * CBWallThickness * (CBHeight + .5m - 2m)/*Walls*/
                                //+ CBLength * CBWidth * .75m  /*Base*/)
                                /// 27M; /*CY*/
                                0;
                        }
                        else if (CBHeight <= 8) 
                        {
                            CBWallThickness = 8m / 12m;
                            return
                                //(2m * (CBLength + 2M * CBWallThickness + CBWidth) * CBWallThickness * (CBHeight + CBBaseThickness - 2m) /*Walls*/
                                ////+ CBLength * CBWidth * CBBaseThickness  /*Base*/) / 27M; /*CY*/
                                //);
                                0;
                        }

                        return 0;
                    }
                case CBp1570Type.Double:
                    {
                        CBLength = 6m + 5m / 12m;

                        if (CBHeight <= 4)
                        {
                            return
                                (2m * (CBLength + 2M * CBWallThickness + CBWidth) * CBWallThickness * (CBHeight + CBBaseThickness - 2m) /*Walls*/
                                + CBLength * CBWidth * CBBaseThickness  /*Base*/
                                ) / 27M; /*CY*/
                        }
                        else if (CBHeight <= 8)
                        {
                            CBWallThickness = 8m / 12m;
                            return
                                (2m * (CBLength + 2M * CBWallThickness + CBWidth) * CBWallThickness * (CBHeight + CBBaseThickness - 2m) /*Walls*/
                                + CBLength * CBWidth * CBBaseThickness  /*Base*/
                                ) / 27M; /*CY*/
                        }
                        return 0;
                    }
                case CBp1570Type.Triple:
                    {
                        CBLength = 9m + 10.5m / 12m;
                        if (CBHeight <= 4)
                        {
                            return
                                //(2M * (2m * CBLength + CBWallThickness + 2M * CBWallThickness + CBWidth) * CBWallThickness * (CBHeight + .5m - 2m) +/*Walls*/
                                //CBLength * CBWidth * .75m  /*Base*/) / 27M; /*CY*/
                                0;
                        }
                        else if (CBHeight <= 8)
                        {
                            
                            return
                                //(2M * (2m * CBLength + CBWallThickness + 2M * (CBWallThickness + 2m / 12m) + CBWidth) * (CBWallThickness + 2m / 12m) * (CBHeight + .5m - 2m) +/*Walls*/
                                //CBLength * CBWidth * .75m  /*Base*/) / 27M; /*CY*/
                                0;
                        }
                        return 0;
                    }

                default:
                    return 0;

            }
        }
        public override decimal PourTop()
        {
            switch (this.CBp1570Typ1)
            {
                case CBp1570Type.Single:
                    {
                        if (CBHeight <= 4)
                        {
                            return
                                //(2M * (CBLength + 2M * CBWallThickness + CBWidth) * CBWallThickness * 2m  /*Walls*/
                                //+ (CBLength + 2m * CBWallThickness) * (CBWallThickness + .5m) * .5m  /*Curb Portion*/
                                //+ (CBLength + 2m * CBWallThickness) * 2.5m * 7m / 12m /*Pan Portion*/) / 27m;
                                0;
                        }
                        else if (CBHeight <= 8)
                        {
                            CBWallThickness = 8m / 12m;
                            return
                                //(2M * (CBLength + 2M * CBWallThickness + CBWidth) * CBWallThickness * 2m  /*Walls*/
                                //+ (CBLength + 2m * CBWallThickness) * (CBWallThickness + .5m) * .5m  /*Curb Portion*/
                                //+ (CBLength + 2m * CBWallThickness) * 2.5m * 7m / 12m /*Pan Portion*/) / 27m;
                                0;
                        }
                        return 0;

                    }
                case CBp1570Type.Double:
                    {
                        CBLength = 6m + 5m / 12m;
                        if (CBHeight <= 4)
                        {
                            return
                                //(2M * (CBLength + 2M * CBWallThickness + CBWidth) * CBWallThickness * 2m  /*Walls*/
                                //+ (CBLength + 2m * CBWallThickness) * (CBWallThickness + .5m) * .5m  /*Curb Portion*/
                                //+ (CBLength + 2m * CBWallThickness) * 2.5m * 7m / 12m /*Pan Portion*/) / 27m;
                                0;

                        }
                        else if (CBHeight <= 8)
                        {
                            CBWallThickness = 8m / 12m;
                            return
                                (2m * (CBLength + 2M * CBWallThickness + CBWidth) * CBWallThickness * (2m) /*Walls*/
                                + CBLength * CBWallThickness * 8m / 12m /*Curb*/
                                + CBLength * (7.5m + 4m)* CBWallThickness / 2m /*Nose*/
                                ) / 27M; /*CY*/
                        }
                        return 0;
                    }
                case CBp1570Type.Triple:
                    {
                        CBLength = 9m + 10.5m / 12m;
                        if (CBHeight <= 4)
                        {
                            return
                                //(2M * (CBLength + 2M * CBWallThickness + CBWidth) * CBWallThickness * 2m  /*Walls*/
                                //+ (CBLength + 2m * CBWallThickness) * (CBWallThickness + .5m) * .5m  /*Curb Portion*/
                                //+ (CBLength + 2m * CBWallThickness) * 2.5m * 7m / 12m /*Pan Portion*/) / 27m;
                                0;

                        }
                        else if (CBHeight <= 8)
                        {
                            CBWallThickness = 8m / 12m;
                            return
                                //(2M * (CBLength + 2M * CBWallThickness + CBWidth) * CBWallThickness * 2m  /*Walls*/
                                //+ (CBLength + 2m * CBWallThickness) * (CBWallThickness + .5m) * .5m  /*Curb Portion*/
                                //+ (CBLength + 2m * CBWallThickness) * 2.5m * 7m / 12m /*Pan Portion*/) / 27m;
                                0;
                        }
                    return 0;
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
                    //2M * (CBLength + CBWidth + 4M *  CBWallThickness) * (CBHeight +.5m) + /*OutsideWalls*/
                    //2M * (CBLength + CBWidth) * (CBHeight +.5m); /*InsideWalls*/
                    0;
            }
            else {
                return
                    //2M * (CBLength + CBWidth + 4M *  (CBWallThickness + 2m/12m)) * (CBHeight + .5m - 2m) + /*OutsideWalls*/
                    //2M * (CBLength + CBWidth) * (CBHeight + .5m - 2m ) + /*InsideWalls*/
                    0;

                    //2M * (CBLength + CBWidth + 4M *  (CBWallThickness)) * (2m) + /*OutsideWalls*/
                    //2M * (CBLength + CBWidth) * (2m); /*InsideWalls*/

            }
        }
        public override decimal InstBottomForms(decimal CBHeight)
        {
            if (CBHeight < 8)
            {
                return
                    //2M * (CBLength + CBWidth + 4M *  CBWallThickness) * (CBHeight +.5m - 2m) + /*OutsideWalls*/
                    //2M * (CBLength + CBWidth) * (CBHeight +.5m - 2m); /*InsideWalls*/
                    0;
            }else
            {
                return
                    //2M * (CBLength + CBWidth + 4M *  (CBWallThickness + 2m/12m)) * (CBHeight +.5m - 2m) + /*OutsideWalls*/
                    //2M * (CBLength + CBWidth) * (CBHeight +.5m - 2m); /*InsideWalls*/
                    0;
            }
        }
        public override decimal InstTopForms()
        {
            return
                //2M * (CBLength + CBWidth + 4M *  CBWallThickness ) * 2m + /*OutsideWalls*/
                //2M * (CBLength + CBWidth) * 2m; /*InsideWalls*/
                0;

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
