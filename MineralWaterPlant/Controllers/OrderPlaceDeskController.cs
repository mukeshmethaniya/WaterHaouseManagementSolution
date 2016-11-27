using MineralWaterPlantBL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MineralWaterPlant.Controllers
{
    public class OrderPlaceDeskController : Controller
    {
        //
        // GET: /OrderPlaceDesk/
     //   OrderPlaceDesk orderDesk = new OrderPlaceDesk();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            OrderPlaceDesk orderDesk = new OrderPlaceDesk();
            return View(orderDesk);
        }

        //[HttpPost]
        //public ActionResult Create(List<OrderedItem> orderedItems)
        //{
        //    if (orderedItems != null)
        //    {
        //      //  orderDesk.OrderedItem.Add(orderedItem);
        //      //  return View(orderDesk);
        //    }
        //    return View();
        //}

        [HttpPost]
        public ActionResult Create(OrderPlaceDesk desk)
        {
            //if (orderedItem != null)
            //{
            //    orderDesk.OrderedItem.Add(orderedItem);
            //    return View(orderDesk);
            //}
            return View();
        }

    }
}
