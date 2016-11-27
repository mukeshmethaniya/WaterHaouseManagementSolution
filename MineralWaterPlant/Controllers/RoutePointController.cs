using MineralWaterPlantBL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MineralWaterPlant.Controllers
{
    public class RoutePointController : Controller
    {
        //
        // GET: /RoutePoint/

        public ActionResult Index()
        {
            MineralWaterPlantDbContext database = new MineralWaterPlantDbContext();

            return View(database.RoutePoints);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(RoutePoint routePoint)
        {
            if (ModelState.IsValid)
            {
                MineralWaterPlantDbContext database = new MineralWaterPlantDbContext();
                database.RoutePoints.Add(routePoint);
                database.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
