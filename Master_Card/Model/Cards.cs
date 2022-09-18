namespace Master_Card.Model
{
    public class Cards
    {
        
        public long CreditCardNumber { get; set; }
        public string? CustomerName { get; set; }
        public string? CustomerEmail { get; set; }
        public long MobileNumber { get; set; }
        public double Amount { get; set; }
        public string? DueDate { get; set; }
    }
}
