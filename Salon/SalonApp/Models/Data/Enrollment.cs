using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalonApp.Models.Data
{
    public class Enrollment
    {
        [Key]
        public int Id { get; set; }
        public int ServiceId { get; set; }
        public Services Service { get; set; }

        public int EmployeeId { get; set; }
        public Employees Employee { get; set; }

        public string? Comment { get; set; } = "defaultComment";
    }
}
