namespace CityMall.Specifications.Specifications.Users;
public sealed class AsNoTrackingGetUserByIdSpecification : Specification<User>
{
    public AsNoTrackingGetUserByIdSpecification(string id) : base(u => u.Id.Equals(id))
    {
        StopTracking();
        IgnorQueryFilter();
    }
}
