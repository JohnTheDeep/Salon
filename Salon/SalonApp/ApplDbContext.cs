
using Microsoft.EntityFrameworkCore;
using Salon.Models.Data;
using SalonApp.Models.Data;
using SalonApp.Services.DbCommands;
using System.Reflection.Metadata;
using System.Windows.Input;

namespace Salon
{
    internal class ApplDbContext : DbContext
    {
        public DbSet<Salons> SalonsT { get; set; }
        public DbSet<Employees> EmployeesT { get; set; }
        public DbSet<Ranks> RanksT { get; set; }
        public DbSet<Users> UsersT { get; set; }
        public DbSet<Services> ServicesT { get; set; }
        public DbSet<Salon_Service> Salon_Service { get; set; }
        public DbSet<Journal> JournalT { get; set; }
        public DbSet<Duty> DutyT { get; set; }
        public DbSet<Statistic> StatisticT { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public ApplDbContext()
        {
            Database.EnsureCreated();
           
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Server = DESKTOP-V2DHIP8\\DEV; Database=SalonDbTEST; Trusted_Connection=true;");
            optionsBuilder.UseSqlServer("Server = 94.124.78.213; Database=SalonDbTEST; Integrated Security=false; User Id=sa; Password=LoveIsMSSQLDb_2022;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Services>()
                .HasMany(c => c.Employees)
                .WithMany(s => s.Services)
                .UsingEntity<Enrollment>(
                   j => j
                    .HasOne(pt => pt.Employee)
                    .WithMany(t => t.Enrollments)
                    .HasForeignKey(pt => pt.EmployeeId),
                j => j
                    .HasOne(pt => pt.Service)
                    .WithMany(p => p.Enrollments)
                    .HasForeignKey(pt => pt.ServiceId),
                j =>
                {
                    j.Property(pt => pt.Comment);
                    j.HasKey(t => new { t.ServiceId, t.EmployeeId });
                    j.ToTable("Enrollments");
                });
        }
    }
}
