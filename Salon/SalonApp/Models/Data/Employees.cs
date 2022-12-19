using Salon.Models.Data;
using SalonApp.Services.DbCommands;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public decimal Paddit { get; set; } = 0;
        public decimal Pfictive { get; set; } = 0;
        public decimal Phandjob { get; set; } = 0;
        public decimal Bid { get; set; } = 0;
        public decimal EntryTreshold { get; set; } = 0;
        public bool IsDelete { get; set; } = false;
        public bool IsEmail { get; set; } = true;
        public Salons EmployeeSalon => Controller.GetSalonById(Salon_Id);
        public virtual List<Services> Services { get; set; } = new List<Services>();
        public virtual List<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
        public virtual List<Journal> Journals { get; set; } = new List<Journal>();
        public virtual List<Statistic> Statistics { get; set; } = new List<Statistic>();
        public Employees() { }
        public Employees(string fullName, int salon_id , int rank_id, bool isAdmin, string email = "", decimal ppackage = 0, decimal pdepilation = 0, decimal pmassage = 0, decimal pelectrodepilation = 0, decimal phandmassage = 0, decimal paddit = 0, decimal pfictive = 0, decimal bid = 0, bool isActive = false, decimal treshold = 0, decimal phandjob = 0)
        {
            FullName = fullName;
            Salon_Id = salon_id;
            Rank_Id = rank_id;
            IsAdmin = isAdmin;
            IsActive = isActive;
            Email = email;
            Ppackage = ppackage;
            Paddit = paddit;
            Pfictive = pfictive;
            Bid = bid;
            EntryTreshold = treshold;
            Phandjob = phandjob;
        }
    }
}
