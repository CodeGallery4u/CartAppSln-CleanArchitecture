using Application.Common.Interfaces;
using Application.Common.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<CartItemDbSet> CartItems { get; set; }
        public DbSet<ItemDbSet> Items { get; set; }

        public bool SaveDbChanges()
        {
            this.SaveChanges();
            return true;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CartItemDbSet>().HasKey(sc => new { sc.CartId, sc.ItemId });
            modelBuilder.Entity<ItemDbSet>().HasData(
                    new ItemDbSet
                    {
                        ItemId = 1,
                        Name = "iPhone 12",
                        Price = 50000,
                        ImageUrl = "https://picsum.photos/200/300"
                    },
                    new ItemDbSet
                    {
                        ItemId = 2,
                        Name = "HP Laptop",
                        Price = 50000,
                        ImageUrl = "https://picsum.photos/200/300"
                    },
                    new ItemDbSet
                    {
                        ItemId = 3,
                        Name = "Samsung S22 Ultra",
                        Price = 84000,
                        ImageUrl = "https://picsum.photos/200/300"
                    }

            );
        }
    }
}
