﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using SmallStructuresTakeOffs.Models;
using SmallStructuresTakeOffs.Enums;


namespace SmallStructuresTakeOffs.Models
{
    public class SD630Headwall  : Headwall
    {
        //public int SD630HeadwallId { get; set; }
        //public int ThisHeadwall { get; set; }
        //public string HWCode { get; set; }
        //public string SD630Description { get; set; }
        //[ForeignKey("Project")]
        //public long ProjId { get; set; }
        //public Project Project { get; set; }
        //public PipeSet PipeNo { get; set; }
        public override decimal SD630_I_D { get; set; } = 1m;
        public override decimal SD630_A { get; set; } = 1m;
        public override decimal SD630_B { get; set; } = 1m;
        public override decimal SD630_C { get; set; } = 1m;
        public override decimal SD630_D { get; set; } = 1m;
        public override decimal SD630_E { get; set; } = 1m;
        public override decimal SD630_F { get; set; } = 1m;
        public override decimal SD630_G { get; set; } = 1m;
        public override decimal SD630_L { get; set; } = 1m;
        public override PipeSet PipeNo { get; set; }

        //public decimal RebNo4Req { get; set; }
        //public decimal RebNo4Purch { get; set; }

        public override decimal PourBase()
        {
            return SD630_C * SD630_L * (8M / 12M) / 27M;
        }
        public  override decimal PourWall()
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
        public override decimal PourTotal()
        {
            return
                PourBase() + PourWall();
        }

        public override decimal FormBase()
        {
            return 2 * (SD630_C + SD630_L) * (8M / 12M);
        }

        public override decimal FormWall()
        {
            return 2 * (SD630_L + (8M / 12M) * SD630_D);
        }

        public override decimal FormFab()
        {
            return FormBase() + FormWall();
        }

        public static List<SD630Headwall> D630HWs
        {
            get
            {
                List<SD630Headwall> headwalls = new()
                {
                    new SD630Headwall { ThisHeadwallId = 0, HWDescription = "Single 18\" Pipe Straight Headwall", SD630_I_D = 18M / 12M, PipeNo = PipeSet.Single, SD630_A = 6M / 12M, SD630_B = 10M / 12M, SD630_C = 24M / 12M, SD630_D = 38M / 12M, SD630_E = 30M / 12M, SD630_F = 19M / 12M, SD630_G = 54M / 12M, SD630_L = 114M / 12M, ConcrCY = 1.2m,ReinfLB = 60m},
                    new SD630Headwall { ThisHeadwallId = 1, HWDescription = "Single 24\" Pipe Straight Headwall", SD630_I_D = 24M / 12M, PipeNo = PipeSet.Single, SD630_A = 8M / 12M, SD630_B = 12M / 12M, SD630_C = 28M / 12M, SD630_D = 44M / 12M, SD630_E = 36M / 12M, SD630_F = 25M / 12M, SD630_G = 66M / 12M, SD630_L = 138M / 12M, ConcrCY = 1.6m,ReinfLB = 78m},
                    new SD630Headwall { ThisHeadwallId = 2, HWDescription = "Single 30\" Pipe Straight Headwall", SD630_I_D = 30M / 12M, PipeNo = PipeSet.Single, SD630_A = 10M / 12M, SD630_B = 14M / 12M, SD630_C = 32M / 12M, SD630_D = 50M / 12M, SD630_E = 45M / 12M, SD630_F = 31M / 12M, SD630_G = 78M / 12M, SD630_L = 162M / 12M, ConcrCY = 2.1m, ReinfLB = 97m },
                    new SD630Headwall { ThisHeadwallId = 3, HWDescription = "Single 36\" Pipe Straight Headwall", SD630_I_D = 36M / 12M, PipeNo = PipeSet.Single, SD630_A = 12M / 12M, SD630_B = 16M / 12M, SD630_C = 36M / 12M, SD630_D = 56M / 12M, SD630_E = 54M / 12M, SD630_F = 37M / 12M, SD630_G = 84M / 12M, SD630_L = 186M / 12M, ConcrCY = 2.7m, ReinfLB = 111m },
                    new SD630Headwall { ThisHeadwallId = 4, HWDescription = "Single 42\" Pipe Straight Headwall", SD630_I_D = 42M / 12M, PipeNo = PipeSet.Single, SD630_A = 14M / 12M, SD630_B = 18M / 12M, SD630_C = 40M / 12M, SD630_D = 62M / 12M, SD630_E = 63M / 12M, SD630_F = 43M / 12M, SD630_G = 102M / 12M, SD630_L = 210M / 12M, ConcrCY = 3.4m, ReinfLB = 135m },
                    new SD630Headwall { ThisHeadwallId = 5, HWDescription = "Double 18\" Pipe Straight Headwall", SD630_I_D = 18M / 12M, PipeNo = PipeSet.Double, SD630_A = 6M / 12M, SD630_B = 10M / 12M, SD630_C = 24M / 12M, SD630_D = 38M / 12M, SD630_E = 30M / 12M, SD630_F = 19M / 12M, SD630_G = 54M / 12M, SD630_L = (114M + 30M) / 12M, ConcrCY = 1.4m,ReinfLB = 73m },
                    new SD630Headwall { ThisHeadwallId = 6, HWDescription = "Double 24\" Pipe Straight Headwall", SD630_I_D = 24M / 12M, PipeNo = PipeSet.Double, SD630_A = 8M / 12M, SD630_B = 12M / 12M, SD630_C = 28M / 12M, SD630_D = 44M / 12M, SD630_E = 36M / 12M, SD630_F = 25M / 12M, SD630_G = 66M / 12M, SD630_L = (138M + 36M) / 12M, ConcrCY = 2m,ReinfLB = 90m },
                    new SD630Headwall { ThisHeadwallId = 7, HWDescription = "Double 30\" Pipe Straight Headwall", SD630_I_D = 30M / 12M, PipeNo = PipeSet.Double, SD630_A = 10M / 12M, SD630_B = 14M / 12M, SD630_C = 32M / 12M, SD630_D = 50M / 12M, SD630_E = 45M / 12M, SD630_F = 31M / 12M, SD630_G = 78M / 12M, SD630_L = (162M + 45M)/ 12M, ConcrCY = 2.6m,ReinfLB = 116m }

                };
                return headwalls;
            }
        }

