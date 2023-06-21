using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ShopFlower.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopFlower.Controllers
{
    
    public class CartController : Controller
    {
        //Dictionary<string, Dictionary<string, string>> cart;

        public CartController()
        {
            //this.cart = new Dictionary<string, Dictionary<string, string>>();
        }


        // public const string CARTKEY = "cart";
        private readonly ShopFlowerContext context = new ShopFlowerContext();
       
        //public Cart GetCart()
        //{
        //    Cart cart = Session["Cart"] as Cart;
        //}
        // GET: CartController
        public ActionResult Cart()
        {
            Dictionary<string, Dictionary<string, string>> cart = new Dictionary<string, Dictionary<string, string>>();
            if (HttpContext.Session.GetString("cart") != null)
            {
                cart = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, string>>>(HttpContext.Session.GetString("cart"));
            }
            else
            {
                cart = null;
                //string jsonstring = JsonConvert.SerializeObject(cart);
                //HttpContext.Session.SetString("cart", jsonstring);
            }
            ViewData["cart"] = cart;
            return View();
        }


        public ActionResult AddToCart(string id)
        {
            //Product product = context.Products.Where(p => p.ProId == id).FirstOrDefault();
            Product product = context.Products.Find(id);
            /*
             * check key "cart" co trong session ko:
             * khong: tao cart
            //check productid trong cart trong session:
                co
                    get quantity by proid: +1
                khong
                    add new product to list
             */
            Dictionary<string, Dictionary<string, string>> cart = new Dictionary<string, Dictionary<string, string>>();
            if (HttpContext.Session.GetString("cart") != null) { 
                cart = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, string>>>(HttpContext.Session.GetString("cart"));
            }
            
            //Dictionary<string, Dictionary<string, string>> cart = HttpContext.Current.Session["cart"] as Dictionary<string, Dictionary<string, string>>;
            //string jsonstring = JsonConvert.SerializeObject(ob);

            if (cart.ContainsKey(product.ProId))
            {
                Dictionary<string, string> productAttr = cart[product.ProId];
                //    //get quantity by proid: +1
                int quantity = Convert.ToInt32(productAttr["Quantity"]) + 1;
                decimal price = Convert.ToDecimal(productAttr["Price"]);
                decimal total = quantity * price;
                productAttr["Quantity"] = quantity.ToString();
                productAttr["Total"] = total.ToString();
                
            }
            else
            {
                //add new product to list
                Dictionary<string, string> newProductAttr = new Dictionary<string, string>();
                newProductAttr["Proname"] = product.ProName;
                newProductAttr["Image"] = product.Image;
                newProductAttr["Quantity"] = "1";
                newProductAttr["Price"] = product.Price.ToString();
                newProductAttr["Total"] = product.Price.ToString();

                cart.Add(product.ProId, newProductAttr); 

               
                //string jsonstring = JsonConvert.SerializeObject(cart);
                //HttpContext.Session.SetString("cart", jsonstring);
                
            }
            string jsonstring = JsonConvert.SerializeObject(cart);
            HttpContext.Session.SetString("cart", jsonstring);
            //Dictionary<string, Dictionary<string, string>> cart1 = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, string>>>(HttpContext.Session.GetString("cart"));
            //if (cart.ContainsKey(product.ProId))
            //{
            //    Dictionary<string, string> productAttr = cart[product.ProId];
            //    //get quantity by proid: +1
            //    productAttr["Quantity"] = (Convert.ToInt32(productAttr["Quantity"]) + 1).ToString();
            //    productAttr["Total"] = (Convert.ToInt32(productAttr["Quantity"]) + 1) * Convert.ToInt32(productAttr["Price"]) + "";

            //}
            //else
            //{
            //    //add new product to list
            //    Dictionary<string, string> newProductAttr = new Dictionary<string, string>();
            //    newProductAttr["Proname"] = product.ProName;
            //    newProductAttr["Image"] = product.Image;
            //    newProductAttr["Quantity"] = "1";
            //    newProductAttr["Price"] = product.Price.ToString();
            //    newProductAttr["Total"] = product.Price.ToString();

            //    cart.Add(product.ProId,newProductAttr);
            //}

            /*
             "Username" -> username
                  "Cart" -> [
                        "Proid 1" -> (
                                "Proname" = proname
                                "Quantity" = quantity
                                "Price" 
                        )
                        "Pro 2" -> 
                      ]
                }
             */
            decimal t = 0;
            foreach (var key in cart.Keys)
            {
                Dictionary<string, string> productAttr = cart[key];
                t += Convert.ToDecimal(productAttr["Total"]);
               
            }
            ViewBag.Total = t;

                //return View("Views/Cart/Cart.cshtml");
                return RedirectToAction(nameof(Cart));
        }

        /*
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddToCart([FromRoute] int id)
        {
            List<Product> listcart = new List<Product>();
            var pro = context.Products.Find(id);
            if (pro == null)
            {
                return NotFound();
            }
            listcart.Add(pro);
            
            return View();
        }

        // GET: CartController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }
        */

        public ActionResult CheckOut(string id)
        {
            return RedirectToAction("Index", "Home");
        }

    }
}
