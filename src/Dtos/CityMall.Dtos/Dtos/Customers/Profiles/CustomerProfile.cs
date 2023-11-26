namespace CityMall.Dtos.Dtos.Customers.Profiles;
public sealed class CustomerProfile : Profile
{
    public CustomerProfile()
    {
        Map();
    }

    void Map()
    {
        CreateMap<AddCustomerDto, Customer>()
            .AfterMap((Dto, model) =>
            {
                model.Id = $"{Guid.NewGuid()}{Guid.NewGuid()}".Replace("-", string.Empty);
            });
        CreateMap<UpdateCustomerDto, Customer>();
        CreateMap<Customer, GetCustomerDto>();
    }
}
