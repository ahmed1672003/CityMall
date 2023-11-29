namespace CityMall.Specifications.Specifications.ProductImages;
public sealed class AsNoTrackingGetProductImageByIdSpecification : Specification<ProductImage>
{
    public AsNoTrackingGetProductImageByIdSpecification(string id) : base(pi => pi.Id.Equals(id))
    {
        StopTracking();
    }
}
