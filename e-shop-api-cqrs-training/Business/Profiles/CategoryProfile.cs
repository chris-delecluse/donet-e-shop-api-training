using AutoMapper;
using Business.Dtos.Category;
using E = Dal.Entities;

namespace Business.Profiles;

public class CategoryProfile : Profile
{
    public CategoryProfile()
    {
        CreateMap<E.Category, CategoryReadDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
    }
}
