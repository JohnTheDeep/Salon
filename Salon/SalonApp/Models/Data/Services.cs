using Salon.Models.Data;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SalonApp.Models.Data
{
    public class Services
    {
        [Key]
        public int Id { get; set; }
        public string ServiceName { get; set; }
        public byte[]? ServiceImage { get; set; }
        public string TitleService { get; set; } = "Основная услуга";
        public string TitleHandJob { get; set; } = "Ручная работа";
        public string ServiceType { get; set; } = "";
        public virtual List<Employees> Employees { get; set; } = new List<Employees>();
        public virtual List<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
        public virtual List<Salons> Salons { get; set; } = new List<Salons>();
        public virtual List<Salon_Service> Salon_Service { get; set; } = new List<Salon_Service>();

    }
}
