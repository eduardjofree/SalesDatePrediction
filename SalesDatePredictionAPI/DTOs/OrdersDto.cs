namespace SalesDatePredictionAPI.DTOs
{
    public class OrdersDto
    {
        public int Orderid { get; set; }
        public string Requireddate { get; set; }
        public string? Shippeddate { get; set; }
        public string Shipname { get; set; }
        public string Shipaddress { get; set; }
        public string Shipcity { get; set; }
    }
}
