namespace CityMall.Infrastructure.Repositories;
public sealed class AddressRepository : Repository<Address>, IAddressRepository
{
    public AddressRepository(ICityMallDbContext context) : base(context)
    {
    }
}
