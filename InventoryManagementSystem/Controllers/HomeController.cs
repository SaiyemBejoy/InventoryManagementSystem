using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventoryManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Thanks for visiting \"MJS Store\"";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact us from the following address";

            return View();
        }
    }
}