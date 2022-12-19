using Salon.Models.Data;
using SalonApp.Services.DbCommands;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalonApp.Models.Data
{
    public class Employees
    {
        [Key]
        public int Id { get; set; }
        public string FullName { get; set; }

        [ForeignKey("Salon")]
        public int Salon_Id { get; set; }
        [ForeignKey("Rank")]
        public int? Rank_Id { get; set; }
        public virtual Salons Salon { get; set; }
        public virtual Ranks? Rank { get; set; } 
        public bool IsAdmin { get; set; }
        public bool IsActive { get; set; } = false;
        public string Email { get; set; } = "";
        public decimal Ppackage { get; set; } = 0;
        public decimal Pdepilation { get; set; } = 0;
        public decimal Pmassage { get; set; } = 0;
        public decimal Pelectrodepilation { get; set; } = 0;
        public decimal Phandmassage { get; set; } = 0;
        public decimal Paddit { get; set; } = 0;
        public decimal Pfictive { get; set; } = 0;
        public decimal Bid { get; set; } = 0;

        public Salons EmployeeSalon => Controller.GetSalonById(Salon_Id);

        public List<Services> Services { get; set; } = new List<Services>();
        public List<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
        public List<Journal> Journals { get; set; } = new List<Journal>();
        public List<Statistic> Statistics { get; set; } = new List<Statistic>();
        public Employees()
        {

        }
        public Employees(string fullName, int salon_id , int rank_id, bool isAdmin, string email = "", decimal ppackage = 0, decimal pdepilation = 0, decimal pmassage = 0, decimal pelectrodepilation = 0, decimal phandmassage = 0, decimal paddit = 0, decimal pfictive = 0, decimal bid = 0, bool isActive = false)
        {
            FullName = fullName;
            Salon_Id = salon_id;
            Rank_Id = rank_id;
            IsAdmin = isAdmin;
            IsActive = isActive;
            Email = email;
            Ppackage = ppackage;
            Pdepilation = pdepilation;
            Pmassage = pmassage;
            Pelectrodepilation = pelectrodepilation;
            Phandmassage = phandmassage;
            Paddit = paddit;
            Pfictive = pfictive;
            Bid = bid;
        }
    }
}
