using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalonApp.Models.Data
{
    public class DutyStat
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Service")]
        public int ServicesId { get; set; }
        public Services Service { get; set; }

        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        public Employees Employee { get; set; }
        public decimal TotalCash { get; set; } = 0;
        public decimal TotalNonCash { get; set; } = 0;
        public decimal TotalFictive { get; set; } = 0;
        public decimal TotalSertificates { get; set; } = 0;
        public virtual List<Journal> Journals { get; set; } = new List<Journal>();
    }
}
