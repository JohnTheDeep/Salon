using SalonApp.Services.DbCommands;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalonApp.Models.Data
{
    public class Users
    {
        [Key]
        public int Id { get; set; }
        public string NickName { get; set; }
        public string Password { get; set; }
        [ForeignKey("Employee")]
        public int Employee_Id { get; set; }
        public string UserType { get; set; }
        public decimal? Ppackage { get; set; } = 0;
        public decimal? Paddit { get; set; } = 0;
        public decimal? VirtualAdminBid { get; set; } = 0;
        public decimal Psertificate { get; set; } = 0;
        public virtual Employees Employee { get; set; }
        public Employees UserEmployee => Controller.GetEmployeeById(Employee_Id);
    }
}
