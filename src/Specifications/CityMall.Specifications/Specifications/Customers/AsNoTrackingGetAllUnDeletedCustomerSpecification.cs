namespace CityMall.Specifications.Specifications.Customers;
public sealed class AsNoTrackingGetAllUnDeletedCustomerSpecification : Specification<Customer>
{
    public AsNoTrackingGetAllUnDeletedCustomerSpecification()
    {
        StopTracking();
    }
}
