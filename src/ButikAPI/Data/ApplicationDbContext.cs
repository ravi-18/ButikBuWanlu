namespace ButikAPI.Data
{
    using ButikAPI.Models;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Application Db Context.
    /// </summary>
    public class ApplicationDbContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationDbContext"/> class.
        /// </summary>
        /// <param name="options">Db Context Optiobs.</param>
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Gets or sets branchs.
        /// </summary>
        public DbSet<Branch> Branches { get; set; }

        /// <summary>
        /// Gets or sets customers.
        /// </summary>
        public DbSet<Customer> Customers { get; set; }

        /// <summary>
        /// Gets or sets products.
        /// </summary>
        public DbSet<Product> Products { get; set; }

        /// <summary>
        /// Gets or sets transactions.
        /// </summary>
        public DbSet<Transaction> Transactions { get; set; }

        /// <inheritdoc/>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .HasOne(e => e.Branch)
                .WithMany(e => e.Customers)
                .HasForeignKey(e => e.BranchId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Transaction>()
                .HasOne(e => e.Customer)
                .WithMany(e => e.Transactions)
                .HasForeignKey(e => e.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Transaction>()
                .HasOne(e => e.Product)
                .WithMany(e => e.Transactions)
                .HasForeignKey(e => e.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
    }
}
