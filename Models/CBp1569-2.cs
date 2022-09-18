using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmallStructuresTakeOffs.Enums;

namespace SmallStructuresTakeOffs.Models
{
    public class CBp1569_2 : CatchBasin
    {
        public override decimal CBLength { get => 3m; set { decimal L = 3m; } }
        public override decimal CBWidth { get => 2.75m; set { decimal W = 2.75m; } }
        public override decimal CBBaseThickness { get => .75m; set { decimal Tb = .75m; } }
        public override decimal CBWallThickness { get => .5m; set { decimal Tw = .5m; } }
        public override int CBVertBars
        {
            get
            {
                switch (this.CBwings)
                {
                    case CBWing.w3ft6in:
                        { return 0; }
                    case CBWing.w7ft6in:
                        { return 24; }

                    default:
                        { return 0; }
                }
            }

            set { decimal Bars = 10m; }

        }

        public override decimal CBSqRingL 
        {
            get
            {
                switch (this.CBwings)
                {
                    case CBWing.w3ft6in:
                        { return 0; }
                    case CBWing.w7ft6in:
                        {
                            decimal wing = 7.5m;
                            return
                                /* Long Side*/ (CBLength + wing + .5m + 4m/12m +
                                /* Width Side */ CBWidth + 4m/12m) * 2m + 1m;
                                //24m; Testing  
                        }

                    default:
                        { return 0; }
                }
            }


            set { decimal R = (CBLength + CBWidth + 4m * 2m/12m) * 2 + 1m ; } 
        }

        public string Genres { get; set; }/* = string.Empty*/
        public CBConfig CBConfg { get; set; }

        public CBWing CBwings { get; set; }

        public CBp1569Type CBp1569Types { get; set; }

        public CBp1569Wing CBp1569Wings { get; set; }


        public override ICollection<CBreinforcement> CBreinforcements
        {
            get => this.theReinforcements(); set => this.theReinforcements();
        }

