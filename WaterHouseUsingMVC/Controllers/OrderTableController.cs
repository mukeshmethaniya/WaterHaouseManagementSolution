using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using WaterHouseUsingMVC.Models;

namespace WaterHouseUsingMVC.Controllers
{
    public class OrderTableController : Controller
    {
        //
        // GET: /OrderTable/

        public ActionResult Index()
        {
            //OrderListDBContext orderList = new OrderListDBContext();
            WaterHouseBusinessLayer.OrderBusinessLayer bl = new WaterHouseBusinessLayer.OrderBusinessLayer();

            return View(bl.OrderList.ToList());

        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        //[HttpPost]
        //public ActionResult Create(FormCollection collection)
        //{
        //    Order order = new Order();
        //    order.ORDERNUMBER =Convert.ToInt32(collection["ORDERNUMBER"]);
        //    order.FIRSTNAME = collection["FIRSTNAME"];

        //    order.MIDDLENAME = collection["MIDDLENAME"];
        //    order.LASTNAME = collection["LASTNAME"];
        //    order.ROOTID = Convert.ToInt32(collection["ROOTID"]);
        //    OrderListDBContext orderList = new OrderListDBContext();
        //    orderList.OrderList.Add(order);
        //    orderList.SaveChanges();

        //   return RedirectToAction("Index");

        //   // return View();
        //}

        [HttpPost]
        public ActionResult Create(WaterHouseBusinessLayer.Order order)
        {
            if (ModelState.IsValid)
            {
             //   OrderListDBContext orderList = new OrderListDBContext();
            //    orderList.OrderList.Add(order);
            //    orderList.SaveChanges();
                WaterHouseBusinessLayer.OrderBusinessLayer bl = new WaterHouseBusinessLayer.OrderBusinessLayer();
                bl.AddOrder(order);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
           // OrderListDBContext orderList = new OrderListDBContext();
            WaterHouseBusinessLayer.OrderBusinessLayer bl = new WaterHouseBusinessLayer.OrderBusinessLayer();
            WaterHouseBusinessLayer.Order order = bl.OrderList.Single(x => x.ORDERNUMBER == id);
            return View(order);
        }

        [HttpPost]
        public ActionResult Edit(Order order)
        {
            if(ModelState.IsValid)
            {
            OrderListDBContext orderList = new OrderListDBContext();
            Order orderDB = orderList.OrderList.Single(x => x.ORDERNUMBER == order.ORDERNUMBER);
            orderDB.FIRSTNAME = order.FIRSTNAME;
            orderDB.MIDDLENAME = order.MIDDLENAME;
            orderDB.LASTNAME = order.LASTNAME;
            orderDB.MOBILENO = order.MOBILENO;
            orderDB.ADDRESS = order.ADDRESS;
            orderDB.QTYBTBOTTLE = order.QTYBTBOTTLE;
            orderDB.QTYICEBOTTLE = order.QTYICEBOTTLE;
            orderDB.QTYPOUCH = order.QTYPOUCH;
            orderDB.ROOTID = order.ROOTID;
            orderList.SaveChanges();
            return RedirectToAction("Index");
            }

            return View(order);
        }
    }
}
