using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using SmallStructuresTakeOffs.Models;
using SmallStructuresTakeOffs.Enums;


namespace SmallStructuresTakeOffs.Models
{
    public class SD630Headwall 

    {
        public int SD630HeadwallId { get; set; }
        public int ThisHeadwall { get; set; }
        public string HWCode { get; set; }
        public string SD630Description { get; set; }

        [ForeignKey("Project")]
        public long ProjId { get; set; }
        public Project Project { get; set; }
        public PipeSet PipeNo { get; set; }
        public decimal SD630_I_D { get; set; }
        public decimal SD630_A { get; set; }
        public decimal SD630_B { get; set; }
        public decimal SD630_C { get; set; } 
        public decimal SD630_D { get; set; }
        public decimal SD630_E { get; set; }
        public decimal SD630_F { get; set; }
        public decimal SD630_G { get; set; }
        public decimal SD630_L { get; set; }
        public decimal RebNo4Req { get; set; }
        public decimal RebNo4Purch { get; set; }
        //public override int ThisHeadwallId { get =>

        //            List < SD630Headwall > headwalls = new()
        //                {
        //        new SD630Headwall
        //        {
        //            HeadwallId = 0,
        //            SD630Description = "Single 18\" Pipe Straight Headwall",
        //            SD630_I_D = 18M / 12M, PipeNo = PipeSet.Single,
        //            SD630_A = 6M / 12M, SD630_B = 10M / 12M,
        //            SD630_C = 24M / 12M, SD630_D = 38M / 12M,
        //            SD630_E = 30M / 12M, SD630_F = 19M / 12M,
        //            SD630_G = 54M / 12M, SD630_L = 114M / 12M,
        //            RebNo4Req = 58.78M, RebNo4Purch = 80.16M
        //        },
        //                    new SD630Headwall { HeadwallId = 1, SD630Description = "Single 24\" Pipe Straight Headwall", SD630_I_D = 24M / 12M, PipeNo = PipeSet.Single, SD630_A = 8M / 12M, SD630_B = 12M / 12M, SD630_C = 28M / 12M, SD630_D = 44M / 12M, SD630_E = 36M / 12M, SD630_F = 25M / 12M, SD630_G = 66M / 12M, SD630_L = 138M / 12M, RebNo4Req = 77.49M, RebNo4Purch = 100.2M },
        //                    new SD630Headwall { HeadwallId = 2, SD630Description = "Single 30\" Pipe Straight Headwall", SD630_I_D = 30M / 12M, PipeNo = PipeSet.Single, SD630_A = 10M / 12M, SD630_B = 14M / 12M, SD630_C = 32M / 12M, SD630_D = 50M / 12M, SD630_E = 45M / 12M, SD630_F = 31M / 12M, SD630_G = 78M / 12M, SD630_L = 162M / 12M, RebNo4Req = 96.19M, RebNo4Purch = 120.24M },
        //                    new SD630Headwall { HeadwallId = 3, SD630Description = "Single 36\" Pipe Straight Headwall", SD630_I_D = 36M / 12M, PipeNo = PipeSet.Single, SD630_A = 12M / 12M, SD630_B = 16M / 12M, SD630_C = 36M / 12M, SD630_D = 56M / 12M, SD630_E = 54M / 12M, SD630_F = 37M / 12M, SD630_G = 84M / 12M, SD630_L = 186M / 12M, RebNo4Req = 110.22M, RebNo4Purch = 120.24M },
        //                    new SD630Headwall { HeadwallId = 4, SD630Description = "Single 42\" Pipe Straight Headwall", SD630_I_D = 42M / 12M, PipeNo = PipeSet.Single, SD630_A = 14M / 12M, SD630_B = 18M / 12M, SD630_C = 40M / 12M, SD630_D = 62M / 12M, SD630_E = 63M / 12M, SD630_F = 43M / 12M, SD630_G = 102M / 12M, SD630_L = 210M / 12M, RebNo4Req = 133.60M, RebNo4Purch = 160.32M },
        //                    new SD630Headwall { HeadwallId = 5, SD630Description = "Double 18\" Pipe Straight Headwall", SD630_I_D = 18M / 12M, PipeNo = PipeSet.Double, SD630_A = 6M / 12M, SD630_B = 10M / 12M, SD630_C = 24M / 12M, SD630_D = 38M / 12M, SD630_E = 30M / 12M, SD630_F = 19M / 12M, SD630_G = 54M / 12M, SD630_L = (114M + 30M) / 12M, RebNo4Req = 71.64M, RebNo4Purch = 80.16M },
        //                    new SD630Headwall { HeadwallId = 6, SD630Description = "Double 24\" Pipe Straight Headwall", SD630_I_D = 24M / 12M, PipeNo = PipeSet.Double, SD630_A = 8M / 12M, SD630_B = 12M / 12M, SD630_C = 28M / 12M, SD630_D = 44M / 12M, SD630_E = 36M / 12M, SD630_F = 25M / 12M, SD630_G = 66M / 12M, SD630_L = (138M + 36M) / 12M, RebNo4Req = 92.85M, RebNo4Purch = 100.2M },
        //                    new SD630Headwall { HeadwallId = 7, SD630Description = "Double 30\" Pipe Straight Headwall", SD630_I_D = 30M / 12M, PipeNo = PipeSet.Double, SD630_A = 10M / 12M, SD630_B = 14M / 12M, SD630_C = 32M / 12M, SD630_D = 50M / 12M, SD630_E = 45M / 12M, SD630_F = 31M / 12M, SD630_G = 78M / 12M, SD630_L = (162M + 45M) / 12M, RebNo4Req = 126.92M, RebNo4Purch = 160.32M }

