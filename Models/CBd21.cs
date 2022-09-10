using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmallStructuresTakeOffs.Models
{
    public class CBd21 : CatchBasin
    {
        public override decimal CBLength
        {
            get => 5m + (6m + 5m / 8m) / 12m; 
            set
            {
                decimal L = 3m;
            }
        }
        public override decimal CBWidth { get => 3m; set { decimal W = 2m; } }
        public override decimal CBBaseThickness { get => 1m; set { decimal T = .5m; } }
        public override decimal CBWallThickness { get => 1m; set { decimal T = .5m; } }
        public override int CBVertBars { get => 14; set { decimal Bars = 14m; } }

        public override decimal CBSqRingL { get => (CBLength + CBWidth + 1m/3m) * 2 + 1; set { decimal R = (CBLength + CBWidth + 1m/3m) * 2 + 1; } }

        public override ICollection<CBreinforcement> CBreinforcements
        {
            get => this.theReinforcements(); set => this.theReinforcements();
        }

        public override ICollection<CBreinforcement> theReinforcements()
        {
            IList<CBreinforcement> cbReinf = new List<CBreinforcement>();

            cbReinf.Add(
                new CBreinforcement
                {
                    CBId = CatchBasinId,
                    CBRebarNom = RebarNomination.No4,
                    CBreinfCode = "rb01",
                    CBreinfQty = 38,
                    CBreinfLength = CBHeight + CBBaseThickness - (5m/12m) + 1m,
                    CBreinfShape = "L Shape (12\" x Long = Length, Vertical, Inside and Outside",
                    TotalLength =  (38m) *  (CBHeight + CBBaseThickness - (5m / 12m) + 1m),
                    TotalWeight =  (38m) *  (CBHeight + CBBaseThickness - (5m / 12m) + 1m) * .668m
                });
            cbReinf.Add(
                new CBreinforcement
                {
                    CBId = CatchBasinId,
                    CBRebarNom = RebarNomination.No4,
                    CBreinfCode = "rb02",
                    CBreinfQty = 2 * ((int)Math.Ceiling(CBHeight + CBBaseThickness) +1 + 2),
                    CBreinfLength = CBLength + 2m * 1.5m/12m,
                    CBreinfShape = "Straight Horizontal, Inside Wall",
                    TotalLength =  (2 * ((int)Math.Ceiling(CBHeight + CBBaseThickness) +1 + 2)) * (CBLength + 2m * 1.5m/12m),
                    TotalWeight =  (2 * ((int)Math.Ceiling(CBHeight + CBBaseThickness) +1 + 2)) * (CBLength + 2m * 1.5m/12m) * .668m
                });
            cbReinf.Add(
                new CBreinforcement
                {
                    CBId = CatchBasinId,
                    CBRebarNom = RebarNomination.No4,
                    CBreinfCode = "rb03",
                    CBreinfQty = 2 * ((int)Math.Ceiling(CBHeight + CBBaseThickness) +1 + 2),
                    CBreinfLength = CBLength + 2m * CBWallThickness - 2m * 1.5m / 12m,
                    CBreinfShape = "Straight Horizontal, Outside Wall",
                    TotalLength = (2 * ((int)Math.Ceiling(CBHeight + CBBaseThickness) +1 + 2)) * (CBLength + 2m * CBWallThickness - 2m * 1.5m / 12m),
                    TotalWeight = (2 * ((int)Math.Ceiling(CBHeight + CBBaseThickness) +1 + 2)) * (CBLength + 2m * CBWallThickness - 2m * 1.5m / 12m) * .668m
                });
            cbReinf.Add(
                new CBreinforcement
                {
                    CBId = CatchBasinId,
                    CBRebarNom = RebarNomination.No4,
                    CBreinfCode = "rb04",
                    CBreinfQty = 2 * ((int)Math.Ceiling(CBHeight + CBBaseThickness) + 1),
                    CBreinfLength = 2m * (CBWidth + 2m * CBWallThickness - 2m * 1.5m / 12m),
                    CBreinfShape = "C Shape Horizontal Outside Wall, 24\"-Overlap",
                    TotalLength = (2 * ((int)Math.Ceiling(CBHeight + CBBaseThickness) + 1)) * (2m * (CBWidth + 2m * CBWallThickness - 2m * 1.5m / 12m)),
                    TotalWeight = (2 * ((int)Math.Ceiling(CBHeight + CBBaseThickness) + 1)) * (2m * (CBWidth + 2m * CBWallThickness - 2m * 1.5m / 12m)) * .668m
                });
            cbReinf.Add(
                new CBreinforcement
                {
                    CBId = CatchBasinId,
                    CBRebarNom = RebarNomination.No4,
                    CBreinfCode = "rb05",
                    CBreinfQty = 2 * ((int)Math.Ceiling(CBHeight + CBBaseThickness) + 1),
                    CBreinfLength = 2m * (CBWidth + 2m * 1.5m / 12m),
                    CBreinfShape = "C Shape Horizontal Inside Wall, 24\"-Overlap",
                    TotalLength = (2 * ((int)Math.Ceiling(CBHeight + CBBaseThickness) + 1)) * (2m * (CBWidth + 2m * 1.5m / 12m)),
                    TotalWeight = (2 * ((int)Math.Ceiling(CBHeight + CBBaseThickness) + 1)) * (2m * (CBWidth + 2m * 1.5m / 12m)) * .668m
                });
            cbReinf.Add(
                new CBreinforcement
                {
                    CBId = CatchBasinId,
                    CBRebarNom = RebarNomination.No5,
                    CBreinfCode = "rb06",
                    CBreinfQty = 14,
                    CBreinfLength = CBLength + 2m * CBWallThickness + 8m/12 - 2m * 1.5m / 12m,
                    CBreinfShape = "Longitudinal Straight T&B, at Base",
                    TotalLength = (14m) * (CBLength + 2m * CBWallThickness + 8m / 12 - 2m * 1.5m / 12m),
                    TotalWeight = (14m) * (CBLength + 2m * CBWallThickness + 8m / 12 - 2m * 1.5m / 12m) * .668m
                });

            cbReinf.Add(
                new CBreinforcement
                {
                    CBId = CatchBasinId,
                    CBRebarNom = RebarNomination.No5,
                    CBreinfCode = "rb07",
                    CBreinfQty = 18,
                    CBreinfLength = CBWidth + 2m * CBWallThickness + 8m / 12 - 2m * 1.5m / 12m,
                    CBreinfShape = "Longitudinal Straight T&B, at Base",
                    TotalLength = (18m) * (CBWidth + 2m * CBWallThickness + 8m / 12 - 2m * 1.5m / 12m),
                    TotalWeight = (18m) * (CBWidth + 2m * CBWallThickness + 8m / 12 - 2m * 1.5m / 12m) * .668m
                });


            return cbReinf;

        }


        public override decimal PourBottom(decimal CBHeight) 
        {
                return 
                    ((CBLength + 2M * CBWallThickness + 8m/12m) * (CBWidth + 2M * CBWallThickness + 8m/12m) * CBBaseThickness + /*Base*/
                    2M * (CBLength + 2M * CBWallThickness + CBWidth) * CBWallThickness * CBHeight /*Walls*/
                    ) / 27M; /*CY*/
        }
        public override decimal PourTop()
        {
            return 0M; /*No Tops in C-15.80*/
        }
        public override decimal PourApron()

        {
            return
                (CBLength + 2m * 4m) * (CBWidth + 2m * 4m) * (2m / 12m) / 27m - /*ApronSize*/
                (CBLength + 2m * CBWallThickness) * (CBWidth + 2m * CBWallThickness) * (2m / 12m) / 27m + /*InsideBox*/ +
                (2m * (CBLength + 2m * 4m)  + 2m * (CBWidth + 2m * 4m) ) * ((0.25M + 0.75M) * .5M / 2M) / 27M + /* Outside Perfimeter CY*/
                (2M * (CBLength + 2m * CBWallThickness) + 2m * (CBWidth + 2m * CBWallThickness)) * ((0.25M + 0.75M) * .5M / 2M) / 27M;  /* Inside Perfimeter CY*/

        }
        public override decimal PurchConcrete(decimal CBHeight)
        {
            return (PourApron()  + PourTop() + PourBottom(CBHeight)) * 1.25M;
        }
        public override decimal FabForms(decimal CBHeight)
        { 
            return 2M * (CBLength + 2M *  CBWallThickness + CBWidth ) * (CBHeight + CBBaseThickness) + /*OutsideWalls*/
                2M * (CBLength + CBWidth) * (CBHeight); /*InsideWalls*/
        }
        public override decimal InstBottomForms(decimal CBHeight)
        {
            return 2M * (CBLength + 2M *  CBWallThickness + CBWidth) * (CBHeight + CBBaseThickness) + /*OutsideWalls*/
                2M * (CBLength + CBWidth) * (CBHeight); /*InsideWalls*/
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
