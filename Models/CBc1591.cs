using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmallStructuresTakeOffs.Enums;

namespace SmallStructuresTakeOffs.Models
{
    public class CBc1591 : CatchBasin
    {
        public SlottedDrain CBSlottedDrain { get; set; }
        public CurbType CBCurbType { get; set; }
        public override decimal CBLength { get; set; } = 3m;
        public override decimal CBWidth { get; set; } = 3m;
        public override decimal CBBaseThickness { get; set; } = .5m;

        //public override decimal CBWallThickness { get => .5m; set { decimal Tw = .5m; } }
        public override decimal CBWallThickness { get; set; } = .5m;
        public string Genres { get; set; }/* = string.Empty*/
        public CBConfig CBConfg { get; set; }
        public CBWing CBwings { get; set; }
        public override ICollection<CBreinforcement> CBreinforcements
        {
            get => this.TheReinforcements(); set => this.TheReinforcements();
        }
        public override ICollection<CBreinforcement> TheReinforcements()
        {
            IList<CBreinforcement> cbReinf = new List<CBreinforcement>();

                cbReinf.Add(
                    new CBreinforcement
                    {
                        CBId = CatchBasinId,
                        CBRebarNom = RebarNomination.No4,
                        CBreinfCode = "rb01",
                        CBreinfQty = 12,
                        CBreinfLength = CBHeight + CBBaseThickness - (5m/12m),
                        CBreinfShape = "Straight, Vertical",
                        TotalLength =  (12m) *  (CBHeight + CBBaseThickness - (5m/12m)),
                        TotalWeight =  (12m) *  (CBHeight + CBBaseThickness - (5m/12m)) * .668m
                    });
                cbReinf.Add(
                    new CBreinforcement
                    {
                        CBId = CatchBasinId,
                        CBRebarNom = RebarNomination.No4,
                        CBreinfCode = "rb02",
                        CBreinfQty = (int)Math.Ceiling(CBHeight) +1,
                        CBreinfLength = 2m * (CBLength + CBWidth + (5m/12m)) + 2,
                        CBreinfShape = "Square Ring Shape, 2'-Overlap",
                        TotalLength =  ((int)Math.Ceiling(CBHeight) +1) * (2m * (CBLength + CBWidth + (5m/12m)) + 2),
                        TotalWeight =  ((int)Math.Ceiling(CBHeight) +1) * (2m * (CBLength + CBWidth + (5m/12m)) + 2) * .668m
                    });

                return cbReinf;
        }
        public Dictionary<string, decimal> WingDict = new Dictionary<string, decimal>
        {
            {"Wing3'-6\"", 3.5M},
            {"Wing7'-6\"", 7.5M},
            {"Wing11'-6\"", 11.5M},
            {"Wing19'-6\"", 19.5M},
        };
        public override decimal CBRebarTakeOfflb(decimal CBHeight) 
        {
            switch (this.CBConfg)
            {
                case CBConfig.SumpOnly:
                {
                    if (CBHeight <= 5)
                    {
                        return
                            0;
                    }
                    else if (CBHeight < 8)
                    {
                        IList<CBreinforcement> cbReinf = new List<CBreinforcement>
                            {
                                new CBreinforcement
                                {
                                    CBId = this.CatchBasinId,
                                    //CBreinforcementId =1,
                                    CBRebarNom = RebarNomination.No3,
                                    CBreinfCode = "rb01",
                                    CBreinfQty = 5,
                                    CBreinfLength = 3.5m,
                                    CBreinfShape = "Straight",
                                },
                                new CBreinforcement
                                {
                                    CBId = this.CatchBasinId,
                                    //CBreinforcementId = 2,
                                    CBRebarNom = RebarNomination.No4,
                                    CBreinfCode = "rb02",
                                    CBreinfQty = 10,
                                    CBreinfLength = 3.5m,
                                    CBreinfShape = "Straight",
                                }
                            };

                        decimal CBTotalWeight = 0;

                        foreach (var cbR in cbReinf)
                        {
                            switch (cbR.CBRebarNom)
                            {
                                case RebarNomination.No3:
                                    CBTotalWeight += cbR.CBreinfQty * cbR.CBreinfLength * WeightDict["RebWeightNo3"];
                                    continue;
                                case RebarNomination.No4:
                                    CBTotalWeight += cbR.CBreinfQty * cbR.CBreinfLength * WeightDict["RebWeightNo4"];
                                    continue;
                                default:
                                    return 0m;
                            }
                        }
                        return 0;
                        //(2M * (CBLength + 2M * CBWallThickness + CBWidth) * CBWallThickness * (CBHeight +.5m - 2m) +/*Walls*/
                        //CBLength * CBWidth * .75m  /*Base*/) / 27M; /*CY*/
                    }
                    else
                    {
                        return
                            0;
                        //(2M * (CBLength + 2M * (CBWallThickness + 2m / 12m) + CBWidth) * (CBWallThickness + 2m / 12m) * (CBHeight +.5m - 2m) +/*Walls*/
                        //CBLength * CBWidth * .75m  /*Base*/) / 27M; /*CY*/
                    }
                }
                case CBConfig.SingleWing:
                {
                    if (CBHeight <= 5)
                    {
                        return
                            0;
                    }
                    else if (CBHeight <= 8)
                    {
                        switch (this.CBwings)
                        {
                            case CBWing.w3ft6in:
                            {
                                const decimal wing = 3.5m;
                                return
                                    3.5m;
                            }
                            case CBWing.w7ft6in:
                            {
                                const decimal wing = 7.5m;
                                decimal S = 1m + wing / 20m;
                                decimal F = CBHeight - (2.5m + wing / 20m);

                                //IList<CBreinforcement> cbReinf = new List<CBreinforcement>
                                //{
                                //    new CBreinforcement
                                //    {
                                //        CBId = this.CatchBasinId,
                                //        //CBreinforcementId =1,
                                //        CBRebarNom = RebarNomination.No4,
                                //        CBreinfCode = "rb01",
                                //        CBreinfQty = ((int)Math.Ceiling(CBHeight /1.5m) +1) * 2,
                                //        CBreinfLength = CBLength + CBWallThickness + WingDict["Wing3'-6\""] + (5m/12m),
                                //        CBreinfShape = "Straight",
                                //    },
                                //    new CBreinforcement
                                //    {
                                //        CBId = this.CatchBasinId,
                                //        //CBreinforcementId = 2,
                                //        CBRebarNom = RebarNomination.No4,
                                //        CBreinfCode = "rb02",
                                //        CBreinfQty = 3 * ((int)Math.Ceiling(CBHeight /1.5m) +1),
                                //        CBreinfLength = CBWidth + 4m + 5m/12m,
                                //        CBreinfShape = "C Shape, 2'-Overlap",
                                //    }
                                //};

                                decimal CBTotalWeight = 0;

                                foreach (var cbR in this.TheReinforcements().ToList())
                                //foreach (var cbR in cbReinf)
                                {
                                    switch (cbR.CBRebarNom)
                                    {
                                        case RebarNomination.No3:
                                            CBTotalWeight += cbR.CBreinfQty * cbR.CBreinfLength * WeightDict["RebWeightNo3"];
                                            continue;
                                        case RebarNomination.No4:
                                            CBTotalWeight += cbR.CBreinfQty * cbR.CBreinfLength * WeightDict["RebWeightNo4"];
                                            continue;
                                        default:
                                            return 0m;
                                    }
                                }
                                return CBTotalWeight;

                                //(2M * (CBLength + 2M * CBWallThickness + CBWidth) * CBWallThickness * (CBHeight +.5m - 2m) +/*Walls*/
                                //CBLength * CBWidth * .75m  /*Base*/) / 27M; /*CY*/

                            }
                            case CBWing.w11ft6in:
                            {
                                const decimal wing = 11.5m;
                                return
                                    11.5m;
                            }
                            case CBWing.w19ft6in:
                            {
                                const decimal wing = 19.5m;
                                return
                                    19.5m;
                            }
                            default:
                            {
                                return
                                    0;
                            }
                        }

                    }
                    else
                    {
                        return
                            0;
                        //(2M * (CBLength + 2M * (CBWallThickness + 2m / 12m) + CBWidth) * (CBWallThickness + 2m / 12m) * (CBHeight +.5m - 2m) +/*Walls*/
                        //CBLength * CBWidth * .75m  /*Base*/) / 27M; /*CY*/
                    }
                }
                case CBConfig.DoubleWing:
                {
                    return
                        0;
                }
                default:
                {
                    return
                        0;
                }
            }
        }
        public override decimal PourBottom(decimal CBHeight) 
        {
            if (CBHeight <= 8)
            {
                switch (this.CBSlottedDrain)
                {
                    case SlottedDrain.Dia18in:
                    {
                        switch (this.CBCurbType)
                        {
                            case CurbType.B:
                            {
                                return
                                2 * (CBLength + 2*CBWallThickness + CBWidth) * CBWallThickness * (CBHeight - (3m/12m + 2.5m)) / 27 +
                                (CBLength + 2m * CBWallThickness) * (CBWidth + 2m * CBWallThickness) * .5m / 27;
                            }

                            case CurbType.CorD:
                            {
                                return
                                2 * (CBLength + 2*CBWallThickness + CBWidth) * CBWallThickness * (CBHeight - (1.625m/12m + 2.5m)) / 27 +
                                (CBLength + 2m * CBWallThickness) * (CBWidth + 2m * CBWallThickness) * .5m / 27;
                            }

                            default:
                                return 0;
                        }
                    }
                    case SlottedDrain.Dia24in:
                    {
                        switch (this.CBCurbType)
                        {
                            case CurbType.B:
                            {
                                return
                                2 * (CBLength + 2*CBWallThickness + CBWidth) * CBWallThickness * (CBHeight - (3m/12m + 3m)) / 27 +
                                (CBLength + 2m * CBWallThickness) * (CBWidth + 2m * CBWallThickness) * .5m / 27;
                                    }

                            case CurbType.CorD:
                            {
                                return
                                2 * (CBLength + 2*CBWallThickness + CBWidth) * CBWallThickness * (CBHeight - (1.625m/12m + 3m)) / 27 +
                                (CBLength + 2m * CBWallThickness) * (CBWidth + 2m * CBWallThickness) * .5m / 27;
                                    }

                            default:
                                return 0;
                        }
                    }
                    case SlottedDrain.None:
                    {
                        return
                        2 * (CBLength + 2*CBWallThickness + CBWidth) * CBWallThickness * (CBHeight - 2m) / 27 +
                        (CBLength + 2m * CBWallThickness) * (CBWidth + 2m * CBWallThickness) * .5m / 27;
                        }
                    default:
                        return 0;
                }
            }
            else
            {
                switch (this.CBSlottedDrain)
                {
                    case SlottedDrain.Dia18in:
                        {
                            switch (this.CBCurbType)
                            {
                                case CurbType.B:
                                    {
                                        return
                                        2 * (CBLength + 2*(CBWallThickness + 2m/12m) + CBWidth) * (CBWallThickness + 2m/12m) * (CBHeight - (3m/12m + 2.5m)) / 27 +
                                        (CBLength + 2m * ((CBWallThickness + 2m/12m) + 3m/12m)) * (CBWidth + 2m * (CBWallThickness + 4m/12m)) * .5m / 27;
                                    }

                                case CurbType.CorD:
                                    {
                                        return
                                        2 * (CBLength + 2*(CBWallThickness + 2m/12m) + CBWidth) * (CBWallThickness + 2m/12m) * (CBHeight - (1.625m/12m + 2.5m)) / 27 +
                                        (CBLength + 2m * (CBWallThickness + 2m/12m)) * (CBWidth + 2m * (CBWallThickness + 4m/12m)) * .5m / 27;
                                    }

                                default:
                                    return 0;
                            }
                        }
                    case SlottedDrain.Dia24in:
                        {
                            switch (this.CBCurbType)
                            {
                                case CurbType.B:
                                    {
                                        return
                                        2 * (CBLength + 2*(CBWallThickness + 2m/12m) + CBWidth) * (CBWallThickness + 2m/12m) * (CBHeight - (3m/12m + 3m)) / 27 +
                                        (CBLength + 2m * (CBWallThickness + 2m/12m)) * (CBWidth + 2m * (CBWallThickness + 2m/12m)) * .5m / 27;
                                    }

                                case CurbType.CorD:
                                    {
                                        return
                                        2 * (CBLength + 2*(CBWallThickness + 2m/12m) + CBWidth) * (CBWallThickness + 2m/12m) * (CBHeight - (1.625m/12m + 3m)) / 27 +
                                        (CBLength + 2m * (CBWallThickness + 2m/12m)) * (CBWidth + 2m * (CBWallThickness + 2m/12m)) * .5m / 27;
                                    }

                                default:
                                    return 0;
                            }
                        }
                    case SlottedDrain.None:
                        {
                            return
                            2 * (CBLength + 2*(CBWallThickness + 2m/12m) + CBWidth) * (CBWallThickness + 2m/12m) * (CBHeight - 2m) / 27 +
                            (CBLength + 2m * (CBWallThickness + 2m/12m)) * (CBWidth + 2m * (CBWallThickness + 2m/12m)) * .5m / 27;
                        }
                    default:
                        return 0;
                }
            }

        }
        public override decimal PourTop()
        {
            switch (this.CBSlottedDrain)
            {
                case SlottedDrain.Dia18in:
                    {
                        switch (this.CBCurbType)
                        {
                            case CurbType.B:
                                {
                                    return
                                    2 * (CBLength + 2*CBWallThickness + CBWidth) * CBWallThickness * ((3m/12m + 2.5m)) / 27;
                                }

                            case CurbType.CorD:
                                {
                                    return
                                    2 * (CBLength + 2*CBWallThickness + CBWidth) * CBWallThickness * ((1.625m/12m + 2.5m)) / 27;
                                }

                            default:
                                return 0;
                        }
                    }
                case SlottedDrain.Dia24in:
                    {
                        switch (this.CBCurbType)
                        {
                            case CurbType.B:
                                {
                                    return
                                    2 * (CBLength + 2*CBWallThickness + CBWidth) * CBWallThickness * ((3m/12m + 3m)) / 27;
                                }

                            case CurbType.CorD:
                                {
                                    return
                                    2 * (CBLength + 2*CBWallThickness + CBWidth) * CBWallThickness * ((1.625m/12m + 3m)) / 27;
                                }

                            default:
                                return 0;
                        }
                    }
                case SlottedDrain.None:
                    {
                        return
                        2 * (CBLength + 2*CBWallThickness + CBWidth) * CBWallThickness * (2m) / 27;
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
            switch (this.CBConfg)
            {
                case CBConfig.SumpOnly:
                {
                    if (CBHeight <= 5)
                    {
                        return
                            0;
                    }
                    else if (CBHeight <= 8)
                    {
                        return
                            0;
                        //(2M * (CBLength + 2M * CBWallThickness + CBWidth) * CBWallThickness * (CBHeight +.5m - 2m) +/*Walls*/
                        //CBLength * CBWidth * .75m  /*Base*/) / 27M; /*CY*/
                    }
                    else
                    {
                        return
                            0;
                        //(2M * (CBLength + 2M * (CBWallThickness + 2m / 12m) + CBWidth) * (CBWallThickness + 2m / 12m) * (CBHeight +.5m - 2m) +/*Walls*/
                        //CBLength * CBWidth * .75m  /*Base*/) / 27M; /*CY*/
                    }
                }
                case CBConfig.SingleWing:
                {
                    if (CBHeight <= 5)
                    {
                        switch (this.CBwings)
                        {
                            case CBWing.w3ft6in:
                            {
                                const decimal wing = 3.5m;
                                return
                                    0;
                            }
                            default:
                            {
                                return
                                    0;
                            }
                        }
                    }
                    else if (CBHeight <= 8)
                    {
                        switch (this.CBwings)
                        {
                            case CBWing.w3ft6in:
                            {
                                const decimal wing = 3.5m;
                                return
                                    3.5m;
                            }
                            case CBWing.w7ft6in:
                            {
                                const decimal Length = 7.5m;
                                decimal T = 1.5m;
                                decimal S = 1m + Length / 20m;
                                decimal F = CBHeight - (2.5m + Length / 20m);

                                return
                                    /*F Bottom Walls */ 2m * (2m * CBLength  + 4m * CBWallThickness + 2m *CBWidth) * F +
                                    /*S Bottom Walls */ 4m * (CBLength + Length   + 3m * CBWallThickness + CBWidth)  * S +
                                    /*T Section Outside Walls */ 2m * (CBLength + 5m * CBWallThickness + Length + CBWidth) * T +
                                    /*T Section Inside Walls */ 2m * (CBLength + CBWallThickness + Length + CBWidth) * (T - 0.5m) +
                                    /* T Section Slab */ (CBLength + CBWallThickness + Length) * CBWidth;
                                //7.5m; Test
                            }
                            case CBWing.w11ft6in:
                            {
                                const decimal wing = 11.5m;
                                return
                                    11.5m;
                            }
                            case CBWing.w19ft6in:
                            {
                                const decimal wing = 19.5m;
                                return
                                    19.5m;
                            }
                            default:
                            {
                                return
                                    0;
                            }
                        }
                    }
                    else
                    {
                        return
                            0;
                    }
                }
                case CBConfig.DoubleWing:
                {
                    return
                        0;
                }
                default:
                {
                    return
                        0;
                }
            }
        }
        public override decimal InstBottomForms(decimal CBHeight)
        {
            switch (this.CBConfg)
            {
                case CBConfig.SumpOnly:
                {
                    if (CBHeight <= 5)
                    {
                        return
                            0;
                    }
                    else if (CBHeight <= 8)
                    {
                        return
                            0;
                        //(2M * (CBLength + 2M * CBWallThickness + CBWidth) * CBWallThickness * (CBHeight +.5m - 2m) +/*Walls*/
                        //CBLength * CBWidth * .75m  /*Base*/) / 27M; /*CY*/
                    }
                    else
                    {
                        return
                            0;
                        //(2M * (CBLength + 2M * (CBWallThickness + 2m / 12m) + CBWidth) * (CBWallThickness + 2m / 12m) * (CBHeight +.5m - 2m) +/*Walls*/
                        //CBLength * CBWidth * .75m  /*Base*/) / 27M; /*CY*/
                    }
                }
                case CBConfig.SingleWing:
                {
                    if (CBHeight <= 5)
                    {
                        switch (this.CBwings)
                        {
                            case CBWing.w3ft6in:
                            {
                                const decimal wing = 3.5m;
                                return
                                    0;
                            }
                            default:
                            {
                                return
                                    0;
                            }
                        }
                    }
                    else if (CBHeight <= 8)
                    {
                        switch (this.CBwings)
                        {
                            case CBWing.w3ft6in:
                            {
                                const decimal wing = 3.5m;
                                return
                                    3.5m;
                            }
                            case CBWing.w7ft6in:
                            {
                                const decimal Length = 7.5m;
                                decimal T = 1.5m;
                                decimal S = 1m + Length / 20m;
                                decimal F = CBHeight - (2.5m + Length / 20m);

                                return
                                    /*F Bottom Walls */ 2m * (2m * CBLength  + 4m * CBWallThickness + 2m *CBWidth) * F +
                                    /*S Bottom Walls */ 4m * (CBLength + Length   + 3m * CBWallThickness + CBWidth)  * S;
                                    /*T Section Outside Walls */ /*2m * (CBLength + 5m * CBWallThickness + Length + CBWidth) * T +*/
                                    /*T Section Inside Walls */ /*2m * (CBLength + CBWallThickness + Length + CBWidth) * (T - 0.5m) +*/
                                    /* T Section Slab */ /*(CBLength + CBWallThickness + Length) * CBWidth;*/
                                //7.5m; Test
                            }
                            case CBWing.w11ft6in:
                            {
                                const decimal wing = 11.5m;
                                return
                                    11.5m;
                            }
                            case CBWing.w19ft6in:
                            {
                                const decimal wing = 19.5m;
                                return
                                    19.5m;
                            }
                            default:
                            {
                                return
                                    0;
                            }
                        }
                    }
                    else
                    {
                        return
                            0;

                    }
                }
                case CBConfig.DoubleWing:
                {
                    return
                        0;
                }
                default:
                {
                    return
                        0;
                }
            }

        }
        public override decimal InstTopForms()
        {
            switch (this.CBConfg)
            {
                case CBConfig.SumpOnly:
                {
                    if (CBHeight <= 5)
                    {
                        return
                            0;
                    }
                    else if (CBHeight <= 8)
                    {
                        return
                            0;
                        //(2M * (CBLength + 2M * CBWallThickness + CBWidth) * CBWallThickness * (CBHeight +.5m - 2m) +/*Walls*/
                        //CBLength * CBWidth * .75m  /*Base*/) / 27M; /*CY*/
                    }
                    else
                    {
                        return
                            0;
                        //(2M * (CBLength + 2M * (CBWallThickness + 2m / 12m) + CBWidth) * (CBWallThickness + 2m / 12m) * (CBHeight +.5m - 2m) +/*Walls*/
                        //CBLength * CBWidth * .75m  /*Base*/) / 27M; /*CY*/
                    }
                }
                case CBConfig.SingleWing:
                {
                    if (CBHeight <= 5)
                    {
                        switch (this.CBwings)
                        {
                            case CBWing.w3ft6in:
                            {
                                const decimal wing = 3.5m;
                                return
                                    0;
                            }
                            default:
                            {
                                return
                                    0;
                            }
                        }
                    }
                    else if (CBHeight < 8)
                    {
                        switch (this.CBwings)
                        {
                            case CBWing.w3ft6in:
                            {
                                const decimal wing = 3.5m;
                                return
                                    3.5m;
                            }
                            case CBWing.w7ft6in:
                            {
                                const decimal Length = 7.5m;
                                decimal T = 1.5m;
                                decimal S = 1m + Length / 20m;
                                decimal F = CBHeight - (2.5m + Length / 20m);

                                return
                                    /*F Bottom Walls */ /*2m * (2m * CBLength  + 4m * CBWallThickness + 2m *CBWidth) * F +*/
                                    /*S Bottom Walls */ /*4m * (CBLength + Length   + 3m * CBWallThickness + CBWidth)  * S +*/
                                    /*T Section Outside Walls */ 2m * (CBLength + 5m * CBWallThickness + Length + CBWidth) * T +
                                    /*T Section Inside Walls */ 2m * (CBLength + CBWallThickness + Length + CBWidth) * (T - 0.5m) +
                                    /* T Section Slab */ (CBLength + CBWallThickness + Length) * CBWidth;
                                //7.5m; Test
                            }
                            case CBWing.w11ft6in:
                            {
                                const decimal wing = 11.5m;
                                return
                                    11.5m;
                            }
                            case CBWing.w19ft6in:
                            {
                                const decimal wing = 19.5m;
                                return
                                    19.5m;
                            }
                            default:
                            {
                                return
                                    0;
                            }
                        }
                    }
                    else
                    {
                        return
                            0;

                    }
                }
                case CBConfig.DoubleWing:
                {
                    return
                        0;
                }
                default:
                {
                    return
                        0;
                }
            }
        }
    }
}
