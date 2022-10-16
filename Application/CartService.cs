using Application.Common.Interfaces;
using Application.Common.Model;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class CartService : ICartService
    {
        private readonly IApplicationDbContext _dbContext;

        public CartService(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IList<CartItem> AddItem(Guid cartId, int itemId)
        {
            //Find item is present in cart
            var cartItem = _dbContext.CartItems.FirstOrDefault(a => a.ItemId == itemId && a.CartId == cartId);
            if (cartItem == null)
            {
                var cartItemToBeAdded = new CartItemDbSet(cartId, itemId, 1);
                _dbContext.CartItems.Add(cartItemToBeAdded);
            }
            else
            {
                cartItem.Quantity += 1;
            }
            _dbContext.SaveDbChanges();

            return GetAllItems(cartId);
          
        }

        public IList<CartItem> GetAllItems(Guid cartId)
        {
            var items = _dbContext.Items.Select(a =>
            new Item() { 
                ItemId = a.ItemId,
                Name = a.Name,
                Price = a.Price,
                ImageUrl = a.ImageUrl
            });

            var cartItems = _dbContext.CartItems.Where(a => a.CartId == cartId).Select(a =>
            new CartItem{
                Item = items.Single(i=>i.ItemId == a.ItemId ),
                Quantity = a.Quantity
            }).ToList();

            return cartItems;
        }

        public IList<CartItem> RemoveItem(Guid cartId, int itemId)
        {
            var cartItem = _dbContext.CartItems.FirstOrDefault(a => a.ItemId == itemId && a.CartId == cartId);
            _dbContext.CartItems.Remove(cartItem);
            _dbContext.SaveDbChanges();
            return GetAllItems(cartId);
        }
    }
}
