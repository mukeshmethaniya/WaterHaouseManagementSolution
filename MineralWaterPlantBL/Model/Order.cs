using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineralWaterPlantBL.Model
{
    public class Order
    {
        public int Id { get; set; }
      //  public string Name { get; set; }

        public int CustomerId { get; set; }
        public int RouteId { get; set; }
     //   public Customer Customer { get; set; }
       // public RoutePoint RouteIdPoint { get; set; }

        public int SubTotal { get; set; }
        public float Discount { get; set; }
        public int Total { get; set; }
        public string Info { get; set; }

        public DateTime Date;
        public TimeSpan TIme;

        public string ContactNumber { get; set; }
    }
}
