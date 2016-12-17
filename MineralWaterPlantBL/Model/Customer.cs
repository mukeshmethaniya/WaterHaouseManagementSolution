using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineralWaterPlantBL.Model
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        public CustomerType CustomerType { get; set; }
        public string Name { get; set; }
        public string MobileNumber { get; set; }
        public string Address { get; set; }
        public int PrimaryRouteId { get; set; }
        public int SecondaryRouteId { get; set; }
        public string Remark { get; set; }
    }

    public enum CustomerType
    {
        Mix,
        AquaZeel,
        BT_Jug
    }
}
