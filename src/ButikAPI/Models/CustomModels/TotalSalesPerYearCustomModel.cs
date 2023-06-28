namespace ButikAPI.Models.CustomModels
{
    /// <summary>
    /// Top Sales Per Year Custom Model.
    /// </summary>
    public class TotalSalesPerYearCustomModel
    {
        /// <summary>
        /// Gets or sets branch Name.
        /// </summary>
        public string BranchName { get; set; }

        /// <summary>
        /// Gets or sets total Sales.
        /// </summary>
        public long TotalSales { get; set; }
    }
}