        //                };
        //    //return headwalls;


        //    set => throw new NotImplementedException(); }

        //public SeedHWInfo SD630Headwalls => SeedHWInfo.sD630Headwalls.ToList();

        public  decimal PourBase()
        {
            return SD630_C * SD630_L * (8M / 12M) / 27M;
        }

        public  decimal PourWall()
        {
            if (PipeNo == PipeSet.Single)
            {
                return (SD630_D * SD630_L - (decimal)Math.PI * (decimal)Math.Pow((double)SD630_I_D, (double)2) / 4) * (8M / 12M) / 27M;
            }
            else
            {
                return (SD630_D * SD630_L - 2 * (decimal)Math.PI * (decimal)Math.Pow((double)SD630_I_D, (double)2) / 4) * (8M / 12M) / 27M;
            }
        }

        public  decimal FormBase()
        {
            return 2 * (SD630_C + SD630_L) * (8M / 12M);
        }

        public  decimal FormWall()
        {
            return 2 * (SD630_L + (8M / 12M) * SD630_D);
        }

        public  decimal FormFab()
        {
            return FormBase() + FormWall();
        }

        //public override ThisHeadwallId {get; set; } = 
        //{
        //        List<SD630Headwall> headwalls = new()
        //            {
        //                new SD630Headwall
        //                    {
        //                        HeadwallId = 0,
        //                        SD630Description = "Single 18\" Pipe Straight Headwall",
        //                        SD630_I_D = 18M / 12M, PipeNo = PipeSet.Single,
        //                        SD630_A = 6M / 12M, SD630_B = 10M / 12M,
        //                        SD630_C = 24M / 12M, SD630_D = 38M / 12M,
        //                        SD630_E = 30M / 12M, SD630_F = 19M / 12M,
        //                        SD630_G = 54M / 12M, SD630_L = 114M / 12M,
        //                        RebNo4Req = 58.78M, RebNo4Purch = 80.16M
        //                    },
        //                new SD630Headwall { HeadwallId = 1, SD630Description = "Single 24\" Pipe Straight Headwall", SD630_I_D = 24M / 12M, PipeNo = PipeSet.Single, SD630_A = 8M / 12M, SD630_B = 12M / 12M, SD630_C = 28M / 12M, SD630_D = 44M / 12M, SD630_E = 36M / 12M, SD630_F = 25M / 12M, SD630_G = 66M / 12M, SD630_L = 138M / 12M, RebNo4Req = 77.49M, RebNo4Purch = 100.2M },
        //                new SD630Headwall { HeadwallId = 2, SD630Description = "Single 30\" Pipe Straight Headwall", SD630_I_D = 30M / 12M, PipeNo = PipeSet.Single, SD630_A = 10M / 12M, SD630_B = 14M / 12M, SD630_C = 32M / 12M, SD630_D = 50M / 12M, SD630_E = 45M / 12M, SD630_F = 31M / 12M, SD630_G = 78M / 12M, SD630_L = 162M / 12M, RebNo4Req = 96.19M, RebNo4Purch = 120.24M },
        //                new SD630Headwall { HeadwallId = 3, SD630Description = "Single 36\" Pipe Straight Headwall", SD630_I_D = 36M / 12M, PipeNo = PipeSet.Single, SD630_A = 12M / 12M, SD630_B = 16M / 12M, SD630_C = 36M / 12M, SD630_D = 56M / 12M, SD630_E = 54M / 12M, SD630_F = 37M / 12M, SD630_G = 84M / 12M, SD630_L = 186M / 12M, RebNo4Req = 110.22M, RebNo4Purch = 120.24M },
        //                new SD630Headwall { HeadwallId = 4, SD630Description = "Single 42\" Pipe Straight Headwall", SD630_I_D = 42M / 12M, PipeNo = PipeSet.Single, SD630_A = 14M / 12M, SD630_B = 18M / 12M, SD630_C = 40M / 12M, SD630_D = 62M / 12M, SD630_E = 63M / 12M, SD630_F = 43M / 12M, SD630_G = 102M / 12M, SD630_L = 210M / 12M, RebNo4Req = 133.60M, RebNo4Purch = 160.32M },
        //                new SD630Headwall { HeadwallId = 5, SD630Description = "Double 18\" Pipe Straight Headwall", SD630_I_D = 18M / 12M, PipeNo = PipeSet.Double, SD630_A = 6M / 12M, SD630_B = 10M / 12M, SD630_C = 24M / 12M, SD630_D = 38M / 12M, SD630_E = 30M / 12M, SD630_F = 19M / 12M, SD630_G = 54M / 12M, SD630_L = (114M + 30M) / 12M, RebNo4Req = 71.64M, RebNo4Purch = 80.16M },
        //                new SD630Headwall { HeadwallId = 6, SD630Description = "Double 24\" Pipe Straight Headwall", SD630_I_D = 24M / 12M, PipeNo = PipeSet.Double, SD630_A = 8M / 12M, SD630_B = 12M / 12M, SD630_C = 28M / 12M, SD630_D = 44M / 12M, SD630_E = 36M / 12M, SD630_F = 25M / 12M, SD630_G = 66M / 12M, SD630_L = (138M + 36M) / 12M, RebNo4Req = 92.85M, RebNo4Purch = 100.2M },
        //                new SD630Headwall { HeadwallId = 7, SD630Description = "Double 30\" Pipe Straight Headwall", SD630_I_D = 30M / 12M, PipeNo = PipeSet.Double, SD630_A = 10M / 12M, SD630_B = 14M / 12M, SD630_C = 32M / 12M, SD630_D = 50M / 12M, SD630_E = 45M / 12M, SD630_F = 31M / 12M, SD630_G = 78M / 12M, SD630_L = (162M + 45M)/ 12M, RebNo4Req = 126.92M, RebNo4Purch = 160.32M }

