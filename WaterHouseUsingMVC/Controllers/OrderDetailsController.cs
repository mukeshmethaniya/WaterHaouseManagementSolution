using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WaterHouseUsingMVC.Models;

namespace WaterHouseUsingMVC.Controllers
{
    public class OrderDetailsController : Controller
    {
        //
        // GET: /OrderListDetails/

        public ActionResult Details(int id)
        {
            Order order = new Order()
            {
                ORDERNUMBER = 1001,
                FIRSTNAME = "Mukesh",
                MIDDLENAME = "G",
                LASTNAME = "Methaniya",
                MOBILENO = "9998186874",
                ADDRESS = "Bharada",
                QTYBTBOTTLE = 5,
                QTYPOUCH = 4,
                QTYICEBOTTLE = 10,
                ROOTID=101
            };
            OrderListDBContext orderList = new OrderListDBContext();
            if (orderList.OrderList.Count() == 0)
            {
                orderList.OrderList.Add(order);
                orderList.SaveChanges();
                id = 0;
            }
            else
            {

                order = orderList.OrderList.Single(x => x.ORDERNUMBER == id);
            }
            return View(order);
        }

        public ActionResult Orders(int rootId)
        {
            OrderListDBContext orderList = new OrderListDBContext();
            return View(orderList.OrderList.ToList());
        }

       
    }
}
