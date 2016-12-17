using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace MineralWaterPlantBL.Model
{
   public class MineralWaterPlantDbContextInitializer : DropCreateDatabaseIfModelChanges<MineralWaterPlantDbContext>
    {
        protected override void Seed(MineralWaterPlantDbContext context)
        {
            var product = new Product()
            {
                Id=1001,
                Name="Aqua Zeel",
                Info="This is 50 pouch bag",
                DefultPrize=25
            };

            context.Products.Add(product);

            var route = new Route()
            {
                Info = "This route is for the thala bharada",
                Name = "Thala-Bharada"
            };

            context.Routes.Add(route);

            var routeItem = new RoutePoint()
            {
                Name = "Bharada",
                RouteId = 1
            };

            var customer = new Customer()
            {
                Name = "Shree Swaminarayan Surukul",
                Address = "Dhrangadhra",
                MobileNumber = "9876543490",
                CustomerType = CustomerType.BT_Jug,
                PrimaryRouteId = 1,
                SecondaryRouteId = 1,
                Remark = "Jay Swaminararayan"
            };
            context.DailyCustomers.Add(customer);

       



            context.RoutePoints.Add(routeItem);


            var order = new Order()
            {
                CustomerId = 1,
                ContactNumber = "987653490",
                RouteId = 1,
                Date = DateTime.Now,
                SubTotal = 100,
                Total = 100
            };
            context.DailyCustomerOrders.Add(order);
            var orderedItem = new OrderedItem()
            {
                OrderId = 1,
                ProductID = 1,
                Quantity = 5,
                PricePerUnit = 20
            };
            context.OrderedItems.Add(orderedItem);
         

            context.SaveChanges();

            base.Seed(context);
        }
    }
}
