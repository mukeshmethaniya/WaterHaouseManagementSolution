using MineralWaterPlantBL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MineralWaterPlant.Controllers
{
    public class DailyOrderPlaceController : Controller
    {
        //
        // GET: /DailyOrderPlace/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(OrderPlaceDesk desk)
        {
            if (desk != null)
            {
                MineralWaterPlantDbContext database = new MineralWaterPlantDbContext();
                var lastorders = database.DailyCustomerOrders.Count();
                
                var order = desk.Order;
                order.Id = lastorders+1;
                order.CustomerId = desk.Customer.Id;
                if (desk.OrderedItems.Count > 0)
                {
                    foreach (var orderedItem in desk.OrderedItems)
                    {
                        orderedItem.OrderId = order.Id;
                    }
                }
                database.DailyCustomerOrders.Add(order);
                database.OrderedItems.AddRange(desk.OrderedItems);
                database.SaveChanges();

            }
            return View();
        }

    }
}
