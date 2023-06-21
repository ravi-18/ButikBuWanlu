namespace ButikAPI.Services.Implementation
{
using ButikAPI.Data;
using ButikAPI.Models;
    using Microsoft.EntityFrameworkCore;

    public class CustomerService : ICustomerService
    {
        private readonly ApplicationDbContext _context;

        public CustomerService(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <inheritdoc/>
        public async Task<Customer> NewCustomer()
        {
            return await this._context.Customers.OrderByDescending(e => e.RegistrationDate).FirstOrDefaultAsync();
        }

        public Task<Customer> OldCustomer()
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<Customer>> TenMostBuyersPerMonth()
        {
            throw new NotImplementedException();
        }
    }
}
