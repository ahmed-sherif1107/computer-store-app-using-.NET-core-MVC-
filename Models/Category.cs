using System.ComponentModel.DataAnnotations;

namespace lab01ASPWebApp.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public ICollection<Items>? Items { get; set; }
    }
}
