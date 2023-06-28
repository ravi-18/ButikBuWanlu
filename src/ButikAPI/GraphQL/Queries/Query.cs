using ButikAPI.Data;
using ButikAPI.Models;
using ButikAPI.Models.CustomModels;
using ButikAPI.Services;
using GraphQL;

namespace ButikAPI.GraphQL.Queries
{
    /// <summary>
    /// Query.
    /// </summary>
    public class Query
    {
        /// <summary>
        /// Branch.
        /// </summary>
        /// <param name="context">Application Db Context.</param>
        /// <returns>IQueryable Branch.</returns>
        [UsePaging]
        [UseFiltering]
        [UseSorting]
        [GraphQLMetadata("branch")]
        public IQueryable<Branch> Branch([Service] ApplicationDbContext context) => context.Branches.OrderBy(e => e.Name).AsQueryable();

        /// <summary>
        /// Customer.
        /// </summary>
        /// <param name="context">Application Db Context.</param>
        /// <returns>IQueryable Customer.</returns>
        [UsePaging]
        [UseFiltering]
        [UseSorting]
        [GraphQLMetadata("customer")]
        public IQueryable<Customer> Customer([Service] ApplicationDbContext context) => context.Customers.OrderBy(e => e.RegistrationDate).ThenBy(e => e.Name).AsQueryable();

        /// <summary>
        /// Transaction.
        /// </summary>
        /// <param name="context">Application Db Context.</param>
        /// <returns>IQueryable Transaction.</returns>
        [UsePaging]
        [UseFiltering]
        [UseSorting]
        [GraphQLMetadata("transcation")]
        public IQueryable<Transaction> Transaction([Service] ApplicationDbContext context) => context.Transactions.OrderBy(e => e.TransactionDate).ThenBy(e => e.Quantity).AsQueryable();

        /// <summary>
        /// Product.
        /// </summary>
        /// <param name="context">Application Db Contxt.</param>
        /// <returns>IQueryable Product.</returns>
        [UsePaging]
        [UseFiltering]
        [UseSorting]
        [GraphQLMetadata("product")]
        public IQueryable<Product> Product([Service] ApplicationDbContext context) => context.Products.OrderBy(e => e.Name).ThenBy(e => e.Price).AsQueryable();

        /// <summary>
        /// Ten Best Seller.
        /// </summary>
        /// <param name="month">Month.</param>
        /// <param name="service">ITranasction Service.</param>
        /// <returns>IQueryable Product.</returns>
        [UseFiltering]
        [UseSorting]
        [GraphQLMetadata("tenBestSelling")]
        public Task<IQueryable<Product>> TenBestSeller(
            int? month,
            [Service]
            ITransactionService service)
        {
            return service.TenBestSellingProductsPerMonth(month);
        }

        /// <summary>
        /// Product Highest Price.
        /// </summary>
        /// <param name="service">IProduct Service.</param>
        /// <returns>Product.</returns>
        [GraphQLMetadata("productHighestPrice")]
        public async Task<Product> ProductHighestPrice(
            [Service]
            IProductService service)
        {
            return await service.ProductHighestPrice();
        }

        /// <summary>
        /// Product Lowest Price.
        /// </summary>
        /// <param name="service">IProduct Service.</param>
        /// <returns>Product.</returns>
        [GraphQLMetadata("productLowestPrice")]
        public async Task<Product> ProductLowestPrice(
            [Service]
            IProductService service)
        {
            return await service.ProductLowestPrice();
        }

        /// <summary>
        /// Ten Best Selling Products Month.
        /// </summary>
        /// <param name="month">Month.</param>
        /// <param name="service">ITransaction Service.</param>
        /// <returns>IQueryable Product.</returns>
        [GraphQLMetadata("tenBestSellingProductsPerMonth")]
        public async Task<IQueryable<Product>> TenBestSellingProductsPerMonth(
            int? month,
            [Service]
            ITransactionService service)
        {
            return await service.TenBestSellingProductsPerMonth(month);
        }

        /// <summary>
        /// Total Sales Per Year.
        /// </summary>
        /// <param name="year">Year.</param>
        /// <param name="service">ITransaction Service.</param>
        /// <returns>IQurtyable Total Sales Per Year Custom Model.</returns>
        [GraphQLMetadata("totalSalesPerYear")]
        public async Task<IQueryable<TotalSalesPerYearCustomModel>> TotalSalesPerYear(
            int? year,
            [Service]
            ITransactionService service)
        {
            return await service.TotalSalesPerYear(year);
        }

        /// <summary>
        /// Five Sales Increase Per Month.
        /// </summary>
        /// <param name="service">ITransaction Service.</param>
        /// <returns>IQueryable Top Five Product.</returns>
        [GraphQLMetadata("fiveSalesIncreasePerMonth")]
        public async Task<IQueryable<TopFiveProduct>> FiveSalesIncreasePerMonth(
            [Service]
            ITransactionService service)
        {
            return await service.FiveSalesIncreasePerMonth();
        }

        /// <summary>
        /// New Customer.
        /// </summary>
        /// <param name="service">ICustomer Service.</param>
        /// <returns>Customer.</returns>
        [GraphQLMetadata("newCustomer")]
        public async Task<Customer> NewCustomer(
            [Service]
            ICustomerService service)
        {
            return await service.NewCustomer();
        }

        /// <summary>
        /// Old Customer.
        /// </summary>
        /// <param name="service">ICustomer Service.</param>
        /// <returns>Customer.</returns>
        [GraphQLMetadata("oldCustomer")]
        public async Task<Customer> OldCustomer(
            [Service]
            ICustomerService service)
        {
            return await service.OldCustomer();
        }

        /// <summary>
        /// Ten Most Buyers Per Month.
        /// </summary>
        /// <param name="month">Month.</param>
        /// <param name="service">ICustomer Service.</param>
        /// <returns>IQueryable Top Most Buyers.</returns>
        [GraphQLMetadata("tenMostBuyersPerMonth")]
        public Task<IQueryable<TopMostBuyers>> TenMostBuyersPerMonth(
            int? month,
            [Service]
            ICustomerService service)
        {
            return service.TenMostBuyersPerMonth(month);
        }
    }
}
