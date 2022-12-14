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
        public override PipeSet PipeNo { get; set; }
        public Slope Slopes { get; set; }
        public SkewHW Skews { get; set; }
        public PipeDiameter PipeDiameters { get; set; }
        public override decimal PourBase()
        {
            switch (Skews)
            {
                case SkewHW.Skew15:
                    {
                        decimal Apron = ((2m * (SD630_Y + 1m) + SD630_Z) / 2m) * SD630_E * 9m/12m; // Apron
                        decimal LtW = (decimal)Math.Sqrt(Math.Pow((double)SD630_G, (double)2) + Math.Pow((double)SD630_E, (double)2)) * 9m/12m * 9m/12m; // LtWing
                        decimal RtW = (decimal)Math.Sqrt(Math.Pow((double)SD630_F, (double)2) + Math.Pow((double)SD630_E, (double)2)) * 9m/12m * 9m/12m; // Rt Wing
                        decimal HW = 2m * (SD630_Y + 1m) * 1m * (9m+6m)/12m; // HW
                        decimal LtHW = ((2m * (decimal)(9d/Math.Sin(Math.PI * 80d/180d)) - 1m * (decimal)(12d/Math.Tan(Math.PI * 80d/180d)))/(2m * 12m)) * 1m * (9m + 6m)/12m; // LtHW
                        decimal RtHW = ((2m * (decimal)(9d/Math.Sin(Math.PI * 50d/180d)) - 1m * (decimal)(12d/Math.Tan(Math.PI * 50d/180d)))/(2m * 12m)) * 1m * (9m + 6m)/12m; // RtHW
                        decimal ApronCutOffWall = (SD630_Z + 2m * 9m/12m) * 9m/12m * (4m - 9m/12m);

                        return
                            (Apron + LtW + RtW + HW + LtHW + RtHW + ApronCutOffWall)/27m;

                    }
                case SkewHW.Skew30:
                    {
                        decimal Apron = ((2m * (SD630_Y + 1m+2m/12m) + SD630_Z) / 2m) * SD630_E * 9m/12m; // Apron
                        decimal ApronCutOffWall = (SD630_Z + 2m * 9m/12m) * 9m/12m * (4m - 9m/12m); // Apron Cutoff Wall
                        decimal LtW = SD630_E * 9m/12m * 9m/12m; // LtWing
                        decimal RtW = (decimal)Math.Sqrt(Math.Pow((double)SD630_F, (double)2) + Math.Pow((double)SD630_E, (double)2)) * 9m/12m * 9m/12m; // Rt Wing
                        decimal HW = 2m * (SD630_Y + 1m+2m/12m) * 1m * (9m + 6m)/12m; // HW
                        decimal LtHW = 9m/12m * 1m * (9m + 6m)/12m; // LtHW
                        decimal RtHW = ((2m * (decimal)(9d/Math.Sin(Math.PI * 40d/180d)) - 1m * (decimal)(12d/Math.Tan(Math.PI * 40d/180d)))/(2m * 12m)) * 1m * (9m + 6m)/12m; // RtHW

                        return
                            (Apron + ApronCutOffWall + LtW + RtW + HW + LtHW + RtHW )/27m;

                    }
                case SkewHW.Skew45:
                    {
                        decimal Apron = ((2m * (SD630_Y + 1m+4m/12m) + SD630_Z) / 2m) * SD630_E * 9m/12m; // Apron
                        decimal ApronCutOffWall = (SD630_Z + 2m * 9m/12m) * 9m/12m * (4m - 9m/12m); // Apron Cutoff Wall
                        decimal LtW = SD630_E * 9m/12m * 9m/12m; // LtWing
                        decimal RtW = (decimal)Math.Sqrt(Math.Pow((double)SD630_F, (double)2) + Math.Pow((double)SD630_E, (double)2)) * 9m/12m * 9m/12m; // Rt Wing
                        decimal HW = 2m * (SD630_Y + 1m+4m/12m) * 1m * (9m + 6m)/12m; // HW
                        decimal LtHW = 9m/12m * 1m * (9m + 6m)/12m; // LtHW
                        decimal RtHW = ((2m * (decimal)(9d/Math.Sin(Math.PI * 25d/180d)) - 1m * (decimal)(12d/Math.Tan(Math.PI * 25d/180d)))/(2m * 12m)) * 1m * (9m + 6m)/12m; // RtHW

                        return
                            (Apron + ApronCutOffWall + LtW + RtW + HW + LtHW + RtHW)/27m;
                    }
                default:
                    return 0;
            }
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

        public static List<SD630_4Of5_Headwall> D630HWs
        {
            get
            {
                List<SD630_4Of5_Headwall> headwalls = new()
                {
                    #region 15d Skew, 2:1 Slope
                    new SD630_4Of5_Headwall { 
                        ThisHeadwallId = 1, 
                        HWDescription = "Single 48\" Pipe Wingwalls On 2:1 Slope, 15d Skew",
                        Slopes= Slope.Slope2_1,
                        Skews=SkewHW.Skew15,
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
                        SD630_H = 6m + 2m/12m,
                        SD630_L = 114M / 12M,
                        SD630_X = 1m+7m/12m,
                        SD630_Y = 2m+(7m/8m)/12m,
                        SD630_Z = 14m+5.25m/12m,
                        ConcrCY = 6.6m,
                        ReinfLB = 450m
                    },
                    new SD630_4Of5_Headwall { 
                        ThisHeadwallId = 2, 
                        HWDescription = "Single 54\" On 2:1 Slope, 15d Skew",
                        Slopes= Slope.Slope2_1,
                        Skews=SkewHW.Skew15,
                        PipeDiameters = PipeDiameter.ID_54,
                        SD630_I_D = 54M/12M, 
                        PipeNo = PipeSet.Single, 
                        SD630_A = 10M / 12M, 
                        SD630_B = 14M / 12M, 
                        SD630_C = 32M / 12M, 
                        SD630_D = 50M / 12M, 
                        SD630_E = 9m, 
                        SD630_F = 7m+6.625m/12m, 
                        SD630_G = 1m+7m/12m,
                        SD630_H = 6m + 8m/12m,
                        SD630_L = 162M / 12M,
                        SD630_X = 1m+8m/12m,
                        SD630_Y = 2m+4m/12m,
                        SD630_Z = 15m+9.625m/12m,
                        ConcrCY = 7.5m,
                        ReinfLB = 540m,
                    },
                    new SD630_4Of5_Headwall { 
                        ThisHeadwallId = 3, 
                        HWDescription = "Single 60\" On 2:1 Slope, 15d Skew",
                        Slopes= Slope.Slope2_1,
                        Skews=SkewHW.Skew15,
                        PipeDiameters = PipeDiameter.ID_60,
                        SD630_I_D = 60M / 12M, 
                        PipeNo = PipeSet.Single, 
                        SD630_A = 12M/12M, 
                        SD630_B = 16M/12M, 
                        SD630_C = 36M/12M, 
                        SD630_D = 56M/12M, 
                        SD630_E = 9m + 10M/12M, 
                        SD630_F = 8m + 3M / 12M, 
                        SD630_G = 1m + 8.75M / 12M,
                        SD630_H = 7m + 2m/12m,
                        SD630_L = 186M / 12M,
                        SD630_X = 1m+9m/12m,
                        SD630_Y = 2m+7m/12m,
                        SD630_Z = 17m+1.75m/12m,
                        ConcrCY = 8.5m,
                        ReinfLB = 625m,
                    },
                    new SD630_4Of5_Headwall { 
                        ThisHeadwallId = 4,
                        HWDescription = "Single 66\" On 2:1 Slope, 15d Skew",
                        Slopes= Slope.Slope2_1,
                        Skews=SkewHW.Skew15,
                        PipeDiameters = PipeDiameter.ID_66,
                        SD630_I_D = 66M / 12M, 
                        PipeNo = PipeSet.Single, 
                        SD630_A = 14M / 12M, 
                        SD630_B = 18M / 12M, 
                        SD630_C = 40M / 12M, 
                        SD630_D = 62M / 12M, 
                        SD630_E = 10m + 8M / 12M, 
                        SD630_F = 8m + 11.375M / 12M, 
                        SD630_G = 1m + 10.625M / 12M,
                        SD630_H = 7m + 8m/12m,
                        SD630_L = 210M / 12M,
                        SD630_X = 1m+10m/12m,
                        SD630_Y = 2m+10.125m/12m,
                        SD630_Z = 18m+6.25m/12m,
                        ConcrCY = 9.7m,
                        ReinfLB = 715m,
                    },
                    new SD630_4Of5_Headwall { 
                        ThisHeadwallId = 5, 
                        HWDescription = "Single 72\" On 2:1 Slope, 15d Skew",
                        Slopes= Slope.Slope2_1,
                        Skews=SkewHW.Skew15,
                        PipeDiameters = PipeDiameter.ID_72,
                        SD630_I_D = 72M / 12M, 
                        PipeNo = PipeSet.Single, 
                        SD630_A = 6M / 12M, 
                        SD630_B = 10M / 12M, 
                        SD630_C = 24M / 12M, 
                        SD630_D = 38M / 12M, 
                        SD630_E = 11m + 6M / 12M, 
                        SD630_F = 9m + 7.75M / 12M, 
                        SD630_G = 2m + 0.5M / 12M,
                        SD630_H = 8m + 2m/12m,
                        SD630_L = (114M + 30M) / 12M,
                        SD630_X = 1m+11m/12m,
                        SD630_Y = 3m+1.125m/12m,
                        SD630_Z = 19m+10.75m/12m,
                        ConcrCY = 10.6m,
                        ReinfLB = 800m,
                    },
                    new SD630_4Of5_Headwall { 
                        ThisHeadwallId = 6, 
                        HWDescription = "Single 78\" Pipe On 2:1 Slope, 15d Skew",
                        Slopes= Slope.Slope2_1,
                        Skews=SkewHW.Skew15,
                        PipeDiameters = PipeDiameter.ID_78,
                        SD630_I_D = 78M / 12M, 
                        PipeNo = PipeSet.Single, 
                        SD630_A = 8M / 12M, 
                        SD630_B = 12M / 12M, 
                        SD630_C = 28M / 12M, 
                        SD630_D = 44M / 12M, 
                        SD630_E = 12m + 4M / 12M, 
                        SD630_F = 10m + 4.125M / 12M, 
                        SD630_G = 2m + 4.25M / 12M,
                        SD630_H = 8m + 8m/12m,
                        SD630_L = (138M + 36M) / 12M,
                        SD630_X = 2m+0m/12m,
                        SD630_Y = 3m+4.375m/12m,
                        SD630_Z = 21m+5.125m/12m,
                        ConcrCY = 11.8m,
                        ReinfLB = 890m,

                    },
                    #endregion
                    #region 15d Skew, 4:1 Slope
                    new SD630_4Of5_Headwall { 
                        ThisHeadwallId = 8,
                        HWDescription = "Single 48\" Pipe On 4:1 Slope, 15d Skew",
                        Slopes= Slope.Slope4_1,
                        Skews=SkewHW.Skew15,
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
                    },
                    new SD630_4Of5_Headwall { 
                        ThisHeadwallId = 9, 
                        HWDescription = "Single 54\" Pipe On 4:1 Slope, 15d Skew",
                        Slopes= Slope.Slope4_1,
                        Skews=SkewHW.Skew15,
                        PipeDiameters = PipeDiameter.ID_48,
                        SD630_I_D = 54M / 12M, 
                        PipeNo = PipeSet.Single, 
                        SD630_A = 10M / 12M, 
                        SD630_B = 14M / 12M, 
                        SD630_C = 32M / 12M, 
                        SD630_D = 50M / 12M, 
                        SD630_E = 15m + 6M / 12M, 
                        SD630_F = 13m + 0.125M / 12M, 
                        SD630_G = 2m + 8.75M / 12M,
                        SD630_H = 6m + 8m/12m,
                        SD630_L = (162M + 45M)/ 12M,
                        SD630_X = 2m + 6m/12m,
                        SD630_Y = 2m + 4m/12m,
                        SD630_Z = 22m + 4.875m/12m,
                        ConcrCY = 13.4m,
                        ReinfLB = 930m,
                    },
                    #endregion
                    #region 15d Skew, 6:1 Slope 
                    new SD630_4Of5_Headwall {
                        ThisHeadwallId = 15,
                        HWDescription = "Single 48\" Pipe On 6:1 Slope, 15d Skew",
                        Slopes= Slope.Slope6_1,
                        Skews=SkewHW.Skew15,
                        PipeDiameters = PipeDiameter.ID_48,
                        SD630_I_D = 54M / 12M,
                        PipeNo = PipeSet.Single,
                        SD630_A = 10M / 12M,
                        SD630_B = 14M / 12M,
                        SD630_C = 32M / 12M,
                        SD630_D = 50M / 12M,
                        SD630_E = 18m + 0M / 12M,
                        SD630_F = 15m + 1.25M / 12M,
                        SD630_G = 3m + 2.125M / 12M,
                        SD630_H = 6m + 2m/12m,
                        SD630_L = (162M + 45M)/ 12M,
                        SD630_X = 3m + 3m/12m,
                        SD630_Y = 2m + .875m/12m,
                        SD630_Z = 24m + 5.125m/12m,
                        ConcrCY = 16.1m,
                        ReinfLB = 1040m
                    },

                    #endregion
                    #region 30d Skew, 2:1 Slope

                    #endregion
                    #region 30d Skew, 4:1 Slope
                    new SD630_4Of5_Headwall {
                        ThisHeadwallId = 108,
                        HWDescription = "Single 48\" Pipe On 4:1 Slope, 30d Skew",
                        Slopes= Slope.Slope4_1,
                        Skews=SkewHW.Skew30,
                        PipeDiameters = PipeDiameter.ID_48,
                        SD630_I_D = 48M / 12M,
                        PipeNo = PipeSet.Single,
                        SD630_A = 8M / 12M,
                        SD630_B = 12M / 12M,
                        SD630_C = 28M / 12M,
                        SD630_D = 44M / 12M,
                        SD630_E = 11m+0m/12m,
                        SD630_F = 13m+1.25m/12m,
                        SD630_G = 2m+6.125m/12m,
                        SD630_L = 138M / 12M,
                        SD630_H = 6m + 2m/12m,
                        SD630_X = 3m+3m/12m,
                        SD630_Y = 2m+3.75m/12m,
                        SD630_Z = 20m+9.75m/12m,
                        ConcrCY = 11m,
                        ReinfLB = 680m,
                    },

                    #endregion
                    #region 30d Skew, 6:1 Slope

                    #endregion
                    #region 45d Skew, 2:1 Slope
                    new SD630_4Of5_Headwall {
                        ThisHeadwallId = 201,
                        HWDescription = "Single 48\" Pipe On 6:1 Slope, 45d Skew",
                        Slopes= Slope.Slope6_1,
                        Skews=SkewHW.Skew45,
                        PipeDiameters = PipeDiameter.ID_48,
                        SD630_I_D = 48M / 12M,
                        PipeNo = PipeSet.Single,
                        SD630_A = 10M / 12M,
                        SD630_B = 14M / 12M,
                        SD630_C = 32M / 12M,
                        SD630_D = 50M / 12M,
                        SD630_E = 12m + 0M / 12M,
                        SD630_F = 25m + 8.75M / 12M,
                        SD630_G = 3m + 2.125M / 12M,
                        SD630_H = 6m + 2m/12m,
                        SD630_L = (162M + 45M)/ 12M,
                        SD630_X = 4m + 0m/12m,
                        SD630_Y = 2m + 10m/12m,
                        SD630_Z = 34m + 9.75m/12m,
                        ConcrCY = 17.5m,
                        ReinfLB = 1150m
                    },

                    #endregion
                    #region 45d Skew, 4:1 Slope
                    new SD630_4Of5_Headwall {
                        ThisHeadwallId = 208,
                        HWDescription = "Single 48\" Pipe On 6:1 Slope, 45d Skew",
                        Slopes= Slope.Slope6_1,
                        Skews=SkewHW.Skew45,
                        PipeDiameters = PipeDiameter.ID_48,
                        SD630_I_D = 48M / 12M,
                        PipeNo = PipeSet.Single,
                        SD630_A = 10M / 12M,
                        SD630_B = 14M / 12M,
                        SD630_C = 32M / 12M,
                        SD630_D = 50M / 12M,
                        SD630_E = 12m + 0M / 12M,
                        SD630_F = 25m + 8.75M / 12M,
                        SD630_G = 3m + 2.125M / 12M,
                        SD630_H = 6m + 2m/12m,
                        SD630_L = (162M + 45M)/ 12M,
                        SD630_X = 4m + 0m/12m,
                        SD630_Y = 2m + 10m/12m,
                        SD630_Z = 34m + 9.75m/12m,
                        ConcrCY = 17.5m,
                        ReinfLB = 1150m
                    },

                    #endregion
                    #region 45d Skew, 6:1 Slope
                    new SD630_4Of5_Headwall {
                        ThisHeadwallId = 215,
                        HWDescription = "Single 48\" Pipe On 6:1 Slope, 45d Skew",
                        Slopes= Slope.Slope6_1,
                        Skews=SkewHW.Skew45,
                        PipeDiameters = PipeDiameter.ID_48,
                        SD630_I_D = 48M / 12M,
                        PipeNo = PipeSet.Single,
                        SD630_A = 10M / 12M,
                        SD630_B = 14M / 12M,
                        SD630_C = 32M / 12M,
                        SD630_D = 50M / 12M,
                        SD630_E = 12m + 0M / 12M,
                        SD630_F = 25m + 8.75M / 12M,
                        SD630_G = 3m + 2.125M / 12M,
                        SD630_H = 6m + 2m/12m,
                        SD630_L = (162M + 45M)/ 12M,
                        SD630_X = 4m + 0m/12m,
                        SD630_Y = 2m + 10m/12m,
                        SD630_Z = 34m + 9.75m/12m,
                        ConcrCY = 17.5m,
                        ReinfLB = 1150m
                    }

                    #endregion
                };
                return headwalls;
            }
        }
        public override SD630_4Of5_Headwall GetTheHW()
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
        }
        public override decimal EngReinf()
        {
            return ReinfLB;
        }

    }
}
