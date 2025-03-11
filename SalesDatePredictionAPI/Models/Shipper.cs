
using Microsoft.EntityFrameworkCore.Update.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalesDatePredictionAPI.Models
{
    [Table("Shippers", Schema = "Sales")]
    public class Shipper
    {
        public int shipperid { get; set; }
        public string companyname { get; set; }
        public string phone { get; set; }

        // Relación con órdenes
        //public ICollection<Order> Orders { get; set; }
    }
}

