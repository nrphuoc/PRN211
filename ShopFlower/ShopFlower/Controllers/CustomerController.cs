using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopFlower.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopFlower.Controllers
{
    public class CustomerController : Controller
    {
        private ShopFlowerContext context = new ShopFlowerContext();
        // GET: CustomerController
        public ActionResult Index()
        {
            var list = context.Customers.ToList();
            ViewBag.Customer = list;
            return View(list);
        }

        // GET: CustomerController/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var cus = context.Customers.Find(id);
            if (cus == null)
            {
                return NotFound();
            }

            return View(cus);
        }

        // GET: CustomerController/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: CustomerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("CusName,Email,CusPhone,CusAddress,Username,Password")] Customer cus)
        {

            if(ModelState.IsValid)
            {
                context.Add(cus);
                context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(cus);

        }

        // GET: CustomerController/Edit/5
        public ActionResult Edit(int id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var cus = context.Customers.Find(id);
            if(cus == null)
            {
                return NotFound();
            }

            return View(cus);
        }

        // POST: CustomerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind("CusId,CusName,Email,CusPhone,CusAddress,Username,Password")] Customer cus)
        {

            if (ModelState.IsValid)
            {
                context.Update(cus);
                context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(cus);
        }

        // GET: CustomerController/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var cus = context.Customers.Find(id);
            if (cus == null)
            {
                return NotFound();
            }

            return View(cus);
        }

        // POST: CustomerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            if (id == null)
            {
                return NotFound();
            }
            var cus = context.Customers.Find(id);
            if (cus == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                context.Customers.Remove(cus);
                context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(cus);
        }
    }
}
