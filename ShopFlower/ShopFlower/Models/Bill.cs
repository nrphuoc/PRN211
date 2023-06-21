using System;
using System.Collections.Generic;

#nullable disable

namespace ShopFlower.Models
{
    public partial class Bill
    {
        public Bill()
        {
            BillItems = new HashSet<BillItem>();
        }

        public string OrderId { get; set; }
        public string Address { get; set; }
        public decimal? Total { get; set; }
        public int? Status { get; set; }
        public int CusId { get; set; }
        public int? StaffId { get; set; }
        public byte[] CreatedAt { get; set; }

        public virtual Customer Cus { get; set; }
        public virtual Staff Staff { get; set; }
        public virtual ICollection<BillItem> BillItems { get; set; }
    }
}
