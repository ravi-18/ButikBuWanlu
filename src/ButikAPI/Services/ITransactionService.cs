using ButikAPI.Models;
using Microsoft.Extensions.Hosting;
using System.Runtime.ConstrainedExecution;
using static HotChocolate.ErrorCodes;

namespace ButikAPI.Services
{
    public interface ITransactionService
    {
        //Untuk menampilkan 10 data pakaian yang paling banyak dibeli dalam 1 bulan
        //di setiap cabang(berdasarkan quantity).
        Task<IQueryable<Product>> TenBestSellingProductsPerMonth(int? month);

        //Untuk menampilkan data nominal penjualan setiap cabang dalam 1 tahun.
        Task<IQueryable<Transaction>> TotalSalesPerYear(DateTime? startDate, DateTime? endDate);
        //Untuk menampilkan 5 data pakaian yang mengalami peningkatan tertinggi
        //penjualan dalam bulan ini dibandingkan bulan sebelumnya. Dengan cara
        //membandingkan quantity yg terjual bulan ini dengan quantity yang terjual
        //bulan sebelumnya.
        Task<IQueryable<Product>> FiveSalesIncreasePerMonth(DateTime? startDate, DateTime? endDate);
    }
}
