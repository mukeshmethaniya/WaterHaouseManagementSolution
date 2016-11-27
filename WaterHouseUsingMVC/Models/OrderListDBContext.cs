using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace WaterHouseUsingMVC.Models
{
    public class OrderListDBContext:DbContext
    {
        public DbSet<Order> OrderList { get; set; }
        public DbSet<Root> RootList { get; set; }
    }
}