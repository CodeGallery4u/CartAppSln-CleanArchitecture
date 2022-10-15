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
        public DbSet<CartItemDbSet> Items { get; set; }
        public DbSet<ItemDbSet> CartItems { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {

        }
    }
}
