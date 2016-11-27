using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WaterHouseUsingMVC.Models;

namespace WaterHouseUsingMVC
{
    public class OrderListDbContextInitializer : DropCreateDatabaseIfModelChanges<OrderListDBContext>
    {
        protected override void Seed(OrderListDBContext context)
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
                ROOTID = 1
            };

            Root root = new Root()
            {
                ROOT_ID = 1001,
                STATION = "THALA-BHARADA"

            };
            context.RootList.Add(root);
            context.OrderList.Add(order);
            context.SaveChanges();
            base.Seed(context);
        }
    }

  
}