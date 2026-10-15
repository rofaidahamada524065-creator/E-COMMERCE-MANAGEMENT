using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_COMMERCE_MANAGEMENT.Model
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime OrderDate { get; set; } 
        [Required]
        public string Status {  get; set; }
        [Required]

        public decimal TotaleAmount { get; set; }   

        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User? User { get; set; }

        public ICollection<OrderItem> orderItems { get; set; }=new List<OrderItem>();

    }
}
