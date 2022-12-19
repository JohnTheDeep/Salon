using Salon.Models.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalonApp.Models.Data
{
    public class Duty
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("User")]
        public int? User_Id { get; set; }

        [ForeignKey("Salon")]
        public int ?Salon_Id { get; set; }

        public Salons ?Salon { get; set; }
        public Users ?User { get; set; }
        public string DutyDate { get; set; }

        public bool IsVirtualAdmin { get; set; }
        public decimal CashPerDay { get; set; } = 0;
        public decimal NonCashPerDay { get; set; } = 0; 
        public decimal TransfersPerDay { get; set; } = 0;
        public decimal TotalSertificates { get; set; } = 0;
        public decimal Total { get; set; } = 0;
        public decimal Income { get; set; } = 0;
        public decimal Taken { get; set; } = 0;
        public bool IsArrived { get; set; } = false;
        public DateTime newcol { get; set; } = DateTime.Today;
        public virtual List<Journal> Journals { get; set; }
        public virtual List<Statistic> Statistics { get; set; }
    }
}
