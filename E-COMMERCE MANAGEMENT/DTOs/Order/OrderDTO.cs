using System.ComponentModel.DataAnnotations;

namespace E_COMMERCE_MANAGEMENT.DTOs.Order
{
    public class OrderDTO
    {
        public int Id { get; set; }
        [Required]
        public DateTime OrderDate { get; set; }
        [Required]
        public string Status { get; set; }
        [Required]

        public decimal TotaleAmount { get; set; }

        public int UserId { get; set; }
    }
}
