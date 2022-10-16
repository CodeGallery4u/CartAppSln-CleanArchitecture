using Application.Common.Model;
using Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<CartItemDbSet> CartItems { get; set; }
        DbSet<ItemDbSet> Items { get; set; }
        bool SaveDbChanges();
    }
}
