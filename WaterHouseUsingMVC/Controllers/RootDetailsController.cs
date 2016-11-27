using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WaterHouseUsingMVC.Models;

namespace WaterHouseUsingMVC.Controllers
{
    public class RootDetailsController : Controller
    {
        //
        // GET: /RootDetails/


        public ActionResult Details(int rootId)
        {
            Root root = new Root()
            {
              ROOT_ID=1001,
              STATION="THALA-BHARADA"

            };
            OrderListDBContext orderList = new OrderListDBContext();
            if (orderList.RootList.Count() == 0)
            {
                orderList.RootList.Add(root);
                orderList.SaveChanges();
                rootId = 1001;
            }
            else
            {

                root = orderList.RootList.Single(x => x.ROOT_ID == rootId);
            }
            return View(root);
        }

        public ActionResult Roots()
        {
            OrderListDBContext orderList = new OrderListDBContext();
            return View(orderList.RootList.ToList());
        }

    }
}
