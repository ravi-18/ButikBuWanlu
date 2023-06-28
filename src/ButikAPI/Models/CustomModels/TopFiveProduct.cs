namespace ButikAPI.Models.CustomModels
{
    /// <summary>
    /// Top Five Product.
    /// </summary>
    public class TopFiveProduct
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
        /// Gets or sets quantity Increase.
        /// </summary>
        public int QuantityIncrease { get; set; }
    }
}
