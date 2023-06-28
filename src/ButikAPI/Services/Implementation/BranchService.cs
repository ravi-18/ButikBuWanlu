// <copyright file="BranchService.cs" company="ButikBuWnalu">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ButikAPI.Services.Implementation
{
    using ButikAPI.Data;
    using ButikAPI.Models;
    using ButikAPI.Models.CustomModels;
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
        public async Task<Branch> Create(BranchRegisterInput input)
        {
            try
            {
                var branch = new Branch();
                if (!string.IsNullOrEmpty(input.Name))
                {
                    branch.Id = Guid.NewGuid();
                    branch.Name = input.Name;
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
        public async Task<Branch> Modify(BranchModifyInput input)
        {
            try
            {
                var branch = await this.context.Branches.FirstOrDefaultAsync(e => e.Id.Equals(input.Id));
                if (branch != null)
                {
                    branch.Name = input.Name;

                    this.context.Update(branch);
                    var hasChanges = this.context.ChangeTracker.HasChanges();
                    if (hasChanges)
                    {
                        await this.context.SaveChangesAsync();
                    }
                }

                return branch;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        /// <inheritdoc/>
        public async Task<DeleteResponse> DeleteById(Guid id)
        {
            try
            {
                var branch = await this.context.Branches.FirstOrDefaultAsync(e => e.Id.Equals(id));
                if (branch != null)
                {
                    this.context.Branches.Remove(branch);
                    await this.context.SaveChangesAsync();
                    return new DeleteResponse() { Value = true, Message = "Berhasil Delete Branch", };
                }
                else
                {
                    return new DeleteResponse() { Value = false, Message = "Gagal Delete Branch", };
                }
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
            return this.context.Branches.OrderBy(e => e.Name);
        }

        ///// <inheritdoc/>
        // public async Task<Branch> Update(BranchModifyInput input)
        // {
        //    try
        //    {
        //        var branch = await this.context.Branches.FirstOrDefaultAsync(e => e.Id.Equals(input.Id));
        //        if (branch != null)
        //        {
        //            branch.Name = input.Name;
        //            this.context.Update(branch);
        //            var hasChange = this.context.ChangeTracker.HasChanges();
        //            if (hasChange)
        //            {
        //                await this.context.SaveChangesAsync();
        //            }
        //            return branch;
        //        }
        //        return null;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message, ex.InnerException);
        //    }
        // }
    }
}
