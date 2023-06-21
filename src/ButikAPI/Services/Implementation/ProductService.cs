using ButikAPI.Data;
using ButikAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ButikAPI.Services.Implementation
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext context;

        public ProductService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<Product> ProductHighestPrice()
        {
            return await this.context.Products.OrderByDescending(e => e.Price).FirstOrDefaultAsync();
        }

        public async Task<Product> ProductLowestPrice()
        {
            return await this.context.Products.OrderBy(e => e.Price).FirstOrDefaultAsync();
        }
    }
}
