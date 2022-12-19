using System.Data.Entity;
using Salon.Models.Data;

namespace Salon
{
    internal class ApplDbContext : DbContext
    {
        public DbSet<SalonModel> _salons { get; set; }
        public ApplDbContext() : base("Server = DESKTOP-V2DHIP8\\DEV; Database=SalonDb; Trusted_Connection=true;") { }
    }
}
