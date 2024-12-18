using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStoreMVC.Models
{
    public class CartItem
    {
        [Key]
        public int CartItemID { get; set; }
        public int CartID { get; set; }
        public int BookID { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        [ForeignKey("CartID")]
        public virtual Cart Cart { get; set; }
        [ForeignKey("BookID")]
        public virtual Book Book { get; set; }
    }
}
