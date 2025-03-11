namespace SalesDatePredictionAPI.DTOs
{
    public class CreateOrderDto
    {
        public int CustomerId { get; set; }
        public int EmpId { get; set; }
        public int ShipperId { get; set; }
        public string ShipName { get; set; }
        public string ShipAddress { get; set; }
        public string ShipCity { get; set; }
        public string ShipCountry { get; set; }
        public string? ShipRegion { get; set; }  // Agregado
        public string ShipPostalCode { get; set; }  // Agregado
        public int ProductId { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime RequiredDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        public decimal Freight { get; set; }
        public decimal Discount { get; set; }
    }
}
