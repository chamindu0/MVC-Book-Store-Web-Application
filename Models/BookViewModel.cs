using System.ComponentModel.DataAnnotations;

namespace BookStoreMVC.Models
{
    public class BookViewModel
    {
        public int BookID { get; set; }

        [Required]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Author")]
        public string Author { get; set; }

        [Required]
        [Display(Name = "ISBN")]
        public string ISBN { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Display(Name = "Price")]
        public decimal Price { get; set; }

        [Required]
        [Display(Name = "Available Stock")]
        public int AvailableStock { get; set; }

        [Display(Name = "Cover Image URL")]
        public string CoverImageUrl { get; set; }
    }
}
