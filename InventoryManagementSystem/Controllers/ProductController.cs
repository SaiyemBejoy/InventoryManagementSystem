using InventoryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventoryManagementSystem.Controllers
{
    public class ProductController : Controller
    {
        Inventory_managementEntities db = new Inventory_managementEntities();
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult DisplayProduct()
        {
            List<Product> products = db.Products.OrderByDescending(x => x.id).ToList();

            return View(products);
        }

        [HttpGet]
        public ActionResult CreateProduct()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateProduct(Product product)
        {
            db.Products.Add(product);
            db.SaveChanges();

            return RedirectToAction("DisplayProduct");
        }

        [HttpGet]
        public ActionResult UpdateProduct(int id)
        {
            Product product = db.Products.Where(x=> x.id == id).SingleOrDefault();

            return View(product);
        }

        [HttpPost]
        public ActionResult UpdateProduct(int id, Product prod)
        {
            Product product = db.Products.Where(x => x.id == id).SingleOrDefault();
            product.Product_name = prod.Product_name;
            product.Product_quantity = prod.Product_quantity;
            db.SaveChanges();

            return RedirectToAction("DisplayProduct");
        }

        [HttpGet]
        public ActionResult ProductDetails(int id)
        {
            Product product = db.Products.Where(x => x.id == id).SingleOrDefault();

            return View(product);
        }

        [HttpGet]
        public ActionResult DeleteProduct(int id)
        {
            Product product = db.Products.Where(x => x.id == id).SingleOrDefault();

            return View(product);
        }

        [HttpPost]
        public ActionResult DeleteProduct(int id, Product prod)
        {
            Product product = db.Products.Where(x => x.id == id).SingleOrDefault();
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("DisplayProduct");
        }
    }
}