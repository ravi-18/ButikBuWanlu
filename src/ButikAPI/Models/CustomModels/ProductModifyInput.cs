namespace ButikAPI.Models.CustomModels
{
    /// <summary>
    /// Product Modify Input.
    /// </summary>
    public class ProductModifyInput : ProductRegisterInput
    {
        /// <summary>
        /// Gets or sets id.
        /// </summary>
        public Guid Id { get; set; }
    }
}
