namespace ButikAPI.Services.Implementation
{
    using System.Globalization;
    using ButikAPI.Data;
    using ButikAPI.Models;
    using ButikAPI.Models.CustomModels;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Customer Service.
    /// </summary>
    public class CustomerService : ICustomerService
    {
        private readonly ApplicationDbContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerService"/> class.
        /// </summary>
        /// <param name="context">Application Db Context.</param>
        public CustomerService(ApplicationDbContext context)
        {
            this.context = context;
        }

        /// <inheritdoc/>
        public async Task<Customer> CreateCustomer(CustomerRegisterInput input)
        {
            try
            {
                var customer = new Customer();
                if (input != null)
                {
                    customer.Id = Guid.NewGuid();
                    customer.Name = input.Name;
                    customer.Email = input.Email;
                    customer.RegistrationDate = input.RegistrationDate;
                    customer.BranchId = input.BranchId;
                    this.context.Add(customer);
                    await this.context.SaveChangesAsync();
                }

                return await this.context.Customers.Include(e => e.Branch).FirstOrDefaultAsync(e => e.Id.Equals(customer.Id)) ?? new Customer();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        /// <inheritdoc/>
        public async Task<Customer> ModifyCustomer(CustomerModifyInput input)
        {
            try
            {
                var customer = await this.context.Customers.FirstOrDefaultAsync(e => e.Id.Equals(input.Id));

                if (customer != null)
                {
                    customer.Id = input.Id;
                    customer.Name = input.Name;
                    customer.Email = input.Email;
                    customer.RegistrationDate = input.RegistrationDate;
                    customer.BranchId = input.BranchId;

                    this.context.Update(customer);
                    var hasChanges = this.context.ChangeTracker.HasChanges();
                    if (hasChanges)
                    {
                        await this.context.SaveChangesAsync();
                    }
                }

                return await this.context.Customers.Include(e => e.Branch).FirstOrDefaultAsync(e => e.Id.Equals(customer.Id)) ?? new Customer();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        /// <inheritdoc/>
        public async Task<DeleteResponse> DeleteCustomerById(Guid id)
        {
            try
            {
                var customer = await this.context.Customers.FirstOrDefaultAsync(e => e.Id.Equals(id));
                if (customer != null)
                {
                    this.context.Customers.Remove(customer);
                    await this.context.SaveChangesAsync();
                    return new DeleteResponse() { Value = true, Message = "Berhasil Delete Customer" };
                }
                else
                {
                    return new DeleteResponse() { Value = false, Message = "Gagal Delete Customer" };
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        /// <inheritdoc/>
        public async Task<Customer> NewCustomer()
        {
            return await this.context.Customers.Include(e => e.Branch).OrderByDescending(e => e.RegistrationDate).FirstOrDefaultAsync();
        }

        /// <inheritdoc/>
        public async Task<Customer> OldCustomer()
        {
            return await this.context.Customers.Include(e => e.Branch).OrderBy(e => e.RegistrationDate).FirstOrDefaultAsync();
        }

        /// <inheritdoc/>
        public async Task<IQueryable<TopMostBuyers>> TenMostBuyersPerMonth(int? month)
        {
            if (month == 0 || month == null)
            {
                month = DateTime.UtcNow.Month;
            }

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
                                                   TotalSpending = g.Sum(t => t.Quantity * t.Product.Price),
                                               }).OrderBy(e => e.TotalSpending).Take(10).ToListAsync();

            return topCustomersByBranchAndMonth.AsQueryable();
        }
    }
}