        public override SD630Headwall GetTheHW()
        {
            var result =
               (from c in D630HWs
                where 
                    c.PipeNo == this.PipeNo
                select c).FirstOrDefault();
            return result;
        }


        //public override ICollection<HWreinforcement> HWreinforcements 
        //{ get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override ICollection<HWreinforcement> HWreinforcements
        {
            get => this.TheReinforcements(); set => this.TheReinforcements();
        }
        public override decimal SD630_H { get; set; } = 1m;
        public override decimal SD630_X { get; set; } = 1m;
        public override decimal SD630_Y { get; set; } = 1m;
        public override decimal SD630_Z { get; set; } = 1m;
        public override decimal ConcrCY { get; set; } = 1m;
        public override decimal ReinfLB { get; set; } = 1m;

        //public override decimal ConcrCY { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        //public override decimal ReinfLB { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override ICollection<HWreinforcement> TheReinforcements()
        {
            IList<HWreinforcement> cbReinf = new List<HWreinforcement>();

            cbReinf.Add(
                new HWreinforcement
                {
                    HWId = HeadwallId,
                    HWRebarNom = RebarNomination.No4,
                    HWreinfCode = "rb01",
                    HWreinfQty = 10,
                    HWreinfLength = SD630_A + SD630_B - (5m / 12m),
                    HWreinfShape = "Straight, Vertical",
                    HWTotalLength = (10m) * (SD630_A + SD630_B - (5m / 12m)),
                    HWTotalWeight = (10m) * (SD630_A + SD630_B - (5m / 12m)) * 0.668m
                });
            cbReinf.Add(
                new HWreinforcement
                {
                    HWId = HeadwallId,
                    HWRebarNom = RebarNomination.No4,
                    HWreinfCode = "rb01",
                    HWreinfQty = 10,
                    HWreinfLength = SD630_A + SD630_B - (5m / 12m),
                    HWreinfShape = "Straight, Vertical",
                    HWTotalLength = (10m) * (SD630_A + SD630_B - (5m / 12m)),
                    HWTotalWeight = (10m) * (SD630_A + SD630_B - (5m / 12m)) * 0.668m
                });
            return cbReinf;
        }

        public override decimal EngConcr()
        {
            throw new NotImplementedException();
        }

        public override decimal EngReinf()
        {
            throw new NotImplementedException();
        }

