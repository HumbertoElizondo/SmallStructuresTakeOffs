using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmallStructuresTakeOffs.Models
{
    public class C1580CB
    {
        public int C1580CBId { get; set; }
        public string C1580CBCode { get; set; }
        public string C1580CBDescription { get; set; }
        public decimal C1580CBHeight { get; set; }
        public decimal C1580CBLenght => 3M; // Interior Front Side of Catch Basin
        public decimal C1580CBWidth => 2M; // Interior Width Side of Catch Basin
        public decimal C1580CBThick => .5M; // Thickness of wall and Floor
        public int C1580VertLsEa => 14; //Vertical Rebar qty
        public decimal C1580SqRingL => 160M / 12M;
        public decimal C1580Reb4FandI { get; set; }
        public decimal C1580Reb4Purch { get; set; }



        public decimal PourBottom(decimal C1580CBHeight)
        {
                return ((C1580CBLenght + 2M * C1580CBThick) * (C1580CBWidth + 2M * C1580CBThick) * C1580CBThick + /*Base*/
                    2M * ((C1580CBLenght + 2M * C1580CBThick) + C1580CBWidth) * C1580CBThick * (C1580CBHeight ) /*Walls*/
                    ) / 27M; /*CY*/
        }
        public decimal PourTop()
        {
            return 0M; /*No Tops in C-15.80*/
        }
        public decimal PourApron()
        {
            return ((11m * 10m) * 2m/12m  +
                    (2m * (11m + 10M) + 2m * (4m + 3m)) * ((3m + 9m) * (6m / 2m) / 144)) / 27m;

            //return (((2M * 4M + 3M) * 2M + (2M * 4M + 2M - .5M * 2M) * 2M) * (0.25M + 0.5M) * .5M / 2M) / 27M + /* Outside Perfimeter CY*/
            //    ((2M * (4M + 3M) * (0.25M + 0.5M) * .5M / 2M))/ 27M + /* Inside Perfimeter CY*/
            //    ((11M * 10M - 4M * 3M) * 2M / 12M) / 27M; /*Apron*/
        }
        public decimal PurchConcrete(decimal C1580CBHeight)
        {
            return (PourApron() + PourTop() + PourBottom(C1580CBHeight)) * 1.25M;
        }
        public decimal FabForms(decimal C1580CBHeight)
        { 
            return 2M * (C1580CBLenght + 2M * 2M * C1580CBThick + C1580CBWidth) * (C1580CBHeight + .5M) + /*OutsideWalls*/
                2M * (C1580CBLenght + C1580CBWidth) * (C1580CBHeight); /*InsideWalls*/
        }
        public decimal InstBottomForms(decimal C1580CBHeight)
        {
            return 2M * (C1580CBLenght + 2M * 2M * C1580CBThick + C1580CBWidth) * (C1580CBHeight + .5M) + /*OutsideWalls*/
                2M * (C1580CBLenght + C1580CBWidth) * (C1580CBHeight); /*InsideWalls*/
        }
        public decimal InstTopForms()
        {
            return 0M; /*No Tops in C-15.80*/
        }
        public decimal RebVertLength(decimal height)
        {
            return C1580CBHeight + .5M;
        }
        public int RebSqRingEa (decimal height)
        {
            return (int)(Math.Ceiling(height))+1;
        }
    }
}
