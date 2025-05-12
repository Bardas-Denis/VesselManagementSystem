using AutoMapper;
using VesselApi.UnitOfWork;
using VesselManagementSystemAPI.DTOs;
using VesselManagementSystemAPI.Models;

namespace VesselManagementSystemAPI.Services
{
    public class OwnerService : IOwnerService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public OwnerService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        //public async Task<IEnumerable<OwnerDto>> GetAllAsync()
        //{
        //    var owners = await _uow.Owners.GetAllAsync(false);
        //    return owners.Select(o => _mapper.Map<OwnerDto>(o));
        //}

        //public async Task<OwnerDto> GetByIdAsync(int id)
        //{
        //    var owner = await _uow.Owners.GetByIdAsync(id);
        //    return _mapper.Map<OwnerDto>(owner);
        //}

        //public async Task<OwnerDto> CreateAsync(CreateOwnerDto dto)
        //{
        //    var owner = _mapper.Map<Owner>(dto);
        //    await _uow.Owners.AddAsync(owner);
        //    await _uow.CompleteAsync();
        //    return _mapper.Map<OwnerDto>(owner);
        //}

        //public async Task UpdateAsync(int id, UpdateOwnerDto dto)
        //{
        //    var owner = await _uow.Owners.GetByIdAsync(id);
        //    _mapper.Map(dto, owner);
        //    await _uow.CompleteAsync();
        //}

        public async Task DeleteAsync(int id)
        {
            var owner = await _uow.Owners.GetByIdAsync(id);
            if (owner == null)
            {
                throw new Exception($"Owner with ID {id} not found.");
            }
            _uow.Owners.Remove(owner);
            await _uow.CompleteAsync();
        }
    }
}
