namespace CityMall.Specifications.Specifications.Customers;
public sealed class AsNoTrackingGetAllDeletedCustomerSpecification : Specification<Customer>
{
    public AsNoTrackingGetAllDeletedCustomerSpecification() : base(c => c.IsDeleted)
    {
        StopTracking();
        IgnorQueryFilter();
    }
}
