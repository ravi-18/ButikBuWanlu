namespace ButikAPI.Services
{
    using ButikAPI.Models;
    using ButikAPI.Models.CustomModels;
    using static HotChocolate.ErrorCodes;

    /// <summary>
    /// ICustomer Service.
    /// </summary>
    public interface ICustomerService
    {
        /// <summary>
        /// Create Customer.
        /// </summary>
        /// <param name="input">Customer Register Input.</param>
        /// <returns>Customer.</returns>
        Task<Customer> CreateCustomer(CustomerRegisterInput input);

        /// <summary>
        /// Modify Customer.
        /// </summary>
        /// <param name="input">Customer Modify Input.</param>
        /// <returns>Customer.</returns>
        Task<Customer> ModifyCustomer(CustomerModifyInput input);

        /// <summary>
        /// Delete Customer By Id.
        /// </summary>
        /// <param name="id">Customer Id.</param>
        /// <returns>Delete Response.</returns>
        Task<DeleteResponse> DeleteCustomerById(Guid id);

        /// <summary>
        /// Untuk menampilkan data pelanggan yang pertama kali mendaftar
        /// (pelanggan terlama)
        /// Old Customer.
        /// </summary>
        /// <returns>Customer.</returns>
        Task<Customer> OldCustomer();

        /// <summary>
        /// pelanggan yang terakhir kali mendaftar(pelanggan
        /// terbaru) berdasarkan cabang.
        /// New Customer.
        /// </summary>
        /// <returns>Customer.</returns>
        Task<Customer> NewCustomer();

        /// <summary>
        /// Untuk menampilkan 10 data pelanggan yang paling besar belanjanya dalam
        /// 1 bulan di setiap cabang(berdasarkan akumulasi total belanja).
        /// Ten Most Buyers Per Month.
        /// </summary>
        /// <param name="month">Month.</param>
        /// <returns>Top Most Buyers.</returns>
        Task<IQueryable<TopMostBuyers>> TenMostBuyersPerMonth(int? month);
    }
}
