using System;
using System.Collections.Generic;

#nullable disable

namespace ShopFlower.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Bills = new HashSet<Bill>();
        }

        public Customer(string cusName, string email, string cusPhone, string cusAddress, string username, string password)
        {
            CusName = cusName;
            Email = email;
            CusPhone = cusPhone;
            CusAddress = cusAddress;
            Username = username;
            Password = password;
        }

        public Customer(int cusId, string cusName, string email, string cusPhone, string cusAddress, string username, string password)
        {
            CusId = cusId;
            CusName = cusName;
            Email = email;
            CusPhone = cusPhone;
            CusAddress = cusAddress;
            Username = username;
            Password = password;
        }

        public int CusId { get; set; }
        public string CusName { get; set; }
        public string Email { get; set; }
        public string CusPhone { get; set; }
        public string CusAddress { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Bill> Bills { get; set; }
    }
}
