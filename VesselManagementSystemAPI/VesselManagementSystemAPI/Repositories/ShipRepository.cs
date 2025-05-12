using Microsoft.EntityFrameworkCore;
using VesselManagementSystemAPI.Data;
using VesselManagementSystemAPI.Models;

namespace VesselManagementSystemAPI.Repositories
{
    public class ShipRepository : IShipRepository
    {
        private readonly VesselDbContext _context;
        public ShipRepository(VesselDbContext context) => _context = context;

        public async Task<IEnumerable<Ship>> GetAllAsync(bool includeDetails)
        {
            IQueryable<Ship> query = _context.Ships.AsNoTracking();
            if (includeDetails)
                query = query.Include(s => s.Category).Include(s => s.ShipOwners)
                              .ThenInclude(so => so.Owner);

            return await query.ToListAsync();
        }
          

        public async Task<Ship> GetByIdAsync(int id)
        {
            return await _context.Ships
                          .Include(s => s.Category)
                          .Include(s => s.ShipOwners)
                              .ThenInclude(so => so.Owner)
                          .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task AddAsync(Ship ship) =>
            await _context.Ships.AddAsync(ship);

        public void Remove(Ship ship) => _context.Ships.Remove(ship);
    }
}
