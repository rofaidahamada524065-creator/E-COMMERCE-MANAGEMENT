using System.ComponentModel.DataAnnotations;

namespace E_COMMERCE_MANAGEMENT.DTOs.Order
{
    public class CreateOrderDTO
    {
        [Required]
        public DateTime OrderDate { get; set; }
        [Required]
        public string Status { get; set; }
        [Required]

        public decimal TotaleAmount { get; set; }

        public int UserId { get; set; }
        public string ProductNaeme { get; set; }    
        public int quantities {  get; set; }
    }
}
