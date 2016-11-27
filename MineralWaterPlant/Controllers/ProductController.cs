using MineralWaterPlantBL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MineralWaterPlant.Controllers
{
    public class ProductController : Controller
    {
        //
        // GET: /Product/

        public ActionResult Index()
        {
            MineralWaterPlantDbContext database = new MineralWaterPlantDbContext();
            var products = database.Products;

            return View(products);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                MineralWaterPlantDbContext database = new MineralWaterPlantDbContext();
                var products = database.Products.ToList();
                product.Id = products[products.Count - 1].Id + 1;
                database.Products.Add(product);
                database.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Edit(int id)
        {
            MineralWaterPlantDbContext database = new MineralWaterPlantDbContext();
            var product = database.Products.Single(x => x.Id == id);
            return View(product);
        }

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                MineralWaterPlantDbContext database = new MineralWaterPlantDbContext();
                var originalProduct = database.Products.Single(x => x.Id == product.Id);
                originalProduct.Name = product.Name;
                originalProduct.Info = product.Info;
                originalProduct.DefultPrize = product.DefultPrize;
                database.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        
        public JsonResult GetAll()
        {
            MineralWaterPlantDbContext database = new MineralWaterPlantDbContext();
            var products = database.Products;
            return Json(products.ToList(), JsonRequestBehavior.AllowGet);
        }

    }
}
