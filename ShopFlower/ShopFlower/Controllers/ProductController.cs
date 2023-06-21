using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopFlower.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopFlower.Controllers
{
    public class ProductController : Controller
    {
        private ShopFlowerContext context = new ShopFlowerContext();
        // GET: ProductController
        public ActionResult Index()
        {
            var list = context.Products.ToList();
            ViewBag.Product = list;
            return View(list);
        }

        // GET: ProductController/Details/5
        public ActionResult Details(string id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var pro = context.Products.Find(id);
            if(pro == null)
            {
                return NotFound();
            }

            return View(pro);
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("ProId,ProName,Quantity,Price,Image,Description")] Product pro)
        {
            if (ModelState.IsValid)
            {
                context.Add(pro);
                context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(pro);
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(string id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var pro = context.Products.Find(id);
            if(pro == null)
            {
                return NotFound();
            }
            return View(pro);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, [Bind("ProId,ProName,Quantity,Price,Image,Description")] Product pro)
        {
            if (ModelState.IsValid)
            {
                context.Update(pro);
                context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(pro);
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(string id)
        {
            var pro = context.Products.Find(id);
            if(pro == null || id == null)
            {
                return NotFound();
            }
            return View(pro);
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string id, IFormCollection collection)
        {
            var pro = context.Products.Find(id);
            if(pro == null || id == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                context.Remove(pro);
                context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(pro);
        }
    }
}
