using System.ComponentModel.DataAnnotations;

namespace E_COMMERCE_MANAGEMENT.Model
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength (100,MinimumLength =2)]
        public string Name { get; set; }
        [MaxLength(200)]
        public string? Description { get; set; }

        public ICollection<Product> Products { get; set; }=new List<Product>();
    }
}
