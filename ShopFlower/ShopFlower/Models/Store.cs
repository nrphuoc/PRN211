using System;
using System.Collections.Generic;

#nullable disable

namespace ShopFlower.Models
{
    public partial class Store
    {
        public Store()
        {
            Stocks = new HashSet<Stock>();
            staff = new HashSet<Staff>();
        }

        public string StoreId { get; set; }
        public string Storename { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

        public virtual ICollection<Stock> Stocks { get; set; }
        public virtual ICollection<Staff> staff { get; set; }
    }
}
