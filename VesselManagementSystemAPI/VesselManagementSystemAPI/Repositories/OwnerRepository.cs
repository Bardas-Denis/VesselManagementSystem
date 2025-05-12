using Microsoft.EntityFrameworkCore;
using VesselManagementSystemAPI.Data;
using VesselManagementSystemAPI.Models;

namespace VesselManagementSystemAPI.Repositories
{
    public class OwnerRepository : IOwnerRepository
    {
        private readonly VesselDbContext _context;
        public OwnerRepository(VesselDbContext context) => _context = context;

        public async Task<IEnumerable<Owner>> GetAllAsync(bool includeShips = false)
        {
            IQueryable<Owner> query = _context.Owners;
            if (includeShips)
                query = query.Include(o => o.ShipOwners).ThenInclude(so => so.Ship);

            return await query.ToListAsync();
        }
        public async Task<Owner> GetByIdAsync(int id) =>
            await _context.Owners
                          .Include(o => o.ShipOwners)
                              .ThenInclude(so => so.Ship)
                          .FirstOrDefaultAsync(o => o.Id == id);

        public async Task AddAsync(Owner owner) =>
            await _context.Owners.AddAsync(owner);

        public void Remove(Owner owner) => _context.Owners.Remove(owner);
    }
}
