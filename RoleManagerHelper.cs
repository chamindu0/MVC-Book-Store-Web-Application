using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using BookStoreMVC.Models;

namespace BookStoreMVC.Helpers
{
    public static class RoleManagerHelper
    {
        public static void EnsureRolesExist()
        {
            var context = new ApplicationDbContext();
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            if (!roleManager.RoleExists("Admin"))
            {
                var role = new IdentityRole { Name = "Admin" };
                roleManager.Create(role);
            }

            if (!roleManager.RoleExists("Customer"))
            {
                var role = new IdentityRole { Name = "Customer" };
                roleManager.Create(role);
            }

            if (!roleManager.RoleExists("Guest"))
            {
                var role = new IdentityRole { Name = "Guest" };
                roleManager.Create(role);
            }
        }
    }
}
