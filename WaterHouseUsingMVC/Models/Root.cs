using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WaterHouseUsingMVC.Models
{
    [Table("RootList")]
    public class Root
    {
        [Key]
        public int ROOT_ID { get; set; }
        public string STATION { get; set; }
        public List<Order> OrderList { get; set; }
    }
}