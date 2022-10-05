using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmallStructuresTakeOffs.Models
{
    public class CBc1580 : CatchBasin
    {
        public override decimal CBLength { get; set; } = 3m;
        public override decimal CBWidth { get; set; } = 2m;
        public override decimal CBBaseThickness { get; set; } = .5m;
        public override decimal CBWallThickness { get => .5m; set { decimal T = .5m; } }
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
                    CBreinfQty = 14,
                    CBreinfLength = CBHeight + CBBaseThickness - (5m/12m),
                    CBreinfShape = "Straight, Vertical ",
                    TotalLength =  (14m) *  (CBHeight + CBBaseThickness - (5m/12m)),
                    TotalWeight =  (14m) *  (CBHeight + CBBaseThickness - (5m/12m)) * .668m
                });
            cbReinf.Add(
                new CBreinforcement
                {
                    CBId = CatchBasinId,
                    CBRebarNom = RebarNomination.No4,
                    CBreinfCode = "rb02",
                    CBreinfQty = (int)Math.Ceiling(CBHeight) +1,
                    CBreinfLength = 2m * (CBLength + CBWidth + 2m * (5m/12m)) + 2m,
                    CBreinfShape = "Square Ring Shape, 2'-Overlap ",
                    TotalLength =  ((int)Math.Ceiling(CBHeight) +1) * (2m * (CBLength + CBWidth + 2m * (5m/12m)) + 2),
                    TotalWeight =  ((int)Math.Ceiling(CBHeight) +1) * (2m * (CBLength + CBWidth + 2m * (5m/12m)) + 2) * .668m
                });

            return cbReinf;

        }
        public override decimal PourBottom(decimal CBHeight) {
            if (CBHeight <= 8)
            {
                return 
                    (CBLength * CBWidth * CBBaseThickness + /*Base*/
                    2M * (CBLength + 2M * CBWallThickness + CBWidth) * CBWallThickness * (CBHeight + CBBaseThickness) /*Walls*/
                    ) / 27M; /*CY*/
            }
            else
            {

                return 
                    (
                        CBLength * CBWidth * CBWallThickness + /*Base*/
                        2M * ((CBLength + 2M * (CBWallThickness + 2m/12m)) + CBWidth) * (CBWallThickness + 2m/12m) * (CBHeight + CBBaseThickness) /*Walls*/
                    ) / 27M; /*CY*/
            }
        }
        public override decimal PourTop()
        {
            return 0M; /*No Tops in C-15.80*/
        }
        public override decimal PourApron()
        {
            if (CBHeight <= 8)
            {
                return
                    (((CBWidth + 2m * 4m ) * (CBLength + 2m * 4m) * 2m / 12m - /*Apron Footprint*/
                    (CBWidth + 2m * CBWallThickness) * (CBLength + 2m * CBWallThickness) * 2m / 12m + /*CB Footprint*/
                    (2m * ((CBWidth + 2m * 4m) + (CBLength + 2m * 4m)) + /*Ext Perimeter*/
                    2m * ((CBWidth + 2m * CBWallThickness) + (CBLength + 2m * CBWallThickness))) * /*Int Perimeter*/
                    (((3m + 9m) * (6m / 2m)) / 144))/*Thickened Perimeter Section (sf)*/
                    ) / 27m; /*cy*/

            }
            else 
            {
                return
                    (((CBWidth + 2m * 4m + 2m * 2m / 12m) * (CBLength + 2m * 4m + 2m * 2m / 12m) * 2m / 12m - /*Apron Footprint*/
                    (CBWidth + 2m * CBWallThickness + 2m * 2m / 12m) * (CBLength + 2m * CBWallThickness + 2m * 2m / 12m) * 2m / 12m + /*CB Footprint*/
                    (2m * ((CBWidth + 2m * 4m + 2m * 2m / 12m) + (CBLength + 2m * 4m + 2m * 2m / 12m)) + /*Ext Perimeter*/
                    2m * ((CBWidth + 2m * CBWallThickness + 2m * 2m / 12m) + (CBLength + 2m * CBWallThickness + 2m * 2m / 12m))) * /*Int Perimeter*/
                    (((3m + 9m) * (6m / 2m)) / 144))/*Thickened Perimeter Section (sf)*/
                    ) / 27m; /*cy*/

            }
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
        public override decimal CBRebarTakeOfflb(decimal CBHeight)
        {
            return
                0;
            //throw new NotImplementedException();
        }
    }
}
