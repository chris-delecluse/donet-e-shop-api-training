using AutoMapper;
using Business.Dtos.User;
using Dal.Entities;

namespace Business.Profiles;

public class UserProfile: Profile
{
    public UserProfile()
    {
        CreateMap<AppUser, UserReadDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
            .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email));
    }
}
