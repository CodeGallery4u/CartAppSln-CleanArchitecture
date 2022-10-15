using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Model
{
    public class CartItemDbSet
    {
        [Key]
        public Guid CartId { get; private set; }
        public int Quantity { get; set; }
        public int ItemId { get; set; }

        public CartItemDbSet(Guid cartId, int itemId, int quantity)
        {
            CartId = cartId;
            Quantity = quantity;
            ItemId = itemId;
        }

        public IList<ItemDbSet> Item { get; set; }
    }
}
