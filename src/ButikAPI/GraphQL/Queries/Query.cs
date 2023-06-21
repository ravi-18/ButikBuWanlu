using ButikAPI.Data;
using ButikAPI.Models;
using ButikAPI.Models.CustomModels;
using ButikAPI.Services;
using GraphQL;

namespace ButikAPI.GraphQL.Queries
{
    public class Query
    {
        /// <summary>
        /// Gets get Branch.
        /// </summary>
        //[UseProjection]
        [UsePaging]
        [UseFiltering]
        [UseSorting]
        [GraphQLMetadata("branch")]
        public IQueryable<Branch> Branch([Service] ApplicationDbContext context) => context.Branches.AsQueryable();

        [UsePaging]
        [UseFiltering]
        [UseSorting]
        [GraphQLMetadata("customer")]
        public IQueryable<Customer> Customer([Service] ApplicationDbContext context) => context.Customers.AsQueryable();

        [UsePaging]
        [UseFiltering]
        [UseSorting]
        [GraphQLMetadata("transcation")]
        public IQueryable<Transaction> Transaction([Service] ApplicationDbContext context) => context.Transactions.AsQueryable();

        [UsePaging]
        [UseFiltering]
        [UseSorting]
        [GraphQLMetadata("product")]
        public IQueryable<Product> Product([Service] ApplicationDbContext context) => context.Products.AsQueryable();

        /// <summary>
        /// Gets get Transaction.
        /// </summary>
        [UseFiltering]
        [UseSorting]
        [GraphQLMetadata("tenBestSelling")]
        public Task<IQueryable<Product>> TenBestSeller(
            int? month,
            [Service]
            ITransactionService service
            )
        {
            return service.TenBestSellingProductsPerMonth(month);
        }

        [GraphQLMetadata("productHighestPrice")]
        public async Task<Product> ProductHighestPrice(
            [Service]
            IProductService service
            )
        {
            return await service.ProductHighestPrice();
        }


        [GraphQLMetadata("productLowestPrice")]
        public async Task<Product> ProductLowestPrice(
            [Service]
            IProductService service
            )
        {
            return await service.ProductLowestPrice();
        }

        [GraphQLMetadata("tenBestSellingProductsPerMonth")]
        public async Task<IQueryable<Product>> TenBestSellingProductsPerMonth(int? month,
            [Service]
            ITransactionService service
            )
        {
            return await service.TenBestSellingProductsPerMonth(month);
        }

        [GraphQLMetadata("totalSalesPerYear")]
        public async Task<IQueryable<TotalSalesPerYearCustomModel>> TotalSalesPerYear(int? year,
            [Service]
            ITransactionService service)
        {
            return await service.TotalSalesPerYear(year);
        }

        [GraphQLMetadata("fiveSalesIncreasePerMonth")]
        public async Task<IQueryable<TopFiveProduct>> FiveSalesIncreasePerMonth(
            [Service]
            ITransactionService service)
        {
            return await service.FiveSalesIncreasePerMonth();
        }

        [GraphQLMetadata("newCustomer")]
        public async Task<Customer> NewCustomer(
            [Service]
            ICustomerService service)
        {
            return await service.NewCustomer();
        }

        [GraphQLMetadata("oldCustomer")]
        public async Task<Customer> OldCustomer(
            [Service]
            ICustomerService service)
        {
            return await service.OldCustomer();
        }

        [GraphQLMetadata("tenMostBuyersPerMonth")]
        Task<IQueryable<TopMostBuyers>> TenMostBuyersPerMonth(int? month,
            [Service]
            ICustomerService service)
        {
            return service.TenMostBuyersPerMonth(month);
        }

    }
}
