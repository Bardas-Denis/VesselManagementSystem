using VesselManagementSystemAPI.Repositories;

namespace VesselApi.UnitOfWork
{
    public interface IUnitOfWork
    {
        IShipRepository Ships { get; }
        IOwnerRepository Owners { get; }

        /// <summary>
        /// Commits all changes made through the repositories in one transaction.
        /// </summary>
        /// <returns>Number of state entries written to the database.</returns>
        Task<int> CompleteAsync();
    }
}
