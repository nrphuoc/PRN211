using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopFlower.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopFlower.Controllers
{
    public class StaffController : Controller
    {
        private ShopFlowerContext context = new ShopFlowerContext();
        // GET: StaffController
        public ActionResult Index()
        {
            var list = context.Staffs.ToList();
            ViewBag.Staff = list;
            var listStore = context.Stores.ToList();
            ViewBag.Store = listStore;
            return View(list);
        }

        // GET: StaffController/Details/5
        public ActionResult Details(int id)
        {
            

            if (id == null)
            {
                return NotFound();
            }
            var staff = context.Staffs.Find(id);
            if (staff == null)
            {
                return NotFound();
            }
            var store = context.Stores.Find(staff.StoreId);
            if(store == null)
            {
                return View(staff);
            }
            else
            {
                ViewBag.Store = store.Storename;
            }
            
            return View(staff);
        }

        // GET: StaffController/Create
        public ActionResult Create()
        {
            var listStore = context.Stores.ToList();
            ViewBag.Store = listStore;

            var liststaff = context.Staffs.ToList();
            int size = 0;
            foreach(Staff s in liststaff)
            {
                if (s.StaffId > size)
                {
                    size = s.StaffId;
                }
            }
            ViewBag.ID = size + 1;
            return View();
        }

        // POST: StaffController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection value)
        {
            int id = Convert.ToInt32(value["StaffId"]);
            Staff staff = new Staff(id, value["Username"], value["Password"], value["Email"], value["Phone"], value["Address"], value["namestore"]);
            if (ModelState.IsValid)
            {
                context.Add(staff);
                context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(staff);
        }

        // GET: StaffController/Edit/5
        public ActionResult Edit(int id)
        {
            var listStore = context.Stores.ToList();
            ViewBag.Store = listStore;
           
            if (id == null)
            {
                return NotFound();
            }
            var staff = context.Staffs.Find(id);
            ViewBag.Staff = staff;
            if (staff == null)
            {
                return NotFound();
            }

            return View(staff);
        }

        // POST: StaffController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection value)
        {
            
            Staff staff = new Staff(id, value["Username"], value["Password"], value["Email"], value["Phone"], value["Address"], value["namestore"]);

            if (ModelState.IsValid)
            {
                context.Update(staff);
                context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(staff);
        }

        // GET: StaffController/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var staff = context.Staffs.Find(id);
            if (staff == null)
            {
                return NotFound();
            }
            var store = context.Stores.Find(staff.StoreId);
            if (store == null)
            {
                return View(staff);
            }
            else
            {
                ViewBag.Store = store.Storename;
            }

            return View(staff);
        }

        // POST: StaffController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            if (id == null)
            {
                return NotFound();
            }
            var staff = context.Staffs.Find(id);
            if (staff == null)
            {
                return NotFound();
            }
            string user = HttpContext.Session.GetString("UserName");
            if (ModelState.IsValid && staff.Username != user)
            {
                context.Staffs.Remove(staff);
                context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return RedirectToAction(nameof(Index));
            }
            
        }
    }
}
