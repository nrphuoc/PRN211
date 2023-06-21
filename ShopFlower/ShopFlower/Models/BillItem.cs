using System;
using System.Collections.Generic;

#nullable disable

namespace ShopFlower.Models
{
    public partial class BillItem
    {
        public string ProId { get; set; }
        public string OrderId { get; set; }
        public int? Quantity { get; set; }
        public decimal? Price { get; set; }

        public virtual Bill Order { get; set; }
        public virtual Product Pro { get; set; }
    }
}
