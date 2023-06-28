namespace ButikAPI.Models.CustomModels
{
    /// <summary>
    /// Customer Modify Input.
    /// </summary>
    public class CustomerModifyInput : CustomerRegisterInput
    {
        /// <summary>
        /// Gets or sets id.
        /// </summary>
        public Guid Id { get; set; }
    }
}
