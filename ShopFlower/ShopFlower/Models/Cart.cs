using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopFlower.Models
{
    public class CartItem
    {
        public Product product { get; set; }
        public int shoppingquantity { get; set; }
    }
    public class Cart
    {
        List<CartItem> items = new List<CartItem>();
        public IEnumerable<CartItem> Items
        {
            get { return items; }
        }
        public void Add(Product pro, int quantity = 1)
        {
            var item = items.FirstOrDefault(s => s.product.ProId == pro.ProId);
            if (item == null)
            {
                items.Add(new CartItem
                {
                    product = pro,
                    shoppingquantity = quantity
                });
                ;
            }
            else
            {
                item.shoppingquantity += quantity;
            }
        }
    }
}
