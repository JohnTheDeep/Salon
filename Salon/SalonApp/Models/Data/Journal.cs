using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SalonApp.Models.Data
{
    public class Journal
    {
        [Key]
        public int Id { get; set; }
        public int DutyId { get; set; }
        public Duty Duty { get; set; }
        [ForeignKey("Service")]
        public int ?Service_Id { get; set; }
        public Services ?Service { get; set; }
        [ForeignKey("Employee")]
        public int ?Employee_id { get; set; }
        public Employees ?Employee { get; set; }
        public string ClientName { get; set; } = "";
        public decimal Cash { get; set; } = 0;
        public decimal NonCash { get; set; } = 0;
        public decimal Transfer { get; set; } = 0;
        public decimal Fictive { get; set; } = 0;
        public decimal Package { get; set; } = 0;
        public decimal PackageCash { get; set; } = 0;
        public decimal PackageNonCash { get; set; } = 0;
        public decimal PackageTransfer { get; set; } = 0;
        public decimal AdditCash { get; set; } = 0;
        public decimal AdditNonCash { get; set; } = 0;
        public decimal HandJobCash { get; set; } = 0;
        public decimal HandJobNonCash { get; set; } = 0;
        public decimal Sertificate { get; set; } = 0;
        public decimal Total { get; set; } = 0;
        public decimal UserTotal { get; set; } = 0;
    }
}
