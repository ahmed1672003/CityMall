namespace CityMall.Specifications.Specifications.Stocks;

public sealed class AsNoTrackingGetAllDeletedStocksSpecification : Specification<Stock>
{
    public AsNoTrackingGetAllDeletedStocksSpecification() : base(s => s.IsDeleted)
    {
        StopTracking();
        IgnorQueryFilter();
    }
}
