namespace ButikAPI.Models.CustomModels
{
    /// <summary>
    /// Top Most Buyers.
    /// </summary>
    public class TopMostBuyers
    {
        /// <summary>
        /// Gets or sets branch Name.
        /// </summary>
        public string BranchName { get; set; }

        /// <summary>
        /// Gets or sets month.
        /// </summary>
        public string Month { get; set; }

        /// <summary>
        /// Gets or sets customer Name.
        /// </summary>
        public string CustomerName { get; set; }

        /// <summary>
        /// Gets or sets total Spending.
        /// </summary>
        public int TotalSpending { get; set; }
    }
}
