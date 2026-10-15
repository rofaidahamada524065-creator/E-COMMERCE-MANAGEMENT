using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_COMMERCE_MANAGEMENT.Model
{
    public class OrderItem
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Range(1,100)]
        public int Quantity { get; set; }
        [Required,Range(0.01,1000000)]
        public decimal UnitPrice { get; set; }

        public int OrderId { get; set; }
        [ForeignKey("OrderId")]
        public Order? Order { get; set; }    

        public int ProdactId { get; set; }
        [ForeignKey("ProdactId")]
        public Product? Product { get; set; }


    }

}