        // There's no need to duplicate the Headwall Configuration via a Mathod, when the Static Property above
        // can be accesses directly thru the class. See Detail action in the SD630Headwall Controller
        //public /*static*/ List<SD630Headwall> D630HWs1()
        //{
        //        List<SD630Headwall> headwalls = new()
        //        {
        //            new SD630Headwall { SD630HeadwallId = 0, SD630Description = "Single 18\" Pipe Straight Headwall", SD630_I_D = 18M / 12M, PipeNo = PipeSet.Single, SD630_A = 6M / 12M, SD630_B = 10M / 12M, SD630_C = 24M / 12M, SD630_D = 38M / 12M, SD630_E = 30M / 12M, SD630_F = 19M / 12M, SD630_G = 54M / 12M, SD630_L = 114M / 12M, RebNo4Req = 58.78M, RebNo4Purch = 80.16M},
        //            new SD630Headwall { SD630HeadwallId = 1, SD630Description = "Single 24\" Pipe Straight Headwall", SD630_I_D = 24M / 12M, PipeNo = PipeSet.Single, SD630_A = 8M / 12M, SD630_B = 12M / 12M, SD630_C = 28M / 12M, SD630_D = 44M / 12M, SD630_E = 36M / 12M, SD630_F = 25M / 12M, SD630_G = 66M / 12M, SD630_L = 138M / 12M, RebNo4Req = 77.49M, RebNo4Purch = 100.2M },
        //            new SD630Headwall { SD630HeadwallId = 2, SD630Description = "Single 30\" Pipe Straight Headwall", SD630_I_D = 30M / 12M, PipeNo = PipeSet.Single, SD630_A = 10M / 12M, SD630_B = 14M / 12M, SD630_C = 32M / 12M, SD630_D = 50M / 12M, SD630_E = 45M / 12M, SD630_F = 31M / 12M, SD630_G = 78M / 12M, SD630_L = 162M / 12M, RebNo4Req = 96.19M, RebNo4Purch = 120.24M },
        //            new SD630Headwall { SD630HeadwallId = 3, SD630Description = "Single 36\" Pipe Straight Headwall", SD630_I_D = 36M / 12M, PipeNo = PipeSet.Single, SD630_A = 12M / 12M, SD630_B = 16M / 12M, SD630_C = 36M / 12M, SD630_D = 56M / 12M, SD630_E = 54M / 12M, SD630_F = 37M / 12M, SD630_G = 84M / 12M, SD630_L = 186M / 12M, RebNo4Req = 110.22M, RebNo4Purch = 120.24M },
        //            new SD630Headwall { SD630HeadwallId = 4, SD630Description = "Single 42\" Pipe Straight Headwall", SD630_I_D = 42M / 12M, PipeNo = PipeSet.Single, SD630_A = 14M / 12M, SD630_B = 18M / 12M, SD630_C = 40M / 12M, SD630_D = 62M / 12M, SD630_E = 63M / 12M, SD630_F = 43M / 12M, SD630_G = 102M / 12M, SD630_L = 210M / 12M, RebNo4Req = 133.60M, RebNo4Purch = 160.32M },
        //            new SD630Headwall { SD630HeadwallId = 5, SD630Description = "Double 18\" Pipe Straight Headwall", SD630_I_D = 18M / 12M, PipeNo = PipeSet.Double, SD630_A = 6M / 12M, SD630_B = 10M / 12M, SD630_C = 24M / 12M, SD630_D = 38M / 12M, SD630_E = 30M / 12M, SD630_F = 19M / 12M, SD630_G = 54M / 12M, SD630_L = (114M + 30M) / 12M, RebNo4Req = 71.64M, RebNo4Purch = 80.16M },
        //            new SD630Headwall { SD630HeadwallId = 6, SD630Description = "Double 24\" Pipe Straight Headwall", SD630_I_D = 24M / 12M, PipeNo = PipeSet.Double, SD630_A = 8M / 12M, SD630_B = 12M / 12M, SD630_C = 28M / 12M, SD630_D = 44M / 12M, SD630_E = 36M / 12M, SD630_F = 25M / 12M, SD630_G = 66M / 12M, SD630_L = (138M + 36M) / 12M, RebNo4Req = 92.85M, RebNo4Purch = 100.2M },
        //            new SD630Headwall { SD630HeadwallId = 7, SD630Description = "Double 30\" Pipe Straight Headwall", SD630_I_D = 30M / 12M, PipeNo = PipeSet.Double, SD630_A = 10M / 12M, SD630_B = 14M / 12M, SD630_C = 32M / 12M, SD630_D = 50M / 12M, SD630_E = 45M / 12M, SD630_F = 31M / 12M, SD630_G = 78M / 12M, SD630_L = (162M + 45M)/ 12M, RebNo4Req = 126.92M, RebNo4Purch = 160.32M }

        //        };
        //        return headwalls;
        //}

    }
}
