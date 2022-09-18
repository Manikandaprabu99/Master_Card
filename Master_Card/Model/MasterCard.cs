namespace Master_Card.Model
{
    public class MasterCard
    {
        
        public long CreditCardNumber { get; set; }
        public string? CustomerName { get; set; }
        public string? CustomerEmail { get; set; }
        public long MobileNumber { get; set; }
        public float Amount { get; set; }
        public string? DueDate { get; set; }
        public float Charges { get; set; }
        public float DueAmount { get; set; }
        public string? Status { get; set; }
    }
}
