namespace CityMall.Specifications.Specifications.Users;
public sealed class AsNoTrackingGetUserByUserNameSpecification : Specification<User>
{
    public AsNoTrackingGetUserByUserNameSpecification(string userName)
        : base(u => u.UserName.Equals(userName))
    {
        StopTracking();
        IgnorQueryFilter();
    }
}
