using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalonApp.Models.Data
{
    public class Lasy
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Service")]
        public int Service_Id { get; set; }
        public Services Service { get; set; }
        [ForeignKey("Employee")]
        public int Employee_id { get; set; } 
        public Employees Employee { get; set; }
        public bool IsSelected { get; set; } = false;
    }
}
