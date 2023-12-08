using System.ComponentModel.DataAnnotations;

namespace E_Tickets.Models
{
    public class ShoppingCartItem
    {
        [Key]
        public int id { get; set; }
        public Movie Movie { get; set; }
        public int Amount { get; set; }
        public String ShoppingCartId { get; set; }
    }
}
