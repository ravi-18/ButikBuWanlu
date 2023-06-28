
namespace ButikAPI.Services
{
    using ButikAPI.Models;
    using ButikAPI.Models.CustomModels;

    /// <summary>
    /// ITransaction Service.
    /// </summary>
    public interface ITransactionService
    {
        /// <summary>
        /// Create Transaction.
        /// </summary>
        /// <param name="input">Transaction Register Input.</param>
        /// <returns>Transaction.</returns>
        Task<Transaction> CreateTransaction(TransactionRegisterInput input);

        /// <summary>
        /// Modify Transaction.
        /// </summary>
        /// <param name="input">Transaction Modify Input.</param>
        /// <returns>Transaction.</returns>
        Task<Transaction> ModifyTransaction(TransactionModifyInput input);

        /// <summary>
        /// Delete By Transaction Id.
        /// </summary>
        /// <param name="id">Transaction Id.</param>
        /// <returns>Delete Response.</returns>
        Task<DeleteResponse> DeleteByTransactionId(Guid id);

        /// <summary>
        /// Untuk menampilkan 10 data pakaian yang paling banyak dibeli dalam 1 bulan
        /// di setiap cabang(berdasarkan quantity).
        /// Ten Best Selling Products Per Month.
        /// </summary>
        /// <param name="month">Month.</param>
        /// <returns>Product..</returns>
        Task<IQueryable<Product>> TenBestSellingProductsPerMonth(int? month);

        /// <summary>
        /// Untuk menampilkan data nominal penjualan setiap cabang dalam 1 tahun.
        /// Total Sales Per Year.
        /// </summary>
        /// <param name="year">Year.</param>
        /// <returns>Total Sales Per Year CustomModel.</returns>
        Task<IQueryable<TotalSalesPerYearCustomModel>> TotalSalesPerYear(int? year);

        /// <summary>
        /// Untuk menampilkan 5 data pakaian yang mengalami peningkatan tertinggi.
        /// penjualan dalam bulan ini dibandingkan bulan sebelumnya. Dengan cara
        /// membandingkan quantity yg terjual bulan ini dengan quantity yang terjual
        /// bulan sebelumnya.
        /// Five Sales Increase Per Month.
        /// </summary>
        /// <returns>Top Five Product.</returns>
        Task<IQueryable<TopFiveProduct>> FiveSalesIncreasePerMonth();
    }
}
