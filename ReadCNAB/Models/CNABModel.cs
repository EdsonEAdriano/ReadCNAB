using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace ReadCNAB.Models
{
    public class CNABModel
    {
        [Key]
        public int Id { get; set; }
        public int TranType { get; set; }
        public DateOnly Date { get; set; }
        public double Value { get; set; }
        public long CPF { get; set; }
        public string Card { get; set; }
        public TimeOnly Time { get; set; }
        public string OwnerName { get; set; }
        public string StoreName { get; set; }
    }
}
