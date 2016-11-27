using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineralWaterPlantBL.Model
{
   public  class OrderPlaceDesk
    {
       public Customer Customer { get; set; }
       public Order Order { get; set; }
       public List<OrderedItem> OrderedItems { get; set; }
       public OrderPlaceDesk()
       {
           Customer = new Customer();
           Order = new Order();
           OrderedItems = new List<OrderedItem>();
           OrderedItems.Add(new OrderedItem() { OrderId=56,ProductID=34,Quantity=5,Discount=10});
       }
    }
}
