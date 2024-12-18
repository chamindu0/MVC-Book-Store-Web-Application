using BookStoreMVC;
using System.Collections.Generic;

public partial class Book
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public Book()
    {
        this.Feedbacks = new HashSet<Feedback>();
        this.OrderItems = new HashSet<OrderItem>();
    }

    public int BookID { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public string ISBN { get; set; }
    public decimal Price { get; set; }
    public int AvailableStock { get; set; }
    public string CoverImageUrl { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    public virtual ICollection<Feedback> Feedbacks { get; set; }
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    public virtual ICollection<OrderItem> OrderItems { get; set; }
}
