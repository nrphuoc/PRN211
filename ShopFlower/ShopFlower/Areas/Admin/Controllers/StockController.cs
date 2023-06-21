using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopFlower.Models;

namespace ShopFlower.Controllers.admin { 

    [Area("admin")]
    [Route("admin/stock")]
    public class StockController : Controller
    {
        private readonly ShopFlowerContext context;

        public StockController(ShopFlowerContext context)
        {
            this.context = context;
        }

        [Route("")]
        [Route("index")]
        public IActionResult Index(string? page, string? mess)
        {
            if (page == null)
            {
                page = "1";
            }

            int size = context.Stocks.Count();
            int numberEachPage = 2;
            int numberPage = (size % numberEachPage == 0 ? (size / numberEachPage) : ((size / numberEachPage)) + 1);
            int numberOffset = numberEachPage * (Convert.ToInt32(page) - 1);

            List<Stock> list = context.Stocks.Skip(numberOffset)
                                             .Take(numberEachPage)
                                             .ToList();
            Dictionary<string, string> listProduct = context.Products.ToDictionary(b => b.ProId, b => b.ProName);
            Dictionary<string, string> listStore = context.Stores.ToDictionary(a => a.StoreId, a => a.Storename);
            
            ViewData["listProduct"] = listProduct;
            ViewData["listStore"] = listStore;

            ViewData["listStock"] = list;
            ViewData["page"] = Convert.ToInt32(page);
            ViewData["numberPage"] = numberPage;
            ViewData["mess"] = mess;



            return View();
        }


        [HttpGet]
        [Route("")]
        [Route("create")]
        public IActionResult Create()
        {
            ViewData["StoreId"] = context.Stores.ToDictionary(b => b.StoreId, b => b.Storename);
            ViewData["ProductId"] = context.Products.ToDictionary(b => b.ProId, b => b.ProName);
            return View();
        }

        [HttpPost]
        [Route("")]
        [Route("create")]
        public IActionResult Create(string storeId, string ProductId, string Quantity)
        {
            Stock stock = new Stock
            {
                StoreId = storeId,
                ProductId = ProductId,
                Quantity = Convert.ToInt32(Quantity)
            };
            context.Stocks.Add(stock);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [Route("")]
        [Route("edit")]
        public IActionResult Edit(string storeid, string productid)
        {
            Stock stock = context.Stocks.Where(s => s.StoreId == storeid && s.ProductId == productid).FirstOrDefault();
            ViewData["stock"] = stock;
            //ViewData["StoreId"] = context.Stores.ToDictionary(b => b.StoreId, b => b.Storename);
            //ViewData["ProductId"] = context.Products.ToDictionary(b => b.ProId, b => b.ProName);
            return View();
        }

        [HttpPost]
        [Route("")]
        [Route("edit")]
        public IActionResult Edit()
        {
            String storeId = Request.Form["StoreId"];
            String productId = Request.Form["ProductId"];
            String quantity = Request.Form["Quantity"];
            
            Stock stock = context.Stocks.Where(s => s.StoreId == storeId && s.ProductId == productId).FirstOrDefault();

            stock.Quantity = Convert.ToInt32(quantity);
            context.Stocks.Update(stock);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [Route("")]
        [Route("delete")]
        public IActionResult Delete(string storeid, string productid)
        {
            Stock stock = context.Stocks.Where(s => s.StoreId == storeid && s.ProductId == productid).FirstOrDefault();
            context.Stocks.Remove(stock);
            context.SaveChanges();
            return RedirectToAction(nameof(Index), new { mess = "Delete success" });
        }
    }

    


}
