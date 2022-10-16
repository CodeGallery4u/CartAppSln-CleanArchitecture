using Application.Common.Model;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestUtility
{
    public static class Utility
    {
        public static ApplicationDbContext CreateAdnSeedTestDatabase()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseInMemoryDatabase(databaseName: "ShoppingCart.db");
            var context = new ApplicationDbContext(optionsBuilder.Options);
            context.Database.EnsureDeleted();

            List<ItemDbSet> items = new()
            {
                new ItemDbSet()
                {
                    ItemId = 1,
                    Name = "iPhone 12",
                    Price = 50000,
                    ImageUrl = "https://picsum.photos/200/300"
                },
                new ItemDbSet()
                {
                    ItemId = 2,
                    Name = "HP Laptop",
                    Price = 50000,
                    ImageUrl = "https://picsum.photos/200/300"
                },
                new ItemDbSet()
                {
                    ItemId = 3,
                    Name = "Samsung S22 Ultra",
                    Price = 84000,
                    ImageUrl = "https://picsum.photos/200/300"
                }
            };

            context.Items.AddRange(items);
            context.SaveChanges();

            return context;

        }

    }
}
