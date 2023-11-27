namespace CityMall.Specifications.Specifications.Stocks;

public sealed class AsNoTrackingGetAllStocksSpecification : Specification<Stock>
{
    public AsNoTrackingGetAllStocksSpecification()
    {
        StopTracking();
        IgnorQueryFilter();
    }
}
