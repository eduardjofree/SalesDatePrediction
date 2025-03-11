namespace SalesDatePredictionAPI.DTOs
{
    public class ResponsePredictOrderForDateDto
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public DateTime? LastOrderDate { get; set; }
        public DateTime? NextPredictOrder { get; set; }
    }
}
