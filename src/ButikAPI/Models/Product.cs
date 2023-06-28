namespace ButikAPI.Models
{
    /// <summary>
    /// Product.
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Gets or sets id.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets price.
        /// </summary>
        public int Price { get; set; }

        /// <summary>
        /// Gets or sets transctions.
        /// </summary>
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
