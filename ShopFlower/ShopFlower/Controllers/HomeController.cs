using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShopFlower.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ShopFlower.Controllers
{
    public class HomeController : Controller

    {
        private ShopFlowerContext context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, ShopFlowerContext context)
        {
            this.context = context;
            _logger = logger;
        }

        public IActionResult Index(string? page)
        {
            if (page == null)
            {
                page = "1";
            }

            int size = context.Products.Count();
            int numberEachPage = 8;
            int numberPage = (size % numberEachPage == 0 ? (size / numberEachPage) : ((size / numberEachPage)) + 1);
            int numberOffset = numberEachPage * (Convert.ToInt32(page) - 1);

            List<Product> list = context.Products.Skip(numberOffset).Take(numberEachPage).ToList();


            ViewData["page"] = Convert.ToInt32(page);
            ViewData["numberPage"] = numberPage;
            ViewData["Product"] = list;
            return View();
        }

        public IActionResult LoginAdmin()
        {
            return View();
        }

        [HttpPost]
        //Login
        public IActionResult LoginAdmin(IFormCollection value)
        {
            string fpass, fuser;
            bool check = false;
            fuser = value["UserName"];
            fpass = value["Password"];

            var list = context.Staffs.ToList();
            foreach(Staff s in list)
            {
                if(fpass == s.Password && fuser == s.Username)
                {
                    check = true;
                    break;
                }
            }

            if(check == true)
            {
                HttpContext.Session.SetString("UserNamead", fuser);
                HttpContext.Session.SetString("UserName", "");
                HttpContext.Session.SetString("messad", "");
                return RedirectToAction(nameof(Index));
            }
            else
            {
                string mess = "Username or password incorrect";
                HttpContext.Session.SetString("messad", mess);
                return View();
            }

        }
        //logout
        public IActionResult Logout()
        {
            //set session
            HttpContext.Session.SetString("UserNamead", "");
            HttpContext.Session.SetString("UserName", "");
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        //Login
        public IActionResult Login(IFormCollection value)
        {
            string fpass, fuser;
            bool check = false;
            fuser = value["UserName"];
            fpass = value["Password"];

            var list = context.Customers.ToList();
            foreach (Customer c in list)
            {
                if (fpass == c.Password && fuser == c.Username)
                {
                    check = true;
                    break;
                }
            }

            if (check == true)
            {
                HttpContext.Session.SetString("UserName", fuser);
                HttpContext.Session.SetString("mess", "");
                HttpContext.Session.SetString("UserNamead", "");
                return RedirectToAction(nameof(Index));
            }
            else
            {
                string mess = "Username or password incorrect";
                HttpContext.Session.SetString("mess", mess);
                return View();
            }

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
