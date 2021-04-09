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
            if (C1580CBHeight <= 8M)
            {
                return ((C1580CBLenght + 2M * C1580CBThick) * (C1580CBWidth + 2M * C1580CBThick) * C1580CBThick + /*Base*/
                    2M * ((C1580CBLenght + 2M * C1580CBThick) + C1580CBWidth) * C1580CBThick * (C1580CBHeight - 2M) /*Walls*/
                    ) / 27M; /*CY*/
            }
            return 0;
        }

        public decimal RebVertLength(decimal height)
        {
            return C1580CBHeight + .5M;
        }

        public int RebSqRingEa (decimal height)
        {
            return (int)(Math.Ceiling(height))+1;
        }

        //public static class SeedC1580CB
        //{
        //    public static List<C1580CB> sD630Headwalls
        //    {
        //        get
        //        {
        //            List<C1580CB> headwalls = new List<C1580CB>
        //            {
        //                new SD630Headwall { SD630Id = 0, SD630Description = "Single 18\" Pipe Straight Headwall", SD630_I_D = 18M / 12M, PipeNo = PipeSet.Single, SD630_A = 6M / 12M, SD630_B = 10M / 12M, SD630_C = 24M / 12M, SD630_D = 38M / 12M, SD630_E = 30M / 12M, SD630_F = 19M / 12M, SD630_G = 54M / 12M, SD630_L = 114M / 12M, RebNo4Req = 58.78M, RebNo4Purch = 80.16M},
        //                new SD630Headwall { SD630Id = 1, SD630Description = "Single 24\" Pipe Straight Headwall", SD630_I_D = 24M / 12M, PipeNo = PipeSet.Single, SD630_A = 8M / 12M, SD630_B = 12M / 12M, SD630_C = 28M / 12M, SD630_D = 44M / 12M, SD630_E = 36M / 12M, SD630_F = 25M / 12M, SD630_G = 66M / 12M, SD630_L = 138M / 12M, RebNo4Req = 77.49M, RebNo4Purch = 100.2M },
        //                new SD630Headwall { SD630Id = 2, SD630Description = "Single 30\" Pipe Straight Headwall", SD630_I_D = 30M / 12M, PipeNo = PipeSet.Single, SD630_A = 10M / 12M, SD630_B = 14M / 12M, SD630_C = 32M / 12M, SD630_D = 50M / 12M, SD630_E = 45M / 12M, SD630_F = 31M / 12M, SD630_G = 78M / 12M, SD630_L = 162M / 12M, RebNo4Req = 96.19M, RebNo4Purch = 120.24M },
        //                new SD630Headwall { SD630Id = 3, SD630Description = "Single 36\" Pipe Straight Headwall", SD630_I_D = 36M / 12M, PipeNo = PipeSet.Single, SD630_A = 12M / 12M, SD630_B = 16M / 12M, SD630_C = 36M / 12M, SD630_D = 56M / 12M, SD630_E = 54M / 12M, SD630_F = 37M / 12M, SD630_G = 84M / 12M, SD630_L = 186M / 12M, RebNo4Req = 110.22M, RebNo4Purch = 120.24M },
        //                new SD630Headwall { SD630Id = 4, SD630Description = "Single 42\" Pipe Straight Headwall", SD630_I_D = 42M / 12M, PipeNo = PipeSet.Single, SD630_A = 14M / 12M, SD630_B = 18M / 12M, SD630_C = 40M / 12M, SD630_D = 62M / 12M, SD630_E = 63M / 12M, SD630_F = 43M / 12M, SD630_G = 102M / 12M, SD630_L = 210M / 12M, RebNo4Req = 133.60M, RebNo4Purch = 160.32M },
        //                new SD630Headwall { SD630Id = 5, SD630Description = "Double 18\" Pipe Straight Headwall", SD630_I_D = 18M / 12M, PipeNo = PipeSet.Double, SD630_A = 6M / 12M, SD630_B = 10M / 12M, SD630_C = 24M / 12M, SD630_D = 38M / 12M, SD630_E = 30M / 12M, SD630_F = 19M / 12M, SD630_G = 54M / 12M, SD630_L = (114M + 30M) / 12M, RebNo4Req = 71.64M, RebNo4Purch = 80.16M },
        //                new SD630Headwall { SD630Id = 6, SD630Description = "Double 24\" Pipe Straight Headwall", SD630_I_D = 24M / 12M, PipeNo = PipeSet.Double, SD630_A = 8M / 12M, SD630_B = 12M / 12M, SD630_C = 28M / 12M, SD630_D = 44M / 12M, SD630_E = 36M / 12M, SD630_F = 25M / 12M, SD630_G = 66M / 12M, SD630_L = (138M + 36M) / 12M, RebNo4Req = 92.85M, RebNo4Purch = 100.2M },
        //                new SD630Headwall { SD630Id = 7, SD630Description = "Double 30\" Pipe Straight Headwall", SD630_I_D = 30M / 12M, PipeNo = PipeSet.Double, SD630_A = 10M / 12M, SD630_B = 14M / 12M, SD630_C = 32M / 12M, SD630_D = 50M / 12M, SD630_E = 45M / 12M, SD630_F = 31M / 12M, SD630_G = 78M / 12M, SD630_L = (162M + 45M)/ 12M, RebNo4Req = 126.92M, RebNo4Purch = 160.32M }

        //            };
        //            return headwalls;
        //        }
        //    }
        //}

    }
}
