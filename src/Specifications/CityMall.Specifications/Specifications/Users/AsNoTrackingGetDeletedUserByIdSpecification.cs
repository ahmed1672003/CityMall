namespace CityMall.Specifications.Specifications.Users;
public sealed class AsNoTrackingGetDeletedUserByIdSpecification : Specification<User>
{
    public AsNoTrackingGetDeletedUserByIdSpecification(string id) : base(u => u.IsDeleted && u.Id.Equals(id))
    {
        StopTracking();
        IgnorQueryFilter();
    }
}
