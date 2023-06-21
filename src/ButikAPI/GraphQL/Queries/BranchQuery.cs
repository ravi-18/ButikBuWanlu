using ButikAPI.Data;
using ButikAPI.Models;

namespace ButikAPI.GraphQL.Queries
{
    public class BranchQuery
    {
        private readonly ApplicationDbContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="BranchQuery"/> class.
        /// </summary>
        /// <param name="context">Application db context.</param>
        public BranchQuery(ApplicationDbContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Gets get Branch.
        /// </summary>
        public IQueryable<Branch> GetBranch =>
            context.Branches.AsQueryable();
    }
}
