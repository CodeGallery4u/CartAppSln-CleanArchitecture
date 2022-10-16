using System;
using System.Collections.Generic;

public static class TestUtility
{

    public CreateAdnSeedTestDatabase()
    {
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
        optionsBuilder.UseInMemoryDatabase(databaseName: "ShoppingCart.db");
        var context = new ApplicationDbContext(optionsBuilder.Options);
        context.Database.EnsureCreated();

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

    }
}
