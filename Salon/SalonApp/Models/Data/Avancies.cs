using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalonApp.Models.Data
{
    public class Avancies
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Employee")]
        public int Employee_Id { get; set; }
        public Employees Employee { get; set; }
        public int Duty_Id { get; set; }
        public string WhenString { get; set; } = "";
        public DateTime? When { get; set; }
        public decimal Total { get; set; } = 0;
        public decimal Fine { get; set; } = 0;
        public string DateIn { get; set; }
        public string DateOut { get; set; }
        public bool IsDeduction { get; set; } = false;
        public DateTime? DateIn2 { get; set; } = DateTime.Now;
        public DateTime? DateOut2 { get; set; } = DateTime.Now;
    }
}