        public override ICollection<CBreinforcement> theReinforcements()
        {
            IList<CBreinforcement> cbReinf = new List<CBreinforcement>();

            switch (this.CBp1569Types)
            {
                case CBp1569Type.M_NoWing:
                {
                        cbReinf.Add(
                                new CBreinforcement
                                {
                                    CBId = CatchBasinId,
                                    CBRebarNom = RebarNomination.No4,
                                    CBreinfCode = "rb01",
                                    CBreinfQty = ((int)Math.Ceiling(CBHeight /1.5m) +1) * 2,
                                    CBreinfLength = CBLength + CBWallThickness + WingDict["Wing3'-6\""] + (5m/12m),
                                    CBreinfShape = "Straight",
                                });
                        cbReinf.Add(
                                new CBreinforcement
                                {
                                    CBId = CatchBasinId,
                                    CBRebarNom = RebarNomination.No4,
                                    CBreinfCode = "rb02",
                                    CBreinfQty = 3 * ((int)Math.Ceiling(CBHeight /1.5m) +1),
                                    CBreinfLength = CBWidth + 4m + 5m/12m,
                                    CBreinfShape = "C Shape, 2'-Overlap",
                                });

                        return cbReinf;
                }
                case CBp1569Type.M1_OneWing:
                {
                    switch (this.CBp1569Types)
                    {
                        case CBp1569Type.M_NoWing:
                        {
                            if (CBHeight <= 4)
                            {
                                return
                                    null;
                                //(2M * (CBLength + 2M * CBWallThickness + CBWidth) * CBWallThickness * (CBHeight +.5m - 2m) +/*Walls*/
                                //CBLength * CBWidth * .75m  /*Base*/) / 27M; /*CY*/
                            }
                            else if (CBHeight <= 8)
                            {
                                return
                                    null;
                                //(2M * (CBLength + 2M * (CBWallThickness + 2m / 12m) + CBWidth) * (CBWallThickness + 2m / 12m) * (CBHeight +.5m - 2m) +/*Walls*/
                                //CBLength * CBWidth * .75m  /*Base*/) / 27M; /*CY*/
                            }
                            else
                            {
                                return
                                    null;
                                //(2M * (CBLength + 2M * (CBWallThickness + 2m / 12m) + CBWidth) * (CBWallThickness + 2m / 12m) * (CBHeight +.5m - 2m) +/*Walls*/
                                //CBLength * CBWidth * .75m  /*Base*/) / 27M; /*CY*/
                            }
                        }
                        case CBp1569Type.M1_OneWing:
                        {
                            if (CBHeight <= 4)
                            {
                                switch (this.CBp1569Wings)
                                {
                                    case CBp1569Wing.Three3:
                                        {
                                            const decimal wing = 3.5m;
                                            return
                                                null;
                                        }
                                    case CBp1569Wing.Six6:
                                        {
                                            const decimal wing = 6m;
                                            const decimal T = 20.25m / 12m;
                                            decimal S = .5m + wing / 10m;
                                            decimal F = CBHeight - (T + S) + .5m;

                                            return
                                                null;
                                            //(
                                            //    2m * (wing - (CBWallThickness + 2m / 12m)) * (CBWallThickness + 2m / 12m) * T /*Long WingWalls*/
                                            //    + 1m * (18m / 12m + 2m * (CBWallThickness + 2m / 12m)) * (CBWallThickness + 2m / 12m) * T /*Short WingWalls*/                                         //2m * (15m/12m * (CBWallThickness + 2m/12m) * S) + /*Short SumpWalls*/
                                            //    + 2m * (CBWidth + 2m * (CBWallThickness + 2m / 12m)) * (CBWallThickness + 2m / 12m) * (T) /*Short SumpWalls*/
                                            //    + 2m * (CBLength) * (CBWallThickness + 2m / 12m) * (T) /*Long SumpWalls*/
                                            //    + wing * (decimal)Math.Sqrt(Math.Pow(1, 2) + Math.Pow(10, 2)) / 10m * 18m / 12m * .5m  /*Wing Slab*/
                                            //    + CBLength * CBWidth * CBBaseThickness /*Sump Slab*/
                                            //   ) / 27M; /*CY*/
                                        }
                                    case CBp1569Wing.Ten10:
                                        {
                                            const decimal wing = 11.5m;
                                            return
                                                null;
                                        }
                                    case CBp1569Wing.Seventeen17:
                                        {
                                            const decimal wing = 19.5m;
                                            return
                                                null;
                                        }
                                    default:
                                        {
                                            return
                                                null;
                                        }
                                }
                            }
                            else if (CBHeight <= 8)
                            {
                                switch (this.CBp1569Wings)
                                {
                                    case CBp1569Wing.Three3:
                                    {
                                        const decimal wing = 3.5m;
                                        return
                                            null;
                                    }
                                    case CBp1569Wing.Six6:
                                    {
                                        const decimal wing = 6m;
                                        const decimal T = 20.25m / 12m;
                                        decimal S = .5m + wing / 10m;
                                        decimal F = CBHeight - (T + S) + .5m;

                                        cbReinf.Add(
                                            new CBreinforcement
                                            {
                                                CBId = CatchBasinId,
                                                CBRebarNom = RebarNomination.No3,
                                                CBreinfCode = "rb01",
                                                CBreinfShape = "Straight, long, Along Wing & Sump",
                                                CBreinfQty = 5,
                                                CBreinfLength = CBLength + wing + 2m * (CBWallThickness + 2m/12m) - (4m / 12m),
                                                TotalLength = (5m) * (CBLength + wing + 2m * (CBWallThickness + 2m / 12m) - (4m / 12m)),
                                                TotalWeight = (5m) * (CBLength + wing + 2m * (CBWallThickness + 2m / 12m) - (4m / 12m)) * .376m
                                            });

                                        cbReinf.Add(
                                            new CBreinforcement
                                            {
                                                CBId = CatchBasinId,
                                                CBRebarNom = RebarNomination.No3,
                                                CBreinfCode = "rb02",
                                                CBreinfShape = "Straight, long, Along Sump",
                                                CBreinfQty = 3,
                                                CBreinfLength = CBLength + 2m * (CBWallThickness + 2m / 12m) - (4m / 12m),
                                                TotalLength = (3m) * (CBLength + 2m * (CBWallThickness + 2m / 12m) - (4m / 12m)),
                                                TotalWeight = (3m) * (CBLength + 2m * (CBWallThickness + 2m / 12m) - (4m / 12m)) * .376m
                                            });


                                        cbReinf.Add(
                                                new CBreinforcement
                                                {
                                                    CBId = CatchBasinId,
                                                    CBRebarNom = RebarNomination.No3,
                                                    CBreinfCode = "rb03",
                                                    CBreinfShape = "Straight, transv, Along Sump",
                                                    CBreinfQty = 8,
                                                    CBreinfLength = CBWidth + 2m * (CBWallThickness + 2m / 12m) - (4m / 12m),
                                                    TotalLength = (8m) * (CBWidth + 2m * (CBWallThickness + 2m / 12m) - (4m / 12m)),
                                                    TotalWeight = (8m) * (CBWidth + 2m * (CBWallThickness + 2m / 12m) - (4m / 12m)) * .376m
                                                });
                                        cbReinf.Add(
                                                new CBreinforcement
                                                {
                                                    CBId = CatchBasinId,
                                                    CBRebarNom = RebarNomination.No3,
                                                    CBreinfCode = "rb04",
                                                    CBreinfShape = "Straight, transv, Along wing",
                                                    CBreinfQty = (int)Math.Ceiling((wing +  (CBWallThickness + 2m / 12m) - (4m / 12m))/.5m) + 1,
                                                    CBreinfLength = 18m/12m + 2m * CBWallThickness - 4m/12m ,
                                                    TotalLength = ((int)Math.Ceiling((wing + (CBWallThickness + 2m / 12m) - (4m / 12m)) / .5m) + 1) * (18m / 12m + 2m * CBWallThickness - 4m / 12m),
                                                    TotalWeight = ((int)Math.Ceiling((wing + (CBWallThickness + 2m / 12m) - (4m / 12m)) / .5m) + 1) * (18m / 12m + 2m * CBWallThickness - 4m / 12m) * .376m
                                                });
                                                    cbReinf.Add(
                                        new CBreinforcement
                                        {
                                            CBId = CatchBasinId,
                                            CBRebarNom = RebarNomination.No4,
                                            CBreinfCode = "rb05",
                                            CBreinfShape = "Dowel Bar, C Shape, 2-3\" x 9\"",
                                            CBreinfQty = 4,
                                            CBreinfLength = (2m * 3m + 9m) / 12m,
                                            TotalLength = (4m) * ((2m * 3m + 9m) / 12m),
                                            TotalWeight = (4m) * ((2m * 3m + 9m) / 12m) * .668m
                                        });


                                                    return cbReinf;
                                    }
                                    case CBp1569Wing.Ten10:
                                    {
                                        const decimal wing = 11.5m;
                                        return
                                            null;
                                    }
                                    case CBp1569Wing.Seventeen17:
                                    {
                                        const decimal wing = 19.5m;
                                        return
                                            null;
                                    }
                                    default:
                                    {
                                        return
                                            null;
                                    }
                                }
                            }
                            else
                            {
                                return
                                    null;
                            }
                        }
                        case CBp1569Type.M2_TwoWing:
                        {
                            return
                                null;
                        }
                        default:
                        {
                            return
                                null;
                        }
                    }
                }
                case CBp1569Type.M2_TwoWing:
                {
                    cbReinf.Add(
                            new CBreinforcement
                            {
                                CBId = CatchBasinId,
                                CBRebarNom = RebarNomination.No4,
                                CBreinfCode = "rb01",
                                CBreinfQty = ((int)Math.Ceiling(CBHeight /1.5m) +1) * 2,
                                CBreinfLength = CBLength + CBWallThickness + WingDict["Wing3'-6\""] + (5m/12m),
                                CBreinfShape = "Straight",
                            });
                    cbReinf.Add(
                            new CBreinforcement
                            {
                                CBId = CatchBasinId,
                                CBRebarNom = RebarNomination.No4,
                                CBreinfCode = "rb02",
                                CBreinfQty = 3 * ((int)Math.Ceiling(CBHeight /1.5m) +1),
                                CBreinfLength = CBWidth + 4m + 5m/12m,
                                CBreinfShape = "C Shape, 2'-Overlap",
                            });

                    return cbReinf;
                }
                default:
                {
                    return
                        null;
                }
            }
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
                    if (CBHeight < 8)
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


                                decimal CBTotalWeight = 0;

                                foreach (var cbR in this.theReinforcements().ToList())
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
            switch (this.CBp1569Types)
            {
                case CBp1569Type.M_NoWing:
                {
                    if (CBHeight <= 8)
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
                case CBp1569Type.M1_OneWing:
                {
                    if (CBHeight <= 4)
                    {
                        switch (this.CBp1569Wings)
                        {
                            case CBp1569Wing.Three3:
                            {
                                const decimal wing = 3m;
                                return
                                    3.5m;
                            }
                            case CBp1569Wing.Six6:
                            {
                                const decimal wing = 6m;
                                        decimal T = 20.25m / 12m;
                                decimal S = .5m + wing / 10m;
                                decimal F = CBHeight - (T + S) + .5m;

                                        return
                                        //(
                                        2m * (CBLength + (CBWallThickness + 2m/12m)) * (CBWallThickness + 2m/12m) * S /*Long Wing Walls */;
                                        //2m * (CBLength + (CBWallThickness + 2m / 12m) + CBWidth) * (CBWallThickness + 2m / 12m) * S /*Transv Wing Walls */;

                                        //+ 2m * (CBLength + wing + 3m * CBWallThickness + CBWidth) * CBWallThickness * S /*S Bottom Walls */ 
                                        //+ CBLength * CBWidth * CBBaseThickness /* Sump Bottom */  
                                        //+ (wing * 20.025m / 20m + CBWallThickness) * CBWidth * .5m /* Wing Bottom */
                                        //) / 27m;
                                    }
                                case CBp1569Wing.Ten10:
                            {
                                const decimal wing = 11.5m;
                                return
                                    11.5m;
                            }
                            case CBp1569Wing.Seventeen17:
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
                    else if (CBHeight <= 8)
                    {
                        switch (this.CBp1569Wings)
                            {
                                case CBp1569Wing.Three3:
                                    {
                                        const decimal wing = 3.5m;
                                        return
                                            3.5m;
                                    }
                                case CBp1569Wing.Six6:
                                {
                                    const decimal wing = 6m;
                                    const decimal T = 20.25m/12m;
                                    decimal S = .5m + wing / 10m;
                                    decimal F = CBHeight - (T + S) + .5m;

                                    return
                                    (
                                        2m * (wing - (CBWallThickness + 2m / 12m)) * (CBWallThickness + 2m / 12m) * S  /*Long WingWalls*/
                                        + 1m * (18m / 12m + 2m * (CBWallThickness + 2m / 12m)) * (CBWallThickness + 2m / 12m) * S /*Short WingWalls*/                                         //2m * (15m/12m * (CBWallThickness + 2m/12m) * S) + /*Short SumpWalls*/
                                        + 2m * (CBWidth + 2m * (CBWallThickness + 2m / 12m)) * (CBWallThickness + 2m / 12m) * (F + S) /*Short SumpWalls*/
                                        + 2m * (CBLength) * (CBWallThickness + 2m / 12m) * (F + S) /*Long SumpWalls*/
                                        + wing * (decimal)Math.Sqrt(Math.Pow(1, 2) + Math.Pow(10, 2)) / 10m * 18m / 12m * .5m  /*Wing Bottom*/
                                        + CBLength * CBWidth * CBBaseThickness /*Sump Base*/
                                       ) / 27M; /*CY*/
                                }
                                case CBp1569Wing.Ten10:
                                    {
                                        const decimal wing = 11.5m;
                                        return
                                            11.5m;
                                    }
                                case CBp1569Wing.Seventeen17:
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
                case CBp1569Type.M2_TwoWing :
                {
                        const decimal wing = 6m;
                        const decimal T = 16m / 12m;
                        decimal S = .5m + wing / 10m;
                        decimal F = (decimal)this.CBHeight - (T + S);

                        return
                            (
                                (CBLength + 2m * (CBWallThickness + 2m / 12m)) * (CBWidth + 2M * (CBWallThickness + 2m / 12m)) * CBBaseThickness + /*Sump Base*/
                                2M * ((CBLength + 2M * (CBWallThickness + 2m / 12m)) + CBWidth) * (CBWallThickness + 2m / 12m) * (F) + /*Sump Walls*/
                                4m * ((wing + (CBWallThickness + 2m / 12m)) * (CBWallThickness + 2m / 12m) * S) + /*Long WingWalls*/
                                2m * (18m / 12m * (CBWallThickness + 2m / 12m) * S) + /*Short WingWalls*/
                                2m * (CBLength * (CBWallThickness + 2m / 12m) * S) + /*Long SumpWalls*/
                                2m * (15m / 12m * (CBWallThickness + 2m / 12m) * S) + /*Short SumpWalls*/
                                wing * (decimal)Math.Sqrt(Math.Pow(1, 2) + Math.Pow(10, 2)) / 10m * 18m / 12m * .5m  /*Wing Bottom*/
                            ) / 27M; /*CY*/
                }
                default:
                {
                    return
                        0;
                }
            }
        }
        public override decimal PourTop()
        {
            switch (this.CBp1569Types)
            {
                case CBp1569Type.M_NoWing:
                    {
                        if (CBHeight <= 4)
                        {
                            return
                                0;
                            //(2M * (CBLength + 2M * CBWallThickness + CBWidth) * CBWallThickness * (CBHeight +.5m - 2m) +/*Walls*/
                            //CBLength * CBWidth * .75m  /*Base*/) / 27M; /*CY*/
                        }
                        else if (CBHeight <= 8)
                        {
                            return
                                0;
                            //(2M * (CBLength + 2M * (CBWallThickness + 2m / 12m) + CBWidth) * (CBWallThickness + 2m / 12m) * (CBHeight +.5m - 2m) +/*Walls*/
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
                case CBp1569Type.M1_OneWing:
                    {
                        if (CBHeight <= 4)
                        {
                            switch (this.CBp1569Wings)
                            {
                                case CBp1569Wing.Three3:
                                    {
                                        const decimal wing = 3.5m;
                                        return
                                            3.5m;
                                    }
                                case CBp1569Wing.Six6:
                                    {
                                        const decimal wing = 6m;
                                        const decimal T = 20.25m / 12m;
                                        decimal S = .5m + wing / 10m;
                                        decimal F = CBHeight - (T + S) + .5m;

                                        return
                                        (
                                            2m * (wing - (CBWallThickness + 2m / 12m)) * (CBWallThickness + 2m / 12m) * T /*Long WingWalls*/
                                            + 1m * (18m / 12m + 2m * (CBWallThickness + 2m / 12m)) * (CBWallThickness + 2m / 12m) * T /*Short WingWalls*/                                         //2m * (15m/12m * (CBWallThickness + 2m/12m) * S) + /*Short SumpWalls*/
                                            + 2m * (CBWidth + 2m * (CBWallThickness + 2m / 12m)) * (CBWallThickness + 2m / 12m) * (T) /*Short SumpWalls*/
                                            + 2m * (CBLength) * (CBWallThickness + 2m / 12m) * (T) /*Long SumpWalls*/
                                            + wing  * (decimal)Math.Sqrt(Math.Pow(1, 2) + Math.Pow(10, 2)) / 10m * 18m / 12m * .5m  /*Wing Slab*/
                                            + CBLength * CBWidth * CBBaseThickness /*Sump Slab*/
                                           ) / 27M; /*CY*/
                                    }
                                case CBp1569Wing.Ten10:
                                    {
                                        const decimal wing = 11.5m;
                                        return
                                            11.5m;
                                    }
                                case CBp1569Wing.Seventeen17:
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
                        else if (CBHeight <= 8)
                        {
                            switch (this.CBp1569Wings)
                            {
                                case CBp1569Wing.Three3:
                                {
                                    const decimal wing = 3.5m;
                                    return
                                        3.5m;
                                }
                                case CBp1569Wing.Six6:
                                {
                                    const decimal wing = 6m;
                                    const decimal T = 20.25m / 12m;
                                    decimal S = .5m + wing / 10m;
                                    decimal F = CBHeight - (T + S) + .5m;

                                    return
                                    (
                                        2m * (wing - (CBWallThickness + 2m / 12m)) * (CBWallThickness + 2m / 12m) * T /*Long WingWalls*/
                                        + 1m * (18m / 12m + 2m * (CBWallThickness + 2m / 12m)) * (CBWallThickness + 2m / 12m) * T /*Short WingWalls*/                                         //2m * (15m/12m * (CBWallThickness + 2m/12m) * S) + /*Short SumpWalls*/
                                        + 2m * (CBWidth + 2m * (CBWallThickness + 2m / 12m)) * (CBWallThickness + 2m / 12m) * T /*Short SumpWalls*/
                                        + 2m * (CBLength) * (CBWallThickness + 2m / 12m) * (T) /*Long SumpWalls*/
                                        + wing * (18m / 12m + 2m * (CBWallThickness + 2m/12m)) * .5m  /*Wing Slab*/
                                        + (CBLength + 2m * (CBWallThickness + 2m / 12m)) * (CBWidth + 2m * (CBWallThickness + 2m / 12m)) * .5m /*Sump Slab*/
                                    ) / 27M; /*CY*/
                                }
                                case CBp1569Wing.Ten10:
                                    {
                                        const decimal wing = 11.5m;
                                        return
                                            11.5m;
                                    }
                                case CBp1569Wing.Seventeen17:
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
                case CBp1569Type.M2_TwoWing:
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
                        else if (CBHeight < 8)
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
    }
}
