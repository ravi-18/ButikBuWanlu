namespace ButikAPI.Services
{
    using ButikAPI.Models;
    using ButikAPI.Models.CustomModels;

    /// <summary>
    /// IProduct Service.
    /// </summary>
    public interface IProductService
    {
        /// <summary>
        /// Create Prodcut.
        /// </summary>
        /// <param name="input">Product Register Input.</param>
        /// <returns>Product.</returns>
        Task<Product> CreateProduct(ProductRegisterInput input);

        /// <summary>
        /// Modify Product.
        /// </summary>
        /// <param name="input">Product Modify Input.</param>
        /// <returns>Product.</returns>
        Task<Product> ModifyProduct(ProductModifyInput input);

        /// <summary>
        /// Delete By Product Id.
        /// </summary>
        /// <param name="id">Product Id.</param>
        /// <returns>Delete Response.</returns>
        Task<DeleteResponse> DeleteByProductId(Guid id);

        /// <summary>
        /// Untuk menampilkan data pakaian dengan harga paling tinggi.
        /// Prodcuct Highest Price.
        /// </summary>
        /// <returns>Product.</returns>
        Task<Product> ProductHighestPrice();

        /// <summary>
        /// Untuk menampilkan data pakaian dengan harga paling murah.
        /// Product Lowest Price.
        /// </summary>
        /// <returns>Product.</returns>
        Task<Product> ProductLowestPrice();

    }
}
