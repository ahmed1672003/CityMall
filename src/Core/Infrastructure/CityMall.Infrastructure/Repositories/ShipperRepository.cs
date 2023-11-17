
namespace CityMall.Infrastructure.Repositories;
public sealed class ShipperRepository : Repository<Shipper>, IShipperRepository
{
    public ShipperRepository(ICityMallDbContext context) : base(context) { }
}
