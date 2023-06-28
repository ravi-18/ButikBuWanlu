namespace ButikAPI.Models.CustomModels
{
    /// <summary>
    /// Customer Register Input.
    /// </summary>
    public class CustomerRegisterInput
    {
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
    }
}
