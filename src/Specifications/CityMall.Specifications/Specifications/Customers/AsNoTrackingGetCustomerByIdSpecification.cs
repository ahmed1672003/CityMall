namespace CityMall.Specifications.Specifications.Customers;
public sealed class AsNoTrackingGetCustomerByIdSpecification : Specification<Customer>
{
    public AsNoTrackingGetCustomerByIdSpecification(string id)
        : base(c => c.Id.Equals(id))
    {
        StopTracking();
    }
}
