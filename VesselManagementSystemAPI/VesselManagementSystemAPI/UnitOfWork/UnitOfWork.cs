using VesselApi.UnitOfWork;
using VesselManagementSystemAPI.Data;
using VesselManagementSystemAPI.Repositories;

namespace VesselManagementSystemAPI.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly VesselDbContext _context;

        public IShipRepository Ships { get; }
        public IOwnerRepository Owners { get; }

        public UnitOfWork(
            VesselDbContext context,
            IShipRepository ships,
            IOwnerRepository owners)
        {
            _context = context;
            Ships = ships;
            Owners = owners;
        }

        public async Task<int> CompleteAsync()
        {
            // Save all changes in one transaction
            return await _context.SaveChangesAsync();
        }
    }
}
