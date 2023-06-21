using ButikAPI.Models;

namespace ButikAPI.Services
{
    public interface IBranchService
    {
        Task<IQueryable<Branch>> GetListAsync();
        Task<Branch> GetById(Guid id);
        Task<Branch> Create(Branch branch);
        Task<Branch> Update(Branch branch);
        Task<bool> DeleteById(Guid id);
    }
}
