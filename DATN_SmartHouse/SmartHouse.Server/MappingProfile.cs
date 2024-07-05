using AutoMapper;
using SmartHouse.Server.Entity;
using SmartHouse.Server.Model_DTO;
using SmartHouse.Server.Model_DTO.Supplier;
namespace SmartHouse.Server

{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
         CreateMap<TbSupplier, SupplierDTO>()
       .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
       .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
       .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
       .ForMember(dest => dest.Adress, opt => opt.MapFrom(src => src.Adress))
       .ForMember(dest => dest.ProvideProducst, opt => opt.MapFrom(src => src.ProvideProducst));
        }

    }
}
