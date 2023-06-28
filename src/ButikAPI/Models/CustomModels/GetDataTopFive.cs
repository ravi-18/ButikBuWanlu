namespace ButikAPI.Models.CustomModels
{
    /// <summary>
    /// Get Data Top Five.
    /// </summary>
    public class GetDataTopFive
    {
        /// <summary>
        /// Gets or sets product Id.
        /// </summary>
        public Guid? ProductId { get; set; }

        /// <summary>
        /// Gets or sets quantity Increase.
        /// </summary>
        public int? Quantity1 { get; set; }

        /// <summary>
        /// Gets or sets quantity Increase.
        /// </summary>
        public int? Quantity2 { get; set; }

        /// <summary>
        /// Gets or sets quantity Increase.
        /// </summary>
        public int? QuantityIncrease { get; set; }
    }
}
