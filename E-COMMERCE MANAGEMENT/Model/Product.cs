using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_COMMERCE_MANAGEMENT.Model
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(1000,MinimumLength =2)]
        public string Name { get; set; }
        [MaxLength(200)]
        public string? Description { get; set; }
        [Required]
        [Range(0.01,1000000)]
        public decimal Price { get; set; }
        [Required]
        [Range(1, 1000000)]
        public int StockQuantaty { get; set; }  

        public int CatgoryID { get; set; }
        [ForeignKey("CatgoryID")]
        public Category? Category { get; set; }    

        public ICollection<OrderItem> orderItems { get; set; }   = new List<OrderItem>();

    }
}
