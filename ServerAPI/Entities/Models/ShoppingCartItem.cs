using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServerAPI.Entities.Models
{
    public class ShoppingCartItem
    {
        [Key]
        [Column("ShoppingCartItemId")]
        public Guid Id { get; set; }

        public Movie Movie { get; set; }
        public int Amount { get; set; }


        public string ShoppingCartId { get; set; }
    }
}