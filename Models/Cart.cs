using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookStoreMVC.Models
{
    public class Cart
    {
        [Key]
        public int CartID { get; set; }
        public string UserID { get; set; }
        public virtual ICollection<CartItem> CartItems { get; set; }

        public Cart()
        {
            CartItems = new HashSet<CartItem>();
        }
    }
}