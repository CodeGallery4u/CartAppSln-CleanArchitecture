using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface ICartService
    {
        IList<CartItem> GetAllItems(Guid cartId);
        IList<CartItem> AddItem(Guid cartId, int itemId);
        IList<CartItem> RemoveItem(Guid cartId, int itemId);
    }
}
