using Salon.Models.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalonApp.Models.Data
{
    public class Salon_Service
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Salon")]
        public int Salon_id { get; set; }
        public Salons Salon { get; set; }
        [ForeignKey("Service")]
        public int Service_Id { get; set; }
        public Services Service { get; set; }
        public bool IsActive { get; set; } = false;
        public string? Comment { get; set; }
    }
}
