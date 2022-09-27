using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmallStructuresTakeOffs.Enums;

namespace SmallStructuresTakeOffs.Models
{
    public class CBc1520T3 : CatchBasin
    {
        public override decimal CBLength { get => 2m + 11.75m/12m; set { decimal L = 2m + 11.75m/12m; } }
        public override decimal CBWidth { get; set; } = 2m + 11.5m / 12m;
        //{ get => 2m + 11.5m/12m; set { decimal W = 2m; } }
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

        //public override ICollection<CBreinforcement> CBreinforcements => throw new NotImplementedException();

        //private IList<CBreinforcement> cbReinf = new List<CBreinforcement>();

        public override ICollection<CBreinforcement> CBreinforcements
        {
            get => this.theReinforcements(); set => this.theReinforcements();
        }

        public override ICollection<CBreinforcement> theReinforcements()
        {
            IList<CBreinforcement> cbReinf = new List<CBreinforcement>();

            switch (this.CBConfg)
            {
                case CBConfig.SumpOnly:
                {
                    if (CBHeight <= 5)
                    {
                            cbReinf.Add(
                                new CBreinforcement
                                {
                                    CBId = CatchBasinId,
                                    CBRebarNom = RebarNomination.No4,
                                    CBreinfCode = "rb01",
                                    CBreinfQty = ((int)Math.Ceiling(CBHeight / 1.5m) + 1) * 2,
                                    CBreinfLength = CBLength + CBWallThickness + WingDict["Wing3'-6\""] + (5m / 12m),
                                    CBreinfShape = "Not Verified",
                                    TotalLength = (((int)Math.Ceiling(CBHeight / 1.5m) + 1) * 2) * (CBLength + CBWallThickness + WingDict["Wing3'-6\""] + (5m / 12m)),
                                    TotalWeight = (((int)Math.Ceiling(CBHeight / 1.5m) + 1) * 2) * (CBLength + CBWallThickness + WingDict["Wing3'-6\""] + (5m / 12m)) * .376m

                                });
                            cbReinf.Add(
                                new CBreinforcement
                                {
                                    CBId = CatchBasinId,
                                    CBRebarNom = RebarNomination.No4,
                                    CBreinfCode = "rb02",
                                    CBreinfQty = 3 * ((int)Math.Ceiling(CBHeight / 1.5m) + 1),
                                    CBreinfLength = 2m * (CBWidth + CBLength + 5m / 12m) + 2m,
                                    CBreinfShape = "Not Verified",
                                    TotalLength = (3 * ((int)Math.Ceiling(CBHeight / 1.5m) + 1)) * (CBWidth + 4m + 5m / 12m),
                                    TotalWeight = (3 * ((int)Math.Ceiling(CBHeight / 1.5m) + 1)) * (CBWidth + 4m + 5m / 12m) * .376m

                                });

                            return cbReinf;
                    }
                    else if (CBHeight <=8)
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
                                    TotalLength = (((int)Math.Ceiling(CBHeight / 1.5m) + 1) * 2) * (CBLength + CBWallThickness + WingDict["Wing3'-6\""] + (5m / 12m)),
                                    TotalWeight = (((int)Math.Ceiling(CBHeight / 1.5m) + 1) * 2) * (CBLength + CBWallThickness + WingDict["Wing3'-6\""] + (5m / 12m)) * .376m

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
                                    TotalLength = (3 * ((int)Math.Ceiling(CBHeight / 1.5m) + 1)) * (CBWidth + 4m + 5m / 12m),
                                    TotalWeight = (3 * ((int)Math.Ceiling(CBHeight / 1.5m) + 1)) * (CBWidth + 4m + 5m / 12m) * .376m

                                });

                        return cbReinf;
                    }
                    else
                    {
                        return
                            null;
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
                                    null;
                            }
                            case CBWing.w7ft6in:
                            {
                                const decimal wing = 7.5m;
                                decimal T = 1.5m + .5m;
                                decimal S = 0.5m + wing / 20m;
                                decimal F = CBHeight + .5m - (T + S);
                                    

                                cbReinf.Add(
                                    new CBreinforcement
                                    {
                                        CBId = CatchBasinId,
                                        CBRebarNom = RebarNomination.No4,
                                        CBreinfCode = "rb01",
                                        CBreinfQty = ((int)Math.Ceiling(F / 1.5m) + 1) * 2,
                                        CBreinfLength = CBLength + CBWallThickness + (5m / 12m),
                                        CBreinfShape = "Straight, horiz, sump",
                                        TotalLength = (((int)Math.Ceiling(F / 1.5m) + 1)) * 2 * (CBLength + CBWallThickness + (5m / 12m)),
                                        TotalWeight = (((int)Math.Ceiling(F / 1.5m) + 1)) * 2 * (CBLength + CBWallThickness + (5m / 12m)) * .668m
                                    });

                                cbReinf.Add(
                                    new CBreinforcement
                                    {
                                        CBId = CatchBasinId,
                                        CBRebarNom = RebarNomination.No4,
                                        CBreinfCode = "rb02",
                                        CBreinfQty = ((int)Math.Ceiling(CBHeight / 1.5m) + 1) + (int)Math.Ceiling(F / 1.5m) + (int)Math.Ceiling((S + T) / 1.5m),
                                        CBreinfLength = CBWidth + 4m + 5m / 12m,
                                        CBreinfShape = "C Shape, horiz, 2'-Overlap",
                                        TotalLength = (((int)Math.Ceiling(CBHeight / 1.5m) + 1) + (int)Math.Ceiling(F / 1.5m) + (int)Math.Ceiling((S + T) / 1.5m)) *
                                                (CBWidth + 4m + 5m / 12m),
                                        TotalWeight = (((int)Math.Ceiling(CBHeight / 1.5m) + 1) + (int)Math.Ceiling(F / 1.5m) + (int)Math.Ceiling((S + T) / 1.5m)) *
                                                (CBWidth + 4m + 5m / 12m) * .668m

                                    });

                                cbReinf.Add(
                                    new CBreinforcement
                                    {
                                        CBId = CatchBasinId,
                                        CBRebarNom = RebarNomination.No4,
                                        CBreinfCode = "rb03",
                                        CBreinfQty = 10,
                                        CBreinfLength = CBHeight + .5m - 5m / 12m,
                                        CBreinfShape = "L Shape, Vert, Sump, L=.5' x 5.58'",
                                        TotalLength = 10m * (CBHeight + .5m - 5m / 12m),
                                        TotalWeight = 10m * (CBHeight + .5m - 5m / 12m) * .668m

                                    });

                                cbReinf.Add(
                                    new CBreinforcement
                                    {
                                        CBId = CatchBasinId,
                                        CBRebarNom = RebarNomination.No4,
                                        CBreinfCode = "rb04",
                                        CBreinfQty = 14,
                                        CBreinfLength = (S + T) + .5m - 5m / 12m,
                                        CBreinfShape = "L Shape, Vert, Wing, L=.5' x 2.46'",
                                        TotalLength = 14m * ((S + T) + .5m - 5m / 12m),
                                        TotalWeight = 14m * ((S + T) + .5m - 5m / 12m) * .668m

                                    });

                                cbReinf.Add(
                                    new CBreinforcement
                                    {
                                        CBId = CatchBasinId,
                                        CBRebarNom = RebarNomination.No4,
                                        CBreinfCode = "rb05",
                                        CBreinfQty = ((int)Math.Ceiling((S + T) / 1.5m) + 1) * 2,
                                        CBreinfLength = (CBLength + 1m * CBWallThickness + WingDict["Wing7'-6\""] + 5m / 12m),
                                        CBreinfShape = "Straight, horiz, Sump & Wing",
                                        TotalLength = (((int)Math.Ceiling((S + T) / 1.5m) + 1) * 2) * ((CBLength + 1m * CBWallThickness + WingDict["Wing7'-6\""] + 5m / 12m)),
                                        TotalWeight = (((int)Math.Ceiling((S + T) / 1.5m) + 1) * 2) * ((CBLength + 1m * CBWallThickness + WingDict["Wing7'-6\""] + 5m / 12m)) * .668m

                                    });

                                cbReinf.Add(
                                    new CBreinforcement
                                    {
                                        CBId = CatchBasinId,
                                        CBRebarNom = RebarNomination.No3,
                                        CBreinfCode = "rb06",
                                        CBreinfQty = 11,
                                        CBreinfLength = (CBLength + 3m * CBWallThickness + WingDict["Wing7'-6\""] - 4m / 12m),
                                        CBreinfShape = "Straight, slab longitudinal, Sump & Wing",
                                        TotalLength = 11m * ((CBLength + 3m * CBWallThickness + WingDict["Wing7'-6\""] - 4m / 12m)),
                                        TotalWeight = (11m) * ((CBLength + 3m * CBWallThickness + WingDict["Wing7'-6\""] - 4m / 12m)) * .376m

                                    });

                                cbReinf.Add(
                                    new CBreinforcement
                                    {
                                        CBId = CatchBasinId,
                                        CBRebarNom = RebarNomination.No3,
                                        CBreinfCode = "rb07",
                                        CBreinfQty = 2,
                                        CBreinfLength = (CBLength + 2m * CBWallThickness - 4m / 12m),
                                        CBreinfShape = "Straight, slab-sump longitudinal, additional",
                                        TotalLength = 2m * (CBLength + 2m * CBWallThickness - 4m / 12m),
                                        TotalWeight = (2m) * (CBLength + 2m * CBWallThickness - 4m / 12m) * .376m

                                    });

                                cbReinf.Add(
                                    new CBreinforcement
                                    {
                                        CBId = CatchBasinId,
                                        CBRebarNom = RebarNomination.No3,
                                        CBreinfCode = "rb08",
                                        CBreinfQty = 24,
                                        CBreinfLength = CBWidth + 2m * CBWallThickness - 5.5m / 12m + ((decimal)Math.PI * 3m / 2m) / 12m + 6m / 12m,
                                        CBreinfShape = "Hooked, slab transverse",
                                        TotalLength = 24m * (CBWidth + 2m * CBWallThickness - 5.5m / 12m + ((decimal)Math.PI * 3m / 2m) / 12m + 6m / 12m),
                                        TotalWeight = (24m) * (CBWidth + 2m * CBWallThickness - 5.5m / 12m + ((decimal)Math.PI * 3m / 2m) / 12m + 6m / 12m) * .376m

                                    });

                                cbReinf.Add(
                                    new CBreinforcement
                                    {
                                        CBId = CatchBasinId,
                                        CBRebarNom = RebarNomination.No3,
                                        CBreinfCode = "rb09",
                                        CBreinfQty = 2,
                                        CBreinfLength = CBWidth + 2m * CBWallThickness - 4m / 12m,
                                        CBreinfShape = "Straight, slab transverse, additional",
                                        TotalLength = 2m * (CBWidth + 2m * CBWallThickness - 4m / 12m),
                                        TotalWeight = (2m) * (CBWidth + 2m * CBWallThickness - 4m / 12m) * .376m

                                    });

                                cbReinf.Add(
                                    new CBreinforcement
                                    {
                                        CBId = CatchBasinId,
                                        CBRebarNom = RebarNomination.No4,
                                        CBreinfCode = "rb10",
                                        CBreinfQty = 1,
                                        CBreinfLength = WingDict["Wing7'-6\""] * 20.025m / 20m - 4m / 12m,
                                        CBreinfShape = "Straight, wing bottom, longitudinal",
                                        TotalLength = 1m * (WingDict["Wing7'-6\""] * 20.025m / 20m - 4m / 12m),
                                        TotalWeight = (1m) * (WingDict["Wing7'-6\""] * 20.025m / 20m - 4m / 12m) * .668m

                                    });

                                cbReinf.Add(
                                    new CBreinforcement
                                    {
                                        CBId = CatchBasinId,
                                        CBRebarNom = RebarNomination.No4,
                                        CBreinfCode = "rb11",
                                        CBreinfQty = 6,
                                        CBreinfLength = CBWidth + 2m * CBWallThickness - 4m / 12m,
                                        CBreinfShape = "Straight, wing bottom, transverse",
                                        TotalLength = 6m * (CBWidth + 2m * CBWallThickness - 4m / 12m),
                                        TotalWeight = (6m) * (CBWidth + 2m * CBWallThickness - 4m / 12m) * .668m

                                    });

                                    return cbReinf;
                                }
                            case CBWing.w11ft6in:
                            {
                                const decimal wing = 11.5m;
                                decimal T = 1.5m + .5m;
                                decimal S = 0.5m + wing / 20m;
                                decimal F = CBHeight + .5m - (T + S);


                                cbReinf.Add(
                                    new CBreinforcement
                                    {
                                        CBId = CatchBasinId,
                                        CBRebarNom = RebarNomination.No4,
                                        CBreinfCode = "rb01",
                                        CBreinfQty = ((int)Math.Ceiling(F / 1.5m) + 1) * 2,
                                        CBreinfLength = CBLength + CBWallThickness + (5m / 12m),
                                        CBreinfShape = "Straight, horiz, sump",
                                        TotalLength = (((int)Math.Ceiling(F / 1.5m) + 1)) * 2 * (CBLength + CBWallThickness + (5m / 12m)),
                                        TotalWeight = (((int)Math.Ceiling(F / 1.5m) + 1)) * 2 * (CBLength + CBWallThickness + (5m / 12m)) * .668m
                                    });

                                cbReinf.Add(
                                    new CBreinforcement
                                    {
                                        CBId = CatchBasinId,
                                        CBRebarNom = RebarNomination.No4,
                                        CBreinfCode = "rb02",
                                        CBreinfQty = ((int)Math.Ceiling(CBHeight / 1.5m) + 1) + (int)Math.Ceiling(F / 1.5m) + (int)Math.Ceiling((S + T) / 1.5m),
                                        CBreinfLength = CBWidth + 4m + 5m / 12m,
                                        CBreinfShape = "C Shape, horiz, 2'-Overlap",
                                        TotalLength = (((int)Math.Ceiling(CBHeight / 1.5m) + 1) + (int)Math.Ceiling(F / 1.5m) + (int)Math.Ceiling((S + T) / 1.5m)) *
                                                (CBWidth + 4m + 5m / 12m),
                                        TotalWeight = (((int)Math.Ceiling(CBHeight / 1.5m) + 1) + (int)Math.Ceiling(F / 1.5m) + (int)Math.Ceiling((S + T) / 1.5m)) *
                                                (CBWidth + 4m + 5m / 12m) * .668m

                                    });

                                cbReinf.Add(
                                    new CBreinforcement
                                    {
                                        CBId = CatchBasinId,
                                        CBRebarNom = RebarNomination.No4,
                                        CBreinfCode = "rb03",
                                        CBreinfQty = 10,
                                        CBreinfLength = CBHeight + .5m - 5m / 12m,
                                        CBreinfShape = "L Shape, Vert, Sump, L=.5' x 5.58'",
                                        TotalLength = 10m * (CBHeight + .5m - 5m / 12m),
                                        TotalWeight = 10m * (CBHeight + .5m - 5m / 12m) * .668m

                                    });

                                cbReinf.Add(
                                    new CBreinforcement
                                    {
                                        CBId = CatchBasinId,
                                        CBRebarNom = RebarNomination.No4,
                                        CBreinfCode = "rb04",
                                        CBreinfQty = 14,
                                        CBreinfLength = (S + T) + .5m - 5m / 12m,
                                        CBreinfShape = "L Shape, Vert, Wing, L=.5' x 2.46'",
                                        TotalLength = 14m * ((S + T) + .5m - 5m / 12m),
                                        TotalWeight = 14m * ((S + T) + .5m - 5m / 12m) * .668m

                                    });

                                cbReinf.Add(
                                    new CBreinforcement
                                    {
                                        CBId = CatchBasinId,
                                        CBRebarNom = RebarNomination.No4,
                                        CBreinfCode = "rb05",
                                        CBreinfQty = ((int)Math.Ceiling((S + T) / 1.5m) + 1) * 2,
                                        CBreinfLength = (CBLength + 1m * CBWallThickness + WingDict["Wing7'-6\""] + 5m / 12m),
                                        CBreinfShape = "Straight, horiz, Sump & Wing",
                                        TotalLength = (((int)Math.Ceiling((S + T) / 1.5m) + 1) * 2) * ((CBLength + 1m * CBWallThickness + WingDict["Wing7'-6\""] + 5m / 12m)),
                                        TotalWeight = (((int)Math.Ceiling((S + T) / 1.5m) + 1) * 2) * ((CBLength + 1m * CBWallThickness + WingDict["Wing7'-6\""] + 5m / 12m)) * .668m

                                    });

                                cbReinf.Add(
                                    new CBreinforcement
                                    {
                                        CBId = CatchBasinId,
                                        CBRebarNom = RebarNomination.No3,
                                        CBreinfCode = "rb06",
                                        CBreinfQty = 11,
                                        CBreinfLength = (CBLength + 3m * CBWallThickness + WingDict["Wing7'-6\""] - 4m / 12m),
                                        CBreinfShape = "Straight, slab longitudinal, Sump & Wing",
                                        TotalLength = 11m * ((CBLength + 3m * CBWallThickness + WingDict["Wing7'-6\""] - 4m / 12m)),
                                        TotalWeight = (11m) * ((CBLength + 3m * CBWallThickness + WingDict["Wing7'-6\""] - 4m / 12m)) * .376m

                                    });

                                cbReinf.Add(
                                    new CBreinforcement
                                    {
                                        CBId = CatchBasinId,
                                        CBRebarNom = RebarNomination.No3,
                                        CBreinfCode = "rb07",
                                        CBreinfQty = 2,
                                        CBreinfLength = (CBLength + 2m * CBWallThickness - 4m / 12m),
                                        CBreinfShape = "Straight, slab-sump longitudinal, additional",
                                        TotalLength = 2m * (CBLength + 2m * CBWallThickness - 4m / 12m),
                                        TotalWeight = (2m) * (CBLength + 2m * CBWallThickness - 4m / 12m) * .376m

                                    });

                                cbReinf.Add(
                                    new CBreinforcement
                                    {
                                        CBId = CatchBasinId,
                                        CBRebarNom = RebarNomination.No3,
                                        CBreinfCode = "rb08",
                                        CBreinfQty = 24,
                                        CBreinfLength = CBWidth + 2m * CBWallThickness - 5.5m / 12m + ((decimal)Math.PI * 3m / 2m) / 12m + 6m / 12m,
                                        CBreinfShape = "Hooked, slab transverse",
                                        TotalLength = 24m * (CBWidth + 2m * CBWallThickness - 5.5m / 12m + ((decimal)Math.PI * 3m / 2m) / 12m + 6m / 12m),
                                        TotalWeight = (24m) * (CBWidth + 2m * CBWallThickness - 5.5m / 12m + ((decimal)Math.PI * 3m / 2m) / 12m + 6m / 12m) * .376m

                                    });

                                cbReinf.Add(
                                    new CBreinforcement
                                    {
                                        CBId = CatchBasinId,
                                        CBRebarNom = RebarNomination.No3,
                                        CBreinfCode = "rb09",
                                        CBreinfQty = 2,
                                        CBreinfLength = CBWidth + 2m * CBWallThickness - 4m / 12m,
                                        CBreinfShape = "Straight, slab transverse, additional",
                                        TotalLength = 2m * (CBWidth + 2m * CBWallThickness - 4m / 12m),
                                        TotalWeight = (2m) * (CBWidth + 2m * CBWallThickness - 4m / 12m) * .376m

                                    });

                                cbReinf.Add(
                                    new CBreinforcement
                                    {
                                        CBId = CatchBasinId,
                                        CBRebarNom = RebarNomination.No4,
                                        CBreinfCode = "rb10",
                                        CBreinfQty = 1,
                                        CBreinfLength = WingDict["Wing7'-6\""] * 20.025m / 20m - 4m / 12m,
                                        CBreinfShape = "Straight, wing bottom, longitudinal",
                                        TotalLength = 1m * (WingDict["Wing7'-6\""] * 20.025m / 20m - 4m / 12m),
                                        TotalWeight = (1m) * (WingDict["Wing7'-6\""] * 20.025m / 20m - 4m / 12m) * .668m

                                    });

                                cbReinf.Add(
                                    new CBreinforcement
                                    {
                                        CBId = CatchBasinId,
                                        CBRebarNom = RebarNomination.No4,
                                        CBreinfCode = "rb11",
                                        CBreinfQty = 6,
                                        CBreinfLength = CBWidth + 2m * CBWallThickness - 4m / 12m,
                                        CBreinfShape = "Straight, wing bottom, transverse",
                                        TotalLength = 6m * (CBWidth + 2m * CBWallThickness - 4m / 12m),
                                        TotalWeight = (6m) * (CBWidth + 2m * CBWallThickness - 4m / 12m) * .668m

                                    });

                                return cbReinf;
                            }
                            case CBWing.w19ft6in:
                            {
                                const decimal wing = 19.5m;
                                decimal T = 1.5m + .5m;
                                decimal S = 0.5m + wing / 20m;
                                decimal F = CBHeight + .5m - (T + S);


                                cbReinf.Add(
                                    new CBreinforcement
                                    {
                                        CBId = CatchBasinId,
                                        CBRebarNom = RebarNomination.No4,
                                        CBreinfCode = "rb01",
                                        CBreinfQty = ((int)Math.Ceiling(F / 1.5m) + 1) * 2,
                                        CBreinfLength = CBLength + CBWallThickness + (5m / 12m),
                                        CBreinfShape = "Straight, horiz, sump",
                                        TotalLength = (((int)Math.Ceiling(F / 1.5m) + 1)) * 2 * (CBLength + CBWallThickness + (5m / 12m)),
                                        TotalWeight = (((int)Math.Ceiling(F / 1.5m) + 1)) * 2 * (CBLength + CBWallThickness + (5m / 12m)) * .668m
                                    });

                                cbReinf.Add(
                                    new CBreinforcement
                                    {
                                        CBId = CatchBasinId,
                                        CBRebarNom = RebarNomination.No4,
                                        CBreinfCode = "rb02",
                                        CBreinfQty = ((int)Math.Ceiling(CBHeight / 1.5m) + 1) + (int)Math.Ceiling(F / 1.5m) + (int)Math.Ceiling((S + T) / 1.5m),
                                        CBreinfLength = CBWidth + 4m + 5m / 12m,
                                        CBreinfShape = "C Shape, horiz, 2'-Overlap",
                                        TotalLength = (((int)Math.Ceiling(CBHeight / 1.5m) + 1) + (int)Math.Ceiling(F / 1.5m) + (int)Math.Ceiling((S + T) / 1.5m)) *
                                                (CBWidth + 4m + 5m / 12m),
                                        TotalWeight = (((int)Math.Ceiling(CBHeight / 1.5m) + 1) + (int)Math.Ceiling(F / 1.5m) + (int)Math.Ceiling((S + T) / 1.5m)) *
                                                (CBWidth + 4m + 5m / 12m) * .668m

                                    });

                                cbReinf.Add(
                                    new CBreinforcement
                                    {
                                        CBId = CatchBasinId,
                                        CBRebarNom = RebarNomination.No4,
                                        CBreinfCode = "rb03",
                                        CBreinfQty = 10,
                                        CBreinfLength = CBHeight + .5m - 5m / 12m,
                                        CBreinfShape = "L Shape, Vert, Sump, L=.5' x 5.58'",
                                        TotalLength = 10m * (CBHeight + .5m - 5m / 12m),
                                        TotalWeight = 10m * (CBHeight + .5m - 5m / 12m) * .668m

                                    });

                                cbReinf.Add(
                                    new CBreinforcement
                                    {
                                        CBId = CatchBasinId,
                                        CBRebarNom = RebarNomination.No4,
                                        CBreinfCode = "rb04",
                                        CBreinfQty = 14,
                                        CBreinfLength = (S + T) + .5m - 5m / 12m,
                                        CBreinfShape = "L Shape, Vert, Wing, L=.5' x 2.46'",
                                        TotalLength = 14m * ((S + T) + .5m - 5m / 12m),
                                        TotalWeight = 14m * ((S + T) + .5m - 5m / 12m) * .668m

                                    });

                                cbReinf.Add(
                                    new CBreinforcement
                                    {
                                        CBId = CatchBasinId,
                                        CBRebarNom = RebarNomination.No4,
                                        CBreinfCode = "rb05",
                                        CBreinfQty = ((int)Math.Ceiling((S + T) / 1.5m) + 1) * 2,
                                        CBreinfLength = (CBLength + 1m * CBWallThickness + WingDict["Wing7'-6\""] + 5m / 12m),
                                        CBreinfShape = "Straight, horiz, Sump & Wing",
                                        TotalLength = (((int)Math.Ceiling((S + T) / 1.5m) + 1) * 2) * ((CBLength + 1m * CBWallThickness + WingDict["Wing7'-6\""] + 5m / 12m)),
                                        TotalWeight = (((int)Math.Ceiling((S + T) / 1.5m) + 1) * 2) * ((CBLength + 1m * CBWallThickness + WingDict["Wing7'-6\""] + 5m / 12m)) * .668m

                                    });

                                cbReinf.Add(
                                    new CBreinforcement
                                    {
                                        CBId = CatchBasinId,
                                        CBRebarNom = RebarNomination.No3,
                                        CBreinfCode = "rb06",
                                        CBreinfQty = 11,
                                        CBreinfLength = (CBLength + 3m * CBWallThickness + WingDict["Wing7'-6\""] - 4m / 12m),
                                        CBreinfShape = "Straight, slab longitudinal, Sump & Wing",
                                        TotalLength = 11m * ((CBLength + 3m * CBWallThickness + WingDict["Wing7'-6\""] - 4m / 12m)),
                                        TotalWeight = (11m) * ((CBLength + 3m * CBWallThickness + WingDict["Wing7'-6\""] - 4m / 12m)) * .376m

                                    });

                                cbReinf.Add(
                                    new CBreinforcement
                                    {
                                        CBId = CatchBasinId,
                                        CBRebarNom = RebarNomination.No3,
                                        CBreinfCode = "rb07",
                                        CBreinfQty = 2,
                                        CBreinfLength = (CBLength + 2m * CBWallThickness - 4m / 12m),
                                        CBreinfShape = "Straight, slab-sump longitudinal, additional",
                                        TotalLength = 2m * (CBLength + 2m * CBWallThickness - 4m / 12m),
                                        TotalWeight = (2m) * (CBLength + 2m * CBWallThickness - 4m / 12m) * .376m

                                    });

                                cbReinf.Add(
                                    new CBreinforcement
                                    {
                                        CBId = CatchBasinId,
                                        CBRebarNom = RebarNomination.No3,
                                        CBreinfCode = "rb08",
                                        CBreinfQty = 24,
                                        CBreinfLength = CBWidth + 2m * CBWallThickness - 5.5m / 12m + ((decimal)Math.PI * 3m / 2m) / 12m + 6m / 12m,
                                        CBreinfShape = "Hooked, slab transverse",
                                        TotalLength = 24m * (CBWidth + 2m * CBWallThickness - 5.5m / 12m + ((decimal)Math.PI * 3m / 2m) / 12m + 6m / 12m),
                                        TotalWeight = (24m) * (CBWidth + 2m * CBWallThickness - 5.5m / 12m + ((decimal)Math.PI * 3m / 2m) / 12m + 6m / 12m) * .376m

                                    });

                                cbReinf.Add(
                                    new CBreinforcement
                                    {
                                        CBId = CatchBasinId,
                                        CBRebarNom = RebarNomination.No3,
                                        CBreinfCode = "rb09",
                                        CBreinfQty = 2,
                                        CBreinfLength = CBWidth + 2m * CBWallThickness - 4m / 12m,
                                        CBreinfShape = "Straight, slab transverse, additional",
                                        TotalLength = 2m * (CBWidth + 2m * CBWallThickness - 4m / 12m),
                                        TotalWeight = (2m) * (CBWidth + 2m * CBWallThickness - 4m / 12m) * .376m

                                    });

                                cbReinf.Add(
                                    new CBreinforcement
                                    {
                                        CBId = CatchBasinId,
                                        CBRebarNom = RebarNomination.No4,
                                        CBreinfCode = "rb10",
                                        CBreinfQty = 1,
                                        CBreinfLength = WingDict["Wing7'-6\""] * 20.025m / 20m - 4m / 12m,
                                        CBreinfShape = "Straight, wing bottom, longitudinal",
                                        TotalLength = 1m * (WingDict["Wing7'-6\""] * 20.025m / 20m - 4m / 12m),
                                        TotalWeight = (1m) * (WingDict["Wing7'-6\""] * 20.025m / 20m - 4m / 12m) * .668m

                                    });

                                cbReinf.Add(
                                    new CBreinforcement
                                    {
                                        CBId = CatchBasinId,
                                        CBRebarNom = RebarNomination.No4,
                                        CBreinfCode = "rb11",
                                        CBreinfQty = 6,
                                        CBreinfLength = CBWidth + 2m * CBWallThickness - 4m / 12m,
                                        CBreinfShape = "Straight, wing bottom, transverse",
                                        TotalLength = 6m * (CBWidth + 2m * CBWallThickness - 4m / 12m),
                                        TotalWeight = (6m) * (CBWidth + 2m * CBWallThickness - 4m / 12m) * .668m

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
                    else if (CBHeight <= 8)
                    {
                        switch (this.CBwings)
                        {
                            case CBWing.w3ft6in:
                            {
                                const decimal wing = 3.5m;
                                return
                                    null;
                            }
                            case CBWing.w7ft6in:
                            {
                                const decimal wing = 7.5m;
                                decimal T = 1.5m + .5m;
                                decimal S = 0.5m + wing / 20m;
                                decimal F = CBHeight + .5m - (T + S);

                                cbReinf.Add(
                                    new CBreinforcement
                                    {
                                        CBId = CatchBasinId,
                                        CBRebarNom = RebarNomination.No4,
                                        CBreinfCode = "rb01",
                                        CBreinfQty = ((int)Math.Ceiling(F /1.5m) +1) * 2,
                                        CBreinfLength = CBLength + CBWallThickness + (5m/12m),
                                        CBreinfShape = "Straight, horiz, sump",
                                        TotalLength =  (((int)Math.Ceiling(F /1.5m) +1)) * 2 * (CBLength + CBWallThickness + (5m/12m)),
                                        TotalWeight =  (((int)Math.Ceiling(F /1.5m) +1)) * 2 * (CBLength + CBWallThickness + (5m/12m)) * .668m
                                    });

                                cbReinf.Add(
                                    new CBreinforcement
                                    {
                                        CBId = CatchBasinId,
                                        CBRebarNom = RebarNomination.No4,
                                        CBreinfCode = "rb02",
                                        CBreinfQty = ((int)Math.Ceiling(CBHeight /1.5m) +1)   + (int)Math.Ceiling(F/1.5m) + (int)Math.Ceiling((S+T)/1.5m),
                                        CBreinfLength = CBWidth + 4m + 5m/12m,
                                        CBreinfShape = "C Shape, horiz, 2'-Overlap",
                                        TotalLength =  (((int)Math.Ceiling(CBHeight /1.5m) +1)   + (int)Math.Ceiling(F/1.5m) + (int)Math.Ceiling((S+T)/1.5m)) *
                                                (CBWidth + 4m + 5m/12m),
                                        TotalWeight =  (((int)Math.Ceiling(CBHeight /1.5m) +1)   + (int)Math.Ceiling(F/1.5m) + (int)Math.Ceiling((S+T)/1.5m)) *
                                                (CBWidth + 4m + 5m/12m) * .668m

                                    });

                                cbReinf.Add(
                                    new CBreinforcement
                                    {
                                        CBId = CatchBasinId,
                                        CBRebarNom = RebarNomination.No4,
                                        CBreinfCode = "rb03",
                                        CBreinfQty = 10,
                                        CBreinfLength = CBHeight +.5m - 5m/12m,
                                        CBreinfShape = "L Shape, Vert, Sump, L=.5' x 5.58'",
                                        TotalLength = 10m * (CBHeight +.5m - 5m/12m),
                                        TotalWeight =  10m * (CBHeight +.5m - 5m/12m) * .668m

                                    });

                                cbReinf.Add(
                                    new CBreinforcement
                                    {
                                        CBId = CatchBasinId,
                                        CBRebarNom = RebarNomination.No4,
                                        CBreinfCode = "rb04",
                                        CBreinfQty = 14,
                                        CBreinfLength = (S + T) +.5m - 5m/12m,
                                        CBreinfShape = "L Shape, Vert, Wing, L=.5' x 2.46'",
                                        TotalLength = 14m * ((S + T) +.5m - 5m/12m),
                                        TotalWeight =  14m * ((S + T) +.5m - 5m/12m) * .668m

                                    });

                                cbReinf.Add(
                                    new CBreinforcement
                                    {
                                        CBId = CatchBasinId,
                                        CBRebarNom = RebarNomination.No4,
                                        CBreinfCode = "rb05",
                                        CBreinfQty = ((int)Math.Ceiling((S + T)/1.5m) +1) * 2,
                                        CBreinfLength =  (CBLength + 1m * CBWallThickness + WingDict["Wing7'-6\""] + 5m/12m),
                                        CBreinfShape = "Straight, horiz, Sump & Wing",
                                        TotalLength = (((int)Math.Ceiling((S + T)/1.5m) +1) * 2) * ((CBLength + 1m * CBWallThickness + WingDict["Wing7'-6\""] + 5m/12m)),
                                        TotalWeight =  (((int)Math.Ceiling((S + T)/1.5m) +1) * 2) * ((CBLength + 1m * CBWallThickness + WingDict["Wing7'-6\""] + 5m/12m)) * .668m

                                    });

                                cbReinf.Add(
                                    new CBreinforcement
                                    {
                                        CBId = CatchBasinId,
                                        CBRebarNom = RebarNomination.No3,
                                        CBreinfCode = "rb06",
                                        CBreinfQty = 11,
                                        CBreinfLength =  (CBLength + 3m * CBWallThickness + WingDict["Wing7'-6\""] - 4m/12m),
                                        CBreinfShape = "Straight, slab longitudinal, Sump & Wing",
                                        TotalLength = 11m * ((CBLength + 3m * CBWallThickness + WingDict["Wing7'-6\""] - 4m/12m)),
                                        TotalWeight =  (11m) * ((CBLength + 3m * CBWallThickness + WingDict["Wing7'-6\""] - 4m/12m)) * .376m

                                    });

                                cbReinf.Add(
                                    new CBreinforcement
                                    {
                                        CBId = CatchBasinId,
                                        CBRebarNom = RebarNomination.No3,
                                        CBreinfCode = "rb07",
                                        CBreinfQty = 2,
                                        CBreinfLength =  (CBLength + 2m * CBWallThickness - 4m/12m),
                                        CBreinfShape = "Straight, slab-sump longitudinal, additional",
                                        TotalLength = 2m * (CBLength + 2m * CBWallThickness - 4m/12m),
                                        TotalWeight =  (2m) * (CBLength + 2m * CBWallThickness - 4m/12m) * .376m

                                    });

                                cbReinf.Add(
                                    new CBreinforcement
                                    {
                                        CBId = CatchBasinId,
                                        CBRebarNom = RebarNomination.No3,
                                        CBreinfCode = "rb08",
                                        CBreinfQty = 24,
                                        CBreinfLength =  CBWidth + 2m * CBWallThickness - 5.5m/12m + ((decimal)Math.PI * 3m / 2m) / 12m + 6m/12m,
                                        CBreinfShape = "Hooked, slab transverse",
                                        TotalLength = 24m * (CBWidth + 2m * CBWallThickness - 5.5m/12m + ((decimal)Math.PI * 3m / 2m) / 12m + 6m/12m),
                                        TotalWeight =  (24m) * (CBWidth + 2m * CBWallThickness - 5.5m/12m + ((decimal)Math.PI * 3m / 2m) / 12m + 6m/12m) * .376m

                                    });

                                cbReinf.Add(
                                    new CBreinforcement
                                    {
                                        CBId = CatchBasinId,
                                        CBRebarNom = RebarNomination.No3,
                                        CBreinfCode = "rb09",
                                        CBreinfQty = 2,
                                        CBreinfLength =  CBWidth + 2m * CBWallThickness - 4m/12m,
                                        CBreinfShape = "Straight, slab transverse, additional",
                                        TotalLength = 2m * (CBWidth + 2m * CBWallThickness - 4m/12m),
                                        TotalWeight =  (2m) * (CBWidth + 2m * CBWallThickness - 4m/12m) * .376m

                                    });

                                cbReinf.Add(
                                    new CBreinforcement
                                    {
                                        CBId = CatchBasinId,
                                        CBRebarNom = RebarNomination.No4,
                                        CBreinfCode = "rb10",
                                        CBreinfQty = 1,
                                        CBreinfLength = WingDict["Wing7'-6\""] * 20.025m/20m -4m/12m,
                                        CBreinfShape = "Straight, wing bottom, longitudinal",
                                        TotalLength = 1m * (WingDict["Wing7'-6\""] * 20.025m/20m -4m/12m),
                                        TotalWeight =  (1m) * (WingDict["Wing7'-6\""] * 20.025m/20m -4m/12m) * .668m

                                    });

                                cbReinf.Add(
                                    new CBreinforcement
                                    {
                                        CBId = CatchBasinId,
                                        CBRebarNom = RebarNomination.No4,
                                        CBreinfCode = "rb11",
                                        CBreinfQty = 6,
                                        CBreinfLength =  CBWidth + 2m * CBWallThickness - 4m/12m,
                                        CBreinfShape = "Straight, wing bottom, transverse",
                                        TotalLength = 6m * (CBWidth + 2m * CBWallThickness - 4m/12m),
                                        TotalWeight =  (6m) * (CBWidth + 2m * CBWallThickness - 4m/12m) * .668m

                                    });

                                return cbReinf;
                            }
                            case CBWing.w11ft6in:
                            {
                                const decimal wing = 11.5m;
                                decimal T = 1.5m + .5m;
                                decimal S = 0.5m + wing / 20m;
                                decimal F = CBHeight + .5m - (T + S);

                                cbReinf.Add(
                                    new CBreinforcement
                                    {
                                        CBId = CatchBasinId,
                                        CBRebarNom = RebarNomination.No4,
                                        CBreinfCode = "rb01",
                                        CBreinfQty = ((int)Math.Ceiling(F / 1.5m) + 1) * 2,
                                        CBreinfLength = CBLength + CBWallThickness + (5m / 12m),
                                        CBreinfShape = "Straight, horiz, sump",
                                        TotalLength = (((int)Math.Ceiling(F / 1.5m) + 1)) * 2 * (CBLength + CBWallThickness + (5m / 12m)),
                                        TotalWeight = (((int)Math.Ceiling(F / 1.5m) + 1)) * 2 * (CBLength + CBWallThickness + (5m / 12m)) * .668m
                                    });

                                cbReinf.Add(
                                    new CBreinforcement
                                    {
                                        CBId = CatchBasinId,
                                        CBRebarNom = RebarNomination.No4,
                                        CBreinfCode = "rb02",
                                        CBreinfQty = ((int)Math.Ceiling(CBHeight / 1.5m) + 1) + (int)Math.Ceiling(F / 1.5m) + (int)Math.Ceiling((S + T) / 1.5m),
                                        CBreinfLength = CBWidth + 4m + 5m / 12m,
                                        CBreinfShape = "C Shape, horiz, 2'-Overlap",
                                        TotalLength = (((int)Math.Ceiling(CBHeight / 1.5m) + 1) + (int)Math.Ceiling(F / 1.5m) + (int)Math.Ceiling((S + T) / 1.5m)) *
                                                (CBWidth + 4m + 5m / 12m),
                                        TotalWeight = (((int)Math.Ceiling(CBHeight / 1.5m) + 1) + (int)Math.Ceiling(F / 1.5m) + (int)Math.Ceiling((S + T) / 1.5m)) *
                                                (CBWidth + 4m + 5m / 12m) * .668m

                                    });

                                cbReinf.Add(
                                    new CBreinforcement
                                    {
                                        CBId = CatchBasinId,
                                        CBRebarNom = RebarNomination.No4,
                                        CBreinfCode = "rb03",
                                        CBreinfQty = 10,
                                        CBreinfLength = CBHeight + .5m - 5m / 12m,
                                        CBreinfShape = "L Shape, Vert, Sump, L=.5' x 5.58'",
                                        TotalLength = 10m * (CBHeight + .5m - 5m / 12m),
                                        TotalWeight = 10m * (CBHeight + .5m - 5m / 12m) * .668m

                                    });

                                cbReinf.Add(
                                    new CBreinforcement
                                    {
                                        CBId = CatchBasinId,
                                        CBRebarNom = RebarNomination.No4,
                                        CBreinfCode = "rb04",
                                        CBreinfQty = 14,
                                        CBreinfLength = (S + T) + .5m - 5m / 12m,
                                        CBreinfShape = "L Shape, Vert, Wing, L=.5' x 2.46'",
                                        TotalLength = 14m * ((S + T) + .5m - 5m / 12m),
                                        TotalWeight = 14m * ((S + T) + .5m - 5m / 12m) * .668m

                                    });

                                cbReinf.Add(
                                    new CBreinforcement
                                    {
                                        CBId = CatchBasinId,
                                        CBRebarNom = RebarNomination.No4,
                                        CBreinfCode = "rb05",
                                        CBreinfQty = ((int)Math.Ceiling((S + T) / 1.5m) + 1) * 2,
                                        CBreinfLength = (CBLength + 1m * CBWallThickness + WingDict["Wing7'-6\""] + 5m / 12m),
                                        CBreinfShape = "Straight, horiz, Sump & Wing",
                                        TotalLength = (((int)Math.Ceiling((S + T) / 1.5m) + 1) * 2) * ((CBLength + 1m * CBWallThickness + WingDict["Wing7'-6\""] + 5m / 12m)),
                                        TotalWeight = (((int)Math.Ceiling((S + T) / 1.5m) + 1) * 2) * ((CBLength + 1m * CBWallThickness + WingDict["Wing7'-6\""] + 5m / 12m)) * .668m

                                    });

                                cbReinf.Add(
                                    new CBreinforcement
                                    {
                                        CBId = CatchBasinId,
                                        CBRebarNom = RebarNomination.No3,
                                        CBreinfCode = "rb06",
                                        CBreinfQty = 11,
                                        CBreinfLength = (CBLength + 3m * CBWallThickness + WingDict["Wing7'-6\""] - 4m / 12m),
                                        CBreinfShape = "Straight, slab longitudinal, Sump & Wing",
                                        TotalLength = 11m * ((CBLength + 3m * CBWallThickness + WingDict["Wing7'-6\""] - 4m / 12m)),
                                        TotalWeight = (11m) * ((CBLength + 3m * CBWallThickness + WingDict["Wing7'-6\""] - 4m / 12m)) * .376m

                                    });

                                cbReinf.Add(
                                    new CBreinforcement
                                    {
                                        CBId = CatchBasinId,
                                        CBRebarNom = RebarNomination.No3,
                                        CBreinfCode = "rb07",
                                        CBreinfQty = 2,
                                        CBreinfLength = (CBLength + 2m * CBWallThickness - 4m / 12m),
                                        CBreinfShape = "Straight, slab-sump longitudinal, additional",
                                        TotalLength = 2m * (CBLength + 2m * CBWallThickness - 4m / 12m),
                                        TotalWeight = (2m) * (CBLength + 2m * CBWallThickness - 4m / 12m) * .376m

                                    });

                                cbReinf.Add(
                                    new CBreinforcement
                                    {
                                        CBId = CatchBasinId,
                                        CBRebarNom = RebarNomination.No3,
                                        CBreinfCode = "rb08",
                                        CBreinfQty = 24,
                                        CBreinfLength = CBWidth + 2m * CBWallThickness - 5.5m / 12m + ((decimal)Math.PI * 3m / 2m) / 12m + 6m / 12m,
                                        CBreinfShape = "Hooked, slab transverse",
                                        TotalLength = 24m * (CBWidth + 2m * CBWallThickness - 5.5m / 12m + ((decimal)Math.PI * 3m / 2m) / 12m + 6m / 12m),
                                        TotalWeight = (24m) * (CBWidth + 2m * CBWallThickness - 5.5m / 12m + ((decimal)Math.PI * 3m / 2m) / 12m + 6m / 12m) * .376m

                                    });

                                cbReinf.Add(
                                    new CBreinforcement
                                    {
                                        CBId = CatchBasinId,
                                        CBRebarNom = RebarNomination.No3,
                                        CBreinfCode = "rb09",
                                        CBreinfQty = 2,
                                        CBreinfLength = CBWidth + 2m * CBWallThickness - 4m / 12m,
                                        CBreinfShape = "Straight, slab transverse, additional",
                                        TotalLength = 2m * (CBWidth + 2m * CBWallThickness - 4m / 12m),
                                        TotalWeight = (2m) * (CBWidth + 2m * CBWallThickness - 4m / 12m) * .376m

                                    });

                                cbReinf.Add(
                                    new CBreinforcement
                                    {
                                        CBId = CatchBasinId,
                                        CBRebarNom = RebarNomination.No4,
                                        CBreinfCode = "rb10",
                                        CBreinfQty = 1,
                                        CBreinfLength = WingDict["Wing7'-6\""] * 20.025m / 20m - 4m / 12m,
                                        CBreinfShape = "Straight, wing bottom, longitudinal",
                                        TotalLength = 1m * (WingDict["Wing7'-6\""] * 20.025m / 20m - 4m / 12m),
                                        TotalWeight = (1m) * (WingDict["Wing7'-6\""] * 20.025m / 20m - 4m / 12m) * .668m

                                    });

                                cbReinf.Add(
                                    new CBreinforcement
                                    {
                                        CBId = CatchBasinId,
                                        CBRebarNom = RebarNomination.No4,
                                        CBreinfCode = "rb11",
                                        CBreinfQty = 6,
                                        CBreinfLength = CBWidth + 2m * CBWallThickness - 4m / 12m,
                                        CBreinfShape = "Straight, wing bottom, transverse",
                                        TotalLength = 6m * (CBWidth + 2m * CBWallThickness - 4m / 12m),
                                        TotalWeight = (6m) * (CBWidth + 2m * CBWallThickness - 4m / 12m) * .668m

                                    });

                                return cbReinf;

                            }
                            case CBWing.w19ft6in:
                            {
                                const decimal wing = 19.5m;
                                decimal T = 1.5m + .5m;
                                decimal S = 0.5m + wing / 20m;
                                decimal F = CBHeight + .5m - (T + S);

                                cbReinf.Add(
                                    new CBreinforcement
                                    {
                                        CBId = CatchBasinId,
                                        CBRebarNom = RebarNomination.No4,
                                        CBreinfCode = "rb01",
                                        CBreinfQty = ((int)Math.Ceiling(F / 1.5m) + 1) * 2,
                                        CBreinfLength = CBLength + CBWallThickness + (5m / 12m),
                                        CBreinfShape = "Straight, horiz, sump",
                                        TotalLength = (((int)Math.Ceiling(F / 1.5m) + 1)) * 2 * (CBLength + CBWallThickness + (5m / 12m)),
                                        TotalWeight = (((int)Math.Ceiling(F / 1.5m) + 1)) * 2 * (CBLength + CBWallThickness + (5m / 12m)) * .668m
                                    });

                                cbReinf.Add(
                                    new CBreinforcement
                                    {
                                        CBId = CatchBasinId,
                                        CBRebarNom = RebarNomination.No4,
                                        CBreinfCode = "rb02",
                                        CBreinfQty = ((int)Math.Ceiling(CBHeight / 1.5m) + 1) + (int)Math.Ceiling(F / 1.5m) + (int)Math.Ceiling((S + T) / 1.5m),
                                        CBreinfLength = CBWidth + 4m + 5m / 12m,
                                        CBreinfShape = "C Shape, horiz, 2'-Overlap",
                                        TotalLength = (((int)Math.Ceiling(CBHeight / 1.5m) + 1) + (int)Math.Ceiling(F / 1.5m) + (int)Math.Ceiling((S + T) / 1.5m)) *
                                                (CBWidth + 4m + 5m / 12m),
                                        TotalWeight = (((int)Math.Ceiling(CBHeight / 1.5m) + 1) + (int)Math.Ceiling(F / 1.5m) + (int)Math.Ceiling((S + T) / 1.5m)) *
                                                (CBWidth + 4m + 5m / 12m) * .668m

                                    });

                                cbReinf.Add(
                                    new CBreinforcement
                                    {
                                        CBId = CatchBasinId,
                                        CBRebarNom = RebarNomination.No4,
                                        CBreinfCode = "rb03",
                                        CBreinfQty = 10,
                                        CBreinfLength = CBHeight + .5m - 5m / 12m,
                                        CBreinfShape = "L Shape, Vert, Sump, L=.5' x 5.58'",
                                        TotalLength = 10m * (CBHeight + .5m - 5m / 12m),
                                        TotalWeight = 10m * (CBHeight + .5m - 5m / 12m) * .668m

                                    });

                                cbReinf.Add(
                                    new CBreinforcement
                                    {
                                        CBId = CatchBasinId,
                                        CBRebarNom = RebarNomination.No4,
                                        CBreinfCode = "rb04",
                                        CBreinfQty = 14,
                                        CBreinfLength = (S + T) + .5m - 5m / 12m,
                                        CBreinfShape = "L Shape, Vert, Wing, L=.5' x 2.46'",
                                        TotalLength = 14m * ((S + T) + .5m - 5m / 12m),
                                        TotalWeight = 14m * ((S + T) + .5m - 5m / 12m) * .668m

                                    });

                                cbReinf.Add(
                                    new CBreinforcement
                                    {
                                        CBId = CatchBasinId,
                                        CBRebarNom = RebarNomination.No4,
                                        CBreinfCode = "rb05",
                                        CBreinfQty = ((int)Math.Ceiling((S + T) / 1.5m) + 1) * 2,
                                        CBreinfLength = (CBLength + 1m * CBWallThickness + WingDict["Wing7'-6\""] + 5m / 12m),
                                        CBreinfShape = "Straight, horiz, Sump & Wing",
                                        TotalLength = (((int)Math.Ceiling((S + T) / 1.5m) + 1) * 2) * ((CBLength + 1m * CBWallThickness + WingDict["Wing7'-6\""] + 5m / 12m)),
                                        TotalWeight = (((int)Math.Ceiling((S + T) / 1.5m) + 1) * 2) * ((CBLength + 1m * CBWallThickness + WingDict["Wing7'-6\""] + 5m / 12m)) * .668m

                                    });

                                cbReinf.Add(
                                    new CBreinforcement
                                    {
                                        CBId = CatchBasinId,
                                        CBRebarNom = RebarNomination.No3,
                                        CBreinfCode = "rb06",
                                        CBreinfQty = 11,
                                        CBreinfLength = (CBLength + 3m * CBWallThickness + WingDict["Wing7'-6\""] - 4m / 12m),
                                        CBreinfShape = "Straight, slab longitudinal, Sump & Wing",
                                        TotalLength = 11m * ((CBLength + 3m * CBWallThickness + WingDict["Wing7'-6\""] - 4m / 12m)),
                                        TotalWeight = (11m) * ((CBLength + 3m * CBWallThickness + WingDict["Wing7'-6\""] - 4m / 12m)) * .376m

                                    });

                                cbReinf.Add(
                                    new CBreinforcement
                                    {
                                        CBId = CatchBasinId,
                                        CBRebarNom = RebarNomination.No3,
                                        CBreinfCode = "rb07",
                                        CBreinfQty = 2,
                                        CBreinfLength = (CBLength + 2m * CBWallThickness - 4m / 12m),
                                        CBreinfShape = "Straight, slab-sump longitudinal, additional",
                                        TotalLength = 2m * (CBLength + 2m * CBWallThickness - 4m / 12m),
                                        TotalWeight = (2m) * (CBLength + 2m * CBWallThickness - 4m / 12m) * .376m

                                    });

                                cbReinf.Add(
                                    new CBreinforcement
                                    {
                                        CBId = CatchBasinId,
                                        CBRebarNom = RebarNomination.No3,
                                        CBreinfCode = "rb08",
                                        CBreinfQty = 24,
                                        CBreinfLength = CBWidth + 2m * CBWallThickness - 5.5m / 12m + ((decimal)Math.PI * 3m / 2m) / 12m + 6m / 12m,
                                        CBreinfShape = "Hooked, slab transverse",
                                        TotalLength = 24m * (CBWidth + 2m * CBWallThickness - 5.5m / 12m + ((decimal)Math.PI * 3m / 2m) / 12m + 6m / 12m),
                                        TotalWeight = (24m) * (CBWidth + 2m * CBWallThickness - 5.5m / 12m + ((decimal)Math.PI * 3m / 2m) / 12m + 6m / 12m) * .376m

                                    });

                                cbReinf.Add(
                                    new CBreinforcement
                                    {
                                        CBId = CatchBasinId,
                                        CBRebarNom = RebarNomination.No3,
                                        CBreinfCode = "rb09",
                                        CBreinfQty = 2,
                                        CBreinfLength = CBWidth + 2m * CBWallThickness - 4m / 12m,
                                        CBreinfShape = "Straight, slab transverse, additional",
                                        TotalLength = 2m * (CBWidth + 2m * CBWallThickness - 4m / 12m),
                                        TotalWeight = (2m) * (CBWidth + 2m * CBWallThickness - 4m / 12m) * .376m

                                    });

                                cbReinf.Add(
                                    new CBreinforcement
                                    {
                                        CBId = CatchBasinId,
                                        CBRebarNom = RebarNomination.No4,
                                        CBreinfCode = "rb10",
                                        CBreinfQty = 1,
                                        CBreinfLength = WingDict["Wing7'-6\""] * 20.025m / 20m - 4m / 12m,
                                        CBreinfShape = "Straight, wing bottom, longitudinal",
                                        TotalLength = 1m * (WingDict["Wing7'-6\""] * 20.025m / 20m - 4m / 12m),
                                        TotalWeight = (1m) * (WingDict["Wing7'-6\""] * 20.025m / 20m - 4m / 12m) * .668m

                                    });

                                cbReinf.Add(
                                    new CBreinforcement
                                    {
                                        CBId = CatchBasinId,
                                        CBRebarNom = RebarNomination.No4,
                                        CBreinfCode = "rb11",
                                        CBreinfQty = 6,
                                        CBreinfLength = CBWidth + 2m * CBWallThickness - 4m / 12m,
                                        CBreinfShape = "Straight, wing bottom, transverse",
                                        TotalLength = 6m * (CBWidth + 2m * CBWallThickness - 4m / 12m),
                                        TotalWeight = (6m) * (CBWidth + 2m * CBWallThickness - 4m / 12m) * .668m

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
                    else
                    {
                        return
                            null;
                        //(2M * (CBLength + 2M * (CBWallThickness + 2m / 12m) + CBWidth) * (CBWallThickness + 2m / 12m) * (CBHeight +.5m - 2m) +/*Walls*/
                        //CBLength * CBWidth * .75m  /*Base*/) / 27M; /*CY*/
                    }
                }
                case CBConfig.DoubleWing:
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
            switch (this.CBConfg)
            {
                case CBConfig.SumpOnly:
                {
                    if (CBHeight <= 5)
                    {
                            decimal T = 1.5m + .5m;
                            decimal S = 0;
                            decimal F = CBHeight + .5m - (T + S);

                            return
                                (2m * (CBLength + 2m * CBWallThickness + CBWidth) * CBWallThickness * (F + S) + /*F + S Bottom Walls */
                                + CBLength * CBWidth * CBBaseThickness) / 27m;/* Sump Bottom */
                    }
                    else if (CBHeight <= 8)
                    {
                            decimal T = 1.5m + .5m;
                            decimal S = 0;
                            decimal F = CBHeight + .5m - (T + S);


                            return
                                (2M * (CBLength + 2M * CBWallThickness + CBWidth) * CBWallThickness * (F + S) +/*Walls*/
                            CBLength * CBWidth * .75m  /*Base*/) / 27M; /*CY*/
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
                            case CBWing.w7ft6in:
                            {
                                const decimal wing = 7.5m;
                                decimal T = 1.5m + .5m;
                                decimal S = CBHeight + 0.5m - T;
                                decimal F = 0;

                                return
                                    (2m * (CBLength + 2m * CBWallThickness + CBWidth) * CBWallThickness * F  /*F Bottom Walls => None*/
                                    + 2m * (CBLength + wing + 3m * CBWallThickness + CBWidth) * CBWallThickness * S  /*S Bottom Walls */
                                    + CBLength * CBWidth * CBBaseThickness  /* Sump Bottom */
                                    + (wing * 20.025m / 20m + CBWallThickness) * CBWidth * .5m /* Wing Bottom */
                                    ) / 27m; /*cy*/
                            }
                                case CBWing.w11ft6in:
                            {
                                const decimal wing = 11.5m;
                                decimal T = 1.5m + .5m;
                                decimal S = CBHeight + 0.5m - T;
                                decimal F = 0;

                                return
                                    (2m * (CBLength + 2m * CBWallThickness + CBWidth) * CBWallThickness * F  /*F Bottom Walls => None*/
                                    + 2m * (CBLength + wing + 3m * CBWallThickness + CBWidth) * CBWallThickness * S  /*S Bottom Walls */
                                    + CBLength * CBWidth * CBBaseThickness  /* Sump Bottom */
                                    + (wing * 20.025m / 20m + CBWallThickness) * CBWidth * .5m /* Wing Bottom */
                                    ) / 27m; /*cy*/

                            }
                            case CBWing.w19ft6in:
                            {
                                const decimal wing = 19.5m;
                                decimal T = 1.5m + .5m;
                                decimal S = .5m + wing / 20m;
                                decimal F = CBHeight + 0.5m - (T + S);


                                return
                                    (2m * (CBLength + 2m * CBWallThickness + CBWidth) * CBWallThickness * F  /*F Bottom Walls => None*/
                                    + 2m * (CBLength + wing + 3m * CBWallThickness + CBWidth) * CBWallThickness * S  /*S Bottom Walls */
                                    + CBLength * CBWidth * CBBaseThickness  /* Sump Bottom */
                                    + (wing * 20.025m / 20m + CBWallThickness) * CBWidth * .5m /* Wing Bottom */
                                    ) / 27m; /*cy*/
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
                                const decimal wing = 7.5m;
                                decimal T = 1.5m + .5m;
                                decimal S = .5m + wing / 20m;
                                decimal F = CBHeight + 0.5m - (T + S);

                                return
                                    (2m * (CBLength + 2m * CBWallThickness + CBWidth) * CBWallThickness * F /*F Sump Walls */
                                    + 2m * (CBLength + wing + 3m * CBWallThickness + CBWidth) * CBWallThickness * S /*S Bottom Walls */
                                    + CBLength * CBWidth * CBBaseThickness /* Sump Bottom */
                                    + (wing * 20.025m / 20m + CBWallThickness) * CBWidth * .5m /* Wing Bottom */
                                    ) / 27m;/* cy */
                            }
                                case CBWing.w11ft6in:
                            {
                                const decimal wing = 11.5m;
                                decimal T = 1.5m + .5m;
                                decimal S = .5m + wing / 20m;
                                decimal F = CBHeight + 0.5m - (T + S);


                                return
                                    (2m * (CBLength + 2m * CBWallThickness + CBWidth) * CBWallThickness * F /*F Sump Walls */
                                    + 2m * (CBLength + wing + 3m * CBWallThickness + CBWidth) * CBWallThickness * S /*S Bottom Walls */
                                    + CBLength * CBWidth * CBBaseThickness /* Sump Bottom */
                                    + (wing * 20.025m / 20m + CBWallThickness) * CBWidth * .5m /* Wing Bottom */
                                    ) / 27m;/* cy */
                            }
                            case CBWing.w19ft6in:
                            {
                                const decimal wing = 19.5m;
                                decimal T = 1.5m + .5m;
                                decimal S = .5m + wing / 20m;
                                decimal F = CBHeight + 0.5m - (T + S);


                                return
                                    (2m * (CBLength + 2m * CBWallThickness + CBWidth) * CBWallThickness * F /*F Sump Walls */
                                    + 2m * (CBLength + wing + 3m * CBWallThickness + CBWidth) * CBWallThickness * S /*S Bottom Walls */
                                    + CBLength * CBWidth * CBBaseThickness /* Sump Bottom */
                                    + (wing * 20.025m / 20m + CBWallThickness) * CBWidth * .5m /* Wing Bottom */
                                    ) / 27m;/* cy */
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
        public override decimal PourTop()
        {
            switch (this.CBConfg)
            {
                case CBConfig.SumpOnly:
                {
                    if (CBHeight <= 5)
                    {
                            decimal wing = 0;
                            decimal T = 1.5m + .5m;
                            decimal S = 0;
                            decimal F = CBHeight - (T + S);


                            return
                            (2m * (CBLength + wing + 2m * CBWallThickness + CBWidth) * CBWallThickness * T /*T Walls */
                            + (CBLength) * (CBWidth) * .5m /*Top Slab */
                            + (CBLength + 2m * CBWallThickness) * 2.5m * 7m / 12m /* Gutter Width */
                            ) / 27m; /*


                            //(2M * (CBLength + 2M * CBWallThickness + CBWidth) * CBWallThickness * (CBHeight +.5m - 2m) +/*Walls*/
                            //CBLength * CBWidth * .75m  /*Base*/) / 27M; /*CY*/


                            //(/*F Bottom Walls */ 2m * (CBLength + 2m * CBWallThickness + CBWidth) * CBWallThickness * F +
                            ///*S Bottom Walls */ 2m * (CBLength + wing + 3m * CBWallThickness + CBWidth) * CBWallThickness * S +
                            ///* Sump Bottom */ CBLength * CBWidth * CBBaseThickness +
                            ///* Wing Bottom */ (wing * 20.025m / 20m + CBWallThickness) * CBWidth * .5m) / 27m;
                            //7.5m; Test
                        }
                    else if (CBHeight <= 8)
                    {
                            decimal T = 1.5m + .5m;
                            decimal S = 0;
                            decimal F = CBHeight - (T + S);


                            return
                                (2M * (CBLength + 2M * CBWallThickness + CBWidth) * CBWallThickness * ( T) +/*Walls*/
                                (CBLength ) * (CBWidth ) * .5m + /*Top Slab */
                                (CBLength + 2m * CBWallThickness) * 2.5m * 7m / 12m) / 27m; /* Gutter Width */

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
                            case CBWing.w7ft6in:
                            {
                                const decimal wing = 7.5m;
                                decimal T = 1.5m + .5m;
                                decimal S = CBHeight + 0.5m - T;
                                decimal F = 0;

                                return
                                    (2m * (CBLength + wing + 3m * CBWallThickness + CBWidth) * CBWallThickness * T /*T Walls */
                                    + (CBLength + CBWallThickness + wing) * CBWidth * .5m /*Toop Slab */
                                    + (CBLength + wing + 3m * CBWallThickness) * 2.5m * 7m / 12m /* Gutter Width */
                                    ) / 27m;/* cy */

                            }
                            case CBWing.w11ft6in:
                            {
                                const decimal wing = 11.5m;
                                decimal T = 1.5m + .5m;
                                decimal S = CBHeight + 0.5m - T;
                                decimal F = 0;

                                return
                                    (2m * (CBLength + wing + 3m * CBWallThickness + CBWidth) * CBWallThickness * T /*T Walls */
                                    + (CBLength + CBWallThickness + wing) * CBWidth * .5m /*Toop Slab */
                                    + (CBLength + wing + 3m * CBWallThickness) * 2.5m * 7m / 12m /* Gutter Width */
                                    ) / 27m;/* cy */

                            }
                            case CBWing.w19ft6in:
                            {
                                const decimal wing = 19.5m;
                                decimal T = 1.5m + .5m;
                                decimal S = CBHeight + 0.5m - T;
                                decimal F = 0;

                                return
                                    (2m * (CBLength + wing + 3m * CBWallThickness + CBWidth) * CBWallThickness * T /*T Walls */
                                    + (CBLength + CBWallThickness + wing) * CBWidth * .5m /*Toop Slab */
                                    + (CBLength + wing + 3m * CBWallThickness) * 2.5m * 7m / 12m /* Gutter Width */
                                    ) / 27m;/* cy */

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
                                const decimal wing = 7.5m;
                                decimal T = 1.5m + .5m;

                                return
                                    (2m * (CBLength + wing + 3m * CBWallThickness + CBWidth) * CBWallThickness * T /*T Walls */
                                    + (CBLength + CBWallThickness + wing) * CBWidth * .5m /*Toop Slab */
                                    + (CBLength + wing + 3m * CBWallThickness) * 2.5m * 7m/12m /* Gutter Width */
                                    ) / 27m;/* cy */
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
                                decimal T = 1.5m + .5m;

                                return
                                    (2m * (CBLength + wing + 3m * CBWallThickness + CBWidth) * CBWallThickness * T /*T Walls */
                                    + (CBLength + CBWallThickness + wing) * CBWidth * .5m /*Toop Slab */
                                    + (CBLength + wing + 3m * CBWallThickness) * 2.5m * 7m / 12m /* Gutter Width */
                                    ) / 27m;/* cy */
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
