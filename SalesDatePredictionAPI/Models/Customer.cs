
using System.ComponentModel.DataAnnotations.Schema;

namespace SalesDatePredictionAPI.Models
{
    [Table("Customers", Schema = "Sales")]
    public class Customer
    {
        public int custid { get; set; }
        public string companyname { get; set; }

        public string contactname { get; set; }
        public string contacttitle { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string? region { get; set; }
        public string postalcode { get; set; }
        public string country { get; set; }
        public string phone { get; set; }
        public string? fax { get; set; }

        // Relación con órdenes
        //public ICollection<Order> Orders { get; set; }
    }
}

