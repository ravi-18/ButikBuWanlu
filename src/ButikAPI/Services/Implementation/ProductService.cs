namespace ButikAPI.Services.Implementation
{
    using System;
    using ButikAPI.Data;
    using ButikAPI.Models;
    using ButikAPI.Models.CustomModels;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Product Service.
    /// </summary>
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductService"/> class.
        /// </summary>
        /// <param name="context">Application Db Context.</param>
        public ProductService(ApplicationDbContext context)
        {
            this.context = context;
        }

        /// <inheritdoc/>
        public async Task<Product> CreateProduct(ProductRegisterInput input)
        {
            try
            {
                var product = new Product();
                product.Id = Guid.NewGuid();
                product.Name = input.Name;
                product.Price = input.Price;

                this.context.Add(product);
                await this.context.SaveChangesAsync();

                return product;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        /// <inheritdoc/>
        public async Task<Product> ModifyProduct(ProductModifyInput input)
        {
            try
            {
                var product = await this.context.Products.FirstOrDefaultAsync(e => e.Id.Equals(input.Id));
                if (product != null)
                {
                    product.Name = input.Name;
                    product.Price = input.Price;

                    this.context.Entry(product).State = EntityState.Modified;
                    await this.context.SaveChangesAsync();
                }

                return product;
            }
            catch (Exception ex) 
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        /// <inheritdoc/>
        public async Task<DeleteResponse> DeleteByProductId(Guid id)
        {
            try
            {
                var product = await this.context.Products.FirstOrDefaultAsync(e => e.Id.Equals(id));
                if (product != null)
                {
                    this.context.Remove(product);
                    await this.context.SaveChangesAsync();
                    return new DeleteResponse() { Value = true, Message = "Berhasil Delete Product" };
                }

                return new DeleteResponse() { Value = false, Message = "Gagal Delete Product" };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        /// <inheritdoc/>
        public async Task<Product> ProductHighestPrice()
        {
            return await this.context.Products.OrderByDescending(e => e.Price).ThenBy(e => e.Name).FirstOrDefaultAsync();
        }

        /// <inheritdoc/>
        public async Task<Product> ProductLowestPrice()
        {
            return await this.context.Products.OrderBy(e => e.Price).ThenBy(e => e.Name).FirstOrDefaultAsync();
        }
    }
}
