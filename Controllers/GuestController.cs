using System.Linq;
using System.Web.Mvc;
using BookStoreMVC.Models;

namespace BookStoreMVC.Controllers
{
    public class GuestController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult SearchBooks(string query)
        {
            var books = db.Books
                .Where(b => b.Title.Contains(query) || b.Author.Contains(query) || b.ISBN.Contains(query))
                .Select(b => new BookViewModel
                {
                    BookID = b.BookID,
                    Title = b.Title,
                    Author = b.Author,
                    ISBN = b.ISBN,
                    Price = b.Price,
                    AvailableStock = b.AvailableStock,
                    CoverImageUrl = b.CoverImageUrl
                }).ToList();

            return View(books);
        }
    }
}
