using System.ComponentModel.DataAnnotations;

namespace E_COMMERCE_MANAGEMENT.DTOs.Product
{
    public class CreateUpdatePruduct
    {
        [Required]
        [StringLength(1000, MinimumLength = 2)]
        public string Name { get; set; }
        [MaxLength(200)]
        public string? Description { get; set; }
        [Required]
        [Range(0.01, 1000000)]
        public decimal Price { get; set; }
        [Required]
        [Range(1, 1000000)]
        public int StockQuantaty { get; set; }

        public int CatgoryID { get; set; }
    }
}
