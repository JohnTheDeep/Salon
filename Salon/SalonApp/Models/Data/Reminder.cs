using Salon.Models.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalonApp.Models.Data
{
    public class Reminder
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Salon")]
        public int Salon_Id { get; set; }
        public Salons Salon { get; set; }
        public string Day { get; set; }
        public string Message { get; set; }
    }
}
