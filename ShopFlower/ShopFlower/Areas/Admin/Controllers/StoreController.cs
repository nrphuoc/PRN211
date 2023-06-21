using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShopFlower.Models;

namespace ShopFlower.Controllers.admin
{
    [Area("Admin")]
    [Route("admin/store")]
    public class StoreController : Controller
    {
        private readonly ShopFlowerContext context;

        public StoreController(ShopFlowerContext context)
        {
            this.context = context;
        }

        [Route("")]
        [Route("index")]
        public IActionResult Index(string? page)
        {
            if (page == null)
            {
                page = "1";
            }

            int size = context.Stores.Count();
            int numberEachPage = 2;
            int numberPage = (size % numberEachPage == 0 ? (size / numberEachPage) : ((size / numberEachPage)) + 1);
            int numberOffset = numberEachPage * (Convert.ToInt32(page) - 1);

            List<Store> list = context.Stores.Skip(numberOffset)
                                             .Take(numberEachPage)
                                             .ToList();
            ViewData["listStore"] = list;
            ViewData["page"] = Convert.ToInt32(page);
            ViewData["numberPage"] = numberPage;
            
            return View();
        }

        [HttpGet]
        [Route("")]
        [Route("create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("")]
        [Route("create")]
        public IActionResult Create(string storeName, string email, string address, string phone)
        {
            string id = storeName.Substring(0, 2).ToUpper();
            int count = context.Stores.Where(o=>o.StoreId.Contains(id)).Count();
            if (count > 0)
            {
                id += (count + 1).ToString();
            }

            Store store = new Store
            {
                StoreId = id,
                Storename = storeName,
                Email = email,
                Address = address,
                Phone = phone
            };

            context.Stores.Add(store);
            context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [Route("")]
        [Route("edit")]
        public IActionResult Edit(string id)
        {
            Store store = context.Stores.Where(o => o.StoreId == id).FirstOrDefault();
            ViewData["store"] = store;
            return View();
        }

        [HttpPost]
        [Route("")]
        [Route("edit")]
        public IActionResult Edit(string id,string name, string email, string address, string phone)
        {
            Store store = context.Stores.Where(o => o.StoreId == id).FirstOrDefault();
            store.Storename = name;
            store.Email = email;
            store.Address = address;
            store.Phone = phone;

            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [Route("")]
        [Route("delete")]
        public IActionResult Delete(string id)
        {
            Store s = context.Stores.Find(id);
            context.Remove(s);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

    }
}
