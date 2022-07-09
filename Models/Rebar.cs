using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallStructuresTakeOffs.Models
{
    public class Rebar
    {
        public int RebarId { get; set; }
        public RebarNomination RebarNom { get; set; }
        public RebarNomLength RebarLength { get; set; }
        public RebarNomWeight RebarWeight { get; set; }
    }

    public enum RebarNomLength
    {
        StickL8 = 8,
        StickL16 = 16,
        RebL20 = 20,
        RebL30 = 30,
        RebL40 = 40,
        RebL60 = 60
    }

    // enum doesn't take decimal values...
    public class RebarNomWeight
    {
        static decimal RebWNo2Weight => 0.167M;
        static decimal RebWNo3Weight => 0.376M;
        static decimal RebWNo4Weight => 0.668M;
        static decimal RebWNo5Weight => 1.050M;
    }

    public enum RebarNomination
    {
        No2,
        No3,
        No4,
        No5
    }
   
}
