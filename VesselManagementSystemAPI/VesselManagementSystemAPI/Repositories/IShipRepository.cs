using VesselManagementSystemAPI.Models;

namespace VesselManagementSystemAPI.Repositories
{
    public interface IShipRepository
    {
        Task<IEnumerable<Ship>> GetAllAsync(bool includeDetails);
        Task<Ship> GetByIdAsync(int id);
        Task AddAsync(Ship ship);
        void Remove(Ship ship);
    }
}
