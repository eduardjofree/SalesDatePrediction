﻿
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;

namespace SalesDatePredictionAPI.Models
{
    [Table("Orders", Schema = "Sales")]
    public class Order
    {
        public int orderid { get; set; }
        public int custid { get; set; }
        public int empid { get; set; }
        public DateTime orderdate { get; set; }
        public DateTime requireddate { get; set; }
        public DateTime? shippeddate { get; set; }
        public int shipperid { get; set; }
        public decimal freight { get; set; }
        public string shipname { get; set; }
        public string shipaddress { get; set; }
        public string shipcity { get; set; }
        public string? shipregion { get; set; }
        public string shippostalcode { get; set; }
        public string shipcountry { get; set; }

        // Relaciones
        //public Customer Customer { get; set; }
        //public Employee Employee { get; set; }
        //public Shipper Shipper { get; set; }
        //public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}

