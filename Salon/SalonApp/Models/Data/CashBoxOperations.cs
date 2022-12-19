using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalonApp.Models.Data
{
    public class CashBoxOperations
    {
        [Key]
        public int Id { get; set; }
        public string Date { get; set; } = "";
        [ForeignKey("CashBox")]
        public int CashBox_Id { get; set; }
        public CashBox CashBox { get; set; }
        public decimal Taken { get; set; } = 0;
        public string Type { get; set; }
        public decimal? LessIn { get; set; } = 0;
        public decimal? Less { get; set; } = 0;
        public int Duty_Id { get; set; } = 0;
    }
}
