namespace SalesDatePredictionAPI.DTOs
{
    public class ResponseOrdersByCustomerDto
    {
        public int OrderID { get; set; }
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string Employee { get; set; }
        public string Shipper { get; set; }
        public string OrderDate { get; set; }
        public string RequiredDate { get; set; }
        public string Freight { get; set; }
        public string ShipName { get; set; }
        public string ShipAddress { get; set; }
        public string ShipCity { get; set; }
        public string ShipCountry { get; set; }
    }
}
