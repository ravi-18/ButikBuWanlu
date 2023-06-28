namespace ButikAPI.Models.CustomModels
{
    /// <summary>
    /// Transaction Register Input.
    /// </summary>
    public class TransactionRegisterInput
    {
        /// <summary>
        /// Gets or sets quantity.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets Transaction Date.
        /// </summary>
        public DateTime TransactionDate { get; set; }

        /// <summary>
        /// Gets or sets customer Id.
        /// </summary>
        public Guid CustomerId { get; set; }

        /// <summary>
        /// Gets or sets product Id.
        /// </summary>
        public Guid ProductId { get; set; }
    }
}
