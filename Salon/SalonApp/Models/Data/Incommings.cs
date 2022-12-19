using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalonApp.Models.Data
{
    public class Incommings
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("CashBox")]
        public int CashBox_Id { get; set; }
        public CashBox CashBox { get; set; }
        public string Type { get; set; }
        public decimal Total { get; set; }
        public string When { get; set; }
        public string? Comment { get; set; } = "";
    }
}
