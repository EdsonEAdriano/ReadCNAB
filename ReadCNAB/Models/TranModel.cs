using System.ComponentModel.DataAnnotations;

namespace ReadCNAB.Models
{
    public class TranModel
    {
        [Key]
        public int TranType { get; set; }
        public string Description { get; set; }
        public string Nature { get; set; }
        public string Signal { get; set; }
    }
}
