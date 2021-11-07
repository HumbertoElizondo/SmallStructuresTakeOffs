using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmallStructuresTakeOffs.Models
{
    public class P1569_1M
    {
        public int P1569_1MId { get; set; }
        public string P1569_1MCode { get; set; }
        public string P1569_1MDescription { get; set; }
        public decimal Height { get; set; }
        public decimal Length => 3M; // Interior Size at Front & Back Sides of Catch Basin
        public decimal Width => 2.75M; // Interior Size at Right & Left Side of Catch Basin
        public decimal Thick => .5M; // Thickness of wall and Floor
        public int RebNo3H_LEa => 8; // Horizontal Bar Lenght Wise (Length 36-3 = 33" (2.75'))
        public int RebNo3H_WEa => 8; // Horizontal Bar Width Wise (Length 33 - 3 = 30" (2.5'))
        public int RebNo4DD_WEa => 4; // Typical Dowel Bar 
        public decimal RebNo3MH_LEa_L => 2.75M; // Horizontal Bar Lenght Wise (Length 36-3 = 33" (2.75'))
        public decimal RebNo3MH_WEa_L => 2.5M; // Horizontal Bar Width Wise (Length 33 - 3 = 30" (2.5'))
        public decimal RebNo4MDD_WEa_L => 4; // Typical Dowel Bar 
        public decimal Reb4FandI { get; set; }
        public decimal Reb3Purch { get; set; }
        public decimal Reb3FandI { get; set; }
        public decimal Reb4Purch { get; set; }


        public decimal PourBottom(decimal Height)
        {
            return ((Length + 2M * Thick) * (Width + 2M * Thick) * Thick + /*Base*/
                2M * ((Length + 2M * Thick) + Width) * Thick * (Height-2M) /*Walls*/
                ) / 27M; /*CY*/
        }
        public decimal PourTop()
        {
            return (2M * ((Length + 2M * Thick) + Width) * Thick * (2M)  + /*Walls*/
                (Length + 2M * Thick) * (Width + 2M * Thick) * Thick ) / 27M;
        }
        public decimal PourApron()
        {
            return 0;
            //return (((2M * 4M + 3M) * 2M + (2M * 4M + 2M - .5M * 2M) * 2M) * (0.25M + 0.5M) * .5M / 2M) / 27M + /* Outside Perfimeter CY*/
            //    ((2M * (4M + 3M) * (0.25M + 0.5M) * .5M / 2M))/ 27M + /* Inside Perfimeter CY*/
            //    ((11M * 10M - 4M * 3M) * 2M / 12M) / 27M; /*Apron*/
        }

        public decimal PurchConcrete(decimal Height)
        {
            return (PourApron() * 1.087M + PourTop() + PourBottom(Height)) * 1.15M;
        }

        public decimal FabForms(decimal Height)
        { 
            return 2M * (Length + 2M * 2M * Width + Width) * (Height + Thick) + /*OutsideWalls*/
                2M * (Length + Width) * (Height) + /*InsideWalls*/
                Length * Width; /*Top Slab*/
        }

        public decimal InstBottomForms(decimal Height)
        {
            return 2M * (Length + 2M * 2M * Thick + Width) * (Height-(2M + .5M)) + /*OutsideWalls*/
                2M * (Length + Width) * (Height-2M); /*InsideWalls*/
        }

        public decimal InstTopForms()
        {
            return 2M * (Length + 2M * 2M * Thick + Width) * (2M + .5M) + /*OutsideWalls*/
                2M * (Length + Width) * (2M) + /*InsideWalls*/
                Length * Width;  /*Slab Form*/
            //return 0M; /*No Tops in C-15.80*/
        }


        public decimal RebVertLength(decimal height)
        {
            return 0;
            //return Height + .5M;
        }

        public int RebSqRingEa (decimal height)
        {
            return 0;
            //return (int)(Math.Ceiling(height))+1;
        }

        public int RebNo3Hor_WidthEa()
        {
            return RebNo3H_LEa;
        }

        public decimal RebNo3Hor_Length()
        {
            return RebNo3MH_LEa_L;
        }

        public int RebNo3Hor_LengthEa()
        {
            return RebNo3H_WEa;
        }

        public decimal RebNo3Hor_Width()
        {
            return RebNo3MH_WEa_L;
        }

        public int RebNo4DwlEa()
        {
            return RebNo4DD_WEa;
        }

        public decimal RebNo4DwlLength()
        {
            return RebNo4MDD_WEa_L;
        }
    }
}
