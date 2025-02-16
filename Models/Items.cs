using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lab01ASPWebApp.Models
{
    public class Items
    {
        [Key]
        public int ID { get; set; }


        [Required(ErrorMessage = "Product name is required  !!!")] // this will appear if a didnt put the client side validations
        //[DisplayName("Item Name")]  // if i wanted to change the name of the pinel
        public string Name { get; set; }

        [Required]
        //[Range(10,1000,ErrorMessage ="item range must be between 10 and 1000")] // if i wanted to add a range to the price 
        public decimal Price { get; set; }


        public DateTime CreatedTime { get; set; }= DateTime.Now;

        [Required]
        [DisplayName("category")]
        [ForeignKey("Category")]
        public int CategoryId {  get; set; }
        public Category? Category { get; set; }
    }
}
