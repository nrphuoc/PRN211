using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopFlower.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopFlower.Controllers
{
    public class BillController : Controller
    {
        private ShopFlowerContext context = new ShopFlowerContext();
        // GET: BillController
        public ActionResult Index()
        {
            var listBill = context.Bills.ToList();
            var listCus = context.Customers.ToList();
            var listStaff = context.Staffs.ToList();
            
            ViewBag.Bill = listBill;
            ViewBag.Cus = listCus;
            ViewBag.Staff = listStaff;

            return View(listBill);
        }

        
    }
}
