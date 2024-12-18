using System.Linq;
using System.Web.Mvc;
using BookStoreMVC.Models;

namespace BookStoreMVC.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            var books = db.Books.Select(b => new BookViewModel
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

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
