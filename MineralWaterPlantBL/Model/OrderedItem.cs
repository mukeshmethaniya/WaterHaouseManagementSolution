using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineralWaterPlantBL.Model
{
    public class OrderedItem
    {
        [Key]
        public int Index { get; set; }
        public int OrderId { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public int PricePerUnit { get; set; }
        public float Discount { get; set; }
    }
}
