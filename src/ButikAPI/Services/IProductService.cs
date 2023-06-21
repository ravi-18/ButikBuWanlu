using ButikAPI.Models;

namespace ButikAPI.Services
{
    public interface IProductService
    {
        //Untuk menampilkan data pakaian dengan harga paling tinggi dan paling murah.
        Task<Product> ProductHighestPrice();
        Task<Product> ProductLowestPrice();

    }
}