        //            };
        //        //return headwalls;
           
        //}


        //public static class SeedHWInfo
        //{
        public static List<SD630Headwall> D630HWs
        {
            get
            {
                List<SD630Headwall> headwalls = new()
                {
                    new SD630Headwall { SD630HeadwallId = 0, SD630Description = "Single 18\" Pipe Straight Headwall", SD630_I_D = 18M / 12M, PipeNo = PipeSet.Single, SD630_A = 6M / 12M, SD630_B = 10M / 12M, SD630_C = 24M / 12M, SD630_D = 38M / 12M, SD630_E = 30M / 12M, SD630_F = 19M / 12M, SD630_G = 54M / 12M, SD630_L = 114M / 12M, RebNo4Req = 58.78M, RebNo4Purch = 80.16M},
                    new SD630Headwall { SD630HeadwallId = 1, SD630Description = "Single 24\" Pipe Straight Headwall", SD630_I_D = 24M / 12M, PipeNo = PipeSet.Single, SD630_A = 8M / 12M, SD630_B = 12M / 12M, SD630_C = 28M / 12M, SD630_D = 44M / 12M, SD630_E = 36M / 12M, SD630_F = 25M / 12M, SD630_G = 66M / 12M, SD630_L = 138M / 12M, RebNo4Req = 77.49M, RebNo4Purch = 100.2M },
                    new SD630Headwall { SD630HeadwallId = 2, SD630Description = "Single 30\" Pipe Straight Headwall", SD630_I_D = 30M / 12M, PipeNo = PipeSet.Single, SD630_A = 10M / 12M, SD630_B = 14M / 12M, SD630_C = 32M / 12M, SD630_D = 50M / 12M, SD630_E = 45M / 12M, SD630_F = 31M / 12M, SD630_G = 78M / 12M, SD630_L = 162M / 12M, RebNo4Req = 96.19M, RebNo4Purch = 120.24M },
                    new SD630Headwall { SD630HeadwallId = 3, SD630Description = "Single 36\" Pipe Straight Headwall", SD630_I_D = 36M / 12M, PipeNo = PipeSet.Single, SD630_A = 12M / 12M, SD630_B = 16M / 12M, SD630_C = 36M / 12M, SD630_D = 56M / 12M, SD630_E = 54M / 12M, SD630_F = 37M / 12M, SD630_G = 84M / 12M, SD630_L = 186M / 12M, RebNo4Req = 110.22M, RebNo4Purch = 120.24M },
                    new SD630Headwall { SD630HeadwallId = 4, SD630Description = "Single 42\" Pipe Straight Headwall", SD630_I_D = 42M / 12M, PipeNo = PipeSet.Single, SD630_A = 14M / 12M, SD630_B = 18M / 12M, SD630_C = 40M / 12M, SD630_D = 62M / 12M, SD630_E = 63M / 12M, SD630_F = 43M / 12M, SD630_G = 102M / 12M, SD630_L = 210M / 12M, RebNo4Req = 133.60M, RebNo4Purch = 160.32M },
                    new SD630Headwall { SD630HeadwallId = 5, SD630Description = "Double 18\" Pipe Straight Headwall", SD630_I_D = 18M / 12M, PipeNo = PipeSet.Double, SD630_A = 6M / 12M, SD630_B = 10M / 12M, SD630_C = 24M / 12M, SD630_D = 38M / 12M, SD630_E = 30M / 12M, SD630_F = 19M / 12M, SD630_G = 54M / 12M, SD630_L = (114M + 30M) / 12M, RebNo4Req = 71.64M, RebNo4Purch = 80.16M },
                    new SD630Headwall { SD630HeadwallId = 6, SD630Description = "Double 24\" Pipe Straight Headwall", SD630_I_D = 24M / 12M, PipeNo = PipeSet.Double, SD630_A = 8M / 12M, SD630_B = 12M / 12M, SD630_C = 28M / 12M, SD630_D = 44M / 12M, SD630_E = 36M / 12M, SD630_F = 25M / 12M, SD630_G = 66M / 12M, SD630_L = (138M + 36M) / 12M, RebNo4Req = 92.85M, RebNo4Purch = 100.2M },
                    new SD630Headwall { SD630HeadwallId = 7, SD630Description = "Double 30\" Pipe Straight Headwall", SD630_I_D = 30M / 12M, PipeNo = PipeSet.Double, SD630_A = 10M / 12M, SD630_B = 14M / 12M, SD630_C = 32M / 12M, SD630_D = 50M / 12M, SD630_E = 45M / 12M, SD630_F = 31M / 12M, SD630_G = 78M / 12M, SD630_L = (162M + 45M)/ 12M, RebNo4Req = 126.92M, RebNo4Purch = 160.32M }

                };
                return headwalls;
            }
        }
        //}

    //public enum PipeSet
    //{
    //    Single,
    //    Double,
    //    Triple
    //}
    }
}
