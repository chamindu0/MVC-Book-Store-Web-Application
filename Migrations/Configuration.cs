namespace BookStoreMVC.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using BookStoreMVC.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<BookStoreMVC.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BookStoreMVC.Models.ApplicationDbContext context)
        {
            // Add sample data to the Books table
            context.Books.AddOrUpdate(
                b => b.ISBN,
                new Book
                {
                    BookID = 01,
                    Title = "Java",
                    Author = "Author 1",
                    ISBN = "1234567890",
                    Price = 19.99m,
                    AvailableStock = 10,
                    CoverImageUrl = "/Content/Images/sample1.jpg"
                },
                new Book
                {
                    BookID = 02,
                    Title = "C++",
                    Author = "Author 2",
                    ISBN = "0987654321",
                    Price = 29.99m,
                    AvailableStock = 5,
                    CoverImageUrl = "/Content/Images/sample2.jpg"
                },
                new Book
                {
                    BookID = 03,
                    Title = "Ruby",
                    Author = "Author 3",
                    ISBN = "1122334455",
                    Price = 15.99m,
                    AvailableStock = 20,
                    CoverImageUrl = "/Content/Images/sample3.jpg"
                },
                new Book
                {
                    BookID = 04,
                    Title = "JavaScript",
                    Author = "Author 4",
                    ISBN = "2233445566",
                    Price = 25.99m,
                    AvailableStock = 8,
                    CoverImageUrl = "/Content/Images/sample4.jpg"
                },
                new Book
                {
                    BookID = 05,
                    Title = "C#",
                    Author = "Author 5",
                    ISBN = "3344556677",
                    Price = 12.99m,
                    AvailableStock = 15,
                    CoverImageUrl = "/Content/Images/sample5.jpg"
                }
            );

            // Add user data directly to the Users table
            context.Users.AddOrUpdate(
                u => u.Email,
                new User
                {
                    UserID = 01,
                    Name = "Admin",
                    Email = "admin@bookstore.com",
                    Password = "Admin@123", 
                    Role = "Admin"
                },
                new User
                {
                    UserID = 02,
                    Name = "Customer",
                    Email = "customer@bookstore.com",
                    Password = "Customer@123", 
                    Role = "Customer"
                }
            );
        }
    }
}
