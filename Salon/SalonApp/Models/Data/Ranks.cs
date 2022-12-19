using SalonApp.Services.DbCommands;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalonApp.Models.Data
{
    public class Ranks
    {
        [Key]
        public int Id { get; set; }
        public string RankName { get; set; }
        public string? Description { get; set; }
        public virtual List<Employees>? Employees { get; set; } = new List<Employees>();
        [NotMapped]
        public List<Employees>? RanksEmployees => Controller.GetEmployeesByRankId(Id);
    }
}
