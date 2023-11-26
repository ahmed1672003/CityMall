namespace CityMall.Specifications.Specifications.Customers;
public sealed class AsNoTrackingGetAllCustomerSpecification : Specification<Customer>
{
    public AsNoTrackingGetAllCustomerSpecification()
    {
        StopTracking();
        IgnorQueryFilter();
    }
}
