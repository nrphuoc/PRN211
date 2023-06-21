using System;
using System.Collections.Generic;

#nullable disable

namespace ShopFlower.Models
{
    public partial class Product
    {
        public Product()
        {
            BillItems = new HashSet<BillItem>();
            Stocks = new HashSet<Stock>();
        }

        public Product(string proId, string proName, int? quantity, decimal? price, string image, string description)
        {
            ProId = proId;
            ProName = proName;
            Quantity = quantity;
            Price = price;
            Image = image;
            Description = description;
            
        }

        public string ProId { get; set; }
        public string ProName { get; set; }
        public int? Quantity { get; set; }
        public decimal? Price { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public bool? Status { get; set; }

        public virtual ICollection<BillItem> BillItems { get; set; }
        public virtual ICollection<Stock> Stocks { get; set; }
    }
}
