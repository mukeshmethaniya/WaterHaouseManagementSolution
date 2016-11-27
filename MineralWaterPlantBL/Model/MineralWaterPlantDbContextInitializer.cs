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

            context.RoutePoints.Add(routeItem);

            

         

            context.SaveChanges();

            base.Seed(context);
        }
    }
}
