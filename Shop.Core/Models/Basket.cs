using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Core.Models
{
    // BaseEntity have the Id
    public class Basket : BaseEntity
    {
        // The virtual is very important. When we read the basket, the Entity framework
        // knows that it must read the basket and all the items in the basket. Lazy Loading.
        public virtual ICollection<BasketItem> BasketItems { get; set; }

        public Basket()
        {
            this.BasketItems = new List<BasketItem>();
        }
    }
}
