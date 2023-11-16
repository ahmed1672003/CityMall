namespace CityMall.Infrastructure.Repositories;
public sealed class CustomerRepository : Repository<Customer>, ICustomerRepository
{
    public CustomerRepository(ICityMallDbContext context) : base(context)
    {
    }
}
