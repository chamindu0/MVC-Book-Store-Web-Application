using System;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using BookStoreMVC.Models;

namespace BookStoreMVC.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            return View();
        }

        // CRUD operations for books
        public ActionResult ListBooks()
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

        public ActionResult CreateBook()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateBook(BookViewModel bookViewModel)
        {
            if (ModelState.IsValid)
            {
                var book = new Book
                {
                    Title = bookViewModel.Title,
                    Author = bookViewModel.Author,
                    ISBN = bookViewModel.ISBN,
                    Price = bookViewModel.Price,
                    AvailableStock = bookViewModel.AvailableStock,
                    CoverImageUrl = bookViewModel.CoverImageUrl
                };
                db.Books.Add(book);
                db.SaveChanges();
                return RedirectToAction("ListBooks");
            }
            return View(bookViewModel);
        }

        public ActionResult EditBook(int id)
        {
            var book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            var bookViewModel = new BookViewModel
            {
                BookID = book.BookID,
                Title = book.Title,
                Author = book.Author,
                ISBN = book.ISBN,
                Price = book.Price,
                AvailableStock = book.AvailableStock,
                CoverImageUrl = book.CoverImageUrl
            };
            return View(bookViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditBook(BookViewModel bookViewModel)
        {
            if (ModelState.IsValid)
            {
                var book = db.Books.Find(bookViewModel.BookID);
                if (book == null)
                {
                    return HttpNotFound();
                }
                book.Title = bookViewModel.Title;
                book.Author = bookViewModel.Author;
                book.ISBN = bookViewModel.ISBN;
                book.Price = bookViewModel.Price;
                book.AvailableStock = bookViewModel.AvailableStock;
                book.CoverImageUrl = bookViewModel.CoverImageUrl;
                db.Entry(book).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ListBooks");
            }
            return View(bookViewModel);
        }

        public ActionResult DeleteBook(int id)
        {
            var book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            var bookViewModel = new BookViewModel
            {
                BookID = book.BookID,
                Title = book.Title,
                Author = book.Author,
                ISBN = book.ISBN,
                Price = book.Price,
                AvailableStock = book.AvailableStock,
                CoverImageUrl = book.CoverImageUrl
            };
            return View(bookViewModel);
        }

        [HttpPost, ActionName("DeleteBook")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteBookConfirmed(int id)
        {
            var book = db.Books.Find(id);
            db.Books.Remove(book);
            db.SaveChanges();
            return RedirectToAction("ListBooks");
        }

        // CRUD operations for users
        public ActionResult ListUsers()
        {
            var users = db.Users.Select(u => new UserViewModel
            {
                UserID = u.UserID,
                Name = u.Name,
                Email = u.Email,
                Role = u.Role
            }).ToList();
            return View(users);
        }

        public ActionResult CreateUser()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateUser(UserViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = new User
                {
                    Name = userViewModel.Name,
                    Email = userViewModel.Email,
                    Password = userViewModel.Password, // Note: In a real application, passwords should be hashed
                    Role = userViewModel.Role
                };
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("ListUsers");
            }
            return View(userViewModel);
        }

        public ActionResult EditUser(int id)
        {
            var user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            var userViewModel = new UserViewModel
            {
                UserID = user.UserID,
                Name = user.Name,
                Email = user.Email,
                Password = user.Password,
                Role = user.Role
            };
            return View(userViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditUser(UserViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = db.Users.Find(userViewModel.UserID);
                if (user == null)
                {
                    return HttpNotFound();
                }
                user.Name = userViewModel.Name;
                user.Email = userViewModel.Email;
                user.Password = userViewModel.Password; // Note: In a real application, passwords should be hashed
                user.Role = userViewModel.Role;
                db.Entry(user).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ListUsers");
            }
            return View(userViewModel);
        }

        public ActionResult DeleteUser(int id)
        {
            var user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            var userViewModel = new UserViewModel
            {
                UserID = user.UserID,
                Name = user.Name,
                Email = user.Email,
                Role = user.Role
            };
            return View(userViewModel);
        }

        [HttpPost, ActionName("DeleteUser")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteUserConfirmed(int id)
        {
            var user = db.Users.Find(id);
            db.Users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("ListUsers");
        }

        // CRUD operations for orders
        public ActionResult ListOrders()
        {
            var orders = db.Orders.ToList();
            return View(orders);
        }

        public ActionResult EditOrder(int id)
        {
            var order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditOrder(Order order)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ListOrders");
            }
            return View(order);
        }

        public ActionResult DeleteOrder(int id)
        {
            var order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        [HttpPost, ActionName("DeleteOrder")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteOrderConfirmed(int id)
        {
            var order = db.Orders.Find(id);
            db.Orders.Remove(order);
            db.SaveChanges();
            return RedirectToAction("ListOrders");
        }

        // Report generation actions
        public ActionResult GenerateDailySalesReport()
        {
            var startDate = DateTime.Now.Date;
            var endDate = startDate.AddDays(1);
            var report = GenerateSalesReport(startDate, endDate);
            ViewBag.StartDate = startDate;
            ViewBag.EndDate = endDate;
            ViewBag.ReportType = "Daily";
            return View("SalesReport", report);
        }

        public ActionResult GenerateWeeklySalesReport()
        {
            var startDate = DateTime.Now.Date.AddDays(-(int)DateTime.Now.DayOfWeek);
            var endDate = startDate.AddDays(7);
            var report = GenerateSalesReport(startDate, endDate);
            ViewBag.StartDate = startDate;
            ViewBag.EndDate = endDate;
            ViewBag.ReportType = "Weekly";
            return View("SalesReport", report);
        }

        public ActionResult GenerateMonthlySalesReport()
        {
            var startDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            var endDate = startDate.AddMonths(1);
            var report = GenerateSalesReport(startDate, endDate);
            ViewBag.StartDate = startDate;
            ViewBag.EndDate = endDate;
            ViewBag.ReportType = "Monthly";
            return View("SalesReport", report);
        }

        public ActionResult GenerateUserReport()
        {
            var users = db.Users.Select(u => new UserDetailViewModel
            {
                UserID = u.UserID,
                Name = u.Name,
                Email = u.Email,
                Role = u.Role,
                OrderCount = u.Orders.Count,
                TotalSpent = u.Orders.Sum(o => (decimal?)o.TotalAmount) ?? 0 // Handle null values
            }).ToList();

            var report = new UserReportViewModel
            {
                ReportDate = DateTime.Now,
                Users = users
            };

            return View("UserReport", report);
        }

        public ActionResult ExportSalesReportToCSV(DateTime startDate, DateTime endDate)
        {
            var report = GenerateSalesReport(startDate, endDate);
            var csv = GenerateSalesReportCSV(report);
            return File(new UTF8Encoding().GetBytes(csv), "text/csv", "SalesReport.csv");
        }

        public ActionResult ExportUserReportToCSV()
        {
            var users = db.Users.Select(u => new UserDetailViewModel
            {
                UserID = u.UserID,
                Name = u.Name,
                Email = u.Email,
                Role = u.Role,
                OrderCount = u.Orders.Count,
                TotalSpent = u.Orders.Sum(o => (decimal?)o.TotalAmount) ?? 0 // Handle null values
            }).ToList();

            var report = new UserReportViewModel
            {
                ReportDate = DateTime.Now,
                Users = users
            };

            var csv = GenerateUserReportCSV(report);
            return File(new UTF8Encoding().GetBytes(csv), "text/csv", "UserReport.csv");
        }

        private SalesReportViewModel GenerateSalesReport(DateTime startDate, DateTime endDate)
        {
            var orders = db.Orders.Where(o => o.OrderDate >= startDate && o.OrderDate < endDate).ToList();
            var report = new SalesReportViewModel
            {
                ReportDate = DateTime.Now,
                TotalSales = orders.Sum(o => (decimal?)o.TotalAmount) ?? 0, // Handle null values
                TotalOrders = orders.Count,
                OrderDetails = orders.Select(o => new OrderDetailViewModel
                {
                    OrderID = o.OrderID,
                    OrderDate = o.OrderDate,
                    TotalAmount = o.TotalAmount,
                    PaymentStatus = o.PaymentStatus
                }).ToList()
            };

            return report;
        }

        private string GenerateSalesReportCSV(SalesReportViewModel report)
        {
            var csv = new StringBuilder();
            csv.AppendLine("Order ID,Order Date,Total Amount,Payment Status");
            foreach (var order in report.OrderDetails)
            {
                csv.AppendLine($"{order.OrderID},{order.OrderDate:MM/dd/yyyy},{order.TotalAmount},{order.PaymentStatus}");
            }
            return csv.ToString();
        }

        private string GenerateUserReportCSV(UserReportViewModel report)
        {
            var csv = new StringBuilder();
            csv.AppendLine("User ID,Name,Email,Role,Order Count,Total Spent");
            foreach (var user in report.Users)
            {
                csv.AppendLine($"{user.UserID},{user.Name},{user.Email},{user.Role},{user.OrderCount},{user.TotalSpent}");
            }
            return csv.ToString();
        }
    }
}
