using ButikAPI.Data;
using ButikAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ButikAPI.Services.Implementation
{
    public class TransactionService : ITransactionService
    {
        private readonly ApplicationDbContext context;

        public TransactionService(ApplicationDbContext context)
        {
            this.context = context;
        }

        ////Untuk menampilkan 10 data pakaian yang paling banyak dibeli dalam 1 bulan
        //di setiap cabang(berdasarkan quantity).
        public async Task<IQueryable<Product>> FiveSalesIncreasePerMonth(int? month)
        {
            var toptenproduct = await ( from p in this.context.Products
                                        join t in this.context.Transactions on p.Id equals t.ProductId
                                        where t.TransactionDate.Month == 12
                                        orderby t.TransactionDate, t.Quantity descending
                                        select p).Take(10).ToListAsync();
            return 
        }

        public async Task<IQueryable<Product>> TenBestSellingProductsPerMonth(int? month)
        {
            if (month == 0 || month == null) month = DateTime.UtcNow.Month;
            var toptenproduct = await (from p in this.context.Products
                                      join t in this.context.Transactions on p.Id equals t.ProductId
                                      where t.TransactionDate.Month == month
                                      orderby t.TransactionDate, t.Quantity descending
                                      select p).Take(10).ToListAsync();
            return toptenproduct.AsQueryable();
        }

        ////Untuk menampilkan data nominal penjualan setiap cabang dalam 1 tahun.
        public async Task<IQueryable<Transaction>> TotalSalesPerYear(DateTime? startDate, DateTime? endDate)
        {
            //var nominalpertahun = await ( from t in this.context.Transactions
            //                              join c in this.context.Customers on t.CustomerId equals c.Id
            //                              join b in this.context.Branches on c.BranchId equals b.Id
            //                              select
            //                              )
            //return 
            throw new NotImplementedException();
        }
    }
}
