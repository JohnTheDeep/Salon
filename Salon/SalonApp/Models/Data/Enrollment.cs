using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalonApp.Models.Data
{
    public class Enrollment
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Service")]
        public int ServiceId { get; set; }
        public Services? Service { get; set; }
        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        public Employees? Employee { get; set; }
        public decimal Percent { get; set; } = 0;
        public string? Comment { get; set; } = "";
    }
}
