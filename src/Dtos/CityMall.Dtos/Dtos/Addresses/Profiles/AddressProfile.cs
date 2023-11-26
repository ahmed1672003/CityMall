using AutoMapper;

using CityMall.Domain.Entities;

namespace CityMall.Dtos.Dtos.Addresses.Profiles;
public sealed class AddressProfile : Profile
{
    public AddressProfile()
    {
        Map();
    }
    void Map()
    {
        CreateMap<AddAddressDto, Address>()
            .AfterMap((dto, model) =>
            {
                model.Id = $"{Guid.NewGuid()}{Guid.NewGuid()}".Replace("-", string.Empty);
            });
        CreateMap<UpdateAddressDto, Address>();
        CreateMap<Address, GetAddressDto>();
    }
}
