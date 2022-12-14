using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServerAPI.Entities.Models
{
    public class Order
    {
        [Key]
        [Column("MovieId")]
        public Guid Id { get; set; }

        public string Email { get; set; }
        public string UserId { get; set; }
        [ForeignKey(nameof(UserId))]
         public ApplicationUser User { get; set; }

        public List<OrderItem> OrderItems { get; set; }
    }
}