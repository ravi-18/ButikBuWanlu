using ButikAPI.Data;
using ButikAPI.Models;
using ButikAPI.Models.CustomModels;
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

        //Untuk menampilkan 5 data pakaian yang mengalami peningkatan tertinggi
        //penjualan dalam bulan ini dibandingkan bulan sebelumnya. Dengan cara
        //membandingkan quantity yg terjual bulan ini dengan quantity yang terjual
        //bulan sebelumnya.
        public async Task<IQueryable<TopFiveProduct>> FiveSalesIncreasePerMonth()
        {
            DateTime currentDate = DateTime.Now;
            DateTime currentMonthStartDate = new DateTime(currentDate.Year, currentDate.Month, 1);
            DateTime previousMonthStartDate = currentMonthStartDate.AddMonths(-1);
            DateTime previousMonthEndDate = currentMonthStartDate.AddDays(-1);

            var top5Products = (from t1 in this.context.Transactions
                                 join t2 in this.context.Transactions on t1.ProductId equals t2.ProductId
                                 where 
                                 t1.TransactionDate >= previousMonthStartDate && 
                                 t1.TransactionDate <= previousMonthEndDate && 
                                 t2.TransactionDate >= currentMonthStartDate && 
                                 t2.TransactionDate <= currentDate
                                 group new { t1.ProductId, Quantity1 = t1.Quantity, Quantity2 = t2.Quantity } by t1.ProductId into g
                                 let previousMonthQuantity = g.Sum(x => x.Quantity1)
                                 let currentMonthQuantity = g.Sum(x => x.Quantity2)
                                 select new
                                 {
                                     ProductId = g.Key,
                                     QuantityIncrease = currentMonthQuantity - previousMonthQuantity
                                 }).OrderByDescending(x => x.QuantityIncrease).Take(5);

            // Retrieve the actual product details
            var products = await (from p in this.context.Products
                           join t in top5Products on p.Id equals t.ProductId
                           select new TopFiveProduct
                           {
                               Id = p.Id,
                               Name = p.Name,
                               Price = p.Price,
                               QuantityIncrease = t.QuantityIncrease
                           }).ToListAsync();
            return products.AsQueryable();
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
        public async Task<IQueryable<TotalSalesPerYearCustomModel>> TotalSalesPerYear(int? year)
        {
            if(year == 0 || year == null) year = DateTime.UtcNow.Year;
            var nominalpertahun = await (from t in this.context.Transactions
                                         join c in this.context.Customers on t.CustomerId equals c.Id
                                         join p in this.context.Products on t.ProductId equals p.Id
                                         join b in this.context.Branches on c.BranchId equals b.Id
                                         where t.TransactionDate.Year == year
                                         group new { p.Price, t.Quantity } by b.Name into g
                                         select new TotalSalesPerYearCustomModel
                                         {
                                             BranchName = g.Key,
                                             TotalSales = g.Sum(x => x.Price * x.Quantity)
                                         }
                                         ).ToListAsync();
            return nominalpertahun.AsQueryable();
        }
    }
}
