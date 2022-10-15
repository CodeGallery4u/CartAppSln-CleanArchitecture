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
        DbSet<CartItemDbSet> Items { get; set; }
        DbSet<ItemDbSet> CartItems { get; set; }
    }
}
