namespace CityMall.Specifications.Specifications.Users;
public sealed class AsNoTrackingGetAllDeletedUsersSpecification : Specification<User>
{
    public AsNoTrackingGetAllDeletedUsersSpecification() : base(u => u.IsDeleted)
    {
        StopTracking();
        IgnorQueryFilter();
    }
}
