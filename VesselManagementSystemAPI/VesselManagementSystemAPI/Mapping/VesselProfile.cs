using AutoMapper;
using VesselManagementSystemAPI.DTOs;
using VesselManagementSystemAPI.Models;

namespace VesselManagementSystemAPI.Mapping
{
    public class VesselProfile : Profile
    {
        public VesselProfile()
        {
            // Ship ↔ ShipDto
            CreateMap<Ship,ShipDto>();
            CreateMap<Ship, ShipDtoWithDetails>()
                .ForMember(dest => dest.ShipType, opt => opt.MapFrom(src => src.Category.ShipType))
                .ForMember(dest => dest.ShipTonnage, opt => opt.MapFrom(src => src.Category.ShipTonnage))
                .ForMember(dest => dest.Owners, opt => opt.Ignore());

            CreateMap<CreateShipDto, Ship>();
            CreateMap<CreateShipWithDetailsDto, Ship>()
            .ForMember(dest => dest.Category, opt => opt.MapFrom(src => new Category
            {
                ShipType = src.ShipType,
                ShipTonnage = src.ShipTonnage
                // ShipId will be handled by EF
            }))
            .ForMember(dest => dest.ShipOwners, opt => opt.Ignore());
            CreateMap<UpdateShipDto, Ship>().ForMember(dest => dest.Category, opt => opt.MapFrom(src => new Category
            {
                ShipType = src.ShipType,
                ShipTonnage = src.ShipTonnage
                // ShipId will be handled by EF
            }))
            .ForMember(dest => dest.ShipOwners, opt => opt.Ignore()); ;

            // Owner ↔ OwnerDto
            CreateMap<Owner, OwnerDto>();
            CreateMap<CreateOwnerDto, Owner>();
            CreateMap<UpdateOwnerDto, Owner>();

            // ShipOwner ↔ OwnerDto
            CreateMap<ShipOwner, OwnerDto>();
        }
    }
}
