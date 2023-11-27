namespace CityMall.Specifications.Specifications.Stocks;
public sealed class AsNoTrackingGetStockByIdSpecification : Specification<Stock>
{
    public AsNoTrackingGetStockByIdSpecification(string id)
        : base(s => s.Id.Equals(id))
    {
        StopTracking();
    }
}
