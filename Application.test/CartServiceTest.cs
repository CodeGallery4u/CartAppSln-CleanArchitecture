using Application.Common.Interfaces;
using Core.Models;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestUtility;

namespace Application.test
{
    public class CartServiceTest
    {
        ApplicationDbContext _context;
        IItemService itemService;
        ICartService cartService;
        public CartServiceTest()
        {
            ApplicationDbContext _context = Utility.CreateAdnSeedTestDatabase();
            itemService = new ItemService(_context);
            cartService = new CartService(_context);
        }
        [Fact]
        public void CartService_AddItem()
        {
            //Arrange
       
            Guid cartId = Guid.NewGuid();
            List<Item> items = itemService.GetAllItems();
            //Act
            cartService.AddItem(cartId, items[0].ItemId);
            var cartItem = cartService.GetAllItems(cartId);
            //Assert
            Assert.True(cartItem != null);
            Assert.True(cartItem.First().Item.ItemId == items[0].ItemId);

        }

        [Fact]
        public void CartService_RemoveItem()
        {
            //Arrange
            Guid cartId = Guid.NewGuid();
            List<Item> items = itemService.GetAllItems();
            //Act
            cartService.AddItem(cartId, items[0].ItemId);
            cartService.AddItem(cartId, items[1].ItemId);
            cartService.RemoveItem(cartId, items[1].ItemId);
            var cartItem = cartService.GetAllItems(cartId);
            //Assert
            Assert.True(cartItem.Count == 1);
            Assert.True(cartItem != null);
            Assert.True(cartItem.First().Item.ItemId == items[0].ItemId);
        }
    }
}
