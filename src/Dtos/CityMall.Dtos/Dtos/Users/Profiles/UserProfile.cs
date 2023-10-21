using AutoMapper;

using CityMall.Domain.Entities.Identity;

namespace CityMall.Dtos.Dtos.Users.Profiles;
public sealed class UserProfile : Profile
{
    public UserProfile()
    {
        Map();
    }
    void Map()
    {
        CreateMap<AddUserDto, User>();
    }
}

