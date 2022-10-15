using Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Cart<T> : BaseEntity<T>
    {
        public IList<CartItem> Items { get; set; }
    }
}
