using System.Linq;
using System.Web.Mvc;
using BookStoreMVC.Models;

namespace BookStoreMVC.Controllers
{
    [Authorize(Roles = "Customer")]
    public class CustomerController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            return View();
        }

        // Search books
        public ActionResult SearchBooks(string searchTerm)
        {
            var books = db.Books.Where(b => b.Title.Contains(searchTerm) || b.Author.Contains(searchTerm)).ToList();
            return View(books);
        }

        // Add to cart
        public ActionResult AddToCart(int bookId)
        {
            // Implement add to cart logic
            return RedirectToAction("Index");
        }

        // Order books
        public ActionResult OrderBooks()
        {
            // Implement order books logic
            return RedirectToAction("Index");
        }
    }
}
