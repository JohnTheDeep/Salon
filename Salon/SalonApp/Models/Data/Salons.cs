using SalonApp.Models.Data;
using SalonApp.Services.DbCommands;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Salon.Models.Data
{
    public class Salons
    {
        [Key]
        public int Id { get; set; }
        public string SalonName { get; set; }
        public string Director { get; set; }
        public virtual List<Employees> Employees { get; set; }
        [NotMapped]
        public List<Employees> SalonEmployees =>
            Controller.GetEmployeesBySalonId(Id);
    
        public List<Services> Services { get; set; } = new List<Services>();
        public List<Salon_Service> Salon_Service { get; set; } = new List<Salon_Service>();
    }
}
