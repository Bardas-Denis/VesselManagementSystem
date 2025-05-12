using VesselManagementSystemAPI.DTOs;

namespace VesselManagementSystemAPI.Services
{
    public interface IOwnerService
    {
        //Task<IEnumerable<OwnerDto>> GetAllAsync();
        //Task<OwnerDto> GetByIdAsync(int id);
        //Task<OwnerDto> CreateAsync(CreateOwnerDto dto);
        //Task UpdateAsync(int id, UpdateOwnerDto dto);
        Task DeleteAsync(int id);
    }
}
