using VesselManagementSystemAPI.DTOs;

namespace VesselManagementSystemAPI.Services
{
    public interface IShipService
    {
        Task<IEnumerable<ShipDto>> GetAllAsync();
        Task<IEnumerable<ShipDtoWithDetails>> GetAllWithDetailsAsync();
        Task<ShipDtoWithDetails> GetByIdAsync(int id);
        Task<ShipDtoWithDetails> CreateAsync(CreateShipDto dto);
        Task<ShipDtoWithDetails> CreateWithDetailsAsync(CreateShipWithDetailsDto dto);
        Task UpdateAsync(int id, UpdateShipDto dto);
        Task DeleteAsync(int id);
    }
}
