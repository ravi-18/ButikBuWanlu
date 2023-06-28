namespace ButikAPI.Services.Implementation
{
    using ButikAPI.Data;
    using ButikAPI.Models;
    using ButikAPI.Models.CustomModels;
    using GraphQL;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Transaction Service.
    /// </summary>
    public class TransactionService : ITransactionService
    {
        private readonly ApplicationDbContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionService"/> class.
        /// </summary>
        /// <param name="context">Application Db Context.</param>
        public TransactionService(ApplicationDbContext context)
        {
            this.context = context;
        }

        /// <inheritdoc/>
        public async Task<Transaction> CreateTransaction(TransactionRegisterInput input)
        {
            try
            {
                var transaction = new Transaction();
                transaction.Id = Guid.NewGuid();
                transaction.Quantity = input.Quantity;
                transaction.TransactionDate = input.TransactionDate;
                transaction.CustomerId = input.CustomerId;
                transaction.ProductId = input.ProductId;

                this.context.Add(transaction);
                await this.context.SaveChangesAsync();
                return await this.context.Transactions
                    .Include(e => e.Product)
                    .Include(e => e.Customer)
                    .ThenInclude(e => e.Branch)
                    .FirstOrDefaultAsync(e => e.Id.Equals(transaction.Id)) ?? new Transaction();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        /// <inheritdoc/>
        public async Task<Transaction> ModifyTransaction(TransactionModifyInput input)
        {
            try
            {
                var transaction = await this.context.Transactions.FirstOrDefaultAsync(e => e.Id.Equals(input.Id));
                if (transaction != null)
                {
                    transaction.Quantity = input.Quantity;
                    transaction.TransactionDate = input.TransactionDate;
                    transaction.CustomerId = input.CustomerId;
                    transaction.ProductId = input.ProductId;

                    this.context.Update(transaction);
                    var hasChange = this.context.ChangeTracker.HasChanges();
                    if (hasChange)
                    {
                        await this.context.SaveChangesAsync();
                    }
                }

                return await this.context.Transactions
                    .Include(e => e.Product)
                    .Include(e => e.Customer)
                    .ThenInclude(e => e.Branch)
                    .FirstOrDefaultAsync(e => e.Id.Equals(transaction.Id)) ?? new Transaction();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        /// <inheritdoc/>
        public async Task<DeleteResponse> DeleteByTransactionId(Guid id)
        {
            try
            {
                var transcation = await this.context.Transactions.FirstOrDefaultAsync(e => e.Id.Equals(id));
                if (transcation != null)
                {
                    this.context.Remove(transcation);
                    await this.context.SaveChangesAsync();

                    return new DeleteResponse() { Value = true, Message = "Berhasil Delete Transaction" };
                }

                return new DeleteResponse() { Value = false, Message = "Gagal Delete Transaction" };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        // Untuk menampilkan 5 data pakaian yang mengalami peningkatan tertinggi
        // penjualan dalam bulan ini dibandingkan bulan sebelumnya. Dengan cara
        // membandingkan quantity yg terjual bulan ini dengan quantity yang terjual
        // bulan sebelumnya.

        /// <inheritdoc/>
        public async Task<IQueryable<TopFiveProduct>> FiveSalesIncreasePerMonth()
        {
            try
            {

                DateTime currentDate = DateTime.Now;
                DateTime currentMonthStartDate = new DateTime(currentDate.Year, currentDate.Month, 1);
                DateTime previousMonthStartDate = currentMonthStartDate.AddMonths(-1);
                DateTime previousMonthEndDate = currentMonthStartDate.AddDays(-1);

                var previousTransactions = await this.context.Transactions.Where(e => e.TransactionDate >= previousMonthStartDate && e.TransactionDate <= previousMonthEndDate).ToListAsync();

                var currentTransactions = await this.context.Transactions.Where(e => e.TransactionDate >= currentMonthStartDate && e.TransactionDate <= currentDate).ToListAsync();

                var top5Products = (from t1 in previousTransactions
                                    join t2 in currentTransactions on t1.ProductId equals t2.ProductId
                                    where
                                        t1.TransactionDate >= previousMonthStartDate &&
                                        t1.TransactionDate <= previousMonthEndDate &&
                                        t2.TransactionDate >= currentMonthStartDate &&
                                        t2.TransactionDate <= currentDate
                                    group new { t1.ProductId, Quantity1 = t1.Quantity, Quantity2 = t2.Quantity } by t1.ProductId into g
                                    let previousMonthQuantity = g.Sum(x => x.Quantity1)
                                    let currentMonthQuantity = g.Sum(x => x.Quantity2)
                                    select new GetDataTopFive
                                    {
                                        ProductId = g.Key,
                                        QuantityIncrease = currentMonthQuantity - previousMonthQuantity,
                                    }).OrderByDescending(x => x.QuantityIncrease).Take(5);

                var products = await this.context.Products.Where(e => top5Products.Select(s => s.ProductId).Contains(e.Id)).ToListAsync();
                
                // Retrieve the actual product details
                var result = (from p in products
                                join t in top5Products on p.Id equals t.ProductId.Value
                                select new TopFiveProduct
                                {
                                    Id = p.Id,
                                    Name = p.Name,
                                    Price = p.Price,
                                    QuantityIncrease = t.QuantityIncrease.Value,
                                }).OrderByDescending(e => e.QuantityIncrease).ThenBy(e => e.Price).ThenBy(e => e.Name);//.ToListAsync();
                return result.AsQueryable();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        /// <inheritdoc/>
        public async Task<IQueryable<Product>> TenBestSellingProductsPerMonth(int? month)
        {
            if (month == 0 || month == null)
            {
                month = DateTime.UtcNow.Month;
            }

            var toptenproduct = await (from p in this.context.Products
                                      join t in this.context.Transactions on p.Id equals t.ProductId
                                      where t.TransactionDate.Month == month
                                      orderby t.TransactionDate, t.Quantity descending
                                      select p).Take(10).ToListAsync();
            return toptenproduct.AsQueryable();
        }

        // Untuk menampilkan data nominal penjualan setiap cabang dalam 1 tahun.
        // Sempat error karena limitasi integer, dan solve ketika di parse ke long.

        /// <inheritdoc/>
        public async Task<IQueryable<TotalSalesPerYearCustomModel>> TotalSalesPerYear(int? year)
        {
            if (year == 0 || year == null)
            {
                year = DateTime.UtcNow.Year;
            }

            var nominalpertahun = await (from t in this.context.Transactions
                                         join c in this.context.Customers on t.CustomerId equals c.Id
                                         join p in this.context.Products on t.ProductId equals p.Id
                                         join b in this.context.Branches on c.BranchId equals b.Id
                                         where t.TransactionDate.Year == year
                                         group new { p.Price, t.Quantity } by b.Name into g
                                         select new TotalSalesPerYearCustomModel
                                         {
                                             BranchName = g.Key,
                                             TotalSales = g.Sum(x => (long)x.Price * (long)x.Quantity),
                                         }).OrderBy(e => e.TotalSales).ThenBy(e => e.BranchName).ToListAsync();
            return nominalpertahun.AsQueryable();
        }
    }
}
