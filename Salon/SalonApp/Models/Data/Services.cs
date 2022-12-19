using Salon.Models.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalonApp.Models.Data
{
    public class Services
    {
        [Key]
        public int Id { get; set; }
        public string ServiceName { get; set; }

        public List<Employees> Employees { get; set; } = new List<Employees>();
        public List<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
        public List<Salons> Salons { get; set; } = new List<Salons>();
        public virtual List<Salon_Service> Salon_Service { get; set; } = new List<Salon_Service>();

    }
}
