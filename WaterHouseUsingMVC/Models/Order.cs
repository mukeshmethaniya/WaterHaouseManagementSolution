using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace WaterHouseUsingMVC.Models
{

    [Table("OrderList")]
    public class Order
    {
        [Key]
        public int ORDERNUMBER { get; set; }
        [Required]
        public string FIRSTNAME { get; set; }
        public string MIDDLENAME { get; set; }
        [Required]
        public string LASTNAME { get; set; }
        [Required]
        public string MOBILENO { get; set; }
        [Required]
        public string ADDRESS { get; set; }
        public int QTYICEBOTTLE { get; set; }
        public int QTYBTBOTTLE { get; set; }
        public int QTYPOUCH { get; set; }
        public int ROOTID { get; set; }

    }
}