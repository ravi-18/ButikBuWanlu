namespace ButikAPI.Models
{
    public class Transaction
    {
        public Guid Id { get; set; }
        public int Quantity { get; set; }
        public DateTime TransactionDate { get; set; }
        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; }
        public Guid ProductId { get; set; }
        public Product Product { get; set; }

    }
}
