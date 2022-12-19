using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalonApp.Models.Data
{
    public class Additional
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Duty")]
        public int DutyId { get; set; } 
        public Duty Duty { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public Users User { get; set; }

        public string ClientName { get; set; } 
        public decimal Cash { get; set; } = 0;
        public decimal NonCash { get; set; } = 0;
        public decimal Sertificate { get; set; } = 0;
        public decimal DiscountCash { get; set; } = 0;
        public decimal DiscountNonCash { get; set; } = 0;
        public decimal Fictive { get; set; } = 0;
        public decimal UserTotal { get; set; } = 0;
        public bool IsSertificate { get; set; } = false;
    }
}
