using AutoMapper;
using VesselApi.UnitOfWork;
using VesselManagementSystemAPI.DTOs;
using VesselManagementSystemAPI.Models;
using VesselManagementSystemAPI.UnitOfWork;

namespace VesselManagementSystemAPI.Services
{
    public class ShipService : IShipService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public ShipService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ShipDto>> GetAllAsync()
        {
            var ships = await _uow.Ships.GetAllAsync(false);
            return ships.Select(s => _mapper.Map<ShipDto>(s));
        }

        public async Task<IEnumerable<ShipDtoWithDetails>> GetAllWithDetailsAsync()
        {
            var ships = await _uow.Ships.GetAllAsync(true);

            var shipDtos = ships.Select(ship =>
            {
                var dto = _mapper.Map<ShipDtoWithDetails>(ship);

                // Manually map Owners
                dto.Owners = ship.ShipOwners?.Select(so => new OwnerDto
                {
                    Id = so.Owner.Id,
                    OwnerName = so.Owner.OwnerName
                }).ToList();

                return dto;
            });

            return shipDtos;
            return shipDtos;
        }

        public async Task<ShipDtoWithDetails> GetByIdAsync(int id)
        {
            var ship = await _uow.Ships.GetByIdAsync(id);
            return _mapper.Map<ShipDtoWithDetails>(ship);
        }

        public async Task<ShipDtoWithDetails> CreateAsync(CreateShipDto dto)
        {
            var ship = _mapper.Map<Ship>(dto);
            await _uow.Ships.AddAsync(ship);
            await _uow.CompleteAsync();
            return _mapper.Map<ShipDtoWithDetails>(ship);
        }
        public async Task<ShipDtoWithDetails> CreateWithDetailsAsync(CreateShipWithDetailsDto dto)
        {
            var ship = _mapper.Map<Ship>(dto);

            ship.ShipOwners = new List<ShipOwner>();
            foreach (var ownerId in dto.OwnerIds)
            {
                ship.ShipOwners.Add(new ShipOwner
                {
                    OwnerId = ownerId
                });
            }

            await _uow.Ships.AddAsync(ship);
            await _uow.CompleteAsync();
            return _mapper.Map<ShipDtoWithDetails>(ship);
        }

        public async Task UpdateAsync(int id, UpdateShipDto dto)
        {
            var ship = await _uow.Ships.GetByIdAsync(id);

            if (ship == null)
            {
                throw new Exception($"Ship with ID {id} not found.");
            }

            _mapper.Map(dto, ship);

            if (dto.OwnerIds != null)
            {
                ship.ShipOwners.Clear();

                ship.ShipOwners = dto.OwnerIds.Select(ownerId => new ShipOwner
                {
                    OwnerId = ownerId,
                    ShipId = ship.Id
                }).ToList();
            }

            await _uow.CompleteAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var ship = await _uow.Ships.GetByIdAsync(id);
            if (ship == null)
            {
                throw new Exception($"Ship with ID {id} not found.");
            }
            _uow.Ships.Remove(ship);
            await _uow.CompleteAsync();
        }
    }
}
