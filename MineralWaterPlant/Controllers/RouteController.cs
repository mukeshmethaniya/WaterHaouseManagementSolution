using MineralWaterPlantBL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MineralWaterPlant.Controllers
{
    public class RouteController : Controller
    {
        //
        // GET: /Route/

        public ActionResult Index()
        {
            MineralWaterPlantDbContext database = new MineralWaterPlantDbContext();
            return View(database.Routes);
        }

        public ActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Create(Route route)
        {
            if (ModelState.IsValid)
            {
                MineralWaterPlantDbContext database = new MineralWaterPlantDbContext();
                database.Routes.Add(route);
                database.SaveChanges();

                return RedirectToAction("Index");
            }
            return View();
        }

        public JsonResult GetAll()
        {
            MineralWaterPlantDbContext database = new MineralWaterPlantDbContext();
            var routes = database.Routes;
            return Json(routes.ToList(), JsonRequestBehavior.AllowGet);
        }

    }
}
