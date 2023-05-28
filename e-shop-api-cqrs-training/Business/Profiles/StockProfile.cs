using AutoMapper;
using Business.Dtos.Stock;
using E = Dal.Entities;

namespace Business.Profiles;

public class StockProfile: Profile
{
    public StockProfile()
    {
        CreateMap<E.ProductStock, StockReadDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity));
    }
}
