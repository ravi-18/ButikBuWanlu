using ButikAPI.Models;
using ButikAPI.Models.CustomModels;
using static HotChocolate.ErrorCodes;

namespace ButikAPI.Services
{
    public interface ICustomerService
    {
        //Untuk menampilkan data pelanggan yang pertama kali mendaftar
        //(pelanggan terlama) dan pelanggan yang terakhir kali mendaftar(pelanggan
        //terbaru) berdasarkan cabang.
        Task<Customer> OldCustomer();
        Task<Customer> NewCustomer();

        //Untuk menampilkan 10 data pelanggan yang paling besar belanjanya dalam
        //1 bulan di setiap cabang(berdasarkan akumulasi total belanja).
        Task<IQueryable<TopMostBuyers>> TenMostBuyersPerMonth(int? month);
    }
}
