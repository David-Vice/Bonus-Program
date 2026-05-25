using System.Data.Entity;
using Bonus_Program.Models;

namespace Bonus_Program.Data
{
    public class BonusDbInitializer : CreateDatabaseIfNotExists<BonusDbContext>
    {
        protected override void Seed(BonusDbContext context)
        {
            context.Managers.Add(new Manager
            {
                Name = "Admin",
                Lastname = "User",
                Login = "admin",
                Password = "1234",
                Admin = true
            });

            context.Managers.Add(new Manager
            {
                Name = "Cashier",
                Lastname = "User",
                Login = "cashier",
                Password = "1234",
                Admin = false
            });

            context.Products.Add(new Product { Fullname = "AI-92", Price = 1.20m, BonusPercent = 2.0m });
            context.Products.Add(new Product { Fullname = "AI-95", Price = 1.40m, BonusPercent = 2.0m });
            context.Products.Add(new Product { Fullname = "Diesel", Price = 1.10m, BonusPercent = 2.0m });

            context.SaveChanges();

            base.Seed(context);
        }
    }
}
