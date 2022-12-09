using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using SmallStructuresTakeOffs.Models;
using SmallStructuresTakeOffs.Enums;


namespace SmallStructuresTakeOffs.Models
{
    public class SD630_4Of5_Headwall  : Headwall
    {
        //public int SD630HeadwallId { get; set; }
        //public int ThisHeadwall { get; set; }
        //public string HWCode { get; set; }
        //public string SD630Description { get; set; }
        //[ForeignKey("Project")]
        //public long ProjId { get; set; }
        //public Project Project { get; set; }
        //public PipeSet PipeNo { get; set; }
        public override decimal SD630_I_D { get; set; } 
        public override decimal SD630_A { get; set; } 
        public override decimal SD630_B { get; set; }
        public override decimal SD630_C { get; set; } 
        public override decimal SD630_D { get; set; }
        public override decimal SD630_E { get; set; }
        public override decimal SD630_F { get; set; }
        public override decimal SD630_G { get; set; }
        public override decimal SD630_L { get; set; }
        public override decimal SD630_H { get; set; }
        public override decimal SD630_X { get; set; }
        public override decimal SD630_Y { get; set; }
        public override decimal SD630_Z { get; set; }
        public override decimal ConcrCY { get; set; } = 1m;
        public override decimal ReinfLB { get; set; } = 1m;
        public Slope Slopes { get; set; }
        public SkewHW Skews { get; set; }
        public PipeDiameter PipeDiameters { get; set; }
        public override decimal PourBase()
        {

                decimal Apron =  ((2m * (SD630_Y + 1m) + SD630_Z) / 2m) * SD630_E * 9m/12m; // Apron
                decimal LtW = (decimal)Math.Sqrt(Math.Pow((double)SD630_G, (double)2) + Math.Pow((double)SD630_E, (double)2)) * 9m/12m * 9m/12m; // LtWing
                decimal RtW = (decimal)Math.Sqrt(Math.Pow((double)SD630_F, (double)2) + Math.Pow((double)SD630_E, (double)2)) * 9m/12m * 9m/12m; // Rt Wing
                decimal HW = 2m * (SD630_Y + 1m) * 1m * 9m/12m; // HW
                decimal LtHW = ((2m * (decimal)(9d/Math.Sin(Math.PI * 80d/180d)) - 1m * (decimal)(12d/Math.Tan(Math.PI * 80d/180d)))/(2m * 12m)) * 1m * (9m + 6m)/12m; // LtHW
                decimal RtHW = ((2m * (decimal)(9d/Math.Sin(Math.PI * 50d/180d)) - 1m * (decimal)(12d/Math.Tan(Math.PI * 50d/180d)))/(2m * 12m)) * 1m * (9m + 6m)/12m; // RtHW
                decimal ApronCutOffWall = (SD630_Z + 2m * 9m/12m) * 9m/12m * (4m - 9m/12m);

                return
                    (Apron + LtW + RtW + HW + LtHW + RtHW + ApronCutOffWall)/27m;
        }
        public  override decimal PourWall()
        {
                decimal HW = 2m * (SD630_Y + 1m) * SD630_H * 9m/12m;
                decimal PipeDia = (decimal)Math.PI * (decimal)Math.Pow((double)SD630_I_D, 2)/4m;
                decimal LtHW = ((2m * (decimal)(9d/Math.Sin(Math.PI * 80d/180d)) - 1m * (decimal)(12d/Math.Tan(Math.PI * 80d/180d)))/(2m * 12m)) * SD630_H * 1m ; // LtHW
                decimal RtHW = ((2m * (decimal)(9d/Math.Sin(Math.PI * 50d/180d)) - 1m * (decimal)(12d/Math.Tan(Math.PI * 50d/180d)))/(2m * 12m)) * SD630_H * 1m ; // RtHW
                decimal LtW = ((decimal)Math.Sqrt(Math.Pow((double)SD630_G, (double)2) + Math.Pow((double)SD630_E, (double)2)) -1m) * (SD630_H + SD630_X) / 2m * 9m/12m; // LtWing
                decimal RtW = ((decimal)Math.Sqrt(Math.Pow((double)SD630_F, (double)2) + Math.Pow((double)SD630_E, (double)2)) -1m) * (SD630_H + SD630_X) / 2m * 9m/12m; // Rt Wing
                decimal LtWone = (1m) * (SD630_H ) * 9m/12m;
                decimal RtWone = (1m) * (SD630_H ) * 9m/12m;
                return
                   (HW - PipeDia + LtHW + RtHW + LtW + RtW + LtWone + RtWone)/27;
                //(SD630_D * SD630_L - (decimal)Math.PI * (decimal)Math.Pow((double)SD630_I_D, (double)2) / 4) * (8M / 12M) / 27M;
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

        public static List<SD630_4Of5_Headwall> D630HWs
        {
            get
            {
                List<SD630_4Of5_Headwall> headwalls = new()
                {
                    #region 2:1 Slope, 15d Skew
                    new SD630_4Of5_Headwall { 
                        ThisHeadwallId = 1, 
                        Slopes= Slope.Slope2_1, 
                        Skews=SkewHW.Skew15, 
                        HWDescription = "Single 48\" Pipe Windwalls On 2:1 Slope, 15d Skew",
                        PipeDiameters = PipeDiameter.ID_48,
                        SD630_I_D = 48m/12m, 
                        PipeNo = PipeSet.Single, 
                        SD630_A = 6M / 12M, 
                        SD630_B = 10M / 12M, 
                        SD630_C = 24M / 12M, 
                        SD630_D = 38M / 12M, 
                        SD630_E = 8m+2m/12m, 
                        SD630_F = 6m+10.25m/12m, 
                        SD630_G = 1m+5.25m/12m, 
                        SD630_L = 114M / 12M,
                        SD630_H = 6m + 2m/12m,
                        SD630_X = 1m+7m/12m,
                        SD630_Y = 2m+(7m/8m)/12m,
                        SD630_Z = 14m+5.25m/12m,
                        ConcrCY = 6.6m,
                        ReinfLB = 450m,
                        RebNo4Req = 58.78M, 
                        RebNo4Purch = 80.16M
                    },

                    #endregion
                    #region 4:1 Slope, 15d Skew
                    new SD630_4Of5_Headwall { 
                        ThisHeadwallId = 8,
                        Slopes= Slope.Slope4_1,
                        Skews=SkewHW.Skew15,
                        HWDescription = "Single 24\" Pipe Straight Headwall",
                        PipeDiameters = PipeDiameter.ID_48,
                        SD630_I_D = 48M / 12M, 
                        PipeNo = PipeSet.Single, 
                        SD630_A = 8M / 12M, 
                        SD630_B = 12M / 12M, 
                        SD630_C = 28M / 12M, 
                        SD630_D = 44M / 12M, 
                        SD630_E = 14m+3m/12m, 
                        SD630_F = 11m+11.5m/12m, 
                        SD630_G = 2m+6.125m/12m, 
                        SD630_L = 138M / 12M,
                        SD630_H = 6m + 2m/12m,
                        SD630_X = 2m+4m/12m,
                        SD630_Y = 2m+(7m/8m)/12m,
                        SD630_Z = 20m+7.375m/12m,
                        ConcrCY = 11.7m,
                        ReinfLB = 770m,
                        RebNo4Req = 77.49M, 
                        RebNo4Purch = 100.2M },
                    #endregion



                    new SD630_4Of5_Headwall { ThisHeadwallId = 3, PipeDiameters = PipeDiameter.ID_48,  HWDescription = "Single 30\" Pipe Straight Headwall", SD630_I_D = 30M / 12M, PipeNo = PipeSet.Single, SD630_A = 10M / 12M, SD630_B = 14M / 12M, SD630_C = 32M / 12M, SD630_D = 50M / 12M, SD630_E = 45M / 12M, SD630_F = 31M / 12M, SD630_G = 78M / 12M, SD630_L = 162M / 12M, RebNo4Req = 96.19M, RebNo4Purch = 120.24M },
                    new SD630_4Of5_Headwall { ThisHeadwallId = 4, HWDescription = "Single 36\" Pipe Straight Headwall", SD630_I_D = 36M / 12M, PipeNo = PipeSet.Single, SD630_A = 12M / 12M, SD630_B = 16M / 12M, SD630_C = 36M / 12M, SD630_D = 56M / 12M, SD630_E = 54M / 12M, SD630_F = 37M / 12M, SD630_G = 84M / 12M, SD630_L = 186M / 12M, RebNo4Req = 110.22M, RebNo4Purch = 120.24M},
                    new SD630_4Of5_Headwall { ThisHeadwallId = 5, HWDescription = "Single 42\" Pipe Straight Headwall", SD630_I_D = 42M / 12M, PipeNo = PipeSet.Single, SD630_A = 14M / 12M, SD630_B = 18M / 12M, SD630_C = 40M / 12M, SD630_D = 62M / 12M, SD630_E = 63M / 12M, SD630_F = 43M / 12M, SD630_G = 102M / 12M, SD630_L = 210M / 12M, RebNo4Req = 133.60M, RebNo4Purch = 160.32M },
                    new SD630_4Of5_Headwall { ThisHeadwallId = 6, HWDescription = "Double 18\" Pipe Straight Headwall", SD630_I_D = 18M / 12M, PipeNo = PipeSet.Double, SD630_A = 6M / 12M, SD630_B = 10M / 12M, SD630_C = 24M / 12M, SD630_D = 38M / 12M, SD630_E = 30M / 12M, SD630_F = 19M / 12M, SD630_G = 54M / 12M, SD630_L = (114M + 30M) / 12M, RebNo4Req = 71.64M, RebNo4Purch = 80.16M },
                    new SD630_4Of5_Headwall { ThisHeadwallId = 7, HWDescription = "Double 24\" Pipe Straight Headwall", SD630_I_D = 24M / 12M, PipeNo = PipeSet.Double, SD630_A = 8M / 12M, SD630_B = 12M / 12M, SD630_C = 28M / 12M, SD630_D = 44M / 12M, SD630_E = 36M / 12M, SD630_F = 25M / 12M, SD630_G = 66M / 12M, SD630_L = (138M + 36M) / 12M, RebNo4Req = 92.85M, RebNo4Purch = 100.2M },
                    new SD630_4Of5_Headwall { ThisHeadwallId = 9, HWDescription = "Double 30\" Pipe Straight Headwall", SD630_I_D = 30M / 12M, PipeNo = PipeSet.Double, SD630_A = 10M / 12M, SD630_B = 14M / 12M, SD630_C = 32M / 12M, SD630_D = 50M / 12M, SD630_E = 45M / 12M, SD630_F = 31M / 12M, SD630_G = 78M / 12M, SD630_L = (162M + 45M)/ 12M, RebNo4Req = 126.92M, RebNo4Purch = 160.32M }

                };
                return headwalls;
            }
        }
        public SD630_4Of5_Headwall GetTheHW()
        {
            var result =
               (from c in D630HWs
                where c.Slopes == this.Slopes &&
                    c.Skews == this.Skews &&
                    c.PipeDiameters == this.PipeDiameters
                select c).First();

            return result;
        }

        public override ICollection<HWreinforcement> HWreinforcements
        {
            get => this.TheReinforcements(); set => this.TheReinforcements();
        }
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
        public decimal EngHWconcr()
        {
            //if (GotApron)
            //{
            //    // ToDo: Remove CutOff Wall
            //    return GetCBC().EngConcPft * CBCbl * CBCbq;
            //}
            return
                GetTheHW().ConcrCY;
                //GetCBC().EngConcPft* CBCbl * CBCbq;
        }
        public decimal EngHWCreinf()
        {
            //if (GotApron)
            //{
            //    // ToDo: Remove CutOff Wall
            //    return GetCBC().EngReinfPft * CBCbl * CBCbq;
            //}
            return
                GetTheHW().ReinfLB;

            //GetCBC().EngReinfPft * CBCbl * CBCbq;
        }
        public override decimal EngConcr()
        {
            return ConcrCY;
            //throw new NotImplementedException();
        }

        public override decimal EngReinf()
        {
            return ReinfLB;
            //throw new NotImplementedException();
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
