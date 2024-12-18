using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using BookStoreMVC.Models;
using Microsoft.AspNet.Identity;

namespace BookStoreMVC.Controllers
{
    public class CartController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private static List<CartItem> cart = new List<CartItem>();

        public ActionResult Index()
        {
            if (TempData["ErrorMessage"] != null)
            {
                ViewBag.ErrorMessage = TempData["ErrorMessage"].ToString();
            }
            return View(cart);
        }

        [HttpPost]
        public ActionResult AddToCart(int id)
        {
            var book = db.Books.Find(id);
            if (book != null && book.AvailableStock > 0)
            {
                var cartItem = cart.FirstOrDefault(c => c.BookID == id);
                if (cartItem == null)
                {
                    cartItem = new CartItem
                    {
                        BookID = book.BookID,
                        Quantity = 1,
                        Price = book.Price,
                        Book = book
                    };
                    cart.Add(cartItem);
                }
                else
                {
                    cartItem.Quantity++;
                }
                book.AvailableStock--;
                db.SaveChanges();
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult ReduceFromCart(int id)
        {
            var cartItem = cart.FirstOrDefault(c => c.BookID == id);
            if (cartItem != null)
            {
                var book = db.Books.Find(id);
                if (book != null)
                {
                    cartItem.Quantity--;
                    book.AvailableStock++;
                    if (cartItem.Quantity <= 0)
                    {
                        cart.Remove(cartItem);
                    }
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult RemoveFromCart(int id)
        {
            var cartItem = cart.FirstOrDefault(c => c.BookID == id);
            if (cartItem != null)
            {
                var book = db.Books.Find(id);
                if (book != null)
                {
                    book.AvailableStock += cartItem.Quantity;
                    cart.Remove(cartItem);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }

        [Authorize]
        [HttpGet]
        public ActionResult PlaceOrder()
        {
            if (!User.Identity.IsAuthenticated)
            {
                TempData["ErrorMessage"] = "You must log in to place an order.";
                return RedirectToAction("Index");
            }

            var userId = User.Identity.GetUserId();
            var order = new Order
            {
                UserID = userId,
                OrderDate = DateTime.Now,
                TotalAmount = cart.Sum(item => item.Price * item.Quantity),
                PaymentStatus = "Pending"
            };

            return View(order);
        }

        [Authorize]
        [HttpPost]
        public ActionResult PlaceOrder(Order order)
        {
            if (!User.Identity.IsAuthenticated)
            {
                TempData["ErrorMessage"] = "You must log in to place an order.";
                return RedirectToAction("Index");
            }

            var userId = User.Identity.GetUserId();
            order.UserID = userId;
            order.OrderDate = DateTime.Now;
            order.TotalAmount = cart.Sum(item => item.Price * item.Quantity);
            order.PaymentStatus = "Pending";

            foreach (var cartItem in cart)
            {
                var orderItem = new OrderItem
                {
                    BookID = cartItem.BookID,
                    Quantity = cartItem.Quantity,
                    Price = cartItem.Price
                };
                order.OrderItems.Add(orderItem);
            }

            db.Orders.Add(order);
            db.SaveChanges();

            // Clear the cart
            cart.Clear();

            // Simulate payment processing
            order.PaymentStatus = "Paid";
            db.SaveChanges();

            TempData["SuccessMessage"] = "Payment successful! Your order has been placed.";

            return RedirectToAction("OrderConfirmation", new { orderId = order.OrderID });
        }

        public ActionResult OrderConfirmation(int orderId)
        {
            var order = db.Orders.Find(orderId);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }
    }
}

