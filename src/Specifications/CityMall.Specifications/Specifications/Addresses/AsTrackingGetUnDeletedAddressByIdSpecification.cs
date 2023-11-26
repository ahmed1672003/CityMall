
namespace CityMall.Specifications.Specifications.Addresses;
public sealed class AsTrackingGetUnDeletedAddressByIdSpecification : Specification<Address>
{
    public AsTrackingGetUnDeletedAddressByIdSpecification(string id) :
        base(a => a.Id.Equals(id))
    {

    }
}
