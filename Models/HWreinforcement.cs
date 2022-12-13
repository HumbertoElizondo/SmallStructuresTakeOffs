using System.ComponentModel.DataAnnotations.Schema;

namespace SmallStructuresTakeOffs.Models
{
    public class HWreinforcement
    {
        //[ForeignKey("Project")]

        public int HWreinforcementId { get; set; }
        [ForeignKey("Headwall")]
        public int HWId { get; set; }

        //public string CBreinforcementName { get; set; }
        public string HWreinfCode { get; set; }

        public string HWreinfShape { get; set; }

        public decimal HWreinfLength { get; set; }

        public int HWreinfQty { get; set; }

        public decimal HWTotalLength { get; set; }

        public decimal HWTotalWeight { get; set; }

        public  RebarNomination HWRebarNom { get; set; }

        //public Rebar CBRebar { get; set; }
    }
}
