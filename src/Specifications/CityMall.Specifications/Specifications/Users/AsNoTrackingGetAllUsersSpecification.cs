namespace CityMall.Specifications.Specifications.Users;
public sealed class AsNoTrackingGetAllUsersSpecification : Specification<User>
{
    public AsNoTrackingGetAllUsersSpecification()
    {
        AsSplitQuery(true);
        StopTracking();
        IgnorQueryFilter();
    }
}
