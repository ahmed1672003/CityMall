namespace CityMall.Specifications.Specifications.Users;
public sealed class AsNoTrackingGetAllUnDeletedUsersSpecification : Specification<User>
{
    public AsNoTrackingGetAllUnDeletedUsersSpecification()
    {
        StopTracking();
        AsSplitQuery(true);
    }
}
