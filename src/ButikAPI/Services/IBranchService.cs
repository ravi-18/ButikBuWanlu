namespace ButikAPI.Services
{
using ButikAPI.Models;
using ButikAPI.Models.CustomModels;

    /// <summary>
    /// IBranch Service.
    /// </summary>
    public interface IBranchService
    {
        /// <summary>
        /// Get List Async.
        /// </summary>
        /// <returns>IQueryable Branch.</returns>
        Task<IQueryable<Branch>> GetListAsync();

        /// <summary>
        /// Get By Id.
        /// </summary>
        /// <param name="id">Bracnh Id.</param>
        /// <returns>Branch.</returns>
        Task<Branch> GetById(Guid id);

        /// <summary>
        /// Create.
        /// </summary>
        /// <param name="input">Input Branch.</param>
        /// <returns>Branch.</returns>
        Task<Branch> Create(BranchRegisterInput input);

        /// <summary>
        /// MOdify.
        /// </summary>
        /// <param name="input">Input Branch.</param>
        /// <returns>Branch.</returns>
        Task<Branch> Modify(BranchModifyInput input);

        // Task<Branch> Update(BranchModifyInput branch);

        /// <summary>
        /// Delete By Id.
        /// </summary>
        /// <param name="id">Branch Id.</param>
        /// <returns>Delete Response.</returns>
        Task<DeleteResponse> DeleteById(Guid id);
    }
}
