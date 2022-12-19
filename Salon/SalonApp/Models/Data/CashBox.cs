using Salon.Models.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalonApp.Models.Data
{
    public class CashBox
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Salon")]
        public int SalonId { get; set; }
        public Salons Salon { get; set; }
        public decimal amountCash { get; set; } = 0;
        public decimal amountNonCash { get; set; } = 0;
        public decimal amountTransfers { get; set; } = 0;
    } 
}
