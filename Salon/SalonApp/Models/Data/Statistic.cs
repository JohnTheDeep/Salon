using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SalonApp.Models.Data
{
    public class Statistic
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Duty")]
        public int Duty_Id { get; set; }
        public Duty Duty { get; set; }  
        [ForeignKey("Employee")]
        public int Employee_Id { get; set; }
        public Employees Employee { get; set; }
        public bool IsAdmin { get; set; } = false;
        public decimal Total { get; set; } = default;
        public bool IsVirtualAdmin { get; set; }
        public bool isArrivedVirtualAdminBid { get; set; } = false;
        public decimal BaseBid { get; set; } = 0;
        public decimal VirtualAdminBid { get; set; } = 0;
        public decimal? Salary { get; set; } = 0;
    }
}
