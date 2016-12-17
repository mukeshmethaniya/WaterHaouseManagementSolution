using MineralWaterPlantBL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MineralWaterPlant.Controllers
{
    public class CustomerController : Controller
    {
        //
        // GET: /Customer/

        public ActionResult Index()
        {
            MineralWaterPlantDbContext database = new MineralWaterPlantDbContext();
            var customers = database.DailyCustomers;
            return View(customers);
        }

        public ActionResult Create()
        {
            return View();
        }

         [HttpPost]
        public ActionResult Create(Customer customer )
        {
            MineralWaterPlantDbContext database = new MineralWaterPlantDbContext();
             database.DailyCustomers.Add(customer);
             database.SaveChanges();
            return View();
        }

         public JsonResult GetAll(string custName)
         {
             MineralWaterPlantDbContext database = new MineralWaterPlantDbContext();
             var customers = database.DailyCustomers.ToList();
             if (custName.Length > 2)
             {
                 customers = customers.FindAll(x => x.Name.ToLower().Contains(custName.ToLower()));
             }
             return Json(customers, JsonRequestBehavior.AllowGet);
         }

    }
}
