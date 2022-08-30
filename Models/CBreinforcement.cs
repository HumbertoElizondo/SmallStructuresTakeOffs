namespace SmallStructuresTakeOffs.Models
{
    public class CBreinforcement
    {
        public int CBreinforcementId { get; set; }

        public int CBId { get; set; }

        //public string CBreinforcementName { get; set; }
        public string CBreinfCode { get; set; }

        public string CBreinfShape { get; set; }

        public decimal CBreinfLength { get; set; }

        public int CBreinfQty { get; set; }

        public decimal TotalLength { get; set; }

        public decimal TotalWeight { get; set; }

        public  RebarNomination CBRebarNom { get; set; }

        //public Rebar CBRebar { get; set; }
    }
}
