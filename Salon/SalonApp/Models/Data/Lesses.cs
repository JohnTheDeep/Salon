using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalonApp.Models.Data
{
    public class Lesses
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        [ForeignKey("Duty")]
        public int Duty_Id { get; set; }
        public Duty Duty { get; set; }
    }
}
