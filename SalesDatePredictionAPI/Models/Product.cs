
using System.ComponentModel.DataAnnotations.Schema;

namespace SalesDatePredictionAPI.Models
{
    [Table("Products", Schema = "Production")]
    public class Product
    {
        public int productid { get; set; }
        public string productname { get; set; }
        public int supplierid { get; set; }
        public int categoryid { get; set; }
        public decimal unitprice { get; set; }
        public int discontinued { get; set; }

        // Relación con detalles de orden
        //public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}

