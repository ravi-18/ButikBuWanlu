// <copyright file="BranchService.cs" company="ButikBuWnalu">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ButikAPI.Services.Implementation
{
    using ButikAPI.Data;
    using ButikAPI.Models;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Service Branch.
    /// </summary>
    public class BranchService : IBranchService
    {
        private readonly ApplicationDbContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="BranchService"/> class.
        /// </summary>
        /// <param name="applicationDbContext">This Application DB Context. </param>
        public BranchService(ApplicationDbContext applicationDbContext)
        {
            this.context = applicationDbContext;
        }

        /// <inheritdoc/>
        public async Task<Branch> Create(Branch branch)
        {
            try
            {
                if (branch != null)
                {
                    branch.Id = Guid.NewGuid();
                    this.context.Add(branch);
                    await this.context.SaveChangesAsync();
                }

                return branch;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        /// <inheritdoc/>
        public async Task<bool> DeleteById(Guid id)
        {
            try
            {
                var branch = await this.context.Branches.FirstOrDefaultAsync(e => e.Id.Equals(id));
                if (branch != null)
                {
                    this.context.Branches.Remove(branch);
                    await this.context.SaveChangesAsync();
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        /// <inheritdoc/>
        public async Task<Branch> GetById(Guid id)
        {
            return await this.context.Branches.FirstOrDefaultAsync(e => e.Id.Equals(id));
        }

        /// <inheritdoc/>
        public async Task<IQueryable<Branch>> GetListAsync()
        {
            return this.context.Branches;
        }

        /// <inheritdoc/>
        public async Task<Branch> Update(Branch newBranch)
        {
            try
            {
                var oldBranch = await this.context.Branches.FirstOrDefaultAsync(e => e.Id.Equals(newBranch.Id));
                if (oldBranch != null)
                {
                    this.context.Branches.Update(newBranch);
                    await this.context.SaveChangesAsync();
                    return newBranch;
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
    }
}
