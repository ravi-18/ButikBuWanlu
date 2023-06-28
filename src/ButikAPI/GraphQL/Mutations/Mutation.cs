namespace ButikAPI.GraphQL.Mutations
{
    using ButikAPI.Models;
    using ButikAPI.Models.CustomModels;
    using ButikAPI.Services;
    using GraphQL;

    /// <summary>
    /// Mutation.
    /// </summary>
    public class Mutation
    {
        /// <summary>
        /// Create Branch.
        /// </summary>
        /// <param name="input">Branch Register Input.</param>
        /// <param name="service">IBranch Service.</param>
        /// <returns>Branch.</returns>
        public Task<Branch> CreateBranch(
            BranchRegisterInput input,
            [Service]
            IBranchService service)
        {
            return service.Create(input);
        }

        /// <summary>
        /// Modify Branch.
        /// </summary>
        /// <param name="input">Branch Modify Input.</param>
        /// <param name="service">IBranch Service.</param>
        /// <returns>Branch.</returns>
        public Task<Branch> ModifyBranch(
            BranchModifyInput input,
            [Service]
            IBranchService service)
        {
            return service.Modify(input);
        }

        /// <summary>
        /// Delete Branch.
        /// </summary>
        /// <param name="id">Branch Id.</param>
        /// <param name="service">IBranch Service.</param>
        /// <returns>Delete Response.</returns>
        public Task<DeleteResponse> DeleteBranch(
            Guid id,
            [Service]
            IBranchService service)
        {
            return service.DeleteById(id);
        }

        /// <summary>
        /// Create Customer.
        /// </summary>
        /// <param name="input">Customer Register Input.</param>
        /// <param name="service">ICustomer Service.</param>
        /// <returns>Customer.</returns>
        public Task<Customer> CreateCustomer(
            CustomerRegisterInput input,
            [Service]
            ICustomerService service)
        {
            return service.CreateCustomer(input);
        }

        /// <summary>
        /// Modify Customer.
        /// </summary>
        /// <param name="input">Customer Modify Input.</param>
        /// <param name="service">ICustomer Service.</param>
        /// <returns>Customer.</returns>
        public Task<Customer> ModifyCustomer(
            CustomerModifyInput input,
            [Service]
            ICustomerService service)
        {
            return service.ModifyCustomer(input);
        }

        /// <summary>
        /// Delete Customer.
        /// </summary>
        /// <param name="id">CustomerId.</param>
        /// <param name="service">ICustomer Service.</param>
        /// <returns>Delete Response.</returns>
        public async Task<DeleteResponse> DeleteCustomer(Guid id, [Service] ICustomerService service)
        {
            return await service.DeleteCustomerById(id);
        }

        /// <summary>
        /// Create Product.
        /// </summary>
        /// <param name="input">Product Register Input.</param>
        /// <param name="service">IProduct Service.</param>
        /// <returns>Product.</returns>
        public async Task<Product> CreateProduct(
            ProductRegisterInput input,
            [Service] IProductService service)
        {
            return await service.CreateProduct(input);
        }

        /// <summary>
        /// Modify Product.
        /// </summary>
        /// <param name="input">Product Modify Input.</param>
        /// <param name="service">IProduct Service.</param>
        /// <returns>Product.</returns>
        public async Task<Product> ModifyProduct(
            ProductModifyInput input,
            [Service] IProductService service)
        {
            return await service.ModifyProduct(input);
        }

        /// <summary>
        /// Delete Product.
        /// </summary>
        /// <param name="id">ProductId.</param>
        /// <param name="service">IProduct Service.</param>
        /// <returns>Delete Response.</returns>
        public async Task<DeleteResponse> DeleteProduct(
            Guid id,
            [Service] IProductService service)
        {
            return await service.DeleteByProductId(id);
        }

        /// <summary>
        /// Create Transaction.
        /// </summary>
        /// <param name="input">Transaction Register Input.</param>
        /// <param name="service">ITransaction Input.</param>
        /// <returns>Transaction.</returns>
        public async Task<Transaction> CreateTransaction(
            TransactionRegisterInput input,
            [Service] ITransactionService service)
        {
            return await service.CreateTransaction(input);
        }

        /// <summary>
        /// Modify Transaction.
        /// </summary>
        /// <param name="input">Transaction Modify Input.</param>
        /// <param name="service">ITransaction Service.</param>
        /// <returns>Transaction.</returns>
        public async Task<Transaction> ModifyTransaction(
            TransactionModifyInput input,
            [Service] ITransactionService service)
        {
            return await service.ModifyTransaction(input);
        }

        /// <summary>
        /// Delete Transaction.
        /// </summary>
        /// <param name="id">TransactionId.</param>
        /// <param name="service">ITransaction Service.</param>
        /// <returns>Delete Response.</returns>
        public async Task<DeleteResponse> DeleteTransaction(
            Guid id,
            [Service] ITransactionService service)
        {
            return await service.DeleteByTransactionId(id);
        }
    }
}
