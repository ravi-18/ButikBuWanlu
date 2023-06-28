namespace ButikAPI.Models
{
    /// <summary>
    /// Transaciton.
    /// </summary>
    public class Transaction
    {
        /// <summary>
        /// Gets or sets id.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets quantity.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets transaction Date
        /// </summary>
        public DateTime TransactionDate { get; set; }

        /// <summary>
        /// Gets or sets customer Id.
        /// </summary>
        public Guid CustomerId { get; set; }

        /// <summary>
        /// Gets or sets customer.
        /// </summary>
        public Customer Customer { get; set; }

        /// <summary>
        /// Gets or sets product Id.
        /// </summary>
        public Guid ProductId { get; set; }

        /// <summary>
        /// Gets or sets product.
        /// </summary>
        public Product Product { get; set; }

    }
}
