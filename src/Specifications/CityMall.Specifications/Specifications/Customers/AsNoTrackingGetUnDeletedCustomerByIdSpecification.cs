namespace CityMall.Specifications.Specifications.Customers;
public sealed class AsNoTrackingGetUnDeletedCustomerByIdSpecification : Specification<Customer>
{
    public AsNoTrackingGetUnDeletedCustomerByIdSpecification(string id)
        : base(c => c.Id.Equals(id))
    {
        StopTracking();
    }
}
