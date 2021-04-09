using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks; 



namespace SmallStructuresTakeOffs.Models
{
    public class SmallStructure
    {
        [Key]
        public int SmStId { get; set; }
        public int ThisStructure { get; set; }
        public string HWcode { get; set; }
    }
}
