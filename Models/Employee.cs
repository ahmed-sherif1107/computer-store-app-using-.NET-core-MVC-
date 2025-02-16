using System.ComponentModel.DataAnnotations;

namespace lab01ASPWebApp.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public string? Email { get; set; }
        [Required]
        public int? Phone { get; set; }
        public int? Age { get; set; }
        public int? Salary { get; set; }
    }
}
