using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public decimal Total { get; set; }
        public bool IsVirtualAdmin { get; set; }
    }
}
