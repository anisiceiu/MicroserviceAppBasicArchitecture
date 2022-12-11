namespace SharedLibrary
{
    public class Order
    {
        public int OrderId { get; set; }
        public string? CustomerName { get; set; }
        public string? Details { get; set; }
        public decimal TotalAmount { get; set; }
    }
}