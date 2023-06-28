namespace ButikAPI.Models
{
    /// <summary>
    /// Customer Model.
    /// </summary>
    public class Customer
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
        /// Gets or sets email.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets registration Date.
        /// </summary>
        public DateTime RegistrationDate { get; set; }

        /// <summary>
        /// Gets or sets branch Id.
        /// </summary>
        public Guid BranchId { get; set; }

        /// <summary>
        /// Gets or sets branch.
        /// </summary>
        public Branch Branch { get; set; }

        /// <summary>
        /// Gets or sets trancsactions.
        /// </summary>
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}