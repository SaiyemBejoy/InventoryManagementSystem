using InventoryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventoryManagementSystem.Controllers
{
    public class SaleController : Controller
    {
        Inventory_managementEntities db = new Inventory_managementEntities();
        // GET: Sale
        public ActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public ActionResult DisplaySale()
        {
            List<Sale> sales = db.Sales.OrderByDescending(x => x.id).ToList();
            return View(sales);
        }

        [HttpGet]
        public ActionResult SaleProduct()
        {
            List<string> products = db.Products.Select(x => x.Product_name).ToList();
            ViewBag.ProductName = new SelectList(products);

            return View();
        }

        [HttpPost]
        public ActionResult SaleProduct(Sale sale)
        {
            db.Sales.Add(sale);
            db.SaveChanges();

            return RedirectToAction("DisplaySale");
        }

        [HttpGet]
        public ActionResult EditSale(int id)
        {
            Sale sale = db.Sales.Where(x => x.id == id).SingleOrDefault();

            List<string> products = db.Products.Select(x => x.Product_name).ToList();
            ViewBag.ProductName = new SelectList(products);

            return View(sale);
        }

        [HttpPost]
        public ActionResult EditSale(int id, Sale sale)
        {
            Sale sl = db.Sales.Where(x => x.id == id).SingleOrDefault();
            sl.Sale_product = sale.Sale_product;
            sl.Sale_quantity = sale.Sale_quantity;
            sl.Sale_date = sale.Sale_date;

            db.SaveChanges();

            return RedirectToAction("DisplaySale");
        }

        [HttpGet]
        public ActionResult SaleDetails(int id)
        {
            Sale sale = db.Sales.Where(x => x.id == id).SingleOrDefault();

            return View(sale);
        }

        [HttpGet]
        public ActionResult DeleteSale(int id)
        {
            Sale sale = db.Sales.Where(x => x.id == id).SingleOrDefault();

            return View(sale);
        }

        [HttpPost]
        public ActionResult DeleteSale(int id, Sale sl)
        {
            Sale sale = db.Sales.Where(x => x.id == id).SingleOrDefault();
            db.Sales.Remove(sale);
            db.SaveChanges();

            return RedirectToAction("DisplaySale");
        }


    }
}