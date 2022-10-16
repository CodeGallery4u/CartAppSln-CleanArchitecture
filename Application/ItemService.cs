using Application.Common.Interfaces;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class ItemService : IItemService
    {
        private readonly IApplicationDbContext _dbContext;

        public ItemService(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Item> GetAllItems()
        {
            List<Item> result = new();
            
            var items = _dbContext.Items.ToList();

            result =  _dbContext.Items
                .Select(a=> 
                new Item() { 
                    Name = a.Name,
                    Price = a.Price,
                    ImageUrl = a.ImageUrl,
                    ItemId = a.ItemId,
                }).ToList();

            return result;
        }
    }
}
