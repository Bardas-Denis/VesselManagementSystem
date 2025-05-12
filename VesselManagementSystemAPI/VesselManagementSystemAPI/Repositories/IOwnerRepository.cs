using VesselManagementSystemAPI.Models;

namespace VesselManagementSystemAPI.Repositories
{
    public interface IOwnerRepository
    {
        Task<IEnumerable<Owner>> GetAllAsync(bool includeShips);
        Task<Owner> GetByIdAsync(int id);
        Task AddAsync(Owner owner);
        void Remove(Owner owner);
    }
}
