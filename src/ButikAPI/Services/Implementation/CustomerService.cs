namespace ButikAPI.Services.Implementation
{
using ButikAPI.Data;
using ButikAPI.Models;
    using ButikAPI.Models.CustomModels;
    using Microsoft.EntityFrameworkCore;
    using System.Globalization;

    public class CustomerService : ICustomerService
    {
        private readonly ApplicationDbContext context;

        public CustomerService(ApplicationDbContext context)
        {
            context = context;
        }

        /// <inheritdoc/>
        public async Task<Customer> NewCustomer()
        {
            return await this.context.Customers.OrderByDescending(e => e.RegistrationDate).FirstOrDefaultAsync();
        }

        public async Task<Customer> OldCustomer()
        {
            return await this.context.Customers.OrderBy(e => e.RegistrationDate).FirstOrDefaultAsync();
        }

        public async Task<IQueryable<TopMostBuyers>> TenMostBuyersPerMonth(int? month)
        {
            if (month == 0 || month == null) month = DateTime.UtcNow.Month;

            var topCustomersByBranchAndMonth = await (from t in this.context.Transactions
                                               join c in this.context.Customers on t.CustomerId equals c.Id
                                               join b in this.context.Branches on c.BranchId equals b.Id
                                               where t.TransactionDate.Month == month 
                                               group t by new { BranchName = b.Name, t.TransactionDate.Month, CustomerName = c.Name } into g
                                               orderby g.Sum(t => t.Quantity * t.Product.Price) descending
                                               select new TopMostBuyers
                                               {
                                                   BranchName = g.Key.BranchName,
                                                   Month = DateTimeFormatInfo.CurrentInfo.GetAbbreviatedMonthName(g.Key.Month),
                                                   CustomerName = g.Key.CustomerName,
                                                   TotalSpending = g.Sum(t => t.Quantity * t.Product.Price)
                                               }).Take(10).ToListAsync();

            return topCustomersByBranchAndMonth.AsQueryable();
        }
    }
}
