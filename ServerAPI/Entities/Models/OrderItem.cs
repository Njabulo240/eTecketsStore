using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServerAPI.Entities.Models
{
    public class OrderItem
    {
         [Key]
         [Column("OrderItemId")]
        public Guid Id { get; set; }

        public int Amount { get; set; }
        public double Price { get; set; }

        public Guid MovieId { get; set; }
        [ForeignKey("MovieId")]
        public Movie Movie { get; set; }

        public Guid OrderId { get; set; }
        [ForeignKey("OrderId")]
        public Order Order { get; set; }
    }
}