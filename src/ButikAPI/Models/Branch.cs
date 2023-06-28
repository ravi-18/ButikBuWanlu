namespace ButikAPI.Models
{
    /// <summary>
    /// Branch Model.
    /// </summary>
    public class Branch
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
        /// Gets or sets customers.
        /// </summary>
        public virtual ICollection<Customer> Customers { get; set; }
    }
}
