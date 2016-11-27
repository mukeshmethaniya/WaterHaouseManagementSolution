using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WaterHouseUsingMVC.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            ViewBag.Products = new List<string>() { 
                "Aqua Pouch",
                "BT Jug",
                "Cool Jug"
             };
            return View();
        }

    }
}
