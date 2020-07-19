using InventoryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventoryManagementSystem.Controllers
{
    public class PurchaseController : Controller
    {
        Inventory_managementEntities db = new Inventory_managementEntities();
        // GET: Purchase
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult DisplayPurchase()
        {
            List<Purchase> purchases = db.Purchases.OrderByDescending(x => x.id).ToList();

            return View(purchases);
        }

        [HttpGet]
        public ActionResult PurchaseProduct()
        {
            List<string> products = db.Products.Select(x => x.Product_name).ToList();
            ViewBag.ProductName = new SelectList(products);

            return View();
        }

        [HttpPost]
        public ActionResult PurchaseProduct(Purchase purchase)
        {
            db.Purchases.Add(purchase);
            db.SaveChanges();

            return RedirectToAction("DisplayPurchase");
        }

        [HttpGet]
        public ActionResult EditPurchase(int id)
        {
            Purchase purchase = db.Purchases.Where(x => x.id == id).SingleOrDefault();

            List<string> products = db.Products.Select(x => x.Product_name).ToList();
            ViewBag.ProductName = new SelectList(products);

            return View(purchase);
        }

        [HttpPost]
        public ActionResult EditPurchase(int id, Purchase purchase)
        {
            Purchase purch = db.Purchases.Where(x => x.id == id).SingleOrDefault();
            purch.Purchase_date = purchase.Purchase_date;
            purch.Purchase_quantity = purchase.Purchase_quantity;
            purch.Purchase_product = purchase.Purchase_product;

            db.SaveChanges();

            return RedirectToAction("DisplayPurchase");
        }

        [HttpGet]
        public ActionResult PurchaseDetails(int id)
        {
            Purchase purchase = db.Purchases.Where(x => x.id == id).SingleOrDefault();

            return View(purchase);
        }

        [HttpGet]
        public ActionResult DeletePurchase(int id)
        {
            Purchase purchase = db.Purchases.Where(x => x.id == id).SingleOrDefault();

            return View(purchase);
        }

        [HttpPost]
        public ActionResult DeletePurchase(int id, Purchase purch)
        {
            Purchase purchase = db.Purchases.Where(x => x.id == id).SingleOrDefault();
            db.Purchases.Remove(purchase);
            db.SaveChanges();

            return RedirectToAction("DisplayPurchase");
        }
    }
}