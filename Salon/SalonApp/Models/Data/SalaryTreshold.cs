using System.ComponentModel.DataAnnotations;

namespace SalonApp.Models.Data
{
    public class SalaryTreshold
    {
        [Key]
        public int Id { get; set; }
        public string Threshold { get; set; } = "";
        public decimal Bid { get; set; } = 0;
    }
}
