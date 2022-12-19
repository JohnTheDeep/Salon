using Salon.Models.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalonApp.Models.Data
{

    public class Duty
    {
        [Key]
        public int Id { get; set; }
        public string DutyDate { get; set; }
        [ForeignKey("Salon")]
        public int ?Salon_Id { get; set; }
        public Salons ?Salon { get; set; }
        [ForeignKey("User")]
        public int ?User_Id { get; set; } //Admin
        public Users ?User { get; set; }
        public bool IsVirtualAdmin { get; set; }
        public decimal CashPerDay { get; set; }
        public decimal NonCashPerDay { get; set; }
        public virtual List<Journal> Journals { get; set; } = new List<Journal>();
        public virtual List<Statistic> Statistics { get; set; } = new List<Statistic>();
    }
}
