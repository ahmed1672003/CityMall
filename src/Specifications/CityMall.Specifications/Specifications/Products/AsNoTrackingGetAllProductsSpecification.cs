namespace CityMall.Specifications.Specifications.Products;

public sealed class AsNoTrackingGetAllProductsSpecification : Specification<Product>
{
    public AsNoTrackingGetAllProductsSpecification()
    {
        StopTracking();
        IgnorQueryFilter();
    }
}
