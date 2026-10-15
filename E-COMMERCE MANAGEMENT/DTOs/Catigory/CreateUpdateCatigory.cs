using System.ComponentModel.DataAnnotations;

namespace E_COMMERCE_MANAGEMENT.DTOs.Catigory
{
    public class CreateUpdateCatigory
    {
        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Name { get; set; }
        [MaxLength(200)]
        public string? Description { get; set; }
    }
}
