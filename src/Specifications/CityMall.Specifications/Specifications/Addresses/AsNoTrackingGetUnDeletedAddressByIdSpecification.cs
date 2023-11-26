using CityMall.Domain.Entities;
namespace CityMall.Specifications.Specifications.Addresses;
public sealed class AsNoTrackingGetUnDeletedAddressByIdSpecification : Specification<Address>
{
    public AsNoTrackingGetUnDeletedAddressByIdSpecification(string id) :
        base(a => a.Id.Equals(id))
    {
        StopTracking();
    }
}
