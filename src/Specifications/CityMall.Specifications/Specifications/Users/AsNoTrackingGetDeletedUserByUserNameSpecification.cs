namespace CityMall.Specifications.Specifications.Users;
public sealed class AsNoTrackingGetDeletedUserByUserNameSpecification : Specification<User>
{
    public AsNoTrackingGetDeletedUserByUserNameSpecification(string userName) :
        base(u => u.IsDeleted && u.UserName.Equals(userName))
    {
        StopTracking();
        IgnorQueryFilter();
    }
}
