﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineralWaterPlantBL.Model
{
    public class MineralWaterPlantDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public DbSet<Route> Routes { get; set; }

        public DbSet<RoutePoint> RoutePoints { get; set; }

    }
}
