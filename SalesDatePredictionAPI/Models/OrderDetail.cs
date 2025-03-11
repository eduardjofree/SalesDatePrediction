using System.ComponentModel.DataAnnotations.Schema;

namespace SalesDatePredictionAPI.Models
{
    [Table("OrderDetails", Schema = "Sales")]
    public class OrderDetail
    {
        public int orderid { get; set; }
        public int productid { get; set; }
        public decimal unitprice { get; set; }
        public int qty { get; set; }
        public decimal discount { get; set; }

        // Relaciones
        public Order Order { get; set; }
        public Product Product { get; set; }
    }
}

